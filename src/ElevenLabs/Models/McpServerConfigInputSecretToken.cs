// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The secret token (Authorization header) stored as a workspace secret or in-place secret</summary>
[JsonConverter(typeof(McpServerConfigInputSecretToken.JsonConverter))]
[Serializable]
public class McpServerConfigInputSecretToken
{
    private McpServerConfigInputSecretToken(string type, object? value)
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
    /// Create a McpServerConfigInputSecretToken from a ConvAiSecretLocator value.
    /// </summary>
    public static McpServerConfigInputSecretToken FromConvAiSecretLocator(
        global::ElevenLabs.ConvAiSecretLocator value
    ) => new("convAiSecretLocator", value);

    /// <summary>
    /// Create a McpServerConfigInputSecretToken from a ConvAiUserSecretDbModel value.
    /// </summary>
    public static McpServerConfigInputSecretToken FromConvAiUserSecretDbModel(
        global::ElevenLabs.ConvAiUserSecretDbModel value
    ) => new("convAiUserSecretDbModel", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "convAiSecretLocator".
    /// </summary>
    public bool IsConvAiSecretLocator() => Type == "convAiSecretLocator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "convAiUserSecretDbModel".
    /// </summary>
    public bool IsConvAiUserSecretDbModel() => Type == "convAiUserSecretDbModel";

    /// <summary>
    /// Returns the value as a ConvAiSecretLocator if <see cref="Type"/> is "convAiSecretLocator", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'convAiSecretLocator'.</exception>
    public global::ElevenLabs.ConvAiSecretLocator AsConvAiSecretLocator() =>
        IsConvAiSecretLocator()
            ? (global::ElevenLabs.ConvAiSecretLocator)Value!
            : throw new ElevenLabsClientException("Union type is not 'convAiSecretLocator'");

    /// <summary>
    /// Returns the value as a ConvAiUserSecretDbModel if <see cref="Type"/> is "convAiUserSecretDbModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'convAiUserSecretDbModel'.</exception>
    public global::ElevenLabs.ConvAiUserSecretDbModel AsConvAiUserSecretDbModel() =>
        IsConvAiUserSecretDbModel()
            ? (global::ElevenLabs.ConvAiUserSecretDbModel)Value!
            : throw new ElevenLabsClientException("Union type is not 'convAiUserSecretDbModel'");

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
    /// Attempts to cast the value to a ConvAiUserSecretDbModel and returns true if successful.
    /// </summary>
    public bool TryGetConvAiUserSecretDbModel(out global::ElevenLabs.ConvAiUserSecretDbModel? value)
    {
        if (Type == "convAiUserSecretDbModel")
        {
            value = (global::ElevenLabs.ConvAiUserSecretDbModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.ConvAiSecretLocator, T> onConvAiSecretLocator,
        global::System.Func<global::ElevenLabs.ConvAiUserSecretDbModel, T> onConvAiUserSecretDbModel
    )
    {
        return Type switch
        {
            "convAiSecretLocator" => onConvAiSecretLocator(AsConvAiSecretLocator()),
            "convAiUserSecretDbModel" => onConvAiUserSecretDbModel(AsConvAiUserSecretDbModel()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ConvAiSecretLocator> onConvAiSecretLocator,
        global::System.Action<global::ElevenLabs.ConvAiUserSecretDbModel> onConvAiUserSecretDbModel
    )
    {
        switch (Type)
        {
            case "convAiSecretLocator":
                onConvAiSecretLocator(AsConvAiSecretLocator());
                break;
            case "convAiUserSecretDbModel":
                onConvAiUserSecretDbModel(AsConvAiUserSecretDbModel());
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
        if (obj is not McpServerConfigInputSecretToken other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator McpServerConfigInputSecretToken(
        global::ElevenLabs.ConvAiSecretLocator value
    ) => new("convAiSecretLocator", value);

    public static implicit operator McpServerConfigInputSecretToken(
        global::ElevenLabs.ConvAiUserSecretDbModel value
    ) => new("convAiUserSecretDbModel", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<McpServerConfigInputSecretToken>
    {
        public override McpServerConfigInputSecretToken? Read(
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
                    ("convAiUserSecretDbModel", typeof(global::ElevenLabs.ConvAiUserSecretDbModel)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new McpServerConfigInputSecretToken(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into McpServerConfigInputSecretToken"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpServerConfigInputSecretToken value,
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

        public override McpServerConfigInputSecretToken ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            McpServerConfigInputSecretToken result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpServerConfigInputSecretToken value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
