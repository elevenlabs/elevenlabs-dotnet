// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TwilioTransferInputConfig.JsonConverter))]
[Serializable]
public record TwilioTransferInputConfig
{
    internal TwilioTransferInputConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TwilioTransferInputConfig with <see cref="TwilioTransferInputConfig.TwilioColdBlindTransfer"/>.
    /// </summary>
    public TwilioTransferInputConfig(TwilioTransferInputConfig.TwilioColdBlindTransfer value)
    {
        Type = "twilio_cold_blind_transfer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TwilioTransferInputConfig with <see cref="TwilioTransferInputConfig.TwilioWarmConferenceTransfer"/>.
    /// </summary>
    public TwilioTransferInputConfig(TwilioTransferInputConfig.TwilioWarmConferenceTransfer value)
    {
        Type = "twilio_warm_conference_transfer";
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
    /// Returns true if <see cref="Type"/> is "twilio_cold_blind_transfer"
    /// </summary>
    public bool IsTwilioColdBlindTransfer => Type == "twilio_cold_blind_transfer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "twilio_warm_conference_transfer"
    /// </summary>
    public bool IsTwilioWarmConferenceTransfer => Type == "twilio_warm_conference_transfer";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TwilioColdBlindTransferConfigInput"/> if <see cref="Type"/> is 'twilio_cold_blind_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'twilio_cold_blind_transfer'.</exception>
    public global::ElevenLabs.TwilioColdBlindTransferConfigInput AsTwilioColdBlindTransfer() =>
        IsTwilioColdBlindTransfer
            ? (global::ElevenLabs.TwilioColdBlindTransferConfigInput)Value!
            : throw new global::System.Exception(
                "TwilioTransferInputConfig.Type is not 'twilio_cold_blind_transfer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TwilioWarmConferenceTransferConfigInput"/> if <see cref="Type"/> is 'twilio_warm_conference_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'twilio_warm_conference_transfer'.</exception>
    public global::ElevenLabs.TwilioWarmConferenceTransferConfigInput AsTwilioWarmConferenceTransfer() =>
        IsTwilioWarmConferenceTransfer
            ? (global::ElevenLabs.TwilioWarmConferenceTransferConfigInput)Value!
            : throw new global::System.Exception(
                "TwilioTransferInputConfig.Type is not 'twilio_warm_conference_transfer'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TwilioColdBlindTransferConfigInput, T> onTwilioColdBlindTransfer,
        Func<
            global::ElevenLabs.TwilioWarmConferenceTransferConfigInput,
            T
        > onTwilioWarmConferenceTransfer,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "twilio_cold_blind_transfer" => onTwilioColdBlindTransfer(AsTwilioColdBlindTransfer()),
            "twilio_warm_conference_transfer" => onTwilioWarmConferenceTransfer(
                AsTwilioWarmConferenceTransfer()
            ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TwilioColdBlindTransferConfigInput> onTwilioColdBlindTransfer,
        Action<global::ElevenLabs.TwilioWarmConferenceTransferConfigInput> onTwilioWarmConferenceTransfer,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "twilio_cold_blind_transfer":
                onTwilioColdBlindTransfer(AsTwilioColdBlindTransfer());
                break;
            case "twilio_warm_conference_transfer":
                onTwilioWarmConferenceTransfer(AsTwilioWarmConferenceTransfer());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TwilioColdBlindTransferConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilioColdBlindTransfer(
        out global::ElevenLabs.TwilioColdBlindTransferConfigInput? value
    )
    {
        if (Type == "twilio_cold_blind_transfer")
        {
            value = (global::ElevenLabs.TwilioColdBlindTransferConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TwilioWarmConferenceTransferConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilioWarmConferenceTransfer(
        out global::ElevenLabs.TwilioWarmConferenceTransferConfigInput? value
    )
    {
        if (Type == "twilio_warm_conference_transfer")
        {
            value = (global::ElevenLabs.TwilioWarmConferenceTransferConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TwilioTransferInputConfig(
        TwilioTransferInputConfig.TwilioColdBlindTransfer value
    ) => new(value);

    public static implicit operator TwilioTransferInputConfig(
        TwilioTransferInputConfig.TwilioWarmConferenceTransfer value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TwilioTransferInputConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TwilioTransferInputConfig).IsAssignableFrom(typeToConvert);

        public override TwilioTransferInputConfig Read(
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
                "twilio_cold_blind_transfer" =>
                    json.Deserialize<global::ElevenLabs.TwilioColdBlindTransferConfigInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TwilioColdBlindTransferConfigInput"
                        ),
                "twilio_warm_conference_transfer" =>
                    json.Deserialize<global::ElevenLabs.TwilioWarmConferenceTransferConfigInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TwilioWarmConferenceTransferConfigInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new TwilioTransferInputConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioTransferInputConfig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "twilio_cold_blind_transfer" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "twilio_warm_conference_transfer" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override TwilioTransferInputConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TwilioTransferInputConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioTransferInputConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for twilio_cold_blind_transfer
    /// </summary>
    [Serializable]
    public struct TwilioColdBlindTransfer
    {
        public TwilioColdBlindTransfer(global::ElevenLabs.TwilioColdBlindTransferConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TwilioColdBlindTransferConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TwilioTransferInputConfig.TwilioColdBlindTransfer(
            global::ElevenLabs.TwilioColdBlindTransferConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for twilio_warm_conference_transfer
    /// </summary>
    [Serializable]
    public struct TwilioWarmConferenceTransfer
    {
        public TwilioWarmConferenceTransfer(
            global::ElevenLabs.TwilioWarmConferenceTransferConfigInput value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TwilioWarmConferenceTransferConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TwilioTransferInputConfig.TwilioWarmConferenceTransfer(
            global::ElevenLabs.TwilioWarmConferenceTransferConfigInput value
        ) => new(value);
    }
}
