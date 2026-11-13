using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Dubbing;

/// <summary>Format to return transcript in. For subtitles use either 'srt' or 'webvtt', and for a full transcript use 'json'. The 'json' format is not yet supported for Dubbing Studio.</summary>
[JsonConverter(typeof(GetTranscriptsRequestFormatType.GetTranscriptsRequestFormatTypeSerializer))]
[Serializable]
public readonly record struct GetTranscriptsRequestFormatType : IStringEnum
{
    public static readonly GetTranscriptsRequestFormatType Srt = new(Values.Srt);

    public static readonly GetTranscriptsRequestFormatType Webvtt = new(Values.Webvtt);

    public static readonly GetTranscriptsRequestFormatType Json = new(Values.Json);

    public GetTranscriptsRequestFormatType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static GetTranscriptsRequestFormatType FromCustom(string value)
    {
        return new GetTranscriptsRequestFormatType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(GetTranscriptsRequestFormatType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetTranscriptsRequestFormatType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetTranscriptsRequestFormatType value) => value.Value;

    public static explicit operator GetTranscriptsRequestFormatType(string value) => new(value);

    internal class GetTranscriptsRequestFormatTypeSerializer
        : JsonConverter<GetTranscriptsRequestFormatType>
    {
        public override GetTranscriptsRequestFormatType Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new GetTranscriptsRequestFormatType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetTranscriptsRequestFormatType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetTranscriptsRequestFormatType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new GetTranscriptsRequestFormatType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetTranscriptsRequestFormatType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Srt = "srt";

        public const string Webvtt = "webvtt";

        public const string Json = "json";
    }
}
