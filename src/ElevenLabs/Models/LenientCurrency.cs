using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LenientCurrency.LenientCurrencySerializer))]
[Serializable]
public readonly record struct LenientCurrency : IStringEnum
{
    public static readonly LenientCurrency Usd = new(Values.Usd);

    public static readonly LenientCurrency Eur = new(Values.Eur);

    public static readonly LenientCurrency Gbp = new(Values.Gbp);

    public static readonly LenientCurrency Pln = new(Values.Pln);

    public static readonly LenientCurrency Cad = new(Values.Cad);

    public static readonly LenientCurrency Aud = new(Values.Aud);

    public static readonly LenientCurrency Chf = new(Values.Chf);

    public static readonly LenientCurrency Sek = new(Values.Sek);

    public static readonly LenientCurrency Nok = new(Values.Nok);

    public static readonly LenientCurrency Dkk = new(Values.Dkk);

    public static readonly LenientCurrency Isk = new(Values.Isk);

    public static readonly LenientCurrency Czk = new(Values.Czk);

    public static readonly LenientCurrency Huf = new(Values.Huf);

    public static readonly LenientCurrency Ron = new(Values.Ron);

    public static readonly LenientCurrency Bgn = new(Values.Bgn);

    public static readonly LenientCurrency Jpy = new(Values.Jpy);

    public static readonly LenientCurrency Cny = new(Values.Cny);

    public static readonly LenientCurrency Twd = new(Values.Twd);

    public static readonly LenientCurrency Inr = new(Values.Inr);

    public static readonly LenientCurrency Brl = new(Values.Brl);

    public static readonly LenientCurrency Mxn = new(Values.Mxn);

    public static readonly LenientCurrency Krw = new(Values.Krw);

    public static readonly LenientCurrency Sgd = new(Values.Sgd);

    public static readonly LenientCurrency Hkd = new(Values.Hkd);

    public static readonly LenientCurrency Nzd = new(Values.Nzd);

    public static readonly LenientCurrency Zar = new(Values.Zar);

    public static readonly LenientCurrency Aed = new(Values.Aed);

    public static readonly LenientCurrency Sar = new(Values.Sar);

    public static readonly LenientCurrency Qar = new(Values.Qar);

    public static readonly LenientCurrency Kwd = new(Values.Kwd);

    public static readonly LenientCurrency Ils = new(Values.Ils);

    public static readonly LenientCurrency Try = new(Values.Try);

    public static readonly LenientCurrency Thb = new(Values.Thb);

    public static readonly LenientCurrency Idr = new(Values.Idr);

    public static readonly LenientCurrency Myr = new(Values.Myr);

    public static readonly LenientCurrency Php = new(Values.Php);

    public static readonly LenientCurrency Vnd = new(Values.Vnd);

    public static readonly LenientCurrency Bdt = new(Values.Bdt);

    public static readonly LenientCurrency Rub = new(Values.Rub);

    public static readonly LenientCurrency Uah = new(Values.Uah);

    public static readonly LenientCurrency Clp = new(Values.Clp);

    public static readonly LenientCurrency Cop = new(Values.Cop);

    public static readonly LenientCurrency Ars = new(Values.Ars);

    public static readonly LenientCurrency Pen = new(Values.Pen);

    public static readonly LenientCurrency Egp = new(Values.Egp);

    public static readonly LenientCurrency Ngn = new(Values.Ngn);

    public static readonly LenientCurrency Kes = new(Values.Kes);

    public static readonly LenientCurrency Pkr = new(Values.Pkr);

    public static readonly LenientCurrency Gel = new(Values.Gel);

    public LenientCurrency(string value)
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
    public static LenientCurrency FromCustom(string value)
    {
        return new LenientCurrency(value);
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

    public static bool operator ==(LenientCurrency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LenientCurrency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LenientCurrency value) => value.Value;

    public static explicit operator LenientCurrency(string value) => new(value);

    internal class LenientCurrencySerializer : JsonConverter<LenientCurrency>
    {
        public override LenientCurrency Read(
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
            return new LenientCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LenientCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LenientCurrency ReadAsPropertyName(
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
            return new LenientCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LenientCurrency value,
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
        public const string Usd = "USD";

        public const string Eur = "EUR";

        public const string Gbp = "GBP";

        public const string Pln = "PLN";

        public const string Cad = "CAD";

        public const string Aud = "AUD";

        public const string Chf = "CHF";

        public const string Sek = "SEK";

        public const string Nok = "NOK";

        public const string Dkk = "DKK";

        public const string Isk = "ISK";

        public const string Czk = "CZK";

        public const string Huf = "HUF";

        public const string Ron = "RON";

        public const string Bgn = "BGN";

        public const string Jpy = "JPY";

        public const string Cny = "CNY";

        public const string Twd = "TWD";

        public const string Inr = "INR";

        public const string Brl = "BRL";

        public const string Mxn = "MXN";

        public const string Krw = "KRW";

        public const string Sgd = "SGD";

        public const string Hkd = "HKD";

        public const string Nzd = "NZD";

        public const string Zar = "ZAR";

        public const string Aed = "AED";

        public const string Sar = "SAR";

        public const string Qar = "QAR";

        public const string Kwd = "KWD";

        public const string Ils = "ILS";

        public const string Try = "TRY";

        public const string Thb = "THB";

        public const string Idr = "IDR";

        public const string Myr = "MYR";

        public const string Php = "PHP";

        public const string Vnd = "VND";

        public const string Bdt = "BDT";

        public const string Rub = "RUB";

        public const string Uah = "UAH";

        public const string Clp = "CLP";

        public const string Cop = "COP";

        public const string Ars = "ARS";

        public const string Pen = "PEN";

        public const string Egp = "EGP";

        public const string Ngn = "NGN";

        public const string Kes = "KES";

        public const string Pkr = "PKR";

        public const string Gel = "GEL";
    }
}
