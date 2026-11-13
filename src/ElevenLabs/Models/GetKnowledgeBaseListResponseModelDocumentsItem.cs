// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GetKnowledgeBaseListResponseModelDocumentsItem.JsonConverter))]
[Serializable]
public record GetKnowledgeBaseListResponseModelDocumentsItem
{
    internal GetKnowledgeBaseListResponseModelDocumentsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of GetKnowledgeBaseListResponseModelDocumentsItem with <see cref="GetKnowledgeBaseListResponseModelDocumentsItem.File"/>.
    /// </summary>
    public GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.File value
    )
    {
        Type = "file";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetKnowledgeBaseListResponseModelDocumentsItem with <see cref="GetKnowledgeBaseListResponseModelDocumentsItem.Folder"/>.
    /// </summary>
    public GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.Folder value
    )
    {
        Type = "folder";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetKnowledgeBaseListResponseModelDocumentsItem with <see cref="GetKnowledgeBaseListResponseModelDocumentsItem.Text"/>.
    /// </summary>
    public GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.Text value
    )
    {
        Type = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetKnowledgeBaseListResponseModelDocumentsItem with <see cref="GetKnowledgeBaseListResponseModelDocumentsItem.Url"/>.
    /// </summary>
    public GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.Url value
    )
    {
        Type = "url";
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
    /// Returns true if <see cref="Type"/> is "file"
    /// </summary>
    public bool IsFile => Type == "file";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "folder"
    /// </summary>
    public bool IsFolder => Type == "folder";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "url"
    /// </summary>
    public bool IsUrl => Type == "url";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel"/> if <see cref="Type"/> is 'file', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'file'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel AsFile() =>
        IsFile
            ? (global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel)Value!
            : throw new global::System.Exception(
                "GetKnowledgeBaseListResponseModelDocumentsItem.Type is not 'file'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel"/> if <see cref="Type"/> is 'folder', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'folder'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel AsFolder() =>
        IsFolder
            ? (global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel)Value!
            : throw new global::System.Exception(
                "GetKnowledgeBaseListResponseModelDocumentsItem.Type is not 'folder'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel AsText() =>
        IsText
            ? (global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel)Value!
            : throw new global::System.Exception(
                "GetKnowledgeBaseListResponseModelDocumentsItem.Type is not 'text'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel"/> if <see cref="Type"/> is 'url', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'url'.</exception>
    public global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel AsUrl() =>
        IsUrl
            ? (global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel)Value!
            : throw new global::System.Exception(
                "GetKnowledgeBaseListResponseModelDocumentsItem.Type is not 'url'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel, T> onFile,
        Func<global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel, T> onFolder,
        Func<global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel, T> onText,
        Func<global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel, T> onUrl,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "file" => onFile(AsFile()),
            "folder" => onFolder(AsFolder()),
            "text" => onText(AsText()),
            "url" => onUrl(AsUrl()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel> onFile,
        Action<global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel> onFolder,
        Action<global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel> onText,
        Action<global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel> onUrl,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "file":
                onFile(AsFile());
                break;
            case "folder":
                onFolder(AsFolder());
                break;
            case "text":
                onText(AsText());
                break;
            case "url":
                onUrl(AsUrl());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsFile(out global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel? value)
    {
        if (Type == "file")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsFolder(
        out global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel? value
    )
    {
        if (Type == "folder")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel? value)
    {
        if (Type == "text")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsUrl(out global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel? value)
    {
        if (Type == "url")
        {
            value = (global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.File value
    ) => new(value);

    public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.Folder value
    ) => new(value);

    public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.Text value
    ) => new(value);

    public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem(
        GetKnowledgeBaseListResponseModelDocumentsItem.Url value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<GetKnowledgeBaseListResponseModelDocumentsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(GetKnowledgeBaseListResponseModelDocumentsItem).IsAssignableFrom(typeToConvert);

        public override GetKnowledgeBaseListResponseModelDocumentsItem Read(
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
                "file" =>
                    json.Deserialize<global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel"
                        ),
                "folder" =>
                    json.Deserialize<global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel"
                        ),
                "text" =>
                    json.Deserialize<global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel"
                        ),
                "url" =>
                    json.Deserialize<global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new GetKnowledgeBaseListResponseModelDocumentsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetKnowledgeBaseListResponseModelDocumentsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "file" => JsonSerializer.SerializeToNode(value.Value, options),
                    "folder" => JsonSerializer.SerializeToNode(value.Value, options),
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "url" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override GetKnowledgeBaseListResponseModelDocumentsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new GetKnowledgeBaseListResponseModelDocumentsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetKnowledgeBaseListResponseModelDocumentsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for file
    /// </summary>
    [Serializable]
    public struct File
    {
        public File(global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem.File(
            global::ElevenLabs.GetKnowledgeBaseSummaryFileResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for folder
    /// </summary>
    [Serializable]
    public struct Folder
    {
        public Folder(global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem.Folder(
            global::ElevenLabs.GetKnowledgeBaseSummaryFolderResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem.Text(
            global::ElevenLabs.GetKnowledgeBaseSummaryTextResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for url
    /// </summary>
    [Serializable]
    public struct Url
    {
        public Url(global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetKnowledgeBaseListResponseModelDocumentsItem.Url(
            global::ElevenLabs.GetKnowledgeBaseSummaryUrlResponseModel value
        ) => new(value);
    }
}
