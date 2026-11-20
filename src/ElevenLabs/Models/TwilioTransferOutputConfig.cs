// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TwilioTransferOutputConfig.JsonConverter))]
[Serializable]
public record TwilioTransferOutputConfig
{
    internal TwilioTransferOutputConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TwilioTransferOutputConfig with <see cref="TwilioTransferOutputConfig.TwilioColdBlindTransfer"/>.
    /// </summary>
    public TwilioTransferOutputConfig(TwilioTransferOutputConfig.TwilioColdBlindTransfer value)
    {
        Type = "twilio_cold_blind_transfer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TwilioTransferOutputConfig with <see cref="TwilioTransferOutputConfig.TwilioWarmConferenceTransfer"/>.
    /// </summary>
    public TwilioTransferOutputConfig(TwilioTransferOutputConfig.TwilioWarmConferenceTransfer value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.TwilioColdBlindTransferConfigOutput"/> if <see cref="Type"/> is 'twilio_cold_blind_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'twilio_cold_blind_transfer'.</exception>
    public global::ElevenLabs.TwilioColdBlindTransferConfigOutput AsTwilioColdBlindTransfer() =>
        IsTwilioColdBlindTransfer
            ? (global::ElevenLabs.TwilioColdBlindTransferConfigOutput)Value!
            : throw new global::System.Exception(
                "TwilioTransferOutputConfig.Type is not 'twilio_cold_blind_transfer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput"/> if <see cref="Type"/> is 'twilio_warm_conference_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'twilio_warm_conference_transfer'.</exception>
    public global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput AsTwilioWarmConferenceTransfer() =>
        IsTwilioWarmConferenceTransfer
            ? (global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput)Value!
            : throw new global::System.Exception(
                "TwilioTransferOutputConfig.Type is not 'twilio_warm_conference_transfer'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TwilioColdBlindTransferConfigOutput, T> onTwilioColdBlindTransfer,
        Func<
            global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput,
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
        Action<global::ElevenLabs.TwilioColdBlindTransferConfigOutput> onTwilioColdBlindTransfer,
        Action<global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput> onTwilioWarmConferenceTransfer,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TwilioColdBlindTransferConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilioColdBlindTransfer(
        out global::ElevenLabs.TwilioColdBlindTransferConfigOutput? value
    )
    {
        if (Type == "twilio_cold_blind_transfer")
        {
            value = (global::ElevenLabs.TwilioColdBlindTransferConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilioWarmConferenceTransfer(
        out global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput? value
    )
    {
        if (Type == "twilio_warm_conference_transfer")
        {
            value = (global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TwilioTransferOutputConfig(
        TwilioTransferOutputConfig.TwilioColdBlindTransfer value
    ) => new(value);

    public static implicit operator TwilioTransferOutputConfig(
        TwilioTransferOutputConfig.TwilioWarmConferenceTransfer value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TwilioTransferOutputConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TwilioTransferOutputConfig).IsAssignableFrom(typeToConvert);

        public override TwilioTransferOutputConfig Read(
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
                    json.Deserialize<global::ElevenLabs.TwilioColdBlindTransferConfigOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TwilioColdBlindTransferConfigOutput"
                        ),
                "twilio_warm_conference_transfer" =>
                    json.Deserialize<global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new TwilioTransferOutputConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioTransferOutputConfig value,
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

        public override TwilioTransferOutputConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TwilioTransferOutputConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioTransferOutputConfig value,
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
        public TwilioColdBlindTransfer(global::ElevenLabs.TwilioColdBlindTransferConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TwilioColdBlindTransferConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TwilioTransferOutputConfig.TwilioColdBlindTransfer(
            global::ElevenLabs.TwilioColdBlindTransferConfigOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for twilio_warm_conference_transfer
    /// </summary>
    [Serializable]
    public struct TwilioWarmConferenceTransfer
    {
        public TwilioWarmConferenceTransfer(
            global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TwilioTransferOutputConfig.TwilioWarmConferenceTransfer(
            global::ElevenLabs.TwilioWarmConferenceTransferConfigOutput value
        ) => new(value);
    }
}
