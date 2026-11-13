// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AnalysisItemResponseModelDefinition.JsonConverter))]
[Serializable]
public record AnalysisItemResponseModelDefinition
{
    internal AnalysisItemResponseModelDefinition(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AnalysisItemResponseModelDefinition with <see cref="AnalysisItemResponseModelDefinition.DataCollection"/>.
    /// </summary>
    public AnalysisItemResponseModelDefinition(
        AnalysisItemResponseModelDefinition.DataCollection value
    )
    {
        Kind = "data_collection";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AnalysisItemResponseModelDefinition with <see cref="AnalysisItemResponseModelDefinition.Evaluation"/>.
    /// </summary>
    public AnalysisItemResponseModelDefinition(AnalysisItemResponseModelDefinition.Evaluation value)
    {
        Kind = "evaluation";
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
    /// Returns true if <see cref="Kind"/> is "data_collection"
    /// </summary>
    public bool IsDataCollection => Kind == "data_collection";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "evaluation"
    /// </summary>
    public bool IsEvaluation => Kind == "evaluation";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UserDataCollectionAnalysisItemOutput"/> if <see cref="Kind"/> is 'data_collection', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'data_collection'.</exception>
    public global::ElevenLabs.UserDataCollectionAnalysisItemOutput AsDataCollection() =>
        IsDataCollection
            ? (global::ElevenLabs.UserDataCollectionAnalysisItemOutput)Value!
            : throw new global::System.Exception(
                "AnalysisItemResponseModelDefinition.Kind is not 'data_collection'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UserEvaluationAnalysisItem"/> if <see cref="Kind"/> is 'evaluation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'evaluation'.</exception>
    public global::ElevenLabs.UserEvaluationAnalysisItem AsEvaluation() =>
        IsEvaluation
            ? (global::ElevenLabs.UserEvaluationAnalysisItem)Value!
            : throw new global::System.Exception(
                "AnalysisItemResponseModelDefinition.Kind is not 'evaluation'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.UserDataCollectionAnalysisItemOutput, T> onDataCollection,
        Func<global::ElevenLabs.UserEvaluationAnalysisItem, T> onEvaluation,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "data_collection" => onDataCollection(AsDataCollection()),
            "evaluation" => onEvaluation(AsEvaluation()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.UserDataCollectionAnalysisItemOutput> onDataCollection,
        Action<global::ElevenLabs.UserEvaluationAnalysisItem> onEvaluation,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "data_collection":
                onDataCollection(AsDataCollection());
                break;
            case "evaluation":
                onEvaluation(AsEvaluation());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UserDataCollectionAnalysisItemOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsDataCollection(
        out global::ElevenLabs.UserDataCollectionAnalysisItemOutput? value
    )
    {
        if (Kind == "data_collection")
        {
            value = (global::ElevenLabs.UserDataCollectionAnalysisItemOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UserEvaluationAnalysisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsEvaluation(out global::ElevenLabs.UserEvaluationAnalysisItem? value)
    {
        if (Kind == "evaluation")
        {
            value = (global::ElevenLabs.UserEvaluationAnalysisItem)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AnalysisItemResponseModelDefinition(
        AnalysisItemResponseModelDefinition.DataCollection value
    ) => new(value);

    public static implicit operator AnalysisItemResponseModelDefinition(
        AnalysisItemResponseModelDefinition.Evaluation value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AnalysisItemResponseModelDefinition>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AnalysisItemResponseModelDefinition).IsAssignableFrom(typeToConvert);

        public override AnalysisItemResponseModelDefinition Read(
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
                "data_collection" =>
                    json.Deserialize<global::ElevenLabs.UserDataCollectionAnalysisItemOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UserDataCollectionAnalysisItemOutput"
                        ),
                "evaluation" => json.Deserialize<global::ElevenLabs.UserEvaluationAnalysisItem?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UserEvaluationAnalysisItem"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new AnalysisItemResponseModelDefinition(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AnalysisItemResponseModelDefinition value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "data_collection" => JsonSerializer.SerializeToNode(value.Value, options),
                    "evaluation" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override AnalysisItemResponseModelDefinition ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AnalysisItemResponseModelDefinition(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AnalysisItemResponseModelDefinition value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for data_collection
    /// </summary>
    [Serializable]
    public struct DataCollection
    {
        public DataCollection(global::ElevenLabs.UserDataCollectionAnalysisItemOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UserDataCollectionAnalysisItemOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AnalysisItemResponseModelDefinition.DataCollection(
            global::ElevenLabs.UserDataCollectionAnalysisItemOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for evaluation
    /// </summary>
    [Serializable]
    public struct Evaluation
    {
        public Evaluation(global::ElevenLabs.UserEvaluationAnalysisItem value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UserEvaluationAnalysisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AnalysisItemResponseModelDefinition.Evaluation(
            global::ElevenLabs.UserEvaluationAnalysisItem value
        ) => new(value);
    }
}
