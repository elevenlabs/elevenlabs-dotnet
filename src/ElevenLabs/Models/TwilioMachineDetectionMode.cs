using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Which Twilio answering-machine-detection (AMD) mode to request for a call.
///
/// `enable` returns a verdict as soon as Twilio can tell a human from a machine.
/// `detect_message_end` additionally waits for the greeting to finish, which is what
/// distinguishes the `machine_end_*` verdicts, at the cost of a later result.
/// </summary>
[JsonConverter(typeof(TwilioMachineDetectionMode.TwilioMachineDetectionModeSerializer))]
[Serializable]
public readonly record struct TwilioMachineDetectionMode : IStringEnum
{
    public static readonly TwilioMachineDetectionMode Enable = new(Values.Enable);

    public static readonly TwilioMachineDetectionMode DetectMessageEnd = new(
        Values.DetectMessageEnd
    );

    public TwilioMachineDetectionMode(string value)
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
    public static TwilioMachineDetectionMode FromCustom(string value)
    {
        return new TwilioMachineDetectionMode(value);
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

    public static bool operator ==(TwilioMachineDetectionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TwilioMachineDetectionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TwilioMachineDetectionMode value) => value.Value;

    public static explicit operator TwilioMachineDetectionMode(string value) => new(value);

    internal class TwilioMachineDetectionModeSerializer : JsonConverter<TwilioMachineDetectionMode>
    {
        public override TwilioMachineDetectionMode Read(
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
            return new TwilioMachineDetectionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioMachineDetectionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioMachineDetectionMode ReadAsPropertyName(
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
            return new TwilioMachineDetectionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioMachineDetectionMode value,
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
        public const string Enable = "enable";

        public const string DetectMessageEnd = "detect_message_end";
    }
}
