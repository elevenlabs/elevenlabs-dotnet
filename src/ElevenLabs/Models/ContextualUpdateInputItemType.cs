using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ContextualUpdateInputItemType.ContextualUpdateInputItemTypeSerializer))]
[Serializable]
public readonly record struct ContextualUpdateInputItemType : IStringEnum
{
    public static readonly ContextualUpdateInputItemType ContextualUpdate = new(
        Values.ContextualUpdate
    );

    public ContextualUpdateInputItemType(string value)
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
    public static ContextualUpdateInputItemType FromCustom(string value)
    {
        return new ContextualUpdateInputItemType(value);
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

    public static bool operator ==(ContextualUpdateInputItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextualUpdateInputItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextualUpdateInputItemType value) => value.Value;

    public static explicit operator ContextualUpdateInputItemType(string value) => new(value);

    internal class ContextualUpdateInputItemTypeSerializer
        : JsonConverter<ContextualUpdateInputItemType>
    {
        public override ContextualUpdateInputItemType Read(
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
            return new ContextualUpdateInputItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextualUpdateInputItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextualUpdateInputItemType ReadAsPropertyName(
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
            return new ContextualUpdateInputItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextualUpdateInputItemType value,
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
        public const string ContextualUpdate = "contextual_update";
    }
}
