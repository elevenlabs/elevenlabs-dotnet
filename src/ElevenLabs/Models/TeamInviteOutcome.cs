using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TeamInviteOutcome.TeamInviteOutcomeSerializer))]
[Serializable]
public readonly record struct TeamInviteOutcome : IStringEnum
{
    public static readonly TeamInviteOutcome Invited = new(Values.Invited);

    public static readonly TeamInviteOutcome Failed = new(Values.Failed);

    public TeamInviteOutcome(string value)
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
    public static TeamInviteOutcome FromCustom(string value)
    {
        return new TeamInviteOutcome(value);
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

    public static bool operator ==(TeamInviteOutcome value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TeamInviteOutcome value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TeamInviteOutcome value) => value.Value;

    public static explicit operator TeamInviteOutcome(string value) => new(value);

    internal class TeamInviteOutcomeSerializer : JsonConverter<TeamInviteOutcome>
    {
        public override TeamInviteOutcome Read(
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
            return new TeamInviteOutcome(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TeamInviteOutcome value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TeamInviteOutcome ReadAsPropertyName(
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
            return new TeamInviteOutcome(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TeamInviteOutcome value,
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
        public const string Invited = "invited";

        public const string Failed = "failed";
    }
}
