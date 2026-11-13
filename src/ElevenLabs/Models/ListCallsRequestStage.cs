using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.OutboundCampaigns;

[JsonConverter(typeof(ListCallsRequestStage.ListCallsRequestStageSerializer))]
[Serializable]
public readonly record struct ListCallsRequestStage : IStringEnum
{
    public static readonly ListCallsRequestStage Queued = new(Values.Queued);

    public static readonly ListCallsRequestStage Sent = new(Values.Sent);

    public static readonly ListCallsRequestStage Delivered = new(Values.Delivered);

    public static readonly ListCallsRequestStage Read = new(Values.Read);

    public static readonly ListCallsRequestStage Replied = new(Values.Replied);

    public static readonly ListCallsRequestStage Failed = new(Values.Failed);

    public ListCallsRequestStage(string value)
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
    public static ListCallsRequestStage FromCustom(string value)
    {
        return new ListCallsRequestStage(value);
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

    public static bool operator ==(ListCallsRequestStage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCallsRequestStage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCallsRequestStage value) => value.Value;

    public static explicit operator ListCallsRequestStage(string value) => new(value);

    internal class ListCallsRequestStageSerializer : JsonConverter<ListCallsRequestStage>
    {
        public override ListCallsRequestStage Read(
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
            return new ListCallsRequestStage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCallsRequestStage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCallsRequestStage ReadAsPropertyName(
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
            return new ListCallsRequestStage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCallsRequestStage value,
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
