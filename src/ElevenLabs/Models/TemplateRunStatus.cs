using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Where a run, or one of its outputs, is in its lifecycle. The run's is rolled
/// up from its outputs' (``aggregate_output_statuses``). A class rather than a
/// ``Literal`` so it publishes as one named enum instead of being inlined into
/// every kind.
/// </summary>
[JsonConverter(typeof(TemplateRunStatus.TemplateRunStatusSerializer))]
[Serializable]
public readonly record struct TemplateRunStatus : IStringEnum
{
    public static readonly TemplateRunStatus Pending = new(Values.Pending);

    public static readonly TemplateRunStatus Generating = new(Values.Generating);

    public static readonly TemplateRunStatus Completed = new(Values.Completed);

    public static readonly TemplateRunStatus Failed = new(Values.Failed);

    public TemplateRunStatus(string value)
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
    public static TemplateRunStatus FromCustom(string value)
    {
        return new TemplateRunStatus(value);
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

    public static bool operator ==(TemplateRunStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateRunStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateRunStatus value) => value.Value;

    public static explicit operator TemplateRunStatus(string value) => new(value);

    internal class TemplateRunStatusSerializer : JsonConverter<TemplateRunStatus>
    {
        public override TemplateRunStatus Read(
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
            return new TemplateRunStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateRunStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateRunStatus ReadAsPropertyName(
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
            return new TemplateRunStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateRunStatus value,
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
        public const string Pending = "pending";

        public const string Generating = "generating";

        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
