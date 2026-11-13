using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Lifecycle status of the project: `queued` before the source is picked up, `preparing` while it is transcribed, `ready` once transcription is done and language targets can start, or `failed`. A project is never reported as `processing` — that value belongs to language targets.</summary>
[JsonConverter(typeof(DubbingProjectResponseStatus.DubbingProjectResponseStatusSerializer))]
[Serializable]
public readonly record struct DubbingProjectResponseStatus : IStringEnum
{
    public static readonly DubbingProjectResponseStatus Queued = new(Values.Queued);

    public static readonly DubbingProjectResponseStatus Preparing = new(Values.Preparing);

    public static readonly DubbingProjectResponseStatus Processing = new(Values.Processing);

    public static readonly DubbingProjectResponseStatus Ready = new(Values.Ready);

    public static readonly DubbingProjectResponseStatus Failed = new(Values.Failed);

    public DubbingProjectResponseStatus(string value)
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
    public static DubbingProjectResponseStatus FromCustom(string value)
    {
        return new DubbingProjectResponseStatus(value);
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

    public static bool operator ==(DubbingProjectResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingProjectResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingProjectResponseStatus value) => value.Value;

    public static explicit operator DubbingProjectResponseStatus(string value) => new(value);

    internal class DubbingProjectResponseStatusSerializer
        : JsonConverter<DubbingProjectResponseStatus>
    {
        public override DubbingProjectResponseStatus Read(
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
            return new DubbingProjectResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingProjectResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingProjectResponseStatus ReadAsPropertyName(
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
            return new DubbingProjectResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingProjectResponseStatus value,
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

        public const string Preparing = "preparing";

        public const string Processing = "processing";

        public const string Ready = "ready";

        public const string Failed = "failed";
    }
}
