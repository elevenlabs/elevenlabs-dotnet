using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AttachedSystemDataCollectionRefSource.AttachedSystemDataCollectionRefSourceSerializer)
)]
[Serializable]
public readonly record struct AttachedSystemDataCollectionRefSource : IStringEnum
{
    public static readonly AttachedSystemDataCollectionRefSource System = new(Values.System);

    public AttachedSystemDataCollectionRefSource(string value)
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
    public static AttachedSystemDataCollectionRefSource FromCustom(string value)
    {
        return new AttachedSystemDataCollectionRefSource(value);
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

    public static bool operator ==(AttachedSystemDataCollectionRefSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AttachedSystemDataCollectionRefSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AttachedSystemDataCollectionRefSource value) =>
        value.Value;

    public static explicit operator AttachedSystemDataCollectionRefSource(string value) =>
        new(value);

    internal class AttachedSystemDataCollectionRefSourceSerializer
        : JsonConverter<AttachedSystemDataCollectionRefSource>
    {
        public override AttachedSystemDataCollectionRefSource Read(
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
            return new AttachedSystemDataCollectionRefSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AttachedSystemDataCollectionRefSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AttachedSystemDataCollectionRefSource ReadAsPropertyName(
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
            return new AttachedSystemDataCollectionRefSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AttachedSystemDataCollectionRefSource value,
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
        public const string System = "system";
    }
}
