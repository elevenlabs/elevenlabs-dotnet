// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GetTicketResponseAssignee.JsonConverter))]
[Serializable]
public record GetTicketResponseAssignee
{
    internal GetTicketResponseAssignee(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseAssignee with <see cref="GetTicketResponseAssignee.AiAgent"/>.
    /// </summary>
    public GetTicketResponseAssignee(GetTicketResponseAssignee.AiAgent value)
    {
        Type = "ai_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseAssignee with <see cref="GetTicketResponseAssignee.HumanAgent"/>.
    /// </summary>
    public GetTicketResponseAssignee(GetTicketResponseAssignee.HumanAgent value)
    {
        Type = "human_agent";
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
    /// Returns the value as a <see cref="global::ElevenLabs.TicketAiAgentAssigneeResponse"/> if <see cref="Type"/> is 'ai_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ai_agent'.</exception>
    public global::ElevenLabs.TicketAiAgentAssigneeResponse AsAiAgent() =>
        IsAiAgent
            ? (global::ElevenLabs.TicketAiAgentAssigneeResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseAssignee.Type is not 'ai_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketHumanAgentAssigneeResponse"/> if <see cref="Type"/> is 'human_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'human_agent'.</exception>
    public global::ElevenLabs.TicketHumanAgentAssigneeResponse AsHumanAgent() =>
        IsHumanAgent
            ? (global::ElevenLabs.TicketHumanAgentAssigneeResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseAssignee.Type is not 'human_agent'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TicketAiAgentAssigneeResponse, T> onAiAgent,
        Func<global::ElevenLabs.TicketHumanAgentAssigneeResponse, T> onHumanAgent,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "ai_agent" => onAiAgent(AsAiAgent()),
            "human_agent" => onHumanAgent(AsHumanAgent()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TicketAiAgentAssigneeResponse> onAiAgent,
        Action<global::ElevenLabs.TicketHumanAgentAssigneeResponse> onHumanAgent,
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
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketAiAgentAssigneeResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsAiAgent(out global::ElevenLabs.TicketAiAgentAssigneeResponse? value)
    {
        if (Type == "ai_agent")
        {
            value = (global::ElevenLabs.TicketAiAgentAssigneeResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketHumanAgentAssigneeResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsHumanAgent(out global::ElevenLabs.TicketHumanAgentAssigneeResponse? value)
    {
        if (Type == "human_agent")
        {
            value = (global::ElevenLabs.TicketHumanAgentAssigneeResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator GetTicketResponseAssignee(
        GetTicketResponseAssignee.AiAgent value
    ) => new(value);

    public static implicit operator GetTicketResponseAssignee(
        GetTicketResponseAssignee.HumanAgent value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GetTicketResponseAssignee>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(GetTicketResponseAssignee).IsAssignableFrom(typeToConvert);

        public override GetTicketResponseAssignee Read(
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
                "ai_agent" => json.Deserialize<global::ElevenLabs.TicketAiAgentAssigneeResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TicketAiAgentAssigneeResponse"
                    ),
                "human_agent" =>
                    json.Deserialize<global::ElevenLabs.TicketHumanAgentAssigneeResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketHumanAgentAssigneeResponse"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new GetTicketResponseAssignee(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetTicketResponseAssignee value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "ai_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "human_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override GetTicketResponseAssignee ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new GetTicketResponseAssignee(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetTicketResponseAssignee value,
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
        public AiAgent(global::ElevenLabs.TicketAiAgentAssigneeResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketAiAgentAssigneeResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseAssignee.AiAgent(
            global::ElevenLabs.TicketAiAgentAssigneeResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for human_agent
    /// </summary>
    [Serializable]
    public struct HumanAgent
    {
        public HumanAgent(global::ElevenLabs.TicketHumanAgentAssigneeResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketHumanAgentAssigneeResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseAssignee.HumanAgent(
            global::ElevenLabs.TicketHumanAgentAssigneeResponse value
        ) => new(value);
    }
}
