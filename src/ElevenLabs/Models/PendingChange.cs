// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The pending change for the user.</summary>
[JsonConverter(typeof(PendingChange.JsonConverter))]
[Serializable]
public class PendingChange
{
    private PendingChange(string type, object? value)
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
    /// Create a PendingChange from a PendingSubscriptionSwitchResponseModel value.
    /// </summary>
    public static PendingChange FromPendingSubscriptionSwitchResponseModel(
        global::ElevenLabs.PendingSubscriptionSwitchResponseModel value
    ) => new("pendingSubscriptionSwitchResponseModel", value);

    /// <summary>
    /// Create a PendingChange from a PendingCancellationResponseModel value.
    /// </summary>
    public static PendingChange FromPendingCancellationResponseModel(
        global::ElevenLabs.PendingCancellationResponseModel value
    ) => new("pendingCancellationResponseModel", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "pendingSubscriptionSwitchResponseModel".
    /// </summary>
    public bool IsPendingSubscriptionSwitchResponseModel() =>
        Type == "pendingSubscriptionSwitchResponseModel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "pendingCancellationResponseModel".
    /// </summary>
    public bool IsPendingCancellationResponseModel() => Type == "pendingCancellationResponseModel";

    /// <summary>
    /// Returns the value as a PendingSubscriptionSwitchResponseModel if <see cref="Type"/> is "pendingSubscriptionSwitchResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'pendingSubscriptionSwitchResponseModel'.</exception>
    public global::ElevenLabs.PendingSubscriptionSwitchResponseModel AsPendingSubscriptionSwitchResponseModel() =>
        IsPendingSubscriptionSwitchResponseModel()
            ? (global::ElevenLabs.PendingSubscriptionSwitchResponseModel)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'pendingSubscriptionSwitchResponseModel'"
            );

    /// <summary>
    /// Returns the value as a PendingCancellationResponseModel if <see cref="Type"/> is "pendingCancellationResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'pendingCancellationResponseModel'.</exception>
    public global::ElevenLabs.PendingCancellationResponseModel AsPendingCancellationResponseModel() =>
        IsPendingCancellationResponseModel()
            ? (global::ElevenLabs.PendingCancellationResponseModel)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'pendingCancellationResponseModel'"
            );

    /// <summary>
    /// Attempts to cast the value to a PendingSubscriptionSwitchResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetPendingSubscriptionSwitchResponseModel(
        out global::ElevenLabs.PendingSubscriptionSwitchResponseModel? value
    )
    {
        if (Type == "pendingSubscriptionSwitchResponseModel")
        {
            value = (global::ElevenLabs.PendingSubscriptionSwitchResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a PendingCancellationResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetPendingCancellationResponseModel(
        out global::ElevenLabs.PendingCancellationResponseModel? value
    )
    {
        if (Type == "pendingCancellationResponseModel")
        {
            value = (global::ElevenLabs.PendingCancellationResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.PendingSubscriptionSwitchResponseModel,
            T
        > onPendingSubscriptionSwitchResponseModel,
        global::System.Func<
            global::ElevenLabs.PendingCancellationResponseModel,
            T
        > onPendingCancellationResponseModel
    )
    {
        return Type switch
        {
            "pendingSubscriptionSwitchResponseModel" => onPendingSubscriptionSwitchResponseModel(
                AsPendingSubscriptionSwitchResponseModel()
            ),
            "pendingCancellationResponseModel" => onPendingCancellationResponseModel(
                AsPendingCancellationResponseModel()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.PendingSubscriptionSwitchResponseModel> onPendingSubscriptionSwitchResponseModel,
        global::System.Action<global::ElevenLabs.PendingCancellationResponseModel> onPendingCancellationResponseModel
    )
    {
        switch (Type)
        {
            case "pendingSubscriptionSwitchResponseModel":
                onPendingSubscriptionSwitchResponseModel(
                    AsPendingSubscriptionSwitchResponseModel()
                );
                break;
            case "pendingCancellationResponseModel":
                onPendingCancellationResponseModel(AsPendingCancellationResponseModel());
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
        if (obj is not PendingChange other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PendingChange(
        global::ElevenLabs.PendingSubscriptionSwitchResponseModel value
    ) => new("pendingSubscriptionSwitchResponseModel", value);

    public static implicit operator PendingChange(
        global::ElevenLabs.PendingCancellationResponseModel value
    ) => new("pendingCancellationResponseModel", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PendingChange>
    {
        public override PendingChange? Read(
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

                if (HasLiteral(document, "kind", "change"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.PendingSubscriptionSwitchResponseModel),
                            options
                        );
                        if (value != null)
                        {
                            return new PendingChange(
                                "pendingSubscriptionSwitchResponseModel",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "kind", "cancellation"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.PendingCancellationResponseModel),
                            options
                        );
                        if (value != null)
                        {
                            return new PendingChange("pendingCancellationResponseModel", value);
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
                        "Cannot deserialize JSON object into PendingChange: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "pendingSubscriptionSwitchResponseModel",
                        typeof(global::ElevenLabs.PendingSubscriptionSwitchResponseModel)
                    ),
                    (
                        "pendingCancellationResponseModel",
                        typeof(global::ElevenLabs.PendingCancellationResponseModel)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new PendingChange(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into PendingChange"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PendingChange value,
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

        public override PendingChange ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            PendingChange result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PendingChange value,
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
