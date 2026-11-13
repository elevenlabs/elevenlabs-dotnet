using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CampaignSource.CampaignSourceSerializer))]
[Serializable]
public readonly record struct CampaignSource : IStringEnum
{
    public static readonly CampaignSource Ui = new(Values.Ui);

    public static readonly CampaignSource Api = new(Values.Api);

    public CampaignSource(string value)
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
    public static CampaignSource FromCustom(string value)
    {
        return new CampaignSource(value);
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

    public static bool operator ==(CampaignSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CampaignSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CampaignSource value) => value.Value;

    public static explicit operator CampaignSource(string value) => new(value);

    internal class CampaignSourceSerializer : JsonConverter<CampaignSource>
    {
        public override CampaignSource Read(
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
            return new CampaignSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CampaignSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CampaignSource ReadAsPropertyName(
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
            return new CampaignSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CampaignSource value,
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
        public const string Ui = "ui";

        public const string Api = "api";
    }
}
