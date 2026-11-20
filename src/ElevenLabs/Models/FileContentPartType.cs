using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(FileContentPartType.FileContentPartTypeSerializer))]
[Serializable]
public readonly record struct FileContentPartType : IStringEnum
{
    public static readonly FileContentPartType File = new(Values.File);

    public FileContentPartType(string value)
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
    public static FileContentPartType FromCustom(string value)
    {
        return new FileContentPartType(value);
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

    public static bool operator ==(FileContentPartType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FileContentPartType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FileContentPartType value) => value.Value;

    public static explicit operator FileContentPartType(string value) => new(value);

    internal class FileContentPartTypeSerializer : JsonConverter<FileContentPartType>
    {
        public override FileContentPartType Read(
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
            return new FileContentPartType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FileContentPartType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FileContentPartType ReadAsPropertyName(
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
            return new FileContentPartType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FileContentPartType value,
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
        public const string File = "file";
    }
}
