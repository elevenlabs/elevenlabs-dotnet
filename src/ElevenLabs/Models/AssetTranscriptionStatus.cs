using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AssetTranscriptionStatus.AssetTranscriptionStatusSerializer))]
[Serializable]
public readonly record struct AssetTranscriptionStatus : IStringEnum
{
    public static readonly AssetTranscriptionStatus Processing = new(Values.Processing);

    public static readonly AssetTranscriptionStatus Completed = new(Values.Completed);

    public static readonly AssetTranscriptionStatus Failed = new(Values.Failed);

    public AssetTranscriptionStatus(string value)
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
    public static AssetTranscriptionStatus FromCustom(string value)
    {
        return new AssetTranscriptionStatus(value);
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

    public static bool operator ==(AssetTranscriptionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AssetTranscriptionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AssetTranscriptionStatus value) => value.Value;

    public static explicit operator AssetTranscriptionStatus(string value) => new(value);

    internal class AssetTranscriptionStatusSerializer : JsonConverter<AssetTranscriptionStatus>
    {
        public override AssetTranscriptionStatus Read(
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
            return new AssetTranscriptionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AssetTranscriptionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AssetTranscriptionStatus ReadAsPropertyName(
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
            return new AssetTranscriptionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AssetTranscriptionStatus value,
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

        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
