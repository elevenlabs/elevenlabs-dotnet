using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExternalSyncJobType.ExternalSyncJobTypeSerializer))]
[Serializable]
public readonly record struct ExternalSyncJobType : IStringEnum
{
    public static readonly ExternalSyncJobType Full = new(Values.Full);

    public static readonly ExternalSyncJobType Incremental = new(Values.Incremental);

    public ExternalSyncJobType(string value)
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
    public static ExternalSyncJobType FromCustom(string value)
    {
        return new ExternalSyncJobType(value);
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

    public static bool operator ==(ExternalSyncJobType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExternalSyncJobType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExternalSyncJobType value) => value.Value;

    public static explicit operator ExternalSyncJobType(string value) => new(value);

    internal class ExternalSyncJobTypeSerializer : JsonConverter<ExternalSyncJobType>
    {
        public override ExternalSyncJobType Read(
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
            return new ExternalSyncJobType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExternalSyncJobType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExternalSyncJobType ReadAsPropertyName(
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
            return new ExternalSyncJobType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExternalSyncJobType value,
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
        public const string Full = "full";

        public const string Incremental = "incremental";
    }
}
