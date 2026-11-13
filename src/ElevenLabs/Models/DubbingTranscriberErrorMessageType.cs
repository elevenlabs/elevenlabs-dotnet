using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DubbingTranscriberErrorMessageType.DubbingTranscriberErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct DubbingTranscriberErrorMessageType : IStringEnum
{
    public static readonly DubbingTranscriberErrorMessageType TranscriberError = new(
        Values.TranscriberError
    );

    public DubbingTranscriberErrorMessageType(string value)
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
    public static DubbingTranscriberErrorMessageType FromCustom(string value)
    {
        return new DubbingTranscriberErrorMessageType(value);
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

    public static bool operator ==(DubbingTranscriberErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingTranscriberErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingTranscriberErrorMessageType value) => value.Value;

    public static explicit operator DubbingTranscriberErrorMessageType(string value) => new(value);

    internal class DubbingTranscriberErrorMessageTypeSerializer
        : JsonConverter<DubbingTranscriberErrorMessageType>
    {
        public override DubbingTranscriberErrorMessageType Read(
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
            return new DubbingTranscriberErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingTranscriberErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingTranscriberErrorMessageType ReadAsPropertyName(
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
            return new DubbingTranscriberErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingTranscriberErrorMessageType value,
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
        public const string TranscriberError = "transcriber_error";
    }
}
