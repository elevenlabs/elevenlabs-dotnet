using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CharacterGender.CharacterGenderSerializer))]
[Serializable]
public readonly record struct CharacterGender : IStringEnum
{
    public static readonly CharacterGender Male = new(Values.Male);

    public static readonly CharacterGender Female = new(Values.Female);

    public static readonly CharacterGender Neutral = new(Values.Neutral);

    public CharacterGender(string value)
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
    public static CharacterGender FromCustom(string value)
    {
        return new CharacterGender(value);
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

    public static bool operator ==(CharacterGender value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CharacterGender value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CharacterGender value) => value.Value;

    public static explicit operator CharacterGender(string value) => new(value);

    internal class CharacterGenderSerializer : JsonConverter<CharacterGender>
    {
        public override CharacterGender Read(
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
            return new CharacterGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CharacterGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CharacterGender ReadAsPropertyName(
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
            return new CharacterGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CharacterGender value,
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
        public const string Male = "male";

        public const string Female = "female";

        public const string Neutral = "neutral";
    }
}
