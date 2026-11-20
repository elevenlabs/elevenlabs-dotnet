// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExotelTransferInputConfig.JsonConverter))]
[Serializable]
public record ExotelTransferInputConfig
{
    internal ExotelTransferInputConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ExotelTransferInputConfig with <see cref="ExotelTransferInputConfig.ExotelColdBlindTransfer"/>.
    /// </summary>
    public ExotelTransferInputConfig(ExotelTransferInputConfig.ExotelColdBlindTransfer value)
    {
        Type = "exotel_cold_blind_transfer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ExotelTransferInputConfig with <see cref="ExotelTransferInputConfig.ExotelWarmTransfer"/>.
    /// </summary>
    public ExotelTransferInputConfig(ExotelTransferInputConfig.ExotelWarmTransfer value)
    {
        Type = "exotel_warm_transfer";
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
    /// Returns true if <see cref="Type"/> is "exotel_cold_blind_transfer"
    /// </summary>
    public bool IsExotelColdBlindTransfer => Type == "exotel_cold_blind_transfer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "exotel_warm_transfer"
    /// </summary>
    public bool IsExotelWarmTransfer => Type == "exotel_warm_transfer";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ExotelColdBlindTransferConfigInput"/> if <see cref="Type"/> is 'exotel_cold_blind_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exotel_cold_blind_transfer'.</exception>
    public global::ElevenLabs.ExotelColdBlindTransferConfigInput AsExotelColdBlindTransfer() =>
        IsExotelColdBlindTransfer
            ? (global::ElevenLabs.ExotelColdBlindTransferConfigInput)Value!
            : throw new global::System.Exception(
                "ExotelTransferInputConfig.Type is not 'exotel_cold_blind_transfer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ExotelWarmTransferConfigInput"/> if <see cref="Type"/> is 'exotel_warm_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exotel_warm_transfer'.</exception>
    public global::ElevenLabs.ExotelWarmTransferConfigInput AsExotelWarmTransfer() =>
        IsExotelWarmTransfer
            ? (global::ElevenLabs.ExotelWarmTransferConfigInput)Value!
            : throw new global::System.Exception(
                "ExotelTransferInputConfig.Type is not 'exotel_warm_transfer'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ExotelColdBlindTransferConfigInput, T> onExotelColdBlindTransfer,
        Func<global::ElevenLabs.ExotelWarmTransferConfigInput, T> onExotelWarmTransfer,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "exotel_cold_blind_transfer" => onExotelColdBlindTransfer(AsExotelColdBlindTransfer()),
            "exotel_warm_transfer" => onExotelWarmTransfer(AsExotelWarmTransfer()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ExotelColdBlindTransferConfigInput> onExotelColdBlindTransfer,
        Action<global::ElevenLabs.ExotelWarmTransferConfigInput> onExotelWarmTransfer,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "exotel_cold_blind_transfer":
                onExotelColdBlindTransfer(AsExotelColdBlindTransfer());
                break;
            case "exotel_warm_transfer":
                onExotelWarmTransfer(AsExotelWarmTransfer());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ExotelColdBlindTransferConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotelColdBlindTransfer(
        out global::ElevenLabs.ExotelColdBlindTransferConfigInput? value
    )
    {
        if (Type == "exotel_cold_blind_transfer")
        {
            value = (global::ElevenLabs.ExotelColdBlindTransferConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ExotelWarmTransferConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotelWarmTransfer(out global::ElevenLabs.ExotelWarmTransferConfigInput? value)
    {
        if (Type == "exotel_warm_transfer")
        {
            value = (global::ElevenLabs.ExotelWarmTransferConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ExotelTransferInputConfig(
        ExotelTransferInputConfig.ExotelColdBlindTransfer value
    ) => new(value);

    public static implicit operator ExotelTransferInputConfig(
        ExotelTransferInputConfig.ExotelWarmTransfer value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ExotelTransferInputConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ExotelTransferInputConfig).IsAssignableFrom(typeToConvert);

        public override ExotelTransferInputConfig Read(
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
                "exotel_cold_blind_transfer" =>
                    json.Deserialize<global::ElevenLabs.ExotelColdBlindTransferConfigInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ExotelColdBlindTransferConfigInput"
                        ),
                "exotel_warm_transfer" =>
                    json.Deserialize<global::ElevenLabs.ExotelWarmTransferConfigInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ExotelWarmTransferConfigInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ExotelTransferInputConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExotelTransferInputConfig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "exotel_cold_blind_transfer" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "exotel_warm_transfer" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ExotelTransferInputConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ExotelTransferInputConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExotelTransferInputConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for exotel_cold_blind_transfer
    /// </summary>
    [Serializable]
    public struct ExotelColdBlindTransfer
    {
        public ExotelColdBlindTransfer(global::ElevenLabs.ExotelColdBlindTransferConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ExotelColdBlindTransferConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExotelTransferInputConfig.ExotelColdBlindTransfer(
            global::ElevenLabs.ExotelColdBlindTransferConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for exotel_warm_transfer
    /// </summary>
    [Serializable]
    public struct ExotelWarmTransfer
    {
        public ExotelWarmTransfer(global::ElevenLabs.ExotelWarmTransferConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ExotelWarmTransferConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExotelTransferInputConfig.ExotelWarmTransfer(
            global::ElevenLabs.ExotelWarmTransferConfigInput value
        ) => new(value);
    }
}
