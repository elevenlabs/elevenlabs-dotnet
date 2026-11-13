// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EndProcedureToolConfigProcedures.JsonConverter))]
[Serializable]
public class EndProcedureToolConfigProcedures
{
    private EndProcedureToolConfigProcedures(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a EndProcedureToolConfigProcedures from a ProcedureVersionRef value.
    /// </summary>
    public static EndProcedureToolConfigProcedures FromProcedureVersionRef(
        global::ElevenLabs.ProcedureVersionRef value
    ) => new("procedureVersionRef", value);

    /// <summary>
    /// Create a EndProcedureToolConfigProcedures from a ProcedureDraftRef value.
    /// </summary>
    public static EndProcedureToolConfigProcedures FromProcedureDraftRef(
        global::ElevenLabs.ProcedureDraftRef value
    ) => new("procedureDraftRef", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "procedureVersionRef".
    /// </summary>
    public bool IsProcedureVersionRef() => Type == "procedureVersionRef";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "procedureDraftRef".
    /// </summary>
    public bool IsProcedureDraftRef() => Type == "procedureDraftRef";

    /// <summary>
    /// Returns the value as a ProcedureVersionRef if <see cref="Type"/> is "procedureVersionRef", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'procedureVersionRef'.</exception>
    public global::ElevenLabs.ProcedureVersionRef AsProcedureVersionRef() =>
        IsProcedureVersionRef()
            ? (global::ElevenLabs.ProcedureVersionRef)Value!
            : throw new ElevenLabsClientException("Union type is not 'procedureVersionRef'");

    /// <summary>
    /// Returns the value as a ProcedureDraftRef if <see cref="Type"/> is "procedureDraftRef", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'procedureDraftRef'.</exception>
    public global::ElevenLabs.ProcedureDraftRef AsProcedureDraftRef() =>
        IsProcedureDraftRef()
            ? (global::ElevenLabs.ProcedureDraftRef)Value!
            : throw new ElevenLabsClientException("Union type is not 'procedureDraftRef'");

    /// <summary>
    /// Attempts to cast the value to a ProcedureVersionRef and returns true if successful.
    /// </summary>
    public bool TryGetProcedureVersionRef(out global::ElevenLabs.ProcedureVersionRef? value)
    {
        if (Type == "procedureVersionRef")
        {
            value = (global::ElevenLabs.ProcedureVersionRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ProcedureDraftRef and returns true if successful.
    /// </summary>
    public bool TryGetProcedureDraftRef(out global::ElevenLabs.ProcedureDraftRef? value)
    {
        if (Type == "procedureDraftRef")
        {
            value = (global::ElevenLabs.ProcedureDraftRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.ProcedureVersionRef, T> onProcedureVersionRef,
        global::System.Func<global::ElevenLabs.ProcedureDraftRef, T> onProcedureDraftRef
    )
    {
        return Type switch
        {
            "procedureVersionRef" => onProcedureVersionRef(AsProcedureVersionRef()),
            "procedureDraftRef" => onProcedureDraftRef(AsProcedureDraftRef()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ProcedureVersionRef> onProcedureVersionRef,
        global::System.Action<global::ElevenLabs.ProcedureDraftRef> onProcedureDraftRef
    )
    {
        switch (Type)
        {
            case "procedureVersionRef":
                onProcedureVersionRef(AsProcedureVersionRef());
                break;
            case "procedureDraftRef":
                onProcedureDraftRef(AsProcedureDraftRef());
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not EndProcedureToolConfigProcedures other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator EndProcedureToolConfigProcedures(
        global::ElevenLabs.ProcedureVersionRef value
    ) => new("procedureVersionRef", value);

    public static implicit operator EndProcedureToolConfigProcedures(
        global::ElevenLabs.ProcedureDraftRef value
    ) => new("procedureDraftRef", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EndProcedureToolConfigProcedures>
    {
        public override EndProcedureToolConfigProcedures? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("procedureVersionRef", typeof(global::ElevenLabs.ProcedureVersionRef)),
                    ("procedureDraftRef", typeof(global::ElevenLabs.ProcedureDraftRef)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new EndProcedureToolConfigProcedures(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into EndProcedureToolConfigProcedures"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EndProcedureToolConfigProcedures value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override EndProcedureToolConfigProcedures ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EndProcedureToolConfigProcedures result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EndProcedureToolConfigProcedures value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
