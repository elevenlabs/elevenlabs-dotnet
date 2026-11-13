using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AttentionStatus.AttentionStatusSerializer))]
[Serializable]
public readonly record struct AttentionStatus : IStringEnum
{
    public static readonly AttentionStatus Open = new(Values.Open);

    public static readonly AttentionStatus Resolved = new(Values.Resolved);

    public static readonly AttentionStatus Retrying = new(Values.Retrying);

    public AttentionStatus(string value)
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
    public static AttentionStatus FromCustom(string value)
    {
        return new AttentionStatus(value);
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

    public static bool operator ==(AttentionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AttentionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AttentionStatus value) => value.Value;

    public static explicit operator AttentionStatus(string value) => new(value);

    internal class AttentionStatusSerializer : JsonConverter<AttentionStatus>
    {
        public override AttentionStatus Read(
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
            return new AttentionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AttentionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AttentionStatus ReadAsPropertyName(
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
            return new AttentionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AttentionStatus value,
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
        public const string Open = "open";

        public const string Resolved = "resolved";

        public const string Retrying = "retrying";
    }
}
