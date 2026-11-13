using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WorkspaceAnalyticsQueryResponseModelColumnTypesItem.WorkspaceAnalyticsQueryResponseModelColumnTypesItemSerializer)
)]
[Serializable]
public readonly record struct WorkspaceAnalyticsQueryResponseModelColumnTypesItem : IStringEnum
{
    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem String = new(
        Values.String
    );

    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem Float = new(
        Values.Float
    );

    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem DateTime = new(
        Values.DateTime
    );

    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem Int = new(
        Values.Int
    );

    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem Bool = new(
        Values.Bool
    );

    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem Json = new(
        Values.Json
    );

    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem Map = new(
        Values.Map
    );

    public static readonly WorkspaceAnalyticsQueryResponseModelColumnTypesItem Array = new(
        Values.Array
    );

    public WorkspaceAnalyticsQueryResponseModelColumnTypesItem(string value)
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
    public static WorkspaceAnalyticsQueryResponseModelColumnTypesItem FromCustom(string value)
    {
        return new WorkspaceAnalyticsQueryResponseModelColumnTypesItem(value);
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
        WorkspaceAnalyticsQueryResponseModelColumnTypesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WorkspaceAnalyticsQueryResponseModelColumnTypesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        WorkspaceAnalyticsQueryResponseModelColumnTypesItem value
    ) => value.Value;

    public static explicit operator WorkspaceAnalyticsQueryResponseModelColumnTypesItem(
        string value
    ) => new(value);

    internal class WorkspaceAnalyticsQueryResponseModelColumnTypesItemSerializer
        : JsonConverter<WorkspaceAnalyticsQueryResponseModelColumnTypesItem>
    {
        public override WorkspaceAnalyticsQueryResponseModelColumnTypesItem Read(
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
            return new WorkspaceAnalyticsQueryResponseModelColumnTypesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkspaceAnalyticsQueryResponseModelColumnTypesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkspaceAnalyticsQueryResponseModelColumnTypesItem ReadAsPropertyName(
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
            return new WorkspaceAnalyticsQueryResponseModelColumnTypesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkspaceAnalyticsQueryResponseModelColumnTypesItem value,
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
        public const string String = "String";

        public const string Float = "Float";

        public const string DateTime = "DateTime";

        public const string Int = "Int";

        public const string Bool = "Bool";

        public const string Json = "JSON";

        public const string Map = "Map";

        public const string Array = "Array";
    }
}
