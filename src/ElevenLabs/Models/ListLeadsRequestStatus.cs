using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.OutboundCampaigns;

[JsonConverter(typeof(ListLeadsRequestStatus.ListLeadsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListLeadsRequestStatus : IStringEnum
{
    public static readonly ListLeadsRequestStatus InProgress = new(Values.InProgress);

    public static readonly ListLeadsRequestStatus Finished = new(Values.Finished);

    public ListLeadsRequestStatus(string value)
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
    public static ListLeadsRequestStatus FromCustom(string value)
    {
        return new ListLeadsRequestStatus(value);
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

    public static bool operator ==(ListLeadsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListLeadsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListLeadsRequestStatus value) => value.Value;

    public static explicit operator ListLeadsRequestStatus(string value) => new(value);

    internal class ListLeadsRequestStatusSerializer : JsonConverter<ListLeadsRequestStatus>
    {
        public override ListLeadsRequestStatus Read(
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
            return new ListLeadsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListLeadsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListLeadsRequestStatus ReadAsPropertyName(
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
            return new ListLeadsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListLeadsRequestStatus value,
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
        public const string InProgress = "in_progress";

        public const string Finished = "finished";
    }
}
