using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AsrProvider.AsrProviderSerializer))]
[Serializable]
public readonly record struct AsrProvider : IStringEnum
{
    public static readonly AsrProvider Elevenlabs = new(Values.Elevenlabs);

    public static readonly AsrProvider ScribeRealtime = new(Values.ScribeRealtime);

    public static readonly AsrProvider ScribeV2Turbo = new(Values.ScribeV2Turbo);

    public AsrProvider(string value)
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
    public static AsrProvider FromCustom(string value)
    {
        return new AsrProvider(value);
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

    public static bool operator ==(AsrProvider value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AsrProvider value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AsrProvider value) => value.Value;

    public static explicit operator AsrProvider(string value) => new(value);

    internal class AsrProviderSerializer : JsonConverter<AsrProvider>
    {
        public override AsrProvider Read(
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
            return new AsrProvider(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AsrProvider value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AsrProvider ReadAsPropertyName(
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
            return new AsrProvider(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AsrProvider value,
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
        public const string Elevenlabs = "elevenlabs";

        public const string ScribeRealtime = "scribe_realtime";

        public const string ScribeV2Turbo = "scribe_v2_turbo";
    }
}
