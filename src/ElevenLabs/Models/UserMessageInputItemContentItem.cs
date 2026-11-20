// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UserMessageInputItemContentItem.JsonConverter))]
[Serializable]
public record UserMessageInputItemContentItem
{
    internal UserMessageInputItemContentItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UserMessageInputItemContentItem with <see cref="UserMessageInputItemContentItem.File"/>.
    /// </summary>
    public UserMessageInputItemContentItem(UserMessageInputItemContentItem.File value)
    {
        Type = "file";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of UserMessageInputItemContentItem with <see cref="UserMessageInputItemContentItem.Text"/>.
    /// </summary>
    public UserMessageInputItemContentItem(UserMessageInputItemContentItem.Text value)
    {
        Type = "text";
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
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.FileContentPart"/> if <see cref="Type"/> is 'file', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'file'.</exception>
    public global::ElevenLabs.FileContentPart AsFile() =>
        IsFile
            ? (global::ElevenLabs.FileContentPart)Value!
            : throw new global::System.Exception(
                "UserMessageInputItemContentItem.Type is not 'file'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TextContentPart"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public global::ElevenLabs.TextContentPart AsText() =>
        IsText
            ? (global::ElevenLabs.TextContentPart)Value!
            : throw new global::System.Exception(
                "UserMessageInputItemContentItem.Type is not 'text'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.FileContentPart, T> onFile,
        Func<global::ElevenLabs.TextContentPart, T> onText,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "file" => onFile(AsFile()),
            "text" => onText(AsText()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.FileContentPart> onFile,
        Action<global::ElevenLabs.TextContentPart> onText,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "file":
                onFile(AsFile());
                break;
            case "text":
                onText(AsText());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.FileContentPart"/> and returns true if successful.
    /// </summary>
    public bool TryAsFile(out global::ElevenLabs.FileContentPart? value)
    {
        if (Type == "file")
        {
            value = (global::ElevenLabs.FileContentPart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TextContentPart"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out global::ElevenLabs.TextContentPart? value)
    {
        if (Type == "text")
        {
            value = (global::ElevenLabs.TextContentPart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UserMessageInputItemContentItem(
        UserMessageInputItemContentItem.File value
    ) => new(value);

    public static implicit operator UserMessageInputItemContentItem(
        UserMessageInputItemContentItem.Text value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UserMessageInputItemContentItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UserMessageInputItemContentItem).IsAssignableFrom(typeToConvert);

        public override UserMessageInputItemContentItem Read(
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
                "file" => json.Deserialize<global::ElevenLabs.FileContentPart?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.FileContentPart"
                    ),
                "text" => json.Deserialize<global::ElevenLabs.TextContentPart?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TextContentPart"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new UserMessageInputItemContentItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserMessageInputItemContentItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "file" => JsonSerializer.SerializeToNode(value.Value, options),
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override UserMessageInputItemContentItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UserMessageInputItemContentItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserMessageInputItemContentItem value,
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
        public File(global::ElevenLabs.FileContentPart value)
        {
            Value = value;
        }

        internal global::ElevenLabs.FileContentPart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UserMessageInputItemContentItem.File(
            global::ElevenLabs.FileContentPart value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(global::ElevenLabs.TextContentPart value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TextContentPart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UserMessageInputItemContentItem.Text(
            global::ElevenLabs.TextContentPart value
        ) => new(value);
    }
}
