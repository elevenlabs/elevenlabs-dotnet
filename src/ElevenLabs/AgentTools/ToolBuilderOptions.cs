using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentTools;

// Option names are the canonical names from the cross-SDK spec, in PascalCase. As in the workflow builder, enum
// values are taken as their wire strings and nested values (placeholders, response filter, SIP headers, ...) in API
// wire format as JsonNode, so the builder stays decoupled from the generated request types.

/// <summary>Options every kind of tool accepts. Pass a <see cref="WebhookToolOptions"/> or <see cref="ClientToolOptions"/> for the kind-specific ones.</summary>
public class CommonToolOptions
{
    /// <summary>What the LLM calls the tool by.</summary>
    public string? Name { get; set; }

    /// <summary>When the tool should be used and what it does.</summary>
    public string? Description { get; set; }

    /// <summary>Seconds to wait for the tool to finish: 5–300 for a webhook tool; 1–120, or -1 with <c>ExpectsResponse</c>, for a client tool.</summary>
    public int? ResponseTimeoutSecs { get; set; }

    /// <summary>Wire value, e.g. <c>"allow"</c>.</summary>
    public string? InterruptionMode { get; set; }

    /// <summary>Wire value, e.g. <c>"auto"</c> or <c>"force"</c>.</summary>
    public string? PreToolSpeech { get; set; }

    /// <summary>Wire value, e.g. <c>"typing"</c>.</summary>
    public string? ToolCallSound { get; set; }

    /// <summary>Wire value, e.g. <c>"auto"</c>.</summary>
    public string? ToolCallSoundBehavior { get; set; }

    /// <summary>Wire value.</summary>
    public string? ToolErrorHandlingMode { get; set; }
}

/// <summary>Options for a webhook tool.</summary>
public sealed class WebhookToolOptions : CommonToolOptions
{
    /// <summary>Placeholder values for the dynamic variables the tool uses (wire format, e.g. <c>{ "user_id": "u_1" }</c>).</summary>
    public JsonNode? DynamicVariablePlaceholders { get; set; }

    /// <summary>Wire value, e.g. <c>"post_tool_speech"</c>.</summary>
    public string? ExecutionMode { get; set; }

    /// <summary><c>api_schema.content_type</c>, e.g. <c>"application/json"</c>.</summary>
    public string? ContentType { get; set; }

    /// <summary><c>api_schema.response_filter</c> (wire format, e.g. <c>{ "mode": "allow", "filters": ["order.id"] }</c>).</summary>
    public JsonNode? ResponseFilter { get; set; }

    /// <summary>Follow HTTP redirects. Needs <see cref="FollowRedirectsAllowedDomains"/>.</summary>
    public bool? FollowRedirects { get; set; }

    /// <summary>The domains redirects may go to.</summary>
    public IReadOnlyList<string>? FollowRedirectsAllowedDomains { get; set; }
}

/// <summary>Options for a client tool.</summary>
public sealed class ClientToolOptions : CommonToolOptions
{
    /// <summary>Placeholder values for the dynamic variables the tool uses (wire format).</summary>
    public JsonNode? DynamicVariablePlaceholders { get; set; }

    /// <summary>Wire value, e.g. <c>"post_tool_speech"</c>.</summary>
    public string? ExecutionMode { get; set; }

    /// <summary>Wait for the client to respond, and pass its response to the LLM.</summary>
    public bool? ExpectsResponse { get; set; }
}

/// <summary>Options for <see cref="WebhookTool.Assign"/>.</summary>
public sealed class AssignOptions
{
    /// <summary>Remove the value from the tool response before the LLM and the transcript see it.</summary>
    public bool? Sanitize { get; set; }

    /// <summary>Store lists and objects as they are instead of as JSON strings.</summary>
    public bool? PreserveNativeType { get; set; }
}

/// <summary>
/// Options for one <see cref="SystemTool.Transfer"/> entry, named as the workflow builder's
/// <c>TransferOptions</c>. The first group applies to <c>TransferToNumber()</c>, the second to <c>TransferToAgent()</c>.
/// </summary>
public sealed class SystemTransferOptions
{
    /// <summary>Wire value: <c>"conference"</c> (the API default), <c>"sip_refer"</c> (needed for a SIP URI), ...</summary>
    public string? TransferType { get; set; }

    /// <summary>Wire format.</summary>
    public JsonNode? CustomSipHeaders { get; set; }
    public bool? SipReferPlayDialtone { get; set; }

    /// <summary>Wire format.</summary>
    public JsonNode? Uui { get; set; }

    /// <summary>Wire format.</summary>
    public JsonNode? PostDialDigits { get; set; }
    public int? DelayMs { get; set; }
    public string? TransferMessage { get; set; }
    public bool? EnableTransferredAgentFirstMessage { get; set; }
    public bool? PreserveClientTtsOverrides { get; set; }
    public bool? PreserveVoiceSettings { get; set; }
}

/// <summary>Params for <see cref="SystemTool.SkipTurn"/>.</summary>
public sealed class SkipTurnOptions
{
    /// <summary>Seconds to wait before the agent checks in. -1 waits for the user.</summary>
    public double? WaitTimeoutSecs { get; set; }
}

/// <summary>Params for <see cref="SystemTool.LanguageDetection"/>.</summary>
public sealed class LanguageDetectionOptions
{
    /// <summary>Only switch language during the first two user turns.</summary>
    public bool? OnlyAtConversationStart { get; set; }
}

/// <summary>Params for <see cref="SystemTool.PlayKeypadTouchTone"/>.</summary>
public sealed class PlayKeypadTouchToneOptions
{
    /// <summary>Send tones as RTP events instead of in-band audio. SIP trunk numbers only.</summary>
    public bool? UseOutOfBandDtmf { get; set; }

    /// <summary>Don't speak after playing tones, so speech doesn't confuse an IVR.</summary>
    public bool? SuppressTurnAfterDtmf { get; set; }
}

/// <summary>Params for <see cref="SystemTool.VoicemailDetection"/>.</summary>
public sealed class VoicemailDetectionOptions
{
    /// <summary>Message to leave on voicemail. Without one, the call ends.</summary>
    public string? VoicemailMessage { get; set; }
}

/// <summary>Params for <see cref="SystemTool.KnowledgeBase"/>.</summary>
public sealed class KnowledgeBaseToolOptions
{
    /// <summary>Wire values, e.g. <c>"keyword"</c>, <c>"semantic"</c>.</summary>
    public IReadOnlyList<string>? EnabledStrategies { get; set; }
}

/// <summary>Params for <see cref="SystemTool.TransferToNumber"/>.</summary>
public sealed class TransferToNumberOptions
{
    /// <summary>Play a message to the caller while they wait for the transfer.</summary>
    public bool? EnableClientMessage { get; set; }
}
