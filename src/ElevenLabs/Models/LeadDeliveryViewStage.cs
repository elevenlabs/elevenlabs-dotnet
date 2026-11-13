using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The furthest the message got, or `failed` if sending it failed.</summary>
[JsonConverter(typeof(LeadDeliveryViewStage.LeadDeliveryViewStageSerializer))]
[Serializable]
public readonly record struct LeadDeliveryViewStage : IStringEnum
{
    public static readonly LeadDeliveryViewStage Queued = new(Values.Queued);

    public static readonly LeadDeliveryViewStage Sent = new(Values.Sent);

    public static readonly LeadDeliveryViewStage Delivered = new(Values.Delivered);

    public static readonly LeadDeliveryViewStage Read = new(Values.Read);

    public static readonly LeadDeliveryViewStage Replied = new(Values.Replied);

    public static readonly LeadDeliveryViewStage Failed = new(Values.Failed);

    public LeadDeliveryViewStage(string value)
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
    public static LeadDeliveryViewStage FromCustom(string value)
    {
        return new LeadDeliveryViewStage(value);
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

    public static bool operator ==(LeadDeliveryViewStage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LeadDeliveryViewStage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LeadDeliveryViewStage value) => value.Value;

    public static explicit operator LeadDeliveryViewStage(string value) => new(value);

    internal class LeadDeliveryViewStageSerializer : JsonConverter<LeadDeliveryViewStage>
    {
        public override LeadDeliveryViewStage Read(
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
            return new LeadDeliveryViewStage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LeadDeliveryViewStage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LeadDeliveryViewStage ReadAsPropertyName(
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
            return new LeadDeliveryViewStage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LeadDeliveryViewStage value,
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
        public const string Queued = "queued";

        public const string Sent = "sent";

        public const string Delivered = "delivered";

        public const string Read = "read";

        public const string Replied = "replied";

        public const string Failed = "failed";
    }
}
