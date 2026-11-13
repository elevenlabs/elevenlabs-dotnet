using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.ServiceAccounts;

[JsonConverter(typeof(ThirdPartyDisableAllowed2.ThirdPartyDisableAllowed2Serializer))]
[Serializable]
public readonly record struct ThirdPartyDisableAllowed2 : IStringEnum
{
    public static readonly ThirdPartyDisableAllowed2 Clear = new(Values.Clear);

    public static readonly ThirdPartyDisableAllowed2 NoUpdate = new(Values.NoUpdate);

    public ThirdPartyDisableAllowed2(string value)
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
    public static ThirdPartyDisableAllowed2 FromCustom(string value)
    {
        return new ThirdPartyDisableAllowed2(value);
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

    public static bool operator ==(ThirdPartyDisableAllowed2 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ThirdPartyDisableAllowed2 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ThirdPartyDisableAllowed2 value) => value.Value;

    public static explicit operator ThirdPartyDisableAllowed2(string value) => new(value);

    internal class ThirdPartyDisableAllowed2Serializer : JsonConverter<ThirdPartyDisableAllowed2>
    {
        public override ThirdPartyDisableAllowed2 Read(
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
            return new ThirdPartyDisableAllowed2(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ThirdPartyDisableAllowed2 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ThirdPartyDisableAllowed2 ReadAsPropertyName(
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
            return new ThirdPartyDisableAllowed2(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ThirdPartyDisableAllowed2 value,
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
