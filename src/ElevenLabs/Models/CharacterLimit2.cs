using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.ServiceAccounts;

[JsonConverter(typeof(CharacterLimit2.CharacterLimit2Serializer))]
[Serializable]
public readonly record struct CharacterLimit2 : IStringEnum
{
    public static readonly CharacterLimit2 Clear = new(Values.Clear);

    public static readonly CharacterLimit2 NoUpdate = new(Values.NoUpdate);

    public CharacterLimit2(string value)
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
    public static CharacterLimit2 FromCustom(string value)
    {
        return new CharacterLimit2(value);
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

    public static bool operator ==(CharacterLimit2 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CharacterLimit2 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CharacterLimit2 value) => value.Value;

    public static explicit operator CharacterLimit2(string value) => new(value);

    internal class CharacterLimit2Serializer : JsonConverter<CharacterLimit2>
    {
        public override CharacterLimit2 Read(
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
            return new CharacterLimit2(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CharacterLimit2 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CharacterLimit2 ReadAsPropertyName(
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
            return new CharacterLimit2(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CharacterLimit2 value,
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
        public const string Clear = "clear";

        public const string NoUpdate = "no_update";
    }
}
