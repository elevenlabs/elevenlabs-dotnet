using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ReviewResponseModelRejectReasonsItem.ReviewResponseModelRejectReasonsItemSerializer)
)]
[Serializable]
public readonly record struct ReviewResponseModelRejectReasonsItem : IStringEnum
{
    public static readonly ReviewResponseModelRejectReasonsItem LacksStructure = new(
        Values.LacksStructure
    );

    public static readonly ReviewResponseModelRejectReasonsItem DoesntOpen = new(Values.DoesntOpen);

    public static readonly ReviewResponseModelRejectReasonsItem NotLiteraryWork = new(
        Values.NotLiteraryWork
    );

    public static readonly ReviewResponseModelRejectReasonsItem LanguageNotSupported = new(
        Values.LanguageNotSupported
    );

    public static readonly ReviewResponseModelRejectReasonsItem TooShort = new(Values.TooShort);

    public static readonly ReviewResponseModelRejectReasonsItem Duplicate = new(Values.Duplicate);

    public static readonly ReviewResponseModelRejectReasonsItem Promotional = new(
        Values.Promotional
    );

    public static readonly ReviewResponseModelRejectReasonsItem FormattingIssues = new(
        Values.FormattingIssues
    );

    public static readonly ReviewResponseModelRejectReasonsItem LowQuality = new(Values.LowQuality);

    public static readonly ReviewResponseModelRejectReasonsItem MetadataIncomplete = new(
        Values.MetadataIncomplete
    );

    public static readonly ReviewResponseModelRejectReasonsItem MetadataInaccurate = new(
        Values.MetadataInaccurate
    );

    public static readonly ReviewResponseModelRejectReasonsItem Typos = new(Values.Typos);

    public static readonly ReviewResponseModelRejectReasonsItem ReviewError = new(
        Values.ReviewError
    );

    public static readonly ReviewResponseModelRejectReasonsItem Spam = new(Values.Spam);

    public static readonly ReviewResponseModelRejectReasonsItem LegalViolation = new(
        Values.LegalViolation
    );

    public static readonly ReviewResponseModelRejectReasonsItem ContentPolicy = new(
        Values.ContentPolicy
    );

    public static readonly ReviewResponseModelRejectReasonsItem PublicDomain = new(
        Values.PublicDomain
    );

    public static readonly ReviewResponseModelRejectReasonsItem Other = new(Values.Other);

    public ReviewResponseModelRejectReasonsItem(string value)
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
    public static ReviewResponseModelRejectReasonsItem FromCustom(string value)
    {
        return new ReviewResponseModelRejectReasonsItem(value);
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

    public static bool operator ==(ReviewResponseModelRejectReasonsItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewResponseModelRejectReasonsItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewResponseModelRejectReasonsItem value) =>
        value.Value;

    public static explicit operator ReviewResponseModelRejectReasonsItem(string value) =>
        new(value);

    internal class ReviewResponseModelRejectReasonsItemSerializer
        : JsonConverter<ReviewResponseModelRejectReasonsItem>
    {
        public override ReviewResponseModelRejectReasonsItem Read(
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
            return new ReviewResponseModelRejectReasonsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewResponseModelRejectReasonsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewResponseModelRejectReasonsItem ReadAsPropertyName(
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
            return new ReviewResponseModelRejectReasonsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewResponseModelRejectReasonsItem value,
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
        public const string LacksStructure = "lacks_structure";

        public const string DoesntOpen = "doesnt_open";

        public const string NotLiteraryWork = "not_literary_work";

        public const string LanguageNotSupported = "language_not_supported";

        public const string TooShort = "too_short";

        public const string Duplicate = "duplicate";

        public const string Promotional = "promotional";

        public const string FormattingIssues = "formatting_issues";

        public const string LowQuality = "low_quality";

        public const string MetadataIncomplete = "metadata_incomplete";

        public const string MetadataInaccurate = "metadata_inaccurate";

        public const string Typos = "typos";

        public const string ReviewError = "review_error";

        public const string Spam = "spam";

        public const string LegalViolation = "legal_violation";

        public const string ContentPolicy = "content_policy";

        public const string PublicDomain = "public_domain";

        public const string Other = "other";
    }
}
