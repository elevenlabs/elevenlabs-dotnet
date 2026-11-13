using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Valid Twilio edge locations.</summary>
[JsonConverter(typeof(TwilioEdgeLocation.TwilioEdgeLocationSerializer))]
[Serializable]
public readonly record struct TwilioEdgeLocation : IStringEnum
{
    public static readonly TwilioEdgeLocation Ashburn = new(Values.Ashburn);

    public static readonly TwilioEdgeLocation Dublin = new(Values.Dublin);

    public static readonly TwilioEdgeLocation Frankfurt = new(Values.Frankfurt);

    public static readonly TwilioEdgeLocation SaoPaulo = new(Values.SaoPaulo);

    public static readonly TwilioEdgeLocation Singapore = new(Values.Singapore);

    public static readonly TwilioEdgeLocation Sydney = new(Values.Sydney);

    public static readonly TwilioEdgeLocation Tokyo = new(Values.Tokyo);

    public static readonly TwilioEdgeLocation Umatilla = new(Values.Umatilla);

    public static readonly TwilioEdgeLocation Roaming = new(Values.Roaming);

    public TwilioEdgeLocation(string value)
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
    public static TwilioEdgeLocation FromCustom(string value)
    {
        return new TwilioEdgeLocation(value);
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

    public static bool operator ==(TwilioEdgeLocation value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TwilioEdgeLocation value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TwilioEdgeLocation value) => value.Value;

    public static explicit operator TwilioEdgeLocation(string value) => new(value);

    internal class TwilioEdgeLocationSerializer : JsonConverter<TwilioEdgeLocation>
    {
        public override TwilioEdgeLocation Read(
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
            return new TwilioEdgeLocation(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioEdgeLocation value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioEdgeLocation ReadAsPropertyName(
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
            return new TwilioEdgeLocation(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioEdgeLocation value,
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
        public const string Ashburn = "ashburn";

        public const string Dublin = "dublin";

        public const string Frankfurt = "frankfurt";

        public const string SaoPaulo = "sao-paulo";

        public const string Singapore = "singapore";

        public const string Sydney = "sydney";

        public const string Tokyo = "tokyo";

        public const string Umatilla = "umatilla";

        public const string Roaming = "roaming";
    }
}
