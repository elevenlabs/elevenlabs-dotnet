using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EndCallToolResultModelResultType.EndCallToolResultModelResultTypeSerializer))]
[Serializable]
public readonly record struct EndCallToolResultModelResultType : IStringEnum
{
    public static readonly EndCallToolResultModelResultType EndCallSuccess = new(
        Values.EndCallSuccess
    );

    public EndCallToolResultModelResultType(string value)
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
    public static EndCallToolResultModelResultType FromCustom(string value)
    {
        return new EndCallToolResultModelResultType(value);
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

    public static bool operator ==(EndCallToolResultModelResultType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EndCallToolResultModelResultType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EndCallToolResultModelResultType value) => value.Value;

    public static explicit operator EndCallToolResultModelResultType(string value) => new(value);

    internal class EndCallToolResultModelResultTypeSerializer
        : JsonConverter<EndCallToolResultModelResultType>
    {
        public override EndCallToolResultModelResultType Read(
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
            return new EndCallToolResultModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EndCallToolResultModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EndCallToolResultModelResultType ReadAsPropertyName(
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
            return new EndCallToolResultModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EndCallToolResultModelResultType value,
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
        public const string EndCallSuccess = "end_call_success";
    }
}
