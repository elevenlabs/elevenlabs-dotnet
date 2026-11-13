using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(PlayDtmfResultSuccessModelResultType.PlayDtmfResultSuccessModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct PlayDtmfResultSuccessModelResultType : IStringEnum
{
    public static readonly PlayDtmfResultSuccessModelResultType PlayDtmfSuccess = new(
        Values.PlayDtmfSuccess
    );

    public PlayDtmfResultSuccessModelResultType(string value)
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
    public static PlayDtmfResultSuccessModelResultType FromCustom(string value)
    {
        return new PlayDtmfResultSuccessModelResultType(value);
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

    public static bool operator ==(PlayDtmfResultSuccessModelResultType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlayDtmfResultSuccessModelResultType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlayDtmfResultSuccessModelResultType value) =>
        value.Value;

    public static explicit operator PlayDtmfResultSuccessModelResultType(string value) =>
        new(value);

    internal class PlayDtmfResultSuccessModelResultTypeSerializer
        : JsonConverter<PlayDtmfResultSuccessModelResultType>
    {
        public override PlayDtmfResultSuccessModelResultType Read(
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
            return new PlayDtmfResultSuccessModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlayDtmfResultSuccessModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlayDtmfResultSuccessModelResultType ReadAsPropertyName(
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
            return new PlayDtmfResultSuccessModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlayDtmfResultSuccessModelResultType value,
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
        public const string PlayDtmfSuccess = "play_dtmf_success";
    }
}
