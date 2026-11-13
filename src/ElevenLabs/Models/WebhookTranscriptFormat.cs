using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WebhookTranscriptFormat.WebhookTranscriptFormatSerializer))]
[Serializable]
public readonly record struct WebhookTranscriptFormat : IStringEnum
{
    public static readonly WebhookTranscriptFormat Json = new(Values.Json);

    public static readonly WebhookTranscriptFormat Opentelemetry = new(Values.Opentelemetry);

    public WebhookTranscriptFormat(string value)
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
    public static WebhookTranscriptFormat FromCustom(string value)
    {
        return new WebhookTranscriptFormat(value);
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

    public static bool operator ==(WebhookTranscriptFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookTranscriptFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookTranscriptFormat value) => value.Value;

    public static explicit operator WebhookTranscriptFormat(string value) => new(value);

    internal class WebhookTranscriptFormatSerializer : JsonConverter<WebhookTranscriptFormat>
    {
        public override WebhookTranscriptFormat Read(
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
            return new WebhookTranscriptFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookTranscriptFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookTranscriptFormat ReadAsPropertyName(
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
            return new WebhookTranscriptFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookTranscriptFormat value,
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
        public const string Json = "json";

        public const string Opentelemetry = "opentelemetry";
    }
}
