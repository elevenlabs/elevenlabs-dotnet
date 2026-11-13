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
public record WorkflowPhoneNumberNodeModelOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Custom SIP headers to include when transferring the call. Each header can be either a static value or a dynamic variable reference.</value>
    [JsonPropertyName("custom_sip_headers")]
    public IEnumerable<WorkflowPhoneNumberNodeModelOutputCustomSipHeadersItem> CustomSipHeaders { get; set; } =
        new List<WorkflowPhoneNumberNodeModelOutputCustomSipHeadersItem>();

    [JsonPropertyName("transfer_destination")]
    public required WorkflowPhoneNumberNodeModelOutputTransferDestination TransferDestination { get; set; }

    [JsonPropertyName("transfer_type")]
    public required TransferTypeEnum TransferType { get; set; }

    /// <value>When True, a ringing tone is played on the original call leg while a SIP REFER transfer completes. The tone is carried over RTP to the SIP peer executing the REFER, so disable this if the receiving system (e.g. an SBC or contact center) should not hear it. When disabled the caller hears silence until the transfer completes. SIP REFER transfers only.</value>
    [JsonPropertyName("sip_refer_play_dialtone")]
    public required bool SipReferPlayDialtone { get; set; }

    /// <value>User-to-User Information (RFC 7433) to attach to SIP REFER transfers. Carries call context such as CRM identifiers or escalation reason across the transfer boundary.</value>
    [JsonPropertyName("uui")]
    public UuiTransferConfig? Uui { get; set; }

    /// <value>DTMF digits to send after call connects (e.g., 'ww1234' for extension). Can be either a static value or a dynamic variable reference. Use 'w' for 0.5s pause. Only supported for Twilio transfers.</value>
    [JsonPropertyName("post_dial_digits")]
    public WorkflowPhoneNumberNodeModelOutputPostDialDigits? PostDialDigits { get; set; }

    [JsonPropertyName("type")]
    public required WorkflowPhoneNumberNodeModelOutputType Type { get; set; }

    [JsonPropertyName("position")]
    public required PositionOutput Position { get; set; }

    /// <value>The ids of outgoing edges in the order they should be evaluated.</value>
    [JsonPropertyName("edge_order")]
    public IEnumerable<string> EdgeOrder { get; set; } = new List<string>();

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
    public virtual bool Equals(WorkflowPhoneNumberNodeModelOutput? other)
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
            && ValueEquality.AreEqual(CustomSipHeaders, other.CustomSipHeaders)
            && ValueEquality.AreEqual(TransferDestination, other.TransferDestination)
            && ValueEquality.AreEqual(TransferType, other.TransferType)
            && ValueEquality.AreEqual(SipReferPlayDialtone, other.SipReferPlayDialtone)
            && ValueEquality.AreEqual(Uui, other.Uui)
            && ValueEquality.AreEqual(PostDialDigits, other.PostDialDigits)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(Position, other.Position)
            && ValueEquality.AreEqual(EdgeOrder, other.EdgeOrder)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomSipHeaders);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TransferDestination);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TransferType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SipReferPlayDialtone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Uui);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PostDialDigits);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Position);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EdgeOrder);
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
