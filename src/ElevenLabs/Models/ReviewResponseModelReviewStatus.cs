using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReviewResponseModelReviewStatus.ReviewResponseModelReviewStatusSerializer))]
[Serializable]
public readonly record struct ReviewResponseModelReviewStatus : IStringEnum
{
    public static readonly ReviewResponseModelReviewStatus Approved = new(Values.Approved);

    public static readonly ReviewResponseModelReviewStatus EditsRequired = new(
        Values.EditsRequired
    );

    public static readonly ReviewResponseModelReviewStatus Rejected = new(Values.Rejected);

    public ReviewResponseModelReviewStatus(string value)
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
    public static ReviewResponseModelReviewStatus FromCustom(string value)
    {
        return new ReviewResponseModelReviewStatus(value);
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

    public static bool operator ==(ReviewResponseModelReviewStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewResponseModelReviewStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewResponseModelReviewStatus value) => value.Value;

    public static explicit operator ReviewResponseModelReviewStatus(string value) => new(value);

    internal class ReviewResponseModelReviewStatusSerializer
        : JsonConverter<ReviewResponseModelReviewStatus>
    {
        public override ReviewResponseModelReviewStatus Read(
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
            return new ReviewResponseModelReviewStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewResponseModelReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewResponseModelReviewStatus ReadAsPropertyName(
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
            return new ReviewResponseModelReviewStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewResponseModelReviewStatus value,
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
        public const string Approved = "approved";

        public const string EditsRequired = "edits_required";

        public const string Rejected = "rejected";
    }
}
