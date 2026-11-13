using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CreateToolCallUnitTestRequestType.CreateToolCallUnitTestRequestTypeSerializer)
)]
[Serializable]
public readonly record struct CreateToolCallUnitTestRequestType : IStringEnum
{
    public static readonly CreateToolCallUnitTestRequestType Tool = new(Values.Tool);

    public CreateToolCallUnitTestRequestType(string value)
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
    public static CreateToolCallUnitTestRequestType FromCustom(string value)
    {
        return new CreateToolCallUnitTestRequestType(value);
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

    public static bool operator ==(CreateToolCallUnitTestRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateToolCallUnitTestRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateToolCallUnitTestRequestType value) => value.Value;

    public static explicit operator CreateToolCallUnitTestRequestType(string value) => new(value);

    internal class CreateToolCallUnitTestRequestTypeSerializer
        : JsonConverter<CreateToolCallUnitTestRequestType>
    {
        public override CreateToolCallUnitTestRequestType Read(
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
            return new CreateToolCallUnitTestRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateToolCallUnitTestRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateToolCallUnitTestRequestType ReadAsPropertyName(
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
            return new CreateToolCallUnitTestRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateToolCallUnitTestRequestType value,
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
        public const string Tool = "tool";
    }
}
