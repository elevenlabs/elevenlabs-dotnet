using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

/// <summary>Response format. Defaults to 'json'. Set to 'opentelemetry' for an OTLP-compatible trace payload using the same structure as the post-call webhook.</summary>
[JsonConverter(typeof(GetConversationsRequestFormat.GetConversationsRequestFormatSerializer))]
[Serializable]
public readonly record struct GetConversationsRequestFormat : IStringEnum
{
    public static readonly GetConversationsRequestFormat Json = new(Values.Json);

    public static readonly GetConversationsRequestFormat Opentelemetry = new(Values.Opentelemetry);

    public GetConversationsRequestFormat(string value)
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
    public static GetConversationsRequestFormat FromCustom(string value)
    {
        return new GetConversationsRequestFormat(value);
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

    public static bool operator ==(GetConversationsRequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetConversationsRequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetConversationsRequestFormat value) => value.Value;

    public static explicit operator GetConversationsRequestFormat(string value) => new(value);

    internal class GetConversationsRequestFormatSerializer
        : JsonConverter<GetConversationsRequestFormat>
    {
        public override GetConversationsRequestFormat Read(
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
            return new GetConversationsRequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetConversationsRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetConversationsRequestFormat ReadAsPropertyName(
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
            return new GetConversationsRequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetConversationsRequestFormat value,
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
