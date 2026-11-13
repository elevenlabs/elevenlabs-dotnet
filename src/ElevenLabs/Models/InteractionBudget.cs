using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(InteractionBudget.InteractionBudgetSerializer))]
[Serializable]
public readonly record struct InteractionBudget : IStringEnum
{
    public static readonly InteractionBudget Realtime = new(Values.Realtime);

    public static readonly InteractionBudget FiveMinutes = new(Values.FiveMinutes);

    public static readonly InteractionBudget TenMinutes = new(Values.TenMinutes);

    public static readonly InteractionBudget OneHour = new(Values.OneHour);

    public InteractionBudget(string value)
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
    public static InteractionBudget FromCustom(string value)
    {
        return new InteractionBudget(value);
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

    public static bool operator ==(InteractionBudget value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InteractionBudget value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InteractionBudget value) => value.Value;

    public static explicit operator InteractionBudget(string value) => new(value);

    internal class InteractionBudgetSerializer : JsonConverter<InteractionBudget>
    {
        public override InteractionBudget Read(
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
            return new InteractionBudget(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InteractionBudget value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InteractionBudget ReadAsPropertyName(
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
            return new InteractionBudget(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InteractionBudget value,
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
        public const string Realtime = "realtime";

        public const string FiveMinutes = "5_minutes";

        public const string TenMinutes = "10_minutes";

        public const string OneHour = "1_hour";
    }
}
