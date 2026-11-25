using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>What the prices are in. The same for every tier on a ladder.</summary>
[JsonConverter(typeof(ResellerTierResponseCurrency.ResellerTierResponseCurrencySerializer))]
[Serializable]
public readonly record struct ResellerTierResponseCurrency : IStringEnum
{
    public static readonly ResellerTierResponseCurrency Usd = new(Values.Usd);

    public static readonly ResellerTierResponseCurrency Eur = new(Values.Eur);

    public static readonly ResellerTierResponseCurrency Gbp = new(Values.Gbp);

    public static readonly ResellerTierResponseCurrency Pln = new(Values.Pln);

    public static readonly ResellerTierResponseCurrency Cad = new(Values.Cad);

    public static readonly ResellerTierResponseCurrency Aud = new(Values.Aud);

    public static readonly ResellerTierResponseCurrency Chf = new(Values.Chf);

    public static readonly ResellerTierResponseCurrency Sek = new(Values.Sek);

    public static readonly ResellerTierResponseCurrency Nok = new(Values.Nok);

    public static readonly ResellerTierResponseCurrency Dkk = new(Values.Dkk);

    public static readonly ResellerTierResponseCurrency Isk = new(Values.Isk);

    public static readonly ResellerTierResponseCurrency Czk = new(Values.Czk);

    public static readonly ResellerTierResponseCurrency Huf = new(Values.Huf);

    public static readonly ResellerTierResponseCurrency Ron = new(Values.Ron);

    public static readonly ResellerTierResponseCurrency Bgn = new(Values.Bgn);

    public static readonly ResellerTierResponseCurrency Jpy = new(Values.Jpy);

    public static readonly ResellerTierResponseCurrency Cny = new(Values.Cny);

    public static readonly ResellerTierResponseCurrency Twd = new(Values.Twd);

    public static readonly ResellerTierResponseCurrency Inr = new(Values.Inr);

    public static readonly ResellerTierResponseCurrency Brl = new(Values.Brl);

    public static readonly ResellerTierResponseCurrency Mxn = new(Values.Mxn);

    public static readonly ResellerTierResponseCurrency Krw = new(Values.Krw);

    public static readonly ResellerTierResponseCurrency Sgd = new(Values.Sgd);

    public static readonly ResellerTierResponseCurrency Hkd = new(Values.Hkd);

    public static readonly ResellerTierResponseCurrency Nzd = new(Values.Nzd);

    public static readonly ResellerTierResponseCurrency Zar = new(Values.Zar);

    public static readonly ResellerTierResponseCurrency Aed = new(Values.Aed);

    public static readonly ResellerTierResponseCurrency Sar = new(Values.Sar);

    public static readonly ResellerTierResponseCurrency Qar = new(Values.Qar);

    public static readonly ResellerTierResponseCurrency Kwd = new(Values.Kwd);

    public static readonly ResellerTierResponseCurrency Ils = new(Values.Ils);

    public static readonly ResellerTierResponseCurrency Try = new(Values.Try);

    public static readonly ResellerTierResponseCurrency Thb = new(Values.Thb);

    public static readonly ResellerTierResponseCurrency Idr = new(Values.Idr);

    public static readonly ResellerTierResponseCurrency Myr = new(Values.Myr);

    public static readonly ResellerTierResponseCurrency Php = new(Values.Php);

    public static readonly ResellerTierResponseCurrency Vnd = new(Values.Vnd);

    public static readonly ResellerTierResponseCurrency Bdt = new(Values.Bdt);

    public static readonly ResellerTierResponseCurrency Rub = new(Values.Rub);

    public static readonly ResellerTierResponseCurrency Uah = new(Values.Uah);

    public static readonly ResellerTierResponseCurrency Clp = new(Values.Clp);

    public static readonly ResellerTierResponseCurrency Cop = new(Values.Cop);

    public static readonly ResellerTierResponseCurrency Ars = new(Values.Ars);

    public static readonly ResellerTierResponseCurrency Pen = new(Values.Pen);

    public static readonly ResellerTierResponseCurrency Egp = new(Values.Egp);

    public static readonly ResellerTierResponseCurrency Ngn = new(Values.Ngn);

    public static readonly ResellerTierResponseCurrency Kes = new(Values.Kes);

    public static readonly ResellerTierResponseCurrency Pkr = new(Values.Pkr);

    public static readonly ResellerTierResponseCurrency Gel = new(Values.Gel);

    public ResellerTierResponseCurrency(string value)
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
    public static ResellerTierResponseCurrency FromCustom(string value)
    {
        return new ResellerTierResponseCurrency(value);
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

    public static bool operator ==(ResellerTierResponseCurrency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResellerTierResponseCurrency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResellerTierResponseCurrency value) => value.Value;

    public static explicit operator ResellerTierResponseCurrency(string value) => new(value);

    internal class ResellerTierResponseCurrencySerializer
        : JsonConverter<ResellerTierResponseCurrency>
    {
        public override ResellerTierResponseCurrency Read(
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
            return new ResellerTierResponseCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResellerTierResponseCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResellerTierResponseCurrency ReadAsPropertyName(
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
            return new ResellerTierResponseCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResellerTierResponseCurrency value,
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
