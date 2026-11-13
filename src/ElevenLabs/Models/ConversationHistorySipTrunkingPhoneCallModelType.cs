using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistorySipTrunkingPhoneCallModelType.ConversationHistorySipTrunkingPhoneCallModelTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationHistorySipTrunkingPhoneCallModelType : IStringEnum
{
    public static readonly ConversationHistorySipTrunkingPhoneCallModelType SipTrunking = new(
        Values.SipTrunking
    );

    public ConversationHistorySipTrunkingPhoneCallModelType(string value)
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
    public static ConversationHistorySipTrunkingPhoneCallModelType FromCustom(string value)
    {
        return new ConversationHistorySipTrunkingPhoneCallModelType(value);
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
        ConversationHistorySipTrunkingPhoneCallModelType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistorySipTrunkingPhoneCallModelType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationHistorySipTrunkingPhoneCallModelType value
    ) => value.Value;

    public static explicit operator ConversationHistorySipTrunkingPhoneCallModelType(
        string value
    ) => new(value);

    internal class ConversationHistorySipTrunkingPhoneCallModelTypeSerializer
        : JsonConverter<ConversationHistorySipTrunkingPhoneCallModelType>
    {
        public override ConversationHistorySipTrunkingPhoneCallModelType Read(
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
            return new ConversationHistorySipTrunkingPhoneCallModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistorySipTrunkingPhoneCallModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistorySipTrunkingPhoneCallModelType ReadAsPropertyName(
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
            return new ConversationHistorySipTrunkingPhoneCallModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistorySipTrunkingPhoneCallModelType value,
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
        public const string SipTrunking = "sip_trunking";
    }
}
