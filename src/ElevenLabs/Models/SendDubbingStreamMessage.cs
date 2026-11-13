// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SendDubbingStreamMessage.JsonConverter))]
[Serializable]
public record SendDubbingStreamMessage
{
    internal SendDubbingStreamMessage(string type, object? value)
    {
        MessageType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SendDubbingStreamMessage with <see cref="SendDubbingStreamMessage.InputAudioChunk"/>.
    /// </summary>
    public SendDubbingStreamMessage(SendDubbingStreamMessage.InputAudioChunk value)
    {
        MessageType = "input_audio_chunk";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SendDubbingStreamMessage with <see cref="SendDubbingStreamMessage.EndOfStream"/>.
    /// </summary>
    public SendDubbingStreamMessage(SendDubbingStreamMessage.EndOfStream value)
    {
        MessageType = "end_of_stream";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("message_type")]
    public string MessageType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "input_audio_chunk"
    /// </summary>
    public bool IsInputAudioChunk => MessageType == "input_audio_chunk";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "end_of_stream"
    /// </summary>
    public bool IsEndOfStream => MessageType == "end_of_stream";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingInputAudioChunk"/> if <see cref="MessageType"/> is 'input_audio_chunk', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'input_audio_chunk'.</exception>
    public global::ElevenLabs.DubbingInputAudioChunk AsInputAudioChunk() =>
        IsInputAudioChunk
            ? (global::ElevenLabs.DubbingInputAudioChunk)Value!
            : throw new global::System.Exception(
                "SendDubbingStreamMessage.MessageType is not 'input_audio_chunk'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingEndOfStream"/> if <see cref="MessageType"/> is 'end_of_stream', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'end_of_stream'.</exception>
    public global::ElevenLabs.DubbingEndOfStream AsEndOfStream() =>
        IsEndOfStream
            ? (global::ElevenLabs.DubbingEndOfStream)Value!
            : throw new global::System.Exception(
                "SendDubbingStreamMessage.MessageType is not 'end_of_stream'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.DubbingInputAudioChunk, T> onInputAudioChunk,
        Func<global::ElevenLabs.DubbingEndOfStream, T> onEndOfStream,
        Func<string, object?, T> onUnknown_
    )
    {
        return MessageType switch
        {
            "input_audio_chunk" => onInputAudioChunk(AsInputAudioChunk()),
            "end_of_stream" => onEndOfStream(AsEndOfStream()),
            _ => onUnknown_(MessageType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.DubbingInputAudioChunk> onInputAudioChunk,
        Action<global::ElevenLabs.DubbingEndOfStream> onEndOfStream,
        Action<string, object?> onUnknown_
    )
    {
        switch (MessageType)
        {
            case "input_audio_chunk":
                onInputAudioChunk(AsInputAudioChunk());
                break;
            case "end_of_stream":
                onEndOfStream(AsEndOfStream());
                break;
            default:
                onUnknown_(MessageType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingInputAudioChunk"/> and returns true if successful.
    /// </summary>
    public bool TryAsInputAudioChunk(out global::ElevenLabs.DubbingInputAudioChunk? value)
    {
        if (MessageType == "input_audio_chunk")
        {
            value = (global::ElevenLabs.DubbingInputAudioChunk)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingEndOfStream"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndOfStream(out global::ElevenLabs.DubbingEndOfStream? value)
    {
        if (MessageType == "end_of_stream")
        {
            value = (global::ElevenLabs.DubbingEndOfStream)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SendDubbingStreamMessage(
        SendDubbingStreamMessage.InputAudioChunk value
    ) => new(value);

    public static implicit operator SendDubbingStreamMessage(
        SendDubbingStreamMessage.EndOfStream value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SendDubbingStreamMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SendDubbingStreamMessage).IsAssignableFrom(typeToConvert);

        public override SendDubbingStreamMessage Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("message_type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'message_type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'message_type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'message_type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'message_type' is null");

            var value = discriminator switch
            {
                "input_audio_chunk" => json.Deserialize<global::ElevenLabs.DubbingInputAudioChunk?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingInputAudioChunk"
                    ),
                "end_of_stream" => json.Deserialize<global::ElevenLabs.DubbingEndOfStream?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingEndOfStream"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new SendDubbingStreamMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendDubbingStreamMessage value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.MessageType switch
                {
                    "input_audio_chunk" => JsonSerializer.SerializeToNode(value.Value, options),
                    "end_of_stream" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["message_type"] = value.MessageType;
            json.WriteTo(writer, options);
        }

        public override SendDubbingStreamMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SendDubbingStreamMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendDubbingStreamMessage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.MessageType);
        }
    }

    /// <summary>
    /// Discriminated union type for input_audio_chunk
    /// </summary>
    [Serializable]
    public struct InputAudioChunk
    {
        public InputAudioChunk(global::ElevenLabs.DubbingInputAudioChunk value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingInputAudioChunk Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendDubbingStreamMessage.InputAudioChunk(
            global::ElevenLabs.DubbingInputAudioChunk value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for end_of_stream
    /// </summary>
    [Serializable]
    public struct EndOfStream
    {
        public EndOfStream(global::ElevenLabs.DubbingEndOfStream value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingEndOfStream Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendDubbingStreamMessage.EndOfStream(
            global::ElevenLabs.DubbingEndOfStream value
        ) => new(value);
    }
}
