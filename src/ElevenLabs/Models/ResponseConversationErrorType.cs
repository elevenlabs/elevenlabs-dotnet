using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>User-facing error types exposed on the public API.</summary>
[JsonConverter(typeof(ResponseConversationErrorType.ResponseConversationErrorTypeSerializer))]
[Serializable]
public readonly record struct ResponseConversationErrorType : IStringEnum
{
    public static readonly ResponseConversationErrorType SystemError = new(Values.SystemError);

    public static readonly ResponseConversationErrorType CallInitializationError = new(
        Values.CallInitializationError
    );

    public static readonly ResponseConversationErrorType LineBusy = new(Values.LineBusy);

    public static readonly ResponseConversationErrorType NoAnswer = new(Values.NoAnswer);

    public static readonly ResponseConversationErrorType CallRejected = new(Values.CallRejected);

    public static readonly ResponseConversationErrorType BlockedByUser = new(Values.BlockedByUser);

    public static readonly ResponseConversationErrorType AgentConfigurationError = new(
        Values.AgentConfigurationError
    );

    public static readonly ResponseConversationErrorType InvalidClientRequest = new(
        Values.InvalidClientRequest
    );

    public static readonly ResponseConversationErrorType PermissionError = new(
        Values.PermissionError
    );

    public static readonly ResponseConversationErrorType EntitlementExceeded = new(
        Values.EntitlementExceeded
    );

    public static readonly ResponseConversationErrorType ClientDisconnected = new(
        Values.ClientDisconnected
    );

    public static readonly ResponseConversationErrorType LlmError = new(Values.LlmError);

    public static readonly ResponseConversationErrorType SpeechError = new(Values.SpeechError);

    public static readonly ResponseConversationErrorType ToolError = new(Values.ToolError);

    public static readonly ResponseConversationErrorType IntegrationError = new(
        Values.IntegrationError
    );

    public static readonly ResponseConversationErrorType GuardrailTriggered = new(
        Values.GuardrailTriggered
    );

    public static readonly ResponseConversationErrorType SafetyViolation = new(
        Values.SafetyViolation
    );

    public static readonly ResponseConversationErrorType MaxDurationExceeded = new(
        Values.MaxDurationExceeded
    );

    public static readonly ResponseConversationErrorType PostProcessingError = new(
        Values.PostProcessingError
    );

    public ResponseConversationErrorType(string value)
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
    public static ResponseConversationErrorType FromCustom(string value)
    {
        return new ResponseConversationErrorType(value);
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

    public static bool operator ==(ResponseConversationErrorType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResponseConversationErrorType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResponseConversationErrorType value) => value.Value;

    public static explicit operator ResponseConversationErrorType(string value) => new(value);

    internal class ResponseConversationErrorTypeSerializer
        : JsonConverter<ResponseConversationErrorType>
    {
        public override ResponseConversationErrorType Read(
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
            return new ResponseConversationErrorType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResponseConversationErrorType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResponseConversationErrorType ReadAsPropertyName(
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
            return new ResponseConversationErrorType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResponseConversationErrorType value,
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
        public const string SystemError = "system_error";

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

        public const string GuardrailTriggered = "guardrail_triggered";

        public const string SafetyViolation = "safety_violation";

        public const string MaxDurationExceeded = "max_duration_exceeded";

        public const string PostProcessingError = "post_processing_error";
    }
}
