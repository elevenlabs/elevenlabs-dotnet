using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Carrier-level AMD verdict reported by Twilio via `AnsweredBy`.</summary>
[JsonConverter(typeof(TwilioAnsweredBy.TwilioAnsweredBySerializer))]
[Serializable]
public readonly record struct TwilioAnsweredBy : IStringEnum
{
    public static readonly TwilioAnsweredBy Human = new(Values.Human);

    public static readonly TwilioAnsweredBy Fax = new(Values.Fax);

    public static readonly TwilioAnsweredBy Unknown = new(Values.Unknown);

    public static readonly TwilioAnsweredBy MachineStart = new(Values.MachineStart);

    public static readonly TwilioAnsweredBy MachineEndBeep = new(Values.MachineEndBeep);

    public static readonly TwilioAnsweredBy MachineEndSilence = new(Values.MachineEndSilence);

    public static readonly TwilioAnsweredBy MachineEndOther = new(Values.MachineEndOther);

    public TwilioAnsweredBy(string value)
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
    public static TwilioAnsweredBy FromCustom(string value)
    {
        return new TwilioAnsweredBy(value);
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

    public static bool operator ==(TwilioAnsweredBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TwilioAnsweredBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TwilioAnsweredBy value) => value.Value;

    public static explicit operator TwilioAnsweredBy(string value) => new(value);

    internal class TwilioAnsweredBySerializer : JsonConverter<TwilioAnsweredBy>
    {
        public override TwilioAnsweredBy Read(
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
            return new TwilioAnsweredBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioAnsweredBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioAnsweredBy ReadAsPropertyName(
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
            return new TwilioAnsweredBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioAnsweredBy value,
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
        public const string Human = "human";

        public const string Fax = "fax";

        public const string Unknown = "unknown";

        public const string MachineStart = "machine_start";

        public const string MachineEndBeep = "machine_end_beep";

        public const string MachineEndSilence = "machine_end_silence";

        public const string MachineEndOther = "machine_end_other";
    }
}
