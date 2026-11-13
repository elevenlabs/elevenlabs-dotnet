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
public record OutboundSipTrunkConfigRequestModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Hostname or IP the SIP INVITE is sent to.</value>
    [JsonPropertyName("address")]
    public required string Address { get; set; }

    [JsonPropertyName("transport")]
    public SipTrunkTransportEnum? Transport { get; set; }

    [JsonPropertyName("media_encryption")]
    public SipMediaEncryptionEnum? MediaEncryption { get; set; }

    /// <value>SIP X-* headers for INVITE request. These headers are sent as-is and may help identify this call.</value>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <value>Map of dynamic variable name to header name for attributes_to_headers</value>
    [JsonPropertyName("attributes_to_headers")]
    public Dictionary<string, string>? AttributesToHeaders { get; set; }

    /// <value>Optional digest authentication credentials (username/password). If not provided, ACL authentication is assumed.</value>
    [JsonPropertyName("credentials")]
    public SipTrunkCredentialsRequestModel? Credentials { get; set; }

    /// <value>Media codecs that should be offered in the SDP for outbound calls. If empty, all supported codecs are offered.</value>
    [JsonPropertyName("enabled_codecs")]
    public IEnumerable<MediaCodec>? EnabledCodecs { get; set; }

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
    public virtual bool Equals(OutboundSipTrunkConfigRequestModel? other)
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
            && ValueEquality.AreEqual(Address, other.Address)
            && ValueEquality.AreEqual(Transport, other.Transport)
            && ValueEquality.AreEqual(MediaEncryption, other.MediaEncryption)
            && ValueEquality.AreEqual(Headers, other.Headers)
            && ValueEquality.AreEqual(AttributesToHeaders, other.AttributesToHeaders)
            && ValueEquality.AreEqual(Credentials, other.Credentials)
            && ValueEquality.AreEqual(EnabledCodecs, other.EnabledCodecs)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Address);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Transport);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MediaEncryption);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Headers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AttributesToHeaders);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Credentials);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnabledCodecs);
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
