using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PlayDtmfResultSuccessModelStatus.PlayDtmfResultSuccessModelStatusSerializer))]
[Serializable]
public readonly record struct PlayDtmfResultSuccessModelStatus : IStringEnum
{
    public static readonly PlayDtmfResultSuccessModelStatus Success = new(Values.Success);

    public PlayDtmfResultSuccessModelStatus(string value)
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
    public static PlayDtmfResultSuccessModelStatus FromCustom(string value)
    {
        return new PlayDtmfResultSuccessModelStatus(value);
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

    public static bool operator ==(PlayDtmfResultSuccessModelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlayDtmfResultSuccessModelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlayDtmfResultSuccessModelStatus value) => value.Value;

    public static explicit operator PlayDtmfResultSuccessModelStatus(string value) => new(value);

    internal class PlayDtmfResultSuccessModelStatusSerializer
        : JsonConverter<PlayDtmfResultSuccessModelStatus>
    {
        public override PlayDtmfResultSuccessModelStatus Read(
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
            return new PlayDtmfResultSuccessModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlayDtmfResultSuccessModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlayDtmfResultSuccessModelStatus ReadAsPropertyName(
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
            return new PlayDtmfResultSuccessModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlayDtmfResultSuccessModelStatus value,
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
        public const string Success = "success";
    }
}
