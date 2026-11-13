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

/// <summary>Response model for oauth2 client creds</summary>
[Serializable]
public record OAuth2ClientCredsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("auth_type")]
    public OAuth2ClientCredsResponseAuthType? AuthType { get; set; }

    [JsonPropertyName("provider")]
    public required string Provider { get; set; }

    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [JsonPropertyName("token_url")]
    public required string TokenUrl { get; set; }

    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    [JsonPropertyName("extra_params")]
    public Dictionary<string, string>? ExtraParams { get; set; }

    /// <value>If True, send client credentials in Authorization header as Basic Auth instead of request body</value>
    [JsonPropertyName("basic_auth_in_header")]
    public bool? BasicAuthInHeader { get; set; }

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

    /// <value>Custom headers configured for OAuth2 token requests</value>
    [JsonPropertyName("custom_headers")]
    public Dictionary<string, string>? CustomHeaders { get; set; }

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
    public virtual bool Equals(OAuth2ClientCredsResponse? other)
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
            && ValueEquality.AreEqual(ClientId, other.ClientId)
            && ValueEquality.AreEqual(TokenUrl, other.TokenUrl)
            && ValueEquality.AreEqual(Scopes, other.Scopes)
            && ValueEquality.AreEqual(ExtraParams, other.ExtraParams)
            && ValueEquality.AreEqual(BasicAuthInHeader, other.BasicAuthInHeader)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(UsedBy, other.UsedBy)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(StatusDetail, other.StatusDetail)
            && ValueEquality.AreEqual(StatusUpdatedAt, other.StatusUpdatedAt)
            && ValueEquality.AreEqual(CustomHeaders, other.CustomHeaders)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ClientId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TokenUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Scopes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExtraParams);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BasicAuthInHeader);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UsedBy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StatusDetail);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StatusUpdatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomHeaders);
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
