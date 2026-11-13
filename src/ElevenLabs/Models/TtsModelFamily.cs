using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TtsModelFamily.TtsModelFamilySerializer))]
[Serializable]
public readonly record struct TtsModelFamily : IStringEnum
{
    public static readonly TtsModelFamily Turbo = new(Values.Turbo);

    public static readonly TtsModelFamily Flash = new(Values.Flash);

    public static readonly TtsModelFamily Multilingual = new(Values.Multilingual);

    public static readonly TtsModelFamily V3Conversational = new(Values.V3Conversational);

    public static readonly TtsModelFamily V4 = new(Values.V4);

    public static readonly TtsModelFamily V4Turbo = new(Values.V4Turbo);

    public TtsModelFamily(string value)
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
    public static TtsModelFamily FromCustom(string value)
    {
        return new TtsModelFamily(value);
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

    public static bool operator ==(TtsModelFamily value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TtsModelFamily value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TtsModelFamily value) => value.Value;

    public static explicit operator TtsModelFamily(string value) => new(value);

    internal class TtsModelFamilySerializer : JsonConverter<TtsModelFamily>
    {
        public override TtsModelFamily Read(
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
            return new TtsModelFamily(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TtsModelFamily value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TtsModelFamily ReadAsPropertyName(
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
            return new TtsModelFamily(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TtsModelFamily value,
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
        public const string Turbo = "turbo";

        public const string Flash = "flash";

        public const string Multilingual = "multilingual";

        public const string V3Conversational = "v3_conversational";

        public const string V4 = "v4";

        public const string V4Turbo = "v4_turbo";
    }
}
