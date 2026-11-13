using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(HidingReason.HidingReasonSerializer))]
[Serializable]
public readonly record struct HidingReason : IStringEnum
{
    public static readonly HidingReason SmbAssistant = new(Values.SmbAssistant);

    public HidingReason(string value)
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
    public static HidingReason FromCustom(string value)
    {
        return new HidingReason(value);
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

    public static bool operator ==(HidingReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(HidingReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(HidingReason value) => value.Value;

    public static explicit operator HidingReason(string value) => new(value);

    internal class HidingReasonSerializer : JsonConverter<HidingReason>
    {
        public override HidingReason Read(
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
            return new HidingReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            HidingReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override HidingReason ReadAsPropertyName(
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
            return new HidingReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            HidingReason value,
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
        public const string SmbAssistant = "smb_assistant";
    }
}
