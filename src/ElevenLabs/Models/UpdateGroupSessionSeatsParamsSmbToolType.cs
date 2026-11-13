using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateGroupSessionSeatsParamsSmbToolType.UpdateGroupSessionSeatsParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateGroupSessionSeatsParamsSmbToolType : IStringEnum
{
    public static readonly UpdateGroupSessionSeatsParamsSmbToolType UpdateGroupSessionSeats = new(
        Values.UpdateGroupSessionSeats
    );

    public UpdateGroupSessionSeatsParamsSmbToolType(string value)
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
    public static UpdateGroupSessionSeatsParamsSmbToolType FromCustom(string value)
    {
        return new UpdateGroupSessionSeatsParamsSmbToolType(value);
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

    public static bool operator ==(
        UpdateGroupSessionSeatsParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateGroupSessionSeatsParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateGroupSessionSeatsParamsSmbToolType value) =>
        value.Value;

    public static explicit operator UpdateGroupSessionSeatsParamsSmbToolType(string value) =>
        new(value);

    internal class UpdateGroupSessionSeatsParamsSmbToolTypeSerializer
        : JsonConverter<UpdateGroupSessionSeatsParamsSmbToolType>
    {
        public override UpdateGroupSessionSeatsParamsSmbToolType Read(
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
            return new UpdateGroupSessionSeatsParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateGroupSessionSeatsParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateGroupSessionSeatsParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateGroupSessionSeatsParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateGroupSessionSeatsParamsSmbToolType value,
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
        public const string UpdateGroupSessionSeats = "update_group_session_seats";
    }
}
