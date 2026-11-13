using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Model to use for the voice generation. Possible values: eleven_multilingual_ttv_v2, eleven_ttv_v3.</summary>
[JsonConverter(typeof(VoiceDesignRequestModelModelId.VoiceDesignRequestModelModelIdSerializer))]
[Serializable]
public readonly record struct VoiceDesignRequestModelModelId : IStringEnum
{
    public static readonly VoiceDesignRequestModelModelId ElevenMultilingualTtvV2 = new(
        Values.ElevenMultilingualTtvV2
    );

    public static readonly VoiceDesignRequestModelModelId ElevenTtvV3 = new(Values.ElevenTtvV3);

    public VoiceDesignRequestModelModelId(string value)
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
    public static VoiceDesignRequestModelModelId FromCustom(string value)
    {
        return new VoiceDesignRequestModelModelId(value);
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

    public static bool operator ==(VoiceDesignRequestModelModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VoiceDesignRequestModelModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VoiceDesignRequestModelModelId value) => value.Value;

    public static explicit operator VoiceDesignRequestModelModelId(string value) => new(value);

    internal class VoiceDesignRequestModelModelIdSerializer
        : JsonConverter<VoiceDesignRequestModelModelId>
    {
        public override VoiceDesignRequestModelModelId Read(
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
            return new VoiceDesignRequestModelModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoiceDesignRequestModelModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoiceDesignRequestModelModelId ReadAsPropertyName(
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
            return new VoiceDesignRequestModelModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoiceDesignRequestModelModelId value,
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
        public const string ElevenMultilingualTtvV2 = "eleven_multilingual_ttv_v2";

        public const string ElevenTtvV3 = "eleven_ttv_v3";
    }
}
