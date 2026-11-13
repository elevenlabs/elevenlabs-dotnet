using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OwnerListAssetsParamsSmbToolType.OwnerListAssetsParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct OwnerListAssetsParamsSmbToolType : IStringEnum
{
    public static readonly OwnerListAssetsParamsSmbToolType OwnerListAssets = new(
        Values.OwnerListAssets
    );

    public OwnerListAssetsParamsSmbToolType(string value)
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
    public static OwnerListAssetsParamsSmbToolType FromCustom(string value)
    {
        return new OwnerListAssetsParamsSmbToolType(value);
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

    public static bool operator ==(OwnerListAssetsParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OwnerListAssetsParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OwnerListAssetsParamsSmbToolType value) => value.Value;

    public static explicit operator OwnerListAssetsParamsSmbToolType(string value) => new(value);

    internal class OwnerListAssetsParamsSmbToolTypeSerializer
        : JsonConverter<OwnerListAssetsParamsSmbToolType>
    {
        public override OwnerListAssetsParamsSmbToolType Read(
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
            return new OwnerListAssetsParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OwnerListAssetsParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OwnerListAssetsParamsSmbToolType ReadAsPropertyName(
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
            return new OwnerListAssetsParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OwnerListAssetsParamsSmbToolType value,
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
        public const string OwnerListAssets = "owner_list_assets";
    }
}
