using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DubbingErrorPayloadMessageType.DubbingErrorPayloadMessageTypeSerializer))]
[Serializable]
public readonly record struct DubbingErrorPayloadMessageType : IStringEnum
{
    public static readonly DubbingErrorPayloadMessageType Error = new(Values.Error);

    public DubbingErrorPayloadMessageType(string value)
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
    public static DubbingErrorPayloadMessageType FromCustom(string value)
    {
        return new DubbingErrorPayloadMessageType(value);
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

    public static bool operator ==(DubbingErrorPayloadMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingErrorPayloadMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingErrorPayloadMessageType value) => value.Value;

    public static explicit operator DubbingErrorPayloadMessageType(string value) => new(value);

    internal class DubbingErrorPayloadMessageTypeSerializer
        : JsonConverter<DubbingErrorPayloadMessageType>
    {
        public override DubbingErrorPayloadMessageType Read(
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
            return new DubbingErrorPayloadMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingErrorPayloadMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingErrorPayloadMessageType ReadAsPropertyName(
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
            return new DubbingErrorPayloadMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingErrorPayloadMessageType value,
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
        public const string Error = "error";
    }
}
