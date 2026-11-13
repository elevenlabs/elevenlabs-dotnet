using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Separator for scopes</summary>
[JsonConverter(
    typeof(ApiIntegrationOAuth2CustomAppResponseScopeSeparator.ApiIntegrationOAuth2CustomAppResponseScopeSeparatorSerializer)
)]
[Serializable]
public readonly record struct ApiIntegrationOAuth2CustomAppResponseScopeSeparator : IStringEnum
{
    public static readonly ApiIntegrationOAuth2CustomAppResponseScopeSeparator Space = new(
        Values.Space
    );

    public static readonly ApiIntegrationOAuth2CustomAppResponseScopeSeparator Comma = new(
        Values.Comma
    );

    public ApiIntegrationOAuth2CustomAppResponseScopeSeparator(string value)
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
    public static ApiIntegrationOAuth2CustomAppResponseScopeSeparator FromCustom(string value)
    {
        return new ApiIntegrationOAuth2CustomAppResponseScopeSeparator(value);
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
        ApiIntegrationOAuth2CustomAppResponseScopeSeparator value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ApiIntegrationOAuth2CustomAppResponseScopeSeparator value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ApiIntegrationOAuth2CustomAppResponseScopeSeparator value
    ) => value.Value;

    public static explicit operator ApiIntegrationOAuth2CustomAppResponseScopeSeparator(
        string value
    ) => new(value);

    internal class ApiIntegrationOAuth2CustomAppResponseScopeSeparatorSerializer
        : JsonConverter<ApiIntegrationOAuth2CustomAppResponseScopeSeparator>
    {
        public override ApiIntegrationOAuth2CustomAppResponseScopeSeparator Read(
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
            return new ApiIntegrationOAuth2CustomAppResponseScopeSeparator(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApiIntegrationOAuth2CustomAppResponseScopeSeparator value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApiIntegrationOAuth2CustomAppResponseScopeSeparator ReadAsPropertyName(
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
            return new ApiIntegrationOAuth2CustomAppResponseScopeSeparator(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApiIntegrationOAuth2CustomAppResponseScopeSeparator value,
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
        public const string Space = " ";

        public const string Comma = ",";
    }
}
