using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The status of the voice sharing.</summary>
[JsonConverter(typeof(VoiceSharingState.VoiceSharingStateSerializer))]
[Serializable]
public readonly record struct VoiceSharingState : IStringEnum
{
    public static readonly VoiceSharingState Enabled = new(Values.Enabled);

    public static readonly VoiceSharingState Disabled = new(Values.Disabled);

    public static readonly VoiceSharingState Copied = new(Values.Copied);

    public static readonly VoiceSharingState CopiedDisabled = new(Values.CopiedDisabled);

    public VoiceSharingState(string value)
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
    public static VoiceSharingState FromCustom(string value)
    {
        return new VoiceSharingState(value);
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

    public static bool operator ==(VoiceSharingState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VoiceSharingState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VoiceSharingState value) => value.Value;

    public static explicit operator VoiceSharingState(string value) => new(value);

    internal class VoiceSharingStateSerializer : JsonConverter<VoiceSharingState>
    {
        public override VoiceSharingState Read(
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
            return new VoiceSharingState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoiceSharingState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoiceSharingState ReadAsPropertyName(
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
            return new VoiceSharingState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoiceSharingState value,
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
        public const string Enabled = "enabled";

        public const string Disabled = "disabled";

        public const string Copied = "copied";

        public const string CopiedDisabled = "copied_disabled";
    }
}
