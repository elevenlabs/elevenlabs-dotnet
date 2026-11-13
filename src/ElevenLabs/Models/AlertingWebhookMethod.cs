using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AlertingWebhookMethod.AlertingWebhookMethodSerializer))]
[Serializable]
public readonly record struct AlertingWebhookMethod : IStringEnum
{
    public static readonly AlertingWebhookMethod Post = new(Values.Post);

    public static readonly AlertingWebhookMethod Put = new(Values.Put);

    public AlertingWebhookMethod(string value)
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
    public static AlertingWebhookMethod FromCustom(string value)
    {
        return new AlertingWebhookMethod(value);
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

    public static bool operator ==(AlertingWebhookMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AlertingWebhookMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AlertingWebhookMethod value) => value.Value;

    public static explicit operator AlertingWebhookMethod(string value) => new(value);

    internal class AlertingWebhookMethodSerializer : JsonConverter<AlertingWebhookMethod>
    {
        public override AlertingWebhookMethod Read(
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
            return new AlertingWebhookMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingWebhookMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AlertingWebhookMethod ReadAsPropertyName(
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
            return new AlertingWebhookMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingWebhookMethod value,
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
        public const string Post = "POST";

        public const string Put = "PUT";
    }
}
