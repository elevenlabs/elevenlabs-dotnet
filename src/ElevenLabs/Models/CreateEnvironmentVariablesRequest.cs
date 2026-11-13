// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.EnvironmentVariables;

[JsonConverter(typeof(CreateEnvironmentVariablesRequest.JsonConverter))]
[Serializable]
public record CreateEnvironmentVariablesRequest
{
    internal CreateEnvironmentVariablesRequest(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateEnvironmentVariablesRequest with <see cref="CreateEnvironmentVariablesRequest.String"/>.
    /// </summary>
    public CreateEnvironmentVariablesRequest(CreateEnvironmentVariablesRequest.String value)
    {
        Type = "string";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreateEnvironmentVariablesRequest with <see cref="CreateEnvironmentVariablesRequest.Secret"/>.
    /// </summary>
    public CreateEnvironmentVariablesRequest(CreateEnvironmentVariablesRequest.Secret value)
    {
        Type = "secret";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreateEnvironmentVariablesRequest with <see cref="CreateEnvironmentVariablesRequest.AuthConnection"/>.
    /// </summary>
    public CreateEnvironmentVariablesRequest(CreateEnvironmentVariablesRequest.AuthConnection value)
    {
        Type = "auth_connection";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "secret"
    /// </summary>
    public bool IsSecret => Type == "secret";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "auth_connection"
    /// </summary>
    public bool IsAuthConnection => Type == "auth_connection";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateStringEnvironmentVariableRequest"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public global::ElevenLabs.CreateStringEnvironmentVariableRequest AsString() =>
        IsString
            ? (global::ElevenLabs.CreateStringEnvironmentVariableRequest)Value!
            : throw new global::System.Exception(
                "CreateEnvironmentVariablesRequest.Type is not 'string'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateSecretEnvironmentVariableRequest"/> if <see cref="Type"/> is 'secret', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'secret'.</exception>
    public global::ElevenLabs.CreateSecretEnvironmentVariableRequest AsSecret() =>
        IsSecret
            ? (global::ElevenLabs.CreateSecretEnvironmentVariableRequest)Value!
            : throw new global::System.Exception(
                "CreateEnvironmentVariablesRequest.Type is not 'secret'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest"/> if <see cref="Type"/> is 'auth_connection', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'auth_connection'.</exception>
    public global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest AsAuthConnection() =>
        IsAuthConnection
            ? (global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest)Value!
            : throw new global::System.Exception(
                "CreateEnvironmentVariablesRequest.Type is not 'auth_connection'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.CreateStringEnvironmentVariableRequest, T> onString,
        Func<global::ElevenLabs.CreateSecretEnvironmentVariableRequest, T> onSecret,
        Func<global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest, T> onAuthConnection,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "secret" => onSecret(AsSecret()),
            "auth_connection" => onAuthConnection(AsAuthConnection()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.CreateStringEnvironmentVariableRequest> onString,
        Action<global::ElevenLabs.CreateSecretEnvironmentVariableRequest> onSecret,
        Action<global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest> onAuthConnection,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "secret":
                onSecret(AsSecret());
                break;
            case "auth_connection":
                onAuthConnection(AsAuthConnection());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateStringEnvironmentVariableRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsString(out global::ElevenLabs.CreateStringEnvironmentVariableRequest? value)
    {
        if (Type == "string")
        {
            value = (global::ElevenLabs.CreateStringEnvironmentVariableRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateSecretEnvironmentVariableRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsSecret(out global::ElevenLabs.CreateSecretEnvironmentVariableRequest? value)
    {
        if (Type == "secret")
        {
            value = (global::ElevenLabs.CreateSecretEnvironmentVariableRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsAuthConnection(
        out global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest? value
    )
    {
        if (Type == "auth_connection")
        {
            value = (global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateEnvironmentVariablesRequest(
        CreateEnvironmentVariablesRequest.String value
    ) => new(value);

    public static implicit operator CreateEnvironmentVariablesRequest(
        CreateEnvironmentVariablesRequest.Secret value
    ) => new(value);

    public static implicit operator CreateEnvironmentVariablesRequest(
        CreateEnvironmentVariablesRequest.AuthConnection value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateEnvironmentVariablesRequest>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateEnvironmentVariablesRequest).IsAssignableFrom(typeToConvert);

        public override CreateEnvironmentVariablesRequest Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "string" =>
                    json.Deserialize<global::ElevenLabs.CreateStringEnvironmentVariableRequest?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateStringEnvironmentVariableRequest"
                        ),
                "secret" =>
                    json.Deserialize<global::ElevenLabs.CreateSecretEnvironmentVariableRequest?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateSecretEnvironmentVariableRequest"
                        ),
                "auth_connection" =>
                    json.Deserialize<global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateEnvironmentVariablesRequest(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateEnvironmentVariablesRequest value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "string" => JsonSerializer.SerializeToNode(value.Value, options),
                    "secret" => JsonSerializer.SerializeToNode(value.Value, options),
                    "auth_connection" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override CreateEnvironmentVariablesRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateEnvironmentVariablesRequest(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateEnvironmentVariablesRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for string
    /// </summary>
    [Serializable]
    public struct String
    {
        public String(global::ElevenLabs.CreateStringEnvironmentVariableRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateStringEnvironmentVariableRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateEnvironmentVariablesRequest.String(
            global::ElevenLabs.CreateStringEnvironmentVariableRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for secret
    /// </summary>
    [Serializable]
    public struct Secret
    {
        public Secret(global::ElevenLabs.CreateSecretEnvironmentVariableRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateSecretEnvironmentVariableRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateEnvironmentVariablesRequest.Secret(
            global::ElevenLabs.CreateSecretEnvironmentVariableRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for auth_connection
    /// </summary>
    [Serializable]
    public struct AuthConnection
    {
        public AuthConnection(
            global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateEnvironmentVariablesRequest.AuthConnection(
            global::ElevenLabs.CreateAuthConnectionEnvironmentVariableRequest value
        ) => new(value);
    }
}
