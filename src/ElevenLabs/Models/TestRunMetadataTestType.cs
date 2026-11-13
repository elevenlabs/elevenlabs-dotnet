using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TestRunMetadataTestType.TestRunMetadataTestTypeSerializer))]
[Serializable]
public readonly record struct TestRunMetadataTestType : IStringEnum
{
    public static readonly TestRunMetadataTestType Llm = new(Values.Llm);

    public static readonly TestRunMetadataTestType ToolCall = new(Values.ToolCall);

    public static readonly TestRunMetadataTestType Simulation = new(Values.Simulation);

    public TestRunMetadataTestType(string value)
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
    public static TestRunMetadataTestType FromCustom(string value)
    {
        return new TestRunMetadataTestType(value);
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

    public static bool operator ==(TestRunMetadataTestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TestRunMetadataTestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TestRunMetadataTestType value) => value.Value;

    public static explicit operator TestRunMetadataTestType(string value) => new(value);

    internal class TestRunMetadataTestTypeSerializer : JsonConverter<TestRunMetadataTestType>
    {
        public override TestRunMetadataTestType Read(
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
            return new TestRunMetadataTestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TestRunMetadataTestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TestRunMetadataTestType ReadAsPropertyName(
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
            return new TestRunMetadataTestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TestRunMetadataTestType value,
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
        public const string Llm = "llm";

        public const string ToolCall = "tool_call";

        public const string Simulation = "simulation";
    }
}
