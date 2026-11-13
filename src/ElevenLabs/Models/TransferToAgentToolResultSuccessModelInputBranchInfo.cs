// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TransferToAgentToolResultSuccessModelInputBranchInfo.JsonConverter))]
[Serializable]
public record TransferToAgentToolResultSuccessModelInputBranchInfo
{
    internal TransferToAgentToolResultSuccessModelInputBranchInfo(string type, object? value)
    {
        BranchReason = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TransferToAgentToolResultSuccessModelInputBranchInfo with <see cref="TransferToAgentToolResultSuccessModelInputBranchInfo.Configured"/>.
    /// </summary>
    public TransferToAgentToolResultSuccessModelInputBranchInfo(
        TransferToAgentToolResultSuccessModelInputBranchInfo.Configured value
    )
    {
        BranchReason = "configured";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TransferToAgentToolResultSuccessModelInputBranchInfo with <see cref="TransferToAgentToolResultSuccessModelInputBranchInfo.DefaultingToMain"/>.
    /// </summary>
    public TransferToAgentToolResultSuccessModelInputBranchInfo(
        TransferToAgentToolResultSuccessModelInputBranchInfo.DefaultingToMain value
    )
    {
        BranchReason = "defaulting_to_main";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TransferToAgentToolResultSuccessModelInputBranchInfo with <see cref="TransferToAgentToolResultSuccessModelInputBranchInfo.TrafficSplit"/>.
    /// </summary>
    public TransferToAgentToolResultSuccessModelInputBranchInfo(
        TransferToAgentToolResultSuccessModelInputBranchInfo.TrafficSplit value
    )
    {
        BranchReason = "traffic_split";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("branch_reason")]
    public string BranchReason { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="BranchReason"/> is "configured"
    /// </summary>
    public bool IsConfigured => BranchReason == "configured";

    /// <summary>
    /// Returns true if <see cref="BranchReason"/> is "defaulting_to_main"
    /// </summary>
    public bool IsDefaultingToMain => BranchReason == "defaulting_to_main";

    /// <summary>
    /// Returns true if <see cref="BranchReason"/> is "traffic_split"
    /// </summary>
    public bool IsTrafficSplit => BranchReason == "traffic_split";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferBranchInfoConfigured"/> if <see cref="BranchReason"/> is 'configured', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="BranchReason"/> is not 'configured'.</exception>
    public global::ElevenLabs.TransferBranchInfoConfigured AsConfigured() =>
        IsConfigured
            ? (global::ElevenLabs.TransferBranchInfoConfigured)Value!
            : throw new global::System.Exception(
                "TransferToAgentToolResultSuccessModelInputBranchInfo.BranchReason is not 'configured'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferBranchInfoDefaultingToMain"/> if <see cref="BranchReason"/> is 'defaulting_to_main', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="BranchReason"/> is not 'defaulting_to_main'.</exception>
    public global::ElevenLabs.TransferBranchInfoDefaultingToMain AsDefaultingToMain() =>
        IsDefaultingToMain
            ? (global::ElevenLabs.TransferBranchInfoDefaultingToMain)Value!
            : throw new global::System.Exception(
                "TransferToAgentToolResultSuccessModelInputBranchInfo.BranchReason is not 'defaulting_to_main'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferBranchInfoTrafficSplit"/> if <see cref="BranchReason"/> is 'traffic_split', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="BranchReason"/> is not 'traffic_split'.</exception>
    public global::ElevenLabs.TransferBranchInfoTrafficSplit AsTrafficSplit() =>
        IsTrafficSplit
            ? (global::ElevenLabs.TransferBranchInfoTrafficSplit)Value!
            : throw new global::System.Exception(
                "TransferToAgentToolResultSuccessModelInputBranchInfo.BranchReason is not 'traffic_split'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TransferBranchInfoConfigured, T> onConfigured,
        Func<global::ElevenLabs.TransferBranchInfoDefaultingToMain, T> onDefaultingToMain,
        Func<global::ElevenLabs.TransferBranchInfoTrafficSplit, T> onTrafficSplit,
        Func<string, object?, T> onUnknown_
    )
    {
        return BranchReason switch
        {
            "configured" => onConfigured(AsConfigured()),
            "defaulting_to_main" => onDefaultingToMain(AsDefaultingToMain()),
            "traffic_split" => onTrafficSplit(AsTrafficSplit()),
            _ => onUnknown_(BranchReason, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TransferBranchInfoConfigured> onConfigured,
        Action<global::ElevenLabs.TransferBranchInfoDefaultingToMain> onDefaultingToMain,
        Action<global::ElevenLabs.TransferBranchInfoTrafficSplit> onTrafficSplit,
        Action<string, object?> onUnknown_
    )
    {
        switch (BranchReason)
        {
            case "configured":
                onConfigured(AsConfigured());
                break;
            case "defaulting_to_main":
                onDefaultingToMain(AsDefaultingToMain());
                break;
            case "traffic_split":
                onTrafficSplit(AsTrafficSplit());
                break;
            default:
                onUnknown_(BranchReason, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferBranchInfoConfigured"/> and returns true if successful.
    /// </summary>
    public bool TryAsConfigured(out global::ElevenLabs.TransferBranchInfoConfigured? value)
    {
        if (BranchReason == "configured")
        {
            value = (global::ElevenLabs.TransferBranchInfoConfigured)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferBranchInfoDefaultingToMain"/> and returns true if successful.
    /// </summary>
    public bool TryAsDefaultingToMain(
        out global::ElevenLabs.TransferBranchInfoDefaultingToMain? value
    )
    {
        if (BranchReason == "defaulting_to_main")
        {
            value = (global::ElevenLabs.TransferBranchInfoDefaultingToMain)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferBranchInfoTrafficSplit"/> and returns true if successful.
    /// </summary>
    public bool TryAsTrafficSplit(out global::ElevenLabs.TransferBranchInfoTrafficSplit? value)
    {
        if (BranchReason == "traffic_split")
        {
            value = (global::ElevenLabs.TransferBranchInfoTrafficSplit)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TransferToAgentToolResultSuccessModelInputBranchInfo(
        TransferToAgentToolResultSuccessModelInputBranchInfo.Configured value
    ) => new(value);

    public static implicit operator TransferToAgentToolResultSuccessModelInputBranchInfo(
        TransferToAgentToolResultSuccessModelInputBranchInfo.DefaultingToMain value
    ) => new(value);

    public static implicit operator TransferToAgentToolResultSuccessModelInputBranchInfo(
        TransferToAgentToolResultSuccessModelInputBranchInfo.TrafficSplit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<TransferToAgentToolResultSuccessModelInputBranchInfo>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TransferToAgentToolResultSuccessModelInputBranchInfo).IsAssignableFrom(
                typeToConvert
            );

        public override TransferToAgentToolResultSuccessModelInputBranchInfo Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("branch_reason", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'branch_reason'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'branch_reason' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'branch_reason' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'branch_reason' is null");

            var value = discriminator switch
            {
                "configured" => json.Deserialize<global::ElevenLabs.TransferBranchInfoConfigured?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TransferBranchInfoConfigured"
                    ),
                "defaulting_to_main" =>
                    json.Deserialize<global::ElevenLabs.TransferBranchInfoDefaultingToMain?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferBranchInfoDefaultingToMain"
                        ),
                "traffic_split" =>
                    json.Deserialize<global::ElevenLabs.TransferBranchInfoTrafficSplit?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferBranchInfoTrafficSplit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new TransferToAgentToolResultSuccessModelInputBranchInfo(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToAgentToolResultSuccessModelInputBranchInfo value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.BranchReason switch
                {
                    "configured" => JsonSerializer.SerializeToNode(value.Value, options),
                    "defaulting_to_main" => JsonSerializer.SerializeToNode(value.Value, options),
                    "traffic_split" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["branch_reason"] = value.BranchReason;
            json.WriteTo(writer, options);
        }

        public override TransferToAgentToolResultSuccessModelInputBranchInfo ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TransferToAgentToolResultSuccessModelInputBranchInfo(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToAgentToolResultSuccessModelInputBranchInfo value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.BranchReason);
        }
    }

    /// <summary>
    /// Discriminated union type for configured
    /// </summary>
    [Serializable]
    public struct Configured
    {
        public Configured(global::ElevenLabs.TransferBranchInfoConfigured value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferBranchInfoConfigured Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferToAgentToolResultSuccessModelInputBranchInfo.Configured(
            global::ElevenLabs.TransferBranchInfoConfigured value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for defaulting_to_main
    /// </summary>
    [Serializable]
    public struct DefaultingToMain
    {
        public DefaultingToMain(global::ElevenLabs.TransferBranchInfoDefaultingToMain value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferBranchInfoDefaultingToMain Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferToAgentToolResultSuccessModelInputBranchInfo.DefaultingToMain(
            global::ElevenLabs.TransferBranchInfoDefaultingToMain value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for traffic_split
    /// </summary>
    [Serializable]
    public struct TrafficSplit
    {
        public TrafficSplit(global::ElevenLabs.TransferBranchInfoTrafficSplit value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferBranchInfoTrafficSplit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferToAgentToolResultSuccessModelInputBranchInfo.TrafficSplit(
            global::ElevenLabs.TransferBranchInfoTrafficSplit value
        ) => new(value);
    }
}
