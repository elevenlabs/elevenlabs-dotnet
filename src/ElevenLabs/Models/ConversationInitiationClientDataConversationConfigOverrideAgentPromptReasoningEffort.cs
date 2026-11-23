using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Reasoning effort of the model. Only available for some models.</summary>
[JsonConverter(
    typeof(ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort.ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffortSerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort
    : IStringEnum
{
    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort None =
        new(Values.None);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort Minimal =
        new(Values.Minimal);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort Low =
        new(Values.Low);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort Medium =
        new(Values.Medium);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort High =
        new(Values.High);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort Xhigh =
        new(Values.Xhigh);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort Max =
        new(Values.Max);

    public ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort(
        string value
    )
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
    public static ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort FromCustom(
        string value
    )
    {
        return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort(
            value
        );
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
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort value
    ) => value.Value;

    public static explicit operator ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort(
        string value
    ) => new(value);

    internal class ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffortSerializer
        : JsonConverter<ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort>
    {
        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort Read(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort ReadAsPropertyName(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptReasoningEffort value,
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
        public const string None = "none";

        public const string Minimal = "minimal";

        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";

        public const string Xhigh = "xhigh";

        public const string Max = "max";
    }
}
