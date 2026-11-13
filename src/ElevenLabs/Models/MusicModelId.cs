using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicModelId.MusicModelIdSerializer))]
[Serializable]
public readonly record struct MusicModelId : IStringEnum
{
    public static readonly MusicModelId MusicV1 = new(Values.MusicV1);

    public static readonly MusicModelId MusicV2 = new(Values.MusicV2);

    public static readonly MusicModelId MusicV25 = new(Values.MusicV25);

    public MusicModelId(string value)
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
    public static MusicModelId FromCustom(string value)
    {
        return new MusicModelId(value);
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

    public static bool operator ==(MusicModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicModelId value) => value.Value;

    public static explicit operator MusicModelId(string value) => new(value);

    internal class MusicModelIdSerializer : JsonConverter<MusicModelId>
    {
        public override MusicModelId Read(
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
            return new MusicModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicModelId ReadAsPropertyName(
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
            return new MusicModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicModelId value,
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
        public const string MusicV1 = "music_v1";

        public const string MusicV2 = "music_v2";

        public const string MusicV25 = "music_v2_5";
    }
}
