// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Event.JsonConverter))]
[Serializable]
public record Event
{
    internal Event(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Event with <see cref="Event.AgentChatResponsePart"/>.
    /// </summary>
    public Event(Event.AgentChatResponsePart value)
    {
        Type = "agent_chat_response_part";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Event with <see cref="Event.AgentReasoningResponsePart"/>.
    /// </summary>
    public Event(Event.AgentReasoningResponsePart value)
    {
        Type = "agent_reasoning_response_part";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Event with <see cref="Event.AgentResponse"/>.
    /// </summary>
    public Event(Event.AgentResponse value)
    {
        Type = "agent_response";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Event with <see cref="Event.AgentToolRequest"/>.
    /// </summary>
    public Event(Event.AgentToolRequest value)
    {
        Type = "agent_tool_request";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Event with <see cref="Event.AgentToolResponse"/>.
    /// </summary>
    public Event(Event.AgentToolResponse value)
    {
        Type = "agent_tool_response";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Event with <see cref="Event.ClientToolCall"/>.
    /// </summary>
    public Event(Event.ClientToolCall value)
    {
        Type = "client_tool_call";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Event with <see cref="Event.StreamEnded"/>.
    /// </summary>
    public Event(Event.StreamEnded value)
    {
        Type = "stream_ended";
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
    /// Returns true if <see cref="Type"/> is "agent_chat_response_part"
    /// </summary>
    public bool IsAgentChatResponsePart => Type == "agent_chat_response_part";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agent_reasoning_response_part"
    /// </summary>
    public bool IsAgentReasoningResponsePart => Type == "agent_reasoning_response_part";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agent_response"
    /// </summary>
    public bool IsAgentResponse => Type == "agent_response";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agent_tool_request"
    /// </summary>
    public bool IsAgentToolRequest => Type == "agent_tool_request";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agent_tool_response"
    /// </summary>
    public bool IsAgentToolResponse => Type == "agent_tool_response";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "client_tool_call"
    /// </summary>
    public bool IsClientToolCall => Type == "client_tool_call";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "stream_ended"
    /// </summary>
    public bool IsStreamEnded => Type == "stream_ended";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentChatResponsePartClientEvent"/> if <see cref="Type"/> is 'agent_chat_response_part', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'agent_chat_response_part'.</exception>
    public global::ElevenLabs.AgentChatResponsePartClientEvent AsAgentChatResponsePart() =>
        IsAgentChatResponsePart
            ? (global::ElevenLabs.AgentChatResponsePartClientEvent)Value!
            : throw new global::System.Exception("Event.Type is not 'agent_chat_response_part'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentReasoningResponsePartClientEvent"/> if <see cref="Type"/> is 'agent_reasoning_response_part', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'agent_reasoning_response_part'.</exception>
    public global::ElevenLabs.AgentReasoningResponsePartClientEvent AsAgentReasoningResponsePart() =>
        IsAgentReasoningResponsePart
            ? (global::ElevenLabs.AgentReasoningResponsePartClientEvent)Value!
            : throw new global::System.Exception(
                "Event.Type is not 'agent_reasoning_response_part'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentResponseClientEvent"/> if <see cref="Type"/> is 'agent_response', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'agent_response'.</exception>
    public global::ElevenLabs.AgentResponseClientEvent AsAgentResponse() =>
        IsAgentResponse
            ? (global::ElevenLabs.AgentResponseClientEvent)Value!
            : throw new global::System.Exception("Event.Type is not 'agent_response'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentToolRequestStreamedEvent"/> if <see cref="Type"/> is 'agent_tool_request', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'agent_tool_request'.</exception>
    public global::ElevenLabs.AgentToolRequestStreamedEvent AsAgentToolRequest() =>
        IsAgentToolRequest
            ? (global::ElevenLabs.AgentToolRequestStreamedEvent)Value!
            : throw new global::System.Exception("Event.Type is not 'agent_tool_request'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentToolResponseStreamedEvent"/> if <see cref="Type"/> is 'agent_tool_response', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'agent_tool_response'.</exception>
    public global::ElevenLabs.AgentToolResponseStreamedEvent AsAgentToolResponse() =>
        IsAgentToolResponse
            ? (global::ElevenLabs.AgentToolResponseStreamedEvent)Value!
            : throw new global::System.Exception("Event.Type is not 'agent_tool_response'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ClientToolCallEvent"/> if <see cref="Type"/> is 'client_tool_call', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'client_tool_call'.</exception>
    public global::ElevenLabs.ClientToolCallEvent AsClientToolCall() =>
        IsClientToolCall
            ? (global::ElevenLabs.ClientToolCallEvent)Value!
            : throw new global::System.Exception("Event.Type is not 'client_tool_call'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.StreamEndedEvent"/> if <see cref="Type"/> is 'stream_ended', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'stream_ended'.</exception>
    public global::ElevenLabs.StreamEndedEvent AsStreamEnded() =>
        IsStreamEnded
            ? (global::ElevenLabs.StreamEndedEvent)Value!
            : throw new global::System.Exception("Event.Type is not 'stream_ended'");

    public T Match<T>(
        Func<global::ElevenLabs.AgentChatResponsePartClientEvent, T> onAgentChatResponsePart,
        Func<
            global::ElevenLabs.AgentReasoningResponsePartClientEvent,
            T
        > onAgentReasoningResponsePart,
        Func<global::ElevenLabs.AgentResponseClientEvent, T> onAgentResponse,
        Func<global::ElevenLabs.AgentToolRequestStreamedEvent, T> onAgentToolRequest,
        Func<global::ElevenLabs.AgentToolResponseStreamedEvent, T> onAgentToolResponse,
        Func<global::ElevenLabs.ClientToolCallEvent, T> onClientToolCall,
        Func<global::ElevenLabs.StreamEndedEvent, T> onStreamEnded,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "agent_chat_response_part" => onAgentChatResponsePart(AsAgentChatResponsePart()),
            "agent_reasoning_response_part" => onAgentReasoningResponsePart(
                AsAgentReasoningResponsePart()
            ),
            "agent_response" => onAgentResponse(AsAgentResponse()),
            "agent_tool_request" => onAgentToolRequest(AsAgentToolRequest()),
            "agent_tool_response" => onAgentToolResponse(AsAgentToolResponse()),
            "client_tool_call" => onClientToolCall(AsClientToolCall()),
            "stream_ended" => onStreamEnded(AsStreamEnded()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.AgentChatResponsePartClientEvent> onAgentChatResponsePart,
        Action<global::ElevenLabs.AgentReasoningResponsePartClientEvent> onAgentReasoningResponsePart,
        Action<global::ElevenLabs.AgentResponseClientEvent> onAgentResponse,
        Action<global::ElevenLabs.AgentToolRequestStreamedEvent> onAgentToolRequest,
        Action<global::ElevenLabs.AgentToolResponseStreamedEvent> onAgentToolResponse,
        Action<global::ElevenLabs.ClientToolCallEvent> onClientToolCall,
        Action<global::ElevenLabs.StreamEndedEvent> onStreamEnded,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "agent_chat_response_part":
                onAgentChatResponsePart(AsAgentChatResponsePart());
                break;
            case "agent_reasoning_response_part":
                onAgentReasoningResponsePart(AsAgentReasoningResponsePart());
                break;
            case "agent_response":
                onAgentResponse(AsAgentResponse());
                break;
            case "agent_tool_request":
                onAgentToolRequest(AsAgentToolRequest());
                break;
            case "agent_tool_response":
                onAgentToolResponse(AsAgentToolResponse());
                break;
            case "client_tool_call":
                onClientToolCall(AsClientToolCall());
                break;
            case "stream_ended":
                onStreamEnded(AsStreamEnded());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentChatResponsePartClientEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsAgentChatResponsePart(
        out global::ElevenLabs.AgentChatResponsePartClientEvent? value
    )
    {
        if (Type == "agent_chat_response_part")
        {
            value = (global::ElevenLabs.AgentChatResponsePartClientEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentReasoningResponsePartClientEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsAgentReasoningResponsePart(
        out global::ElevenLabs.AgentReasoningResponsePartClientEvent? value
    )
    {
        if (Type == "agent_reasoning_response_part")
        {
            value = (global::ElevenLabs.AgentReasoningResponsePartClientEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentResponseClientEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsAgentResponse(out global::ElevenLabs.AgentResponseClientEvent? value)
    {
        if (Type == "agent_response")
        {
            value = (global::ElevenLabs.AgentResponseClientEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentToolRequestStreamedEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsAgentToolRequest(out global::ElevenLabs.AgentToolRequestStreamedEvent? value)
    {
        if (Type == "agent_tool_request")
        {
            value = (global::ElevenLabs.AgentToolRequestStreamedEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentToolResponseStreamedEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsAgentToolResponse(out global::ElevenLabs.AgentToolResponseStreamedEvent? value)
    {
        if (Type == "agent_tool_response")
        {
            value = (global::ElevenLabs.AgentToolResponseStreamedEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ClientToolCallEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsClientToolCall(out global::ElevenLabs.ClientToolCallEvent? value)
    {
        if (Type == "client_tool_call")
        {
            value = (global::ElevenLabs.ClientToolCallEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.StreamEndedEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsStreamEnded(out global::ElevenLabs.StreamEndedEvent? value)
    {
        if (Type == "stream_ended")
        {
            value = (global::ElevenLabs.StreamEndedEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Event(Event.AgentChatResponsePart value) => new(value);

    public static implicit operator Event(Event.AgentReasoningResponsePart value) => new(value);

    public static implicit operator Event(Event.AgentResponse value) => new(value);

    public static implicit operator Event(Event.AgentToolRequest value) => new(value);

    public static implicit operator Event(Event.AgentToolResponse value) => new(value);

    public static implicit operator Event(Event.ClientToolCall value) => new(value);

    public static implicit operator Event(Event.StreamEnded value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Event>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Event).IsAssignableFrom(typeToConvert);

        public override Event Read(
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
                "agent_chat_response_part" =>
                    json.Deserialize<global::ElevenLabs.AgentChatResponsePartClientEvent?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AgentChatResponsePartClientEvent"
                        ),
                "agent_reasoning_response_part" =>
                    json.Deserialize<global::ElevenLabs.AgentReasoningResponsePartClientEvent?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AgentReasoningResponsePartClientEvent"
                        ),
                "agent_response" => json.Deserialize<global::ElevenLabs.AgentResponseClientEvent?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AgentResponseClientEvent"
                    ),
                "agent_tool_request" =>
                    json.Deserialize<global::ElevenLabs.AgentToolRequestStreamedEvent?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AgentToolRequestStreamedEvent"
                        ),
                "agent_tool_response" =>
                    json.Deserialize<global::ElevenLabs.AgentToolResponseStreamedEvent?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AgentToolResponseStreamedEvent"
                        ),
                "client_tool_call" => json.Deserialize<global::ElevenLabs.ClientToolCallEvent?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ClientToolCallEvent"
                    ),
                "stream_ended" => json.Deserialize<global::ElevenLabs.StreamEndedEvent?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.StreamEndedEvent"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Event(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Event value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "agent_chat_response_part" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "agent_reasoning_response_part" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "agent_response" => JsonSerializer.SerializeToNode(value.Value, options),
                    "agent_tool_request" => JsonSerializer.SerializeToNode(value.Value, options),
                    "agent_tool_response" => JsonSerializer.SerializeToNode(value.Value, options),
                    "client_tool_call" => JsonSerializer.SerializeToNode(value.Value, options),
                    "stream_ended" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override Event ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Event(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Event value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for agent_chat_response_part
    /// </summary>
    [Serializable]
    public struct AgentChatResponsePart
    {
        public AgentChatResponsePart(global::ElevenLabs.AgentChatResponsePartClientEvent value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentChatResponsePartClientEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Event.AgentChatResponsePart(
            global::ElevenLabs.AgentChatResponsePartClientEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for agent_reasoning_response_part
    /// </summary>
    [Serializable]
    public struct AgentReasoningResponsePart
    {
        public AgentReasoningResponsePart(
            global::ElevenLabs.AgentReasoningResponsePartClientEvent value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentReasoningResponsePartClientEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Event.AgentReasoningResponsePart(
            global::ElevenLabs.AgentReasoningResponsePartClientEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for agent_response
    /// </summary>
    [Serializable]
    public struct AgentResponse
    {
        public AgentResponse(global::ElevenLabs.AgentResponseClientEvent value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentResponseClientEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Event.AgentResponse(
            global::ElevenLabs.AgentResponseClientEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for agent_tool_request
    /// </summary>
    [Serializable]
    public struct AgentToolRequest
    {
        public AgentToolRequest(global::ElevenLabs.AgentToolRequestStreamedEvent value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentToolRequestStreamedEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Event.AgentToolRequest(
            global::ElevenLabs.AgentToolRequestStreamedEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for agent_tool_response
    /// </summary>
    [Serializable]
    public struct AgentToolResponse
    {
        public AgentToolResponse(global::ElevenLabs.AgentToolResponseStreamedEvent value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentToolResponseStreamedEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Event.AgentToolResponse(
            global::ElevenLabs.AgentToolResponseStreamedEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for client_tool_call
    /// </summary>
    [Serializable]
    public struct ClientToolCall
    {
        public ClientToolCall(global::ElevenLabs.ClientToolCallEvent value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ClientToolCallEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Event.ClientToolCall(
            global::ElevenLabs.ClientToolCallEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for stream_ended
    /// </summary>
    [Serializable]
    public struct StreamEnded
    {
        public StreamEnded(global::ElevenLabs.StreamEndedEvent value)
        {
            Value = value;
        }

        internal global::ElevenLabs.StreamEndedEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Event.StreamEnded(
            global::ElevenLabs.StreamEndedEvent value
        ) => new(value);
    }
}
