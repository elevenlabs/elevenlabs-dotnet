using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus.KnowledgeBaseBulkDeleteSuccessfulResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus : IStringEnum
{
    public static readonly KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus Success = new(
        Values.Success
    );

    public KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus(string value)
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
    public static KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus FromCustom(string value)
    {
        return new KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus(value);
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
        KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus value
    ) => value.Value;

    public static explicit operator KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus(
        string value
    ) => new(value);

    internal class KnowledgeBaseBulkDeleteSuccessfulResponseModelStatusSerializer
        : JsonConverter<KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus>
    {
        public override KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus Read(
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
            return new KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus ReadAsPropertyName(
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
            return new KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseBulkDeleteSuccessfulResponseModelStatus value,
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
