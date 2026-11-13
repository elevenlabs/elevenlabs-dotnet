// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MemoryEntrySearchResultSource.JsonConverter))]
[Serializable]
public class MemoryEntrySearchResultSource
{
    private MemoryEntrySearchResultSource(string type, object? value)
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
    /// Create a MemoryEntrySearchResultSource from a ConversationSource value.
    /// </summary>
    public static MemoryEntrySearchResultSource FromConversationSource(
        global::ElevenLabs.ConversationSource value
    ) => new("conversationSource", value);

    /// <summary>
    /// Create a MemoryEntrySearchResultSource from a ManualSource value.
    /// </summary>
    public static MemoryEntrySearchResultSource FromManualSource(
        global::ElevenLabs.ManualSource value
    ) => new("manualSource", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conversationSource".
    /// </summary>
    public bool IsConversationSource() => Type == "conversationSource";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "manualSource".
    /// </summary>
    public bool IsManualSource() => Type == "manualSource";

    /// <summary>
    /// Returns the value as a ConversationSource if <see cref="Type"/> is "conversationSource", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'conversationSource'.</exception>
    public global::ElevenLabs.ConversationSource AsConversationSource() =>
        IsConversationSource()
            ? (global::ElevenLabs.ConversationSource)Value!
            : throw new ElevenLabsClientException("Union type is not 'conversationSource'");

    /// <summary>
    /// Returns the value as a ManualSource if <see cref="Type"/> is "manualSource", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'manualSource'.</exception>
    public global::ElevenLabs.ManualSource AsManualSource() =>
        IsManualSource()
            ? (global::ElevenLabs.ManualSource)Value!
            : throw new ElevenLabsClientException("Union type is not 'manualSource'");

    /// <summary>
    /// Attempts to cast the value to a ConversationSource and returns true if successful.
    /// </summary>
    public bool TryGetConversationSource(out global::ElevenLabs.ConversationSource? value)
    {
        if (Type == "conversationSource")
        {
            value = (global::ElevenLabs.ConversationSource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ManualSource and returns true if successful.
    /// </summary>
    public bool TryGetManualSource(out global::ElevenLabs.ManualSource? value)
    {
        if (Type == "manualSource")
        {
            value = (global::ElevenLabs.ManualSource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.ConversationSource, T> onConversationSource,
        global::System.Func<global::ElevenLabs.ManualSource, T> onManualSource
    )
    {
        return Type switch
        {
            "conversationSource" => onConversationSource(AsConversationSource()),
            "manualSource" => onManualSource(AsManualSource()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ConversationSource> onConversationSource,
        global::System.Action<global::ElevenLabs.ManualSource> onManualSource
    )
    {
        switch (Type)
        {
            case "conversationSource":
                onConversationSource(AsConversationSource());
                break;
            case "manualSource":
                onManualSource(AsManualSource());
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
        if (obj is not MemoryEntrySearchResultSource other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator MemoryEntrySearchResultSource(
        global::ElevenLabs.ConversationSource value
    ) => new("conversationSource", value);

    public static implicit operator MemoryEntrySearchResultSource(
        global::ElevenLabs.ManualSource value
    ) => new("manualSource", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<MemoryEntrySearchResultSource>
    {
        public override MemoryEntrySearchResultSource? Read(
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

                if (HasLiteral(document, "type", "conversation"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ConversationSource),
                            options
                        );
                        if (value != null)
                        {
                            return new MemoryEntrySearchResultSource("conversationSource", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "manual"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ManualSource),
                            options
                        );
                        if (value != null)
                        {
                            return new MemoryEntrySearchResultSource("manualSource", value);
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
                        "Cannot deserialize JSON object into MemoryEntrySearchResultSource: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("conversationSource", typeof(global::ElevenLabs.ConversationSource)),
                    ("manualSource", typeof(global::ElevenLabs.ManualSource)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new MemoryEntrySearchResultSource(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into MemoryEntrySearchResultSource"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            MemoryEntrySearchResultSource value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override MemoryEntrySearchResultSource ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            MemoryEntrySearchResultSource result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MemoryEntrySearchResultSource value,
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
