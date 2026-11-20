// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipTransferOutputConfig.JsonConverter))]
[Serializable]
public record SipTransferOutputConfig
{
    internal SipTransferOutputConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SipTransferOutputConfig with <see cref="SipTransferOutputConfig.SipColdConferenceTransfer"/>.
    /// </summary>
    public SipTransferOutputConfig(SipTransferOutputConfig.SipColdConferenceTransfer value)
    {
        Type = "sip_cold_conference_transfer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SipTransferOutputConfig with <see cref="SipTransferOutputConfig.SipColdReferTransfer"/>.
    /// </summary>
    public SipTransferOutputConfig(SipTransferOutputConfig.SipColdReferTransfer value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.SipColdConferenceTransferConfigOutput"/> if <see cref="Type"/> is 'sip_cold_conference_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_cold_conference_transfer'.</exception>
    public global::ElevenLabs.SipColdConferenceTransferConfigOutput AsSipColdConferenceTransfer() =>
        IsSipColdConferenceTransfer
            ? (global::ElevenLabs.SipColdConferenceTransferConfigOutput)Value!
            : throw new global::System.Exception(
                "SipTransferOutputConfig.Type is not 'sip_cold_conference_transfer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipColdReferTransferConfigOutput"/> if <see cref="Type"/> is 'sip_cold_refer_transfer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_cold_refer_transfer'.</exception>
    public global::ElevenLabs.SipColdReferTransferConfigOutput AsSipColdReferTransfer() =>
        IsSipColdReferTransfer
            ? (global::ElevenLabs.SipColdReferTransferConfigOutput)Value!
            : throw new global::System.Exception(
                "SipTransferOutputConfig.Type is not 'sip_cold_refer_transfer'"
            );

    public T Match<T>(
        Func<
            global::ElevenLabs.SipColdConferenceTransferConfigOutput,
            T
        > onSipColdConferenceTransfer,
        Func<global::ElevenLabs.SipColdReferTransferConfigOutput, T> onSipColdReferTransfer,
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
        Action<global::ElevenLabs.SipColdConferenceTransferConfigOutput> onSipColdConferenceTransfer,
        Action<global::ElevenLabs.SipColdReferTransferConfigOutput> onSipColdReferTransfer,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipColdConferenceTransferConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipColdConferenceTransfer(
        out global::ElevenLabs.SipColdConferenceTransferConfigOutput? value
    )
    {
        if (Type == "sip_cold_conference_transfer")
        {
            value = (global::ElevenLabs.SipColdConferenceTransferConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipColdReferTransferConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipColdReferTransfer(
        out global::ElevenLabs.SipColdReferTransferConfigOutput? value
    )
    {
        if (Type == "sip_cold_refer_transfer")
        {
            value = (global::ElevenLabs.SipColdReferTransferConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SipTransferOutputConfig(
        SipTransferOutputConfig.SipColdConferenceTransfer value
    ) => new(value);

    public static implicit operator SipTransferOutputConfig(
        SipTransferOutputConfig.SipColdReferTransfer value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SipTransferOutputConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SipTransferOutputConfig).IsAssignableFrom(typeToConvert);

        public override SipTransferOutputConfig Read(
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
                    json.Deserialize<global::ElevenLabs.SipColdConferenceTransferConfigOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SipColdConferenceTransferConfigOutput"
                        ),
                "sip_cold_refer_transfer" =>
                    json.Deserialize<global::ElevenLabs.SipColdReferTransferConfigOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SipColdReferTransferConfigOutput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SipTransferOutputConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipTransferOutputConfig value,
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

        public override SipTransferOutputConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SipTransferOutputConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipTransferOutputConfig value,
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
            global::ElevenLabs.SipColdConferenceTransferConfigOutput value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.SipColdConferenceTransferConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipTransferOutputConfig.SipColdConferenceTransfer(
            global::ElevenLabs.SipColdConferenceTransferConfigOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_cold_refer_transfer
    /// </summary>
    [Serializable]
    public struct SipColdReferTransfer
    {
        public SipColdReferTransfer(global::ElevenLabs.SipColdReferTransferConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SipColdReferTransferConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipTransferOutputConfig.SipColdReferTransfer(
            global::ElevenLabs.SipColdReferTransferConfigOutput value
        ) => new(value);
    }
}
