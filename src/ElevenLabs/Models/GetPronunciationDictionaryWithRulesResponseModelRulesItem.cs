// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GetPronunciationDictionaryWithRulesResponseModelRulesItem.JsonConverter))]
[Serializable]
public record GetPronunciationDictionaryWithRulesResponseModelRulesItem
{
    internal GetPronunciationDictionaryWithRulesResponseModelRulesItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of GetPronunciationDictionaryWithRulesResponseModelRulesItem with <see cref="GetPronunciationDictionaryWithRulesResponseModelRulesItem.Alias"/>.
    /// </summary>
    public GetPronunciationDictionaryWithRulesResponseModelRulesItem(
        GetPronunciationDictionaryWithRulesResponseModelRulesItem.Alias value
    )
    {
        Type = "alias";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetPronunciationDictionaryWithRulesResponseModelRulesItem with <see cref="GetPronunciationDictionaryWithRulesResponseModelRulesItem.Phoneme"/>.
    /// </summary>
    public GetPronunciationDictionaryWithRulesResponseModelRulesItem(
        GetPronunciationDictionaryWithRulesResponseModelRulesItem.Phoneme value
    )
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
    /// Returns the value as a <see cref="global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel"/> if <see cref="Type"/> is 'alias', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'alias'.</exception>
    public global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel AsAlias() =>
        IsAlias
            ? (global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel)Value!
            : throw new global::System.Exception(
                "GetPronunciationDictionaryWithRulesResponseModelRulesItem.Type is not 'alias'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel"/> if <see cref="Type"/> is 'phoneme', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phoneme'.</exception>
    public global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel AsPhoneme() =>
        IsPhoneme
            ? (global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel)Value!
            : throw new global::System.Exception(
                "GetPronunciationDictionaryWithRulesResponseModelRulesItem.Type is not 'phoneme'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel, T> onAlias,
        Func<global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel, T> onPhoneme,
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
        Action<global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel> onAlias,
        Action<global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel> onPhoneme,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsAlias(
        out global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel? value
    )
    {
        if (Type == "alias")
        {
            value = (global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhoneme(
        out global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel? value
    )
    {
        if (Type == "phoneme")
        {
            value = (global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator GetPronunciationDictionaryWithRulesResponseModelRulesItem(
        GetPronunciationDictionaryWithRulesResponseModelRulesItem.Alias value
    ) => new(value);

    public static implicit operator GetPronunciationDictionaryWithRulesResponseModelRulesItem(
        GetPronunciationDictionaryWithRulesResponseModelRulesItem.Phoneme value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<GetPronunciationDictionaryWithRulesResponseModelRulesItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(GetPronunciationDictionaryWithRulesResponseModelRulesItem).IsAssignableFrom(
                typeToConvert
            );

        public override GetPronunciationDictionaryWithRulesResponseModelRulesItem Read(
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
                    json.Deserialize<global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel"
                        ),
                "phoneme" =>
                    json.Deserialize<global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new GetPronunciationDictionaryWithRulesResponseModelRulesItem(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPronunciationDictionaryWithRulesResponseModelRulesItem value,
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

        public override GetPronunciationDictionaryWithRulesResponseModelRulesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new GetPronunciationDictionaryWithRulesResponseModelRulesItem(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPronunciationDictionaryWithRulesResponseModelRulesItem value,
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
        public Alias(global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetPronunciationDictionaryWithRulesResponseModelRulesItem.Alias(
            global::ElevenLabs.PronunciationDictionaryAliasRuleResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for phoneme
    /// </summary>
    [Serializable]
    public struct Phoneme
    {
        public Phoneme(global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetPronunciationDictionaryWithRulesResponseModelRulesItem.Phoneme(
            global::ElevenLabs.PronunciationDictionaryPhonemeRuleResponseModel value
        ) => new(value);
    }
}
