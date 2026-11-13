using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationTokenPurpose.ConversationTokenPurposeSerializer))]
[Serializable]
public readonly record struct ConversationTokenPurpose : IStringEnum
{
    public static readonly ConversationTokenPurpose SignedUrl = new(Values.SignedUrl);

    public static readonly ConversationTokenPurpose ShareableLink = new(Values.ShareableLink);

    public ConversationTokenPurpose(string value)
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
    public static ConversationTokenPurpose FromCustom(string value)
    {
        return new ConversationTokenPurpose(value);
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

    public static bool operator ==(ConversationTokenPurpose value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationTokenPurpose value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationTokenPurpose value) => value.Value;

    public static explicit operator ConversationTokenPurpose(string value) => new(value);

    internal class ConversationTokenPurposeSerializer : JsonConverter<ConversationTokenPurpose>
    {
        public override ConversationTokenPurpose Read(
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
            return new ConversationTokenPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationTokenPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationTokenPurpose ReadAsPropertyName(
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
            return new ConversationTokenPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationTokenPurpose value,
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
        public const string SignedUrl = "signed_url";

        public const string ShareableLink = "shareable_link";
    }
}
