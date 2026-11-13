using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(BranchProtectionStatus.BranchProtectionStatusSerializer))]
[Serializable]
public readonly record struct BranchProtectionStatus : IStringEnum
{
    public static readonly BranchProtectionStatus WriterPermsRequired = new(
        Values.WriterPermsRequired
    );

    public static readonly BranchProtectionStatus AdminPermsRequired = new(
        Values.AdminPermsRequired
    );

    public BranchProtectionStatus(string value)
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
    public static BranchProtectionStatus FromCustom(string value)
    {
        return new BranchProtectionStatus(value);
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

    public static bool operator ==(BranchProtectionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BranchProtectionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BranchProtectionStatus value) => value.Value;

    public static explicit operator BranchProtectionStatus(string value) => new(value);

    internal class BranchProtectionStatusSerializer : JsonConverter<BranchProtectionStatus>
    {
        public override BranchProtectionStatus Read(
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
            return new BranchProtectionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BranchProtectionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BranchProtectionStatus ReadAsPropertyName(
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
            return new BranchProtectionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BranchProtectionStatus value,
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
        public const string WriterPermsRequired = "writer_perms_required";

        public const string AdminPermsRequired = "admin_perms_required";
    }
}
