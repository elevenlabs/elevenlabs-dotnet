using ElevenLabs;
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

namespace ElevenLabs.ServiceAccounts;

[Serializable]
public record BodyEditServiceAccountApiKeyV1ServiceAccountsServiceAccountUserIdApiKeysApiKeyIdPatch
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Whether to enable or disable the API key.</value>
    [JsonPropertyName("is_enabled")]
    public OneOf<bool, IsEnabled2>? IsEnabled { get; set; }

    /// <value>The name of the XI API key to use (used for identification purposes only).</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>The permissions of the XI API.</value>
    [JsonPropertyName("permissions")]
    public OneOf<IEnumerable<PermissionType>, Permissions22>? Permissions { get; set; }

    /// <value>The character limit of the XI API key. If provided this will limit the usage of this api key to n characters per month where n is the chosen value. Requests that incur charges will fail after reaching this monthly limit.</value>
    [JsonPropertyName("character_limit")]
    public OneOf<int, CharacterLimit2>? CharacterLimit { get; set; }

    /// <value>List of IP addresses or CIDR ranges allowed to use this API key. Each entry may be a CIDR range (e.g. '10.0.0.0/24') or a bare IP address (normalized to /32 or /128). On create, omit or pass null to allow all IPs. On update, omit to leave the allowlist unchanged, or pass "clear" to remove it.</value>
    [JsonPropertyName("allowed_ips")]
    public OneOf<IEnumerable<string>, AllowedIps2>? AllowedIps { get; set; }

    /// <value>Whether the holder of this key may disable it via the self-disable endpoint. On create, omit or pass null to use the workspace's default (enabled for non-Enterprise plans, disabled for Enterprise plans). On update, omit to leave it unchanged, or pass "clear" to reset it to the workspace default. Only honored for workspaces with self-disable access enabled.</value>
    [JsonPropertyName("third_party_disable_allowed")]
    public OneOf<bool, ThirdPartyDisableAllowed2>? ThirdPartyDisableAllowed { get; set; }

    /// <value>Maximum concurrent text-to-speech/speech-to-speech requests for this API key. Only available for enterprise customers.</value>
    [JsonPropertyName("tts_concurrency_limit")]
    public OneOf<int, TtsConcurrencyLimit2>? TtsConcurrencyLimit { get; set; }

    /// <value>Maximum concurrent dubbing requests for this API key. Only available for enterprise customers.</value>
    [JsonPropertyName("dubbing_concurrency_limit")]
    public OneOf<int, DubbingConcurrencyLimit2>? DubbingConcurrencyLimit { get; set; }

    /// <value>Maximum concurrent music generation requests for this API key. Only available for enterprise customers.</value>
    [JsonPropertyName("music_concurrency_limit")]
    public OneOf<int, MusicConcurrencyLimit2>? MusicConcurrencyLimit { get; set; }

    /// <value>Unix timestamp (in seconds) after which this API key stops working. When set, it must be at least 15 minutes and at most 90 days in the future. On create, omit or pass null for a key that never expires. On update, omit to leave it unchanged, or pass "clear" to remove the expiry (never expires). A workspace may disallow never-expiring keys, or allow them only on service account API keys; creating one or clearing an expiry then fails.</value>
    [JsonPropertyName("expires_at_unix")]
    public OneOf<int, ExpiresAtUnix2>? ExpiresAtUnix { get; set; }

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
    public virtual bool Equals(
        BodyEditServiceAccountApiKeyV1ServiceAccountsServiceAccountUserIdApiKeysApiKeyIdPatch? other
    )
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
            && ValueEquality.AreEqual(IsEnabled, other.IsEnabled)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Permissions, other.Permissions)
            && ValueEquality.AreEqual(CharacterLimit, other.CharacterLimit)
            && ValueEquality.AreEqual(AllowedIps, other.AllowedIps)
            && ValueEquality.AreEqual(ThirdPartyDisableAllowed, other.ThirdPartyDisableAllowed)
            && ValueEquality.AreEqual(TtsConcurrencyLimit, other.TtsConcurrencyLimit)
            && ValueEquality.AreEqual(DubbingConcurrencyLimit, other.DubbingConcurrencyLimit)
            && ValueEquality.AreEqual(MusicConcurrencyLimit, other.MusicConcurrencyLimit)
            && ValueEquality.AreEqual(ExpiresAtUnix, other.ExpiresAtUnix)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Permissions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AllowedIps);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ThirdPartyDisableAllowed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TtsConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DubbingConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MusicConcurrencyLimit);
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
