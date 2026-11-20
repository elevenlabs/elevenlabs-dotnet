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
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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
public record ReceptionTeamMemberResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The member's user ID.</value>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <value>The member's email address.</value>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <value>The member's first name, if set.</value>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <value>Whether the member owns the workspace.</value>
    [JsonPropertyName("is_owner")]
    public required bool IsOwner { get; set; }

    /// <value>Whether the member is a workspace admin.</value>
    [JsonPropertyName("is_admin")]
    public required bool IsAdmin { get; set; }

    /// <value>URL of the member's profile picture, if set.</value>
    [JsonPropertyName("picture_url")]
    public string? PictureUrl { get; set; }

    /// <value>Whether the member's access to the workspace is suspended.</value>
    [JsonPropertyName("is_suspended")]
    public bool? IsSuspended { get; set; }

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
    public virtual bool Equals(ReceptionTeamMemberResponse? other)
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
            && ValueEquality.AreEqual(UserId, other.UserId)
            && ValueEquality.AreEqual(Email, other.Email)
            && ValueEquality.AreEqual(FirstName, other.FirstName)
            && ValueEquality.AreEqual(IsOwner, other.IsOwner)
            && ValueEquality.AreEqual(IsAdmin, other.IsAdmin)
            && ValueEquality.AreEqual(PictureUrl, other.PictureUrl)
            && ValueEquality.AreEqual(IsSuspended, other.IsSuspended)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Email);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FirstName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsOwner);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsAdmin);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PictureUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsSuspended);
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
