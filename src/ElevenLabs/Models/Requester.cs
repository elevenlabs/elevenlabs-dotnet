// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.CustomerSupport;

[JsonConverter(typeof(Requester.JsonConverter))]
[Serializable]
public record Requester
{
    internal Requester(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Requester with <see cref="Requester.Email"/>.
    /// </summary>
    public Requester(Requester.Email value)
    {
        Type = "email";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Requester with <see cref="Requester.Slack"/>.
    /// </summary>
    public Requester(Requester.Slack value)
    {
        Type = "slack";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Requester with <see cref="Requester.UserId"/>.
    /// </summary>
    public Requester(Requester.UserId value)
    {
        Type = "user_id";
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
    /// Returns true if <see cref="Type"/> is "email"
    /// </summary>
    public bool IsEmail => Type == "email";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "slack"
    /// </summary>
    public bool IsSlack => Type == "slack";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "user_id"
    /// </summary>
    public bool IsUserId => Type == "user_id";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketRequesterByEmailRequest"/> if <see cref="Type"/> is 'email', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'email'.</exception>
    public global::ElevenLabs.TicketRequesterByEmailRequest AsEmail() =>
        IsEmail
            ? (global::ElevenLabs.TicketRequesterByEmailRequest)Value!
            : throw new global::System.Exception("Requester.Type is not 'email'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketRequesterBySlackRequest"/> if <see cref="Type"/> is 'slack', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'slack'.</exception>
    public global::ElevenLabs.TicketRequesterBySlackRequest AsSlack() =>
        IsSlack
            ? (global::ElevenLabs.TicketRequesterBySlackRequest)Value!
            : throw new global::System.Exception("Requester.Type is not 'slack'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketRequesterByUserIdRequest"/> if <see cref="Type"/> is 'user_id', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user_id'.</exception>
    public global::ElevenLabs.TicketRequesterByUserIdRequest AsUserId() =>
        IsUserId
            ? (global::ElevenLabs.TicketRequesterByUserIdRequest)Value!
            : throw new global::System.Exception("Requester.Type is not 'user_id'");

    public T Match<T>(
        Func<global::ElevenLabs.TicketRequesterByEmailRequest, T> onEmail,
        Func<global::ElevenLabs.TicketRequesterBySlackRequest, T> onSlack,
        Func<global::ElevenLabs.TicketRequesterByUserIdRequest, T> onUserId,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "email" => onEmail(AsEmail()),
            "slack" => onSlack(AsSlack()),
            "user_id" => onUserId(AsUserId()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TicketRequesterByEmailRequest> onEmail,
        Action<global::ElevenLabs.TicketRequesterBySlackRequest> onSlack,
        Action<global::ElevenLabs.TicketRequesterByUserIdRequest> onUserId,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "email":
                onEmail(AsEmail());
                break;
            case "slack":
                onSlack(AsSlack());
                break;
            case "user_id":
                onUserId(AsUserId());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketRequesterByEmailRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsEmail(out global::ElevenLabs.TicketRequesterByEmailRequest? value)
    {
        if (Type == "email")
        {
            value = (global::ElevenLabs.TicketRequesterByEmailRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketRequesterBySlackRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsSlack(out global::ElevenLabs.TicketRequesterBySlackRequest? value)
    {
        if (Type == "slack")
        {
            value = (global::ElevenLabs.TicketRequesterBySlackRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketRequesterByUserIdRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsUserId(out global::ElevenLabs.TicketRequesterByUserIdRequest? value)
    {
        if (Type == "user_id")
        {
            value = (global::ElevenLabs.TicketRequesterByUserIdRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Requester(Requester.Email value) => new(value);

    public static implicit operator Requester(Requester.Slack value) => new(value);

    public static implicit operator Requester(Requester.UserId value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Requester>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Requester).IsAssignableFrom(typeToConvert);

        public override Requester Read(
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
                "email" => json.Deserialize<global::ElevenLabs.TicketRequesterByEmailRequest?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TicketRequesterByEmailRequest"
                    ),
                "slack" => json.Deserialize<global::ElevenLabs.TicketRequesterBySlackRequest?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TicketRequesterBySlackRequest"
                    ),
                "user_id" => json.Deserialize<global::ElevenLabs.TicketRequesterByUserIdRequest?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TicketRequesterByUserIdRequest"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Requester(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Requester value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "email" => JsonSerializer.SerializeToNode(value.Value, options),
                    "slack" => JsonSerializer.SerializeToNode(value.Value, options),
                    "user_id" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override Requester ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Requester(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Requester value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for email
    /// </summary>
    [Serializable]
    public struct Email
    {
        public Email(global::ElevenLabs.TicketRequesterByEmailRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketRequesterByEmailRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Requester.Email(
            global::ElevenLabs.TicketRequesterByEmailRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for slack
    /// </summary>
    [Serializable]
    public struct Slack
    {
        public Slack(global::ElevenLabs.TicketRequesterBySlackRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketRequesterBySlackRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Requester.Slack(
            global::ElevenLabs.TicketRequesterBySlackRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user_id
    /// </summary>
    [Serializable]
    public struct UserId
    {
        public UserId(global::ElevenLabs.TicketRequesterByUserIdRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketRequesterByUserIdRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Requester.UserId(
            global::ElevenLabs.TicketRequesterByUserIdRequest value
        ) => new(value);
    }
}
