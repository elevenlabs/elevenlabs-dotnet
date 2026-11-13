using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The audio encoding of the output, as `codec_sampleRateHz_bitrateKbps`. `mp3_44100_192` requires the Creator tier or above.</summary>
[JsonConverter(
    typeof(ElevenMultilingualV2RequestOutputFormat.ElevenMultilingualV2RequestOutputFormatSerializer)
)]
[Serializable]
public readonly record struct ElevenMultilingualV2RequestOutputFormat : IStringEnum
{
    public static readonly ElevenMultilingualV2RequestOutputFormat Mp32205032 = new(
        Values.Mp32205032
    );

    public static readonly ElevenMultilingualV2RequestOutputFormat Mp32400048 = new(
        Values.Mp32400048
    );

    public static readonly ElevenMultilingualV2RequestOutputFormat Mp34410032 = new(
        Values.Mp34410032
    );

    public static readonly ElevenMultilingualV2RequestOutputFormat Mp34410064 = new(
        Values.Mp34410064
    );

    public static readonly ElevenMultilingualV2RequestOutputFormat Mp34410096 = new(
        Values.Mp34410096
    );

    public static readonly ElevenMultilingualV2RequestOutputFormat Mp344100128 = new(
        Values.Mp344100128
    );

    public static readonly ElevenMultilingualV2RequestOutputFormat Mp344100192 = new(
        Values.Mp344100192
    );

    public ElevenMultilingualV2RequestOutputFormat(string value)
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
    public static ElevenMultilingualV2RequestOutputFormat FromCustom(string value)
    {
        return new ElevenMultilingualV2RequestOutputFormat(value);
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

    public static bool operator ==(ElevenMultilingualV2RequestOutputFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ElevenMultilingualV2RequestOutputFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ElevenMultilingualV2RequestOutputFormat value) =>
        value.Value;

    public static explicit operator ElevenMultilingualV2RequestOutputFormat(string value) =>
        new(value);

    internal class ElevenMultilingualV2RequestOutputFormatSerializer
        : JsonConverter<ElevenMultilingualV2RequestOutputFormat>
    {
        public override ElevenMultilingualV2RequestOutputFormat Read(
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
            return new ElevenMultilingualV2RequestOutputFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ElevenMultilingualV2RequestOutputFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ElevenMultilingualV2RequestOutputFormat ReadAsPropertyName(
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
            return new ElevenMultilingualV2RequestOutputFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ElevenMultilingualV2RequestOutputFormat value,
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
        public const string Mp32205032 = "mp3_22050_32";

        public const string Mp32400048 = "mp3_24000_48";

        public const string Mp34410032 = "mp3_44100_32";

        public const string Mp34410064 = "mp3_44100_64";

        public const string Mp34410096 = "mp3_44100_96";

        public const string Mp344100128 = "mp3_44100_128";

        public const string Mp344100192 = "mp3_44100_192";
    }
}
