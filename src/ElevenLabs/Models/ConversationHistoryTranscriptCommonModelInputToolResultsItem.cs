// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationHistoryTranscriptCommonModelInputToolResultsItem.JsonConverter))]
[Serializable]
public class ConversationHistoryTranscriptCommonModelInputToolResultsItem
{
    private ConversationHistoryTranscriptCommonModelInputToolResultsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a ConversationHistoryTranscriptCommonModelInputToolResultsItem from a ConversationHistoryTranscriptOtherToolsResultCommonModel value.
    /// </summary>
    public static ConversationHistoryTranscriptCommonModelInputToolResultsItem FromConversationHistoryTranscriptOtherToolsResultCommonModel(
        global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel value
    ) => new("conversationHistoryTranscriptOtherToolsResultCommonModel", value);

    /// <summary>
    /// Create a ConversationHistoryTranscriptCommonModelInputToolResultsItem from a ConversationHistoryTranscriptSystemToolResultCommonModelInput value.
    /// </summary>
    public static ConversationHistoryTranscriptCommonModelInputToolResultsItem FromConversationHistoryTranscriptSystemToolResultCommonModelInput(
        global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput value
    ) => new("conversationHistoryTranscriptSystemToolResultCommonModelInput", value);

    /// <summary>
    /// Create a ConversationHistoryTranscriptCommonModelInputToolResultsItem from a ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput value.
    /// </summary>
    public static ConversationHistoryTranscriptCommonModelInputToolResultsItem FromConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput(
        global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput value
    ) =>
        new("conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput", value);

    /// <summary>
    /// Create a ConversationHistoryTranscriptCommonModelInputToolResultsItem from a ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput value.
    /// </summary>
    public static ConversationHistoryTranscriptCommonModelInputToolResultsItem FromConversationHistoryTranscriptWorkflowToolsResultCommonModelInput(
        global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput value
    ) => new("conversationHistoryTranscriptWorkflowToolsResultCommonModelInput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptOtherToolsResultCommonModel".
    /// </summary>
    public bool IsConversationHistoryTranscriptOtherToolsResultCommonModel() =>
        Type == "conversationHistoryTranscriptOtherToolsResultCommonModel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptSystemToolResultCommonModelInput".
    /// </summary>
    public bool IsConversationHistoryTranscriptSystemToolResultCommonModelInput() =>
        Type == "conversationHistoryTranscriptSystemToolResultCommonModelInput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput".
    /// </summary>
    public bool IsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput() =>
        Type == "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput".
    /// </summary>
    public bool IsConversationHistoryTranscriptWorkflowToolsResultCommonModelInput() =>
        Type == "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput";

    /// <summary>
    /// Returns the value as a ConversationHistoryTranscriptOtherToolsResultCommonModel if <see cref="Type"/> is "conversationHistoryTranscriptOtherToolsResultCommonModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationHistoryTranscriptOtherToolsResultCommonModel'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel AsConversationHistoryTranscriptOtherToolsResultCommonModel() =>
        IsConversationHistoryTranscriptOtherToolsResultCommonModel()
            ? (global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationHistoryTranscriptOtherToolsResultCommonModel'"
            );

    /// <summary>
    /// Returns the value as a ConversationHistoryTranscriptSystemToolResultCommonModelInput if <see cref="Type"/> is "conversationHistoryTranscriptSystemToolResultCommonModelInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationHistoryTranscriptSystemToolResultCommonModelInput'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput AsConversationHistoryTranscriptSystemToolResultCommonModelInput() =>
        IsConversationHistoryTranscriptSystemToolResultCommonModelInput()
            ? (global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput)
                Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationHistoryTranscriptSystemToolResultCommonModelInput'"
            );

    /// <summary>
    /// Returns the value as a ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput if <see cref="Type"/> is "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput AsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput() =>
        IsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput()
            ? (global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput)
                Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput'"
            );

    /// <summary>
    /// Returns the value as a ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput if <see cref="Type"/> is "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationHistoryTranscriptWorkflowToolsResultCommonModelInput'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput AsConversationHistoryTranscriptWorkflowToolsResultCommonModelInput() =>
        IsConversationHistoryTranscriptWorkflowToolsResultCommonModelInput()
            ? (global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput)
                Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationHistoryTranscriptWorkflowToolsResultCommonModelInput'"
            );

    /// <summary>
    /// Attempts to cast the value to a ConversationHistoryTranscriptOtherToolsResultCommonModel and returns true if successful.
    /// </summary>
    public bool TryGetConversationHistoryTranscriptOtherToolsResultCommonModel(
        out global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel? value
    )
    {
        if (Type == "conversationHistoryTranscriptOtherToolsResultCommonModel")
        {
            value = (global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationHistoryTranscriptSystemToolResultCommonModelInput and returns true if successful.
    /// </summary>
    public bool TryGetConversationHistoryTranscriptSystemToolResultCommonModelInput(
        out global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput? value
    )
    {
        if (Type == "conversationHistoryTranscriptSystemToolResultCommonModelInput")
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput and returns true if successful.
    /// </summary>
    public bool TryGetConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput(
        out global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput? value
    )
    {
        if (Type == "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput")
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput and returns true if successful.
    /// </summary>
    public bool TryGetConversationHistoryTranscriptWorkflowToolsResultCommonModelInput(
        out global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput? value
    )
    {
        if (Type == "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput")
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel,
            T
        > onConversationHistoryTranscriptOtherToolsResultCommonModel,
        global::System.Func<
            global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput,
            T
        > onConversationHistoryTranscriptSystemToolResultCommonModelInput,
        global::System.Func<
            global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput,
            T
        > onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput,
        global::System.Func<
            global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput,
            T
        > onConversationHistoryTranscriptWorkflowToolsResultCommonModelInput
    )
    {
        return Type switch
        {
            "conversationHistoryTranscriptOtherToolsResultCommonModel" =>
                onConversationHistoryTranscriptOtherToolsResultCommonModel(
                    AsConversationHistoryTranscriptOtherToolsResultCommonModel()
                ),
            "conversationHistoryTranscriptSystemToolResultCommonModelInput" =>
                onConversationHistoryTranscriptSystemToolResultCommonModelInput(
                    AsConversationHistoryTranscriptSystemToolResultCommonModelInput()
                ),
            "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput" =>
                onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput(
                    AsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput()
                ),
            "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput" =>
                onConversationHistoryTranscriptWorkflowToolsResultCommonModelInput(
                    AsConversationHistoryTranscriptWorkflowToolsResultCommonModelInput()
                ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel> onConversationHistoryTranscriptOtherToolsResultCommonModel,
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput> onConversationHistoryTranscriptSystemToolResultCommonModelInput,
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput> onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput,
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput> onConversationHistoryTranscriptWorkflowToolsResultCommonModelInput
    )
    {
        switch (Type)
        {
            case "conversationHistoryTranscriptOtherToolsResultCommonModel":
                onConversationHistoryTranscriptOtherToolsResultCommonModel(
                    AsConversationHistoryTranscriptOtherToolsResultCommonModel()
                );
                break;
            case "conversationHistoryTranscriptSystemToolResultCommonModelInput":
                onConversationHistoryTranscriptSystemToolResultCommonModelInput(
                    AsConversationHistoryTranscriptSystemToolResultCommonModelInput()
                );
                break;
            case "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput":
                onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput(
                    AsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput()
                );
                break;
            case "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput":
                onConversationHistoryTranscriptWorkflowToolsResultCommonModelInput(
                    AsConversationHistoryTranscriptWorkflowToolsResultCommonModelInput()
                );
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not ConversationHistoryTranscriptCommonModelInputToolResultsItem other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationHistoryTranscriptCommonModelInputToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel value
    ) => new("conversationHistoryTranscriptOtherToolsResultCommonModel", value);

    public static implicit operator ConversationHistoryTranscriptCommonModelInputToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput value
    ) => new("conversationHistoryTranscriptSystemToolResultCommonModelInput", value);

    public static implicit operator ConversationHistoryTranscriptCommonModelInputToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput value
    ) =>
        new("conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput", value);

    public static implicit operator ConversationHistoryTranscriptCommonModelInputToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput value
    ) => new("conversationHistoryTranscriptWorkflowToolsResultCommonModelInput", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ConversationHistoryTranscriptCommonModelInputToolResultsItem>
    {
        public override ConversationHistoryTranscriptCommonModelInputToolResultsItem? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                // A payload carrying a member's literal decodes as that member or not at all.
                var matchedLiteral = false;

                if (HasLiteral(document, "type", "system"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput),
                            options
                        );
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptCommonModelInputToolResultsItem(
                                "conversationHistoryTranscriptSystemToolResultCommonModelInput",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "api_integration_webhook"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput),
                            options
                        );
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptCommonModelInputToolResultsItem(
                                "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "workflow"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput),
                            options
                        );
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptCommonModelInputToolResultsItem(
                                "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (matchedLiteral)
                {
                    throw new JsonException(
                        "Cannot deserialize JSON object into ConversationHistoryTranscriptCommonModelInputToolResultsItem: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "conversationHistoryTranscriptOtherToolsResultCommonModel",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel)
                    ),
                    (
                        "conversationHistoryTranscriptSystemToolResultCommonModelInput",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelInput)
                    ),
                    (
                        "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelInput)
                    ),
                    (
                        "conversationHistoryTranscriptWorkflowToolsResultCommonModelInput",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelInput)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptCommonModelInputToolResultsItem(
                                key,
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ConversationHistoryTranscriptCommonModelInputToolResultsItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptCommonModelInputToolResultsItem value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override ConversationHistoryTranscriptCommonModelInputToolResultsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ConversationHistoryTranscriptCommonModelInputToolResultsItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptCommonModelInputToolResultsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }

        private static bool HasLiteral(JsonDocument document, string key, string expected)
        {
            if (!document.RootElement.TryGetProperty(key, out var property))
            {
                return false;
            }

            return property.ValueKind == JsonValueKind.String && property.GetString() == expected;
        }
    }
}
