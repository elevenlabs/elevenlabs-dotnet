using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Currency code for all prices (ISO 4217)</summary>
[JsonConverter(
    typeof(ReceptionAgentInfoResponseCurrency.ReceptionAgentInfoResponseCurrencySerializer)
)]
[Serializable]
public readonly record struct ReceptionAgentInfoResponseCurrency : IStringEnum
{
    public static readonly ReceptionAgentInfoResponseCurrency Usd = new(Values.Usd);

    public static readonly ReceptionAgentInfoResponseCurrency Eur = new(Values.Eur);

    public static readonly ReceptionAgentInfoResponseCurrency Gbp = new(Values.Gbp);

    public static readonly ReceptionAgentInfoResponseCurrency Pln = new(Values.Pln);

    public static readonly ReceptionAgentInfoResponseCurrency Cad = new(Values.Cad);

    public static readonly ReceptionAgentInfoResponseCurrency Aud = new(Values.Aud);

    public static readonly ReceptionAgentInfoResponseCurrency Chf = new(Values.Chf);

    public static readonly ReceptionAgentInfoResponseCurrency Sek = new(Values.Sek);

    public static readonly ReceptionAgentInfoResponseCurrency Nok = new(Values.Nok);

    public static readonly ReceptionAgentInfoResponseCurrency Dkk = new(Values.Dkk);

    public static readonly ReceptionAgentInfoResponseCurrency Isk = new(Values.Isk);

    public static readonly ReceptionAgentInfoResponseCurrency Czk = new(Values.Czk);

    public static readonly ReceptionAgentInfoResponseCurrency Huf = new(Values.Huf);

    public static readonly ReceptionAgentInfoResponseCurrency Ron = new(Values.Ron);

    public static readonly ReceptionAgentInfoResponseCurrency Bgn = new(Values.Bgn);

    public static readonly ReceptionAgentInfoResponseCurrency Jpy = new(Values.Jpy);

    public static readonly ReceptionAgentInfoResponseCurrency Cny = new(Values.Cny);

    public static readonly ReceptionAgentInfoResponseCurrency Twd = new(Values.Twd);

    public static readonly ReceptionAgentInfoResponseCurrency Inr = new(Values.Inr);

    public static readonly ReceptionAgentInfoResponseCurrency Brl = new(Values.Brl);

    public static readonly ReceptionAgentInfoResponseCurrency Mxn = new(Values.Mxn);

    public static readonly ReceptionAgentInfoResponseCurrency Krw = new(Values.Krw);

    public static readonly ReceptionAgentInfoResponseCurrency Sgd = new(Values.Sgd);

    public static readonly ReceptionAgentInfoResponseCurrency Hkd = new(Values.Hkd);

    public static readonly ReceptionAgentInfoResponseCurrency Nzd = new(Values.Nzd);

    public static readonly ReceptionAgentInfoResponseCurrency Zar = new(Values.Zar);

    public static readonly ReceptionAgentInfoResponseCurrency Aed = new(Values.Aed);

    public static readonly ReceptionAgentInfoResponseCurrency Sar = new(Values.Sar);

    public static readonly ReceptionAgentInfoResponseCurrency Qar = new(Values.Qar);

    public static readonly ReceptionAgentInfoResponseCurrency Kwd = new(Values.Kwd);

    public static readonly ReceptionAgentInfoResponseCurrency Ils = new(Values.Ils);

    public static readonly ReceptionAgentInfoResponseCurrency Try = new(Values.Try);

    public static readonly ReceptionAgentInfoResponseCurrency Thb = new(Values.Thb);

    public static readonly ReceptionAgentInfoResponseCurrency Idr = new(Values.Idr);

    public static readonly ReceptionAgentInfoResponseCurrency Myr = new(Values.Myr);

    public static readonly ReceptionAgentInfoResponseCurrency Php = new(Values.Php);

    public static readonly ReceptionAgentInfoResponseCurrency Vnd = new(Values.Vnd);

    public static readonly ReceptionAgentInfoResponseCurrency Bdt = new(Values.Bdt);

    public static readonly ReceptionAgentInfoResponseCurrency Rub = new(Values.Rub);

    public static readonly ReceptionAgentInfoResponseCurrency Uah = new(Values.Uah);

    public static readonly ReceptionAgentInfoResponseCurrency Clp = new(Values.Clp);

    public static readonly ReceptionAgentInfoResponseCurrency Cop = new(Values.Cop);

    public static readonly ReceptionAgentInfoResponseCurrency Ars = new(Values.Ars);

    public static readonly ReceptionAgentInfoResponseCurrency Pen = new(Values.Pen);

    public static readonly ReceptionAgentInfoResponseCurrency Egp = new(Values.Egp);

    public static readonly ReceptionAgentInfoResponseCurrency Ngn = new(Values.Ngn);

    public static readonly ReceptionAgentInfoResponseCurrency Kes = new(Values.Kes);

    public static readonly ReceptionAgentInfoResponseCurrency Pkr = new(Values.Pkr);

    public static readonly ReceptionAgentInfoResponseCurrency Gel = new(Values.Gel);

    public ReceptionAgentInfoResponseCurrency(string value)
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
    public static ReceptionAgentInfoResponseCurrency FromCustom(string value)
    {
        return new ReceptionAgentInfoResponseCurrency(value);
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

    public static bool operator ==(ReceptionAgentInfoResponseCurrency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionAgentInfoResponseCurrency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionAgentInfoResponseCurrency value) => value.Value;

    public static explicit operator ReceptionAgentInfoResponseCurrency(string value) => new(value);

    internal class ReceptionAgentInfoResponseCurrencySerializer
        : JsonConverter<ReceptionAgentInfoResponseCurrency>
    {
        public override ReceptionAgentInfoResponseCurrency Read(
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
            return new ReceptionAgentInfoResponseCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionAgentInfoResponseCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionAgentInfoResponseCurrency ReadAsPropertyName(
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
            return new ReceptionAgentInfoResponseCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionAgentInfoResponseCurrency value,
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
