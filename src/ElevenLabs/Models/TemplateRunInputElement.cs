// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>One element of an array-valued TemplateRunInput. Same members as TemplateRunInput; nested arrays are untyped (stopgap for a recursive-union generator bug).</summary>
[JsonConverter(typeof(TemplateRunInputElement.JsonConverter))]
[Serializable]
public class TemplateRunInputElement
{
    private TemplateRunInputElement(string type, object? value)
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
    /// Create a TemplateRunInputElement from a String value.
    /// </summary>
    public static TemplateRunInputElement FromString(string value) => new("string", value);

    /// <summary>
    /// Create a TemplateRunInputElement from a Bool value.
    /// </summary>
    public static TemplateRunInputElement FromBool(bool value) => new("bool", value);

    /// <summary>
    /// Create a TemplateRunInputElement from a Int value.
    /// </summary>
    public static TemplateRunInputElement FromInt(int value) => new("int", value);

    /// <summary>
    /// Create a TemplateRunInputElement from a Double value.
    /// </summary>
    public static TemplateRunInputElement FromDouble(double value) => new("double", value);

    /// <summary>
    /// Create a TemplateRunInputElement from a TemplateInputReference value.
    /// </summary>
    public static TemplateRunInputElement FromTemplateInputReference(
        global::ElevenLabs.TemplateInputReference value
    ) => new("templateInputReference", value);

    /// <summary>
    /// Create a TemplateRunInputElement from a ListOfUnknown value.
    /// </summary>
    public static TemplateRunInputElement FromListOfUnknown(IEnumerable<object> value) =>
        new("list", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string".
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "bool".
    /// </summary>
    public bool IsBool() => Type == "bool";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "int".
    /// </summary>
    public bool IsInt() => Type == "int";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "double".
    /// </summary>
    public bool IsDouble() => Type == "double";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "templateInputReference".
    /// </summary>
    public bool IsTemplateInputReference() => Type == "templateInputReference";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "list".
    /// </summary>
    public bool IsListOfUnknown() => Type == "list";

    /// <summary>
    /// Returns the value as a String if <see cref="Type"/> is "string", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString()
            ? (string)Value!
            : throw new ElevenLabsClientException("Union type is not 'string'");

    /// <summary>
    /// Returns the value as a Bool if <see cref="Type"/> is "bool", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'bool'.</exception>
    public bool AsBool() =>
        IsBool() ? (bool)Value! : throw new ElevenLabsClientException("Union type is not 'bool'");

    /// <summary>
    /// Returns the value as a Int if <see cref="Type"/> is "int", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'int'.</exception>
    public int AsInt() =>
        IsInt() ? (int)Value! : throw new ElevenLabsClientException("Union type is not 'int'");

    /// <summary>
    /// Returns the value as a Double if <see cref="Type"/> is "double", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'double'.</exception>
    public double AsDouble() =>
        IsDouble()
            ? (double)Value!
            : throw new ElevenLabsClientException("Union type is not 'double'");

    /// <summary>
    /// Returns the value as a TemplateInputReference if <see cref="Type"/> is "templateInputReference", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'templateInputReference'.</exception>
    public global::ElevenLabs.TemplateInputReference AsTemplateInputReference() =>
        IsTemplateInputReference()
            ? (global::ElevenLabs.TemplateInputReference)Value!
            : throw new ElevenLabsClientException("Union type is not 'templateInputReference'");

    /// <summary>
    /// Returns the value as a ListOfUnknown if <see cref="Type"/> is "list", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'list'.</exception>
    public IEnumerable<object> AsListOfUnknown() =>
        IsListOfUnknown()
            ? (IEnumerable<object>)Value!
            : throw new ElevenLabsClientException("Union type is not 'list'");

    /// <summary>
    /// Attempts to cast the value to a String and returns true if successful.
    /// </summary>
    public bool TryGetString(out string? value)
    {
        if (Type == "string")
        {
            value = (string)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Bool and returns true if successful.
    /// </summary>
    public bool TryGetBool(out bool? value)
    {
        if (Type == "bool")
        {
            value = (bool)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Int and returns true if successful.
    /// </summary>
    public bool TryGetInt(out int? value)
    {
        if (Type == "int")
        {
            value = (int)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Double and returns true if successful.
    /// </summary>
    public bool TryGetDouble(out double? value)
    {
        if (Type == "double")
        {
            value = (double)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a TemplateInputReference and returns true if successful.
    /// </summary>
    public bool TryGetTemplateInputReference(out global::ElevenLabs.TemplateInputReference? value)
    {
        if (Type == "templateInputReference")
        {
            value = (global::ElevenLabs.TemplateInputReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ListOfUnknown and returns true if successful.
    /// </summary>
    public bool TryGetListOfUnknown(out IEnumerable<object>? value)
    {
        if (Type == "list")
        {
            value = (IEnumerable<object>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<string, T> onString,
        global::System.Func<bool, T> onBool,
        global::System.Func<int, T> onInt,
        global::System.Func<double, T> onDouble,
        global::System.Func<global::ElevenLabs.TemplateInputReference, T> onTemplateInputReference,
        global::System.Func<IEnumerable<object>, T> onListOfUnknown
    )
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "bool" => onBool(AsBool()),
            "int" => onInt(AsInt()),
            "double" => onDouble(AsDouble()),
            "templateInputReference" => onTemplateInputReference(AsTemplateInputReference()),
            "list" => onListOfUnknown(AsListOfUnknown()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<string> onString,
        global::System.Action<bool> onBool,
        global::System.Action<int> onInt,
        global::System.Action<double> onDouble,
        global::System.Action<global::ElevenLabs.TemplateInputReference> onTemplateInputReference,
        global::System.Action<IEnumerable<object>> onListOfUnknown
    )
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "bool":
                onBool(AsBool());
                break;
            case "int":
                onInt(AsInt());
                break;
            case "double":
                onDouble(AsDouble());
                break;
            case "templateInputReference":
                onTemplateInputReference(AsTemplateInputReference());
                break;
            case "list":
                onListOfUnknown(AsListOfUnknown());
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
        if (obj is not TemplateRunInputElement other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TemplateRunInputElement(string value) => new("string", value);

    public static implicit operator TemplateRunInputElement(bool value) => new("bool", value);

    public static implicit operator TemplateRunInputElement(int value) => new("int", value);

    public static implicit operator TemplateRunInputElement(double value) => new("double", value);

    public static implicit operator TemplateRunInputElement(
        global::ElevenLabs.TemplateInputReference value
    ) => new("templateInputReference", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TemplateRunInputElement>
    {
        public override TemplateRunInputElement? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetInt32(out var intValue))
                {
                    TemplateRunInputElement intResult = new("int", intValue);
                    return intResult;
                }
                TemplateRunInputElement doubleResult = new("double", (double)reader.GetDouble());
                return doubleResult;
            }

            if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            {
                TemplateRunInputElement boolResult = new("bool", reader.GetBoolean());
                return boolResult;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                if (int.TryParse(stringValue, out var intFromStringValue))
                {
                    TemplateRunInputElement intFromStringResult = new("int", intFromStringValue);
                    return intFromStringResult;
                }

                TemplateRunInputElement stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var arrayDocument = JsonDocument.ParseValue(ref reader);

                var arrayTypes = new (string Key, global::System.Type Type)[]
                {
                    ("list", typeof(IEnumerable<object>)),
                };

                foreach (var (key, type) in arrayTypes)
                {
                    try
                    {
                        var value = arrayDocument.Deserialize(type, options);
                        if (value != null)
                        {
                            return new TemplateRunInputElement(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("templateInputReference", typeof(global::ElevenLabs.TemplateInputReference)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new TemplateRunInputElement(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into TemplateRunInputElement"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateRunInputElement value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                str => writer.WriteStringValue(str),
                b => writer.WriteBooleanValue(b),
                num => writer.WriteNumberValue(num),
                num => writer.WriteNumberValue(num),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override TemplateRunInputElement ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            TemplateRunInputElement result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateRunInputElement value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
