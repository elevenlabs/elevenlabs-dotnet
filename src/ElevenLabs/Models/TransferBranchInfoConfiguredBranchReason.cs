using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferBranchInfoConfiguredBranchReason.TransferBranchInfoConfiguredBranchReasonSerializer)
)]
[Serializable]
public readonly record struct TransferBranchInfoConfiguredBranchReason : IStringEnum
{
    public static readonly TransferBranchInfoConfiguredBranchReason Configured = new(
        Values.Configured
    );

    public TransferBranchInfoConfiguredBranchReason(string value)
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
    public static TransferBranchInfoConfiguredBranchReason FromCustom(string value)
    {
        return new TransferBranchInfoConfiguredBranchReason(value);
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
        TransferBranchInfoConfiguredBranchReason value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferBranchInfoConfiguredBranchReason value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TransferBranchInfoConfiguredBranchReason value) =>
        value.Value;

    public static explicit operator TransferBranchInfoConfiguredBranchReason(string value) =>
        new(value);

    internal class TransferBranchInfoConfiguredBranchReasonSerializer
        : JsonConverter<TransferBranchInfoConfiguredBranchReason>
    {
        public override TransferBranchInfoConfiguredBranchReason Read(
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
            return new TransferBranchInfoConfiguredBranchReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferBranchInfoConfiguredBranchReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferBranchInfoConfiguredBranchReason ReadAsPropertyName(
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
            return new TransferBranchInfoConfiguredBranchReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferBranchInfoConfiguredBranchReason value,
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
        public const string Configured = "configured";
    }
}
