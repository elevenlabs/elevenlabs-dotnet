using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Why a receptionist is currently inactive (live calls disabled).</summary>
[JsonConverter(
    typeof(ReceptionCustomerFacingAgentDeactivationReason.ReceptionCustomerFacingAgentDeactivationReasonSerializer)
)]
[Serializable]
public readonly record struct ReceptionCustomerFacingAgentDeactivationReason : IStringEnum
{
    public static readonly ReceptionCustomerFacingAgentDeactivationReason TierDowngrade = new(
        Values.TierDowngrade
    );

    public static readonly ReceptionCustomerFacingAgentDeactivationReason User = new(Values.User);

    public ReceptionCustomerFacingAgentDeactivationReason(string value)
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
    public static ReceptionCustomerFacingAgentDeactivationReason FromCustom(string value)
    {
        return new ReceptionCustomerFacingAgentDeactivationReason(value);
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
        ReceptionCustomerFacingAgentDeactivationReason value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReceptionCustomerFacingAgentDeactivationReason value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionCustomerFacingAgentDeactivationReason value) =>
        value.Value;

    public static explicit operator ReceptionCustomerFacingAgentDeactivationReason(string value) =>
        new(value);

    internal class ReceptionCustomerFacingAgentDeactivationReasonSerializer
        : JsonConverter<ReceptionCustomerFacingAgentDeactivationReason>
    {
        public override ReceptionCustomerFacingAgentDeactivationReason Read(
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
            return new ReceptionCustomerFacingAgentDeactivationReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionCustomerFacingAgentDeactivationReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionCustomerFacingAgentDeactivationReason ReadAsPropertyName(
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
            return new ReceptionCustomerFacingAgentDeactivationReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionCustomerFacingAgentDeactivationReason value,
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

        public const string User = "user";
    }
}
