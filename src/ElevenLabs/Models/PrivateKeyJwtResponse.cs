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

/// <summary>Response model for Private Key JWT auth connections</summary>
[Serializable]
public record PrivateKeyJwtResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("auth_type")]
    public PrivateKeyJwtResponseAuthType? AuthType { get; set; }

    [JsonPropertyName("provider")]
    public required string Provider { get; set; }

    /// <value>JWT signing algorithm</value>
    [JsonPropertyName("algorithm")]
    public PrivateKeyJwtResponseAlgorithm? Algorithm { get; set; }

    /// <value>Key ID (kid) for JWT header - useful for key rotation</value>
    [JsonPropertyName("key_id")]
    public string? KeyId { get; set; }

    /// <value>JWT issuer (iss claim)</value>
    [JsonPropertyName("issuer")]
    public required string Issuer { get; set; }

    /// <value>JWT audience (aud claim)</value>
    [JsonPropertyName("audience")]
    public required string Audience { get; set; }

    /// <value>JWT subject (sub claim)</value>
    [JsonPropertyName("subject")]
    public required string Subject { get; set; }

    /// <value>Token expiration time in seconds</value>
    [JsonPropertyName("expiration_seconds")]
    public int? ExpirationSeconds { get; set; }

    /// <value>Additional custom claims to include in the JWT</value>
    [JsonPropertyName("extra_params")]
    public Dictionary<string, string>? ExtraParams { get; set; }

    /// <value>Additional JWT header parameters (e.g. x5t). 'alg' and 'kid' are set from algorithm and key_id.</value>
    [JsonPropertyName("extra_headers")]
    public Dictionary<string, string>? ExtraHeaders { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("used_by")]
    public AuthConnectionDependencies? UsedBy { get; set; }

    /// <value>
    /// Single status field shared by every auth type's stored credential.
    ///
    /// OAuth values (``REFRESH_FAILED``, ``REVOKED``) are written by the OAuth
    /// token-manager refresh path. ``CREDENTIAL_INVALID`` is written by the
    /// tool execution path when an upstream response matches a credential's
    /// ``failure_signatures`` entry (Bearer, Basic auth, etc.).
    /// </value>
    [JsonPropertyName("status")]
    public AuthConnectionStatus? Status { get; set; }

    [JsonPropertyName("status_detail")]
    public string? StatusDetail { get; set; }

    [JsonPropertyName("status_updated_at")]
    public string? StatusUpdatedAt { get; set; }

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
    public virtual bool Equals(PrivateKeyJwtResponse? other)
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
            && ValueEquality.AreEqual(AuthType, other.AuthType)
            && ValueEquality.AreEqual(Provider, other.Provider)
            && ValueEquality.AreEqual(Algorithm, other.Algorithm)
            && ValueEquality.AreEqual(KeyId, other.KeyId)
            && ValueEquality.AreEqual(Issuer, other.Issuer)
            && ValueEquality.AreEqual(Audience, other.Audience)
            && ValueEquality.AreEqual(Subject, other.Subject)
            && ValueEquality.AreEqual(ExpirationSeconds, other.ExpirationSeconds)
            && ValueEquality.AreEqual(ExtraParams, other.ExtraParams)
            && ValueEquality.AreEqual(ExtraHeaders, other.ExtraHeaders)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(UsedBy, other.UsedBy)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(StatusDetail, other.StatusDetail)
            && ValueEquality.AreEqual(StatusUpdatedAt, other.StatusUpdatedAt)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Provider);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Algorithm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(KeyId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Issuer);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Audience);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Subject);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExpirationSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExtraParams);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExtraHeaders);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UsedBy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StatusDetail);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StatusUpdatedAt);
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
