using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Send the result to the listed flows webhooks.</summary>
[JsonConverter(typeof(WebhookTargetIdsType.WebhookTargetIdsTypeSerializer))]
[Serializable]
public readonly record struct WebhookTargetIdsType : IStringEnum
{
    public static readonly WebhookTargetIdsType Ids = new(Values.Ids);

    public WebhookTargetIdsType(string value)
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
    public static WebhookTargetIdsType FromCustom(string value)
    {
        return new WebhookTargetIdsType(value);
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

    public static bool operator ==(WebhookTargetIdsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookTargetIdsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookTargetIdsType value) => value.Value;

    public static explicit operator WebhookTargetIdsType(string value) => new(value);

    internal class WebhookTargetIdsTypeSerializer : JsonConverter<WebhookTargetIdsType>
    {
        public override WebhookTargetIdsType Read(
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
            return new WebhookTargetIdsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookTargetIdsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookTargetIdsType ReadAsPropertyName(
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
            return new WebhookTargetIdsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookTargetIdsType value,
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
        public const string Ids = "ids";
    }
}
