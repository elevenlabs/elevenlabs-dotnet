using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Voice category used for filtering</summary>
[JsonConverter(typeof(GetSharedVoicesRequestCategory.GetSharedVoicesRequestCategorySerializer))]
[Serializable]
public readonly record struct GetSharedVoicesRequestCategory : IStringEnum
{
    public static readonly GetSharedVoicesRequestCategory Professional = new(Values.Professional);

    public static readonly GetSharedVoicesRequestCategory Famous = new(Values.Famous);

    public static readonly GetSharedVoicesRequestCategory HighQuality = new(Values.HighQuality);

    public GetSharedVoicesRequestCategory(string value)
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
    public static GetSharedVoicesRequestCategory FromCustom(string value)
    {
        return new GetSharedVoicesRequestCategory(value);
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

    public static bool operator ==(GetSharedVoicesRequestCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSharedVoicesRequestCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSharedVoicesRequestCategory value) => value.Value;

    public static explicit operator GetSharedVoicesRequestCategory(string value) => new(value);

    internal class GetSharedVoicesRequestCategorySerializer
        : JsonConverter<GetSharedVoicesRequestCategory>
    {
        public override GetSharedVoicesRequestCategory Read(
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
            return new GetSharedVoicesRequestCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSharedVoicesRequestCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSharedVoicesRequestCategory ReadAsPropertyName(
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
            return new GetSharedVoicesRequestCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSharedVoicesRequestCategory value,
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
        public const string Professional = "professional";

        public const string Famous = "famous";

        public const string HighQuality = "high_quality";
    }
}
