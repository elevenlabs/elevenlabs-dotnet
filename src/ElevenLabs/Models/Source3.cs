// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Source3.JsonConverter))]
[Serializable]
public record Source3
{
    internal Source3(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Source3 with <see cref="Source3.Text"/>.
    /// </summary>
    public Source3(Source3.Text value)
    {
        Type = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Source3 with <see cref="Source3.Url"/>.
    /// </summary>
    public Source3(Source3.Url value)
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
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "url"
    /// </summary>
    public bool IsUrl => Type == "url";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PodcastTextSource"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public global::ElevenLabs.PodcastTextSource AsText() =>
        IsText
            ? (global::ElevenLabs.PodcastTextSource)Value!
            : throw new global::System.Exception("Source3.Type is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PodcastUrlSource"/> if <see cref="Type"/> is 'url', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'url'.</exception>
    public global::ElevenLabs.PodcastUrlSource AsUrl() =>
        IsUrl
            ? (global::ElevenLabs.PodcastUrlSource)Value!
            : throw new global::System.Exception("Source3.Type is not 'url'");

    public T Match<T>(
        Func<global::ElevenLabs.PodcastTextSource, T> onText,
        Func<global::ElevenLabs.PodcastUrlSource, T> onUrl,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "text" => onText(AsText()),
            "url" => onUrl(AsUrl()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PodcastTextSource> onText,
        Action<global::ElevenLabs.PodcastUrlSource> onUrl,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PodcastTextSource"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out global::ElevenLabs.PodcastTextSource? value)
    {
        if (Type == "text")
        {
            value = (global::ElevenLabs.PodcastTextSource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PodcastUrlSource"/> and returns true if successful.
    /// </summary>
    public bool TryAsUrl(out global::ElevenLabs.PodcastUrlSource? value)
    {
        if (Type == "url")
        {
            value = (global::ElevenLabs.PodcastUrlSource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Source3(Source3.Text value) => new(value);

    public static implicit operator Source3(Source3.Url value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Source3>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Source3).IsAssignableFrom(typeToConvert);

        public override Source3 Read(
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
                "text" => json.Deserialize<global::ElevenLabs.PodcastTextSource?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PodcastTextSource"
                    ),
                "url" => json.Deserialize<global::ElevenLabs.PodcastUrlSource?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PodcastUrlSource"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Source3(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Source3 value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "url" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override Source3 ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Source3(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Source3 value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(global::ElevenLabs.PodcastTextSource value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PodcastTextSource Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Source3.Text(global::ElevenLabs.PodcastTextSource value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for url
    /// </summary>
    [Serializable]
    public struct Url
    {
        public Url(global::ElevenLabs.PodcastUrlSource value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PodcastUrlSource Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Source3.Url(global::ElevenLabs.PodcastUrlSource value) =>
            new(value);
    }
}
