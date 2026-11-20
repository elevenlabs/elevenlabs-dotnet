using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Which kind of regulated number a request or an issued number is for.</summary>
[JsonConverter(typeof(ApplicationNumberType.ApplicationNumberTypeSerializer))]
[Serializable]
public readonly record struct ApplicationNumberType : IStringEnum
{
    public static readonly ApplicationNumberType Local = new(Values.Local);

    public static readonly ApplicationNumberType Mobile = new(Values.Mobile);

    public ApplicationNumberType(string value)
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
    public static ApplicationNumberType FromCustom(string value)
    {
        return new ApplicationNumberType(value);
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

    public static bool operator ==(ApplicationNumberType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ApplicationNumberType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ApplicationNumberType value) => value.Value;

    public static explicit operator ApplicationNumberType(string value) => new(value);

    internal class ApplicationNumberTypeSerializer : JsonConverter<ApplicationNumberType>
    {
        public override ApplicationNumberType Read(
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
            return new ApplicationNumberType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApplicationNumberType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApplicationNumberType ReadAsPropertyName(
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
            return new ApplicationNumberType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApplicationNumberType value,
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
        public const string Local = "local";

        public const string Mobile = "mobile";
    }
}
