using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The role the invitee joins with: 'workspace_admin' or 'workspace_member'.</summary>
[JsonConverter(typeof(TeamInviteRequestRole.TeamInviteRequestRoleSerializer))]
[Serializable]
public readonly record struct TeamInviteRequestRole : IStringEnum
{
    public static readonly TeamInviteRequestRole WorkspaceAdmin = new(Values.WorkspaceAdmin);

    public static readonly TeamInviteRequestRole WorkspaceMember = new(Values.WorkspaceMember);

    public TeamInviteRequestRole(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static TeamInviteRequestRole FromCustom(string value)
    {
        return new TeamInviteRequestRole(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(TeamInviteRequestRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TeamInviteRequestRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TeamInviteRequestRole value) => value.Value;

    public static explicit operator TeamInviteRequestRole(string value) => new(value);

    internal class TeamInviteRequestRoleSerializer : JsonConverter<TeamInviteRequestRole>
    {
        public override TeamInviteRequestRole Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new TeamInviteRequestRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TeamInviteRequestRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TeamInviteRequestRole ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new TeamInviteRequestRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TeamInviteRequestRole value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string WorkspaceAdmin = "workspace_admin";

        public const string WorkspaceMember = "workspace_member";
    }
}
