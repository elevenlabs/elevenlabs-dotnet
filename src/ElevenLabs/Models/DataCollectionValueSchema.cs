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

/// <summary>Schema property for literal JSON types. IMPORTANT: Only ONE of the following fields can be set: description (LLM provides value), dynamic_variable (value from variable), is_system_provided (system provides value), constant_value (fixed value), or is_omitted (parameter is omitted). These are mutually exclusive.</summary>
[Serializable]
public record DataCollectionValueSchema : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public required OneOf<Type13, IEnumerable<string>> Type { get; set; }

    /// <value>The description of the property. When set, the LLM will provide the value based on this description. Mutually exclusive with dynamic_variable, is_system_provided, constant_value, and is_omitted.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>List of allowed string values for string type parameters</value>
    [JsonPropertyName("enum")]
    public IEnumerable<string>? Enum { get; set; }

    /// <value>If true, the value will be populated by the system at runtime. Used by API Integration Webhook tools for templating. Mutually exclusive with description, dynamic_variable, constant_value, and is_omitted.</value>
    [JsonPropertyName("is_system_provided")]
    public bool? IsSystemProvided { get; set; }

    /// <value>The name of the dynamic variable to use for this property's value. Mutually exclusive with description, is_system_provided, constant_value, and is_omitted.</value>
    [JsonPropertyName("dynamic_variable")]
    public string? DynamicVariable { get; set; }

    /// <value>Server-side rejection guard for an LLM-provided value: the runtime rejects any value outside the permitted set this object names, and the set is not advertised to the LLM as an enum. Only supported when the value source is `description`; combining it with dynamic_variable, is_system_provided, constant_value, or is_omitted is rejected.</value>
    [JsonPropertyName("allowed_values")]
    public AllowedValues? AllowedValues { get; set; }

    /// <value>DEPRECATED: use `allowed_values` instead. When set, the LLM provides the value but the runtime rejects any value not present in the list held by this dynamic variable (must be a JSON array such as ["ws_alpha", "ws_beta"]). Use to let the LLM pick from a server-verified set (e.g. the IDs the current user is allowed to access). Requires description; mutually exclusive with dynamic_variable, is_system_provided, constant_value, and is_omitted.</value>
    [JsonPropertyName("allowed_values_dynamic_variable")]
    public string? AllowedValuesDynamicVariable { get; set; }

    /// <value>A constant value to use for this property. Mutually exclusive with description, dynamic_variable, is_system_provided, and is_omitted.</value>
    [JsonPropertyName("constant_value")]
    public OneOf<string, int, double, bool>? ConstantValue { get; set; }

    /// <value>If true, this parameter will be completely omitted from the request. Only valid for optional parameters. Mutually exclusive with description, dynamic_variable, is_system_provided, and constant_value.</value>
    [JsonPropertyName("is_omitted")]
    public bool? IsOmitted { get; set; }

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
    public virtual bool Equals(DataCollectionValueSchema? other)
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
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(Enum, other.Enum)
            && ValueEquality.AreEqual(IsSystemProvided, other.IsSystemProvided)
            && ValueEquality.AreEqual(DynamicVariable, other.DynamicVariable)
            && ValueEquality.AreEqual(AllowedValues, other.AllowedValues)
            && ValueEquality.AreEqual(
                AllowedValuesDynamicVariable,
                other.AllowedValuesDynamicVariable
            )
            && ValueEquality.AreEqual(ConstantValue, other.ConstantValue)
            && ValueEquality.AreEqual(IsOmitted, other.IsOmitted)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Enum);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsSystemProvided);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DynamicVariable);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AllowedValues);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AllowedValuesDynamicVariable);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConstantValue);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsOmitted);
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
