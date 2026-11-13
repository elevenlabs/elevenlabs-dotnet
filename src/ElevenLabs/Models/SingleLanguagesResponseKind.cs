using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Indicates this response contains single languages (not source-to-destination pairs).</summary>
[JsonConverter(typeof(SingleLanguagesResponseKind.SingleLanguagesResponseKindSerializer))]
[Serializable]
public readonly record struct SingleLanguagesResponseKind : IStringEnum
{
    public static readonly SingleLanguagesResponseKind Single = new(Values.Single);

    public SingleLanguagesResponseKind(string value)
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
    public static SingleLanguagesResponseKind FromCustom(string value)
    {
        return new SingleLanguagesResponseKind(value);
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

    public static bool operator ==(SingleLanguagesResponseKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SingleLanguagesResponseKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SingleLanguagesResponseKind value) => value.Value;

    public static explicit operator SingleLanguagesResponseKind(string value) => new(value);

    internal class SingleLanguagesResponseKindSerializer
        : JsonConverter<SingleLanguagesResponseKind>
    {
        public override SingleLanguagesResponseKind Read(
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
            return new SingleLanguagesResponseKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SingleLanguagesResponseKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SingleLanguagesResponseKind ReadAsPropertyName(
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
            return new SingleLanguagesResponseKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SingleLanguagesResponseKind value,
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
        public const string Single = "single";
    }
}
