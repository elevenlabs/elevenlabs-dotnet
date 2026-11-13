using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.SpeechEngine;
using ElevenLabs.Studio;
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ElevenLabs;

[Serializable]
public record McpServerConfigInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Defines the MCP server-level approval policy for tool execution.</value>
    [JsonPropertyName("approval_policy")]
    public McpApprovalPolicy? ApprovalPolicy { get; set; }

    /// <value>List of tool approval hashes for per-tool approval when approval_policy is REQUIRE_APPROVAL_PER_TOOL</value>
    [JsonPropertyName("tool_approval_hashes")]
    public IEnumerable<McpToolApprovalHash>? ToolApprovalHashes { get; set; }

    /// <value>Supported MCP server transport types.</value>
    [JsonPropertyName("transport")]
    public McpServerTransport? Transport { get; set; }

    /// <value>The URL of the MCP server, if this contains a secret please store as a workspace secret, otherwise store as a plain string. Must use https</value>
    [JsonPropertyName("url")]
    public required OneOf<string, ConvAiSecretLocator> Url { get; set; }

    /// <value>The secret token (Authorization header) stored as a workspace secret or in-place secret</value>
    [JsonPropertyName("secret_token")]
    public McpServerConfigInputSecretToken? SecretToken { get; set; }

    /// <value>The headers included in the request</value>
    [JsonPropertyName("request_headers")]
    public Dictionary<
        string,
        OneOf<string, ConvAiSecretLocator, ConvAiDynamicVariable, ConvAiEnvVarLocator>
    >? RequestHeaders { get; set; }

    /// <value>Entries sent in the MCP `_meta` field of tools/call requests. Values may be JSON scalars, or references to a workspace secret, dynamic variable, or environment variable resolved per call.</value>
    [JsonPropertyName("request_meta")]
    public Dictionary<
        string,
        OneOf<
            string,
            int,
            double,
            bool,
            ConvAiSecretLocator,
            ConvAiDynamicVariable,
            ConvAiEnvVarLocator
        >
    >? RequestMeta { get; set; }

    /// <value>Optional auth connection to use for authentication with this MCP server</value>
    [JsonPropertyName("auth_connection")]
    public McpServerConfigInputAuthConnection? AuthConnection { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>DEPRECATED: use `pre_tool_speech` instead. If true, all tools from this MCP server will require pre-tool execution speech.</value>
    [JsonPropertyName("force_pre_tool_speech")]
    public bool? ForcePreToolSpeech { get; set; }

    [JsonPropertyName("pre_tool_speech")]
    public PreToolSpeechMode? PreToolSpeech { get; set; }

    /// <value>DEPRECATED: use `interruption_mode` instead. If true, the user will not be able to interrupt the agent while any tool from this MCP server is running.</value>
    [JsonPropertyName("disable_interruptions")]
    public bool? DisableInterruptions { get; set; }

    [JsonPropertyName("interruption_mode")]
    public ToolInterruptionMode? InterruptionMode { get; set; }

    /// <value>Predefined tool call sound type to play during tool execution for all tools from this MCP server</value>
    [JsonPropertyName("tool_call_sound")]
    public ToolCallSoundType? ToolCallSound { get; set; }

    /// <value>Determines how the tool call sound should be played.</value>
    [JsonPropertyName("tool_call_sound_behavior")]
    public ToolCallSoundBehavior? ToolCallSoundBehavior { get; set; }

    [JsonPropertyName("execution_mode")]
    public ToolExecutionMode? ExecutionMode { get; set; }

    /// <value>The maximum time in seconds to wait for each MCP tool call to complete. Must be between 5 and 300 seconds (inclusive).</value>
    [JsonPropertyName("response_timeout_secs")]
    public int? ResponseTimeoutSecs { get; set; }

    /// <value>List of per-tool configuration overrides that override the server-level defaults for specific tools</value>
    [JsonPropertyName("tool_config_overrides")]
    public IEnumerable<McpToolConfigOverrideInput>? ToolConfigOverrides { get; set; }

    /// <value>Whether to disable HTTP compression for this MCP server. Enable this if the server does not support compressed responses.</value>
    [JsonPropertyName("disable_compression")]
    public bool? DisableCompression { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    /// <remarks>
    /// Written out rather than synthesized. A record's generated Equals compares every instance
    /// field, and `_extensionData` is a fresh Dictionary per instance compared by REFERENCE, so two
    /// identical models were never equal — silently defeating ==, Distinct(), HashSet membership,
    /// dictionary keys and test assertions for every model in the SDK. Excluding it loses nothing:
    /// it is a transient deserialization sink whose contents are copied into
    /// AdditionalProperties, which IS compared here.
    /// </remarks>
    public virtual bool Equals(McpServerConfigInput? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // The synthesized record Equals compares EqualityContract, so a base instance never equals a
        // derived one. Hand-writing Equals drops that unless it is restated.
        if (EqualityContract != other.EqualityContract)
        {
            return false;
        }
        // Declared properties first: the additional-properties comparison walks a dictionary and
        // allocates a string per entry, and is the least likely of the three to differ, so letting
        // the cheap scalar comparisons short-circuit ahead of it matters for Distinct/HashSet over
        // large collections. Anchored on `true` so a model with no declared properties still emits
        // a valid expression.
        return true
            && ValueEquality.AreEqual(ApprovalPolicy, other.ApprovalPolicy)
            && ValueEquality.AreEqual(ToolApprovalHashes, other.ToolApprovalHashes)
            && ValueEquality.AreEqual(Transport, other.Transport)
            && ValueEquality.AreEqual(Url, other.Url)
            && ValueEquality.AreEqual(SecretToken, other.SecretToken)
            && ValueEquality.AreEqual(RequestHeaders, other.RequestHeaders)
            && ValueEquality.AreEqual(RequestMeta, other.RequestMeta)
            && ValueEquality.AreEqual(AuthConnection, other.AuthConnection)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(ForcePreToolSpeech, other.ForcePreToolSpeech)
            && ValueEquality.AreEqual(PreToolSpeech, other.PreToolSpeech)
            && ValueEquality.AreEqual(DisableInterruptions, other.DisableInterruptions)
            && ValueEquality.AreEqual(InterruptionMode, other.InterruptionMode)
            && ValueEquality.AreEqual(ToolCallSound, other.ToolCallSound)
            && ValueEquality.AreEqual(ToolCallSoundBehavior, other.ToolCallSoundBehavior)
            && ValueEquality.AreEqual(ExecutionMode, other.ExecutionMode)
            && ValueEquality.AreEqual(ResponseTimeoutSecs, other.ResponseTimeoutSecs)
            && ValueEquality.AreEqual(ToolConfigOverrides, other.ToolConfigOverrides)
            && ValueEquality.AreEqual(DisableCompression, other.DisableCompression)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApprovalPolicy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolApprovalHashes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Transport);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Url);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SecretToken);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestHeaders);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestMeta);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthConnection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ForcePreToolSpeech);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreToolSpeech);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableInterruptions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InterruptionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallSound);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallSoundBehavior);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExecutionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseTimeoutSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolConfigOverrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableCompression);
            hash = (hash * 31) + AdditionalProperties.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
