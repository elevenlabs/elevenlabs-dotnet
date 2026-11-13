using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(VoiceCategory.VoiceCategorySerializer))]
[Serializable]
public readonly record struct VoiceCategory : IStringEnum
{
    public static readonly VoiceCategory Premade = new(Values.Premade);

    public static readonly VoiceCategory Cloned = new(Values.Cloned);

    public static readonly VoiceCategory Generated = new(Values.Generated);

    public static readonly VoiceCategory Professional = new(Values.Professional);

    public VoiceCategory(string value)
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
    public static VoiceCategory FromCustom(string value)
    {
        return new VoiceCategory(value);
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

    public static bool operator ==(VoiceCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VoiceCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VoiceCategory value) => value.Value;

    public static explicit operator VoiceCategory(string value) => new(value);

    internal class VoiceCategorySerializer : JsonConverter<VoiceCategory>
    {
        public override VoiceCategory Read(
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
            return new VoiceCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoiceCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoiceCategory ReadAsPropertyName(
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
            return new VoiceCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoiceCategory value,
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
        public const string Premade = "premade";

        public const string Cloned = "cloned";

        public const string Generated = "generated";

        public const string Professional = "professional";
    }
}
