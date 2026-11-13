using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MockNoMatchBehavior.MockNoMatchBehaviorSerializer))]
[Serializable]
public readonly record struct MockNoMatchBehavior : IStringEnum
{
    public static readonly MockNoMatchBehavior CallRealTool = new(Values.CallRealTool);

    public static readonly MockNoMatchBehavior RaiseError = new(Values.RaiseError);

    public MockNoMatchBehavior(string value)
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
    public static MockNoMatchBehavior FromCustom(string value)
    {
        return new MockNoMatchBehavior(value);
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

    public static bool operator ==(MockNoMatchBehavior value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MockNoMatchBehavior value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MockNoMatchBehavior value) => value.Value;

    public static explicit operator MockNoMatchBehavior(string value) => new(value);

    internal class MockNoMatchBehaviorSerializer : JsonConverter<MockNoMatchBehavior>
    {
        public override MockNoMatchBehavior Read(
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
            return new MockNoMatchBehavior(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MockNoMatchBehavior value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MockNoMatchBehavior ReadAsPropertyName(
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
            return new MockNoMatchBehavior(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MockNoMatchBehavior value,
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
        public const string CallRealTool = "call_real_tool";

        public const string RaiseError = "raise_error";
    }
}
