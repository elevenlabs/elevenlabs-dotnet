using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WebhookHttpMethod.WebhookHttpMethodSerializer))]
[Serializable]
public readonly record struct WebhookHttpMethod : IStringEnum
{
    public static readonly WebhookHttpMethod Get = new(Values.Get);

    public static readonly WebhookHttpMethod Post = new(Values.Post);

    public static readonly WebhookHttpMethod Put = new(Values.Put);

    public static readonly WebhookHttpMethod Patch = new(Values.Patch);

    public static readonly WebhookHttpMethod Delete = new(Values.Delete);

    public WebhookHttpMethod(string value)
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
    public static WebhookHttpMethod FromCustom(string value)
    {
        return new WebhookHttpMethod(value);
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

    public static bool operator ==(WebhookHttpMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookHttpMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookHttpMethod value) => value.Value;

    public static explicit operator WebhookHttpMethod(string value) => new(value);

    internal class WebhookHttpMethodSerializer : JsonConverter<WebhookHttpMethod>
    {
        public override WebhookHttpMethod Read(
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
            return new WebhookHttpMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookHttpMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookHttpMethod ReadAsPropertyName(
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
            return new WebhookHttpMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookHttpMethod value,
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
        public const string Get = "GET";

        public const string Post = "POST";

        public const string Put = "PUT";

        public const string Patch = "PATCH";

        public const string Delete = "DELETE";
    }
}
