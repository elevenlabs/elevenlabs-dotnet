using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Processing status for knowledge sources.
///
/// - `processing`: the file or site is being read.
/// - `ready`: done; the results are available.
/// - `error`: it failed and can be retried.
///
/// See `progress` for detail.
/// </summary>
[JsonConverter(typeof(KnowledgeSourceStatus.KnowledgeSourceStatusSerializer))]
[Serializable]
public readonly record struct KnowledgeSourceStatus : IStringEnum
{
    public static readonly KnowledgeSourceStatus Processing = new(Values.Processing);

    public static readonly KnowledgeSourceStatus Ready = new(Values.Ready);

    public static readonly KnowledgeSourceStatus Error = new(Values.Error);

    public KnowledgeSourceStatus(string value)
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
    public static KnowledgeSourceStatus FromCustom(string value)
    {
        return new KnowledgeSourceStatus(value);
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

    public static bool operator ==(KnowledgeSourceStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeSourceStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeSourceStatus value) => value.Value;

    public static explicit operator KnowledgeSourceStatus(string value) => new(value);

    internal class KnowledgeSourceStatusSerializer : JsonConverter<KnowledgeSourceStatus>
    {
        public override KnowledgeSourceStatus Read(
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
            return new KnowledgeSourceStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeSourceStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeSourceStatus ReadAsPropertyName(
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
            return new KnowledgeSourceStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeSourceStatus value,
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
        public const string Processing = "processing";

        public const string Ready = "ready";

        public const string Error = "error";
    }
}
