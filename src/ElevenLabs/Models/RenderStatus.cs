using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(RenderStatus.RenderStatusSerializer))]
[Serializable]
public readonly record struct RenderStatus : IStringEnum
{
    public static readonly RenderStatus Complete = new(Values.Complete);

    public static readonly RenderStatus Processing = new(Values.Processing);

    public static readonly RenderStatus Failed = new(Values.Failed);

    public RenderStatus(string value)
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
    public static RenderStatus FromCustom(string value)
    {
        return new RenderStatus(value);
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

    public static bool operator ==(RenderStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RenderStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RenderStatus value) => value.Value;

    public static explicit operator RenderStatus(string value) => new(value);

    internal class RenderStatusSerializer : JsonConverter<RenderStatus>
    {
        public override RenderStatus Read(
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
            return new RenderStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RenderStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RenderStatus ReadAsPropertyName(
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
            return new RenderStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RenderStatus value,
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
        public const string Complete = "complete";

        public const string Processing = "processing";

        public const string Failed = "failed";
    }
}
