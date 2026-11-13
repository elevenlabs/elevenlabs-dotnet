// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.PronunciationDictionaries;

[JsonConverter(typeof(RulesItem.JsonConverter))]
[Serializable]
public record RulesItem
{
    internal RulesItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of RulesItem with <see cref="RulesItem.Alias"/>.
    /// </summary>
    public RulesItem(RulesItem.Alias value)
    {
        Type = "alias";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RulesItem with <see cref="RulesItem.Phoneme"/>.
    /// </summary>
    public RulesItem(RulesItem.Phoneme value)
    {
        Type = "phoneme";
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
    /// Returns true if <see cref="Type"/> is "alias"
    /// </summary>
    public bool IsAlias => Type == "alias";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "phoneme"
    /// </summary>
    public bool IsPhoneme => Type == "phoneme";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel"/> if <see cref="Type"/> is 'alias', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'alias'.</exception>
    public global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel AsAlias() =>
        IsAlias
            ? (global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel)Value!
            : throw new global::System.Exception("RulesItem.Type is not 'alias'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel"/> if <see cref="Type"/> is 'phoneme', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phoneme'.</exception>
    public global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel AsPhoneme() =>
        IsPhoneme
            ? (global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel)Value!
            : throw new global::System.Exception("RulesItem.Type is not 'phoneme'");

    public T Match<T>(
        Func<global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel, T> onAlias,
        Func<global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel, T> onPhoneme,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "alias" => onAlias(AsAlias()),
            "phoneme" => onPhoneme(AsPhoneme()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel> onAlias,
        Action<global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel> onPhoneme,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "alias":
                onAlias(AsAlias());
                break;
            case "phoneme":
                onPhoneme(AsPhoneme());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsAlias(
        out global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel? value
    )
    {
        if (Type == "alias")
        {
            value = (global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhoneme(
        out global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel? value
    )
    {
        if (Type == "phoneme")
        {
            value = (global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator RulesItem(RulesItem.Alias value) => new(value);

    public static implicit operator RulesItem(RulesItem.Phoneme value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<RulesItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(RulesItem).IsAssignableFrom(typeToConvert);

        public override RulesItem Read(
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
                "alias" =>
                    json.Deserialize<global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel"
                        ),
                "phoneme" =>
                    json.Deserialize<global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new RulesItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RulesItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "alias" => JsonSerializer.SerializeToNode(value.Value, options),
                    "phoneme" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override RulesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new RulesItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RulesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for alias
    /// </summary>
    [Serializable]
    public struct Alias
    {
        public Alias(global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RulesItem.Alias(
            global::ElevenLabs.PronunciationDictionaryAliasRuleRequestModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for phoneme
    /// </summary>
    [Serializable]
    public struct Phoneme
    {
        public Phoneme(global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RulesItem.Phoneme(
            global::ElevenLabs.PronunciationDictionaryPhonemeRuleRequestModel value
        ) => new(value);
    }
}
