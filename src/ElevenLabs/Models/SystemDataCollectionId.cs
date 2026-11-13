using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SystemDataCollectionId.SystemDataCollectionIdSerializer))]
[Serializable]
public readonly record struct SystemDataCollectionId : IStringEnum
{
    public static readonly SystemDataCollectionId SystemDataCollectionTopic = new(
        Values.SystemDataCollectionTopic
    );

    public SystemDataCollectionId(string value)
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
    public static SystemDataCollectionId FromCustom(string value)
    {
        return new SystemDataCollectionId(value);
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

    public static bool operator ==(SystemDataCollectionId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SystemDataCollectionId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SystemDataCollectionId value) => value.Value;

    public static explicit operator SystemDataCollectionId(string value) => new(value);

    internal class SystemDataCollectionIdSerializer : JsonConverter<SystemDataCollectionId>
    {
        public override SystemDataCollectionId Read(
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
            return new SystemDataCollectionId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SystemDataCollectionId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SystemDataCollectionId ReadAsPropertyName(
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
            return new SystemDataCollectionId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SystemDataCollectionId value,
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
        public const string SystemDataCollectionTopic = "__system_data_collection_topic";
    }
}
