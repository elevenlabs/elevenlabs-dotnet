using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MockingStrategy.MockingStrategySerializer))]
[Serializable]
public readonly record struct MockingStrategy : IStringEnum
{
    public static readonly MockingStrategy All = new(Values.All);

    public static readonly MockingStrategy Selected = new(Values.Selected);

    public static readonly MockingStrategy None = new(Values.None);

    public MockingStrategy(string value)
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
    public static MockingStrategy FromCustom(string value)
    {
        return new MockingStrategy(value);
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

    public static bool operator ==(MockingStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MockingStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MockingStrategy value) => value.Value;

    public static explicit operator MockingStrategy(string value) => new(value);

    internal class MockingStrategySerializer : JsonConverter<MockingStrategy>
    {
        public override MockingStrategy Read(
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
            return new MockingStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MockingStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MockingStrategy ReadAsPropertyName(
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
            return new MockingStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MockingStrategy value,
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
        public const string All = "all";

        public const string Selected = "selected";

        public const string None = "none";
    }
}
