using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TestToolResultModelStatus.TestToolResultModelStatusSerializer))]
[Serializable]
public readonly record struct TestToolResultModelStatus : IStringEnum
{
    public static readonly TestToolResultModelStatus Success = new(Values.Success);

    public TestToolResultModelStatus(string value)
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
    public static TestToolResultModelStatus FromCustom(string value)
    {
        return new TestToolResultModelStatus(value);
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

    public static bool operator ==(TestToolResultModelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TestToolResultModelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TestToolResultModelStatus value) => value.Value;

    public static explicit operator TestToolResultModelStatus(string value) => new(value);

    internal class TestToolResultModelStatusSerializer : JsonConverter<TestToolResultModelStatus>
    {
        public override TestToolResultModelStatus Read(
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
            return new TestToolResultModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TestToolResultModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TestToolResultModelStatus ReadAsPropertyName(
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
            return new TestToolResultModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TestToolResultModelStatus value,
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
        public const string Success = "success";
    }
}
