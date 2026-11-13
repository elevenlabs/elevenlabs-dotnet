using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Version of the turn detection model to use.</summary>
[JsonConverter(typeof(TurnModel.TurnModelSerializer))]
[Serializable]
public readonly record struct TurnModel : IStringEnum
{
    public static readonly TurnModel TurnV2 = new(Values.TurnV2);

    public static readonly TurnModel TurnV3 = new(Values.TurnV3);

    public TurnModel(string value)
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
    public static TurnModel FromCustom(string value)
    {
        return new TurnModel(value);
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

    public static bool operator ==(TurnModel value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(TurnModel value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(TurnModel value) => value.Value;

    public static explicit operator TurnModel(string value) => new(value);

    internal class TurnModelSerializer : JsonConverter<TurnModel>
    {
        public override TurnModel Read(
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
            return new TurnModel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TurnModel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TurnModel ReadAsPropertyName(
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
            return new TurnModel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TurnModel value,
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
        public const string TurnV2 = "turn_v2";

        public const string TurnV3 = "turn_v3";
    }
}
