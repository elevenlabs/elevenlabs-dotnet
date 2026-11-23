using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The usage mode of the knowledge base</summary>
[JsonConverter(
    typeof(ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode.ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageModeSerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode
    : IStringEnum
{
    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode Prompt =
        new(Values.Prompt);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode Auto =
        new(Values.Auto);

    public ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode(
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
    public static ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode FromCustom(
        string value
    )
    {
        return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode(
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
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode value
    ) => value.Value;

    public static explicit operator ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode(
        string value
    ) => new(value);

    internal class ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageModeSerializer
        : JsonConverter<ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode>
    {
        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode Read(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode ReadAsPropertyName(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemUsageMode value,
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
        public const string Prompt = "prompt";

        public const string Auto = "auto";
    }
}
