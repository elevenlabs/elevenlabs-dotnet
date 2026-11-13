using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Identifies this warning; branch on it to read the other fields.</summary>
[JsonConverter(typeof(VoicesNotPermittedWarningType.VoicesNotPermittedWarningTypeSerializer))]
[Serializable]
public readonly record struct VoicesNotPermittedWarningType : IStringEnum
{
    public static readonly VoicesNotPermittedWarningType VoicesNotPermitted = new(
        Values.VoicesNotPermitted
    );

    public VoicesNotPermittedWarningType(string value)
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
    public static VoicesNotPermittedWarningType FromCustom(string value)
    {
        return new VoicesNotPermittedWarningType(value);
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

    public static bool operator ==(VoicesNotPermittedWarningType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VoicesNotPermittedWarningType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VoicesNotPermittedWarningType value) => value.Value;

    public static explicit operator VoicesNotPermittedWarningType(string value) => new(value);

    internal class VoicesNotPermittedWarningTypeSerializer
        : JsonConverter<VoicesNotPermittedWarningType>
    {
        public override VoicesNotPermittedWarningType Read(
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
            return new VoicesNotPermittedWarningType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoicesNotPermittedWarningType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoicesNotPermittedWarningType ReadAsPropertyName(
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
            return new VoicesNotPermittedWarningType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoicesNotPermittedWarningType value,
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
        public const string VoicesNotPermitted = "voices_not_permitted";
    }
}
