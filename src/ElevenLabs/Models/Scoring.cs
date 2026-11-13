// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How this criterion is scored (binary or numeric_uniform).</summary>
[JsonConverter(typeof(Scoring.JsonConverter))]
[Serializable]
public record Scoring
{
    internal Scoring(string type, object? value)
    {
        Mode = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Scoring with <see cref="Scoring.Binary"/>.
    /// </summary>
    public Scoring(Scoring.Binary value)
    {
        Mode = "binary";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Scoring with <see cref="Scoring.NumericUniform"/>.
    /// </summary>
    public Scoring(Scoring.NumericUniform value)
    {
        Mode = "numeric_uniform";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("mode")]
    public string Mode { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Mode"/> is "binary"
    /// </summary>
    public bool IsBinary => Mode == "binary";

    /// <summary>
    /// Returns true if <see cref="Mode"/> is "numeric_uniform"
    /// </summary>
    public bool IsNumericUniform => Mode == "numeric_uniform";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BinaryScoring"/> if <see cref="Mode"/> is 'binary', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Mode"/> is not 'binary'.</exception>
    public global::ElevenLabs.BinaryScoring AsBinary() =>
        IsBinary
            ? (global::ElevenLabs.BinaryScoring)Value!
            : throw new global::System.Exception("Scoring.Mode is not 'binary'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.NumericUniformScoring"/> if <see cref="Mode"/> is 'numeric_uniform', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Mode"/> is not 'numeric_uniform'.</exception>
    public global::ElevenLabs.NumericUniformScoring AsNumericUniform() =>
        IsNumericUniform
            ? (global::ElevenLabs.NumericUniformScoring)Value!
            : throw new global::System.Exception("Scoring.Mode is not 'numeric_uniform'");

    public T Match<T>(
        Func<global::ElevenLabs.BinaryScoring, T> onBinary,
        Func<global::ElevenLabs.NumericUniformScoring, T> onNumericUniform,
        Func<string, object?, T> onUnknown_
    )
    {
        return Mode switch
        {
            "binary" => onBinary(AsBinary()),
            "numeric_uniform" => onNumericUniform(AsNumericUniform()),
            _ => onUnknown_(Mode, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.BinaryScoring> onBinary,
        Action<global::ElevenLabs.NumericUniformScoring> onNumericUniform,
        Action<string, object?> onUnknown_
    )
    {
        switch (Mode)
        {
            case "binary":
                onBinary(AsBinary());
                break;
            case "numeric_uniform":
                onNumericUniform(AsNumericUniform());
                break;
            default:
                onUnknown_(Mode, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BinaryScoring"/> and returns true if successful.
    /// </summary>
    public bool TryAsBinary(out global::ElevenLabs.BinaryScoring? value)
    {
        if (Mode == "binary")
        {
            value = (global::ElevenLabs.BinaryScoring)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.NumericUniformScoring"/> and returns true if successful.
    /// </summary>
    public bool TryAsNumericUniform(out global::ElevenLabs.NumericUniformScoring? value)
    {
        if (Mode == "numeric_uniform")
        {
            value = (global::ElevenLabs.NumericUniformScoring)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Scoring(Scoring.Binary value) => new(value);

    public static implicit operator Scoring(Scoring.NumericUniform value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Scoring>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Scoring).IsAssignableFrom(typeToConvert);

        public override Scoring Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("mode", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'mode'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'mode' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'mode' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'mode' is null");

            var value = discriminator switch
            {
                "binary" => json.Deserialize<global::ElevenLabs.BinaryScoring?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BinaryScoring"
                    ),
                "numeric_uniform" => json.Deserialize<global::ElevenLabs.NumericUniformScoring?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.NumericUniformScoring"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Scoring(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Scoring value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Mode switch
                {
                    "binary" => JsonSerializer.SerializeToNode(value.Value, options),
                    "numeric_uniform" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["mode"] = value.Mode;
            json.WriteTo(writer, options);
        }

        public override Scoring ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Scoring(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Scoring value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Mode);
        }
    }

    /// <summary>
    /// Discriminated union type for binary
    /// </summary>
    [Serializable]
    public struct Binary
    {
        public Binary(global::ElevenLabs.BinaryScoring value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BinaryScoring Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Scoring.Binary(global::ElevenLabs.BinaryScoring value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for numeric_uniform
    /// </summary>
    [Serializable]
    public struct NumericUniform
    {
        public NumericUniform(global::ElevenLabs.NumericUniformScoring value)
        {
            Value = value;
        }

        internal global::ElevenLabs.NumericUniformScoring Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Scoring.NumericUniform(
            global::ElevenLabs.NumericUniformScoring value
        ) => new(value);
    }
}
