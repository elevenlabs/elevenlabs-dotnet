// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(SendConversationMessageRequestInputItem.JsonConverter))]
[Serializable]
public record SendConversationMessageRequestInputItem
{
    internal SendConversationMessageRequestInputItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SendConversationMessageRequestInputItem with <see cref="SendConversationMessageRequestInputItem.ClientToolResult"/>.
    /// </summary>
    public SendConversationMessageRequestInputItem(
        SendConversationMessageRequestInputItem.ClientToolResult value
    )
    {
        Type = "client_tool_result";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SendConversationMessageRequestInputItem with <see cref="SendConversationMessageRequestInputItem.ContextualUpdate"/>.
    /// </summary>
    public SendConversationMessageRequestInputItem(
        SendConversationMessageRequestInputItem.ContextualUpdate value
    )
    {
        Type = "contextual_update";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SendConversationMessageRequestInputItem with <see cref="SendConversationMessageRequestInputItem.UserMessage"/>.
    /// </summary>
    public SendConversationMessageRequestInputItem(
        SendConversationMessageRequestInputItem.UserMessage value
    )
    {
        Type = "user_message";
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
    /// Returns true if <see cref="Type"/> is "client_tool_result"
    /// </summary>
    public bool IsClientToolResult => Type == "client_tool_result";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "contextual_update"
    /// </summary>
    public bool IsContextualUpdate => Type == "contextual_update";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "user_message"
    /// </summary>
    public bool IsUserMessage => Type == "user_message";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ClientToolResultItem"/> if <see cref="Type"/> is 'client_tool_result', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'client_tool_result'.</exception>
    public global::ElevenLabs.ClientToolResultItem AsClientToolResult() =>
        IsClientToolResult
            ? (global::ElevenLabs.ClientToolResultItem)Value!
            : throw new global::System.Exception(
                "SendConversationMessageRequestInputItem.Type is not 'client_tool_result'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ContextualUpdateInputItem"/> if <see cref="Type"/> is 'contextual_update', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'contextual_update'.</exception>
    public global::ElevenLabs.ContextualUpdateInputItem AsContextualUpdate() =>
        IsContextualUpdate
            ? (global::ElevenLabs.ContextualUpdateInputItem)Value!
            : throw new global::System.Exception(
                "SendConversationMessageRequestInputItem.Type is not 'contextual_update'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UserMessageInputItem"/> if <see cref="Type"/> is 'user_message', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user_message'.</exception>
    public global::ElevenLabs.UserMessageInputItem AsUserMessage() =>
        IsUserMessage
            ? (global::ElevenLabs.UserMessageInputItem)Value!
            : throw new global::System.Exception(
                "SendConversationMessageRequestInputItem.Type is not 'user_message'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ClientToolResultItem, T> onClientToolResult,
        Func<global::ElevenLabs.ContextualUpdateInputItem, T> onContextualUpdate,
        Func<global::ElevenLabs.UserMessageInputItem, T> onUserMessage,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "client_tool_result" => onClientToolResult(AsClientToolResult()),
            "contextual_update" => onContextualUpdate(AsContextualUpdate()),
            "user_message" => onUserMessage(AsUserMessage()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ClientToolResultItem> onClientToolResult,
        Action<global::ElevenLabs.ContextualUpdateInputItem> onContextualUpdate,
        Action<global::ElevenLabs.UserMessageInputItem> onUserMessage,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "client_tool_result":
                onClientToolResult(AsClientToolResult());
                break;
            case "contextual_update":
                onContextualUpdate(AsContextualUpdate());
                break;
            case "user_message":
                onUserMessage(AsUserMessage());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ClientToolResultItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsClientToolResult(out global::ElevenLabs.ClientToolResultItem? value)
    {
        if (Type == "client_tool_result")
        {
            value = (global::ElevenLabs.ClientToolResultItem)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ContextualUpdateInputItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsContextualUpdate(out global::ElevenLabs.ContextualUpdateInputItem? value)
    {
        if (Type == "contextual_update")
        {
            value = (global::ElevenLabs.ContextualUpdateInputItem)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UserMessageInputItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsUserMessage(out global::ElevenLabs.UserMessageInputItem? value)
    {
        if (Type == "user_message")
        {
            value = (global::ElevenLabs.UserMessageInputItem)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SendConversationMessageRequestInputItem(
        SendConversationMessageRequestInputItem.ClientToolResult value
    ) => new(value);

    public static implicit operator SendConversationMessageRequestInputItem(
        SendConversationMessageRequestInputItem.ContextualUpdate value
    ) => new(value);

    public static implicit operator SendConversationMessageRequestInputItem(
        SendConversationMessageRequestInputItem.UserMessage value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SendConversationMessageRequestInputItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SendConversationMessageRequestInputItem).IsAssignableFrom(typeToConvert);

        public override SendConversationMessageRequestInputItem Read(
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
                "client_tool_result" => json.Deserialize<global::ElevenLabs.ClientToolResultItem?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ClientToolResultItem"
                    ),
                "contextual_update" =>
                    json.Deserialize<global::ElevenLabs.ContextualUpdateInputItem?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ContextualUpdateInputItem"
                        ),
                "user_message" => json.Deserialize<global::ElevenLabs.UserMessageInputItem?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UserMessageInputItem"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new SendConversationMessageRequestInputItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendConversationMessageRequestInputItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "client_tool_result" => JsonSerializer.SerializeToNode(value.Value, options),
                    "contextual_update" => JsonSerializer.SerializeToNode(value.Value, options),
                    "user_message" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override SendConversationMessageRequestInputItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SendConversationMessageRequestInputItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendConversationMessageRequestInputItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for client_tool_result
    /// </summary>
    [Serializable]
    public struct ClientToolResult
    {
        public ClientToolResult(global::ElevenLabs.ClientToolResultItem value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ClientToolResultItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendConversationMessageRequestInputItem.ClientToolResult(
            global::ElevenLabs.ClientToolResultItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for contextual_update
    /// </summary>
    [Serializable]
    public struct ContextualUpdate
    {
        public ContextualUpdate(global::ElevenLabs.ContextualUpdateInputItem value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ContextualUpdateInputItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendConversationMessageRequestInputItem.ContextualUpdate(
            global::ElevenLabs.ContextualUpdateInputItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user_message
    /// </summary>
    [Serializable]
    public struct UserMessage
    {
        public UserMessage(global::ElevenLabs.UserMessageInputItem value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UserMessageInputItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SendConversationMessageRequestInputItem.UserMessage(
            global::ElevenLabs.UserMessageInputItem value
        ) => new(value);
    }
}
