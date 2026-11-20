using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TextOutputItemRole.TextOutputItemRoleSerializer))]
[Serializable]
public readonly record struct TextOutputItemRole : IStringEnum
{
    public static readonly TextOutputItemRole Agent = new(Values.Agent);

    public TextOutputItemRole(string value)
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
    public static TextOutputItemRole FromCustom(string value)
    {
        return new TextOutputItemRole(value);
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

    public static bool operator ==(TextOutputItemRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TextOutputItemRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TextOutputItemRole value) => value.Value;

    public static explicit operator TextOutputItemRole(string value) => new(value);

    internal class TextOutputItemRoleSerializer : JsonConverter<TextOutputItemRole>
    {
        public override TextOutputItemRole Read(
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
            return new TextOutputItemRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextOutputItemRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextOutputItemRole ReadAsPropertyName(
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
            return new TextOutputItemRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextOutputItemRole value,
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
        public const string Agent = "agent";
    }
}
