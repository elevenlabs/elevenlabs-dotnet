using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MergeProposalReviewState.MergeProposalReviewStateSerializer))]
[Serializable]
public readonly record struct MergeProposalReviewState : IStringEnum
{
    public static readonly MergeProposalReviewState Approved = new(Values.Approved);

    public static readonly MergeProposalReviewState ChangesRequested = new(Values.ChangesRequested);

    public MergeProposalReviewState(string value)
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
    public static MergeProposalReviewState FromCustom(string value)
    {
        return new MergeProposalReviewState(value);
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

    public static bool operator ==(MergeProposalReviewState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MergeProposalReviewState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MergeProposalReviewState value) => value.Value;

    public static explicit operator MergeProposalReviewState(string value) => new(value);

    internal class MergeProposalReviewStateSerializer : JsonConverter<MergeProposalReviewState>
    {
        public override MergeProposalReviewState Read(
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
            return new MergeProposalReviewState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MergeProposalReviewState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MergeProposalReviewState ReadAsPropertyName(
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
            return new MergeProposalReviewState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MergeProposalReviewState value,
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

        public const string ChangesRequested = "changes_requested";
    }
}
