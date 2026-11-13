using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentConversationTicketIssueType.AgentConversationTicketIssueTypeSerializer))]
[Serializable]
public readonly record struct AgentConversationTicketIssueType : IStringEnum
{
    public static readonly AgentConversationTicketIssueType KnowledgeGap = new(Values.KnowledgeGap);

    public static readonly AgentConversationTicketIssueType IncorrectInformation = new(
        Values.IncorrectInformation
    );

    public static readonly AgentConversationTicketIssueType DocumentationGap = new(
        Values.DocumentationGap
    );

    public static readonly AgentConversationTicketIssueType ProductFeedback = new(
        Values.ProductFeedback
    );

    public static readonly AgentConversationTicketIssueType PlatformBug = new(Values.PlatformBug);

    public static readonly AgentConversationTicketIssueType ToolIssue = new(Values.ToolIssue);

    public static readonly AgentConversationTicketIssueType MissingTool = new(Values.MissingTool);

    public static readonly AgentConversationTicketIssueType UnnecessaryEscalation = new(
        Values.UnnecessaryEscalation
    );

    public static readonly AgentConversationTicketIssueType WrongAction = new(Values.WrongAction);

    public AgentConversationTicketIssueType(string value)
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
    public static AgentConversationTicketIssueType FromCustom(string value)
    {
        return new AgentConversationTicketIssueType(value);
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

    public static bool operator ==(AgentConversationTicketIssueType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentConversationTicketIssueType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentConversationTicketIssueType value) => value.Value;

    public static explicit operator AgentConversationTicketIssueType(string value) => new(value);

    internal class AgentConversationTicketIssueTypeSerializer
        : JsonConverter<AgentConversationTicketIssueType>
    {
        public override AgentConversationTicketIssueType Read(
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
            return new AgentConversationTicketIssueType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentConversationTicketIssueType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentConversationTicketIssueType ReadAsPropertyName(
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
            return new AgentConversationTicketIssueType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentConversationTicketIssueType value,
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
        public const string KnowledgeGap = "knowledge_gap";

        public const string IncorrectInformation = "incorrect_information";

        public const string DocumentationGap = "documentation_gap";

        public const string ProductFeedback = "product_feedback";

        public const string PlatformBug = "platform_bug";

        public const string ToolIssue = "tool_issue";

        public const string MissingTool = "missing_tool";

        public const string UnnecessaryEscalation = "unnecessary_escalation";

        public const string WrongAction = "wrong_action";
    }
}
