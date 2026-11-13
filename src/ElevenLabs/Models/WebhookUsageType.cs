using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WebhookUsageType.WebhookUsageTypeSerializer))]
[Serializable]
public readonly record struct WebhookUsageType : IStringEnum
{
    public static readonly WebhookUsageType ConvAiAgentSettings = new(Values.ConvAiAgentSettings);

    public static readonly WebhookUsageType ConvAiSettings = new(Values.ConvAiSettings);

    public static readonly WebhookUsageType VoiceLibraryRemovalNotices = new(
        Values.VoiceLibraryRemovalNotices
    );

    public static readonly WebhookUsageType SpeechToText = new(Values.SpeechToText);

    public static readonly WebhookUsageType AgentQaEvaluations = new(Values.AgentQaEvaluations);

    public static readonly WebhookUsageType ConvAiAlerting = new(Values.ConvAiAlerting);

    public static readonly WebhookUsageType Flows = new(Values.Flows);

    public static readonly WebhookUsageType Dubbing = new(Values.Dubbing);

    public WebhookUsageType(string value)
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
    public static WebhookUsageType FromCustom(string value)
    {
        return new WebhookUsageType(value);
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

    public static bool operator ==(WebhookUsageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookUsageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookUsageType value) => value.Value;

    public static explicit operator WebhookUsageType(string value) => new(value);

    internal class WebhookUsageTypeSerializer : JsonConverter<WebhookUsageType>
    {
        public override WebhookUsageType Read(
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
            return new WebhookUsageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookUsageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookUsageType ReadAsPropertyName(
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
            return new WebhookUsageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookUsageType value,
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
        public const string ConvAiAgentSettings = "ConvAI Agent Settings";

        public const string ConvAiSettings = "ConvAI Settings";

        public const string VoiceLibraryRemovalNotices = "Voice Library Removal Notices";

        public const string SpeechToText = "Speech to Text";

        public const string AgentQaEvaluations = "Agent QA Evaluations";

        public const string ConvAiAlerting = "ConvAI Alerting";

        public const string Flows = "Flows";

        public const string Dubbing = "Dubbing";
    }
}
