using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Exit branch taken when the Genesys Bot Connector session ends.
///
/// These values are the intent names registered in the Genesys bot list, so they are
/// what the Call Bot Connector node branches on. Adding a value here without also
/// registering the intent in Genesys would produce an exit the flow cannot handle.
/// </summary>
[JsonConverter(typeof(GenesysBotOutcome.GenesysBotOutcomeSerializer))]
[Serializable]
public readonly record struct GenesysBotOutcome : IStringEnum
{
    public static readonly GenesysBotOutcome Success = new(Values.Success);

    public static readonly GenesysBotOutcome Escalate = new(Values.Escalate);

    public GenesysBotOutcome(string value)
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
    public static GenesysBotOutcome FromCustom(string value)
    {
        return new GenesysBotOutcome(value);
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

    public static bool operator ==(GenesysBotOutcome value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GenesysBotOutcome value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GenesysBotOutcome value) => value.Value;

    public static explicit operator GenesysBotOutcome(string value) => new(value);

    internal class GenesysBotOutcomeSerializer : JsonConverter<GenesysBotOutcome>
    {
        public override GenesysBotOutcome Read(
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
            return new GenesysBotOutcome(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GenesysBotOutcome value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GenesysBotOutcome ReadAsPropertyName(
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
            return new GenesysBotOutcome(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GenesysBotOutcome value,
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
        public const string Success = "success";

        public const string Escalate = "escalate";
    }
}
