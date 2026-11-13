using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus.KnowledgeBaseSummaryBatchSuccessfulResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus : IStringEnum
{
    public static readonly KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus Success = new(
        Values.Success
    );

    public KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus(string value)
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
    public static KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus FromCustom(string value)
    {
        return new KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus(value);
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
        KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus value
    ) => value.Value;

    public static explicit operator KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus(
        string value
    ) => new(value);

    internal class KnowledgeBaseSummaryBatchSuccessfulResponseModelStatusSerializer
        : JsonConverter<KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus>
    {
        public override KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus Read(
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
            return new KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus ReadAsPropertyName(
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
            return new KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseSummaryBatchSuccessfulResponseModelStatus value,
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
