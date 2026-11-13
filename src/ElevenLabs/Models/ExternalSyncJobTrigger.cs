using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExternalSyncJobTrigger.ExternalSyncJobTriggerSerializer))]
[Serializable]
public readonly record struct ExternalSyncJobTrigger : IStringEnum
{
    public static readonly ExternalSyncJobTrigger OnDemand = new(Values.OnDemand);

    public static readonly ExternalSyncJobTrigger OnConnect = new(Values.OnConnect);

    public static readonly ExternalSyncJobTrigger Auto = new(Values.Auto);

    public ExternalSyncJobTrigger(string value)
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
    public static ExternalSyncJobTrigger FromCustom(string value)
    {
        return new ExternalSyncJobTrigger(value);
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

    public static bool operator ==(ExternalSyncJobTrigger value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExternalSyncJobTrigger value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExternalSyncJobTrigger value) => value.Value;

    public static explicit operator ExternalSyncJobTrigger(string value) => new(value);

    internal class ExternalSyncJobTriggerSerializer : JsonConverter<ExternalSyncJobTrigger>
    {
        public override ExternalSyncJobTrigger Read(
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
            return new ExternalSyncJobTrigger(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExternalSyncJobTrigger value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExternalSyncJobTrigger ReadAsPropertyName(
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
            return new ExternalSyncJobTrigger(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExternalSyncJobTrigger value,
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
        public const string OnDemand = "on_demand";

        public const string OnConnect = "on_connect";

        public const string Auto = "auto";
    }
}
