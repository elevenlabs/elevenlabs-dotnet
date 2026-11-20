using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Reception;

/// <summary>Currency code for all prices (ISO 4217)</summary>
[JsonConverter(
    typeof(ReceptionUpdateAgentInfoRequestCurrency.ReceptionUpdateAgentInfoRequestCurrencySerializer)
)]
[Serializable]
public readonly record struct ReceptionUpdateAgentInfoRequestCurrency : IStringEnum
{
    public static readonly ReceptionUpdateAgentInfoRequestCurrency Usd = new(Values.Usd);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Eur = new(Values.Eur);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Gbp = new(Values.Gbp);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Pln = new(Values.Pln);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Cad = new(Values.Cad);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Aud = new(Values.Aud);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Chf = new(Values.Chf);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Sek = new(Values.Sek);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Nok = new(Values.Nok);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Dkk = new(Values.Dkk);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Isk = new(Values.Isk);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Czk = new(Values.Czk);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Huf = new(Values.Huf);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Ron = new(Values.Ron);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Bgn = new(Values.Bgn);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Jpy = new(Values.Jpy);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Cny = new(Values.Cny);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Twd = new(Values.Twd);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Inr = new(Values.Inr);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Brl = new(Values.Brl);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Mxn = new(Values.Mxn);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Krw = new(Values.Krw);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Sgd = new(Values.Sgd);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Hkd = new(Values.Hkd);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Nzd = new(Values.Nzd);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Zar = new(Values.Zar);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Aed = new(Values.Aed);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Sar = new(Values.Sar);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Qar = new(Values.Qar);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Kwd = new(Values.Kwd);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Ils = new(Values.Ils);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Try = new(Values.Try);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Thb = new(Values.Thb);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Idr = new(Values.Idr);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Myr = new(Values.Myr);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Php = new(Values.Php);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Vnd = new(Values.Vnd);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Bdt = new(Values.Bdt);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Rub = new(Values.Rub);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Uah = new(Values.Uah);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Clp = new(Values.Clp);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Cop = new(Values.Cop);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Ars = new(Values.Ars);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Pen = new(Values.Pen);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Egp = new(Values.Egp);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Ngn = new(Values.Ngn);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Kes = new(Values.Kes);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Pkr = new(Values.Pkr);

    public static readonly ReceptionUpdateAgentInfoRequestCurrency Gel = new(Values.Gel);

    public ReceptionUpdateAgentInfoRequestCurrency(string value)
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
    public static ReceptionUpdateAgentInfoRequestCurrency FromCustom(string value)
    {
        return new ReceptionUpdateAgentInfoRequestCurrency(value);
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

    public static bool operator ==(ReceptionUpdateAgentInfoRequestCurrency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionUpdateAgentInfoRequestCurrency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionUpdateAgentInfoRequestCurrency value) =>
        value.Value;

    public static explicit operator ReceptionUpdateAgentInfoRequestCurrency(string value) =>
        new(value);

    internal class ReceptionUpdateAgentInfoRequestCurrencySerializer
        : JsonConverter<ReceptionUpdateAgentInfoRequestCurrency>
    {
        public override ReceptionUpdateAgentInfoRequestCurrency Read(
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
            return new ReceptionUpdateAgentInfoRequestCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionUpdateAgentInfoRequestCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionUpdateAgentInfoRequestCurrency ReadAsPropertyName(
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
            return new ReceptionUpdateAgentInfoRequestCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionUpdateAgentInfoRequestCurrency value,
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
