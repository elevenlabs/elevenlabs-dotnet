using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateToolCallUnitTestRequestType.UpdateToolCallUnitTestRequestTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateToolCallUnitTestRequestType : IStringEnum
{
    public static readonly UpdateToolCallUnitTestRequestType Tool = new(Values.Tool);

    public UpdateToolCallUnitTestRequestType(string value)
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
    public static UpdateToolCallUnitTestRequestType FromCustom(string value)
    {
        return new UpdateToolCallUnitTestRequestType(value);
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

    public static bool operator ==(UpdateToolCallUnitTestRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateToolCallUnitTestRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateToolCallUnitTestRequestType value) => value.Value;

    public static explicit operator UpdateToolCallUnitTestRequestType(string value) => new(value);

    internal class UpdateToolCallUnitTestRequestTypeSerializer
        : JsonConverter<UpdateToolCallUnitTestRequestType>
    {
        public override UpdateToolCallUnitTestRequestType Read(
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
            return new UpdateToolCallUnitTestRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateToolCallUnitTestRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateToolCallUnitTestRequestType ReadAsPropertyName(
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
            return new UpdateToolCallUnitTestRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateToolCallUnitTestRequestType value,
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
