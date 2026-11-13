// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The avatar of the widget</summary>
[JsonConverter(typeof(WidgetConfigAvatar.JsonConverter))]
[Serializable]
public class WidgetConfigAvatar
{
    private WidgetConfigAvatar(string type, object? value)
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
    /// Create a WidgetConfigAvatar from a OrbAvatar value.
    /// </summary>
    public static WidgetConfigAvatar FromOrbAvatar(global::ElevenLabs.OrbAvatar value) =>
        new("orbAvatar", value);

    /// <summary>
    /// Create a WidgetConfigAvatar from a UrlAvatar value.
    /// </summary>
    public static WidgetConfigAvatar FromUrlAvatar(global::ElevenLabs.UrlAvatar value) =>
        new("urlAvatar", value);

    /// <summary>
    /// Create a WidgetConfigAvatar from a ImageAvatar value.
    /// </summary>
    public static WidgetConfigAvatar FromImageAvatar(global::ElevenLabs.ImageAvatar value) =>
        new("imageAvatar", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "orbAvatar".
    /// </summary>
    public bool IsOrbAvatar() => Type == "orbAvatar";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "urlAvatar".
    /// </summary>
    public bool IsUrlAvatar() => Type == "urlAvatar";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "imageAvatar".
    /// </summary>
    public bool IsImageAvatar() => Type == "imageAvatar";

    /// <summary>
    /// Returns the value as a OrbAvatar if <see cref="Type"/> is "orbAvatar", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'orbAvatar'.</exception>
    public global::ElevenLabs.OrbAvatar AsOrbAvatar() =>
        IsOrbAvatar()
            ? (global::ElevenLabs.OrbAvatar)Value!
            : throw new ElevenLabsClientException("Union type is not 'orbAvatar'");

    /// <summary>
    /// Returns the value as a UrlAvatar if <see cref="Type"/> is "urlAvatar", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'urlAvatar'.</exception>
    public global::ElevenLabs.UrlAvatar AsUrlAvatar() =>
        IsUrlAvatar()
            ? (global::ElevenLabs.UrlAvatar)Value!
            : throw new ElevenLabsClientException("Union type is not 'urlAvatar'");

    /// <summary>
    /// Returns the value as a ImageAvatar if <see cref="Type"/> is "imageAvatar", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'imageAvatar'.</exception>
    public global::ElevenLabs.ImageAvatar AsImageAvatar() =>
        IsImageAvatar()
            ? (global::ElevenLabs.ImageAvatar)Value!
            : throw new ElevenLabsClientException("Union type is not 'imageAvatar'");

    /// <summary>
    /// Attempts to cast the value to a OrbAvatar and returns true if successful.
    /// </summary>
    public bool TryGetOrbAvatar(out global::ElevenLabs.OrbAvatar? value)
    {
        if (Type == "orbAvatar")
        {
            value = (global::ElevenLabs.OrbAvatar)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a UrlAvatar and returns true if successful.
    /// </summary>
    public bool TryGetUrlAvatar(out global::ElevenLabs.UrlAvatar? value)
    {
        if (Type == "urlAvatar")
        {
            value = (global::ElevenLabs.UrlAvatar)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ImageAvatar and returns true if successful.
    /// </summary>
    public bool TryGetImageAvatar(out global::ElevenLabs.ImageAvatar? value)
    {
        if (Type == "imageAvatar")
        {
            value = (global::ElevenLabs.ImageAvatar)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.OrbAvatar, T> onOrbAvatar,
        global::System.Func<global::ElevenLabs.UrlAvatar, T> onUrlAvatar,
        global::System.Func<global::ElevenLabs.ImageAvatar, T> onImageAvatar
    )
    {
        return Type switch
        {
            "orbAvatar" => onOrbAvatar(AsOrbAvatar()),
            "urlAvatar" => onUrlAvatar(AsUrlAvatar()),
            "imageAvatar" => onImageAvatar(AsImageAvatar()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.OrbAvatar> onOrbAvatar,
        global::System.Action<global::ElevenLabs.UrlAvatar> onUrlAvatar,
        global::System.Action<global::ElevenLabs.ImageAvatar> onImageAvatar
    )
    {
        switch (Type)
        {
            case "orbAvatar":
                onOrbAvatar(AsOrbAvatar());
                break;
            case "urlAvatar":
                onUrlAvatar(AsUrlAvatar());
                break;
            case "imageAvatar":
                onImageAvatar(AsImageAvatar());
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
        if (obj is not WidgetConfigAvatar other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WidgetConfigAvatar(global::ElevenLabs.OrbAvatar value) =>
        new("orbAvatar", value);

    public static implicit operator WidgetConfigAvatar(global::ElevenLabs.UrlAvatar value) =>
        new("urlAvatar", value);

    public static implicit operator WidgetConfigAvatar(global::ElevenLabs.ImageAvatar value) =>
        new("imageAvatar", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WidgetConfigAvatar>
    {
        public override WidgetConfigAvatar? Read(
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

                if (HasLiteral(document, "type", "orb"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.OrbAvatar),
                            options
                        );
                        if (value != null)
                        {
                            return new WidgetConfigAvatar("orbAvatar", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "url"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.UrlAvatar),
                            options
                        );
                        if (value != null)
                        {
                            return new WidgetConfigAvatar("urlAvatar", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "image"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ImageAvatar),
                            options
                        );
                        if (value != null)
                        {
                            return new WidgetConfigAvatar("imageAvatar", value);
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
                        "Cannot deserialize JSON object into WidgetConfigAvatar: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "orbAvatar",
                        typeof(global::ElevenLabs.OrbAvatar),
                        new[] { "type", "color_1", "color_2" }
                    ),
                    (
                        "urlAvatar",
                        typeof(global::ElevenLabs.UrlAvatar),
                        new[] { "type", "custom_url" }
                    ),
                    (
                        "imageAvatar",
                        typeof(global::ElevenLabs.ImageAvatar),
                        new[] { "type", "url" }
                    ),
                };

                foreach (var (key, type, anyOfKeys) in types)
                {
                    // A member whose properties are all optional deserializes from any object, so it
                    // only gets a turn when the payload carries one of its own keys.
                    if (anyOfKeys.Length > 0 && !HasAnyProperty(document, anyOfKeys))
                    {
                        continue;
                    }

                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new WidgetConfigAvatar(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into WidgetConfigAvatar"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            WidgetConfigAvatar value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override WidgetConfigAvatar ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            WidgetConfigAvatar result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WidgetConfigAvatar value,
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

        private static bool HasAnyProperty(JsonDocument document, string[] keys)
        {
            foreach (var key in keys)
            {
                if (document.RootElement.TryGetProperty(key, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
