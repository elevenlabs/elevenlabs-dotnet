// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AlertingSettingsResponseNotifiersItem.JsonConverter))]
[Serializable]
public record AlertingSettingsResponseNotifiersItem
{
    internal AlertingSettingsResponseNotifiersItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AlertingSettingsResponseNotifiersItem with <see cref="AlertingSettingsResponseNotifiersItem.Webhook"/>.
    /// </summary>
    public AlertingSettingsResponseNotifiersItem(
        AlertingSettingsResponseNotifiersItem.Webhook value
    )
    {
        Type = "webhook";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AlertingSettingsResponseNotifiersItem with <see cref="AlertingSettingsResponseNotifiersItem.Integration"/>.
    /// </summary>
    public AlertingSettingsResponseNotifiersItem(
        AlertingSettingsResponseNotifiersItem.Integration value
    )
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
    /// Returns the value as a <see cref="global::ElevenLabs.AlertingWebhookNotifierResponse"/> if <see cref="Type"/> is 'webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook'.</exception>
    public global::ElevenLabs.AlertingWebhookNotifierResponse AsWebhook() =>
        IsWebhook
            ? (global::ElevenLabs.AlertingWebhookNotifierResponse)Value!
            : throw new global::System.Exception(
                "AlertingSettingsResponseNotifiersItem.Type is not 'webhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AlertingIntegrationNotifierResponse"/> if <see cref="Type"/> is 'integration', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'integration'.</exception>
    public global::ElevenLabs.AlertingIntegrationNotifierResponse AsIntegration() =>
        IsIntegration
            ? (global::ElevenLabs.AlertingIntegrationNotifierResponse)Value!
            : throw new global::System.Exception(
                "AlertingSettingsResponseNotifiersItem.Type is not 'integration'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.AlertingWebhookNotifierResponse, T> onWebhook,
        Func<global::ElevenLabs.AlertingIntegrationNotifierResponse, T> onIntegration,
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
        Action<global::ElevenLabs.AlertingWebhookNotifierResponse> onWebhook,
        Action<global::ElevenLabs.AlertingIntegrationNotifierResponse> onIntegration,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AlertingWebhookNotifierResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsWebhook(out global::ElevenLabs.AlertingWebhookNotifierResponse? value)
    {
        if (Type == "webhook")
        {
            value = (global::ElevenLabs.AlertingWebhookNotifierResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AlertingIntegrationNotifierResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsIntegration(out global::ElevenLabs.AlertingIntegrationNotifierResponse? value)
    {
        if (Type == "integration")
        {
            value = (global::ElevenLabs.AlertingIntegrationNotifierResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AlertingSettingsResponseNotifiersItem(
        AlertingSettingsResponseNotifiersItem.Webhook value
    ) => new(value);

    public static implicit operator AlertingSettingsResponseNotifiersItem(
        AlertingSettingsResponseNotifiersItem.Integration value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AlertingSettingsResponseNotifiersItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AlertingSettingsResponseNotifiersItem).IsAssignableFrom(typeToConvert);

        public override AlertingSettingsResponseNotifiersItem Read(
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
                "webhook" => json.Deserialize<global::ElevenLabs.AlertingWebhookNotifierResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AlertingWebhookNotifierResponse"
                    ),
                "integration" =>
                    json.Deserialize<global::ElevenLabs.AlertingIntegrationNotifierResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AlertingIntegrationNotifierResponse"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new AlertingSettingsResponseNotifiersItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingSettingsResponseNotifiersItem value,
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

        public override AlertingSettingsResponseNotifiersItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AlertingSettingsResponseNotifiersItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingSettingsResponseNotifiersItem value,
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
        public Webhook(global::ElevenLabs.AlertingWebhookNotifierResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AlertingWebhookNotifierResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AlertingSettingsResponseNotifiersItem.Webhook(
            global::ElevenLabs.AlertingWebhookNotifierResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for integration
    /// </summary>
    [Serializable]
    public struct Integration
    {
        public Integration(global::ElevenLabs.AlertingIntegrationNotifierResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AlertingIntegrationNotifierResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AlertingSettingsResponseNotifiersItem.Integration(
            global::ElevenLabs.AlertingIntegrationNotifierResponse value
        ) => new(value);
    }
}
