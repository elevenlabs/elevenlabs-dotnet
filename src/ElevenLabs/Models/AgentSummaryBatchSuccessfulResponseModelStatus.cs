using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AgentSummaryBatchSuccessfulResponseModelStatus.AgentSummaryBatchSuccessfulResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct AgentSummaryBatchSuccessfulResponseModelStatus : IStringEnum
{
    public static readonly AgentSummaryBatchSuccessfulResponseModelStatus Success = new(
        Values.Success
    );

    public AgentSummaryBatchSuccessfulResponseModelStatus(string value)
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
    public static AgentSummaryBatchSuccessfulResponseModelStatus FromCustom(string value)
    {
        return new AgentSummaryBatchSuccessfulResponseModelStatus(value);
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

    public static bool operator ==(
        AgentSummaryBatchSuccessfulResponseModelStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentSummaryBatchSuccessfulResponseModelStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AgentSummaryBatchSuccessfulResponseModelStatus value) =>
        value.Value;

    public static explicit operator AgentSummaryBatchSuccessfulResponseModelStatus(string value) =>
        new(value);

    internal class AgentSummaryBatchSuccessfulResponseModelStatusSerializer
        : JsonConverter<AgentSummaryBatchSuccessfulResponseModelStatus>
    {
        public override AgentSummaryBatchSuccessfulResponseModelStatus Read(
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
            return new AgentSummaryBatchSuccessfulResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSummaryBatchSuccessfulResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSummaryBatchSuccessfulResponseModelStatus ReadAsPropertyName(
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
            return new AgentSummaryBatchSuccessfulResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSummaryBatchSuccessfulResponseModelStatus value,
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
    }
}
