// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentAnalysisItemsInputEvaluationCriteriaItem.JsonConverter))]
[Serializable]
public record AgentAnalysisItemsInputEvaluationCriteriaItem
{
    internal AgentAnalysisItemsInputEvaluationCriteriaItem(string type, object? value)
    {
        Source = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentAnalysisItemsInputEvaluationCriteriaItem with <see cref="AgentAnalysisItemsInputEvaluationCriteriaItem.System"/>.
    /// </summary>
    public AgentAnalysisItemsInputEvaluationCriteriaItem(
        AgentAnalysisItemsInputEvaluationCriteriaItem.System value
    )
    {
        Source = "system";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentAnalysisItemsInputEvaluationCriteriaItem with <see cref="AgentAnalysisItemsInputEvaluationCriteriaItem.User"/>.
    /// </summary>
    public AgentAnalysisItemsInputEvaluationCriteriaItem(
        AgentAnalysisItemsInputEvaluationCriteriaItem.User value
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
    /// Returns the value as a <see cref="global::ElevenLabs.AttachedSystemEvaluationRef"/> if <see cref="Source"/> is 'system', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'system'.</exception>
    public global::ElevenLabs.AttachedSystemEvaluationRef AsSystem() =>
        IsSystem
            ? (global::ElevenLabs.AttachedSystemEvaluationRef)Value!
            : throw new global::System.Exception(
                "AgentAnalysisItemsInputEvaluationCriteriaItem.Source is not 'system'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AttachedUserEvaluationRef"/> if <see cref="Source"/> is 'user', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'user'.</exception>
    public global::ElevenLabs.AttachedUserEvaluationRef AsUser() =>
        IsUser
            ? (global::ElevenLabs.AttachedUserEvaluationRef)Value!
            : throw new global::System.Exception(
                "AgentAnalysisItemsInputEvaluationCriteriaItem.Source is not 'user'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.AttachedSystemEvaluationRef, T> onSystem,
        Func<global::ElevenLabs.AttachedUserEvaluationRef, T> onUser,
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
        Action<global::ElevenLabs.AttachedSystemEvaluationRef> onSystem,
        Action<global::ElevenLabs.AttachedUserEvaluationRef> onUser,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AttachedSystemEvaluationRef"/> and returns true if successful.
    /// </summary>
    public bool TryAsSystem(out global::ElevenLabs.AttachedSystemEvaluationRef? value)
    {
        if (Source == "system")
        {
            value = (global::ElevenLabs.AttachedSystemEvaluationRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AttachedUserEvaluationRef"/> and returns true if successful.
    /// </summary>
    public bool TryAsUser(out global::ElevenLabs.AttachedUserEvaluationRef? value)
    {
        if (Source == "user")
        {
            value = (global::ElevenLabs.AttachedUserEvaluationRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentAnalysisItemsInputEvaluationCriteriaItem(
        AgentAnalysisItemsInputEvaluationCriteriaItem.System value
    ) => new(value);

    public static implicit operator AgentAnalysisItemsInputEvaluationCriteriaItem(
        AgentAnalysisItemsInputEvaluationCriteriaItem.User value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<AgentAnalysisItemsInputEvaluationCriteriaItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AgentAnalysisItemsInputEvaluationCriteriaItem).IsAssignableFrom(typeToConvert);

        public override AgentAnalysisItemsInputEvaluationCriteriaItem Read(
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
                "system" => json.Deserialize<global::ElevenLabs.AttachedSystemEvaluationRef?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AttachedSystemEvaluationRef"
                    ),
                "user" => json.Deserialize<global::ElevenLabs.AttachedUserEvaluationRef?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AttachedUserEvaluationRef"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentAnalysisItemsInputEvaluationCriteriaItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentAnalysisItemsInputEvaluationCriteriaItem value,
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

        public override AgentAnalysisItemsInputEvaluationCriteriaItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AgentAnalysisItemsInputEvaluationCriteriaItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentAnalysisItemsInputEvaluationCriteriaItem value,
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
        public System(global::ElevenLabs.AttachedSystemEvaluationRef value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AttachedSystemEvaluationRef Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentAnalysisItemsInputEvaluationCriteriaItem.System(
            global::ElevenLabs.AttachedSystemEvaluationRef value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user
    /// </summary>
    [Serializable]
    public struct User
    {
        public User(global::ElevenLabs.AttachedUserEvaluationRef value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AttachedUserEvaluationRef Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentAnalysisItemsInputEvaluationCriteriaItem.User(
            global::ElevenLabs.AttachedUserEvaluationRef value
        ) => new(value);
    }
}
