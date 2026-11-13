// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of podcast to generate. Can be 'conversation', an interaction between two voices, or 'bulletin', a monologue.</summary>
[JsonConverter(typeof(Mode.JsonConverter))]
[Serializable]
public record Mode
{
    internal Mode(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Mode with <see cref="Mode.Conversation"/>.
    /// </summary>
    public Mode(Mode.Conversation value)
    {
        Type = "conversation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Mode with <see cref="Mode.Bulletin"/>.
    /// </summary>
    public Mode(Mode.Bulletin value)
    {
        Type = "bulletin";
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
    /// Returns true if <see cref="Type"/> is "conversation"
    /// </summary>
    public bool IsConversation => Type == "conversation";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "bulletin"
    /// </summary>
    public bool IsBulletin => Type == "bulletin";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PodcastConversationMode"/> if <see cref="Type"/> is 'conversation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'conversation'.</exception>
    public global::ElevenLabs.PodcastConversationMode AsConversation() =>
        IsConversation
            ? (global::ElevenLabs.PodcastConversationMode)Value!
            : throw new global::System.Exception("Mode.Type is not 'conversation'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PodcastBulletinMode"/> if <see cref="Type"/> is 'bulletin', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'bulletin'.</exception>
    public global::ElevenLabs.PodcastBulletinMode AsBulletin() =>
        IsBulletin
            ? (global::ElevenLabs.PodcastBulletinMode)Value!
            : throw new global::System.Exception("Mode.Type is not 'bulletin'");

    public T Match<T>(
        Func<global::ElevenLabs.PodcastConversationMode, T> onConversation,
        Func<global::ElevenLabs.PodcastBulletinMode, T> onBulletin,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "conversation" => onConversation(AsConversation()),
            "bulletin" => onBulletin(AsBulletin()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PodcastConversationMode> onConversation,
        Action<global::ElevenLabs.PodcastBulletinMode> onBulletin,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "conversation":
                onConversation(AsConversation());
                break;
            case "bulletin":
                onBulletin(AsBulletin());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PodcastConversationMode"/> and returns true if successful.
    /// </summary>
    public bool TryAsConversation(out global::ElevenLabs.PodcastConversationMode? value)
    {
        if (Type == "conversation")
        {
            value = (global::ElevenLabs.PodcastConversationMode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PodcastBulletinMode"/> and returns true if successful.
    /// </summary>
    public bool TryAsBulletin(out global::ElevenLabs.PodcastBulletinMode? value)
    {
        if (Type == "bulletin")
        {
            value = (global::ElevenLabs.PodcastBulletinMode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Mode(Mode.Conversation value) => new(value);

    public static implicit operator Mode(Mode.Bulletin value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Mode>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Mode).IsAssignableFrom(typeToConvert);

        public override Mode Read(
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
                "conversation" => json.Deserialize<global::ElevenLabs.PodcastConversationMode?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PodcastConversationMode"
                    ),
                "bulletin" => json.Deserialize<global::ElevenLabs.PodcastBulletinMode?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PodcastBulletinMode"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Mode(discriminator, value);
        }

        public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
        {
            JsonNode json =
                value.Type switch
                {
                    "conversation" => JsonSerializer.SerializeToNode(value.Value, options),
                    "bulletin" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override Mode ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Mode(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Mode value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for conversation
    /// </summary>
    [Serializable]
    public struct Conversation
    {
        public Conversation(global::ElevenLabs.PodcastConversationMode value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PodcastConversationMode Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Mode.Conversation(
            global::ElevenLabs.PodcastConversationMode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for bulletin
    /// </summary>
    [Serializable]
    public struct Bulletin
    {
        public Bulletin(global::ElevenLabs.PodcastBulletinMode value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PodcastBulletinMode Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Mode.Bulletin(
            global::ElevenLabs.PodcastBulletinMode value
        ) => new(value);
    }
}
