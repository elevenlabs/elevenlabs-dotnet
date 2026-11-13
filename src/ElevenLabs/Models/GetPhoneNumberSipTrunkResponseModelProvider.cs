using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Phone provider</summary>
[JsonConverter(
    typeof(GetPhoneNumberSipTrunkResponseModelProvider.GetPhoneNumberSipTrunkResponseModelProviderSerializer)
)]
[Serializable]
public readonly record struct GetPhoneNumberSipTrunkResponseModelProvider : IStringEnum
{
    public static readonly GetPhoneNumberSipTrunkResponseModelProvider SipTrunk = new(
        Values.SipTrunk
    );

    public GetPhoneNumberSipTrunkResponseModelProvider(string value)
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
    public static GetPhoneNumberSipTrunkResponseModelProvider FromCustom(string value)
    {
        return new GetPhoneNumberSipTrunkResponseModelProvider(value);
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

    public static bool operator ==(
        GetPhoneNumberSipTrunkResponseModelProvider value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPhoneNumberSipTrunkResponseModelProvider value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetPhoneNumberSipTrunkResponseModelProvider value) =>
        value.Value;

    public static explicit operator GetPhoneNumberSipTrunkResponseModelProvider(string value) =>
        new(value);

    internal class GetPhoneNumberSipTrunkResponseModelProviderSerializer
        : JsonConverter<GetPhoneNumberSipTrunkResponseModelProvider>
    {
        public override GetPhoneNumberSipTrunkResponseModelProvider Read(
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
            return new GetPhoneNumberSipTrunkResponseModelProvider(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPhoneNumberSipTrunkResponseModelProvider value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPhoneNumberSipTrunkResponseModelProvider ReadAsPropertyName(
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
            return new GetPhoneNumberSipTrunkResponseModelProvider(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPhoneNumberSipTrunkResponseModelProvider value,
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
        public const string SipTrunk = "sip_trunk";
    }
}
