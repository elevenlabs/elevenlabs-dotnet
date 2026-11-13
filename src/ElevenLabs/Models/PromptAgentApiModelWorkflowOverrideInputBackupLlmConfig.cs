// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Configuration for backup LLM cascading. Can be disabled, use system defaults, or specify custom order.</summary>
[JsonConverter(typeof(PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig.JsonConverter))]
[Serializable]
public class PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig
{
    private PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig from a BackupLlmDefault value.
    /// </summary>
    public static PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig FromBackupLlmDefault(
        global::ElevenLabs.BackupLlmDefault value
    ) => new("backupLlmDefault", value);

    /// <summary>
    /// Create a PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig from a BackupLlmDisabled value.
    /// </summary>
    public static PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig FromBackupLlmDisabled(
        global::ElevenLabs.BackupLlmDisabled value
    ) => new("backupLlmDisabled", value);

    /// <summary>
    /// Create a PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig from a BackupLlmOverride value.
    /// </summary>
    public static PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig FromBackupLlmOverride(
        global::ElevenLabs.BackupLlmOverride value
    ) => new("backupLlmOverride", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "backupLlmDefault".
    /// </summary>
    public bool IsBackupLlmDefault() => Type == "backupLlmDefault";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "backupLlmDisabled".
    /// </summary>
    public bool IsBackupLlmDisabled() => Type == "backupLlmDisabled";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "backupLlmOverride".
    /// </summary>
    public bool IsBackupLlmOverride() => Type == "backupLlmOverride";

    /// <summary>
    /// Returns the value as a BackupLlmDefault if <see cref="Type"/> is "backupLlmDefault", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'backupLlmDefault'.</exception>
    public global::ElevenLabs.BackupLlmDefault AsBackupLlmDefault() =>
        IsBackupLlmDefault()
            ? (global::ElevenLabs.BackupLlmDefault)Value!
            : throw new ElevenLabsClientException("Union type is not 'backupLlmDefault'");

    /// <summary>
    /// Returns the value as a BackupLlmDisabled if <see cref="Type"/> is "backupLlmDisabled", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'backupLlmDisabled'.</exception>
    public global::ElevenLabs.BackupLlmDisabled AsBackupLlmDisabled() =>
        IsBackupLlmDisabled()
            ? (global::ElevenLabs.BackupLlmDisabled)Value!
            : throw new ElevenLabsClientException("Union type is not 'backupLlmDisabled'");

    /// <summary>
    /// Returns the value as a BackupLlmOverride if <see cref="Type"/> is "backupLlmOverride", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'backupLlmOverride'.</exception>
    public global::ElevenLabs.BackupLlmOverride AsBackupLlmOverride() =>
        IsBackupLlmOverride()
            ? (global::ElevenLabs.BackupLlmOverride)Value!
            : throw new ElevenLabsClientException("Union type is not 'backupLlmOverride'");

    /// <summary>
    /// Attempts to cast the value to a BackupLlmDefault and returns true if successful.
    /// </summary>
    public bool TryGetBackupLlmDefault(out global::ElevenLabs.BackupLlmDefault? value)
    {
        if (Type == "backupLlmDefault")
        {
            value = (global::ElevenLabs.BackupLlmDefault)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a BackupLlmDisabled and returns true if successful.
    /// </summary>
    public bool TryGetBackupLlmDisabled(out global::ElevenLabs.BackupLlmDisabled? value)
    {
        if (Type == "backupLlmDisabled")
        {
            value = (global::ElevenLabs.BackupLlmDisabled)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a BackupLlmOverride and returns true if successful.
    /// </summary>
    public bool TryGetBackupLlmOverride(out global::ElevenLabs.BackupLlmOverride? value)
    {
        if (Type == "backupLlmOverride")
        {
            value = (global::ElevenLabs.BackupLlmOverride)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.BackupLlmDefault, T> onBackupLlmDefault,
        global::System.Func<global::ElevenLabs.BackupLlmDisabled, T> onBackupLlmDisabled,
        global::System.Func<global::ElevenLabs.BackupLlmOverride, T> onBackupLlmOverride
    )
    {
        return Type switch
        {
            "backupLlmDefault" => onBackupLlmDefault(AsBackupLlmDefault()),
            "backupLlmDisabled" => onBackupLlmDisabled(AsBackupLlmDisabled()),
            "backupLlmOverride" => onBackupLlmOverride(AsBackupLlmOverride()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.BackupLlmDefault> onBackupLlmDefault,
        global::System.Action<global::ElevenLabs.BackupLlmDisabled> onBackupLlmDisabled,
        global::System.Action<global::ElevenLabs.BackupLlmOverride> onBackupLlmOverride
    )
    {
        switch (Type)
        {
            case "backupLlmDefault":
                onBackupLlmDefault(AsBackupLlmDefault());
                break;
            case "backupLlmDisabled":
                onBackupLlmDisabled(AsBackupLlmDisabled());
                break;
            case "backupLlmOverride":
                onBackupLlmOverride(AsBackupLlmOverride());
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(
        global::ElevenLabs.BackupLlmDefault value
    ) => new("backupLlmDefault", value);

    public static implicit operator PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(
        global::ElevenLabs.BackupLlmDisabled value
    ) => new("backupLlmDisabled", value);

    public static implicit operator PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(
        global::ElevenLabs.BackupLlmOverride value
    ) => new("backupLlmOverride", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig>
    {
        public override PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                // A payload carrying a member's literal decodes as that member or not at all.
                var matchedLiteral = false;

                if (HasLiteral(document, "preference", "default"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.BackupLlmDefault),
                            options
                        );
                        if (value != null)
                        {
                            return new PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(
                                "backupLlmDefault",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "preference", "disabled"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.BackupLlmDisabled),
                            options
                        );
                        if (value != null)
                        {
                            return new PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(
                                "backupLlmDisabled",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "preference", "override"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.BackupLlmOverride),
                            options
                        );
                        if (value != null)
                        {
                            return new PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(
                                "backupLlmOverride",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (matchedLiteral)
                {
                    throw new JsonException(
                        "Cannot deserialize JSON object into PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "backupLlmDefault",
                        typeof(global::ElevenLabs.BackupLlmDefault),
                        new[] { "preference" }
                    ),
                    (
                        "backupLlmDisabled",
                        typeof(global::ElevenLabs.BackupLlmDisabled),
                        new[] { "preference" }
                    ),
                    (
                        "backupLlmOverride",
                        typeof(global::ElevenLabs.BackupLlmOverride),
                        global::System.Array.Empty<string>()
                    ),
                };

                foreach (var (key, type, anyOfKeys) in types)
                {
                    // A member whose properties are all optional deserializes from any object, so it
                    // only gets a turn when the payload carries one of its own keys.
                    if (anyOfKeys.Length > 0 && !HasAnyProperty(document, anyOfKeys))
                    {
                        continue;
                    }

                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig(
                                key,
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PromptAgentApiModelWorkflowOverrideInputBackupLlmConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }

        private static bool HasLiteral(JsonDocument document, string key, string expected)
        {
            if (!document.RootElement.TryGetProperty(key, out var property))
            {
                return false;
            }

            return property.ValueKind == JsonValueKind.String && property.GetString() == expected;
        }

        private static bool HasAnyProperty(JsonDocument document, string[] keys)
        {
            foreach (var key in keys)
            {
                if (document.RootElement.TryGetProperty(key, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
