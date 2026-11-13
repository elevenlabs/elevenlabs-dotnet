using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace;

/// <summary>Role to grant to the target: one of 'admin', 'editor', 'commenter', or 'viewer'.</summary>
[JsonConverter(
    typeof(BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole.BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRoleSerializer)
)]
[Serializable]
public readonly record struct BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole
    : IStringEnum
{
    public static readonly BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole Admin =
        new(Values.Admin);

    public static readonly BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole Editor =
        new(Values.Editor);

    public static readonly BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole Commenter =
        new(Values.Commenter);

    public static readonly BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole Viewer =
        new(Values.Viewer);

    public BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole FromCustom(
        string value
    )
    {
        return new BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole value
    ) => value.Value;

    public static explicit operator BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole(
        string value
    ) => new(value);

    internal class BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRoleSerializer
        : JsonConverter<BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole>
    {
        public override BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyShareWorkspaceResourceV1WorkspaceResourcesResourceIdSharePostRole value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Admin = "admin";

        public const string Editor = "editor";

        public const string Commenter = "commenter";

        public const string Viewer = "viewer";
    }
}
