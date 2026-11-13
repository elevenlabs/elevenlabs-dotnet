using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The category of the voice.</summary>
[JsonConverter(typeof(LibraryVoiceResponseCategory.LibraryVoiceResponseCategorySerializer))]
[Serializable]
public readonly record struct LibraryVoiceResponseCategory : IStringEnum
{
    public static readonly LibraryVoiceResponseCategory Generated = new(Values.Generated);

    public static readonly LibraryVoiceResponseCategory Cloned = new(Values.Cloned);

    public static readonly LibraryVoiceResponseCategory Premade = new(Values.Premade);

    public static readonly LibraryVoiceResponseCategory Professional = new(Values.Professional);

    public static readonly LibraryVoiceResponseCategory Famous = new(Values.Famous);

    public static readonly LibraryVoiceResponseCategory HighQuality = new(Values.HighQuality);

    public LibraryVoiceResponseCategory(string value)
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
    public static LibraryVoiceResponseCategory FromCustom(string value)
    {
        return new LibraryVoiceResponseCategory(value);
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

    public static bool operator ==(LibraryVoiceResponseCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LibraryVoiceResponseCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LibraryVoiceResponseCategory value) => value.Value;

    public static explicit operator LibraryVoiceResponseCategory(string value) => new(value);

    internal class LibraryVoiceResponseCategorySerializer
        : JsonConverter<LibraryVoiceResponseCategory>
    {
        public override LibraryVoiceResponseCategory Read(
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
            return new LibraryVoiceResponseCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LibraryVoiceResponseCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LibraryVoiceResponseCategory ReadAsPropertyName(
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
            return new LibraryVoiceResponseCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LibraryVoiceResponseCategory value,
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
        public const string Generated = "generated";

        public const string Cloned = "cloned";

        public const string Premade = "premade";

        public const string Professional = "professional";

        public const string Famous = "famous";

        public const string HighQuality = "high_quality";
    }
}
