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
using ElevenLabs.ServiceAccounts;
using ElevenLabs.SpeechEngine;
using ElevenLabs.Studio;
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace;

[Serializable]
public record BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePost
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Start of the time range as a Unix timestamp in milliseconds. Must be at least 2020-01-01.</value>
    [JsonPropertyName("start_time")]
    public required int StartTime { get; set; }

    /// <value>End of the time range as a Unix timestamp in milliseconds. Must be at least 2020-01-01.</value>
    [JsonPropertyName("end_time")]
    public required int EndTime { get; set; }

    /// <value>Bucket size in seconds. Each row in the response covers this many seconds of the selected time range. For example, pass 3600 for hourly buckets, 86400 for daily buckets, or 604800 for weekly buckets. Whether `time_zone` shifts bucket boundaries depends on this value: week multiples (e.g. 604800) are calendar weeks that start Monday at local midnight; whole-day multiples that are not whole weeks (e.g. 86400) align to local midnight; whole-hour multiples up to 24 hours (e.g. 3600, 14400) align to local hour boundaries from midnight; sub-hour values and other sizes remain UTC-anchored regardless of `time_zone`.</value>
    [JsonPropertyName("interval_seconds")]
    public int? IntervalSeconds { get; set; }

    [JsonPropertyName("group_by")]
    public IEnumerable<BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem>? GroupBy { get; set; }

    [JsonPropertyName("filters")]
    public IEnumerable<ColumnFilter>? Filters { get; set; }

    /// <value>IANA time zone identifier (e.g. 'America/New_York', 'Europe/London', 'UTC') used to align bucket boundaries for eligible `interval_seconds` values. Week multiples (e.g. 604800) are calendar weeks that start Monday at local midnight. Whole-day multiples that are not whole weeks start at local midnight; whole-hour multiples up to 24 hours align to local hour boundaries from midnight. Sub-hour intervals and other bucket sizes remain UTC-anchored regardless of this setting. Defaults to UTC.</value>
    [JsonPropertyName("time_zone")]
    public string? TimeZone { get; set; }

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
        BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePost? other
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
            && ValueEquality.AreEqual(StartTime, other.StartTime)
            && ValueEquality.AreEqual(EndTime, other.EndTime)
            && ValueEquality.AreEqual(IntervalSeconds, other.IntervalSeconds)
            && ValueEquality.AreEqual(GroupBy, other.GroupBy)
            && ValueEquality.AreEqual(Filters, other.Filters)
            && ValueEquality.AreEqual(TimeZone, other.TimeZone)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntervalSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GroupBy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Filters);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TimeZone);
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
