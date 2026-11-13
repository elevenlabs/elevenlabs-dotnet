using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Music;

[JsonConverter(typeof(FinetuneVisibility.FinetuneVisibilitySerializer))]
[Serializable]
public readonly record struct FinetuneVisibility : IStringEnum
{
    public static readonly FinetuneVisibility Private = new(Values.Private);

    public static readonly FinetuneVisibility Workspace = new(Values.Workspace);

    public static readonly FinetuneVisibility Public = new(Values.Public);

    public FinetuneVisibility(string value)
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
    public static FinetuneVisibility FromCustom(string value)
    {
        return new FinetuneVisibility(value);
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

    public static bool operator ==(FinetuneVisibility value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FinetuneVisibility value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FinetuneVisibility value) => value.Value;

    public static explicit operator FinetuneVisibility(string value) => new(value);

    internal class FinetuneVisibilitySerializer : JsonConverter<FinetuneVisibility>
    {
        public override FinetuneVisibility Read(
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
            return new FinetuneVisibility(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FinetuneVisibility value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FinetuneVisibility ReadAsPropertyName(
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
            return new FinetuneVisibility(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FinetuneVisibility value,
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
        public const string Private = "private";

        public const string Workspace = "workspace";

        public const string Public = "public";
    }
}
