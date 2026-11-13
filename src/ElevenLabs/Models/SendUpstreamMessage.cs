// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SendUpstreamMessage.JsonConverter))]
[Serializable]
public record SendUpstreamMessage
{
    internal SendUpstreamMessage(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SendUpstreamMessage with <see cref="SendUpstreamMessage.AgentResponse"/>.
    /// </summary>
    public SendUpstreamMessage(SendUpstreamMessage.AgentResponse value)
    {
        Type = "agent_response";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SendUpstreamMessage with <see cref="SendUpstreamMessage.Pong"/>.
    /// </summary>
    public SendUpstreamMessage(SendUpstreamMessage.Pong value)
    {
        Type = "pong";
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
    /// Returns true if <see cref="Type"/> is "agent_response"
    /// </summary>
    public bool IsAgentResponse => Type == "agent_response";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "pong"
    /// </summary>
    public bool IsPong => Type == "pong";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentResponse"/> if <see cref="Type"/> is 'agent_response', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'agent_response'.</exception>
    public global::ElevenLabs.AgentResponse AsAgentResponse() =>
        IsAgentResponse
            ? (global::ElevenLabs.AgentResponse)Value!
            : throw new global::System.Exception(
                "SendUpstreamMessage.Type is not 'agent_response'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Pong"/> if <see cref="Type"/> is 'pong', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'pong'.</exception>
    public global::ElevenLabs.Pong AsPong() =>
        IsPong
            ? (global::ElevenLabs.Pong)Value!
            : throw new global::System.Exception("SendUpstreamMessage.Type is not 'pong'");

    public T Match<T>(
        Func<global::ElevenLabs.AgentResponse, T> onAgentResponse,
        Func<global::ElevenLabs.Pong, T> onPong,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "agent_response" => onAgentResponse(AsAgentResponse()),
            "pong" => onPong(AsPong()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.AgentResponse> onAgentResponse,
        Action<global::ElevenLabs.Pong> onPong,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "agent_response":
                onAgentResponse(AsAgentResponse());
                break;
            case "pong":
                onPong(AsPong());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsAgentResponse(out global::ElevenLabs.AgentResponse? value)
    {
        if (Type == "agent_response")
        {
            value = (global::ElevenLabs.AgentResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Pong"/> and returns true if successful.
    /// </summary>
    public bool TryAsPong(out global::ElevenLabs.Pong? value)
    {
        if (Type == "pong")
        {
            value = (global::ElevenLabs.Pong)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SendUpstreamMessage(SendUpstreamMessage.AgentResponse value) =>
        new(value);

    public static implicit operator SendUpstreamMessage(SendUpstreamMessage.Pong value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SendUpstreamMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SendUpstreamMessage).IsAssignableFrom(typeToConvert);

        public override SendUpstreamMessage Read(
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
                "agent_response" => json.Deserialize<global::ElevenLabs.AgentResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AgentResponse"
                    ),
                "pong" => json.Deserialize<global::ElevenLabs.Pong?>(options)
                    ?? throw new JsonException("Failed to deserialize global::ElevenLabs.Pong"),
                _ => json.Deserialize<object?>(options),
            };
            return new SendUpstreamMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendUpstreamMessage value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "agent_response" => JsonSerializer.SerializeToNode(value.Value, options),
                    "pong" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override SendUpstreamMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SendUpstreamMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendUpstreamMessage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for agent_response
    /// </summary>
    [Serializable]
    public struct AgentResponse
    {
        public AgentResponse(global::ElevenLabs.AgentResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendUpstreamMessage.AgentResponse(
            global::ElevenLabs.AgentResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for pong
    /// </summary>
    [Serializable]
    public struct Pong
    {
        public Pong(global::ElevenLabs.Pong value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Pong Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendUpstreamMessage.Pong(global::ElevenLabs.Pong value) =>
            new(value);
    }
}
