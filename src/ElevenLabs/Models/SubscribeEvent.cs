// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SubscribeEvent.JsonConverter))]
[Serializable]
public class SubscribeEvent
{
    private SubscribeEvent(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a SubscribeEvent from a ConversationInitiationMetadata value.
    /// </summary>
    public static SubscribeEvent FromConversationInitiationMetadata(
        global::ElevenLabs.ConversationInitiationMetadata value
    ) => new("conversationInitiationMetadata", value);

    /// <summary>
    /// Create a SubscribeEvent from a AgentResponseComplete value.
    /// </summary>
    public static SubscribeEvent FromAgentResponseComplete(
        global::ElevenLabs.AgentResponseComplete value
    ) => new("agentResponseComplete", value);

    /// <summary>
    /// Create a SubscribeEvent from a ContextUsage value.
    /// </summary>
    public static SubscribeEvent FromContextUsage(global::ElevenLabs.ContextUsage value) =>
        new("contextUsage", value);

    /// <summary>
    /// Create a SubscribeEvent from a McpToolCall value.
    /// </summary>
    public static SubscribeEvent FromMcpToolCall(global::ElevenLabs.McpToolCall value) =>
        new("mcpToolCall", value);

    /// <summary>
    /// Create a SubscribeEvent from a ClientError value.
    /// </summary>
    public static SubscribeEvent FromClientError(global::ElevenLabs.ClientError value) =>
        new("clientError", value);

    /// <summary>
    /// Create a SubscribeEvent from a GuardrailTriggered value.
    /// </summary>
    public static SubscribeEvent FromGuardrailTriggered(
        global::ElevenLabs.GuardrailTriggered value
    ) => new("guardrailTriggered", value);

    /// <summary>
    /// Create a SubscribeEvent from a ConversationUserTranscript value.
    /// </summary>
    public static SubscribeEvent FromConversationUserTranscript(
        global::ElevenLabs.ConversationUserTranscript value
    ) => new("conversationUserTranscript", value);

    /// <summary>
    /// Create a SubscribeEvent from a ConversationAgentResponse value.
    /// </summary>
    public static SubscribeEvent FromConversationAgentResponse(
        global::ElevenLabs.ConversationAgentResponse value
    ) => new("conversationAgentResponse", value);

    /// <summary>
    /// Create a SubscribeEvent from a QueueStatus value.
    /// </summary>
    public static SubscribeEvent FromQueueStatus(global::ElevenLabs.QueueStatus value) =>
        new("queueStatus", value);

    /// <summary>
    /// Create a SubscribeEvent from a AgentResponseCorrection value.
    /// </summary>
    public static SubscribeEvent FromAgentResponseCorrection(
        global::ElevenLabs.AgentResponseCorrection value
    ) => new("agentResponseCorrection", value);

    /// <summary>
    /// Create a SubscribeEvent from a AgentResponseMetadata value.
    /// </summary>
    public static SubscribeEvent FromAgentResponseMetadata(
        global::ElevenLabs.AgentResponseMetadata value
    ) => new("agentResponseMetadata", value);

    /// <summary>
    /// Create a SubscribeEvent from a AudioResponse value.
    /// </summary>
    public static SubscribeEvent FromAudioResponse(global::ElevenLabs.AudioResponse value) =>
        new("audioResponse", value);

    /// <summary>
    /// Create a SubscribeEvent from a Interruption value.
    /// </summary>
    public static SubscribeEvent FromInterruption(global::ElevenLabs.Interruption value) =>
        new("interruption", value);

    /// <summary>
    /// Create a SubscribeEvent from a VadScore value.
    /// </summary>
    public static SubscribeEvent FromVadScore(global::ElevenLabs.VadScore value) =>
        new("vadScore", value);

    /// <summary>
    /// Create a SubscribeEvent from a AgentChatResponsePart value.
    /// </summary>
    public static SubscribeEvent FromAgentChatResponsePart(
        global::ElevenLabs.AgentChatResponsePart value
    ) => new("agentChatResponsePart", value);

    /// <summary>
    /// Create a SubscribeEvent from a ClientToolCall value.
    /// </summary>
    public static SubscribeEvent FromClientToolCall(global::ElevenLabs.ClientToolCall value) =>
        new("clientToolCall", value);

    /// <summary>
    /// Create a SubscribeEvent from a AgentToolResponse value.
    /// </summary>
    public static SubscribeEvent FromAgentToolResponse(
        global::ElevenLabs.AgentToolResponse value
    ) => new("agentToolResponse", value);

    /// <summary>
    /// Create a SubscribeEvent from a AgentToolResponseFullPayload value.
    /// </summary>
    public static SubscribeEvent FromAgentToolResponseFullPayload(
        global::ElevenLabs.AgentToolResponseFullPayload value
    ) => new("agentToolResponseFullPayload", value);

    /// <summary>
    /// Create a SubscribeEvent from a AgentToolRequest value.
    /// </summary>
    public static SubscribeEvent FromAgentToolRequest(global::ElevenLabs.AgentToolRequest value) =>
        new("agentToolRequest", value);

    /// <summary>
    /// Create a SubscribeEvent from a ConversationPing value.
    /// </summary>
    public static SubscribeEvent FromConversationPing(global::ElevenLabs.ConversationPing value) =>
        new("conversationPing", value);

    /// <summary>
    /// Create a SubscribeEvent from a McpConnectionStatus value.
    /// </summary>
    public static SubscribeEvent FromMcpConnectionStatus(
        global::ElevenLabs.McpConnectionStatus value
    ) => new("mcpConnectionStatus", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationInitiationMetadata".
    /// </summary>
    public bool IsConversationInitiationMetadata() => Type == "conversationInitiationMetadata";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentResponseComplete".
    /// </summary>
    public bool IsAgentResponseComplete() => Type == "agentResponseComplete";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "contextUsage".
    /// </summary>
    public bool IsContextUsage() => Type == "contextUsage";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "mcpToolCall".
    /// </summary>
    public bool IsMcpToolCall() => Type == "mcpToolCall";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "clientError".
    /// </summary>
    public bool IsClientError() => Type == "clientError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guardrailTriggered".
    /// </summary>
    public bool IsGuardrailTriggered() => Type == "guardrailTriggered";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationUserTranscript".
    /// </summary>
    public bool IsConversationUserTranscript() => Type == "conversationUserTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationAgentResponse".
    /// </summary>
    public bool IsConversationAgentResponse() => Type == "conversationAgentResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "queueStatus".
    /// </summary>
    public bool IsQueueStatus() => Type == "queueStatus";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentResponseCorrection".
    /// </summary>
    public bool IsAgentResponseCorrection() => Type == "agentResponseCorrection";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentResponseMetadata".
    /// </summary>
    public bool IsAgentResponseMetadata() => Type == "agentResponseMetadata";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "audioResponse".
    /// </summary>
    public bool IsAudioResponse() => Type == "audioResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "interruption".
    /// </summary>
    public bool IsInterruption() => Type == "interruption";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "vadScore".
    /// </summary>
    public bool IsVadScore() => Type == "vadScore";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentChatResponsePart".
    /// </summary>
    public bool IsAgentChatResponsePart() => Type == "agentChatResponsePart";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "clientToolCall".
    /// </summary>
    public bool IsClientToolCall() => Type == "clientToolCall";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentToolResponse".
    /// </summary>
    public bool IsAgentToolResponse() => Type == "agentToolResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentToolResponseFullPayload".
    /// </summary>
    public bool IsAgentToolResponseFullPayload() => Type == "agentToolResponseFullPayload";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentToolRequest".
    /// </summary>
    public bool IsAgentToolRequest() => Type == "agentToolRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationPing".
    /// </summary>
    public bool IsConversationPing() => Type == "conversationPing";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "mcpConnectionStatus".
    /// </summary>
    public bool IsMcpConnectionStatus() => Type == "mcpConnectionStatus";

    /// <summary>
    /// Returns the value as a ConversationInitiationMetadata if <see cref="Type"/> is "conversationInitiationMetadata", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationInitiationMetadata'.</exception>
    public global::ElevenLabs.ConversationInitiationMetadata AsConversationInitiationMetadata() =>
        IsConversationInitiationMetadata()
            ? (global::ElevenLabs.ConversationInitiationMetadata)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationInitiationMetadata'"
            );

    /// <summary>
    /// Returns the value as a AgentResponseComplete if <see cref="Type"/> is "agentResponseComplete", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'agentResponseComplete'.</exception>
    public global::ElevenLabs.AgentResponseComplete AsAgentResponseComplete() =>
        IsAgentResponseComplete()
            ? (global::ElevenLabs.AgentResponseComplete)Value!
            : throw new ElevenLabsClientException("Union type is not 'agentResponseComplete'");

    /// <summary>
    /// Returns the value as a ContextUsage if <see cref="Type"/> is "contextUsage", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'contextUsage'.</exception>
    public global::ElevenLabs.ContextUsage AsContextUsage() =>
        IsContextUsage()
            ? (global::ElevenLabs.ContextUsage)Value!
            : throw new ElevenLabsClientException("Union type is not 'contextUsage'");

    /// <summary>
    /// Returns the value as a McpToolCall if <see cref="Type"/> is "mcpToolCall", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'mcpToolCall'.</exception>
    public global::ElevenLabs.McpToolCall AsMcpToolCall() =>
        IsMcpToolCall()
            ? (global::ElevenLabs.McpToolCall)Value!
            : throw new ElevenLabsClientException("Union type is not 'mcpToolCall'");

    /// <summary>
    /// Returns the value as a ClientError if <see cref="Type"/> is "clientError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'clientError'.</exception>
    public global::ElevenLabs.ClientError AsClientError() =>
        IsClientError()
            ? (global::ElevenLabs.ClientError)Value!
            : throw new ElevenLabsClientException("Union type is not 'clientError'");

    /// <summary>
    /// Returns the value as a GuardrailTriggered if <see cref="Type"/> is "guardrailTriggered", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'guardrailTriggered'.</exception>
    public global::ElevenLabs.GuardrailTriggered AsGuardrailTriggered() =>
        IsGuardrailTriggered()
            ? (global::ElevenLabs.GuardrailTriggered)Value!
            : throw new ElevenLabsClientException("Union type is not 'guardrailTriggered'");

    /// <summary>
    /// Returns the value as a ConversationUserTranscript if <see cref="Type"/> is "conversationUserTranscript", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationUserTranscript'.</exception>
    public global::ElevenLabs.ConversationUserTranscript AsConversationUserTranscript() =>
        IsConversationUserTranscript()
            ? (global::ElevenLabs.ConversationUserTranscript)Value!
            : throw new ElevenLabsClientException("Union type is not 'conversationUserTranscript'");

    /// <summary>
    /// Returns the value as a ConversationAgentResponse if <see cref="Type"/> is "conversationAgentResponse", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationAgentResponse'.</exception>
    public global::ElevenLabs.ConversationAgentResponse AsConversationAgentResponse() =>
        IsConversationAgentResponse()
            ? (global::ElevenLabs.ConversationAgentResponse)Value!
            : throw new ElevenLabsClientException("Union type is not 'conversationAgentResponse'");

    /// <summary>
    /// Returns the value as a QueueStatus if <see cref="Type"/> is "queueStatus", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'queueStatus'.</exception>
    public global::ElevenLabs.QueueStatus AsQueueStatus() =>
        IsQueueStatus()
            ? (global::ElevenLabs.QueueStatus)Value!
            : throw new ElevenLabsClientException("Union type is not 'queueStatus'");

    /// <summary>
    /// Returns the value as a AgentResponseCorrection if <see cref="Type"/> is "agentResponseCorrection", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'agentResponseCorrection'.</exception>
    public global::ElevenLabs.AgentResponseCorrection AsAgentResponseCorrection() =>
        IsAgentResponseCorrection()
            ? (global::ElevenLabs.AgentResponseCorrection)Value!
            : throw new ElevenLabsClientException("Union type is not 'agentResponseCorrection'");

    /// <summary>
    /// Returns the value as a AgentResponseMetadata if <see cref="Type"/> is "agentResponseMetadata", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'agentResponseMetadata'.</exception>
    public global::ElevenLabs.AgentResponseMetadata AsAgentResponseMetadata() =>
        IsAgentResponseMetadata()
            ? (global::ElevenLabs.AgentResponseMetadata)Value!
            : throw new ElevenLabsClientException("Union type is not 'agentResponseMetadata'");

    /// <summary>
    /// Returns the value as a AudioResponse if <see cref="Type"/> is "audioResponse", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'audioResponse'.</exception>
    public global::ElevenLabs.AudioResponse AsAudioResponse() =>
        IsAudioResponse()
            ? (global::ElevenLabs.AudioResponse)Value!
            : throw new ElevenLabsClientException("Union type is not 'audioResponse'");

    /// <summary>
    /// Returns the value as a Interruption if <see cref="Type"/> is "interruption", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'interruption'.</exception>
    public global::ElevenLabs.Interruption AsInterruption() =>
        IsInterruption()
            ? (global::ElevenLabs.Interruption)Value!
            : throw new ElevenLabsClientException("Union type is not 'interruption'");

    /// <summary>
    /// Returns the value as a VadScore if <see cref="Type"/> is "vadScore", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'vadScore'.</exception>
    public global::ElevenLabs.VadScore AsVadScore() =>
        IsVadScore()
            ? (global::ElevenLabs.VadScore)Value!
            : throw new ElevenLabsClientException("Union type is not 'vadScore'");

    /// <summary>
    /// Returns the value as a AgentChatResponsePart if <see cref="Type"/> is "agentChatResponsePart", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'agentChatResponsePart'.</exception>
    public global::ElevenLabs.AgentChatResponsePart AsAgentChatResponsePart() =>
        IsAgentChatResponsePart()
            ? (global::ElevenLabs.AgentChatResponsePart)Value!
            : throw new ElevenLabsClientException("Union type is not 'agentChatResponsePart'");

    /// <summary>
    /// Returns the value as a ClientToolCall if <see cref="Type"/> is "clientToolCall", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'clientToolCall'.</exception>
    public global::ElevenLabs.ClientToolCall AsClientToolCall() =>
        IsClientToolCall()
            ? (global::ElevenLabs.ClientToolCall)Value!
            : throw new ElevenLabsClientException("Union type is not 'clientToolCall'");

    /// <summary>
    /// Returns the value as a AgentToolResponse if <see cref="Type"/> is "agentToolResponse", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'agentToolResponse'.</exception>
    public global::ElevenLabs.AgentToolResponse AsAgentToolResponse() =>
        IsAgentToolResponse()
            ? (global::ElevenLabs.AgentToolResponse)Value!
            : throw new ElevenLabsClientException("Union type is not 'agentToolResponse'");

    /// <summary>
    /// Returns the value as a AgentToolResponseFullPayload if <see cref="Type"/> is "agentToolResponseFullPayload", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'agentToolResponseFullPayload'.</exception>
    public global::ElevenLabs.AgentToolResponseFullPayload AsAgentToolResponseFullPayload() =>
        IsAgentToolResponseFullPayload()
            ? (global::ElevenLabs.AgentToolResponseFullPayload)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'agentToolResponseFullPayload'"
            );

    /// <summary>
    /// Returns the value as a AgentToolRequest if <see cref="Type"/> is "agentToolRequest", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'agentToolRequest'.</exception>
    public global::ElevenLabs.AgentToolRequest AsAgentToolRequest() =>
        IsAgentToolRequest()
            ? (global::ElevenLabs.AgentToolRequest)Value!
            : throw new ElevenLabsClientException("Union type is not 'agentToolRequest'");

    /// <summary>
    /// Returns the value as a ConversationPing if <see cref="Type"/> is "conversationPing", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationPing'.</exception>
    public global::ElevenLabs.ConversationPing AsConversationPing() =>
        IsConversationPing()
            ? (global::ElevenLabs.ConversationPing)Value!
            : throw new ElevenLabsClientException("Union type is not 'conversationPing'");

    /// <summary>
    /// Returns the value as a McpConnectionStatus if <see cref="Type"/> is "mcpConnectionStatus", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'mcpConnectionStatus'.</exception>
    public global::ElevenLabs.McpConnectionStatus AsMcpConnectionStatus() =>
        IsMcpConnectionStatus()
            ? (global::ElevenLabs.McpConnectionStatus)Value!
            : throw new ElevenLabsClientException("Union type is not 'mcpConnectionStatus'");

    /// <summary>
    /// Attempts to cast the value to a ConversationInitiationMetadata and returns true if successful.
    /// </summary>
    public bool TryGetConversationInitiationMetadata(
        out global::ElevenLabs.ConversationInitiationMetadata? value
    )
    {
        if (Type == "conversationInitiationMetadata")
        {
            value = (global::ElevenLabs.ConversationInitiationMetadata)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AgentResponseComplete and returns true if successful.
    /// </summary>
    public bool TryGetAgentResponseComplete(out global::ElevenLabs.AgentResponseComplete? value)
    {
        if (Type == "agentResponseComplete")
        {
            value = (global::ElevenLabs.AgentResponseComplete)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ContextUsage and returns true if successful.
    /// </summary>
    public bool TryGetContextUsage(out global::ElevenLabs.ContextUsage? value)
    {
        if (Type == "contextUsage")
        {
            value = (global::ElevenLabs.ContextUsage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a McpToolCall and returns true if successful.
    /// </summary>
    public bool TryGetMcpToolCall(out global::ElevenLabs.McpToolCall? value)
    {
        if (Type == "mcpToolCall")
        {
            value = (global::ElevenLabs.McpToolCall)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ClientError and returns true if successful.
    /// </summary>
    public bool TryGetClientError(out global::ElevenLabs.ClientError? value)
    {
        if (Type == "clientError")
        {
            value = (global::ElevenLabs.ClientError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a GuardrailTriggered and returns true if successful.
    /// </summary>
    public bool TryGetGuardrailTriggered(out global::ElevenLabs.GuardrailTriggered? value)
    {
        if (Type == "guardrailTriggered")
        {
            value = (global::ElevenLabs.GuardrailTriggered)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationUserTranscript and returns true if successful.
    /// </summary>
    public bool TryGetConversationUserTranscript(
        out global::ElevenLabs.ConversationUserTranscript? value
    )
    {
        if (Type == "conversationUserTranscript")
        {
            value = (global::ElevenLabs.ConversationUserTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationAgentResponse and returns true if successful.
    /// </summary>
    public bool TryGetConversationAgentResponse(
        out global::ElevenLabs.ConversationAgentResponse? value
    )
    {
        if (Type == "conversationAgentResponse")
        {
            value = (global::ElevenLabs.ConversationAgentResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a QueueStatus and returns true if successful.
    /// </summary>
    public bool TryGetQueueStatus(out global::ElevenLabs.QueueStatus? value)
    {
        if (Type == "queueStatus")
        {
            value = (global::ElevenLabs.QueueStatus)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AgentResponseCorrection and returns true if successful.
    /// </summary>
    public bool TryGetAgentResponseCorrection(out global::ElevenLabs.AgentResponseCorrection? value)
    {
        if (Type == "agentResponseCorrection")
        {
            value = (global::ElevenLabs.AgentResponseCorrection)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AgentResponseMetadata and returns true if successful.
    /// </summary>
    public bool TryGetAgentResponseMetadata(out global::ElevenLabs.AgentResponseMetadata? value)
    {
        if (Type == "agentResponseMetadata")
        {
            value = (global::ElevenLabs.AgentResponseMetadata)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AudioResponse and returns true if successful.
    /// </summary>
    public bool TryGetAudioResponse(out global::ElevenLabs.AudioResponse? value)
    {
        if (Type == "audioResponse")
        {
            value = (global::ElevenLabs.AudioResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Interruption and returns true if successful.
    /// </summary>
    public bool TryGetInterruption(out global::ElevenLabs.Interruption? value)
    {
        if (Type == "interruption")
        {
            value = (global::ElevenLabs.Interruption)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a VadScore and returns true if successful.
    /// </summary>
    public bool TryGetVadScore(out global::ElevenLabs.VadScore? value)
    {
        if (Type == "vadScore")
        {
            value = (global::ElevenLabs.VadScore)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AgentChatResponsePart and returns true if successful.
    /// </summary>
    public bool TryGetAgentChatResponsePart(out global::ElevenLabs.AgentChatResponsePart? value)
    {
        if (Type == "agentChatResponsePart")
        {
            value = (global::ElevenLabs.AgentChatResponsePart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ClientToolCall and returns true if successful.
    /// </summary>
    public bool TryGetClientToolCall(out global::ElevenLabs.ClientToolCall? value)
    {
        if (Type == "clientToolCall")
        {
            value = (global::ElevenLabs.ClientToolCall)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AgentToolResponse and returns true if successful.
    /// </summary>
    public bool TryGetAgentToolResponse(out global::ElevenLabs.AgentToolResponse? value)
    {
        if (Type == "agentToolResponse")
        {
            value = (global::ElevenLabs.AgentToolResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AgentToolResponseFullPayload and returns true if successful.
    /// </summary>
    public bool TryGetAgentToolResponseFullPayload(
        out global::ElevenLabs.AgentToolResponseFullPayload? value
    )
    {
        if (Type == "agentToolResponseFullPayload")
        {
            value = (global::ElevenLabs.AgentToolResponseFullPayload)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AgentToolRequest and returns true if successful.
    /// </summary>
    public bool TryGetAgentToolRequest(out global::ElevenLabs.AgentToolRequest? value)
    {
        if (Type == "agentToolRequest")
        {
            value = (global::ElevenLabs.AgentToolRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationPing and returns true if successful.
    /// </summary>
    public bool TryGetConversationPing(out global::ElevenLabs.ConversationPing? value)
    {
        if (Type == "conversationPing")
        {
            value = (global::ElevenLabs.ConversationPing)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a McpConnectionStatus and returns true if successful.
    /// </summary>
    public bool TryGetMcpConnectionStatus(out global::ElevenLabs.McpConnectionStatus? value)
    {
        if (Type == "mcpConnectionStatus")
        {
            value = (global::ElevenLabs.McpConnectionStatus)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.ConversationInitiationMetadata,
            T
        > onConversationInitiationMetadata,
        global::System.Func<global::ElevenLabs.AgentResponseComplete, T> onAgentResponseComplete,
        global::System.Func<global::ElevenLabs.ContextUsage, T> onContextUsage,
        global::System.Func<global::ElevenLabs.McpToolCall, T> onMcpToolCall,
        global::System.Func<global::ElevenLabs.ClientError, T> onClientError,
        global::System.Func<global::ElevenLabs.GuardrailTriggered, T> onGuardrailTriggered,
        global::System.Func<
            global::ElevenLabs.ConversationUserTranscript,
            T
        > onConversationUserTranscript,
        global::System.Func<
            global::ElevenLabs.ConversationAgentResponse,
            T
        > onConversationAgentResponse,
        global::System.Func<global::ElevenLabs.QueueStatus, T> onQueueStatus,
        global::System.Func<
            global::ElevenLabs.AgentResponseCorrection,
            T
        > onAgentResponseCorrection,
        global::System.Func<global::ElevenLabs.AgentResponseMetadata, T> onAgentResponseMetadata,
        global::System.Func<global::ElevenLabs.AudioResponse, T> onAudioResponse,
        global::System.Func<global::ElevenLabs.Interruption, T> onInterruption,
        global::System.Func<global::ElevenLabs.VadScore, T> onVadScore,
        global::System.Func<global::ElevenLabs.AgentChatResponsePart, T> onAgentChatResponsePart,
        global::System.Func<global::ElevenLabs.ClientToolCall, T> onClientToolCall,
        global::System.Func<global::ElevenLabs.AgentToolResponse, T> onAgentToolResponse,
        global::System.Func<
            global::ElevenLabs.AgentToolResponseFullPayload,
            T
        > onAgentToolResponseFullPayload,
        global::System.Func<global::ElevenLabs.AgentToolRequest, T> onAgentToolRequest,
        global::System.Func<global::ElevenLabs.ConversationPing, T> onConversationPing,
        global::System.Func<global::ElevenLabs.McpConnectionStatus, T> onMcpConnectionStatus
    )
    {
        return Type switch
        {
            "conversationInitiationMetadata" => onConversationInitiationMetadata(
                AsConversationInitiationMetadata()
            ),
            "agentResponseComplete" => onAgentResponseComplete(AsAgentResponseComplete()),
            "contextUsage" => onContextUsage(AsContextUsage()),
            "mcpToolCall" => onMcpToolCall(AsMcpToolCall()),
            "clientError" => onClientError(AsClientError()),
            "guardrailTriggered" => onGuardrailTriggered(AsGuardrailTriggered()),
            "conversationUserTranscript" => onConversationUserTranscript(
                AsConversationUserTranscript()
            ),
            "conversationAgentResponse" => onConversationAgentResponse(
                AsConversationAgentResponse()
            ),
            "queueStatus" => onQueueStatus(AsQueueStatus()),
            "agentResponseCorrection" => onAgentResponseCorrection(AsAgentResponseCorrection()),
            "agentResponseMetadata" => onAgentResponseMetadata(AsAgentResponseMetadata()),
            "audioResponse" => onAudioResponse(AsAudioResponse()),
            "interruption" => onInterruption(AsInterruption()),
            "vadScore" => onVadScore(AsVadScore()),
            "agentChatResponsePart" => onAgentChatResponsePart(AsAgentChatResponsePart()),
            "clientToolCall" => onClientToolCall(AsClientToolCall()),
            "agentToolResponse" => onAgentToolResponse(AsAgentToolResponse()),
            "agentToolResponseFullPayload" => onAgentToolResponseFullPayload(
                AsAgentToolResponseFullPayload()
            ),
            "agentToolRequest" => onAgentToolRequest(AsAgentToolRequest()),
            "conversationPing" => onConversationPing(AsConversationPing()),
            "mcpConnectionStatus" => onMcpConnectionStatus(AsMcpConnectionStatus()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ConversationInitiationMetadata> onConversationInitiationMetadata,
        global::System.Action<global::ElevenLabs.AgentResponseComplete> onAgentResponseComplete,
        global::System.Action<global::ElevenLabs.ContextUsage> onContextUsage,
        global::System.Action<global::ElevenLabs.McpToolCall> onMcpToolCall,
        global::System.Action<global::ElevenLabs.ClientError> onClientError,
        global::System.Action<global::ElevenLabs.GuardrailTriggered> onGuardrailTriggered,
        global::System.Action<global::ElevenLabs.ConversationUserTranscript> onConversationUserTranscript,
        global::System.Action<global::ElevenLabs.ConversationAgentResponse> onConversationAgentResponse,
        global::System.Action<global::ElevenLabs.QueueStatus> onQueueStatus,
        global::System.Action<global::ElevenLabs.AgentResponseCorrection> onAgentResponseCorrection,
        global::System.Action<global::ElevenLabs.AgentResponseMetadata> onAgentResponseMetadata,
        global::System.Action<global::ElevenLabs.AudioResponse> onAudioResponse,
        global::System.Action<global::ElevenLabs.Interruption> onInterruption,
        global::System.Action<global::ElevenLabs.VadScore> onVadScore,
        global::System.Action<global::ElevenLabs.AgentChatResponsePart> onAgentChatResponsePart,
        global::System.Action<global::ElevenLabs.ClientToolCall> onClientToolCall,
        global::System.Action<global::ElevenLabs.AgentToolResponse> onAgentToolResponse,
        global::System.Action<global::ElevenLabs.AgentToolResponseFullPayload> onAgentToolResponseFullPayload,
        global::System.Action<global::ElevenLabs.AgentToolRequest> onAgentToolRequest,
        global::System.Action<global::ElevenLabs.ConversationPing> onConversationPing,
        global::System.Action<global::ElevenLabs.McpConnectionStatus> onMcpConnectionStatus
    )
    {
        switch (Type)
        {
            case "conversationInitiationMetadata":
                onConversationInitiationMetadata(AsConversationInitiationMetadata());
                break;
            case "agentResponseComplete":
                onAgentResponseComplete(AsAgentResponseComplete());
                break;
            case "contextUsage":
                onContextUsage(AsContextUsage());
                break;
            case "mcpToolCall":
                onMcpToolCall(AsMcpToolCall());
                break;
            case "clientError":
                onClientError(AsClientError());
                break;
            case "guardrailTriggered":
                onGuardrailTriggered(AsGuardrailTriggered());
                break;
            case "conversationUserTranscript":
                onConversationUserTranscript(AsConversationUserTranscript());
                break;
            case "conversationAgentResponse":
                onConversationAgentResponse(AsConversationAgentResponse());
                break;
            case "queueStatus":
                onQueueStatus(AsQueueStatus());
                break;
            case "agentResponseCorrection":
                onAgentResponseCorrection(AsAgentResponseCorrection());
                break;
            case "agentResponseMetadata":
                onAgentResponseMetadata(AsAgentResponseMetadata());
                break;
            case "audioResponse":
                onAudioResponse(AsAudioResponse());
                break;
            case "interruption":
                onInterruption(AsInterruption());
                break;
            case "vadScore":
                onVadScore(AsVadScore());
                break;
            case "agentChatResponsePart":
                onAgentChatResponsePart(AsAgentChatResponsePart());
                break;
            case "clientToolCall":
                onClientToolCall(AsClientToolCall());
                break;
            case "agentToolResponse":
                onAgentToolResponse(AsAgentToolResponse());
                break;
            case "agentToolResponseFullPayload":
                onAgentToolResponseFullPayload(AsAgentToolResponseFullPayload());
                break;
            case "agentToolRequest":
                onAgentToolRequest(AsAgentToolRequest());
                break;
            case "conversationPing":
                onConversationPing(AsConversationPing());
                break;
            case "mcpConnectionStatus":
                onMcpConnectionStatus(AsMcpConnectionStatus());
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not SubscribeEvent other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.ConversationInitiationMetadata value
    ) => new("conversationInitiationMetadata", value);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.AgentResponseComplete value
    ) => new("agentResponseComplete", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.ContextUsage value) =>
        new("contextUsage", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.McpToolCall value) =>
        new("mcpToolCall", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.ClientError value) =>
        new("clientError", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.GuardrailTriggered value) =>
        new("guardrailTriggered", value);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.ConversationUserTranscript value
    ) => new("conversationUserTranscript", value);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.ConversationAgentResponse value
    ) => new("conversationAgentResponse", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.QueueStatus value) =>
        new("queueStatus", value);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.AgentResponseCorrection value
    ) => new("agentResponseCorrection", value);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.AgentResponseMetadata value
    ) => new("agentResponseMetadata", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.AudioResponse value) =>
        new("audioResponse", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.Interruption value) =>
        new("interruption", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.VadScore value) =>
        new("vadScore", value);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.AgentChatResponsePart value
    ) => new("agentChatResponsePart", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.ClientToolCall value) =>
        new("clientToolCall", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.AgentToolResponse value) =>
        new("agentToolResponse", value);

    public static implicit operator SubscribeEvent(
        global::ElevenLabs.AgentToolResponseFullPayload value
    ) => new("agentToolResponseFullPayload", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.AgentToolRequest value) =>
        new("agentToolRequest", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.ConversationPing value) =>
        new("conversationPing", value);

    public static implicit operator SubscribeEvent(global::ElevenLabs.McpConnectionStatus value) =>
        new("mcpConnectionStatus", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SubscribeEvent>
    {
        public override SubscribeEvent? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                // A payload carrying a member's literal decodes as that member or not at all.
                var matchedLiteral = false;

                if (HasLiteral(document, "type", "conversation_initiation_metadata"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationInitiationMetadata),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("conversationInitiationMetadata", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_response_complete"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AgentResponseComplete),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("agentResponseComplete", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "context_usage"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ContextUsage),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("contextUsage", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "mcp_tool_call"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.McpToolCall),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("mcpToolCall", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "client_error"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ClientError),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("clientError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "guardrail_triggered"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.GuardrailTriggered),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("guardrailTriggered", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "user_transcript"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationUserTranscript),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("conversationUserTranscript", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_response"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationAgentResponse),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("conversationAgentResponse", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "queue_status"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.QueueStatus),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("queueStatus", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_response_correction"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AgentResponseCorrection),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("agentResponseCorrection", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_response_metadata"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AgentResponseMetadata),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("agentResponseMetadata", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "audio"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AudioResponse),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("audioResponse", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "interruption"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.Interruption),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("interruption", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "vad_score"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.VadScore),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("vadScore", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_chat_response_part"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AgentChatResponsePart),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("agentChatResponsePart", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "client_tool_call"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ClientToolCall),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("clientToolCall", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_tool_response"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AgentToolResponse),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("agentToolResponse", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_tool_response_full_payload"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AgentToolResponseFullPayload),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("agentToolResponseFullPayload", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "agent_tool_request"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AgentToolRequest),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("agentToolRequest", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "ping"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationPing),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("conversationPing", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "mcp_connection_status"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.McpConnectionStatus),
                            options
                        );
                        if (value != null)
                        {
                            return new SubscribeEvent("mcpConnectionStatus", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (matchedLiteral)
                {
                    throw new JsonException(
                        "Cannot deserialize JSON object into SubscribeEvent: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "conversationInitiationMetadata",
                        typeof(global::ElevenLabs.ConversationInitiationMetadata)
                    ),
                    ("agentResponseComplete", typeof(global::ElevenLabs.AgentResponseComplete)),
                    ("contextUsage", typeof(global::ElevenLabs.ContextUsage)),
                    ("mcpToolCall", typeof(global::ElevenLabs.McpToolCall)),
                    ("clientError", typeof(global::ElevenLabs.ClientError)),
                    ("guardrailTriggered", typeof(global::ElevenLabs.GuardrailTriggered)),
                    (
                        "conversationUserTranscript",
                        typeof(global::ElevenLabs.ConversationUserTranscript)
                    ),
                    (
                        "conversationAgentResponse",
                        typeof(global::ElevenLabs.ConversationAgentResponse)
                    ),
                    ("queueStatus", typeof(global::ElevenLabs.QueueStatus)),
                    ("agentResponseCorrection", typeof(global::ElevenLabs.AgentResponseCorrection)),
                    ("agentResponseMetadata", typeof(global::ElevenLabs.AgentResponseMetadata)),
                    ("audioResponse", typeof(global::ElevenLabs.AudioResponse)),
                    ("interruption", typeof(global::ElevenLabs.Interruption)),
                    ("vadScore", typeof(global::ElevenLabs.VadScore)),
                    ("agentChatResponsePart", typeof(global::ElevenLabs.AgentChatResponsePart)),
                    ("clientToolCall", typeof(global::ElevenLabs.ClientToolCall)),
                    ("agentToolResponse", typeof(global::ElevenLabs.AgentToolResponse)),
                    (
                        "agentToolResponseFullPayload",
                        typeof(global::ElevenLabs.AgentToolResponseFullPayload)
                    ),
                    ("agentToolRequest", typeof(global::ElevenLabs.AgentToolRequest)),
                    ("conversationPing", typeof(global::ElevenLabs.ConversationPing)),
                    ("mcpConnectionStatus", typeof(global::ElevenLabs.McpConnectionStatus)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new SubscribeEvent(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into SubscribeEvent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubscribeEvent value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override SubscribeEvent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            SubscribeEvent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubscribeEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }

        private static bool HasLiteral(JsonDocument document, string key, string expected)
        {
            if (!document.RootElement.TryGetProperty(key, out var property))
            {
                return false;
            }

            return property.ValueKind == JsonValueKind.String && property.GetString() == expected;
        }
    }
}
