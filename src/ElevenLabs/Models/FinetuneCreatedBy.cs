using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Music;

[JsonConverter(typeof(FinetuneCreatedBy.FinetuneCreatedBySerializer))]
[Serializable]
public readonly record struct FinetuneCreatedBy : IStringEnum
{
    public static readonly FinetuneCreatedBy Self = new(Values.Self);

    public static readonly FinetuneCreatedBy Workspace = new(Values.Workspace);

    public static readonly FinetuneCreatedBy Elevenlabs = new(Values.Elevenlabs);

    public FinetuneCreatedBy(string value)
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
    public static FinetuneCreatedBy FromCustom(string value)
    {
        return new FinetuneCreatedBy(value);
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

    public static bool operator ==(FinetuneCreatedBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FinetuneCreatedBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FinetuneCreatedBy value) => value.Value;

    public static explicit operator FinetuneCreatedBy(string value) => new(value);

    internal class FinetuneCreatedBySerializer : JsonConverter<FinetuneCreatedBy>
    {
        public override FinetuneCreatedBy Read(
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
            return new FinetuneCreatedBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FinetuneCreatedBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FinetuneCreatedBy ReadAsPropertyName(
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
            return new FinetuneCreatedBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FinetuneCreatedBy value,
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
        public const string Self = "self";

        public const string Workspace = "workspace";

        public const string Elevenlabs = "elevenlabs";
    }
}
