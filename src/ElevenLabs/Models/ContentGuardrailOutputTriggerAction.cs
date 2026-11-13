// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ContentGuardrailOutputTriggerAction.JsonConverter))]
[Serializable]
public record ContentGuardrailOutputTriggerAction
{
    internal ContentGuardrailOutputTriggerAction(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ContentGuardrailOutputTriggerAction with <see cref="ContentGuardrailOutputTriggerAction.EndCall"/>.
    /// </summary>
    public ContentGuardrailOutputTriggerAction(ContentGuardrailOutputTriggerAction.EndCall value)
    {
        Type = "end_call";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentGuardrailOutputTriggerAction with <see cref="ContentGuardrailOutputTriggerAction.Retry"/>.
    /// </summary>
    public ContentGuardrailOutputTriggerAction(ContentGuardrailOutputTriggerAction.Retry value)
    {
        Type = "retry";
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
    /// Returns true if <see cref="Type"/> is "end_call"
    /// </summary>
    public bool IsEndCall => Type == "end_call";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "retry"
    /// </summary>
    public bool IsRetry => Type == "retry";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.EndCallTriggerAction"/> if <see cref="Type"/> is 'end_call', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'end_call'.</exception>
    public global::ElevenLabs.EndCallTriggerAction AsEndCall() =>
        IsEndCall
            ? (global::ElevenLabs.EndCallTriggerAction)Value!
            : throw new global::System.Exception(
                "ContentGuardrailOutputTriggerAction.Type is not 'end_call'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.RetryTriggerAction"/> if <see cref="Type"/> is 'retry', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'retry'.</exception>
    public global::ElevenLabs.RetryTriggerAction AsRetry() =>
        IsRetry
            ? (global::ElevenLabs.RetryTriggerAction)Value!
            : throw new global::System.Exception(
                "ContentGuardrailOutputTriggerAction.Type is not 'retry'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.EndCallTriggerAction, T> onEndCall,
        Func<global::ElevenLabs.RetryTriggerAction, T> onRetry,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "end_call" => onEndCall(AsEndCall()),
            "retry" => onRetry(AsRetry()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.EndCallTriggerAction> onEndCall,
        Action<global::ElevenLabs.RetryTriggerAction> onRetry,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "end_call":
                onEndCall(AsEndCall());
                break;
            case "retry":
                onRetry(AsRetry());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.EndCallTriggerAction"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndCall(out global::ElevenLabs.EndCallTriggerAction? value)
    {
        if (Type == "end_call")
        {
            value = (global::ElevenLabs.EndCallTriggerAction)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.RetryTriggerAction"/> and returns true if successful.
    /// </summary>
    public bool TryAsRetry(out global::ElevenLabs.RetryTriggerAction? value)
    {
        if (Type == "retry")
        {
            value = (global::ElevenLabs.RetryTriggerAction)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ContentGuardrailOutputTriggerAction(
        ContentGuardrailOutputTriggerAction.EndCall value
    ) => new(value);

    public static implicit operator ContentGuardrailOutputTriggerAction(
        ContentGuardrailOutputTriggerAction.Retry value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ContentGuardrailOutputTriggerAction>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ContentGuardrailOutputTriggerAction).IsAssignableFrom(typeToConvert);

        public override ContentGuardrailOutputTriggerAction Read(
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
                "end_call" => json.Deserialize<global::ElevenLabs.EndCallTriggerAction?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.EndCallTriggerAction"
                    ),
                "retry" => json.Deserialize<global::ElevenLabs.RetryTriggerAction?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.RetryTriggerAction"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ContentGuardrailOutputTriggerAction(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContentGuardrailOutputTriggerAction value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "end_call" => JsonSerializer.SerializeToNode(value.Value, options),
                    "retry" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ContentGuardrailOutputTriggerAction ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ContentGuardrailOutputTriggerAction(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContentGuardrailOutputTriggerAction value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for end_call
    /// </summary>
    [Serializable]
    public struct EndCall
    {
        public EndCall(global::ElevenLabs.EndCallTriggerAction value)
        {
            Value = value;
        }

        internal global::ElevenLabs.EndCallTriggerAction Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentGuardrailOutputTriggerAction.EndCall(
            global::ElevenLabs.EndCallTriggerAction value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for retry
    /// </summary>
    [Serializable]
    public struct Retry
    {
        public Retry(global::ElevenLabs.RetryTriggerAction value)
        {
            Value = value;
        }

        internal global::ElevenLabs.RetryTriggerAction Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentGuardrailOutputTriggerAction.Retry(
            global::ElevenLabs.RetryTriggerAction value
        ) => new(value);
    }
}
