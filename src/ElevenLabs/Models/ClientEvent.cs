using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ClientEvent.ClientEventSerializer))]
[Serializable]
public readonly record struct ClientEvent : IStringEnum
{
    public static readonly ClientEvent ConversationInitiationMetadata = new(
        Values.ConversationInitiationMetadata
    );

    public static readonly ClientEvent AsrInitiationMetadata = new(Values.AsrInitiationMetadata);

    public static readonly ClientEvent Ping = new(Values.Ping);

    public static readonly ClientEvent Audio = new(Values.Audio);

    public static readonly ClientEvent Interruption = new(Values.Interruption);

    public static readonly ClientEvent UserTranscript = new(Values.UserTranscript);

    public static readonly ClientEvent TentativeUserTranscript = new(
        Values.TentativeUserTranscript
    );

    public static readonly ClientEvent AgentResponse = new(Values.AgentResponse);

    public static readonly ClientEvent AgentResponseCorrection = new(
        Values.AgentResponseCorrection
    );

    public static readonly ClientEvent ClientToolCall = new(Values.ClientToolCall);

    public static readonly ClientEvent McpToolCall = new(Values.McpToolCall);

    public static readonly ClientEvent McpConnectionStatus = new(Values.McpConnectionStatus);

    public static readonly ClientEvent AgentToolRequest = new(Values.AgentToolRequest);

    public static readonly ClientEvent AgentToolResponse = new(Values.AgentToolResponse);

    public static readonly ClientEvent AgentToolResponseFullPayload = new(
        Values.AgentToolResponseFullPayload
    );

    public static readonly ClientEvent AgentResponseMetadata = new(Values.AgentResponseMetadata);

    public static readonly ClientEvent VadScore = new(Values.VadScore);

    public static readonly ClientEvent AgentChatResponsePart = new(Values.AgentChatResponsePart);

    public static readonly ClientEvent ClientError = new(Values.ClientError);

    public static readonly ClientEvent GuardrailTriggered = new(Values.GuardrailTriggered);

    public static readonly ClientEvent DtmfRequest = new(Values.DtmfRequest);

    public static readonly ClientEvent AgentResponseComplete = new(Values.AgentResponseComplete);

    public static readonly ClientEvent ContextUsage = new(Values.ContextUsage);

    public static readonly ClientEvent InternalTurnProbability = new(
        Values.InternalTurnProbability
    );

    public static readonly ClientEvent InternalTentativeAgentResponse = new(
        Values.InternalTentativeAgentResponse
    );

    public ClientEvent(string value)
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
    public static ClientEvent FromCustom(string value)
    {
        return new ClientEvent(value);
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

    public static bool operator ==(ClientEvent value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientEvent value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientEvent value) => value.Value;

    public static explicit operator ClientEvent(string value) => new(value);

    internal class ClientEventSerializer : JsonConverter<ClientEvent>
    {
        public override ClientEvent Read(
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
            return new ClientEvent(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientEvent ReadAsPropertyName(
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
            return new ClientEvent(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientEvent value,
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
        public const string ConversationInitiationMetadata = "conversation_initiation_metadata";

        public const string AsrInitiationMetadata = "asr_initiation_metadata";

        public const string Ping = "ping";

        public const string Audio = "audio";

        public const string Interruption = "interruption";

        public const string UserTranscript = "user_transcript";

        public const string TentativeUserTranscript = "tentative_user_transcript";

        public const string AgentResponse = "agent_response";

        public const string AgentResponseCorrection = "agent_response_correction";

        public const string ClientToolCall = "client_tool_call";

        public const string McpToolCall = "mcp_tool_call";

        public const string McpConnectionStatus = "mcp_connection_status";

        public const string AgentToolRequest = "agent_tool_request";

        public const string AgentToolResponse = "agent_tool_response";

        public const string AgentToolResponseFullPayload = "agent_tool_response_full_payload";

        public const string AgentResponseMetadata = "agent_response_metadata";

        public const string VadScore = "vad_score";

        public const string AgentChatResponsePart = "agent_chat_response_part";

        public const string ClientError = "client_error";

        public const string GuardrailTriggered = "guardrail_triggered";

        public const string DtmfRequest = "dtmf_request";

        public const string AgentResponseComplete = "agent_response_complete";

        public const string ContextUsage = "context_usage";

        public const string InternalTurnProbability = "internal_turn_probability";

        public const string InternalTentativeAgentResponse = "internal_tentative_agent_response";
    }
}
