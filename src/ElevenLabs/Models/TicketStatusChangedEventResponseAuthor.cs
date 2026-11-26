// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TicketStatusChangedEventResponseAuthor.JsonConverter))]
[Serializable]
public record TicketStatusChangedEventResponseAuthor
{
    internal TicketStatusChangedEventResponseAuthor(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TicketStatusChangedEventResponseAuthor with <see cref="TicketStatusChangedEventResponseAuthor.AiAgent"/>.
    /// </summary>
    public TicketStatusChangedEventResponseAuthor(
        TicketStatusChangedEventResponseAuthor.AiAgent value
    )
    {
        Type = "ai_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TicketStatusChangedEventResponseAuthor with <see cref="TicketStatusChangedEventResponseAuthor.HumanAgent"/>.
    /// </summary>
    public TicketStatusChangedEventResponseAuthor(
        TicketStatusChangedEventResponseAuthor.HumanAgent value
    )
    {
        Type = "human_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TicketStatusChangedEventResponseAuthor with <see cref="TicketStatusChangedEventResponseAuthor.Requester"/>.
    /// </summary>
    public TicketStatusChangedEventResponseAuthor(
        TicketStatusChangedEventResponseAuthor.Requester value
    )
    {
        Type = "requester";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ai_agent"
    /// </summary>
    public bool IsAiAgent => Type == "ai_agent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "human_agent"
    /// </summary>
    public bool IsHumanAgent => Type == "human_agent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "requester"
    /// </summary>
    public bool IsRequester => Type == "requester";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketEventAiAgentAuthorResponse"/> if <see cref="Type"/> is 'ai_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ai_agent'.</exception>
    public global::ElevenLabs.TicketEventAiAgentAuthorResponse AsAiAgent() =>
        IsAiAgent
            ? (global::ElevenLabs.TicketEventAiAgentAuthorResponse)Value!
            : throw new global::System.Exception(
                "TicketStatusChangedEventResponseAuthor.Type is not 'ai_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketEventHumanAgentAuthorResponse"/> if <see cref="Type"/> is 'human_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'human_agent'.</exception>
    public global::ElevenLabs.TicketEventHumanAgentAuthorResponse AsHumanAgent() =>
        IsHumanAgent
            ? (global::ElevenLabs.TicketEventHumanAgentAuthorResponse)Value!
            : throw new global::System.Exception(
                "TicketStatusChangedEventResponseAuthor.Type is not 'human_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketEventRequesterAuthorResponse"/> if <see cref="Type"/> is 'requester', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'requester'.</exception>
    public global::ElevenLabs.TicketEventRequesterAuthorResponse AsRequester() =>
        IsRequester
            ? (global::ElevenLabs.TicketEventRequesterAuthorResponse)Value!
            : throw new global::System.Exception(
                "TicketStatusChangedEventResponseAuthor.Type is not 'requester'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TicketEventAiAgentAuthorResponse, T> onAiAgent,
        Func<global::ElevenLabs.TicketEventHumanAgentAuthorResponse, T> onHumanAgent,
        Func<global::ElevenLabs.TicketEventRequesterAuthorResponse, T> onRequester,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "ai_agent" => onAiAgent(AsAiAgent()),
            "human_agent" => onHumanAgent(AsHumanAgent()),
            "requester" => onRequester(AsRequester()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TicketEventAiAgentAuthorResponse> onAiAgent,
        Action<global::ElevenLabs.TicketEventHumanAgentAuthorResponse> onHumanAgent,
        Action<global::ElevenLabs.TicketEventRequesterAuthorResponse> onRequester,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "ai_agent":
                onAiAgent(AsAiAgent());
                break;
            case "human_agent":
                onHumanAgent(AsHumanAgent());
                break;
            case "requester":
                onRequester(AsRequester());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketEventAiAgentAuthorResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsAiAgent(out global::ElevenLabs.TicketEventAiAgentAuthorResponse? value)
    {
        if (Type == "ai_agent")
        {
            value = (global::ElevenLabs.TicketEventAiAgentAuthorResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketEventHumanAgentAuthorResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsHumanAgent(out global::ElevenLabs.TicketEventHumanAgentAuthorResponse? value)
    {
        if (Type == "human_agent")
        {
            value = (global::ElevenLabs.TicketEventHumanAgentAuthorResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketEventRequesterAuthorResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsRequester(out global::ElevenLabs.TicketEventRequesterAuthorResponse? value)
    {
        if (Type == "requester")
        {
            value = (global::ElevenLabs.TicketEventRequesterAuthorResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TicketStatusChangedEventResponseAuthor(
        TicketStatusChangedEventResponseAuthor.AiAgent value
    ) => new(value);

    public static implicit operator TicketStatusChangedEventResponseAuthor(
        TicketStatusChangedEventResponseAuthor.HumanAgent value
    ) => new(value);

    public static implicit operator TicketStatusChangedEventResponseAuthor(
        TicketStatusChangedEventResponseAuthor.Requester value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TicketStatusChangedEventResponseAuthor>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TicketStatusChangedEventResponseAuthor).IsAssignableFrom(typeToConvert);

        public override TicketStatusChangedEventResponseAuthor Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "ai_agent" =>
                    json.Deserialize<global::ElevenLabs.TicketEventAiAgentAuthorResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketEventAiAgentAuthorResponse"
                        ),
                "human_agent" =>
                    json.Deserialize<global::ElevenLabs.TicketEventHumanAgentAuthorResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketEventHumanAgentAuthorResponse"
                        ),
                "requester" =>
                    json.Deserialize<global::ElevenLabs.TicketEventRequesterAuthorResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketEventRequesterAuthorResponse"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new TicketStatusChangedEventResponseAuthor(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketStatusChangedEventResponseAuthor value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "ai_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "human_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "requester" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override TicketStatusChangedEventResponseAuthor ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TicketStatusChangedEventResponseAuthor(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketStatusChangedEventResponseAuthor value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for ai_agent
    /// </summary>
    [Serializable]
    public struct AiAgent
    {
        public AiAgent(global::ElevenLabs.TicketEventAiAgentAuthorResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketEventAiAgentAuthorResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TicketStatusChangedEventResponseAuthor.AiAgent(
            global::ElevenLabs.TicketEventAiAgentAuthorResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for human_agent
    /// </summary>
    [Serializable]
    public struct HumanAgent
    {
        public HumanAgent(global::ElevenLabs.TicketEventHumanAgentAuthorResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketEventHumanAgentAuthorResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TicketStatusChangedEventResponseAuthor.HumanAgent(
            global::ElevenLabs.TicketEventHumanAgentAuthorResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for requester
    /// </summary>
    [Serializable]
    public struct Requester
    {
        public Requester(global::ElevenLabs.TicketEventRequesterAuthorResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketEventRequesterAuthorResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TicketStatusChangedEventResponseAuthor.Requester(
            global::ElevenLabs.TicketEventRequesterAuthorResponse value
        ) => new(value);
    }
}
