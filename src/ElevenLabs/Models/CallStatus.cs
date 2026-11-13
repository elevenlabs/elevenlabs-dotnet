using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.OutboundCampaigns;

[JsonConverter(typeof(CallStatus.CallStatusSerializer))]
[Serializable]
public readonly record struct CallStatus : IStringEnum
{
    public static readonly CallStatus Queued = new(Values.Queued);

    public static readonly CallStatus Submitted = new(Values.Submitted);

    public static readonly CallStatus Completed = new(Values.Completed);

    public static readonly CallStatus Cancelled = new(Values.Cancelled);

    public static readonly CallStatus Attention = new(Values.Attention);

    public CallStatus(string value)
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
    public static CallStatus FromCustom(string value)
    {
        return new CallStatus(value);
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

    public static bool operator ==(CallStatus value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CallStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CallStatus value) => value.Value;

    public static explicit operator CallStatus(string value) => new(value);

    internal class CallStatusSerializer : JsonConverter<CallStatus>
    {
        public override CallStatus Read(
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
            return new CallStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CallStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CallStatus ReadAsPropertyName(
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
            return new CallStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CallStatus value,
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

        public const string Submitted = "submitted";

        public const string Completed = "completed";

        public const string Cancelled = "cancelled";

        public const string Attention = "attention";
    }
}
