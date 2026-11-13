using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GenesysRegion.GenesysRegionSerializer))]
[Serializable]
public readonly record struct GenesysRegion : IStringEnum
{
    public static readonly GenesysRegion UsEast1 = new(Values.UsEast1);

    public static readonly GenesysRegion EuWest1 = new(Values.EuWest1);

    public static readonly GenesysRegion ApSoutheast2 = new(Values.ApSoutheast2);

    public static readonly GenesysRegion ApNortheast1 = new(Values.ApNortheast1);

    public static readonly GenesysRegion EuCentral1 = new(Values.EuCentral1);

    public static readonly GenesysRegion UsWest2 = new(Values.UsWest2);

    public static readonly GenesysRegion CaCentral1 = new(Values.CaCentral1);

    public static readonly GenesysRegion ApNortheast2 = new(Values.ApNortheast2);

    public static readonly GenesysRegion EuWest2 = new(Values.EuWest2);

    public static readonly GenesysRegion ApSouth1 = new(Values.ApSouth1);

    public static readonly GenesysRegion UsEast2 = new(Values.UsEast2);

    public static readonly GenesysRegion SaEast1 = new(Values.SaEast1);

    public static readonly GenesysRegion MeCentral1 = new(Values.MeCentral1);

    public static readonly GenesysRegion ApNortheast3 = new(Values.ApNortheast3);

    public static readonly GenesysRegion EuCentral2 = new(Values.EuCentral2);

    public static readonly GenesysRegion MxCentral1 = new(Values.MxCentral1);

    public static readonly GenesysRegion ApSoutheast1 = new(Values.ApSoutheast1);

    public GenesysRegion(string value)
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
    public static GenesysRegion FromCustom(string value)
    {
        return new GenesysRegion(value);
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

    public static bool operator ==(GenesysRegion value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GenesysRegion value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GenesysRegion value) => value.Value;

    public static explicit operator GenesysRegion(string value) => new(value);

    internal class GenesysRegionSerializer : JsonConverter<GenesysRegion>
    {
        public override GenesysRegion Read(
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
            return new GenesysRegion(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GenesysRegion value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GenesysRegion ReadAsPropertyName(
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
            return new GenesysRegion(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GenesysRegion value,
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
        public const string UsEast1 = "us_east_1";

        public const string EuWest1 = "eu_west_1";

        public const string ApSoutheast2 = "ap_southeast_2";

        public const string ApNortheast1 = "ap_northeast_1";

        public const string EuCentral1 = "eu_central_1";

        public const string UsWest2 = "us_west_2";

        public const string CaCentral1 = "ca_central_1";

        public const string ApNortheast2 = "ap_northeast_2";

        public const string EuWest2 = "eu_west_2";

        public const string ApSouth1 = "ap_south_1";

        public const string UsEast2 = "us_east_2";

        public const string SaEast1 = "sa_east_1";

        public const string MeCentral1 = "me_central_1";

        public const string ApNortheast3 = "ap_northeast_3";

        public const string EuCentral2 = "eu_central_2";

        public const string MxCentral1 = "mx_central_1";

        public const string ApSoutheast1 = "ap_southeast_1";
    }
}
