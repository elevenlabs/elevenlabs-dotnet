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
public record VoiceSharingModerationCheckResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The date the moderation check was made in Unix time.</value>
    [JsonPropertyName("date_checked_unix")]
    public int? DateCheckedUnix { get; set; }

    /// <value>The name value of the voice.</value>
    [JsonPropertyName("name_value")]
    public string? NameValue { get; set; }

    /// <value>Whether the name check was successful.</value>
    [JsonPropertyName("name_check")]
    public bool? NameCheck { get; set; }

    /// <value>The description value of the voice.</value>
    [JsonPropertyName("description_value")]
    public string? DescriptionValue { get; set; }

    /// <value>Whether the description check was successful.</value>
    [JsonPropertyName("description_check")]
    public bool? DescriptionCheck { get; set; }

    /// <value>A list of sample IDs.</value>
    [JsonPropertyName("sample_ids")]
    public IEnumerable<string>? SampleIds { get; set; }

    /// <value>A list of sample checks.</value>
    [JsonPropertyName("sample_checks")]
    public IEnumerable<double>? SampleChecks { get; set; }

    /// <value>A list of captcha IDs.</value>
    [JsonPropertyName("captcha_ids")]
    public IEnumerable<string>? CaptchaIds { get; set; }

    /// <value>A list of CAPTCHA check values.</value>
    [JsonPropertyName("captcha_checks")]
    public IEnumerable<double>? CaptchaChecks { get; set; }

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
    public virtual bool Equals(VoiceSharingModerationCheckResponseModel? other)
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
            && ValueEquality.AreEqual(DateCheckedUnix, other.DateCheckedUnix)
            && ValueEquality.AreEqual(NameValue, other.NameValue)
            && ValueEquality.AreEqual(NameCheck, other.NameCheck)
            && ValueEquality.AreEqual(DescriptionValue, other.DescriptionValue)
            && ValueEquality.AreEqual(DescriptionCheck, other.DescriptionCheck)
            && ValueEquality.AreEqual(SampleIds, other.SampleIds)
            && ValueEquality.AreEqual(SampleChecks, other.SampleChecks)
            && ValueEquality.AreEqual(CaptchaIds, other.CaptchaIds)
            && ValueEquality.AreEqual(CaptchaChecks, other.CaptchaChecks)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DateCheckedUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NameValue);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NameCheck);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DescriptionValue);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DescriptionCheck);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SampleIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SampleChecks);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CaptchaIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CaptchaChecks);
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
