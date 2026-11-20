using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceptionVertical.ReceptionVerticalSerializer))]
[Serializable]
public readonly record struct ReceptionVertical : IStringEnum
{
    public static readonly ReceptionVertical SalonBarbershop = new(Values.SalonBarbershop);

    public static readonly ReceptionVertical NailBeauty = new(Values.NailBeauty);

    public static readonly ReceptionVertical Spa = new(Values.Spa);

    public static readonly ReceptionVertical Medical = new(Values.Medical);

    public static readonly ReceptionVertical Veterinary = new(Values.Veterinary);

    public static readonly ReceptionVertical Fitness = new(Values.Fitness);

    public static readonly ReceptionVertical HomeServices = new(Values.HomeServices);

    public static readonly ReceptionVertical Photography = new(Values.Photography);

    public static readonly ReceptionVertical Consulting = new(Values.Consulting);

    public static readonly ReceptionVertical Restaurant = new(Values.Restaurant);

    public static readonly ReceptionVertical Dental = new(Values.Dental);

    public static readonly ReceptionVertical AutoService = new(Values.AutoService);

    public static readonly ReceptionVertical Tutoring = new(Values.Tutoring);

    public static readonly ReceptionVertical Legal = new(Values.Legal);

    public static readonly ReceptionVertical RealEstate = new(Values.RealEstate);

    public static readonly ReceptionVertical Other = new(Values.Other);

    public ReceptionVertical(string value)
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
    public static ReceptionVertical FromCustom(string value)
    {
        return new ReceptionVertical(value);
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

    public static bool operator ==(ReceptionVertical value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionVertical value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionVertical value) => value.Value;

    public static explicit operator ReceptionVertical(string value) => new(value);

    internal class ReceptionVerticalSerializer : JsonConverter<ReceptionVertical>
    {
        public override ReceptionVertical Read(
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
            return new ReceptionVertical(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionVertical value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionVertical ReadAsPropertyName(
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
            return new ReceptionVertical(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionVertical value,
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
        public const string SalonBarbershop = "salon_barbershop";

        public const string NailBeauty = "nail_beauty";

        public const string Spa = "spa";

        public const string Medical = "medical";

        public const string Veterinary = "veterinary";

        public const string Fitness = "fitness";

        public const string HomeServices = "home_services";

        public const string Photography = "photography";

        public const string Consulting = "consulting";

        public const string Restaurant = "restaurant";

        public const string Dental = "dental";

        public const string AutoService = "auto_service";

        public const string Tutoring = "tutoring";

        public const string Legal = "legal";

        public const string RealEstate = "real_estate";

        public const string Other = "other";
    }
}
