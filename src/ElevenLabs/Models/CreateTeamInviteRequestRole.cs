using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Reception.Team;

/// <summary>The role the invitee joins with: 'workspace_admin' or 'workspace_member'.</summary>
[JsonConverter(typeof(CreateTeamInviteRequestRole.CreateTeamInviteRequestRoleSerializer))]
[Serializable]
public readonly record struct CreateTeamInviteRequestRole : IStringEnum
{
    public static readonly CreateTeamInviteRequestRole WorkspaceAdmin = new(Values.WorkspaceAdmin);

    public static readonly CreateTeamInviteRequestRole WorkspaceMember = new(
        Values.WorkspaceMember
    );

    public CreateTeamInviteRequestRole(string value)
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
    public static CreateTeamInviteRequestRole FromCustom(string value)
    {
        return new CreateTeamInviteRequestRole(value);
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

    public static bool operator ==(CreateTeamInviteRequestRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTeamInviteRequestRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTeamInviteRequestRole value) => value.Value;

    public static explicit operator CreateTeamInviteRequestRole(string value) => new(value);

    internal class CreateTeamInviteRequestRoleSerializer
        : JsonConverter<CreateTeamInviteRequestRole>
    {
        public override CreateTeamInviteRequestRole Read(
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
            return new CreateTeamInviteRequestRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTeamInviteRequestRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTeamInviteRequestRole ReadAsPropertyName(
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
            return new CreateTeamInviteRequestRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTeamInviteRequestRole value,
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
