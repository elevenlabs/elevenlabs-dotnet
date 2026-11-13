// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AlertingSettingsNotifiersItem.JsonConverter))]
[Serializable]
public record AlertingSettingsNotifiersItem
{
    internal AlertingSettingsNotifiersItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AlertingSettingsNotifiersItem with <see cref="AlertingSettingsNotifiersItem.Webhook"/>.
    /// </summary>
    public AlertingSettingsNotifiersItem(AlertingSettingsNotifiersItem.Webhook value)
    {
        Type = "webhook";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AlertingSettingsNotifiersItem with <see cref="AlertingSettingsNotifiersItem.Integration"/>.
    /// </summary>
    public AlertingSettingsNotifiersItem(AlertingSettingsNotifiersItem.Integration value)
    {
        Type = "integration";
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
    /// Returns true if <see cref="Type"/> is "webhook"
    /// </summary>
    public bool IsWebhook => Type == "webhook";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "integration"
    /// </summary>
    public bool IsIntegration => Type == "integration";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AlertingWebhookNotifier"/> if <see cref="Type"/> is 'webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook'.</exception>
    public global::ElevenLabs.AlertingWebhookNotifier AsWebhook() =>
        IsWebhook
            ? (global::ElevenLabs.AlertingWebhookNotifier)Value!
            : throw new global::System.Exception(
                "AlertingSettingsNotifiersItem.Type is not 'webhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AlertingIntegrationNotifier"/> if <see cref="Type"/> is 'integration', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'integration'.</exception>
    public global::ElevenLabs.AlertingIntegrationNotifier AsIntegration() =>
        IsIntegration
            ? (global::ElevenLabs.AlertingIntegrationNotifier)Value!
            : throw new global::System.Exception(
                "AlertingSettingsNotifiersItem.Type is not 'integration'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.AlertingWebhookNotifier, T> onWebhook,
        Func<global::ElevenLabs.AlertingIntegrationNotifier, T> onIntegration,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "webhook" => onWebhook(AsWebhook()),
            "integration" => onIntegration(AsIntegration()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.AlertingWebhookNotifier> onWebhook,
        Action<global::ElevenLabs.AlertingIntegrationNotifier> onIntegration,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "webhook":
                onWebhook(AsWebhook());
                break;
            case "integration":
                onIntegration(AsIntegration());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AlertingWebhookNotifier"/> and returns true if successful.
    /// </summary>
    public bool TryAsWebhook(out global::ElevenLabs.AlertingWebhookNotifier? value)
    {
        if (Type == "webhook")
        {
            value = (global::ElevenLabs.AlertingWebhookNotifier)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AlertingIntegrationNotifier"/> and returns true if successful.
    /// </summary>
    public bool TryAsIntegration(out global::ElevenLabs.AlertingIntegrationNotifier? value)
    {
        if (Type == "integration")
        {
            value = (global::ElevenLabs.AlertingIntegrationNotifier)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AlertingSettingsNotifiersItem(
        AlertingSettingsNotifiersItem.Webhook value
    ) => new(value);

    public static implicit operator AlertingSettingsNotifiersItem(
        AlertingSettingsNotifiersItem.Integration value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AlertingSettingsNotifiersItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AlertingSettingsNotifiersItem).IsAssignableFrom(typeToConvert);

        public override AlertingSettingsNotifiersItem Read(
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
                "webhook" => json.Deserialize<global::ElevenLabs.AlertingWebhookNotifier?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AlertingWebhookNotifier"
                    ),
                "integration" => json.Deserialize<global::ElevenLabs.AlertingIntegrationNotifier?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AlertingIntegrationNotifier"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new AlertingSettingsNotifiersItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingSettingsNotifiersItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "webhook" => JsonSerializer.SerializeToNode(value.Value, options),
                    "integration" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override AlertingSettingsNotifiersItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AlertingSettingsNotifiersItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingSettingsNotifiersItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for webhook
    /// </summary>
    [Serializable]
    public struct Webhook
    {
        public Webhook(global::ElevenLabs.AlertingWebhookNotifier value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AlertingWebhookNotifier Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AlertingSettingsNotifiersItem.Webhook(
            global::ElevenLabs.AlertingWebhookNotifier value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for integration
    /// </summary>
    [Serializable]
    public struct Integration
    {
        public Integration(global::ElevenLabs.AlertingIntegrationNotifier value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AlertingIntegrationNotifier Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AlertingSettingsNotifiersItem.Integration(
            global::ElevenLabs.AlertingIntegrationNotifier value
        ) => new(value);
    }
}
