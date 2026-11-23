using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LoadingState.LoadingStateSerializer))]
[Serializable]
public readonly record struct LoadingState : IStringEnum
{
    public static readonly LoadingState Loading = new(Values.Loading);

    public LoadingState(string value)
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
    public static LoadingState FromCustom(string value)
    {
        return new LoadingState(value);
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

    public static bool operator ==(LoadingState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoadingState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoadingState value) => value.Value;

    public static explicit operator LoadingState(string value) => new(value);

    internal class LoadingStateSerializer : JsonConverter<LoadingState>
    {
        public override LoadingState Read(
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
            return new LoadingState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LoadingState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LoadingState ReadAsPropertyName(
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
            return new LoadingState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LoadingState value,
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
        public const string Loading = "loading";
    }
}
