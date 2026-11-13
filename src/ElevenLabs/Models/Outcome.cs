// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Outcome.JsonConverter))]
[Serializable]
public record Outcome
{
    internal Outcome(string type, object? value)
    {
        Status = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Outcome with <see cref="Outcome.Closed"/>.
    /// </summary>
    public Outcome(Outcome.Closed value)
    {
        Status = "closed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Outcome with <see cref="Outcome.Merged"/>.
    /// </summary>
    public Outcome(Outcome.Merged value)
    {
        Status = "merged";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Outcome with <see cref="Outcome.Open"/>.
    /// </summary>
    public Outcome(Outcome.Open value)
    {
        Status = "open";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Status"/> is "closed"
    /// </summary>
    public bool IsClosed => Status == "closed";

    /// <summary>
    /// Returns true if <see cref="Status"/> is "merged"
    /// </summary>
    public bool IsMerged => Status == "merged";

    /// <summary>
    /// Returns true if <see cref="Status"/> is "open"
    /// </summary>
    public bool IsOpen => Status == "open";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ClosedOutcome"/> if <see cref="Status"/> is 'closed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'closed'.</exception>
    public global::ElevenLabs.ClosedOutcome AsClosed() =>
        IsClosed
            ? (global::ElevenLabs.ClosedOutcome)Value!
            : throw new global::System.Exception("Outcome.Status is not 'closed'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MergedOutcome"/> if <see cref="Status"/> is 'merged', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'merged'.</exception>
    public global::ElevenLabs.MergedOutcome AsMerged() =>
        IsMerged
            ? (global::ElevenLabs.MergedOutcome)Value!
            : throw new global::System.Exception("Outcome.Status is not 'merged'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OpenOutcome"/> if <see cref="Status"/> is 'open', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'open'.</exception>
    public global::ElevenLabs.OpenOutcome AsOpen() =>
        IsOpen
            ? (global::ElevenLabs.OpenOutcome)Value!
            : throw new global::System.Exception("Outcome.Status is not 'open'");

    public T Match<T>(
        Func<global::ElevenLabs.ClosedOutcome, T> onClosed,
        Func<global::ElevenLabs.MergedOutcome, T> onMerged,
        Func<global::ElevenLabs.OpenOutcome, T> onOpen,
        Func<string, object?, T> onUnknown_
    )
    {
        return Status switch
        {
            "closed" => onClosed(AsClosed()),
            "merged" => onMerged(AsMerged()),
            "open" => onOpen(AsOpen()),
            _ => onUnknown_(Status, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ClosedOutcome> onClosed,
        Action<global::ElevenLabs.MergedOutcome> onMerged,
        Action<global::ElevenLabs.OpenOutcome> onOpen,
        Action<string, object?> onUnknown_
    )
    {
        switch (Status)
        {
            case "closed":
                onClosed(AsClosed());
                break;
            case "merged":
                onMerged(AsMerged());
                break;
            case "open":
                onOpen(AsOpen());
                break;
            default:
                onUnknown_(Status, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ClosedOutcome"/> and returns true if successful.
    /// </summary>
    public bool TryAsClosed(out global::ElevenLabs.ClosedOutcome? value)
    {
        if (Status == "closed")
        {
            value = (global::ElevenLabs.ClosedOutcome)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MergedOutcome"/> and returns true if successful.
    /// </summary>
    public bool TryAsMerged(out global::ElevenLabs.MergedOutcome? value)
    {
        if (Status == "merged")
        {
            value = (global::ElevenLabs.MergedOutcome)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OpenOutcome"/> and returns true if successful.
    /// </summary>
    public bool TryAsOpen(out global::ElevenLabs.OpenOutcome? value)
    {
        if (Status == "open")
        {
            value = (global::ElevenLabs.OpenOutcome)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Outcome(Outcome.Closed value) => new(value);

    public static implicit operator Outcome(Outcome.Merged value) => new(value);

    public static implicit operator Outcome(Outcome.Open value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Outcome>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Outcome).IsAssignableFrom(typeToConvert);

        public override Outcome Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("status", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'status'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'status' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'status' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'status' is null");

            var value = discriminator switch
            {
                "closed" => json.Deserialize<global::ElevenLabs.ClosedOutcome?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ClosedOutcome"
                    ),
                "merged" => json.Deserialize<global::ElevenLabs.MergedOutcome?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.MergedOutcome"
                    ),
                "open" => json.Deserialize<global::ElevenLabs.OpenOutcome?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.OpenOutcome"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Outcome(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Outcome value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Status switch
                {
                    "closed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "merged" => JsonSerializer.SerializeToNode(value.Value, options),
                    "open" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["status"] = value.Status;
            json.WriteTo(writer, options);
        }

        public override Outcome ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Outcome(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Outcome value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Status);
        }
    }

    /// <summary>
    /// Discriminated union type for closed
    /// </summary>
    [Serializable]
    public struct Closed
    {
        public Closed(global::ElevenLabs.ClosedOutcome value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ClosedOutcome Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Outcome.Closed(global::ElevenLabs.ClosedOutcome value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for merged
    /// </summary>
    [Serializable]
    public struct Merged
    {
        public Merged(global::ElevenLabs.MergedOutcome value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MergedOutcome Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Outcome.Merged(global::ElevenLabs.MergedOutcome value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for open
    /// </summary>
    [Serializable]
    public struct Open
    {
        public Open(global::ElevenLabs.OpenOutcome value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OpenOutcome Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Outcome.Open(global::ElevenLabs.OpenOutcome value) =>
            new(value);
    }
}
