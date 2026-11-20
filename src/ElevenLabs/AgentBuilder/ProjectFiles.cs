using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentBuilder;

/// <summary>
/// File access for <see cref="AgentProject"/>: reads the index files and the configs they list, and writes files
/// owner-only, never through a symlink and never outside the project.
/// </summary>
/// <remarks>
/// Symlinks are resolved with <c>FileSystemInfo.LinkTarget</c> (.NET 6+). On net462 and netstandard2.0, which can't
/// read a link's target, any symlink (reparse point) inside the project is refused instead, and files are written
/// with the platform's default permissions, since those frameworks have no API to set a Unix file mode.
/// </remarks>
internal static class ProjectFiles
{
    private static readonly StringComparison PathComparison =
        Path.DirectorySeparatorChar == '\\' ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

    private static readonly UTF8Encoding Utf8NoBom = new(false);

    /// <summary>Reads the index files and every config they list. <c>Taken</c> lists the files already in the config directories.</summary>
    public static (Dictionary<string, string> Files, List<string> Taken, string Root) ReadProject(string dir)
    {
        var root = ProjectRoot(dir);
        var files = new Dictionary<string, string>();
        foreach (var index in new[] { AgentProject.AgentsFile, AgentProject.ToolsFile })
        {
            var text = ReadIfExists(ResolveInProject(root, index));
            if (text == null)
            {
                continue;
            }
            files[index] = text;
            JsonNode? parsed;
            try
            {
                parsed = JsonNode.Parse(text);
            }
            catch (JsonException)
            {
                continue; // AgentProject reports it, with the parse error.
            }
            var configs = new List<JsonNode?>();
            foreach (var entry in (parsed?["agents"] as JsonArray ?? new JsonArray()).OfType<JsonObject>())
            {
                configs.Add(entry["config"]);
                foreach (var branch in (entry["branches"] as JsonObject ?? new JsonObject()))
                {
                    configs.Add((branch.Value as JsonObject)?["config"]);
                }
            }
            foreach (var entry in (parsed?["tools"] as JsonArray ?? new JsonArray()).OfType<JsonObject>())
            {
                configs.Add(entry["config"]);
            }
            foreach (var config in configs)
            {
                if (AgentWire.Str(config) is not string path)
                {
                    throw new AgentProjectException($"{index} has an entry without a \"config\" path");
                }
                var content = ReadIfExists(ResolveInProject(root, path));
                if (content != null)
                {
                    files[ProjectFormat.NormalizePath(path)] = content;
                }
            }
        }
        var taken = new List<string>();
        foreach (var sub in new[] { AgentProject.AgentConfigsDir, AgentProject.ToolConfigsDir })
        {
            var path = Path.Combine(root, sub);
            if (Directory.Exists(path))
            {
                taken.AddRange(Directory.EnumerateFileSystemEntries(path).Select(entry => $"{sub}/{Path.GetFileName(entry)}"));
            }
        }
        return (files, taken, root);
    }

    /// <summary>Writes each file owner-only, creating directories as needed, never through a symlink or outside the project.</summary>
    public static void WriteProjectFiles(string root, IEnumerable<KeyValuePair<string, string>> files)
    {
        foreach (var file in files)
        {
            var target = ResolveInProject(root, file.Key);
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            if (IsSymlink(target))
            {
                throw new AgentProjectException($"Refusing to write {file.Key}: it's a symlink");
            }
            WriteOwnerOnly(target, file.Value);
        }
    }

    /// <summary>The project directory with symlinks resolved, where the framework can resolve them.</summary>
    private static string ProjectRoot(string dir)
    {
        var full = Path.GetFullPath(dir);
        if (!Directory.Exists(full))
        {
            throw new AgentProjectException($"{dir} isn't a directory");
        }
#if NET6_0_OR_GREATER
        return RealPath(full) ?? full;
#else
        return full;
#endif
    }

    /// <summary>
    /// The CLI's <c>resolve_in_project</c>: the absolute path for a project-relative one, refusing anything that
    /// escapes the project, including through a symlinked directory.
    /// </summary>
    internal static string ResolveInProject(string root, string path)
    {
        if (path.Trim().Length == 0 || path.Any(char.IsControl))
        {
            throw new AgentProjectException($"Invalid config path {JsonValue.Create(path)!.ToJsonString()}");
        }
        if (Path.IsPathRooted(path))
        {
            throw new AgentProjectException($"Config path {path} is outside the project");
        }
        var candidate = Path.GetFullPath(Path.Combine(root, path));
        if (!Inside(root, candidate))
        {
            throw new AgentProjectException($"Config path {path} is outside the project");
        }
#if NET6_0_OR_GREATER
        // The deepest part of the path that exists, with symlinks resolved, must still be inside.
        for (var ancestor = candidate; ; )
        {
            var real = RealPath(ancestor);
            if (real != null)
            {
                if (!Inside(root, real))
                {
                    throw new AgentProjectException($"Config path {path} leads outside the project through a symlink");
                }
                return candidate;
            }
            var parent = Path.GetDirectoryName(ancestor);
            if (parent == null || parent == ancestor)
            {
                throw new AgentProjectException($"Config path {path} is outside the project");
            }
            ancestor = parent;
        }
#else
        // No way to read a link's target here: refuse any symlink between the project root and the file.
        var relative = candidate.Substring(root.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        var current = root;
        var separators = new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
        foreach (var part in relative.Split(separators, StringSplitOptions.RemoveEmptyEntries))
        {
            current = Path.Combine(current, part);
            if (IsSymlink(current))
            {
                throw new AgentProjectException(
                    $"Config path {path} goes through a symlink, which this framework can't check stays inside the project"
                );
            }
        }
        return candidate;
#endif
    }

    private static bool Inside(string root, string path)
    {
        var trimmed = root.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        return string.Equals(path, trimmed, PathComparison)
            || path.StartsWith(trimmed + Path.DirectorySeparatorChar, PathComparison);
    }

    private static bool IsSymlink(string path)
    {
#if NET6_0_OR_GREATER
        return new FileInfo(path).LinkTarget != null;
#else
        try
        {
            return (File.GetAttributes(path) & FileAttributes.ReparsePoint) != 0;
        }
        catch (Exception ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
        {
            return false;
        }
#endif
    }

#if NET6_0_OR_GREATER
    /// <summary>The path with every symlink resolved, like POSIX <c>realpath</c>, or <c>null</c> if it doesn't exist.</summary>
    private static string? RealPath(string path, int hops = 0)
    {
        if (hops > 40)
        {
            throw new AgentProjectException($"Too many levels of symlinks at {path}");
        }
        var full = Path.GetFullPath(path);
        var rootPart = Path.GetPathRoot(full) ?? "";
        var parts = full.Substring(rootPart.Length)
            .Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
        var current = rootPart;
        for (var i = 0; i < parts.Length; i++)
        {
            var next = Path.Combine(current, parts[i]);
            var link = new FileInfo(next).LinkTarget;
            if (link != null)
            {
                var resolved = Path.IsPathRooted(link) ? link : Path.Combine(current, link);
                var rest = parts.Skip(i + 1).ToArray();
                return RealPath(rest.Length == 0 ? resolved : Path.Combine(new[] { resolved }.Concat(rest).ToArray()), hops + 1);
            }
            if (!Directory.Exists(next) && !File.Exists(next))
            {
                return null;
            }
            current = next;
        }
        return current;
    }
#endif

    private static void WriteOwnerOnly(string target, string text)
    {
        var bytes = Utf8NoBom.GetBytes(text);
#if NET7_0_OR_GREATER
        if (!OperatingSystem.IsWindows())
        {
            const UnixFileMode ownerOnly = UnixFileMode.UserRead | UnixFileMode.UserWrite;
            using (
                var stream = new FileStream(
                    target,
                    new FileStreamOptions
                    {
                        Mode = FileMode.Create,
                        Access = FileAccess.Write,
                        Share = FileShare.None,
                        UnixCreateMode = ownerOnly,
                    }
                )
            )
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            // UnixCreateMode applies only when the file is new; tighten an existing one too.
            File.SetUnixFileMode(target, ownerOnly);
            return;
        }
#endif
        File.WriteAllBytes(target, bytes);
    }

    private static string? ReadIfExists(string path)
    {
        try
        {
            return File.ReadAllText(path, Utf8NoBom);
        }
        catch (Exception ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
        {
            return null;
        }
    }
}
