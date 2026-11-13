// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OrderItemRequestInput.JsonConverter))]
[Serializable]
public record OrderItemRequestInput
{
    internal OrderItemRequestInput(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of OrderItemRequestInput with <see cref="OrderItemRequestInput.Dub"/>.
    /// </summary>
    public OrderItemRequestInput(OrderItemRequestInput.Dub value)
    {
        Kind = "dub";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of OrderItemRequestInput with <see cref="OrderItemRequestInput.Subtitles"/>.
    /// </summary>
    public OrderItemRequestInput(OrderItemRequestInput.Subtitles value)
    {
        Kind = "subtitles";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of OrderItemRequestInput with <see cref="OrderItemRequestInput.Transcription"/>.
    /// </summary>
    public OrderItemRequestInput(OrderItemRequestInput.Transcription value)
    {
        Kind = "transcription";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("kind")]
    public string Kind { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "dub"
    /// </summary>
    public bool IsDub => Kind == "dub";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "subtitles"
    /// </summary>
    public bool IsSubtitles => Kind == "subtitles";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "transcription"
    /// </summary>
    public bool IsTranscription => Kind == "transcription";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubOrderItemRequest"/> if <see cref="Kind"/> is 'dub', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'dub'.</exception>
    public global::ElevenLabs.DubOrderItemRequest AsDub() =>
        IsDub
            ? (global::ElevenLabs.DubOrderItemRequest)Value!
            : throw new global::System.Exception("OrderItemRequestInput.Kind is not 'dub'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitleOrderItemRequest"/> if <see cref="Kind"/> is 'subtitles', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'subtitles'.</exception>
    public global::ElevenLabs.SubtitleOrderItemRequest AsSubtitles() =>
        IsSubtitles
            ? (global::ElevenLabs.SubtitleOrderItemRequest)Value!
            : throw new global::System.Exception("OrderItemRequestInput.Kind is not 'subtitles'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranscriptionOrderItemRequest"/> if <see cref="Kind"/> is 'transcription', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'transcription'.</exception>
    public global::ElevenLabs.TranscriptionOrderItemRequest AsTranscription() =>
        IsTranscription
            ? (global::ElevenLabs.TranscriptionOrderItemRequest)Value!
            : throw new global::System.Exception(
                "OrderItemRequestInput.Kind is not 'transcription'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.DubOrderItemRequest, T> onDub,
        Func<global::ElevenLabs.SubtitleOrderItemRequest, T> onSubtitles,
        Func<global::ElevenLabs.TranscriptionOrderItemRequest, T> onTranscription,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "dub" => onDub(AsDub()),
            "subtitles" => onSubtitles(AsSubtitles()),
            "transcription" => onTranscription(AsTranscription()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.DubOrderItemRequest> onDub,
        Action<global::ElevenLabs.SubtitleOrderItemRequest> onSubtitles,
        Action<global::ElevenLabs.TranscriptionOrderItemRequest> onTranscription,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "dub":
                onDub(AsDub());
                break;
            case "subtitles":
                onSubtitles(AsSubtitles());
                break;
            case "transcription":
                onTranscription(AsTranscription());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubOrderItemRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsDub(out global::ElevenLabs.DubOrderItemRequest? value)
    {
        if (Kind == "dub")
        {
            value = (global::ElevenLabs.DubOrderItemRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitleOrderItemRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubtitles(out global::ElevenLabs.SubtitleOrderItemRequest? value)
    {
        if (Kind == "subtitles")
        {
            value = (global::ElevenLabs.SubtitleOrderItemRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranscriptionOrderItemRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranscription(out global::ElevenLabs.TranscriptionOrderItemRequest? value)
    {
        if (Kind == "transcription")
        {
            value = (global::ElevenLabs.TranscriptionOrderItemRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator OrderItemRequestInput(OrderItemRequestInput.Dub value) =>
        new(value);

    public static implicit operator OrderItemRequestInput(OrderItemRequestInput.Subtitles value) =>
        new(value);

    public static implicit operator OrderItemRequestInput(
        OrderItemRequestInput.Transcription value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<OrderItemRequestInput>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(OrderItemRequestInput).IsAssignableFrom(typeToConvert);

        public override OrderItemRequestInput Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("kind", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'kind'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'kind' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'kind' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'kind' is null");

            var value = discriminator switch
            {
                "dub" => json.Deserialize<global::ElevenLabs.DubOrderItemRequest?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubOrderItemRequest"
                    ),
                "subtitles" => json.Deserialize<global::ElevenLabs.SubtitleOrderItemRequest?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubtitleOrderItemRequest"
                    ),
                "transcription" =>
                    json.Deserialize<global::ElevenLabs.TranscriptionOrderItemRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranscriptionOrderItemRequest"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new OrderItemRequestInput(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderItemRequestInput value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "dub" => JsonSerializer.SerializeToNode(value.Value, options),
                    "subtitles" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transcription" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override OrderItemRequestInput ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new OrderItemRequestInput(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderItemRequestInput value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for dub
    /// </summary>
    [Serializable]
    public struct Dub
    {
        public Dub(global::ElevenLabs.DubOrderItemRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubOrderItemRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator OrderItemRequestInput.Dub(
            global::ElevenLabs.DubOrderItemRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for subtitles
    /// </summary>
    [Serializable]
    public struct Subtitles
    {
        public Subtitles(global::ElevenLabs.SubtitleOrderItemRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitleOrderItemRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator OrderItemRequestInput.Subtitles(
            global::ElevenLabs.SubtitleOrderItemRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transcription
    /// </summary>
    [Serializable]
    public struct Transcription
    {
        public Transcription(global::ElevenLabs.TranscriptionOrderItemRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranscriptionOrderItemRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator OrderItemRequestInput.Transcription(
            global::ElevenLabs.TranscriptionOrderItemRequest value
        ) => new(value);
    }
}
