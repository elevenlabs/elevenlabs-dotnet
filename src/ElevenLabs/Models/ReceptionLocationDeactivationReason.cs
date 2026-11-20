using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Why a location is currently inactive.</summary>
[JsonConverter(
    typeof(ReceptionLocationDeactivationReason.ReceptionLocationDeactivationReasonSerializer)
)]
[Serializable]
public readonly record struct ReceptionLocationDeactivationReason : IStringEnum
{
    public static readonly ReceptionLocationDeactivationReason TierDowngrade = new(
        Values.TierDowngrade
    );

    public static readonly ReceptionLocationDeactivationReason User = new(Values.User);

    public ReceptionLocationDeactivationReason(string value)
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
    public static ReceptionLocationDeactivationReason FromCustom(string value)
    {
        return new ReceptionLocationDeactivationReason(value);
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

    public static bool operator ==(ReceptionLocationDeactivationReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionLocationDeactivationReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionLocationDeactivationReason value) =>
        value.Value;

    public static explicit operator ReceptionLocationDeactivationReason(string value) => new(value);

    internal class ReceptionLocationDeactivationReasonSerializer
        : JsonConverter<ReceptionLocationDeactivationReason>
    {
        public override ReceptionLocationDeactivationReason Read(
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
            return new ReceptionLocationDeactivationReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionLocationDeactivationReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionLocationDeactivationReason ReadAsPropertyName(
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
            return new ReceptionLocationDeactivationReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionLocationDeactivationReason value,
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
