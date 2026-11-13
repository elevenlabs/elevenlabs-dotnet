using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(MergeProposalStatus.MergeProposalStatusSerializer))]
[Serializable]
public readonly record struct MergeProposalStatus : IStringEnum
{
    public static readonly MergeProposalStatus Open = new(Values.Open);

    public static readonly MergeProposalStatus Merged = new(Values.Merged);

    public static readonly MergeProposalStatus Closed = new(Values.Closed);

    public MergeProposalStatus(string value)
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
    public static MergeProposalStatus FromCustom(string value)
    {
        return new MergeProposalStatus(value);
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

    public static bool operator ==(MergeProposalStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MergeProposalStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MergeProposalStatus value) => value.Value;

    public static explicit operator MergeProposalStatus(string value) => new(value);

    internal class MergeProposalStatusSerializer : JsonConverter<MergeProposalStatus>
    {
        public override MergeProposalStatus Read(
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
            return new MergeProposalStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MergeProposalStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MergeProposalStatus ReadAsPropertyName(
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
            return new MergeProposalStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MergeProposalStatus value,
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
        public const string Open = "open";

        public const string Merged = "merged";

        public const string Closed = "closed";
    }
}
