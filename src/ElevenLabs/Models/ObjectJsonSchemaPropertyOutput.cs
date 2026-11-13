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
public record ObjectJsonSchemaPropertyOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>When set, the entire parameter is populated from this dynamic variable at runtime. Mutually exclusive with description (LLM-provided value), constant_value, and is_omitted.</value>
    [JsonPropertyName("dynamic_variable")]
    public string? DynamicVariable { get; set; }

    /// <value>When set, the entire object uses this constant JSON value at runtime. Mutually exclusive with description (LLM-provided object), dynamic_variable, and is_omitted.</value>
    [JsonPropertyName("constant_value")]
    public Dictionary<string, object?>? ConstantValue { get; set; }

    /// <value>If true, this parameter will be completely omitted from the request. Only valid for optional parameters. Mutually exclusive with description, dynamic_variable, and constant_value.</value>
    [JsonPropertyName("is_omitted")]
    public bool? IsOmitted { get; set; }

    [JsonPropertyName("type")]
    public ObjectJsonSchemaPropertyOutputType? Type { get; set; }

    [JsonPropertyName("required")]
    public IEnumerable<string>? Required { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, ObjectJsonSchemaPropertyOutputProperties>? Properties { get; set; }

    [JsonPropertyName("required_constraints")]
    public RequiredConstraints? RequiredConstraints { get; set; }

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
    public virtual bool Equals(ObjectJsonSchemaPropertyOutput? other)
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
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(DynamicVariable, other.DynamicVariable)
            && ValueEquality.AreEqual(ConstantValue, other.ConstantValue)
            && ValueEquality.AreEqual(IsOmitted, other.IsOmitted)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(Required, other.Required)
            && ValueEquality.AreEqual(Properties, other.Properties)
            && ValueEquality.AreEqual(RequiredConstraints, other.RequiredConstraints)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DynamicVariable);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConstantValue);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsOmitted);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Required);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Properties);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequiredConstraints);
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
