// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.CustomerSupport;

[JsonConverter(typeof(CreateTicketRequestAuthor.JsonConverter))]
[Serializable]
public record CreateTicketRequestAuthor
{
    internal CreateTicketRequestAuthor(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateTicketRequestAuthor with <see cref="CreateTicketRequestAuthor.HumanAgent"/>.
    /// </summary>
    public CreateTicketRequestAuthor(CreateTicketRequestAuthor.HumanAgent value)
    {
        Type = "human_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreateTicketRequestAuthor with <see cref="CreateTicketRequestAuthor.Requester"/>.
    /// </summary>
    public CreateTicketRequestAuthor(CreateTicketRequestAuthor.Requester value)
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
    /// Returns true if <see cref="Type"/> is "human_agent"
    /// </summary>
    public bool IsHumanAgent => Type == "human_agent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "requester"
    /// </summary>
    public bool IsRequester => Type == "requester";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketHumanAgentAuthorRequest"/> if <see cref="Type"/> is 'human_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'human_agent'.</exception>
    public global::ElevenLabs.TicketHumanAgentAuthorRequest AsHumanAgent() =>
        IsHumanAgent
            ? (global::ElevenLabs.TicketHumanAgentAuthorRequest)Value!
            : throw new global::System.Exception(
                "CreateTicketRequestAuthor.Type is not 'human_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketRequesterAuthorRequest"/> if <see cref="Type"/> is 'requester', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'requester'.</exception>
    public global::ElevenLabs.TicketRequesterAuthorRequest AsRequester() =>
        IsRequester
            ? (global::ElevenLabs.TicketRequesterAuthorRequest)Value!
            : throw new global::System.Exception(
                "CreateTicketRequestAuthor.Type is not 'requester'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TicketHumanAgentAuthorRequest, T> onHumanAgent,
        Func<global::ElevenLabs.TicketRequesterAuthorRequest, T> onRequester,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "human_agent" => onHumanAgent(AsHumanAgent()),
            "requester" => onRequester(AsRequester()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TicketHumanAgentAuthorRequest> onHumanAgent,
        Action<global::ElevenLabs.TicketRequesterAuthorRequest> onRequester,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketHumanAgentAuthorRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsHumanAgent(out global::ElevenLabs.TicketHumanAgentAuthorRequest? value)
    {
        if (Type == "human_agent")
        {
            value = (global::ElevenLabs.TicketHumanAgentAuthorRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketRequesterAuthorRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsRequester(out global::ElevenLabs.TicketRequesterAuthorRequest? value)
    {
        if (Type == "requester")
        {
            value = (global::ElevenLabs.TicketRequesterAuthorRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateTicketRequestAuthor(
        CreateTicketRequestAuthor.HumanAgent value
    ) => new(value);

    public static implicit operator CreateTicketRequestAuthor(
        CreateTicketRequestAuthor.Requester value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateTicketRequestAuthor>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateTicketRequestAuthor).IsAssignableFrom(typeToConvert);

        public override CreateTicketRequestAuthor Read(
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
                "human_agent" =>
                    json.Deserialize<global::ElevenLabs.TicketHumanAgentAuthorRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketHumanAgentAuthorRequest"
                        ),
                "requester" => json.Deserialize<global::ElevenLabs.TicketRequesterAuthorRequest?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TicketRequesterAuthorRequest"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateTicketRequestAuthor(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTicketRequestAuthor value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "human_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "requester" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override CreateTicketRequestAuthor ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateTicketRequestAuthor(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTicketRequestAuthor value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for human_agent
    /// </summary>
    [Serializable]
    public struct HumanAgent
    {
        public HumanAgent(global::ElevenLabs.TicketHumanAgentAuthorRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketHumanAgentAuthorRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateTicketRequestAuthor.HumanAgent(
            global::ElevenLabs.TicketHumanAgentAuthorRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for requester
    /// </summary>
    [Serializable]
    public struct Requester
    {
        public Requester(global::ElevenLabs.TicketRequesterAuthorRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketRequesterAuthorRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateTicketRequestAuthor.Requester(
            global::ElevenLabs.TicketRequesterAuthorRequest value
        ) => new(value);
    }
}
