using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(TestType.TestTypeSerializer))]
[Serializable]
public readonly record struct TestType : IStringEnum
{
    public static readonly TestType Llm = new(Values.Llm);

    public static readonly TestType Tool = new(Values.Tool);

    public static readonly TestType Simulation = new(Values.Simulation);

    public static readonly TestType Folder = new(Values.Folder);

    public TestType(string value)
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
    public static TestType FromCustom(string value)
    {
        return new TestType(value);
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

    public static bool operator ==(TestType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(TestType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(TestType value) => value.Value;

    public static explicit operator TestType(string value) => new(value);

    internal class TestTypeSerializer : JsonConverter<TestType>
    {
        public override TestType Read(
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
            return new TestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TestType ReadAsPropertyName(
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
            return new TestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TestType value,
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

        public const string Tool = "tool";

        public const string Simulation = "simulation";

        public const string Folder = "folder";
    }
}
