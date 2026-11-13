using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MaxCreditLimitExtension21.MaxCreditLimitExtension21Serializer))]
[Serializable]
public readonly record struct MaxCreditLimitExtension21 : IStringEnum
{
    public static readonly MaxCreditLimitExtension21 Unlimited = new(Values.Unlimited);

    public MaxCreditLimitExtension21(string value)
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
    public static MaxCreditLimitExtension21 FromCustom(string value)
    {
        return new MaxCreditLimitExtension21(value);
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

    public static bool operator ==(MaxCreditLimitExtension21 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MaxCreditLimitExtension21 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MaxCreditLimitExtension21 value) => value.Value;

    public static explicit operator MaxCreditLimitExtension21(string value) => new(value);

    internal class MaxCreditLimitExtension21Serializer : JsonConverter<MaxCreditLimitExtension21>
    {
        public override MaxCreditLimitExtension21 Read(
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
            return new MaxCreditLimitExtension21(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MaxCreditLimitExtension21 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MaxCreditLimitExtension21 ReadAsPropertyName(
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
            return new MaxCreditLimitExtension21(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MaxCreditLimitExtension21 value,
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
