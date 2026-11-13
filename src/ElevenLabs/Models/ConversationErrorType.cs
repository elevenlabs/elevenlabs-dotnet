using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Stored in conversation history. Never exposed to customers directly.</summary>
[JsonConverter(typeof(ConversationErrorType.ConversationErrorTypeSerializer))]
[Serializable]
public readonly record struct ConversationErrorType : IStringEnum
{
    public static readonly ConversationErrorType Unknown = new(Values.Unknown);

    public static readonly ConversationErrorType CallInitializationError = new(
        Values.CallInitializationError
    );

    public static readonly ConversationErrorType LineBusy = new(Values.LineBusy);

    public static readonly ConversationErrorType NoAnswer = new(Values.NoAnswer);

    public static readonly ConversationErrorType CallRejected = new(Values.CallRejected);

    public static readonly ConversationErrorType BlockedByUser = new(Values.BlockedByUser);

    public static readonly ConversationErrorType AgentConfigurationError = new(
        Values.AgentConfigurationError
    );

    public static readonly ConversationErrorType InvalidClientRequest = new(
        Values.InvalidClientRequest
    );

    public static readonly ConversationErrorType PermissionError = new(Values.PermissionError);

    public static readonly ConversationErrorType EntitlementExceeded = new(
        Values.EntitlementExceeded
    );

    public static readonly ConversationErrorType ClientDisconnected = new(
        Values.ClientDisconnected
    );

    public static readonly ConversationErrorType LlmError = new(Values.LlmError);

    public static readonly ConversationErrorType SpeechError = new(Values.SpeechError);

    public static readonly ConversationErrorType ToolError = new(Values.ToolError);

    public static readonly ConversationErrorType IntegrationError = new(Values.IntegrationError);

    public static readonly ConversationErrorType DependencyError = new(Values.DependencyError);

    public static readonly ConversationErrorType GuardrailTriggered = new(
        Values.GuardrailTriggered
    );

    public static readonly ConversationErrorType SafetyViolation = new(Values.SafetyViolation);

    public static readonly ConversationErrorType MaxDurationExceeded = new(
        Values.MaxDurationExceeded
    );

    public static readonly ConversationErrorType WorkflowEndFailure = new(
        Values.WorkflowEndFailure
    );

    public static readonly ConversationErrorType InternalError = new(Values.InternalError);

    public static readonly ConversationErrorType PostProcessingError = new(
        Values.PostProcessingError
    );

    public ConversationErrorType(string value)
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
    public static ConversationErrorType FromCustom(string value)
    {
        return new ConversationErrorType(value);
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

    public static bool operator ==(ConversationErrorType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationErrorType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationErrorType value) => value.Value;

    public static explicit operator ConversationErrorType(string value) => new(value);

    internal class ConversationErrorTypeSerializer : JsonConverter<ConversationErrorType>
    {
        public override ConversationErrorType Read(
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
            return new ConversationErrorType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationErrorType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationErrorType ReadAsPropertyName(
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
            return new ConversationErrorType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationErrorType value,
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
        public const string Unknown = "unknown";

        public const string CallInitializationError = "call_initialization_error";

        public const string LineBusy = "line_busy";

        public const string NoAnswer = "no_answer";

        public const string CallRejected = "call_rejected";

        public const string BlockedByUser = "blocked_by_user";

        public const string AgentConfigurationError = "agent_configuration_error";

        public const string InvalidClientRequest = "invalid_client_request";

        public const string PermissionError = "permission_error";

        public const string EntitlementExceeded = "entitlement_exceeded";

        public const string ClientDisconnected = "client_disconnected";

        public const string LlmError = "llm_error";

        public const string SpeechError = "speech_error";

        public const string ToolError = "tool_error";

        public const string IntegrationError = "integration_error";

        public const string DependencyError = "dependency_error";

        public const string GuardrailTriggered = "guardrail_triggered";

        public const string SafetyViolation = "safety_violation";

        public const string MaxDurationExceeded = "max_duration_exceeded";

        public const string WorkflowEndFailure = "workflow_end_failure";

        public const string InternalError = "internal_error";

        public const string PostProcessingError = "post_processing_error";
    }
}
