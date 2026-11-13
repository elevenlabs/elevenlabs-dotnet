// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SendTranslateStreamMessage.JsonConverter))]
[Serializable]
public record SendTranslateStreamMessage
{
    internal SendTranslateStreamMessage(string type, object? value)
    {
        MessageType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SendTranslateStreamMessage with <see cref="SendTranslateStreamMessage.InputAudioChunk"/>.
    /// </summary>
    public SendTranslateStreamMessage(SendTranslateStreamMessage.InputAudioChunk value)
    {
        MessageType = "input_audio_chunk";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SendTranslateStreamMessage with <see cref="SendTranslateStreamMessage.EndOfStream"/>.
    /// </summary>
    public SendTranslateStreamMessage(SendTranslateStreamMessage.EndOfStream value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateInputAudioChunk"/> if <see cref="MessageType"/> is 'input_audio_chunk', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'input_audio_chunk'.</exception>
    public global::ElevenLabs.TranslateInputAudioChunk AsInputAudioChunk() =>
        IsInputAudioChunk
            ? (global::ElevenLabs.TranslateInputAudioChunk)Value!
            : throw new global::System.Exception(
                "SendTranslateStreamMessage.MessageType is not 'input_audio_chunk'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateEndOfStream"/> if <see cref="MessageType"/> is 'end_of_stream', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'end_of_stream'.</exception>
    public global::ElevenLabs.TranslateEndOfStream AsEndOfStream() =>
        IsEndOfStream
            ? (global::ElevenLabs.TranslateEndOfStream)Value!
            : throw new global::System.Exception(
                "SendTranslateStreamMessage.MessageType is not 'end_of_stream'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TranslateInputAudioChunk, T> onInputAudioChunk,
        Func<global::ElevenLabs.TranslateEndOfStream, T> onEndOfStream,
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
        Action<global::ElevenLabs.TranslateInputAudioChunk> onInputAudioChunk,
        Action<global::ElevenLabs.TranslateEndOfStream> onEndOfStream,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateInputAudioChunk"/> and returns true if successful.
    /// </summary>
    public bool TryAsInputAudioChunk(out global::ElevenLabs.TranslateInputAudioChunk? value)
    {
        if (MessageType == "input_audio_chunk")
        {
            value = (global::ElevenLabs.TranslateInputAudioChunk)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateEndOfStream"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndOfStream(out global::ElevenLabs.TranslateEndOfStream? value)
    {
        if (MessageType == "end_of_stream")
        {
            value = (global::ElevenLabs.TranslateEndOfStream)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SendTranslateStreamMessage(
        SendTranslateStreamMessage.InputAudioChunk value
    ) => new(value);

    public static implicit operator SendTranslateStreamMessage(
        SendTranslateStreamMessage.EndOfStream value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SendTranslateStreamMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SendTranslateStreamMessage).IsAssignableFrom(typeToConvert);

        public override SendTranslateStreamMessage Read(
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
                "input_audio_chunk" =>
                    json.Deserialize<global::ElevenLabs.TranslateInputAudioChunk?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateInputAudioChunk"
                        ),
                "end_of_stream" => json.Deserialize<global::ElevenLabs.TranslateEndOfStream?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateEndOfStream"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new SendTranslateStreamMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendTranslateStreamMessage value,
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

        public override SendTranslateStreamMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SendTranslateStreamMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendTranslateStreamMessage value,
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
        public InputAudioChunk(global::ElevenLabs.TranslateInputAudioChunk value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateInputAudioChunk Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendTranslateStreamMessage.InputAudioChunk(
            global::ElevenLabs.TranslateInputAudioChunk value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for end_of_stream
    /// </summary>
    [Serializable]
    public struct EndOfStream
    {
        public EndOfStream(global::ElevenLabs.TranslateEndOfStream value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateEndOfStream Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendTranslateStreamMessage.EndOfStream(
            global::ElevenLabs.TranslateEndOfStream value
        ) => new(value);
    }
}
