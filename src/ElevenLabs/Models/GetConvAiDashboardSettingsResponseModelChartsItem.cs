// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GetConvAiDashboardSettingsResponseModelChartsItem.JsonConverter))]
[Serializable]
public record GetConvAiDashboardSettingsResponseModelChartsItem
{
    internal GetConvAiDashboardSettingsResponseModelChartsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of GetConvAiDashboardSettingsResponseModelChartsItem with <see cref="GetConvAiDashboardSettingsResponseModelChartsItem.CallSuccess"/>.
    /// </summary>
    public GetConvAiDashboardSettingsResponseModelChartsItem(
        GetConvAiDashboardSettingsResponseModelChartsItem.CallSuccess value
    )
    {
        Type = "call_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetConvAiDashboardSettingsResponseModelChartsItem with <see cref="GetConvAiDashboardSettingsResponseModelChartsItem.Criteria"/>.
    /// </summary>
    public GetConvAiDashboardSettingsResponseModelChartsItem(
        GetConvAiDashboardSettingsResponseModelChartsItem.Criteria value
    )
    {
        Type = "criteria";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetConvAiDashboardSettingsResponseModelChartsItem with <see cref="GetConvAiDashboardSettingsResponseModelChartsItem.DataCollection"/>.
    /// </summary>
    public GetConvAiDashboardSettingsResponseModelChartsItem(
        GetConvAiDashboardSettingsResponseModelChartsItem.DataCollection value
    )
    {
        Type = "data_collection";
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
    /// Returns true if <see cref="Type"/> is "call_success"
    /// </summary>
    public bool IsCallSuccess => Type == "call_success";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "criteria"
    /// </summary>
    public bool IsCriteria => Type == "criteria";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "data_collection"
    /// </summary>
    public bool IsDataCollection => Type == "data_collection";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DashboardCallSuccessChartModel"/> if <see cref="Type"/> is 'call_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'call_success'.</exception>
    public global::ElevenLabs.DashboardCallSuccessChartModel AsCallSuccess() =>
        IsCallSuccess
            ? (global::ElevenLabs.DashboardCallSuccessChartModel)Value!
            : throw new global::System.Exception(
                "GetConvAiDashboardSettingsResponseModelChartsItem.Type is not 'call_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DashboardCriteriaChartModel"/> if <see cref="Type"/> is 'criteria', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'criteria'.</exception>
    public global::ElevenLabs.DashboardCriteriaChartModel AsCriteria() =>
        IsCriteria
            ? (global::ElevenLabs.DashboardCriteriaChartModel)Value!
            : throw new global::System.Exception(
                "GetConvAiDashboardSettingsResponseModelChartsItem.Type is not 'criteria'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DashboardDataCollectionChartModel"/> if <see cref="Type"/> is 'data_collection', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'data_collection'.</exception>
    public global::ElevenLabs.DashboardDataCollectionChartModel AsDataCollection() =>
        IsDataCollection
            ? (global::ElevenLabs.DashboardDataCollectionChartModel)Value!
            : throw new global::System.Exception(
                "GetConvAiDashboardSettingsResponseModelChartsItem.Type is not 'data_collection'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.DashboardCallSuccessChartModel, T> onCallSuccess,
        Func<global::ElevenLabs.DashboardCriteriaChartModel, T> onCriteria,
        Func<global::ElevenLabs.DashboardDataCollectionChartModel, T> onDataCollection,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "call_success" => onCallSuccess(AsCallSuccess()),
            "criteria" => onCriteria(AsCriteria()),
            "data_collection" => onDataCollection(AsDataCollection()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.DashboardCallSuccessChartModel> onCallSuccess,
        Action<global::ElevenLabs.DashboardCriteriaChartModel> onCriteria,
        Action<global::ElevenLabs.DashboardDataCollectionChartModel> onDataCollection,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "call_success":
                onCallSuccess(AsCallSuccess());
                break;
            case "criteria":
                onCriteria(AsCriteria());
                break;
            case "data_collection":
                onDataCollection(AsDataCollection());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DashboardCallSuccessChartModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsCallSuccess(out global::ElevenLabs.DashboardCallSuccessChartModel? value)
    {
        if (Type == "call_success")
        {
            value = (global::ElevenLabs.DashboardCallSuccessChartModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DashboardCriteriaChartModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsCriteria(out global::ElevenLabs.DashboardCriteriaChartModel? value)
    {
        if (Type == "criteria")
        {
            value = (global::ElevenLabs.DashboardCriteriaChartModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DashboardDataCollectionChartModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsDataCollection(out global::ElevenLabs.DashboardDataCollectionChartModel? value)
    {
        if (Type == "data_collection")
        {
            value = (global::ElevenLabs.DashboardDataCollectionChartModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator GetConvAiDashboardSettingsResponseModelChartsItem(
        GetConvAiDashboardSettingsResponseModelChartsItem.CallSuccess value
    ) => new(value);

    public static implicit operator GetConvAiDashboardSettingsResponseModelChartsItem(
        GetConvAiDashboardSettingsResponseModelChartsItem.Criteria value
    ) => new(value);

    public static implicit operator GetConvAiDashboardSettingsResponseModelChartsItem(
        GetConvAiDashboardSettingsResponseModelChartsItem.DataCollection value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<GetConvAiDashboardSettingsResponseModelChartsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(GetConvAiDashboardSettingsResponseModelChartsItem).IsAssignableFrom(
                typeToConvert
            );

        public override GetConvAiDashboardSettingsResponseModelChartsItem Read(
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
                "call_success" =>
                    json.Deserialize<global::ElevenLabs.DashboardCallSuccessChartModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DashboardCallSuccessChartModel"
                        ),
                "criteria" => json.Deserialize<global::ElevenLabs.DashboardCriteriaChartModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DashboardCriteriaChartModel"
                    ),
                "data_collection" =>
                    json.Deserialize<global::ElevenLabs.DashboardDataCollectionChartModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DashboardDataCollectionChartModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new GetConvAiDashboardSettingsResponseModelChartsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetConvAiDashboardSettingsResponseModelChartsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "call_success" => JsonSerializer.SerializeToNode(value.Value, options),
                    "criteria" => JsonSerializer.SerializeToNode(value.Value, options),
                    "data_collection" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override GetConvAiDashboardSettingsResponseModelChartsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new GetConvAiDashboardSettingsResponseModelChartsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetConvAiDashboardSettingsResponseModelChartsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for call_success
    /// </summary>
    [Serializable]
    public struct CallSuccess
    {
        public CallSuccess(global::ElevenLabs.DashboardCallSuccessChartModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DashboardCallSuccessChartModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetConvAiDashboardSettingsResponseModelChartsItem.CallSuccess(
            global::ElevenLabs.DashboardCallSuccessChartModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for criteria
    /// </summary>
    [Serializable]
    public struct Criteria
    {
        public Criteria(global::ElevenLabs.DashboardCriteriaChartModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DashboardCriteriaChartModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetConvAiDashboardSettingsResponseModelChartsItem.Criteria(
            global::ElevenLabs.DashboardCriteriaChartModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for data_collection
    /// </summary>
    [Serializable]
    public struct DataCollection
    {
        public DataCollection(global::ElevenLabs.DashboardDataCollectionChartModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DashboardDataCollectionChartModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetConvAiDashboardSettingsResponseModelChartsItem.DataCollection(
            global::ElevenLabs.DashboardDataCollectionChartModel value
        ) => new(value);
    }
}
