// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(FileContentPartSource.JsonConverter))]
[Serializable]
public record FileContentPartSource
{
    internal FileContentPartSource(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of FileContentPartSource with <see cref="FileContentPartSource.Base64"/>.
    /// </summary>
    public FileContentPartSource(FileContentPartSource.Base64 value)
    {
        Type = "base64";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FileContentPartSource with <see cref="FileContentPartSource.FileId"/>.
    /// </summary>
    public FileContentPartSource(FileContentPartSource.FileId value)
    {
        Type = "file_id";
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
    /// Returns true if <see cref="Type"/> is "base64"
    /// </summary>
    public bool IsBase64 => Type == "base64";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "file_id"
    /// </summary>
    public bool IsFileId => Type == "file_id";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Base64FileSource"/> if <see cref="Type"/> is 'base64', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'base64'.</exception>
    public global::ElevenLabs.Base64FileSource AsBase64() =>
        IsBase64
            ? (global::ElevenLabs.Base64FileSource)Value!
            : throw new global::System.Exception("FileContentPartSource.Type is not 'base64'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.FileIdSource"/> if <see cref="Type"/> is 'file_id', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'file_id'.</exception>
    public global::ElevenLabs.FileIdSource AsFileId() =>
        IsFileId
            ? (global::ElevenLabs.FileIdSource)Value!
            : throw new global::System.Exception("FileContentPartSource.Type is not 'file_id'");

    public T Match<T>(
        Func<global::ElevenLabs.Base64FileSource, T> onBase64,
        Func<global::ElevenLabs.FileIdSource, T> onFileId,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "base64" => onBase64(AsBase64()),
            "file_id" => onFileId(AsFileId()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.Base64FileSource> onBase64,
        Action<global::ElevenLabs.FileIdSource> onFileId,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "base64":
                onBase64(AsBase64());
                break;
            case "file_id":
                onFileId(AsFileId());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Base64FileSource"/> and returns true if successful.
    /// </summary>
    public bool TryAsBase64(out global::ElevenLabs.Base64FileSource? value)
    {
        if (Type == "base64")
        {
            value = (global::ElevenLabs.Base64FileSource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.FileIdSource"/> and returns true if successful.
    /// </summary>
    public bool TryAsFileId(out global::ElevenLabs.FileIdSource? value)
    {
        if (Type == "file_id")
        {
            value = (global::ElevenLabs.FileIdSource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator FileContentPartSource(FileContentPartSource.Base64 value) =>
        new(value);

    public static implicit operator FileContentPartSource(FileContentPartSource.FileId value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FileContentPartSource>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(FileContentPartSource).IsAssignableFrom(typeToConvert);

        public override FileContentPartSource Read(
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
                "base64" => json.Deserialize<global::ElevenLabs.Base64FileSource?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.Base64FileSource"
                    ),
                "file_id" => json.Deserialize<global::ElevenLabs.FileIdSource?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.FileIdSource"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new FileContentPartSource(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FileContentPartSource value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "base64" => JsonSerializer.SerializeToNode(value.Value, options),
                    "file_id" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override FileContentPartSource ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new FileContentPartSource(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FileContentPartSource value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for base64
    /// </summary>
    [Serializable]
    public struct Base64
    {
        public Base64(global::ElevenLabs.Base64FileSource value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Base64FileSource Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator FileContentPartSource.Base64(
            global::ElevenLabs.Base64FileSource value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for file_id
    /// </summary>
    [Serializable]
    public struct FileId
    {
        public FileId(global::ElevenLabs.FileIdSource value)
        {
            Value = value;
        }

        internal global::ElevenLabs.FileIdSource Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator FileContentPartSource.FileId(
            global::ElevenLabs.FileIdSource value
        ) => new(value);
    }
}
