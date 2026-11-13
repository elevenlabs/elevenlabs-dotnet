// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.JsonConverter)
)]
[Serializable]
public record ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost
{
    internal ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        string type,
        object? value
    )
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost with <see cref="ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Url"/>.
    /// </summary>
    public ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Url value
    )
    {
        Type = "url";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost with <see cref="ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.File"/>.
    /// </summary>
    public ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.File value
    )
    {
        Type = "file";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost with <see cref="ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Text"/>.
    /// </summary>
    public ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Text value
    )
    {
        Type = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost with <see cref="ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Folder"/>.
    /// </summary>
    public ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Folder value
    )
    {
        Type = "folder";
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
    /// Returns true if <see cref="Type"/> is "url"
    /// </summary>
    public bool IsUrl => Type == "url";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "file"
    /// </summary>
    public bool IsFile => Type == "file";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "folder"
    /// </summary>
    public bool IsFolder => Type == "folder";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseUrlResponseModel"/> if <see cref="Type"/> is 'url', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'url'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseUrlResponseModel AsUrl() =>
        IsUrl
            ? (global::ElevenLabs.GetKnowledgeBaseUrlResponseModel)Value!
            : throw new global::System.Exception(
                "ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Type is not 'url'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseFileResponseModel"/> if <see cref="Type"/> is 'file', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'file'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseFileResponseModel AsFile() =>
        IsFile
            ? (global::ElevenLabs.GetKnowledgeBaseFileResponseModel)Value!
            : throw new global::System.Exception(
                "ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Type is not 'file'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseTextResponseModel"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseTextResponseModel AsText() =>
        IsText
            ? (global::ElevenLabs.GetKnowledgeBaseTextResponseModel)Value!
            : throw new global::System.Exception(
                "ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Type is not 'text'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseFolderResponseModel"/> if <see cref="Type"/> is 'folder', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'folder'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseFolderResponseModel AsFolder() =>
        IsFolder
            ? (global::ElevenLabs.GetKnowledgeBaseFolderResponseModel)Value!
            : throw new global::System.Exception(
                "ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Type is not 'folder'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.GetKnowledgeBaseUrlResponseModel, T> onUrl,
        Func<global::ElevenLabs.GetKnowledgeBaseFileResponseModel, T> onFile,
        Func<global::ElevenLabs.GetKnowledgeBaseTextResponseModel, T> onText,
        Func<global::ElevenLabs.GetKnowledgeBaseFolderResponseModel, T> onFolder,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "url" => onUrl(AsUrl()),
            "file" => onFile(AsFile()),
            "text" => onText(AsText()),
            "folder" => onFolder(AsFolder()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.GetKnowledgeBaseUrlResponseModel> onUrl,
        Action<global::ElevenLabs.GetKnowledgeBaseFileResponseModel> onFile,
        Action<global::ElevenLabs.GetKnowledgeBaseTextResponseModel> onText,
        Action<global::ElevenLabs.GetKnowledgeBaseFolderResponseModel> onFolder,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "url":
                onUrl(AsUrl());
                break;
            case "file":
                onFile(AsFile());
                break;
            case "text":
                onText(AsText());
                break;
            case "folder":
                onFolder(AsFolder());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseUrlResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsUrl(out global::ElevenLabs.GetKnowledgeBaseUrlResponseModel? value)
    {
        if (Type == "url")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseUrlResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseFileResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsFile(out global::ElevenLabs.GetKnowledgeBaseFileResponseModel? value)
    {
        if (Type == "file")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseFileResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseTextResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out global::ElevenLabs.GetKnowledgeBaseTextResponseModel? value)
    {
        if (Type == "text")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseTextResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseFolderResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsFolder(out global::ElevenLabs.GetKnowledgeBaseFolderResponseModel? value)
    {
        if (Type == "folder")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseFolderResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Url value
    ) => new(value);

    public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.File value
    ) => new(value);

    public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Text value
    ) => new(value);

    public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
        ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Folder value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost).IsAssignableFrom(
                typeToConvert
            );

        public override ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost Read(
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
                "url" => json.Deserialize<global::ElevenLabs.GetKnowledgeBaseUrlResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseUrlResponseModel"
                    ),
                "file" => json.Deserialize<global::ElevenLabs.GetKnowledgeBaseFileResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseFileResponseModel"
                    ),
                "text" => json.Deserialize<global::ElevenLabs.GetKnowledgeBaseTextResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseTextResponseModel"
                    ),
                "folder" =>
                    json.Deserialize<global::ElevenLabs.GetKnowledgeBaseFolderResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseFolderResponseModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "url" => JsonSerializer.SerializeToNode(value.Value, options),
                    "file" => JsonSerializer.SerializeToNode(value.Value, options),
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "folder" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for url
    /// </summary>
    [Serializable]
    public struct Url
    {
        public Url(global::ElevenLabs.GetKnowledgeBaseUrlResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseUrlResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Url(
            global::ElevenLabs.GetKnowledgeBaseUrlResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for file
    /// </summary>
    [Serializable]
    public struct File
    {
        public File(global::ElevenLabs.GetKnowledgeBaseFileResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseFileResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.File(
            global::ElevenLabs.GetKnowledgeBaseFileResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(global::ElevenLabs.GetKnowledgeBaseTextResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseTextResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Text(
            global::ElevenLabs.GetKnowledgeBaseTextResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for folder
    /// </summary>
    [Serializable]
    public struct Folder
    {
        public Folder(global::ElevenLabs.GetKnowledgeBaseFolderResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseFolderResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost.Folder(
            global::ElevenLabs.GetKnowledgeBaseFolderResponseModel value
        ) => new(value);
    }
}
