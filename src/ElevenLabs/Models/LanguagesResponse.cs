// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LanguagesResponse.JsonConverter))]
[Serializable]
public record LanguagesResponse
{
    internal LanguagesResponse(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of LanguagesResponse with <see cref="LanguagesResponse.Pair"/>.
    /// </summary>
    public LanguagesResponse(LanguagesResponse.Pair value)
    {
        Kind = "pair";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of LanguagesResponse with <see cref="LanguagesResponse.Single"/>.
    /// </summary>
    public LanguagesResponse(LanguagesResponse.Single value)
    {
        Kind = "single";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("kind")]
    public string Kind { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "pair"
    /// </summary>
    public bool IsPair => Kind == "pair";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "single"
    /// </summary>
    public bool IsSingle => Kind == "single";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PairedLanguagesResponse"/> if <see cref="Kind"/> is 'pair', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'pair'.</exception>
    public global::ElevenLabs.PairedLanguagesResponse AsPair() =>
        IsPair
            ? (global::ElevenLabs.PairedLanguagesResponse)Value!
            : throw new global::System.Exception("LanguagesResponse.Kind is not 'pair'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SingleLanguagesResponse"/> if <see cref="Kind"/> is 'single', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'single'.</exception>
    public global::ElevenLabs.SingleLanguagesResponse AsSingle() =>
        IsSingle
            ? (global::ElevenLabs.SingleLanguagesResponse)Value!
            : throw new global::System.Exception("LanguagesResponse.Kind is not 'single'");

    public T Match<T>(
        Func<global::ElevenLabs.PairedLanguagesResponse, T> onPair,
        Func<global::ElevenLabs.SingleLanguagesResponse, T> onSingle,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "pair" => onPair(AsPair()),
            "single" => onSingle(AsSingle()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PairedLanguagesResponse> onPair,
        Action<global::ElevenLabs.SingleLanguagesResponse> onSingle,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "pair":
                onPair(AsPair());
                break;
            case "single":
                onSingle(AsSingle());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PairedLanguagesResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsPair(out global::ElevenLabs.PairedLanguagesResponse? value)
    {
        if (Kind == "pair")
        {
            value = (global::ElevenLabs.PairedLanguagesResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SingleLanguagesResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsSingle(out global::ElevenLabs.SingleLanguagesResponse? value)
    {
        if (Kind == "single")
        {
            value = (global::ElevenLabs.SingleLanguagesResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator LanguagesResponse(LanguagesResponse.Pair value) => new(value);

    public static implicit operator LanguagesResponse(LanguagesResponse.Single value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<LanguagesResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(LanguagesResponse).IsAssignableFrom(typeToConvert);

        public override LanguagesResponse Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("kind", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'kind'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'kind' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'kind' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'kind' is null");

            var value = discriminator switch
            {
                "pair" => json.Deserialize<global::ElevenLabs.PairedLanguagesResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PairedLanguagesResponse"
                    ),
                "single" => json.Deserialize<global::ElevenLabs.SingleLanguagesResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SingleLanguagesResponse"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new LanguagesResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LanguagesResponse value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "pair" => JsonSerializer.SerializeToNode(value.Value, options),
                    "single" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override LanguagesResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new LanguagesResponse(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LanguagesResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for pair
    /// </summary>
    [Serializable]
    public struct Pair
    {
        public Pair(global::ElevenLabs.PairedLanguagesResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PairedLanguagesResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator LanguagesResponse.Pair(
            global::ElevenLabs.PairedLanguagesResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for single
    /// </summary>
    [Serializable]
    public struct Single
    {
        public Single(global::ElevenLabs.SingleLanguagesResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SingleLanguagesResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator LanguagesResponse.Single(
            global::ElevenLabs.SingleLanguagesResponse value
        ) => new(value);
    }
}
