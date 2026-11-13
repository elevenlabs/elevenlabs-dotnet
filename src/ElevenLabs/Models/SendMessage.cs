// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SendMessage.JsonConverter))]
[Serializable]
public class SendMessage
{
    private SendMessage(string type, object? value)
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
    /// Create a SendMessage from a InitializeConnection value.
    /// </summary>
    public static SendMessage FromInitializeConnection(
        global::ElevenLabs.InitializeConnection value
    ) => new("initializeConnection", value);

    /// <summary>
    /// Create a SendMessage from a SendText value.
    /// </summary>
    public static SendMessage FromSendText(global::ElevenLabs.SendText value) =>
        new("sendText", value);

    /// <summary>
    /// Create a SendMessage from a CloseConnection value.
    /// </summary>
    public static SendMessage FromCloseConnection(global::ElevenLabs.CloseConnection value) =>
        new("closeConnection", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "initializeConnection".
    /// </summary>
    public bool IsInitializeConnection() => Type == "initializeConnection";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sendText".
    /// </summary>
    public bool IsSendText() => Type == "sendText";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "closeConnection".
    /// </summary>
    public bool IsCloseConnection() => Type == "closeConnection";

    /// <summary>
    /// Returns the value as a InitializeConnection if <see cref="Type"/> is "initializeConnection", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'initializeConnection'.</exception>
    public global::ElevenLabs.InitializeConnection AsInitializeConnection() =>
        IsInitializeConnection()
            ? (global::ElevenLabs.InitializeConnection)Value!
            : throw new ElevenLabsClientException("Union type is not 'initializeConnection'");

    /// <summary>
    /// Returns the value as a SendText if <see cref="Type"/> is "sendText", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'sendText'.</exception>
    public global::ElevenLabs.SendText AsSendText() =>
        IsSendText()
            ? (global::ElevenLabs.SendText)Value!
            : throw new ElevenLabsClientException("Union type is not 'sendText'");

    /// <summary>
    /// Returns the value as a CloseConnection if <see cref="Type"/> is "closeConnection", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'closeConnection'.</exception>
    public global::ElevenLabs.CloseConnection AsCloseConnection() =>
        IsCloseConnection()
            ? (global::ElevenLabs.CloseConnection)Value!
            : throw new ElevenLabsClientException("Union type is not 'closeConnection'");

    /// <summary>
    /// Attempts to cast the value to a InitializeConnection and returns true if successful.
    /// </summary>
    public bool TryGetInitializeConnection(out global::ElevenLabs.InitializeConnection? value)
    {
        if (Type == "initializeConnection")
        {
            value = (global::ElevenLabs.InitializeConnection)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a SendText and returns true if successful.
    /// </summary>
    public bool TryGetSendText(out global::ElevenLabs.SendText? value)
    {
        if (Type == "sendText")
        {
            value = (global::ElevenLabs.SendText)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a CloseConnection and returns true if successful.
    /// </summary>
    public bool TryGetCloseConnection(out global::ElevenLabs.CloseConnection? value)
    {
        if (Type == "closeConnection")
        {
            value = (global::ElevenLabs.CloseConnection)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.InitializeConnection, T> onInitializeConnection,
        global::System.Func<global::ElevenLabs.SendText, T> onSendText,
        global::System.Func<global::ElevenLabs.CloseConnection, T> onCloseConnection
    )
    {
        return Type switch
        {
            "initializeConnection" => onInitializeConnection(AsInitializeConnection()),
            "sendText" => onSendText(AsSendText()),
            "closeConnection" => onCloseConnection(AsCloseConnection()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.InitializeConnection> onInitializeConnection,
        global::System.Action<global::ElevenLabs.SendText> onSendText,
        global::System.Action<global::ElevenLabs.CloseConnection> onCloseConnection
    )
    {
        switch (Type)
        {
            case "initializeConnection":
                onInitializeConnection(AsInitializeConnection());
                break;
            case "sendText":
                onSendText(AsSendText());
                break;
            case "closeConnection":
                onCloseConnection(AsCloseConnection());
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
        if (obj is not SendMessage other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SendMessage(global::ElevenLabs.InitializeConnection value) =>
        new("initializeConnection", value);

    public static implicit operator SendMessage(global::ElevenLabs.SendText value) =>
        new("sendText", value);

    public static implicit operator SendMessage(global::ElevenLabs.CloseConnection value) =>
        new("closeConnection", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SendMessage>
    {
        public override SendMessage? Read(
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

                if (HasLiteral(document, "text", " "))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.InitializeConnection),
                            options
                        );
                        if (value != null)
                        {
                            return new SendMessage("initializeConnection", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "text", ""))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.CloseConnection),
                            options
                        );
                        if (value != null)
                        {
                            return new SendMessage("closeConnection", value);
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
                        "Cannot deserialize JSON object into SendMessage: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("initializeConnection", typeof(global::ElevenLabs.InitializeConnection)),
                    ("sendText", typeof(global::ElevenLabs.SendText)),
                    ("closeConnection", typeof(global::ElevenLabs.CloseConnection)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new SendMessage(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into SendMessage"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendMessage value,
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

        public override SendMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            SendMessage result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendMessage value,
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
    }
}
