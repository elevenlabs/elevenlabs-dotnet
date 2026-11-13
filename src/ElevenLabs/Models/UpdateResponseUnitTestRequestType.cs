using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateResponseUnitTestRequestType.UpdateResponseUnitTestRequestTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateResponseUnitTestRequestType : IStringEnum
{
    public static readonly UpdateResponseUnitTestRequestType Llm = new(Values.Llm);

    public UpdateResponseUnitTestRequestType(string value)
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
    public static UpdateResponseUnitTestRequestType FromCustom(string value)
    {
        return new UpdateResponseUnitTestRequestType(value);
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

    public static bool operator ==(UpdateResponseUnitTestRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateResponseUnitTestRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateResponseUnitTestRequestType value) => value.Value;

    public static explicit operator UpdateResponseUnitTestRequestType(string value) => new(value);

    internal class UpdateResponseUnitTestRequestTypeSerializer
        : JsonConverter<UpdateResponseUnitTestRequestType>
    {
        public override UpdateResponseUnitTestRequestType Read(
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
            return new UpdateResponseUnitTestRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateResponseUnitTestRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateResponseUnitTestRequestType ReadAsPropertyName(
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
            return new UpdateResponseUnitTestRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateResponseUnitTestRequestType value,
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
        public const string Llm = "llm";
    }
}
