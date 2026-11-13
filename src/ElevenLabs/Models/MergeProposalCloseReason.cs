using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MergeProposalCloseReason.MergeProposalCloseReasonSerializer))]
[Serializable]
public readonly record struct MergeProposalCloseReason : IStringEnum
{
    public static readonly MergeProposalCloseReason Withdrawn = new(Values.Withdrawn);

    public static readonly MergeProposalCloseReason Rejected = new(Values.Rejected);

    public static readonly MergeProposalCloseReason BranchArchived = new(Values.BranchArchived);

    public MergeProposalCloseReason(string value)
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
    public static MergeProposalCloseReason FromCustom(string value)
    {
        return new MergeProposalCloseReason(value);
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

    public static bool operator ==(MergeProposalCloseReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MergeProposalCloseReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MergeProposalCloseReason value) => value.Value;

    public static explicit operator MergeProposalCloseReason(string value) => new(value);

    internal class MergeProposalCloseReasonSerializer : JsonConverter<MergeProposalCloseReason>
    {
        public override MergeProposalCloseReason Read(
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
            return new MergeProposalCloseReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MergeProposalCloseReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MergeProposalCloseReason ReadAsPropertyName(
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
            return new MergeProposalCloseReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MergeProposalCloseReason value,
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
        public const string Withdrawn = "withdrawn";

        public const string Rejected = "rejected";

        public const string BranchArchived = "branch_archived";
    }
}
