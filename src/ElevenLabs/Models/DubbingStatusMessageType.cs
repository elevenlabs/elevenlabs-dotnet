using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DubbingStatusMessageType.DubbingStatusMessageTypeSerializer))]
[Serializable]
public readonly record struct DubbingStatusMessageType : IStringEnum
{
    public static readonly DubbingStatusMessageType Status = new(Values.Status);

    public DubbingStatusMessageType(string value)
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
    public static DubbingStatusMessageType FromCustom(string value)
    {
        return new DubbingStatusMessageType(value);
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

    public static bool operator ==(DubbingStatusMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingStatusMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingStatusMessageType value) => value.Value;

    public static explicit operator DubbingStatusMessageType(string value) => new(value);

    internal class DubbingStatusMessageTypeSerializer : JsonConverter<DubbingStatusMessageType>
    {
        public override DubbingStatusMessageType Read(
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
            return new DubbingStatusMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingStatusMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingStatusMessageType ReadAsPropertyName(
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
            return new DubbingStatusMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingStatusMessageType value,
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
        public const string Status = "status";
    }
}
