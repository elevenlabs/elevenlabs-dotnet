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
public record UpdateOAuth2JwtRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("auth_type")]
    public UpdateOAuth2JwtRequestAuthType? AuthType { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    [JsonPropertyName("algorithm")]
    public UpdateOAuth2JwtRequestAlgorithm? Algorithm { get; set; }

    [JsonPropertyName("key_id")]
    public string? KeyId { get; set; }

    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("expiration_seconds")]
    public int? ExpirationSeconds { get; set; }

    [JsonPropertyName("extra_params")]
    public Dictionary<string, string>? ExtraParams { get; set; }

    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    [JsonPropertyName("token_response_field")]
    public UpdateOAuth2JwtRequestTokenResponseField? TokenResponseField { get; set; }

    [JsonPropertyName("jwt_usage")]
    public UpdateOAuth2JwtRequestJwtUsage? JwtUsage { get; set; }

    [JsonPropertyName("extra_headers")]
    public Dictionary<string, string>? ExtraHeaders { get; set; }

    [JsonPropertyName("secret_key")]
    public string? SecretKey { get; set; }

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
    public virtual bool Equals(UpdateOAuth2JwtRequest? other)
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
            && ValueEquality.AreEqual(AuthType, other.AuthType)
            && ValueEquality.AreEqual(Provider, other.Provider)
            && ValueEquality.AreEqual(Algorithm, other.Algorithm)
            && ValueEquality.AreEqual(KeyId, other.KeyId)
            && ValueEquality.AreEqual(Issuer, other.Issuer)
            && ValueEquality.AreEqual(Audience, other.Audience)
            && ValueEquality.AreEqual(Subject, other.Subject)
            && ValueEquality.AreEqual(ExpirationSeconds, other.ExpirationSeconds)
            && ValueEquality.AreEqual(ExtraParams, other.ExtraParams)
            && ValueEquality.AreEqual(Scopes, other.Scopes)
            && ValueEquality.AreEqual(TokenResponseField, other.TokenResponseField)
            && ValueEquality.AreEqual(JwtUsage, other.JwtUsage)
            && ValueEquality.AreEqual(ExtraHeaders, other.ExtraHeaders)
            && ValueEquality.AreEqual(SecretKey, other.SecretKey)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Provider);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Algorithm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(KeyId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Issuer);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Audience);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Subject);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExpirationSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExtraParams);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Scopes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TokenResponseField);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(JwtUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExtraHeaders);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SecretKey);
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
