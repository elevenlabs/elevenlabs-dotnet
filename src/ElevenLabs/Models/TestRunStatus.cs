using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TestRunStatus.TestRunStatusSerializer))]
[Serializable]
public readonly record struct TestRunStatus : IStringEnum
{
    public static readonly TestRunStatus Pending = new(Values.Pending);

    public static readonly TestRunStatus Passed = new(Values.Passed);

    public static readonly TestRunStatus Failed = new(Values.Failed);

    public static readonly TestRunStatus Cancelled = new(Values.Cancelled);

    public TestRunStatus(string value)
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
    public static TestRunStatus FromCustom(string value)
    {
        return new TestRunStatus(value);
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

    public static bool operator ==(TestRunStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TestRunStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TestRunStatus value) => value.Value;

    public static explicit operator TestRunStatus(string value) => new(value);

    internal class TestRunStatusSerializer : JsonConverter<TestRunStatus>
    {
        public override TestRunStatus Read(
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
            return new TestRunStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TestRunStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TestRunStatus ReadAsPropertyName(
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
            return new TestRunStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TestRunStatus value,
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
        public const string Pending = "pending";

        public const string Passed = "passed";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";
    }
}
