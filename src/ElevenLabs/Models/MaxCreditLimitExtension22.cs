using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MaxCreditLimitExtension22.MaxCreditLimitExtension22Serializer))]
[Serializable]
public readonly record struct MaxCreditLimitExtension22 : IStringEnum
{
    public static readonly MaxCreditLimitExtension22 Unlimited = new(Values.Unlimited);

    public MaxCreditLimitExtension22(string value)
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
    public static MaxCreditLimitExtension22 FromCustom(string value)
    {
        return new MaxCreditLimitExtension22(value);
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

    public static bool operator ==(MaxCreditLimitExtension22 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MaxCreditLimitExtension22 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MaxCreditLimitExtension22 value) => value.Value;

    public static explicit operator MaxCreditLimitExtension22(string value) => new(value);

    internal class MaxCreditLimitExtension22Serializer : JsonConverter<MaxCreditLimitExtension22>
    {
        public override MaxCreditLimitExtension22 Read(
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
            return new MaxCreditLimitExtension22(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MaxCreditLimitExtension22 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MaxCreditLimitExtension22 ReadAsPropertyName(
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
            return new MaxCreditLimitExtension22(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MaxCreditLimitExtension22 value,
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
        public const string Unlimited = "unlimited";
    }
}
