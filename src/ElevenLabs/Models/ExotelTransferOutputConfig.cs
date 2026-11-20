// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExotelTransferOutputConfig.JsonConverter))]
[Serializable]
public record ExotelTransferOutputConfig
{
    internal ExotelTransferOutputConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ExotelTransferOutputConfig with <see cref="ExotelTransferOutputConfig.ExotelColdBlindTransfer"/>.
    /// </summary>
    public ExotelTransferOutputConfig(ExotelTransferOutputConfig.ExotelColdBlindTransfer value)
    {
        Type = "exotel_cold_blind_transfer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ExotelTransferOutputConfig with <see cref="ExotelTransferOutputConfig.ExotelWarmTransfer"/>.
    /// </summary>
    public ExotelTransferOutputConfig(ExotelTransferOutputConfig.ExotelWarmTransfer value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.ExotelColdBlindTransferConfigOutput"/> if <see cref="Type"/> is 'exotel_cold_blind_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exotel_cold_blind_transfer'.</exception>
    public global::ElevenLabs.ExotelColdBlindTransferConfigOutput AsExotelColdBlindTransfer() =>
        IsExotelColdBlindTransfer
            ? (global::ElevenLabs.ExotelColdBlindTransferConfigOutput)Value!
            : throw new global::System.Exception(
                "ExotelTransferOutputConfig.Type is not 'exotel_cold_blind_transfer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ExotelWarmTransferConfigOutput"/> if <see cref="Type"/> is 'exotel_warm_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exotel_warm_transfer'.</exception>
    public global::ElevenLabs.ExotelWarmTransferConfigOutput AsExotelWarmTransfer() =>
        IsExotelWarmTransfer
            ? (global::ElevenLabs.ExotelWarmTransferConfigOutput)Value!
            : throw new global::System.Exception(
                "ExotelTransferOutputConfig.Type is not 'exotel_warm_transfer'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ExotelColdBlindTransferConfigOutput, T> onExotelColdBlindTransfer,
        Func<global::ElevenLabs.ExotelWarmTransferConfigOutput, T> onExotelWarmTransfer,
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
        Action<global::ElevenLabs.ExotelColdBlindTransferConfigOutput> onExotelColdBlindTransfer,
        Action<global::ElevenLabs.ExotelWarmTransferConfigOutput> onExotelWarmTransfer,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ExotelColdBlindTransferConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotelColdBlindTransfer(
        out global::ElevenLabs.ExotelColdBlindTransferConfigOutput? value
    )
    {
        if (Type == "exotel_cold_blind_transfer")
        {
            value = (global::ElevenLabs.ExotelColdBlindTransferConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ExotelWarmTransferConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotelWarmTransfer(
        out global::ElevenLabs.ExotelWarmTransferConfigOutput? value
    )
    {
        if (Type == "exotel_warm_transfer")
        {
            value = (global::ElevenLabs.ExotelWarmTransferConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ExotelTransferOutputConfig(
        ExotelTransferOutputConfig.ExotelColdBlindTransfer value
    ) => new(value);

    public static implicit operator ExotelTransferOutputConfig(
        ExotelTransferOutputConfig.ExotelWarmTransfer value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ExotelTransferOutputConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ExotelTransferOutputConfig).IsAssignableFrom(typeToConvert);

        public override ExotelTransferOutputConfig Read(
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
                    json.Deserialize<global::ElevenLabs.ExotelColdBlindTransferConfigOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ExotelColdBlindTransferConfigOutput"
                        ),
                "exotel_warm_transfer" =>
                    json.Deserialize<global::ElevenLabs.ExotelWarmTransferConfigOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ExotelWarmTransferConfigOutput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ExotelTransferOutputConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExotelTransferOutputConfig value,
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

        public override ExotelTransferOutputConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ExotelTransferOutputConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExotelTransferOutputConfig value,
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
        public ExotelColdBlindTransfer(global::ElevenLabs.ExotelColdBlindTransferConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ExotelColdBlindTransferConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExotelTransferOutputConfig.ExotelColdBlindTransfer(
            global::ElevenLabs.ExotelColdBlindTransferConfigOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for exotel_warm_transfer
    /// </summary>
    [Serializable]
    public struct ExotelWarmTransfer
    {
        public ExotelWarmTransfer(global::ElevenLabs.ExotelWarmTransferConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ExotelWarmTransferConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExotelTransferOutputConfig.ExotelWarmTransfer(
            global::ElevenLabs.ExotelWarmTransferConfigOutput value
        ) => new(value);
    }
}
