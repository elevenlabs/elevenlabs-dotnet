// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipTransferInputConfig.JsonConverter))]
[Serializable]
public record SipTransferInputConfig
{
    internal SipTransferInputConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SipTransferInputConfig with <see cref="SipTransferInputConfig.SipColdConferenceTransfer"/>.
    /// </summary>
    public SipTransferInputConfig(SipTransferInputConfig.SipColdConferenceTransfer value)
    {
        Type = "sip_cold_conference_transfer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SipTransferInputConfig with <see cref="SipTransferInputConfig.SipColdReferTransfer"/>.
    /// </summary>
    public SipTransferInputConfig(SipTransferInputConfig.SipColdReferTransfer value)
    {
        Type = "sip_cold_refer_transfer";
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
    /// Returns true if <see cref="Type"/> is "sip_cold_conference_transfer"
    /// </summary>
    public bool IsSipColdConferenceTransfer => Type == "sip_cold_conference_transfer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sip_cold_refer_transfer"
    /// </summary>
    public bool IsSipColdReferTransfer => Type == "sip_cold_refer_transfer";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipColdConferenceTransferConfigInput"/> if <see cref="Type"/> is 'sip_cold_conference_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_cold_conference_transfer'.</exception>
    public global::ElevenLabs.SipColdConferenceTransferConfigInput AsSipColdConferenceTransfer() =>
        IsSipColdConferenceTransfer
            ? (global::ElevenLabs.SipColdConferenceTransferConfigInput)Value!
            : throw new global::System.Exception(
                "SipTransferInputConfig.Type is not 'sip_cold_conference_transfer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipColdReferTransferConfigInput"/> if <see cref="Type"/> is 'sip_cold_refer_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_cold_refer_transfer'.</exception>
    public global::ElevenLabs.SipColdReferTransferConfigInput AsSipColdReferTransfer() =>
        IsSipColdReferTransfer
            ? (global::ElevenLabs.SipColdReferTransferConfigInput)Value!
            : throw new global::System.Exception(
                "SipTransferInputConfig.Type is not 'sip_cold_refer_transfer'"
            );

    public T Match<T>(
        Func<
            global::ElevenLabs.SipColdConferenceTransferConfigInput,
            T
        > onSipColdConferenceTransfer,
        Func<global::ElevenLabs.SipColdReferTransferConfigInput, T> onSipColdReferTransfer,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "sip_cold_conference_transfer" => onSipColdConferenceTransfer(
                AsSipColdConferenceTransfer()
            ),
            "sip_cold_refer_transfer" => onSipColdReferTransfer(AsSipColdReferTransfer()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.SipColdConferenceTransferConfigInput> onSipColdConferenceTransfer,
        Action<global::ElevenLabs.SipColdReferTransferConfigInput> onSipColdReferTransfer,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "sip_cold_conference_transfer":
                onSipColdConferenceTransfer(AsSipColdConferenceTransfer());
                break;
            case "sip_cold_refer_transfer":
                onSipColdReferTransfer(AsSipColdReferTransfer());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipColdConferenceTransferConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipColdConferenceTransfer(
        out global::ElevenLabs.SipColdConferenceTransferConfigInput? value
    )
    {
        if (Type == "sip_cold_conference_transfer")
        {
            value = (global::ElevenLabs.SipColdConferenceTransferConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipColdReferTransferConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipColdReferTransfer(
        out global::ElevenLabs.SipColdReferTransferConfigInput? value
    )
    {
        if (Type == "sip_cold_refer_transfer")
        {
            value = (global::ElevenLabs.SipColdReferTransferConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SipTransferInputConfig(
        SipTransferInputConfig.SipColdConferenceTransfer value
    ) => new(value);

    public static implicit operator SipTransferInputConfig(
        SipTransferInputConfig.SipColdReferTransfer value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SipTransferInputConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SipTransferInputConfig).IsAssignableFrom(typeToConvert);

        public override SipTransferInputConfig Read(
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
                "sip_cold_conference_transfer" =>
                    json.Deserialize<global::ElevenLabs.SipColdConferenceTransferConfigInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SipColdConferenceTransferConfigInput"
                        ),
                "sip_cold_refer_transfer" =>
                    json.Deserialize<global::ElevenLabs.SipColdReferTransferConfigInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SipColdReferTransferConfigInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SipTransferInputConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipTransferInputConfig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "sip_cold_conference_transfer" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "sip_cold_refer_transfer" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override SipTransferInputConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SipTransferInputConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipTransferInputConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for sip_cold_conference_transfer
    /// </summary>
    [Serializable]
    public struct SipColdConferenceTransfer
    {
        public SipColdConferenceTransfer(
            global::ElevenLabs.SipColdConferenceTransferConfigInput value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.SipColdConferenceTransferConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipTransferInputConfig.SipColdConferenceTransfer(
            global::ElevenLabs.SipColdConferenceTransferConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_cold_refer_transfer
    /// </summary>
    [Serializable]
    public struct SipColdReferTransfer
    {
        public SipColdReferTransfer(global::ElevenLabs.SipColdReferTransferConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SipColdReferTransferConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipTransferInputConfig.SipColdReferTransfer(
            global::ElevenLabs.SipColdReferTransferConfigInput value
        ) => new(value);
    }
}
