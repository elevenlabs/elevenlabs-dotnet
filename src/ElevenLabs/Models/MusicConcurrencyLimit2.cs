using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.ServiceAccounts;

[JsonConverter(typeof(MusicConcurrencyLimit2.MusicConcurrencyLimit2Serializer))]
[Serializable]
public readonly record struct MusicConcurrencyLimit2 : IStringEnum
{
    public static readonly MusicConcurrencyLimit2 Clear = new(Values.Clear);

    public static readonly MusicConcurrencyLimit2 NoUpdate = new(Values.NoUpdate);

    public MusicConcurrencyLimit2(string value)
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
    public static MusicConcurrencyLimit2 FromCustom(string value)
    {
        return new MusicConcurrencyLimit2(value);
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

    public static bool operator ==(MusicConcurrencyLimit2 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicConcurrencyLimit2 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicConcurrencyLimit2 value) => value.Value;

    public static explicit operator MusicConcurrencyLimit2(string value) => new(value);

    internal class MusicConcurrencyLimit2Serializer : JsonConverter<MusicConcurrencyLimit2>
    {
        public override MusicConcurrencyLimit2 Read(
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
            return new MusicConcurrencyLimit2(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicConcurrencyLimit2 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicConcurrencyLimit2 ReadAsPropertyName(
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
            return new MusicConcurrencyLimit2(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicConcurrencyLimit2 value,
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
        public const string Clear = "clear";

        public const string NoUpdate = "no_update";
    }
}
