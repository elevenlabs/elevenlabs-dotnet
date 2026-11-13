// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentAnalysisItemsInputDataCollectionItem.JsonConverter))]
[Serializable]
public record AgentAnalysisItemsInputDataCollectionItem
{
    internal AgentAnalysisItemsInputDataCollectionItem(string type, object? value)
    {
        Source = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentAnalysisItemsInputDataCollectionItem with <see cref="AgentAnalysisItemsInputDataCollectionItem.System"/>.
    /// </summary>
    public AgentAnalysisItemsInputDataCollectionItem(
        AgentAnalysisItemsInputDataCollectionItem.System value
    )
    {
        Source = "system";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentAnalysisItemsInputDataCollectionItem with <see cref="AgentAnalysisItemsInputDataCollectionItem.User"/>.
    /// </summary>
    public AgentAnalysisItemsInputDataCollectionItem(
        AgentAnalysisItemsInputDataCollectionItem.User value
    )
    {
        Source = "user";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Source"/> is "system"
    /// </summary>
    public bool IsSystem => Source == "system";

    /// <summary>
    /// Returns true if <see cref="Source"/> is "user"
    /// </summary>
    public bool IsUser => Source == "user";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AttachedSystemDataCollectionRef"/> if <see cref="Source"/> is 'system', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'system'.</exception>
    public global::ElevenLabs.AttachedSystemDataCollectionRef AsSystem() =>
        IsSystem
            ? (global::ElevenLabs.AttachedSystemDataCollectionRef)Value!
            : throw new global::System.Exception(
                "AgentAnalysisItemsInputDataCollectionItem.Source is not 'system'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AttachedUserDataCollectionRef"/> if <see cref="Source"/> is 'user', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'user'.</exception>
    public global::ElevenLabs.AttachedUserDataCollectionRef AsUser() =>
        IsUser
            ? (global::ElevenLabs.AttachedUserDataCollectionRef)Value!
            : throw new global::System.Exception(
                "AgentAnalysisItemsInputDataCollectionItem.Source is not 'user'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.AttachedSystemDataCollectionRef, T> onSystem,
        Func<global::ElevenLabs.AttachedUserDataCollectionRef, T> onUser,
        Func<string, object?, T> onUnknown_
    )
    {
        return Source switch
        {
            "system" => onSystem(AsSystem()),
            "user" => onUser(AsUser()),
            _ => onUnknown_(Source, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.AttachedSystemDataCollectionRef> onSystem,
        Action<global::ElevenLabs.AttachedUserDataCollectionRef> onUser,
        Action<string, object?> onUnknown_
    )
    {
        switch (Source)
        {
            case "system":
                onSystem(AsSystem());
                break;
            case "user":
                onUser(AsUser());
                break;
            default:
                onUnknown_(Source, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AttachedSystemDataCollectionRef"/> and returns true if successful.
    /// </summary>
    public bool TryAsSystem(out global::ElevenLabs.AttachedSystemDataCollectionRef? value)
    {
        if (Source == "system")
        {
            value = (global::ElevenLabs.AttachedSystemDataCollectionRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AttachedUserDataCollectionRef"/> and returns true if successful.
    /// </summary>
    public bool TryAsUser(out global::ElevenLabs.AttachedUserDataCollectionRef? value)
    {
        if (Source == "user")
        {
            value = (global::ElevenLabs.AttachedUserDataCollectionRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentAnalysisItemsInputDataCollectionItem(
        AgentAnalysisItemsInputDataCollectionItem.System value
    ) => new(value);

    public static implicit operator AgentAnalysisItemsInputDataCollectionItem(
        AgentAnalysisItemsInputDataCollectionItem.User value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentAnalysisItemsInputDataCollectionItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AgentAnalysisItemsInputDataCollectionItem).IsAssignableFrom(typeToConvert);

        public override AgentAnalysisItemsInputDataCollectionItem Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("source", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'source'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'source' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'source' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'source' is null");

            var value = discriminator switch
            {
                "system" => json.Deserialize<global::ElevenLabs.AttachedSystemDataCollectionRef?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AttachedSystemDataCollectionRef"
                    ),
                "user" => json.Deserialize<global::ElevenLabs.AttachedUserDataCollectionRef?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AttachedUserDataCollectionRef"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentAnalysisItemsInputDataCollectionItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentAnalysisItemsInputDataCollectionItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Source switch
                {
                    "system" => JsonSerializer.SerializeToNode(value.Value, options),
                    "user" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["source"] = value.Source;
            json.WriteTo(writer, options);
        }

        public override AgentAnalysisItemsInputDataCollectionItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AgentAnalysisItemsInputDataCollectionItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentAnalysisItemsInputDataCollectionItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Source);
        }
    }

    /// <summary>
    /// Discriminated union type for system
    /// </summary>
    [Serializable]
    public struct System
    {
        public System(global::ElevenLabs.AttachedSystemDataCollectionRef value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AttachedSystemDataCollectionRef Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentAnalysisItemsInputDataCollectionItem.System(
            global::ElevenLabs.AttachedSystemDataCollectionRef value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user
    /// </summary>
    [Serializable]
    public struct User
    {
        public User(global::ElevenLabs.AttachedUserDataCollectionRef value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AttachedUserDataCollectionRef Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentAnalysisItemsInputDataCollectionItem.User(
            global::ElevenLabs.AttachedUserDataCollectionRef value
        ) => new(value);
    }
}
