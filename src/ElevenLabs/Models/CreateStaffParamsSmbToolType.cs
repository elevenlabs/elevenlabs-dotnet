using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CreateStaffParamsSmbToolType.CreateStaffParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct CreateStaffParamsSmbToolType : IStringEnum
{
    public static readonly CreateStaffParamsSmbToolType CreateStaff = new(Values.CreateStaff);

    public CreateStaffParamsSmbToolType(string value)
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
    public static CreateStaffParamsSmbToolType FromCustom(string value)
    {
        return new CreateStaffParamsSmbToolType(value);
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

    public static bool operator ==(CreateStaffParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateStaffParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateStaffParamsSmbToolType value) => value.Value;

    public static explicit operator CreateStaffParamsSmbToolType(string value) => new(value);

    internal class CreateStaffParamsSmbToolTypeSerializer
        : JsonConverter<CreateStaffParamsSmbToolType>
    {
        public override CreateStaffParamsSmbToolType Read(
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
            return new CreateStaffParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateStaffParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateStaffParamsSmbToolType ReadAsPropertyName(
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
            return new CreateStaffParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateStaffParamsSmbToolType value,
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
        public const string CreateStaff = "create_staff";
    }
}
