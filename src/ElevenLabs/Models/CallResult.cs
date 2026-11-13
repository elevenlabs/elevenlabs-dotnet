using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.OutboundCampaigns;

[JsonConverter(typeof(CallResult.CallResultSerializer))]
[Serializable]
public readonly record struct CallResult : IStringEnum
{
    public static readonly CallResult Answered = new(Values.Answered);

    public static readonly CallResult Voicemail = new(Values.Voicemail);

    public static readonly CallResult Busy = new(Values.Busy);

    public static readonly CallResult NoAnswer = new(Values.NoAnswer);

    public static readonly CallResult Failed = new(Values.Failed);

    public CallResult(string value)
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
    public static CallResult FromCustom(string value)
    {
        return new CallResult(value);
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

    public static bool operator ==(CallResult value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CallResult value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CallResult value) => value.Value;

    public static explicit operator CallResult(string value) => new(value);

    internal class CallResultSerializer : JsonConverter<CallResult>
    {
        public override CallResult Read(
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
            return new CallResult(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CallResult value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CallResult ReadAsPropertyName(
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
            return new CallResult(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CallResult value,
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
        public const string Answered = "answered";

        public const string Voicemail = "voicemail";

        public const string Busy = "busy";

        public const string NoAnswer = "no_answer";

        public const string Failed = "failed";
    }
}
