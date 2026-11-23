using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of the knowledge base</summary>
[JsonConverter(
    typeof(ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType.ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType
    : IStringEnum
{
    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType File =
        new(Values.File);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType Url =
        new(Values.Url);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType Text =
        new(Values.Text);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType Folder =
        new(Values.Folder);

    public ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType(
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
    public static ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType FromCustom(
        string value
    )
    {
        return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType(
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
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType value
    ) => value.Value;

    public static explicit operator ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType(
        string value
    ) => new(value);

    internal class ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemTypeSerializer
        : JsonConverter<ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType>
    {
        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType Read(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType ReadAsPropertyName(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptKnowledgeBaseItemType value,
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
        public const string File = "file";

        public const string Url = "url";

        public const string Text = "text";

        public const string Folder = "folder";
    }
}
