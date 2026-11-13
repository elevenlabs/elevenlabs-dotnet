using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicOnlyOutputFormats.MusicOnlyOutputFormatsSerializer))]
[Serializable]
public readonly record struct MusicOnlyOutputFormats : IStringEnum
{
    public static readonly MusicOnlyOutputFormats Mp348000128 = new(Values.Mp348000128);

    public static readonly MusicOnlyOutputFormats Mp348000192 = new(Values.Mp348000192);

    public static readonly MusicOnlyOutputFormats Mp348000240 = new(Values.Mp348000240);

    public static readonly MusicOnlyOutputFormats Mp348000320 = new(Values.Mp348000320);

    public MusicOnlyOutputFormats(string value)
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
    public static MusicOnlyOutputFormats FromCustom(string value)
    {
        return new MusicOnlyOutputFormats(value);
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

    public static bool operator ==(MusicOnlyOutputFormats value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicOnlyOutputFormats value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicOnlyOutputFormats value) => value.Value;

    public static explicit operator MusicOnlyOutputFormats(string value) => new(value);

    internal class MusicOnlyOutputFormatsSerializer : JsonConverter<MusicOnlyOutputFormats>
    {
        public override MusicOnlyOutputFormats Read(
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
            return new MusicOnlyOutputFormats(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicOnlyOutputFormats value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicOnlyOutputFormats ReadAsPropertyName(
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
            return new MusicOnlyOutputFormats(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicOnlyOutputFormats value,
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
        public const string Mp348000128 = "mp3_48000_128";

        public const string Mp348000192 = "mp3_48000_192";

        public const string Mp348000240 = "mp3_48000_240";

        public const string Mp348000320 = "mp3_48000_320";
    }
}
