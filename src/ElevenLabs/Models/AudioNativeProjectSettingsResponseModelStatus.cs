using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Current state of the project</summary>
[JsonConverter(
    typeof(AudioNativeProjectSettingsResponseModelStatus.AudioNativeProjectSettingsResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct AudioNativeProjectSettingsResponseModelStatus : IStringEnum
{
    public static readonly AudioNativeProjectSettingsResponseModelStatus Processing = new(
        Values.Processing
    );

    public static readonly AudioNativeProjectSettingsResponseModelStatus Ready = new(Values.Ready);

    public AudioNativeProjectSettingsResponseModelStatus(string value)
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
    public static AudioNativeProjectSettingsResponseModelStatus FromCustom(string value)
    {
        return new AudioNativeProjectSettingsResponseModelStatus(value);
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

    public static bool operator ==(
        AudioNativeProjectSettingsResponseModelStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AudioNativeProjectSettingsResponseModelStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AudioNativeProjectSettingsResponseModelStatus value) =>
        value.Value;

    public static explicit operator AudioNativeProjectSettingsResponseModelStatus(string value) =>
        new(value);

    internal class AudioNativeProjectSettingsResponseModelStatusSerializer
        : JsonConverter<AudioNativeProjectSettingsResponseModelStatus>
    {
        public override AudioNativeProjectSettingsResponseModelStatus Read(
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
            return new AudioNativeProjectSettingsResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AudioNativeProjectSettingsResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AudioNativeProjectSettingsResponseModelStatus ReadAsPropertyName(
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
            return new AudioNativeProjectSettingsResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AudioNativeProjectSettingsResponseModelStatus value,
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
        public const string Processing = "processing";

        public const string Ready = "ready";
    }
}
