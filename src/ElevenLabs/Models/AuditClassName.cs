using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace;

/// <summary>OCSF event classes emitted in audit logs.</summary>
[JsonConverter(typeof(AuditClassName.AuditClassNameSerializer))]
[Serializable]
public readonly record struct AuditClassName : IStringEnum
{
    public static readonly AuditClassName AccountChange = new(Values.AccountChange);

    public static readonly AuditClassName Authentication = new(Values.Authentication);

    public static readonly AuditClassName EntityManagement = new(Values.EntityManagement);

    public static readonly AuditClassName UserAccessManagement = new(Values.UserAccessManagement);

    public static readonly AuditClassName GroupManagement = new(Values.GroupManagement);

    public AuditClassName(string value)
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
    public static AuditClassName FromCustom(string value)
    {
        return new AuditClassName(value);
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

    public static bool operator ==(AuditClassName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AuditClassName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AuditClassName value) => value.Value;

    public static explicit operator AuditClassName(string value) => new(value);

    internal class AuditClassNameSerializer : JsonConverter<AuditClassName>
    {
        public override AuditClassName Read(
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
            return new AuditClassName(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuditClassName value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AuditClassName ReadAsPropertyName(
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
            return new AuditClassName(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AuditClassName value,
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
        public const string AccountChange = "Account Change";

        public const string Authentication = "Authentication";

        public const string EntityManagement = "Entity Management";

        public const string UserAccessManagement = "User Access Management";

        public const string GroupManagement = "Group Management";
    }
}
