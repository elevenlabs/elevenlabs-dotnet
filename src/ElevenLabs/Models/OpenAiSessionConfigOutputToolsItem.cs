// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OpenAiSessionConfigOutputToolsItem.JsonConverter))]
[Serializable]
public record OpenAiSessionConfigOutputToolsItem
{
    internal OpenAiSessionConfigOutputToolsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of OpenAiSessionConfigOutputToolsItem with <see cref="OpenAiSessionConfigOutputToolsItem.Function"/>.
    /// </summary>
    public OpenAiSessionConfigOutputToolsItem(OpenAiSessionConfigOutputToolsItem.Function value)
    {
        Type = "function";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of OpenAiSessionConfigOutputToolsItem with <see cref="OpenAiSessionConfigOutputToolsItem.Mcp"/>.
    /// </summary>
    public OpenAiSessionConfigOutputToolsItem(OpenAiSessionConfigOutputToolsItem.Mcp value)
    {
        Type = "mcp";
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
    /// Returns true if <see cref="Type"/> is "function"
    /// </summary>
    public bool IsFunction => Type == "function";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "mcp"
    /// </summary>
    public bool IsMcp => Type == "mcp";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OpenAiFunctionTool"/> if <see cref="Type"/> is 'function', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'function'.</exception>
    public global::ElevenLabs.OpenAiFunctionTool AsFunction() =>
        IsFunction
            ? (global::ElevenLabs.OpenAiFunctionTool)Value!
            : throw new global::System.Exception(
                "OpenAiSessionConfigOutputToolsItem.Type is not 'function'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OpenAimcpTool"/> if <see cref="Type"/> is 'mcp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mcp'.</exception>
    public global::ElevenLabs.OpenAimcpTool AsMcp() =>
        IsMcp
            ? (global::ElevenLabs.OpenAimcpTool)Value!
            : throw new global::System.Exception(
                "OpenAiSessionConfigOutputToolsItem.Type is not 'mcp'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.OpenAiFunctionTool, T> onFunction,
        Func<global::ElevenLabs.OpenAimcpTool, T> onMcp,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "function" => onFunction(AsFunction()),
            "mcp" => onMcp(AsMcp()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.OpenAiFunctionTool> onFunction,
        Action<global::ElevenLabs.OpenAimcpTool> onMcp,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "function":
                onFunction(AsFunction());
                break;
            case "mcp":
                onMcp(AsMcp());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OpenAiFunctionTool"/> and returns true if successful.
    /// </summary>
    public bool TryAsFunction(out global::ElevenLabs.OpenAiFunctionTool? value)
    {
        if (Type == "function")
        {
            value = (global::ElevenLabs.OpenAiFunctionTool)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OpenAimcpTool"/> and returns true if successful.
    /// </summary>
    public bool TryAsMcp(out global::ElevenLabs.OpenAimcpTool? value)
    {
        if (Type == "mcp")
        {
            value = (global::ElevenLabs.OpenAimcpTool)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator OpenAiSessionConfigOutputToolsItem(
        OpenAiSessionConfigOutputToolsItem.Function value
    ) => new(value);

    public static implicit operator OpenAiSessionConfigOutputToolsItem(
        OpenAiSessionConfigOutputToolsItem.Mcp value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<OpenAiSessionConfigOutputToolsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(OpenAiSessionConfigOutputToolsItem).IsAssignableFrom(typeToConvert);

        public override OpenAiSessionConfigOutputToolsItem Read(
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
                "function" => json.Deserialize<global::ElevenLabs.OpenAiFunctionTool?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.OpenAiFunctionTool"
                    ),
                "mcp" => json.Deserialize<global::ElevenLabs.OpenAimcpTool?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.OpenAimcpTool"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new OpenAiSessionConfigOutputToolsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OpenAiSessionConfigOutputToolsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "function" => JsonSerializer.SerializeToNode(value.Value, options),
                    "mcp" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override OpenAiSessionConfigOutputToolsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new OpenAiSessionConfigOutputToolsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OpenAiSessionConfigOutputToolsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for function
    /// </summary>
    [Serializable]
    public struct Function
    {
        public Function(global::ElevenLabs.OpenAiFunctionTool value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OpenAiFunctionTool Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator OpenAiSessionConfigOutputToolsItem.Function(
            global::ElevenLabs.OpenAiFunctionTool value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for mcp
    /// </summary>
    [Serializable]
    public struct Mcp
    {
        public Mcp(global::ElevenLabs.OpenAimcpTool value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OpenAimcpTool Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator OpenAiSessionConfigOutputToolsItem.Mcp(
            global::ElevenLabs.OpenAimcpTool value
        ) => new(value);
    }
}
