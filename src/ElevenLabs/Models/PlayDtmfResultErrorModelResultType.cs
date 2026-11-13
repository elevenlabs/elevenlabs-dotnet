using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(PlayDtmfResultErrorModelResultType.PlayDtmfResultErrorModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct PlayDtmfResultErrorModelResultType : IStringEnum
{
    public static readonly PlayDtmfResultErrorModelResultType PlayDtmfError = new(
        Values.PlayDtmfError
    );

    public PlayDtmfResultErrorModelResultType(string value)
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
    public static PlayDtmfResultErrorModelResultType FromCustom(string value)
    {
        return new PlayDtmfResultErrorModelResultType(value);
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

    public static bool operator ==(PlayDtmfResultErrorModelResultType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlayDtmfResultErrorModelResultType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlayDtmfResultErrorModelResultType value) => value.Value;

    public static explicit operator PlayDtmfResultErrorModelResultType(string value) => new(value);

    internal class PlayDtmfResultErrorModelResultTypeSerializer
        : JsonConverter<PlayDtmfResultErrorModelResultType>
    {
        public override PlayDtmfResultErrorModelResultType Read(
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
            return new PlayDtmfResultErrorModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlayDtmfResultErrorModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlayDtmfResultErrorModelResultType ReadAsPropertyName(
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
            return new PlayDtmfResultErrorModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlayDtmfResultErrorModelResultType value,
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
        public const string PlayDtmfError = "play_dtmf_error";
    }
}
