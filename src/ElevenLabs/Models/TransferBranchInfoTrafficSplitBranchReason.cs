using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferBranchInfoTrafficSplitBranchReason.TransferBranchInfoTrafficSplitBranchReasonSerializer)
)]
[Serializable]
public readonly record struct TransferBranchInfoTrafficSplitBranchReason : IStringEnum
{
    public static readonly TransferBranchInfoTrafficSplitBranchReason TrafficSplit = new(
        Values.TrafficSplit
    );

    public TransferBranchInfoTrafficSplitBranchReason(string value)
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
    public static TransferBranchInfoTrafficSplitBranchReason FromCustom(string value)
    {
        return new TransferBranchInfoTrafficSplitBranchReason(value);
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

    public static bool operator ==(
        TransferBranchInfoTrafficSplitBranchReason value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferBranchInfoTrafficSplitBranchReason value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TransferBranchInfoTrafficSplitBranchReason value) =>
        value.Value;

    public static explicit operator TransferBranchInfoTrafficSplitBranchReason(string value) =>
        new(value);

    internal class TransferBranchInfoTrafficSplitBranchReasonSerializer
        : JsonConverter<TransferBranchInfoTrafficSplitBranchReason>
    {
        public override TransferBranchInfoTrafficSplitBranchReason Read(
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
            return new TransferBranchInfoTrafficSplitBranchReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferBranchInfoTrafficSplitBranchReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferBranchInfoTrafficSplitBranchReason ReadAsPropertyName(
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
            return new TransferBranchInfoTrafficSplitBranchReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferBranchInfoTrafficSplitBranchReason value,
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
        public const string TrafficSplit = "traffic_split";
    }
}
