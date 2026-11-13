// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Configuration for backup LLM cascading. Can be disabled, use system defaults, or specify custom order.</summary>
[JsonConverter(typeof(PromptAgentApiModelOutputBackupLlmConfig.JsonConverter))]
[Serializable]
public record PromptAgentApiModelOutputBackupLlmConfig
{
    internal PromptAgentApiModelOutputBackupLlmConfig(string type, object? value)
    {
        Preference = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelOutputBackupLlmConfig with <see cref="PromptAgentApiModelOutputBackupLlmConfig.Default"/>.
    /// </summary>
    public PromptAgentApiModelOutputBackupLlmConfig(
        PromptAgentApiModelOutputBackupLlmConfig.Default value
    )
    {
        Preference = "default";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelOutputBackupLlmConfig with <see cref="PromptAgentApiModelOutputBackupLlmConfig.Disabled"/>.
    /// </summary>
    public PromptAgentApiModelOutputBackupLlmConfig(
        PromptAgentApiModelOutputBackupLlmConfig.Disabled value
    )
    {
        Preference = "disabled";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelOutputBackupLlmConfig with <see cref="PromptAgentApiModelOutputBackupLlmConfig.Override"/>.
    /// </summary>
    public PromptAgentApiModelOutputBackupLlmConfig(
        PromptAgentApiModelOutputBackupLlmConfig.Override value
    )
    {
        Preference = "override";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("preference")]
    public string Preference { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Preference"/> is "default"
    /// </summary>
    public bool IsDefault => Preference == "default";

    /// <summary>
    /// Returns true if <see cref="Preference"/> is "disabled"
    /// </summary>
    public bool IsDisabled => Preference == "disabled";

    /// <summary>
    /// Returns true if <see cref="Preference"/> is "override"
    /// </summary>
    public bool IsOverride => Preference == "override";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BackupLlmDefault"/> if <see cref="Preference"/> is 'default', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Preference"/> is not 'default'.</exception>
    public global::ElevenLabs.BackupLlmDefault AsDefault() =>
        IsDefault
            ? (global::ElevenLabs.BackupLlmDefault)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelOutputBackupLlmConfig.Preference is not 'default'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BackupLlmDisabled"/> if <see cref="Preference"/> is 'disabled', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Preference"/> is not 'disabled'.</exception>
    public global::ElevenLabs.BackupLlmDisabled AsDisabled() =>
        IsDisabled
            ? (global::ElevenLabs.BackupLlmDisabled)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelOutputBackupLlmConfig.Preference is not 'disabled'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BackupLlmOverride"/> if <see cref="Preference"/> is 'override', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Preference"/> is not 'override'.</exception>
    public global::ElevenLabs.BackupLlmOverride AsOverride() =>
        IsOverride
            ? (global::ElevenLabs.BackupLlmOverride)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelOutputBackupLlmConfig.Preference is not 'override'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.BackupLlmDefault, T> onDefault,
        Func<global::ElevenLabs.BackupLlmDisabled, T> onDisabled,
        Func<global::ElevenLabs.BackupLlmOverride, T> onOverride,
        Func<string, object?, T> onUnknown_
    )
    {
        return Preference switch
        {
            "default" => onDefault(AsDefault()),
            "disabled" => onDisabled(AsDisabled()),
            "override" => onOverride(AsOverride()),
            _ => onUnknown_(Preference, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.BackupLlmDefault> onDefault,
        Action<global::ElevenLabs.BackupLlmDisabled> onDisabled,
        Action<global::ElevenLabs.BackupLlmOverride> onOverride,
        Action<string, object?> onUnknown_
    )
    {
        switch (Preference)
        {
            case "default":
                onDefault(AsDefault());
                break;
            case "disabled":
                onDisabled(AsDisabled());
                break;
            case "override":
                onOverride(AsOverride());
                break;
            default:
                onUnknown_(Preference, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BackupLlmDefault"/> and returns true if successful.
    /// </summary>
    public bool TryAsDefault(out global::ElevenLabs.BackupLlmDefault? value)
    {
        if (Preference == "default")
        {
            value = (global::ElevenLabs.BackupLlmDefault)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BackupLlmDisabled"/> and returns true if successful.
    /// </summary>
    public bool TryAsDisabled(out global::ElevenLabs.BackupLlmDisabled? value)
    {
        if (Preference == "disabled")
        {
            value = (global::ElevenLabs.BackupLlmDisabled)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BackupLlmOverride"/> and returns true if successful.
    /// </summary>
    public bool TryAsOverride(out global::ElevenLabs.BackupLlmOverride? value)
    {
        if (Preference == "override")
        {
            value = (global::ElevenLabs.BackupLlmOverride)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PromptAgentApiModelOutputBackupLlmConfig(
        PromptAgentApiModelOutputBackupLlmConfig.Default value
    ) => new(value);

    public static implicit operator PromptAgentApiModelOutputBackupLlmConfig(
        PromptAgentApiModelOutputBackupLlmConfig.Disabled value
    ) => new(value);

    public static implicit operator PromptAgentApiModelOutputBackupLlmConfig(
        PromptAgentApiModelOutputBackupLlmConfig.Override value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PromptAgentApiModelOutputBackupLlmConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PromptAgentApiModelOutputBackupLlmConfig).IsAssignableFrom(typeToConvert);

        public override PromptAgentApiModelOutputBackupLlmConfig Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("preference", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'preference'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'preference' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'preference' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'preference' is null");

            var value = discriminator switch
            {
                "default" => json.Deserialize<global::ElevenLabs.BackupLlmDefault?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BackupLlmDefault"
                    ),
                "disabled" => json.Deserialize<global::ElevenLabs.BackupLlmDisabled?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BackupLlmDisabled"
                    ),
                "override" => json.Deserialize<global::ElevenLabs.BackupLlmOverride?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BackupLlmOverride"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new PromptAgentApiModelOutputBackupLlmConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromptAgentApiModelOutputBackupLlmConfig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Preference switch
                {
                    "default" => JsonSerializer.SerializeToNode(value.Value, options),
                    "disabled" => JsonSerializer.SerializeToNode(value.Value, options),
                    "override" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["preference"] = value.Preference;
            json.WriteTo(writer, options);
        }

        public override PromptAgentApiModelOutputBackupLlmConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PromptAgentApiModelOutputBackupLlmConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PromptAgentApiModelOutputBackupLlmConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Preference);
        }
    }

    /// <summary>
    /// Discriminated union type for default
    /// </summary>
    [Serializable]
    public struct Default
    {
        public Default(global::ElevenLabs.BackupLlmDefault value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BackupLlmDefault Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelOutputBackupLlmConfig.Default(
            global::ElevenLabs.BackupLlmDefault value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for disabled
    /// </summary>
    [Serializable]
    public struct Disabled
    {
        public Disabled(global::ElevenLabs.BackupLlmDisabled value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BackupLlmDisabled Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelOutputBackupLlmConfig.Disabled(
            global::ElevenLabs.BackupLlmDisabled value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for override
    /// </summary>
    [Serializable]
    public struct Override
    {
        public Override(global::ElevenLabs.BackupLlmOverride value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BackupLlmOverride Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelOutputBackupLlmConfig.Override(
            global::ElevenLabs.BackupLlmOverride value
        ) => new(value);
    }
}
