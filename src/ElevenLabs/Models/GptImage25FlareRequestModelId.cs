using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(GptImage25FlareRequestModelId.GptImage25FlareRequestModelIdSerializer))]
[Serializable]
public readonly record struct GptImage25FlareRequestModelId : IStringEnum
{
    public static readonly GptImage25FlareRequestModelId GptImage25Flare = new(
        Values.GptImage25Flare
    );

    public GptImage25FlareRequestModelId(string value)
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
    public static GptImage25FlareRequestModelId FromCustom(string value)
    {
        return new GptImage25FlareRequestModelId(value);
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

    public static bool operator ==(GptImage25FlareRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage25FlareRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage25FlareRequestModelId value) => value.Value;

    public static explicit operator GptImage25FlareRequestModelId(string value) => new(value);

    internal class GptImage25FlareRequestModelIdSerializer
        : JsonConverter<GptImage25FlareRequestModelId>
    {
        public override GptImage25FlareRequestModelId Read(
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
            return new GptImage25FlareRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage25FlareRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage25FlareRequestModelId ReadAsPropertyName(
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
            return new GptImage25FlareRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage25FlareRequestModelId value,
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
        public const string GptImage25Flare = "gpt-image-2.5-flare";
    }
}
