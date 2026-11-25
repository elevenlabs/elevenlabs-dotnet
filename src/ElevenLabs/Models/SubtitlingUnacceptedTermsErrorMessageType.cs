using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SubtitlingUnacceptedTermsErrorMessageType.SubtitlingUnacceptedTermsErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct SubtitlingUnacceptedTermsErrorMessageType : IStringEnum
{
    public static readonly SubtitlingUnacceptedTermsErrorMessageType UnacceptedTerms = new(
        Values.UnacceptedTerms
    );

    public SubtitlingUnacceptedTermsErrorMessageType(string value)
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
    public static SubtitlingUnacceptedTermsErrorMessageType FromCustom(string value)
    {
        return new SubtitlingUnacceptedTermsErrorMessageType(value);
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
        SubtitlingUnacceptedTermsErrorMessageType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SubtitlingUnacceptedTermsErrorMessageType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingUnacceptedTermsErrorMessageType value) =>
        value.Value;

    public static explicit operator SubtitlingUnacceptedTermsErrorMessageType(string value) =>
        new(value);

    internal class SubtitlingUnacceptedTermsErrorMessageTypeSerializer
        : JsonConverter<SubtitlingUnacceptedTermsErrorMessageType>
    {
        public override SubtitlingUnacceptedTermsErrorMessageType Read(
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
            return new SubtitlingUnacceptedTermsErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingUnacceptedTermsErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingUnacceptedTermsErrorMessageType ReadAsPropertyName(
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
            return new SubtitlingUnacceptedTermsErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingUnacceptedTermsErrorMessageType value,
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
        public const string UnacceptedTerms = "unaccepted_terms";
    }
}
