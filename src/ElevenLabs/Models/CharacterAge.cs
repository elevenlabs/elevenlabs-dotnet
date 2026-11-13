using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CharacterAge.CharacterAgeSerializer))]
[Serializable]
public readonly record struct CharacterAge : IStringEnum
{
    public static readonly CharacterAge Young = new(Values.Young);

    public static readonly CharacterAge MiddleAged = new(Values.MiddleAged);

    public static readonly CharacterAge Old = new(Values.Old);

    public CharacterAge(string value)
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
    public static CharacterAge FromCustom(string value)
    {
        return new CharacterAge(value);
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

    public static bool operator ==(CharacterAge value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CharacterAge value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CharacterAge value) => value.Value;

    public static explicit operator CharacterAge(string value) => new(value);

    internal class CharacterAgeSerializer : JsonConverter<CharacterAge>
    {
        public override CharacterAge Read(
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
            return new CharacterAge(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CharacterAge value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CharacterAge ReadAsPropertyName(
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
            return new CharacterAge(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CharacterAge value,
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
        public const string Young = "young";

        public const string MiddleAged = "middle_aged";

        public const string Old = "old";
    }
}
