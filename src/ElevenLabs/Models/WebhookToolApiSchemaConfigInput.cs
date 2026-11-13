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
public record WebhookToolApiSchemaConfigInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Headers that should be included in the request</value>
    [JsonPropertyName("request_headers")]
    public Dictionary<
        string,
        OneOf<string, ConvAiSecretLocator, ConvAiDynamicVariable, ConvAiEnvVarLocator>
    >? RequestHeaders { get; set; }

    /// <value>The URL that the webhook will be sent to. May include path parameters, e.g. https://example.com/agents/{agent_id}</value>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <value>The HTTP method to use for the webhook</value>
    [JsonPropertyName("method")]
    public WebhookToolApiSchemaConfigInputMethod? Method { get; set; }

    /// <value>Schema for path parameters, if any. The keys should match the placeholders in the URL.</value>
    [JsonPropertyName("path_params_schema")]
    public Dictionary<string, LiteralJsonSchemaProperty>? PathParamsSchema { get; set; }

    /// <value>Schema for any query params, if any. These will be added to end of the URL as query params. Note: properties in a query param must all be literal types</value>
    [JsonPropertyName("query_params_schema")]
    public QueryParamsJsonSchemaInput? QueryParamsSchema { get; set; }

    /// <value>Schema for the body parameters, if any. Used for POST/PATCH/PUT requests. The schema should be an object which will be sent as the json body</value>
    [JsonPropertyName("request_body_schema")]
    public ObjectJsonSchemaPropertyInput? RequestBodySchema { get; set; }

    /// <value>Schema describing the expected response body structure. For documentation only; not surfaced to the LLM.</value>
    [JsonPropertyName("response_body_schema")]
    public ObjectJsonSchemaPropertyInput? ResponseBodySchema { get; set; }

    /// <value>Optional allow-list filter applied to the response before the LLM sees it, so large responses don't pollute the context. Defaults to the full response.</value>
    [JsonPropertyName("response_filter")]
    public ResponseFilter? ResponseFilter { get; set; }

    /// <value>Content type for the request body. Only applies to POST/PUT/PATCH requests.</value>
    [JsonPropertyName("content_type")]
    public WebhookToolApiSchemaConfigInputContentType? ContentType { get; set; }

    /// <value>URL placeholders resolved from the auth connection (e.g. secrets injected via UrlSecretAuthConnection) rather than from path_params_schema.</value>
    [JsonPropertyName("auth_resolved_params")]
    public IEnumerable<string>? AuthResolvedParams { get; set; }

    /// <value>Optional auth connection to use for authentication with this webhook</value>
    [JsonPropertyName("auth_connection")]
    public WebhookToolApiSchemaConfigInputAuthConnection? AuthConnection { get; set; }

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
    public virtual bool Equals(WebhookToolApiSchemaConfigInput? other)
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
            && ValueEquality.AreEqual(RequestHeaders, other.RequestHeaders)
            && ValueEquality.AreEqual(Url, other.Url)
            && ValueEquality.AreEqual(Method, other.Method)
            && ValueEquality.AreEqual(PathParamsSchema, other.PathParamsSchema)
            && ValueEquality.AreEqual(QueryParamsSchema, other.QueryParamsSchema)
            && ValueEquality.AreEqual(RequestBodySchema, other.RequestBodySchema)
            && ValueEquality.AreEqual(ResponseBodySchema, other.ResponseBodySchema)
            && ValueEquality.AreEqual(ResponseFilter, other.ResponseFilter)
            && ValueEquality.AreEqual(ContentType, other.ContentType)
            && ValueEquality.AreEqual(AuthResolvedParams, other.AuthResolvedParams)
            && ValueEquality.AreEqual(AuthConnection, other.AuthConnection)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestHeaders);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Url);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Method);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PathParamsSchema);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QueryParamsSchema);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestBodySchema);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseBodySchema);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseFilter);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthResolvedParams);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthConnection);
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
