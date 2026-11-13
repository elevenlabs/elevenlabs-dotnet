using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CampaignConversationType.CampaignConversationTypeSerializer))]
[Serializable]
public readonly record struct CampaignConversationType : IStringEnum
{
    public static readonly CampaignConversationType Initial = new(Values.Initial);

    public static readonly CampaignConversationType Retry = new(Values.Retry);

    public static readonly CampaignConversationType Callback = new(Values.Callback);

    public static readonly CampaignConversationType Redirect = new(Values.Redirect);

    public CampaignConversationType(string value)
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
    public static CampaignConversationType FromCustom(string value)
    {
        return new CampaignConversationType(value);
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

    public static bool operator ==(CampaignConversationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CampaignConversationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CampaignConversationType value) => value.Value;

    public static explicit operator CampaignConversationType(string value) => new(value);

    internal class CampaignConversationTypeSerializer : JsonConverter<CampaignConversationType>
    {
        public override CampaignConversationType Read(
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
            return new CampaignConversationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CampaignConversationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CampaignConversationType ReadAsPropertyName(
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
            return new CampaignConversationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CampaignConversationType value,
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
        public const string Initial = "initial";

        public const string Retry = "retry";

        public const string Callback = "callback";

        public const string Redirect = "redirect";
    }
}
