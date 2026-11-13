using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(RagIndexStatus.RagIndexStatusSerializer))]
[Serializable]
public readonly record struct RagIndexStatus : IStringEnum
{
    public static readonly RagIndexStatus New = new(Values.New);

    public static readonly RagIndexStatus Created = new(Values.Created);

    public static readonly RagIndexStatus Processing = new(Values.Processing);

    public static readonly RagIndexStatus Failed = new(Values.Failed);

    public static readonly RagIndexStatus Succeeded = new(Values.Succeeded);

    public static readonly RagIndexStatus RagLimitExceeded = new(Values.RagLimitExceeded);

    public static readonly RagIndexStatus DocumentTooSmall = new(Values.DocumentTooSmall);

    public static readonly RagIndexStatus CannotIndexFolder = new(Values.CannotIndexFolder);

    public RagIndexStatus(string value)
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
    public static RagIndexStatus FromCustom(string value)
    {
        return new RagIndexStatus(value);
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

    public static bool operator ==(RagIndexStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RagIndexStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RagIndexStatus value) => value.Value;

    public static explicit operator RagIndexStatus(string value) => new(value);

    internal class RagIndexStatusSerializer : JsonConverter<RagIndexStatus>
    {
        public override RagIndexStatus Read(
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
            return new RagIndexStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RagIndexStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RagIndexStatus ReadAsPropertyName(
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
            return new RagIndexStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RagIndexStatus value,
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
        public const string New = "new";

        public const string Created = "created";

        public const string Processing = "processing";

        public const string Failed = "failed";

        public const string Succeeded = "succeeded";

        public const string RagLimitExceeded = "rag_limit_exceeded";

        public const string DocumentTooSmall = "document_too_small";

        public const string CannotIndexFolder = "cannot_index_folder";
    }
}
