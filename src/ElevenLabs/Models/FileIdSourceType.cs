using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(FileIdSourceType.FileIdSourceTypeSerializer))]
[Serializable]
public readonly record struct FileIdSourceType : IStringEnum
{
    public static readonly FileIdSourceType FileId = new(Values.FileId);

    public FileIdSourceType(string value)
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
    public static FileIdSourceType FromCustom(string value)
    {
        return new FileIdSourceType(value);
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

    public static bool operator ==(FileIdSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FileIdSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FileIdSourceType value) => value.Value;

    public static explicit operator FileIdSourceType(string value) => new(value);

    internal class FileIdSourceTypeSerializer : JsonConverter<FileIdSourceType>
    {
        public override FileIdSourceType Read(
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
            return new FileIdSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FileIdSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FileIdSourceType ReadAsPropertyName(
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
            return new FileIdSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FileIdSourceType value,
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
        public const string FileId = "file_id";
    }
}
