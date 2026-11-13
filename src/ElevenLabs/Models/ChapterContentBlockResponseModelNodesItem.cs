// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ChapterContentBlockResponseModelNodesItem.JsonConverter))]
[Serializable]
public record ChapterContentBlockResponseModelNodesItem
{
    internal ChapterContentBlockResponseModelNodesItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ChapterContentBlockResponseModelNodesItem with <see cref="ChapterContentBlockResponseModelNodesItem.TtsNode"/>.
    /// </summary>
    public ChapterContentBlockResponseModelNodesItem(
        ChapterContentBlockResponseModelNodesItem.TtsNode value
    )
    {
        Type = "tts_node";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ChapterContentBlockResponseModelNodesItem with <see cref="ChapterContentBlockResponseModelNodesItem._Other"/>.
    /// </summary>
    public ChapterContentBlockResponseModelNodesItem(
        ChapterContentBlockResponseModelNodesItem._Other value
    )
    {
        Type = "_other";
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
    /// Returns true if <see cref="Type"/> is "tts_node"
    /// </summary>
    public bool IsTtsNode => Type == "tts_node";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "_other"
    /// </summary>
    public bool Is_Other => Type == "_other";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel"/> if <see cref="Type"/> is 'tts_node', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'tts_node'.</exception>
    public global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel AsTtsNode() =>
        IsTtsNode
            ? (global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel)Value!
            : throw new global::System.Exception(
                "ChapterContentBlockResponseModelNodesItem.Type is not 'tts_node'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel"/> if <see cref="Type"/> is '_other', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not '_other'.</exception>
    public global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel As_Other() =>
        Is_Other
            ? (global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel)Value!
            : throw new global::System.Exception(
                "ChapterContentBlockResponseModelNodesItem.Type is not '_other'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel, T> onTtsNode,
        Func<global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel, T> on_Other,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "tts_node" => onTtsNode(AsTtsNode()),
            "_other" => on_Other(As_Other()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel> onTtsNode,
        Action<global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel> on_Other,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "tts_node":
                onTtsNode(AsTtsNode());
                break;
            case "_other":
                on_Other(As_Other());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTtsNode(out global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel? value)
    {
        if (Type == "tts_node")
        {
            value = (global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAs_Other(
        out global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel? value
    )
    {
        if (Type == "_other")
        {
            value = (global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ChapterContentBlockResponseModelNodesItem(
        ChapterContentBlockResponseModelNodesItem.TtsNode value
    ) => new(value);

    public static implicit operator ChapterContentBlockResponseModelNodesItem(
        ChapterContentBlockResponseModelNodesItem._Other value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ChapterContentBlockResponseModelNodesItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ChapterContentBlockResponseModelNodesItem).IsAssignableFrom(typeToConvert);

        public override ChapterContentBlockResponseModelNodesItem Read(
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
                "tts_node" =>
                    json.Deserialize<global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel"
                        ),
                "_other" =>
                    json.Deserialize<global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ChapterContentBlockResponseModelNodesItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChapterContentBlockResponseModelNodesItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "tts_node" => JsonSerializer.SerializeToNode(value.Value, options),
                    "_other" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ChapterContentBlockResponseModelNodesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ChapterContentBlockResponseModelNodesItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChapterContentBlockResponseModelNodesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for tts_node
    /// </summary>
    [Serializable]
    public struct TtsNode
    {
        public TtsNode(global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ChapterContentBlockResponseModelNodesItem.TtsNode(
            global::ElevenLabs.ChapterContentBlockTtsNodeResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for _other
    /// </summary>
    [Serializable]
    public struct _Other
    {
        public _Other(global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ChapterContentBlockResponseModelNodesItem._Other(
            global::ElevenLabs.ChapterContentBlockExtendableNodeResponseModel value
        ) => new(value);
    }
}
