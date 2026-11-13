// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The API key for authentication. Either a workspace secret reference {'secret_id': '...'} or an environment variable reference {'env_var_label': '...'}.</summary>
[JsonConverter(typeof(ApiKey.JsonConverter))]
[Serializable]
public class ApiKey
{
    private ApiKey(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a ApiKey from a ConvAiSecretLocator value.
    /// </summary>
    public static ApiKey FromConvAiSecretLocator(global::ElevenLabs.ConvAiSecretLocator value) =>
        new("convAiSecretLocator", value);

    /// <summary>
    /// Create a ApiKey from a ConvAiEnvVarLocator value.
    /// </summary>
    public static ApiKey FromConvAiEnvVarLocator(global::ElevenLabs.ConvAiEnvVarLocator value) =>
        new("convAiEnvVarLocator", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "convAiSecretLocator".
    /// </summary>
    public bool IsConvAiSecretLocator() => Type == "convAiSecretLocator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "convAiEnvVarLocator".
    /// </summary>
    public bool IsConvAiEnvVarLocator() => Type == "convAiEnvVarLocator";

    /// <summary>
    /// Returns the value as a ConvAiSecretLocator if <see cref="Type"/> is "convAiSecretLocator", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'convAiSecretLocator'.</exception>
    public global::ElevenLabs.ConvAiSecretLocator AsConvAiSecretLocator() =>
        IsConvAiSecretLocator()
            ? (global::ElevenLabs.ConvAiSecretLocator)Value!
            : throw new ElevenLabsClientException("Union type is not 'convAiSecretLocator'");

    /// <summary>
    /// Returns the value as a ConvAiEnvVarLocator if <see cref="Type"/> is "convAiEnvVarLocator", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'convAiEnvVarLocator'.</exception>
    public global::ElevenLabs.ConvAiEnvVarLocator AsConvAiEnvVarLocator() =>
        IsConvAiEnvVarLocator()
            ? (global::ElevenLabs.ConvAiEnvVarLocator)Value!
            : throw new ElevenLabsClientException("Union type is not 'convAiEnvVarLocator'");

    /// <summary>
    /// Attempts to cast the value to a ConvAiSecretLocator and returns true if successful.
    /// </summary>
    public bool TryGetConvAiSecretLocator(out global::ElevenLabs.ConvAiSecretLocator? value)
    {
        if (Type == "convAiSecretLocator")
        {
            value = (global::ElevenLabs.ConvAiSecretLocator)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConvAiEnvVarLocator and returns true if successful.
    /// </summary>
    public bool TryGetConvAiEnvVarLocator(out global::ElevenLabs.ConvAiEnvVarLocator? value)
    {
        if (Type == "convAiEnvVarLocator")
        {
            value = (global::ElevenLabs.ConvAiEnvVarLocator)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.ConvAiSecretLocator, T> onConvAiSecretLocator,
        global::System.Func<global::ElevenLabs.ConvAiEnvVarLocator, T> onConvAiEnvVarLocator
    )
    {
        return Type switch
        {
            "convAiSecretLocator" => onConvAiSecretLocator(AsConvAiSecretLocator()),
            "convAiEnvVarLocator" => onConvAiEnvVarLocator(AsConvAiEnvVarLocator()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ConvAiSecretLocator> onConvAiSecretLocator,
        global::System.Action<global::ElevenLabs.ConvAiEnvVarLocator> onConvAiEnvVarLocator
    )
    {
        switch (Type)
        {
            case "convAiSecretLocator":
                onConvAiSecretLocator(AsConvAiSecretLocator());
                break;
            case "convAiEnvVarLocator":
                onConvAiEnvVarLocator(AsConvAiEnvVarLocator());
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not ApiKey other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ApiKey(global::ElevenLabs.ConvAiSecretLocator value) =>
        new("convAiSecretLocator", value);

    public static implicit operator ApiKey(global::ElevenLabs.ConvAiEnvVarLocator value) =>
        new("convAiEnvVarLocator", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ApiKey>
    {
        public override ApiKey? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("convAiSecretLocator", typeof(global::ElevenLabs.ConvAiSecretLocator)),
                    ("convAiEnvVarLocator", typeof(global::ElevenLabs.ConvAiEnvVarLocator)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new ApiKey(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ApiKey"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApiKey value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override ApiKey ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ApiKey result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApiKey value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
