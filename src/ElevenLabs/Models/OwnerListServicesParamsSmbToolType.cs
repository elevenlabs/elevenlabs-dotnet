using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(OwnerListServicesParamsSmbToolType.OwnerListServicesParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct OwnerListServicesParamsSmbToolType : IStringEnum
{
    public static readonly OwnerListServicesParamsSmbToolType OwnerListServices = new(
        Values.OwnerListServices
    );

    public OwnerListServicesParamsSmbToolType(string value)
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
    public static OwnerListServicesParamsSmbToolType FromCustom(string value)
    {
        return new OwnerListServicesParamsSmbToolType(value);
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

    public static bool operator ==(OwnerListServicesParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OwnerListServicesParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OwnerListServicesParamsSmbToolType value) => value.Value;

    public static explicit operator OwnerListServicesParamsSmbToolType(string value) => new(value);

    internal class OwnerListServicesParamsSmbToolTypeSerializer
        : JsonConverter<OwnerListServicesParamsSmbToolType>
    {
        public override OwnerListServicesParamsSmbToolType Read(
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
            return new OwnerListServicesParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OwnerListServicesParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OwnerListServicesParamsSmbToolType ReadAsPropertyName(
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
            return new OwnerListServicesParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OwnerListServicesParamsSmbToolType value,
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
        public const string OwnerListServices = "owner_list_services";
    }
}
