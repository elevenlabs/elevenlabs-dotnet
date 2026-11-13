using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Single-word processing step shown in the UI status badge.</summary>
[JsonConverter(typeof(ProcessingProgress.ProcessingProgressSerializer))]
[Serializable]
public readonly record struct ProcessingProgress : IStringEnum
{
    public static readonly ProcessingProgress Converting = new(Values.Converting);

    public static readonly ProcessingProgress Storing = new(Values.Storing);

    public static readonly ProcessingProgress Scraping = new(Values.Scraping);

    public static readonly ProcessingProgress Crawling = new(Values.Crawling);

    public static readonly ProcessingProgress Extracting = new(Values.Extracting);

    public ProcessingProgress(string value)
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
    public static ProcessingProgress FromCustom(string value)
    {
        return new ProcessingProgress(value);
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

    public static bool operator ==(ProcessingProgress value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProcessingProgress value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProcessingProgress value) => value.Value;

    public static explicit operator ProcessingProgress(string value) => new(value);

    internal class ProcessingProgressSerializer : JsonConverter<ProcessingProgress>
    {
        public override ProcessingProgress Read(
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
            return new ProcessingProgress(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProcessingProgress value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProcessingProgress ReadAsPropertyName(
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
            return new ProcessingProgress(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProcessingProgress value,
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
        public const string Converting = "Converting";

        public const string Storing = "Storing";

        public const string Scraping = "Scraping";

        public const string Crawling = "Crawling";

        public const string Extracting = "Extracting";
    }
}
