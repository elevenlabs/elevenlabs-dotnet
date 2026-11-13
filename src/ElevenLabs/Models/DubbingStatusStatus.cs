using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DubbingStatusStatus.DubbingStatusStatusSerializer))]
[Serializable]
public readonly record struct DubbingStatusStatus : IStringEnum
{
    public static readonly DubbingStatusStatus Started = new(Values.Started);

    public static readonly DubbingStatusStatus Stopped = new(Values.Stopped);

    public DubbingStatusStatus(string value)
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
    public static DubbingStatusStatus FromCustom(string value)
    {
        return new DubbingStatusStatus(value);
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

    public static bool operator ==(DubbingStatusStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingStatusStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingStatusStatus value) => value.Value;

    public static explicit operator DubbingStatusStatus(string value) => new(value);

    internal class DubbingStatusStatusSerializer : JsonConverter<DubbingStatusStatus>
    {
        public override DubbingStatusStatus Read(
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
            return new DubbingStatusStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingStatusStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingStatusStatus ReadAsPropertyName(
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
            return new DubbingStatusStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingStatusStatus value,
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
        public const string Started = "started";

        public const string Stopped = "stopped";
    }
}
