// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PublishEvent.JsonConverter))]
[Serializable]
public class PublishEvent
{
    private PublishEvent(string type, object? value)
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
    /// Create a PublishEvent from a UserAudioChunk value.
    /// </summary>
    public static PublishEvent FromUserAudioChunk(global::ElevenLabs.UserAudioChunk value) =>
        new("userAudioChunk", value);

    /// <summary>
    /// Create a PublishEvent from a Feedback value.
    /// </summary>
    public static PublishEvent FromFeedback(global::ElevenLabs.Feedback value) =>
        new("feedback", value);

    /// <summary>
    /// Create a PublishEvent from a UserMessage value.
    /// </summary>
    public static PublishEvent FromUserMessage(global::ElevenLabs.UserMessage value) =>
        new("userMessage", value);

    /// <summary>
    /// Create a PublishEvent from a UserActivity value.
    /// </summary>
    public static PublishEvent FromUserActivity(global::ElevenLabs.UserActivity value) =>
        new("userActivity", value);

    /// <summary>
    /// Create a PublishEvent from a MultimodalMessage value.
    /// </summary>
    public static PublishEvent FromMultimodalMessage(global::ElevenLabs.MultimodalMessage value) =>
        new("multimodalMessage", value);

    /// <summary>
    /// Create a PublishEvent from a ConversationPong value.
    /// </summary>
    public static PublishEvent FromConversationPong(global::ElevenLabs.ConversationPong value) =>
        new("conversationPong", value);

    /// <summary>
    /// Create a PublishEvent from a ClientToolResult value.
    /// </summary>
    public static PublishEvent FromClientToolResult(global::ElevenLabs.ClientToolResult value) =>
        new("clientToolResult", value);

    /// <summary>
    /// Create a PublishEvent from a McpToolApprovalResult value.
    /// </summary>
    public static PublishEvent FromMcpToolApprovalResult(
        global::ElevenLabs.McpToolApprovalResult value
    ) => new("mcpToolApprovalResult", value);

    /// <summary>
    /// Create a PublishEvent from a ContextualUpdate value.
    /// </summary>
    public static PublishEvent FromContextualUpdate(global::ElevenLabs.ContextualUpdate value) =>
        new("contextualUpdate", value);

    /// <summary>
    /// Create a PublishEvent from a ConversationInitiationClientData value.
    /// </summary>
    public static PublishEvent FromConversationInitiationClientData(
        global::ElevenLabs.ConversationInitiationClientData value
    ) => new("conversationInitiationClientData", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "userAudioChunk".
    /// </summary>
    public bool IsUserAudioChunk() => Type == "userAudioChunk";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "feedback".
    /// </summary>
    public bool IsFeedback() => Type == "feedback";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "userMessage".
    /// </summary>
    public bool IsUserMessage() => Type == "userMessage";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "userActivity".
    /// </summary>
    public bool IsUserActivity() => Type == "userActivity";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "multimodalMessage".
    /// </summary>
    public bool IsMultimodalMessage() => Type == "multimodalMessage";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationPong".
    /// </summary>
    public bool IsConversationPong() => Type == "conversationPong";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "clientToolResult".
    /// </summary>
    public bool IsClientToolResult() => Type == "clientToolResult";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "mcpToolApprovalResult".
    /// </summary>
    public bool IsMcpToolApprovalResult() => Type == "mcpToolApprovalResult";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "contextualUpdate".
    /// </summary>
    public bool IsContextualUpdate() => Type == "contextualUpdate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationInitiationClientData".
    /// </summary>
    public bool IsConversationInitiationClientData() => Type == "conversationInitiationClientData";

    /// <summary>
    /// Returns the value as a UserAudioChunk if <see cref="Type"/> is "userAudioChunk", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'userAudioChunk'.</exception>
    public global::ElevenLabs.UserAudioChunk AsUserAudioChunk() =>
        IsUserAudioChunk()
            ? (global::ElevenLabs.UserAudioChunk)Value!
            : throw new ElevenLabsClientException("Union type is not 'userAudioChunk'");

    /// <summary>
    /// Returns the value as a Feedback if <see cref="Type"/> is "feedback", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'feedback'.</exception>
    public global::ElevenLabs.Feedback AsFeedback() =>
        IsFeedback()
            ? (global::ElevenLabs.Feedback)Value!
            : throw new ElevenLabsClientException("Union type is not 'feedback'");

    /// <summary>
    /// Returns the value as a UserMessage if <see cref="Type"/> is "userMessage", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'userMessage'.</exception>
    public global::ElevenLabs.UserMessage AsUserMessage() =>
        IsUserMessage()
            ? (global::ElevenLabs.UserMessage)Value!
            : throw new ElevenLabsClientException("Union type is not 'userMessage'");

    /// <summary>
    /// Returns the value as a UserActivity if <see cref="Type"/> is "userActivity", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'userActivity'.</exception>
    public global::ElevenLabs.UserActivity AsUserActivity() =>
        IsUserActivity()
            ? (global::ElevenLabs.UserActivity)Value!
            : throw new ElevenLabsClientException("Union type is not 'userActivity'");

    /// <summary>
    /// Returns the value as a MultimodalMessage if <see cref="Type"/> is "multimodalMessage", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'multimodalMessage'.</exception>
    public global::ElevenLabs.MultimodalMessage AsMultimodalMessage() =>
        IsMultimodalMessage()
            ? (global::ElevenLabs.MultimodalMessage)Value!
            : throw new ElevenLabsClientException("Union type is not 'multimodalMessage'");

    /// <summary>
    /// Returns the value as a ConversationPong if <see cref="Type"/> is "conversationPong", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationPong'.</exception>
    public global::ElevenLabs.ConversationPong AsConversationPong() =>
        IsConversationPong()
            ? (global::ElevenLabs.ConversationPong)Value!
            : throw new ElevenLabsClientException("Union type is not 'conversationPong'");

    /// <summary>
    /// Returns the value as a ClientToolResult if <see cref="Type"/> is "clientToolResult", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'clientToolResult'.</exception>
    public global::ElevenLabs.ClientToolResult AsClientToolResult() =>
        IsClientToolResult()
            ? (global::ElevenLabs.ClientToolResult)Value!
            : throw new ElevenLabsClientException("Union type is not 'clientToolResult'");

    /// <summary>
    /// Returns the value as a McpToolApprovalResult if <see cref="Type"/> is "mcpToolApprovalResult", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'mcpToolApprovalResult'.</exception>
    public global::ElevenLabs.McpToolApprovalResult AsMcpToolApprovalResult() =>
        IsMcpToolApprovalResult()
            ? (global::ElevenLabs.McpToolApprovalResult)Value!
            : throw new ElevenLabsClientException("Union type is not 'mcpToolApprovalResult'");

    /// <summary>
    /// Returns the value as a ContextualUpdate if <see cref="Type"/> is "contextualUpdate", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'contextualUpdate'.</exception>
    public global::ElevenLabs.ContextualUpdate AsContextualUpdate() =>
        IsContextualUpdate()
            ? (global::ElevenLabs.ContextualUpdate)Value!
            : throw new ElevenLabsClientException("Union type is not 'contextualUpdate'");

    /// <summary>
    /// Returns the value as a ConversationInitiationClientData if <see cref="Type"/> is "conversationInitiationClientData", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationInitiationClientData'.</exception>
    public global::ElevenLabs.ConversationInitiationClientData AsConversationInitiationClientData() =>
        IsConversationInitiationClientData()
            ? (global::ElevenLabs.ConversationInitiationClientData)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationInitiationClientData'"
            );

    /// <summary>
    /// Attempts to cast the value to a UserAudioChunk and returns true if successful.
    /// </summary>
    public bool TryGetUserAudioChunk(out global::ElevenLabs.UserAudioChunk? value)
    {
        if (Type == "userAudioChunk")
        {
            value = (global::ElevenLabs.UserAudioChunk)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Feedback and returns true if successful.
    /// </summary>
    public bool TryGetFeedback(out global::ElevenLabs.Feedback? value)
    {
        if (Type == "feedback")
        {
            value = (global::ElevenLabs.Feedback)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a UserMessage and returns true if successful.
    /// </summary>
    public bool TryGetUserMessage(out global::ElevenLabs.UserMessage? value)
    {
        if (Type == "userMessage")
        {
            value = (global::ElevenLabs.UserMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a UserActivity and returns true if successful.
    /// </summary>
    public bool TryGetUserActivity(out global::ElevenLabs.UserActivity? value)
    {
        if (Type == "userActivity")
        {
            value = (global::ElevenLabs.UserActivity)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a MultimodalMessage and returns true if successful.
    /// </summary>
    public bool TryGetMultimodalMessage(out global::ElevenLabs.MultimodalMessage? value)
    {
        if (Type == "multimodalMessage")
        {
            value = (global::ElevenLabs.MultimodalMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationPong and returns true if successful.
    /// </summary>
    public bool TryGetConversationPong(out global::ElevenLabs.ConversationPong? value)
    {
        if (Type == "conversationPong")
        {
            value = (global::ElevenLabs.ConversationPong)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ClientToolResult and returns true if successful.
    /// </summary>
    public bool TryGetClientToolResult(out global::ElevenLabs.ClientToolResult? value)
    {
        if (Type == "clientToolResult")
        {
            value = (global::ElevenLabs.ClientToolResult)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a McpToolApprovalResult and returns true if successful.
    /// </summary>
    public bool TryGetMcpToolApprovalResult(out global::ElevenLabs.McpToolApprovalResult? value)
    {
        if (Type == "mcpToolApprovalResult")
        {
            value = (global::ElevenLabs.McpToolApprovalResult)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ContextualUpdate and returns true if successful.
    /// </summary>
    public bool TryGetContextualUpdate(out global::ElevenLabs.ContextualUpdate? value)
    {
        if (Type == "contextualUpdate")
        {
            value = (global::ElevenLabs.ContextualUpdate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationInitiationClientData and returns true if successful.
    /// </summary>
    public bool TryGetConversationInitiationClientData(
        out global::ElevenLabs.ConversationInitiationClientData? value
    )
    {
        if (Type == "conversationInitiationClientData")
        {
            value = (global::ElevenLabs.ConversationInitiationClientData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.UserAudioChunk, T> onUserAudioChunk,
        global::System.Func<global::ElevenLabs.Feedback, T> onFeedback,
        global::System.Func<global::ElevenLabs.UserMessage, T> onUserMessage,
        global::System.Func<global::ElevenLabs.UserActivity, T> onUserActivity,
        global::System.Func<global::ElevenLabs.MultimodalMessage, T> onMultimodalMessage,
        global::System.Func<global::ElevenLabs.ConversationPong, T> onConversationPong,
        global::System.Func<global::ElevenLabs.ClientToolResult, T> onClientToolResult,
        global::System.Func<global::ElevenLabs.McpToolApprovalResult, T> onMcpToolApprovalResult,
        global::System.Func<global::ElevenLabs.ContextualUpdate, T> onContextualUpdate,
        global::System.Func<
            global::ElevenLabs.ConversationInitiationClientData,
            T
        > onConversationInitiationClientData
    )
    {
        return Type switch
        {
            "userAudioChunk" => onUserAudioChunk(AsUserAudioChunk()),
            "feedback" => onFeedback(AsFeedback()),
            "userMessage" => onUserMessage(AsUserMessage()),
            "userActivity" => onUserActivity(AsUserActivity()),
            "multimodalMessage" => onMultimodalMessage(AsMultimodalMessage()),
            "conversationPong" => onConversationPong(AsConversationPong()),
            "clientToolResult" => onClientToolResult(AsClientToolResult()),
            "mcpToolApprovalResult" => onMcpToolApprovalResult(AsMcpToolApprovalResult()),
            "contextualUpdate" => onContextualUpdate(AsContextualUpdate()),
            "conversationInitiationClientData" => onConversationInitiationClientData(
                AsConversationInitiationClientData()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.UserAudioChunk> onUserAudioChunk,
        global::System.Action<global::ElevenLabs.Feedback> onFeedback,
        global::System.Action<global::ElevenLabs.UserMessage> onUserMessage,
        global::System.Action<global::ElevenLabs.UserActivity> onUserActivity,
        global::System.Action<global::ElevenLabs.MultimodalMessage> onMultimodalMessage,
        global::System.Action<global::ElevenLabs.ConversationPong> onConversationPong,
        global::System.Action<global::ElevenLabs.ClientToolResult> onClientToolResult,
        global::System.Action<global::ElevenLabs.McpToolApprovalResult> onMcpToolApprovalResult,
        global::System.Action<global::ElevenLabs.ContextualUpdate> onContextualUpdate,
        global::System.Action<global::ElevenLabs.ConversationInitiationClientData> onConversationInitiationClientData
    )
    {
        switch (Type)
        {
            case "userAudioChunk":
                onUserAudioChunk(AsUserAudioChunk());
                break;
            case "feedback":
                onFeedback(AsFeedback());
                break;
            case "userMessage":
                onUserMessage(AsUserMessage());
                break;
            case "userActivity":
                onUserActivity(AsUserActivity());
                break;
            case "multimodalMessage":
                onMultimodalMessage(AsMultimodalMessage());
                break;
            case "conversationPong":
                onConversationPong(AsConversationPong());
                break;
            case "clientToolResult":
                onClientToolResult(AsClientToolResult());
                break;
            case "mcpToolApprovalResult":
                onMcpToolApprovalResult(AsMcpToolApprovalResult());
                break;
            case "contextualUpdate":
                onContextualUpdate(AsContextualUpdate());
                break;
            case "conversationInitiationClientData":
                onConversationInitiationClientData(AsConversationInitiationClientData());
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
        if (obj is not PublishEvent other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PublishEvent(global::ElevenLabs.UserAudioChunk value) =>
        new("userAudioChunk", value);

    public static implicit operator PublishEvent(global::ElevenLabs.Feedback value) =>
        new("feedback", value);

    public static implicit operator PublishEvent(global::ElevenLabs.UserMessage value) =>
        new("userMessage", value);

    public static implicit operator PublishEvent(global::ElevenLabs.UserActivity value) =>
        new("userActivity", value);

    public static implicit operator PublishEvent(global::ElevenLabs.MultimodalMessage value) =>
        new("multimodalMessage", value);

    public static implicit operator PublishEvent(global::ElevenLabs.ConversationPong value) =>
        new("conversationPong", value);

    public static implicit operator PublishEvent(global::ElevenLabs.ClientToolResult value) =>
        new("clientToolResult", value);

    public static implicit operator PublishEvent(global::ElevenLabs.McpToolApprovalResult value) =>
        new("mcpToolApprovalResult", value);

    public static implicit operator PublishEvent(global::ElevenLabs.ContextualUpdate value) =>
        new("contextualUpdate", value);

    public static implicit operator PublishEvent(
        global::ElevenLabs.ConversationInitiationClientData value
    ) => new("conversationInitiationClientData", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PublishEvent>
    {
        public override PublishEvent? Read(
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

                if (HasLiteral(document, "type", "feedback"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.Feedback),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("feedback", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "user_message"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.UserMessage),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("userMessage", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "user_activity"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.UserActivity),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("userActivity", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "multimodal_message"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.MultimodalMessage),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("multimodalMessage", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "pong"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationPong),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("conversationPong", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "client_tool_result"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ClientToolResult),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("clientToolResult", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "mcp_tool_approval_result"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.McpToolApprovalResult),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("mcpToolApprovalResult", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "contextual_update"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ContextualUpdate),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("contextualUpdate", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "conversation_initiation_client_data"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationInitiationClientData),
                            options
                        );
                        if (value != null)
                        {
                            return new PublishEvent("conversationInitiationClientData", value);
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
                        "Cannot deserialize JSON object into PublishEvent: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "userAudioChunk",
                        typeof(global::ElevenLabs.UserAudioChunk),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "feedback",
                        typeof(global::ElevenLabs.Feedback),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "userMessage",
                        typeof(global::ElevenLabs.UserMessage),
                        new[] { "id", "type", "text", "user_identifier", "source_medium" }
                    ),
                    ("userActivity", typeof(global::ElevenLabs.UserActivity), new[] { "type" }),
                    (
                        "multimodalMessage",
                        typeof(global::ElevenLabs.MultimodalMessage),
                        new[] { "type", "text", "file", "files" }
                    ),
                    (
                        "conversationPong",
                        typeof(global::ElevenLabs.ConversationPong),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "clientToolResult",
                        typeof(global::ElevenLabs.ClientToolResult),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "mcpToolApprovalResult",
                        typeof(global::ElevenLabs.McpToolApprovalResult),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "contextualUpdate",
                        typeof(global::ElevenLabs.ContextualUpdate),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "conversationInitiationClientData",
                        typeof(global::ElevenLabs.ConversationInitiationClientData),
                        new[]
                        {
                            "conversation_config_override",
                            "custom_llm_extra_body",
                            "user_id",
                            "source_info",
                            "branch_id",
                            "environment",
                            "starting_workflow_node_id",
                            "procedure_ids",
                            "start_procedure_ids",
                            "dynamic_variables",
                            "type",
                        }
                    ),
                };

                foreach (var (key, type, anyOfKeys) in types)
                {
                    // A member whose properties are all optional deserializes from any object, so it
                    // only gets a turn when the payload carries one of its own keys.
                    if (anyOfKeys.Length > 0 && !HasAnyProperty(document, anyOfKeys))
                    {
                        continue;
                    }

                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new PublishEvent(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into PublishEvent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PublishEvent value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override PublishEvent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            PublishEvent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PublishEvent value,
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

        private static bool HasAnyProperty(JsonDocument document, string[] keys)
        {
            foreach (var key in keys)
            {
                if (document.RootElement.TryGetProperty(key, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
