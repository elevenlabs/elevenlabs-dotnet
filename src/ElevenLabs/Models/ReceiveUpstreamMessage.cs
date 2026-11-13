// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveUpstreamMessage.JsonConverter))]
[Serializable]
public record ReceiveUpstreamMessage
{
    internal ReceiveUpstreamMessage(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ReceiveUpstreamMessage with <see cref="ReceiveUpstreamMessage.Init"/>.
    /// </summary>
    public ReceiveUpstreamMessage(ReceiveUpstreamMessage.Init value)
    {
        Type = "init";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveUpstreamMessage with <see cref="ReceiveUpstreamMessage.UserTranscript"/>.
    /// </summary>
    public ReceiveUpstreamMessage(ReceiveUpstreamMessage.UserTranscript value)
    {
        Type = "user_transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveUpstreamMessage with <see cref="ReceiveUpstreamMessage.Ping"/>.
    /// </summary>
    public ReceiveUpstreamMessage(ReceiveUpstreamMessage.Ping value)
    {
        Type = "ping";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveUpstreamMessage with <see cref="ReceiveUpstreamMessage.Close"/>.
    /// </summary>
    public ReceiveUpstreamMessage(ReceiveUpstreamMessage.Close value)
    {
        Type = "close";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveUpstreamMessage with <see cref="ReceiveUpstreamMessage.Error"/>.
    /// </summary>
    public ReceiveUpstreamMessage(ReceiveUpstreamMessage.Error value)
    {
        Type = "error";
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
    /// Returns true if <see cref="Type"/> is "init"
    /// </summary>
    public bool IsInit => Type == "init";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "user_transcript"
    /// </summary>
    public bool IsUserTranscript => Type == "user_transcript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ping"
    /// </summary>
    public bool IsPing => Type == "ping";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "close"
    /// </summary>
    public bool IsClose => Type == "close";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "error"
    /// </summary>
    public bool IsError => Type == "error";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Init"/> if <see cref="Type"/> is 'init', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'init'.</exception>
    public global::ElevenLabs.Init AsInit() =>
        IsInit
            ? (global::ElevenLabs.Init)Value!
            : throw new global::System.Exception("ReceiveUpstreamMessage.Type is not 'init'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UserTranscript"/> if <see cref="Type"/> is 'user_transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user_transcript'.</exception>
    public global::ElevenLabs.UserTranscript AsUserTranscript() =>
        IsUserTranscript
            ? (global::ElevenLabs.UserTranscript)Value!
            : throw new global::System.Exception(
                "ReceiveUpstreamMessage.Type is not 'user_transcript'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Ping"/> if <see cref="Type"/> is 'ping', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ping'.</exception>
    public global::ElevenLabs.Ping AsPing() =>
        IsPing
            ? (global::ElevenLabs.Ping)Value!
            : throw new global::System.Exception("ReceiveUpstreamMessage.Type is not 'ping'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Close"/> if <see cref="Type"/> is 'close', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'close'.</exception>
    public global::ElevenLabs.Close AsClose() =>
        IsClose
            ? (global::ElevenLabs.Close)Value!
            : throw new global::System.Exception("ReceiveUpstreamMessage.Type is not 'close'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SpeechEngineError"/> if <see cref="Type"/> is 'error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'error'.</exception>
    public global::ElevenLabs.SpeechEngineError AsError() =>
        IsError
            ? (global::ElevenLabs.SpeechEngineError)Value!
            : throw new global::System.Exception("ReceiveUpstreamMessage.Type is not 'error'");

    public T Match<T>(
        Func<global::ElevenLabs.Init, T> onInit,
        Func<global::ElevenLabs.UserTranscript, T> onUserTranscript,
        Func<global::ElevenLabs.Ping, T> onPing,
        Func<global::ElevenLabs.Close, T> onClose,
        Func<global::ElevenLabs.SpeechEngineError, T> onError,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "init" => onInit(AsInit()),
            "user_transcript" => onUserTranscript(AsUserTranscript()),
            "ping" => onPing(AsPing()),
            "close" => onClose(AsClose()),
            "error" => onError(AsError()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.Init> onInit,
        Action<global::ElevenLabs.UserTranscript> onUserTranscript,
        Action<global::ElevenLabs.Ping> onPing,
        Action<global::ElevenLabs.Close> onClose,
        Action<global::ElevenLabs.SpeechEngineError> onError,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "init":
                onInit(AsInit());
                break;
            case "user_transcript":
                onUserTranscript(AsUserTranscript());
                break;
            case "ping":
                onPing(AsPing());
                break;
            case "close":
                onClose(AsClose());
                break;
            case "error":
                onError(AsError());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Init"/> and returns true if successful.
    /// </summary>
    public bool TryAsInit(out global::ElevenLabs.Init? value)
    {
        if (Type == "init")
        {
            value = (global::ElevenLabs.Init)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UserTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsUserTranscript(out global::ElevenLabs.UserTranscript? value)
    {
        if (Type == "user_transcript")
        {
            value = (global::ElevenLabs.UserTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Ping"/> and returns true if successful.
    /// </summary>
    public bool TryAsPing(out global::ElevenLabs.Ping? value)
    {
        if (Type == "ping")
        {
            value = (global::ElevenLabs.Ping)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Close"/> and returns true if successful.
    /// </summary>
    public bool TryAsClose(out global::ElevenLabs.Close? value)
    {
        if (Type == "close")
        {
            value = (global::ElevenLabs.Close)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SpeechEngineError"/> and returns true if successful.
    /// </summary>
    public bool TryAsError(out global::ElevenLabs.SpeechEngineError? value)
    {
        if (Type == "error")
        {
            value = (global::ElevenLabs.SpeechEngineError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveUpstreamMessage(ReceiveUpstreamMessage.Init value) =>
        new(value);

    public static implicit operator ReceiveUpstreamMessage(
        ReceiveUpstreamMessage.UserTranscript value
    ) => new(value);

    public static implicit operator ReceiveUpstreamMessage(ReceiveUpstreamMessage.Ping value) =>
        new(value);

    public static implicit operator ReceiveUpstreamMessage(ReceiveUpstreamMessage.Close value) =>
        new(value);

    public static implicit operator ReceiveUpstreamMessage(ReceiveUpstreamMessage.Error value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveUpstreamMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ReceiveUpstreamMessage).IsAssignableFrom(typeToConvert);

        public override ReceiveUpstreamMessage Read(
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
                "init" => json.Deserialize<global::ElevenLabs.Init?>(options)
                    ?? throw new JsonException("Failed to deserialize global::ElevenLabs.Init"),
                "user_transcript" => json.Deserialize<global::ElevenLabs.UserTranscript?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UserTranscript"
                    ),
                "ping" => json.Deserialize<global::ElevenLabs.Ping?>(options)
                    ?? throw new JsonException("Failed to deserialize global::ElevenLabs.Ping"),
                "close" => json.Deserialize<global::ElevenLabs.Close?>(options)
                    ?? throw new JsonException("Failed to deserialize global::ElevenLabs.Close"),
                "error" => json.Deserialize<global::ElevenLabs.SpeechEngineError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SpeechEngineError"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ReceiveUpstreamMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveUpstreamMessage value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "init" => JsonSerializer.SerializeToNode(value.Value, options),
                    "user_transcript" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ping" => JsonSerializer.SerializeToNode(value.Value, options),
                    "close" => JsonSerializer.SerializeToNode(value.Value, options),
                    "error" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ReceiveUpstreamMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ReceiveUpstreamMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveUpstreamMessage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for init
    /// </summary>
    [Serializable]
    public struct Init
    {
        public Init(global::ElevenLabs.Init value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Init Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveUpstreamMessage.Init(
            global::ElevenLabs.Init value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user_transcript
    /// </summary>
    [Serializable]
    public struct UserTranscript
    {
        public UserTranscript(global::ElevenLabs.UserTranscript value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UserTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveUpstreamMessage.UserTranscript(
            global::ElevenLabs.UserTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ping
    /// </summary>
    [Serializable]
    public struct Ping
    {
        public Ping(global::ElevenLabs.Ping value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Ping Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveUpstreamMessage.Ping(
            global::ElevenLabs.Ping value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for close
    /// </summary>
    [Serializable]
    public struct Close
    {
        public Close(global::ElevenLabs.Close value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Close Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveUpstreamMessage.Close(
            global::ElevenLabs.Close value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for error
    /// </summary>
    [Serializable]
    public struct Error
    {
        public Error(global::ElevenLabs.SpeechEngineError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SpeechEngineError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveUpstreamMessage.Error(
            global::ElevenLabs.SpeechEngineError value
        ) => new(value);
    }
}
