// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationHistoryTranscriptResponseModelToolResultsItem.JsonConverter))]
[Serializable]
public class ConversationHistoryTranscriptResponseModelToolResultsItem
{
    private ConversationHistoryTranscriptResponseModelToolResultsItem(string type, object? value)
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
    /// Create a ConversationHistoryTranscriptResponseModelToolResultsItem from a ConversationHistoryTranscriptOtherToolsResultCommonModel value.
    /// </summary>
    public static ConversationHistoryTranscriptResponseModelToolResultsItem FromConversationHistoryTranscriptOtherToolsResultCommonModel(
        global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel value
    ) => new("conversationHistoryTranscriptOtherToolsResultCommonModel", value);

    /// <summary>
    /// Create a ConversationHistoryTranscriptResponseModelToolResultsItem from a ConversationHistoryTranscriptSystemToolResultCommonModelOutput value.
    /// </summary>
    public static ConversationHistoryTranscriptResponseModelToolResultsItem FromConversationHistoryTranscriptSystemToolResultCommonModelOutput(
        global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput value
    ) => new("conversationHistoryTranscriptSystemToolResultCommonModelOutput", value);

    /// <summary>
    /// Create a ConversationHistoryTranscriptResponseModelToolResultsItem from a ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput value.
    /// </summary>
    public static ConversationHistoryTranscriptResponseModelToolResultsItem FromConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput(
        global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput value
    ) =>
        new(
            "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput",
            value
        );

    /// <summary>
    /// Create a ConversationHistoryTranscriptResponseModelToolResultsItem from a ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput value.
    /// </summary>
    public static ConversationHistoryTranscriptResponseModelToolResultsItem FromConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput(
        global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput value
    ) => new("conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptOtherToolsResultCommonModel".
    /// </summary>
    public bool IsConversationHistoryTranscriptOtherToolsResultCommonModel() =>
        Type == "conversationHistoryTranscriptOtherToolsResultCommonModel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptSystemToolResultCommonModelOutput".
    /// </summary>
    public bool IsConversationHistoryTranscriptSystemToolResultCommonModelOutput() =>
        Type == "conversationHistoryTranscriptSystemToolResultCommonModelOutput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput".
    /// </summary>
    public bool IsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput() =>
        Type == "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput".
    /// </summary>
    public bool IsConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput() =>
        Type == "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput";

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
    /// Returns the value as a ConversationHistoryTranscriptSystemToolResultCommonModelOutput if <see cref="Type"/> is "conversationHistoryTranscriptSystemToolResultCommonModelOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationHistoryTranscriptSystemToolResultCommonModelOutput'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput AsConversationHistoryTranscriptSystemToolResultCommonModelOutput() =>
        IsConversationHistoryTranscriptSystemToolResultCommonModelOutput()
            ? (global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput)
                Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationHistoryTranscriptSystemToolResultCommonModelOutput'"
            );

    /// <summary>
    /// Returns the value as a ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput if <see cref="Type"/> is "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput AsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput() =>
        IsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput()
            ? (global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput)
                Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput'"
            );

    /// <summary>
    /// Returns the value as a ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput if <see cref="Type"/> is "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput AsConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput() =>
        IsConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput()
            ? (global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput)
                Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput'"
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
    /// Attempts to cast the value to a ConversationHistoryTranscriptSystemToolResultCommonModelOutput and returns true if successful.
    /// </summary>
    public bool TryGetConversationHistoryTranscriptSystemToolResultCommonModelOutput(
        out global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput? value
    )
    {
        if (Type == "conversationHistoryTranscriptSystemToolResultCommonModelOutput")
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput and returns true if successful.
    /// </summary>
    public bool TryGetConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput(
        out global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput? value
    )
    {
        if (
            Type == "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput"
        )
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput and returns true if successful.
    /// </summary>
    public bool TryGetConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput(
        out global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput? value
    )
    {
        if (Type == "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput")
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput)
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
            global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput,
            T
        > onConversationHistoryTranscriptSystemToolResultCommonModelOutput,
        global::System.Func<
            global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput,
            T
        > onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput,
        global::System.Func<
            global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput,
            T
        > onConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput
    )
    {
        return Type switch
        {
            "conversationHistoryTranscriptOtherToolsResultCommonModel" =>
                onConversationHistoryTranscriptOtherToolsResultCommonModel(
                    AsConversationHistoryTranscriptOtherToolsResultCommonModel()
                ),
            "conversationHistoryTranscriptSystemToolResultCommonModelOutput" =>
                onConversationHistoryTranscriptSystemToolResultCommonModelOutput(
                    AsConversationHistoryTranscriptSystemToolResultCommonModelOutput()
                ),
            "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput" =>
                onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput(
                    AsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput()
                ),
            "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput" =>
                onConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput(
                    AsConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput()
                ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel> onConversationHistoryTranscriptOtherToolsResultCommonModel,
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput> onConversationHistoryTranscriptSystemToolResultCommonModelOutput,
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput> onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput,
        global::System.Action<global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput> onConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput
    )
    {
        switch (Type)
        {
            case "conversationHistoryTranscriptOtherToolsResultCommonModel":
                onConversationHistoryTranscriptOtherToolsResultCommonModel(
                    AsConversationHistoryTranscriptOtherToolsResultCommonModel()
                );
                break;
            case "conversationHistoryTranscriptSystemToolResultCommonModelOutput":
                onConversationHistoryTranscriptSystemToolResultCommonModelOutput(
                    AsConversationHistoryTranscriptSystemToolResultCommonModelOutput()
                );
                break;
            case "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput":
                onConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput(
                    AsConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput()
                );
                break;
            case "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput":
                onConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput(
                    AsConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput()
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
        if (obj is not ConversationHistoryTranscriptResponseModelToolResultsItem other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationHistoryTranscriptResponseModelToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel value
    ) => new("conversationHistoryTranscriptOtherToolsResultCommonModel", value);

    public static implicit operator ConversationHistoryTranscriptResponseModelToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput value
    ) => new("conversationHistoryTranscriptSystemToolResultCommonModelOutput", value);

    public static implicit operator ConversationHistoryTranscriptResponseModelToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput value
    ) =>
        new(
            "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput",
            value
        );

    public static implicit operator ConversationHistoryTranscriptResponseModelToolResultsItem(
        global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput value
    ) => new("conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ConversationHistoryTranscriptResponseModelToolResultsItem>
    {
        public override ConversationHistoryTranscriptResponseModelToolResultsItem? Read(
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
                            typeof(global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput),
                            options
                        );
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptResponseModelToolResultsItem(
                                "conversationHistoryTranscriptSystemToolResultCommonModelOutput",
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
                            typeof(global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput),
                            options
                        );
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptResponseModelToolResultsItem(
                                "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput",
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
                            typeof(global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput),
                            options
                        );
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptResponseModelToolResultsItem(
                                "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput",
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
                        "Cannot deserialize JSON object into ConversationHistoryTranscriptResponseModelToolResultsItem: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "conversationHistoryTranscriptOtherToolsResultCommonModel",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptOtherToolsResultCommonModel)
                    ),
                    (
                        "conversationHistoryTranscriptSystemToolResultCommonModelOutput",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptSystemToolResultCommonModelOutput)
                    ),
                    (
                        "conversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput)
                    ),
                    (
                        "conversationHistoryTranscriptWorkflowToolsResultCommonModelOutput",
                        typeof(global::ElevenLabs.ConversationHistoryTranscriptWorkflowToolsResultCommonModelOutput)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new ConversationHistoryTranscriptResponseModelToolResultsItem(
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
                $"Cannot deserialize JSON token {reader.TokenType} into ConversationHistoryTranscriptResponseModelToolResultsItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptResponseModelToolResultsItem value,
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

        public override ConversationHistoryTranscriptResponseModelToolResultsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ConversationHistoryTranscriptResponseModelToolResultsItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptResponseModelToolResultsItem value,
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
