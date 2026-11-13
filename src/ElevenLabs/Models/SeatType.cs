using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Seat types for workspace members.</summary>
[JsonConverter(typeof(SeatType.SeatTypeSerializer))]
[Serializable]
public readonly record struct SeatType : IStringEnum
{
    public static readonly SeatType WorkspaceAdmin = new(Values.WorkspaceAdmin);

    public static readonly SeatType WorkspaceMember = new(Values.WorkspaceMember);

    public static readonly SeatType WorkspaceLiteMember = new(Values.WorkspaceLiteMember);

    public SeatType(string value)
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
    public static SeatType FromCustom(string value)
    {
        return new SeatType(value);
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

    public static bool operator ==(SeatType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(SeatType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(SeatType value) => value.Value;

    public static explicit operator SeatType(string value) => new(value);

    internal class SeatTypeSerializer : JsonConverter<SeatType>
    {
        public override SeatType Read(
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
            return new SeatType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SeatType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SeatType ReadAsPropertyName(
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
            return new SeatType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SeatType value,
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
        public const string WorkspaceAdmin = "workspace_admin";

        public const string WorkspaceMember = "workspace_member";

        public const string WorkspaceLiteMember = "workspace_lite_member";
    }
}
