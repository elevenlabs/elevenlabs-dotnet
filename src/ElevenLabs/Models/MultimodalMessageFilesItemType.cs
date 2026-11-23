using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MultimodalMessageFilesItemType.MultimodalMessageFilesItemTypeSerializer))]
[Serializable]
public readonly record struct MultimodalMessageFilesItemType : IStringEnum
{
    public static readonly MultimodalMessageFilesItemType FileInput = new(Values.FileInput);

    public MultimodalMessageFilesItemType(string value)
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
    public static MultimodalMessageFilesItemType FromCustom(string value)
    {
        return new MultimodalMessageFilesItemType(value);
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

    public static bool operator ==(MultimodalMessageFilesItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MultimodalMessageFilesItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MultimodalMessageFilesItemType value) => value.Value;

    public static explicit operator MultimodalMessageFilesItemType(string value) => new(value);

    internal class MultimodalMessageFilesItemTypeSerializer
        : JsonConverter<MultimodalMessageFilesItemType>
    {
        public override MultimodalMessageFilesItemType Read(
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
            return new MultimodalMessageFilesItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MultimodalMessageFilesItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MultimodalMessageFilesItemType ReadAsPropertyName(
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
            return new MultimodalMessageFilesItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MultimodalMessageFilesItemType value,
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
        public const string FileInput = "file_input";
    }
}
