using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(ToolSortBy.ToolSortBySerializer))]
[Serializable]
public readonly record struct ToolSortBy : IStringEnum
{
    public static readonly ToolSortBy Name = new(Values.Name);

    public static readonly ToolSortBy CreatedAt = new(Values.CreatedAt);

    public ToolSortBy(string value)
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
    public static ToolSortBy FromCustom(string value)
    {
        return new ToolSortBy(value);
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

    public static bool operator ==(ToolSortBy value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(ToolSortBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolSortBy value) => value.Value;

    public static explicit operator ToolSortBy(string value) => new(value);

    internal class ToolSortBySerializer : JsonConverter<ToolSortBy>
    {
        public override ToolSortBy Read(
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
            return new ToolSortBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolSortBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolSortBy ReadAsPropertyName(
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
            return new ToolSortBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolSortBy value,
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
        public const string Name = "name";

        public const string CreatedAt = "created_at";
    }
}
