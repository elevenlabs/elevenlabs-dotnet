using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(PendingSubscriptionSwitchResponseModelKind.PendingSubscriptionSwitchResponseModelKindSerializer)
)]
[Serializable]
public readonly record struct PendingSubscriptionSwitchResponseModelKind : IStringEnum
{
    public static readonly PendingSubscriptionSwitchResponseModelKind Change = new(Values.Change);

    public PendingSubscriptionSwitchResponseModelKind(string value)
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
    public static PendingSubscriptionSwitchResponseModelKind FromCustom(string value)
    {
        return new PendingSubscriptionSwitchResponseModelKind(value);
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
        PendingSubscriptionSwitchResponseModelKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PendingSubscriptionSwitchResponseModelKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(PendingSubscriptionSwitchResponseModelKind value) =>
        value.Value;

    public static explicit operator PendingSubscriptionSwitchResponseModelKind(string value) =>
        new(value);

    internal class PendingSubscriptionSwitchResponseModelKindSerializer
        : JsonConverter<PendingSubscriptionSwitchResponseModelKind>
    {
        public override PendingSubscriptionSwitchResponseModelKind Read(
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
            return new PendingSubscriptionSwitchResponseModelKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PendingSubscriptionSwitchResponseModelKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PendingSubscriptionSwitchResponseModelKind ReadAsPropertyName(
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
            return new PendingSubscriptionSwitchResponseModelKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PendingSubscriptionSwitchResponseModelKind value,
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
        public const string Change = "change";
    }
}
