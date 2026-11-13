using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OpenOutcomeStatus.OpenOutcomeStatusSerializer))]
[Serializable]
public readonly record struct OpenOutcomeStatus : IStringEnum
{
    public static readonly OpenOutcomeStatus Open = new(Values.Open);

    public OpenOutcomeStatus(string value)
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
    public static OpenOutcomeStatus FromCustom(string value)
    {
        return new OpenOutcomeStatus(value);
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

    public static bool operator ==(OpenOutcomeStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OpenOutcomeStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OpenOutcomeStatus value) => value.Value;

    public static explicit operator OpenOutcomeStatus(string value) => new(value);

    internal class OpenOutcomeStatusSerializer : JsonConverter<OpenOutcomeStatus>
    {
        public override OpenOutcomeStatus Read(
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
            return new OpenOutcomeStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OpenOutcomeStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OpenOutcomeStatus ReadAsPropertyName(
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
            return new OpenOutcomeStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OpenOutcomeStatus value,
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
    }
}
