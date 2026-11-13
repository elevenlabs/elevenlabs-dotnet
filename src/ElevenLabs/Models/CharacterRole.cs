using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CharacterRole.CharacterRoleSerializer))]
[Serializable]
public readonly record struct CharacterRole : IStringEnum
{
    public static readonly CharacterRole Narrator = new(Values.Narrator);

    public static readonly CharacterRole Main = new(Values.Main);

    public static readonly CharacterRole Supporting = new(Values.Supporting);

    public static readonly CharacterRole Minor = new(Values.Minor);

    public CharacterRole(string value)
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
    public static CharacterRole FromCustom(string value)
    {
        return new CharacterRole(value);
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

    public static bool operator ==(CharacterRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CharacterRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CharacterRole value) => value.Value;

    public static explicit operator CharacterRole(string value) => new(value);

    internal class CharacterRoleSerializer : JsonConverter<CharacterRole>
    {
        public override CharacterRole Read(
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
            return new CharacterRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CharacterRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CharacterRole ReadAsPropertyName(
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
            return new CharacterRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CharacterRole value,
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
        public const string Narrator = "narrator";

        public const string Main = "main";

        public const string Supporting = "supporting";

        public const string Minor = "minor";
    }
}
