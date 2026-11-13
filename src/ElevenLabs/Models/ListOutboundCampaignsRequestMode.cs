using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(ListOutboundCampaignsRequestMode.ListOutboundCampaignsRequestModeSerializer))]
[Serializable]
public readonly record struct ListOutboundCampaignsRequestMode : IStringEnum
{
    public static readonly ListOutboundCampaignsRequestMode Voice = new(Values.Voice);

    public static readonly ListOutboundCampaignsRequestMode Message = new(Values.Message);

    public ListOutboundCampaignsRequestMode(string value)
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
    public static ListOutboundCampaignsRequestMode FromCustom(string value)
    {
        return new ListOutboundCampaignsRequestMode(value);
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

    public static bool operator ==(ListOutboundCampaignsRequestMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOutboundCampaignsRequestMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOutboundCampaignsRequestMode value) => value.Value;

    public static explicit operator ListOutboundCampaignsRequestMode(string value) => new(value);

    internal class ListOutboundCampaignsRequestModeSerializer
        : JsonConverter<ListOutboundCampaignsRequestMode>
    {
        public override ListOutboundCampaignsRequestMode Read(
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
            return new ListOutboundCampaignsRequestMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOutboundCampaignsRequestMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOutboundCampaignsRequestMode ReadAsPropertyName(
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
            return new ListOutboundCampaignsRequestMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOutboundCampaignsRequestMode value,
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
        public const string Voice = "voice";

        public const string Message = "message";
    }
}
