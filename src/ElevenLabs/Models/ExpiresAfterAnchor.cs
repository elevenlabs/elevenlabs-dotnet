using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExpiresAfterAnchor.ExpiresAfterAnchorSerializer))]
[Serializable]
public readonly record struct ExpiresAfterAnchor : IStringEnum
{
    public static readonly ExpiresAfterAnchor CreatedAt = new(Values.CreatedAt);

    public ExpiresAfterAnchor(string value)
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
    public static ExpiresAfterAnchor FromCustom(string value)
    {
        return new ExpiresAfterAnchor(value);
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

    public static bool operator ==(ExpiresAfterAnchor value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExpiresAfterAnchor value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExpiresAfterAnchor value) => value.Value;

    public static explicit operator ExpiresAfterAnchor(string value) => new(value);

    internal class ExpiresAfterAnchorSerializer : JsonConverter<ExpiresAfterAnchor>
    {
        public override ExpiresAfterAnchor Read(
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
            return new ExpiresAfterAnchor(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExpiresAfterAnchor value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExpiresAfterAnchor ReadAsPropertyName(
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
            return new ExpiresAfterAnchor(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExpiresAfterAnchor value,
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
        public const string CreatedAt = "created_at";
    }
}
