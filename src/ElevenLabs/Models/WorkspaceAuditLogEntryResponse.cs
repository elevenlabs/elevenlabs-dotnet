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

/// <summary>Audit log entry with Firestore document ID for API responses.</summary>
[Serializable]
public record WorkspaceAuditLogEntryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Event metadata</value>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <value>Event time in milliseconds since epoch</value>
    [JsonPropertyName("time")]
    public int? Time { get; set; }

    /// <value>Activity ID</value>
    [JsonPropertyName("activity_id")]
    public required int ActivityId { get; set; }

    /// <value>Activity name</value>
    [JsonPropertyName("activity_name")]
    public required string ActivityName { get; set; }

    /// <value>Event category</value>
    [JsonPropertyName("category_name")]
    public string? CategoryName { get; set; }

    /// <value>Category UID for IAM</value>
    [JsonPropertyName("category_uid")]
    public int? CategoryUid { get; set; }

    /// <value>Event class name</value>
    [JsonPropertyName("class_name")]
    public string? ClassName { get; set; }

    /// <value>Event class UID</value>
    [JsonPropertyName("class_uid")]
    public int? ClassUid { get; set; }

    /// <value>
    /// OCSF Severity levels.
    ///
    /// Spec: https://schema.ocsf.io/1.6.0/objects/severity_id
    /// </value>
    [JsonPropertyName("severity_id")]
    public int? SeverityId { get; set; }

    /// <value>
    /// OCSF Status levels.
    ///
    /// Spec: https://schema.ocsf.io/1.6.0/objects/status_id
    /// </value>
    [JsonPropertyName("status_id")]
    public required int StatusId { get; set; }

    /// <value>
    /// OCSF Actor object - describes the entity that performed the action.
    ///
    /// Spec: https://schema.ocsf.io/1.6.0/objects/actor
    /// </value>
    [JsonPropertyName("actor")]
    public required ActorModel Actor { get; set; }

    /// <value>Device information</value>
    [JsonPropertyName("device")]
    public DeviceModel? Device { get; set; }

    /// <value>HTTP request details</value>
    [JsonPropertyName("http_request")]
    public HttpRequestModel? HttpRequest { get; set; }

    /// <value>Human-readable event description</value>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    /// <value>Attributes not mapped to OCSF</value>
    [JsonPropertyName("unmapped")]
    public Dictionary<string, object?>? Unmapped { get; set; }

    /// <value>Firestore document ID</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Event time in human-readable RFC 3339 format, derived from 'time'.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("time_dt")]
    public string? TimeDt { get; set; }

    /// <value>OCSF type_uid is class_uid * 100 + activity_id.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("type_uid")]
    public int? TypeUid { get; set; }

    /// <value>OCSF type_name combines class_name and activity_name.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("type_name")]
    public string? TypeName { get; set; }

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
    public virtual bool Equals(WorkspaceAuditLogEntryResponse? other)
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
            && ValueEquality.AreEqual(Metadata, other.Metadata)
            && ValueEquality.AreEqual(Time, other.Time)
            && ValueEquality.AreEqual(ActivityId, other.ActivityId)
            && ValueEquality.AreEqual(ActivityName, other.ActivityName)
            && ValueEquality.AreEqual(CategoryName, other.CategoryName)
            && ValueEquality.AreEqual(CategoryUid, other.CategoryUid)
            && ValueEquality.AreEqual(ClassName, other.ClassName)
            && ValueEquality.AreEqual(ClassUid, other.ClassUid)
            && ValueEquality.AreEqual(SeverityId, other.SeverityId)
            && ValueEquality.AreEqual(StatusId, other.StatusId)
            && ValueEquality.AreEqual(Actor, other.Actor)
            && ValueEquality.AreEqual(Device, other.Device)
            && ValueEquality.AreEqual(HttpRequest, other.HttpRequest)
            && ValueEquality.AreEqual(Message, other.Message)
            && ValueEquality.AreEqual(Unmapped, other.Unmapped)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(TimeDt, other.TimeDt)
            && ValueEquality.AreEqual(TypeUid, other.TypeUid)
            && ValueEquality.AreEqual(TypeName, other.TypeName)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Metadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Time);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ActivityId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ActivityName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CategoryName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CategoryUid);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ClassName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ClassUid);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SeverityId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StatusId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Actor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Device);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HttpRequest);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Message);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Unmapped);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TimeDt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TypeUid);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TypeName);
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
