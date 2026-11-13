// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SpeechToTextChunkResponseModelEditedTranscript.JsonConverter))]
[Serializable]
public record SpeechToTextChunkResponseModelEditedTranscript
{
    internal SpeechToTextChunkResponseModelEditedTranscript(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SpeechToTextChunkResponseModelEditedTranscript with <see cref="SpeechToTextChunkResponseModelEditedTranscript.Error"/>.
    /// </summary>
    public SpeechToTextChunkResponseModelEditedTranscript(
        SpeechToTextChunkResponseModelEditedTranscript.Error value
    )
    {
        Kind = "error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SpeechToTextChunkResponseModelEditedTranscript with <see cref="SpeechToTextChunkResponseModelEditedTranscript.Transcript"/>.
    /// </summary>
    public SpeechToTextChunkResponseModelEditedTranscript(
        SpeechToTextChunkResponseModelEditedTranscript.Transcript value
    )
    {
        Kind = "transcript";
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
    /// Returns true if <see cref="Kind"/> is "error"
    /// </summary>
    public bool IsError => Kind == "error";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "transcript"
    /// </summary>
    public bool IsTranscript => Kind == "transcript";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranscriptEditError"/> if <see cref="Kind"/> is 'error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'error'.</exception>
    public global::ElevenLabs.TranscriptEditError AsError() =>
        IsError
            ? (global::ElevenLabs.TranscriptEditError)Value!
            : throw new global::System.Exception(
                "SpeechToTextChunkResponseModelEditedTranscript.Kind is not 'error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.EditedTranscriptResponse"/> if <see cref="Kind"/> is 'transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'transcript'.</exception>
    public global::ElevenLabs.EditedTranscriptResponse AsTranscript() =>
        IsTranscript
            ? (global::ElevenLabs.EditedTranscriptResponse)Value!
            : throw new global::System.Exception(
                "SpeechToTextChunkResponseModelEditedTranscript.Kind is not 'transcript'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TranscriptEditError, T> onError,
        Func<global::ElevenLabs.EditedTranscriptResponse, T> onTranscript,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "error" => onError(AsError()),
            "transcript" => onTranscript(AsTranscript()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TranscriptEditError> onError,
        Action<global::ElevenLabs.EditedTranscriptResponse> onTranscript,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "error":
                onError(AsError());
                break;
            case "transcript":
                onTranscript(AsTranscript());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranscriptEditError"/> and returns true if successful.
    /// </summary>
    public bool TryAsError(out global::ElevenLabs.TranscriptEditError? value)
    {
        if (Kind == "error")
        {
            value = (global::ElevenLabs.TranscriptEditError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.EditedTranscriptResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranscript(out global::ElevenLabs.EditedTranscriptResponse? value)
    {
        if (Kind == "transcript")
        {
            value = (global::ElevenLabs.EditedTranscriptResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SpeechToTextChunkResponseModelEditedTranscript(
        SpeechToTextChunkResponseModelEditedTranscript.Error value
    ) => new(value);

    public static implicit operator SpeechToTextChunkResponseModelEditedTranscript(
        SpeechToTextChunkResponseModelEditedTranscript.Transcript value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<SpeechToTextChunkResponseModelEditedTranscript>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SpeechToTextChunkResponseModelEditedTranscript).IsAssignableFrom(typeToConvert);

        public override SpeechToTextChunkResponseModelEditedTranscript Read(
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
                "error" => json.Deserialize<global::ElevenLabs.TranscriptEditError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranscriptEditError"
                    ),
                "transcript" => json.Deserialize<global::ElevenLabs.EditedTranscriptResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.EditedTranscriptResponse"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new SpeechToTextChunkResponseModelEditedTranscript(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeechToTextChunkResponseModelEditedTranscript value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transcript" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override SpeechToTextChunkResponseModelEditedTranscript ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SpeechToTextChunkResponseModelEditedTranscript(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeechToTextChunkResponseModelEditedTranscript value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for error
    /// </summary>
    [Serializable]
    public struct Error
    {
        public Error(global::ElevenLabs.TranscriptEditError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranscriptEditError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SpeechToTextChunkResponseModelEditedTranscript.Error(
            global::ElevenLabs.TranscriptEditError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transcript
    /// </summary>
    [Serializable]
    public struct Transcript
    {
        public Transcript(global::ElevenLabs.EditedTranscriptResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.EditedTranscriptResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SpeechToTextChunkResponseModelEditedTranscript.Transcript(
            global::ElevenLabs.EditedTranscriptResponse value
        ) => new(value);
    }
}
