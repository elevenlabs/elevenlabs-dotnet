using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Separator for scopes</summary>
[JsonConverter(
    typeof(ApiIntegrationOAuth2AuthCodeResponseScopeSeparator.ApiIntegrationOAuth2AuthCodeResponseScopeSeparatorSerializer)
)]
[Serializable]
public readonly record struct ApiIntegrationOAuth2AuthCodeResponseScopeSeparator : IStringEnum
{
    public static readonly ApiIntegrationOAuth2AuthCodeResponseScopeSeparator Space = new(
        Values.Space
    );

    public static readonly ApiIntegrationOAuth2AuthCodeResponseScopeSeparator Comma = new(
        Values.Comma
    );

    public ApiIntegrationOAuth2AuthCodeResponseScopeSeparator(string value)
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
    public static ApiIntegrationOAuth2AuthCodeResponseScopeSeparator FromCustom(string value)
    {
        return new ApiIntegrationOAuth2AuthCodeResponseScopeSeparator(value);
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
        ApiIntegrationOAuth2AuthCodeResponseScopeSeparator value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ApiIntegrationOAuth2AuthCodeResponseScopeSeparator value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ApiIntegrationOAuth2AuthCodeResponseScopeSeparator value
    ) => value.Value;

    public static explicit operator ApiIntegrationOAuth2AuthCodeResponseScopeSeparator(
        string value
    ) => new(value);

    internal class ApiIntegrationOAuth2AuthCodeResponseScopeSeparatorSerializer
        : JsonConverter<ApiIntegrationOAuth2AuthCodeResponseScopeSeparator>
    {
        public override ApiIntegrationOAuth2AuthCodeResponseScopeSeparator Read(
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
            return new ApiIntegrationOAuth2AuthCodeResponseScopeSeparator(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApiIntegrationOAuth2AuthCodeResponseScopeSeparator value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApiIntegrationOAuth2AuthCodeResponseScopeSeparator ReadAsPropertyName(
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
            return new ApiIntegrationOAuth2AuthCodeResponseScopeSeparator(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApiIntegrationOAuth2AuthCodeResponseScopeSeparator value,
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
