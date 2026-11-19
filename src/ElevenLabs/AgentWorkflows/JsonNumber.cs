using System;
using System.Globalization;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// JSON number text, read from its decimal digits rather than through a double, and written as JavaScript writes it
/// (ECMAScript <c>Number.prototype.toString</c>: <c>1e-7</c>, <c>1e+21</c>, <c>0.000001</c>), so the canonical JSON
/// matches the other SDKs byte for byte.
/// </summary>
internal static class JsonNumber
{
    /// <summary>
    /// <paramref name="text"/> as JavaScript would write the same number. A number a double can't hold exactly (such
    /// as 9007199254740993 or 9007199254740992.5) is kept as written, so no value changes.
    /// </summary>
    public static string ToJavaScript(string text)
    {
        if (
            !double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var value)
            || double.IsInfinity(value)
            || double.IsNaN(value)
        )
        {
            return text;
        }
        var js = Format(value);
        return SameValue(text, js) ? js : text;
    }

    /// <summary>Whether the number <paramref name="text"/> is a whole number, judged from every digit written.</summary>
    public static bool IsIntegral(string text) =>
        Decompose(text, out _, out var digits, out var point) && (digits.Length == 0 || point >= digits.Length);

    /// <summary>ECMAScript <c>Number::toString(x)</c> for a finite double.</summary>
    private static string Format(double value)
    {
        if (value == 0)
        {
            return "0";
        }
        Decompose(Shortest(Math.Abs(value)), out _, out var digits, out var point);
        var k = digits.Length;
        var n = (int)point;
        string body;
        if (k <= n && n <= 21)
        {
            body = digits + new string('0', n - k);
        }
        else if (0 < n && n <= 21)
        {
            body = digits.Substring(0, n) + "." + digits.Substring(n);
        }
        else if (-6 < n && n <= 0)
        {
            body = "0." + new string('0', -n) + digits;
        }
        else
        {
            var exponent = (n - 1 >= 0 ? "+" : "-") + Math.Abs(n - 1).ToString(CultureInfo.InvariantCulture);
            body =
                k == 1
                    ? digits + "e" + exponent
                    : digits.Substring(0, 1) + "." + digits.Substring(1) + "e" + exponent;
        }
        return value < 0 ? "-" + body : body;
    }

    /// <summary>The fewest significant digits that read back as <paramref name="value"/>, as JavaScript picks them.</summary>
    private static string Shortest(double value)
    {
#if NETCOREAPP3_0_OR_GREATER
        // "R" is the shortest round-trippable form here.
        return value.ToString("R", CultureInfo.InvariantCulture);
#else
        // .NET Framework's "R" tries 15 digits and then 17, so it can write more digits than needed.
        for (var precision = 1; precision < 17; precision++)
        {
            var candidate = value.ToString("E" + (precision - 1), CultureInfo.InvariantCulture);
            if (double.Parse(candidate, NumberStyles.Float, CultureInfo.InvariantCulture) == value)
            {
                return candidate;
            }
        }
        return value.ToString("E16", CultureInfo.InvariantCulture);
#endif
    }

    /// <summary>Whether two number texts are the same decimal value.</summary>
    private static bool SameValue(string a, string b)
    {
        if (
            !Decompose(a, out var negativeA, out var digitsA, out var pointA)
            || !Decompose(b, out var negativeB, out var digitsB, out var pointB)
        )
        {
            return false;
        }
        if (digitsA.Length == 0 || digitsB.Length == 0)
        {
            // Zero, whatever its sign: JavaScript writes -0 as 0.
            return digitsA.Length == digitsB.Length;
        }
        return negativeA == negativeB && digitsA == digitsB && pointA == pointB;
    }

    /// <summary>
    /// Splits number text into its sign, its significant digits (no leading or trailing zeros; empty for zero) and
    /// the decimal point position, so the value is <c>0.digits × 10^point</c>.
    /// </summary>
    private static bool Decompose(string text, out bool negative, out string digits, out long point)
    {
        negative = false;
        digits = "";
        point = 0;
        var s = text.Trim();
        if (s.StartsWith("-", StringComparison.Ordinal) || s.StartsWith("+", StringComparison.Ordinal))
        {
            negative = s[0] == '-';
            s = s.Substring(1);
        }
        long exponent = 0;
        var e = s.IndexOfAny(new[] { 'e', 'E' });
        if (e >= 0)
        {
            if (
                !long.TryParse(
                    s.Substring(e + 1),
                    NumberStyles.AllowLeadingSign,
                    CultureInfo.InvariantCulture,
                    out exponent
                )
            )
            {
                return false;
            }
            s = s.Substring(0, e);
        }
        var dot = s.IndexOf('.');
        var whole = dot >= 0 ? s.Substring(0, dot) : s;
        var fraction = dot >= 0 ? s.Substring(dot + 1) : "";
        var all = whole + fraction;
        if (all.Length == 0)
        {
            return false;
        }
        foreach (var c in all)
        {
            if (c < '0' || c > '9')
            {
                return false;
            }
        }
        var leading = 0;
        while (leading < all.Length && all[leading] == '0')
        {
            leading++;
        }
        digits = all.Substring(leading).TrimEnd('0');
        point = whole.Length - leading + exponent;
        return true;
    }
}
