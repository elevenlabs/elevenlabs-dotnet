// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan.JsonConverter)
)]
[Serializable]
public class BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan
{
    private BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan(
        string type,
        object? value
    )
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
    /// Create a BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan from a MusicPrompt value.
    /// </summary>
    public static BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan FromMusicPrompt(
        global::ElevenLabs.MusicPrompt value
    ) => new("musicPrompt", value);

    /// <summary>
    /// Create a BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan from a CompositionPlan value.
    /// </summary>
    public static BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan FromCompositionPlan(
        global::ElevenLabs.CompositionPlan value
    ) => new("compositionPlan", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "musicPrompt".
    /// </summary>
    public bool IsMusicPrompt() => Type == "musicPrompt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "compositionPlan".
    /// </summary>
    public bool IsCompositionPlan() => Type == "compositionPlan";

    /// <summary>
    /// Returns the value as a MusicPrompt if <see cref="Type"/> is "musicPrompt", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'musicPrompt'.</exception>
    public global::ElevenLabs.MusicPrompt AsMusicPrompt() =>
        IsMusicPrompt()
            ? (global::ElevenLabs.MusicPrompt)Value!
            : throw new ElevenLabsClientException("Union type is not 'musicPrompt'");

    /// <summary>
    /// Returns the value as a CompositionPlan if <see cref="Type"/> is "compositionPlan", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'compositionPlan'.</exception>
    public global::ElevenLabs.CompositionPlan AsCompositionPlan() =>
        IsCompositionPlan()
            ? (global::ElevenLabs.CompositionPlan)Value!
            : throw new ElevenLabsClientException("Union type is not 'compositionPlan'");

    /// <summary>
    /// Attempts to cast the value to a MusicPrompt and returns true if successful.
    /// </summary>
    public bool TryGetMusicPrompt(out global::ElevenLabs.MusicPrompt? value)
    {
        if (Type == "musicPrompt")
        {
            value = (global::ElevenLabs.MusicPrompt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a CompositionPlan and returns true if successful.
    /// </summary>
    public bool TryGetCompositionPlan(out global::ElevenLabs.CompositionPlan? value)
    {
        if (Type == "compositionPlan")
        {
            value = (global::ElevenLabs.CompositionPlan)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.MusicPrompt, T> onMusicPrompt,
        global::System.Func<global::ElevenLabs.CompositionPlan, T> onCompositionPlan
    )
    {
        return Type switch
        {
            "musicPrompt" => onMusicPrompt(AsMusicPrompt()),
            "compositionPlan" => onCompositionPlan(AsCompositionPlan()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.MusicPrompt> onMusicPrompt,
        global::System.Action<global::ElevenLabs.CompositionPlan> onCompositionPlan
    )
    {
        switch (Type)
        {
            case "musicPrompt":
                onMusicPrompt(AsMusicPrompt());
                break;
            case "compositionPlan":
                onCompositionPlan(AsCompositionPlan());
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
        if (
            obj is not BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan other
        )
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan(
        global::ElevenLabs.MusicPrompt value
    ) => new("musicPrompt", value);

    public static implicit operator BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan(
        global::ElevenLabs.CompositionPlan value
    ) => new("compositionPlan", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan>
    {
        public override BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan? Read(
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

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("musicPrompt", typeof(global::ElevenLabs.MusicPrompt)),
                    ("compositionPlan", typeof(global::ElevenLabs.CompositionPlan)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan(
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
                $"Cannot deserialize JSON token {reader.TokenType} into BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan value,
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

        public override BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
