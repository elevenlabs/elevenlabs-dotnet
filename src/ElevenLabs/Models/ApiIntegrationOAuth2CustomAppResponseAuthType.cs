using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ApiIntegrationOAuth2CustomAppResponseAuthType.ApiIntegrationOAuth2CustomAppResponseAuthTypeSerializer)
)]
[Serializable]
public readonly record struct ApiIntegrationOAuth2CustomAppResponseAuthType : IStringEnum
{
    public static readonly ApiIntegrationOAuth2CustomAppResponseAuthType ApiIntegrationOauth2CustomApp =
        new(Values.ApiIntegrationOauth2CustomApp);

    public ApiIntegrationOAuth2CustomAppResponseAuthType(string value)
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
    public static ApiIntegrationOAuth2CustomAppResponseAuthType FromCustom(string value)
    {
        return new ApiIntegrationOAuth2CustomAppResponseAuthType(value);
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
        ApiIntegrationOAuth2CustomAppResponseAuthType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ApiIntegrationOAuth2CustomAppResponseAuthType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ApiIntegrationOAuth2CustomAppResponseAuthType value) =>
        value.Value;

    public static explicit operator ApiIntegrationOAuth2CustomAppResponseAuthType(string value) =>
        new(value);

    internal class ApiIntegrationOAuth2CustomAppResponseAuthTypeSerializer
        : JsonConverter<ApiIntegrationOAuth2CustomAppResponseAuthType>
    {
        public override ApiIntegrationOAuth2CustomAppResponseAuthType Read(
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
            return new ApiIntegrationOAuth2CustomAppResponseAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApiIntegrationOAuth2CustomAppResponseAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApiIntegrationOAuth2CustomAppResponseAuthType ReadAsPropertyName(
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
            return new ApiIntegrationOAuth2CustomAppResponseAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApiIntegrationOAuth2CustomAppResponseAuthType value,
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
        public const string ApiIntegrationOauth2CustomApp = "api_integration_oauth2_custom_app";
    }
}
