using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Why a phone assignment is currently inactive.</summary>
[JsonConverter(
    typeof(ReceptionPhoneAssignmentDeactivationReason.ReceptionPhoneAssignmentDeactivationReasonSerializer)
)]
[Serializable]
public readonly record struct ReceptionPhoneAssignmentDeactivationReason : IStringEnum
{
    public static readonly ReceptionPhoneAssignmentDeactivationReason TierDowngrade = new(
        Values.TierDowngrade
    );

    public static readonly ReceptionPhoneAssignmentDeactivationReason NoEntitlement = new(
        Values.NoEntitlement
    );

    public static readonly ReceptionPhoneAssignmentDeactivationReason User = new(Values.User);

    public ReceptionPhoneAssignmentDeactivationReason(string value)
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
    public static ReceptionPhoneAssignmentDeactivationReason FromCustom(string value)
    {
        return new ReceptionPhoneAssignmentDeactivationReason(value);
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

    public static bool operator ==(
        ReceptionPhoneAssignmentDeactivationReason value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReceptionPhoneAssignmentDeactivationReason value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionPhoneAssignmentDeactivationReason value) =>
        value.Value;

    public static explicit operator ReceptionPhoneAssignmentDeactivationReason(string value) =>
        new(value);

    internal class ReceptionPhoneAssignmentDeactivationReasonSerializer
        : JsonConverter<ReceptionPhoneAssignmentDeactivationReason>
    {
        public override ReceptionPhoneAssignmentDeactivationReason Read(
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
            return new ReceptionPhoneAssignmentDeactivationReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionPhoneAssignmentDeactivationReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionPhoneAssignmentDeactivationReason ReadAsPropertyName(
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
            return new ReceptionPhoneAssignmentDeactivationReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionPhoneAssignmentDeactivationReason value,
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
        public const string TierDowngrade = "tier_downgrade";

        public const string NoEntitlement = "no_entitlement";

        public const string User = "user";
    }
}
