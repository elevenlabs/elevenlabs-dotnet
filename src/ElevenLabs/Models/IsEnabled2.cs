using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.ServiceAccounts;

[JsonConverter(typeof(IsEnabled2.IsEnabled2Serializer))]
[Serializable]
public readonly record struct IsEnabled2 : IStringEnum
{
    public static readonly IsEnabled2 NoUpdate = new(Values.NoUpdate);

    public IsEnabled2(string value)
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
    public static IsEnabled2 FromCustom(string value)
    {
        return new IsEnabled2(value);
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

    public static bool operator ==(IsEnabled2 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(IsEnabled2 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IsEnabled2 value) => value.Value;

    public static explicit operator IsEnabled2(string value) => new(value);

    internal class IsEnabled2Serializer : JsonConverter<IsEnabled2>
    {
        public override IsEnabled2 Read(
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
            return new IsEnabled2(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IsEnabled2 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IsEnabled2 ReadAsPropertyName(
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
            return new IsEnabled2(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IsEnabled2 value,
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
        public const string NoUpdate = "no_update";
    }
}
