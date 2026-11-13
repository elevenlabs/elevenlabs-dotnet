using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(WebhookToolConfigInputType.WebhookToolConfigInputTypeSerializer))]
[Serializable]
public readonly record struct WebhookToolConfigInputType : IStringEnum
{
    public static readonly WebhookToolConfigInputType Webhook = new(Values.Webhook);

    public WebhookToolConfigInputType(string value)
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
    public static WebhookToolConfigInputType FromCustom(string value)
    {
        return new WebhookToolConfigInputType(value);
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

    public static bool operator ==(WebhookToolConfigInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookToolConfigInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookToolConfigInputType value) => value.Value;

    public static explicit operator WebhookToolConfigInputType(string value) => new(value);

    internal class WebhookToolConfigInputTypeSerializer : JsonConverter<WebhookToolConfigInputType>
    {
        public override WebhookToolConfigInputType Read(
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
            return new WebhookToolConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookToolConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookToolConfigInputType ReadAsPropertyName(
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
            return new WebhookToolConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookToolConfigInputType value,
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
        public const string Webhook = "webhook";
    }
}
