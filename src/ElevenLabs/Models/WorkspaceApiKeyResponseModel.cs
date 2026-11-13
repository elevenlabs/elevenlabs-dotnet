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
public record WorkspaceApiKeyResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("hint")]
    public required string Hint { get; set; }

    [JsonPropertyName("key_id")]
    public required string KeyId { get; set; }

    [JsonPropertyName("service_account_user_id")]
    public required string ServiceAccountUserId { get; set; }

    [JsonPropertyName("created_at_unix")]
    public int? CreatedAtUnix { get; set; }

    [JsonPropertyName("is_disabled")]
    public bool? IsDisabled { get; set; }

    [JsonPropertyName("permissions")]
    public IEnumerable<PermissionType>? Permissions { get; set; }

    [JsonPropertyName("disable_reason")]
    public LockReason? DisableReason { get; set; }

    /// <value>Maximum number of credits allowed in the current billing period.</value>
    [JsonPropertyName("character_limit")]
    public int? CharacterLimit { get; set; }

    /// <value>Credits already used in the current billing period.</value>
    [JsonPropertyName("character_count")]
    public int? CharacterCount { get; set; }

    [JsonPropertyName("hashed_xi_api_key")]
    public required string HashedXiApiKey { get; set; }

    [JsonPropertyName("allowed_ips")]
    public IEnumerable<string>? AllowedIps { get; set; }

    [JsonPropertyName("third_party_disable_allowed")]
    public bool? ThirdPartyDisableAllowed { get; set; }

    /// <value>Per-API-key concurrency limits (TTS/dubbing/music). Enterprise-only.</value>
    [JsonPropertyName("platform_limits")]
    public PlatformLimits? PlatformLimits { get; set; }

    /// <value>Unix timestamp (seconds) after which this API key stops working. Null means the key never expires.</value>
    [JsonPropertyName("expires_at_unix")]
    public int? ExpiresAtUnix { get; set; }

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
    public virtual bool Equals(WorkspaceApiKeyResponseModel? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Hint, other.Hint)
            && ValueEquality.AreEqual(KeyId, other.KeyId)
            && ValueEquality.AreEqual(ServiceAccountUserId, other.ServiceAccountUserId)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(IsDisabled, other.IsDisabled)
            && ValueEquality.AreEqual(Permissions, other.Permissions)
            && ValueEquality.AreEqual(DisableReason, other.DisableReason)
            && ValueEquality.AreEqual(CharacterLimit, other.CharacterLimit)
            && ValueEquality.AreEqual(CharacterCount, other.CharacterCount)
            && ValueEquality.AreEqual(HashedXiApiKey, other.HashedXiApiKey)
            && ValueEquality.AreEqual(AllowedIps, other.AllowedIps)
            && ValueEquality.AreEqual(ThirdPartyDisableAllowed, other.ThirdPartyDisableAllowed)
            && ValueEquality.AreEqual(PlatformLimits, other.PlatformLimits)
            && ValueEquality.AreEqual(ExpiresAtUnix, other.ExpiresAtUnix)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Hint);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(KeyId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ServiceAccountUserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsDisabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Permissions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HashedXiApiKey);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AllowedIps);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ThirdPartyDisableAllowed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformLimits);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExpiresAtUnix);
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
