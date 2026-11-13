using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(CampaignStatus.CampaignStatusSerializer))]
[Serializable]
public readonly record struct CampaignStatus : IStringEnum
{
    public static readonly CampaignStatus Active = new(Values.Active);

    public static readonly CampaignStatus Paused = new(Values.Paused);

    public static readonly CampaignStatus Stopping = new(Values.Stopping);

    public static readonly CampaignStatus Stopped = new(Values.Stopped);

    public static readonly CampaignStatus Completed = new(Values.Completed);

    public static readonly CampaignStatus Failed = new(Values.Failed);

    public static readonly CampaignStatus Attention = new(Values.Attention);

    public CampaignStatus(string value)
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
    public static CampaignStatus FromCustom(string value)
    {
        return new CampaignStatus(value);
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

    public static bool operator ==(CampaignStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CampaignStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CampaignStatus value) => value.Value;

    public static explicit operator CampaignStatus(string value) => new(value);

    internal class CampaignStatusSerializer : JsonConverter<CampaignStatus>
    {
        public override CampaignStatus Read(
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
            return new CampaignStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CampaignStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CampaignStatus ReadAsPropertyName(
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
            return new CampaignStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CampaignStatus value,
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
        public const string Active = "active";

        public const string Paused = "paused";

        public const string Stopping = "stopping";

        public const string Stopped = "stopped";

        public const string Completed = "completed";

        public const string Failed = "failed";

        public const string Attention = "attention";
    }
}
