using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(ElevenFlashV25RequestModelId.ElevenFlashV25RequestModelIdSerializer))]
[Serializable]
public readonly record struct ElevenFlashV25RequestModelId : IStringEnum
{
    public static readonly ElevenFlashV25RequestModelId ElevenFlashV25 = new(Values.ElevenFlashV25);

    public ElevenFlashV25RequestModelId(string value)
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
    public static ElevenFlashV25RequestModelId FromCustom(string value)
    {
        return new ElevenFlashV25RequestModelId(value);
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

    public static bool operator ==(ElevenFlashV25RequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ElevenFlashV25RequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ElevenFlashV25RequestModelId value) => value.Value;

    public static explicit operator ElevenFlashV25RequestModelId(string value) => new(value);

    internal class ElevenFlashV25RequestModelIdSerializer
        : JsonConverter<ElevenFlashV25RequestModelId>
    {
        public override ElevenFlashV25RequestModelId Read(
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
            return new ElevenFlashV25RequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ElevenFlashV25RequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ElevenFlashV25RequestModelId ReadAsPropertyName(
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
            return new ElevenFlashV25RequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ElevenFlashV25RequestModelId value,
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
        public const string ElevenFlashV25 = "eleven_flash_v2_5";
    }
}
