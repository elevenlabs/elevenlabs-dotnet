// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WebhookTarget.JsonConverter))]
[Serializable]
public record WebhookTarget
{
    internal WebhookTarget(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WebhookTarget with <see cref="WebhookTarget.All"/>.
    /// </summary>
    public WebhookTarget(WebhookTarget.All value)
    {
        Type = "all";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookTarget with <see cref="WebhookTarget.Ids"/>.
    /// </summary>
    public WebhookTarget(WebhookTarget.Ids value)
    {
        Type = "ids";
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
    /// Returns true if <see cref="Type"/> is "all"
    /// </summary>
    public bool IsAll => Type == "all";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ids"
    /// </summary>
    public bool IsIds => Type == "ids";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WebhookTargetAll"/> if <see cref="Type"/> is 'all', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'all'.</exception>
    public global::ElevenLabs.WebhookTargetAll AsAll() =>
        IsAll
            ? (global::ElevenLabs.WebhookTargetAll)Value!
            : throw new global::System.Exception("WebhookTarget.Type is not 'all'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WebhookTargetIds"/> if <see cref="Type"/> is 'ids', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ids'.</exception>
    public global::ElevenLabs.WebhookTargetIds AsIds() =>
        IsIds
            ? (global::ElevenLabs.WebhookTargetIds)Value!
            : throw new global::System.Exception("WebhookTarget.Type is not 'ids'");

    public T Match<T>(
        Func<global::ElevenLabs.WebhookTargetAll, T> onAll,
        Func<global::ElevenLabs.WebhookTargetIds, T> onIds,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "all" => onAll(AsAll()),
            "ids" => onIds(AsIds()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.WebhookTargetAll> onAll,
        Action<global::ElevenLabs.WebhookTargetIds> onIds,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "all":
                onAll(AsAll());
                break;
            case "ids":
                onIds(AsIds());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WebhookTargetAll"/> and returns true if successful.
    /// </summary>
    public bool TryAsAll(out global::ElevenLabs.WebhookTargetAll? value)
    {
        if (Type == "all")
        {
            value = (global::ElevenLabs.WebhookTargetAll)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WebhookTargetIds"/> and returns true if successful.
    /// </summary>
    public bool TryAsIds(out global::ElevenLabs.WebhookTargetIds? value)
    {
        if (Type == "ids")
        {
            value = (global::ElevenLabs.WebhookTargetIds)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WebhookTarget(WebhookTarget.All value) => new(value);

    public static implicit operator WebhookTarget(WebhookTarget.Ids value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WebhookTarget>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WebhookTarget).IsAssignableFrom(typeToConvert);

        public override WebhookTarget Read(
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
                "all" => json.Deserialize<global::ElevenLabs.WebhookTargetAll?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WebhookTargetAll"
                    ),
                "ids" => json.Deserialize<global::ElevenLabs.WebhookTargetIds?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WebhookTargetIds"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new WebhookTarget(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookTarget value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "all" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ids" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override WebhookTarget ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WebhookTarget(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookTarget value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for all
    /// </summary>
    [Serializable]
    public struct All
    {
        public All(global::ElevenLabs.WebhookTargetAll value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WebhookTargetAll Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookTarget.All(
            global::ElevenLabs.WebhookTargetAll value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ids
    /// </summary>
    [Serializable]
    public struct Ids
    {
        public Ids(global::ElevenLabs.WebhookTargetIds value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WebhookTargetIds Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookTarget.Ids(
            global::ElevenLabs.WebhookTargetIds value
        ) => new(value);
    }
}
