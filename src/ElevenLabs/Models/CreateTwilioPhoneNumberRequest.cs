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

namespace ElevenLabs;

[Serializable]
public record CreateTwilioPhoneNumberRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Phone number</value>
    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; set; }

    /// <value>Label for the phone number</value>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <value>This field is deprecated and will be removed in the future. Whether this phone number supports inbound calls</value>
    [JsonPropertyName("supports_inbound")]
    public bool? SupportsInbound { get; set; }

    /// <value>This field is deprecated and will be removed in the future. Whether this phone number supports outbound calls</value>
    [JsonPropertyName("supports_outbound")]
    public bool? SupportsOutbound { get; set; }

    [JsonPropertyName("provider")]
    public CreateTwilioPhoneNumberRequestProvider? Provider { get; set; }

    /// <value>Agent ID to assign the phone number to</value>
    [JsonPropertyName("agent_id")]
    public string? AgentId { get; set; }

    /// <value>Twilio Account SID (starts with `AC`) or API Key SID (starts with `SK`)</value>
    [JsonPropertyName("sid")]
    public required string Sid { get; set; }

    /// <value>Secret paired with `sid`: the Account Auth Token for an Account SID, or the API Key Secret for an API Key SID</value>
    [JsonPropertyName("token")]
    public required string Token { get; set; }

    /// <value>Twilio Account Auth Token, required for API Key imports to validate inbound webhook signatures</value>
    [JsonPropertyName("account_auth_token")]
    public string? AccountAuthToken { get; set; }

    /// <value>Twilio Additional Region Configuration</value>
    [JsonPropertyName("region_config")]
    public RegionConfigRequest? RegionConfig { get; set; }

    /// <value>Route inbound SMS to ElevenLabs. On by default; set to false to skip SMS configuration for numbers that don't support it.</value>
    [JsonPropertyName("enable_sms")]
    public bool? EnableSms { get; set; }

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
    public virtual bool Equals(CreateTwilioPhoneNumberRequest? other)
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
            && ValueEquality.AreEqual(PhoneNumber, other.PhoneNumber)
            && ValueEquality.AreEqual(Label, other.Label)
            && ValueEquality.AreEqual(SupportsInbound, other.SupportsInbound)
            && ValueEquality.AreEqual(SupportsOutbound, other.SupportsOutbound)
            && ValueEquality.AreEqual(Provider, other.Provider)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(Sid, other.Sid)
            && ValueEquality.AreEqual(Token, other.Token)
            && ValueEquality.AreEqual(AccountAuthToken, other.AccountAuthToken)
            && ValueEquality.AreEqual(RegionConfig, other.RegionConfig)
            && ValueEquality.AreEqual(EnableSms, other.EnableSms)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Label);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportsInbound);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportsOutbound);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Provider);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Sid);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Token);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccountAuthToken);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RegionConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableSms);
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
