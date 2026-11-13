using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Lifecycle status: `queued` (waiting on the project to be ready, or on a worker), `processing` while it is being dubbed, `completed` once its output is available, `stale` when the transcript changed after the output was produced, or `failed`.</summary>
[JsonConverter(typeof(DubbingLanguageResponseStatus.DubbingLanguageResponseStatusSerializer))]
[Serializable]
public readonly record struct DubbingLanguageResponseStatus : IStringEnum
{
    public static readonly DubbingLanguageResponseStatus Queued = new(Values.Queued);

    public static readonly DubbingLanguageResponseStatus Processing = new(Values.Processing);

    public static readonly DubbingLanguageResponseStatus Completed = new(Values.Completed);

    public static readonly DubbingLanguageResponseStatus Stale = new(Values.Stale);

    public static readonly DubbingLanguageResponseStatus Failed = new(Values.Failed);

    public DubbingLanguageResponseStatus(string value)
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
    public static DubbingLanguageResponseStatus FromCustom(string value)
    {
        return new DubbingLanguageResponseStatus(value);
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

    public static bool operator ==(DubbingLanguageResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingLanguageResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingLanguageResponseStatus value) => value.Value;

    public static explicit operator DubbingLanguageResponseStatus(string value) => new(value);

    internal class DubbingLanguageResponseStatusSerializer
        : JsonConverter<DubbingLanguageResponseStatus>
    {
        public override DubbingLanguageResponseStatus Read(
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
            return new DubbingLanguageResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingLanguageResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingLanguageResponseStatus ReadAsPropertyName(
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
            return new DubbingLanguageResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingLanguageResponseStatus value,
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

        public const string Processing = "processing";

        public const string Completed = "completed";

        public const string Stale = "stale";

        public const string Failed = "failed";
    }
}
