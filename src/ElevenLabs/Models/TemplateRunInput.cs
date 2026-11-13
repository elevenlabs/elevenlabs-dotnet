// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// One value bound to a template input port, in the form its `content_schema`
/// calls for. A `string` port takes the text itself; `number`, `integer` and
/// `boolean` ports take a JSON value of that type. Anything stored elsewhere is
/// a reference discriminated on `type`: a prior `generation`, an uploaded
/// `asset`, a `voice`, or media passed `inline_base64`. An `array` port takes a
/// JSON array with one value per element, admissible for the schema's `items`.
/// `object` ports cannot be bound through this API yet.
///
/// No constraints beyond the wire shape live here: what a port accepts (an
/// `enum`, a length) is stated by its `content_schema`, and the run path
/// validates against that same schema.
/// </summary>
[JsonConverter(typeof(TemplateRunInput.JsonConverter))]
[Serializable]
public class TemplateRunInput
{
    private TemplateRunInput(string type, object? value)
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
    /// Create a TemplateRunInput from a String value.
    /// </summary>
    public static TemplateRunInput FromString(string value) => new("string", value);

    /// <summary>
    /// Create a TemplateRunInput from a Bool value.
    /// </summary>
    public static TemplateRunInput FromBool(bool value) => new("bool", value);

    /// <summary>
    /// Create a TemplateRunInput from a Int value.
    /// </summary>
    public static TemplateRunInput FromInt(int value) => new("int", value);

    /// <summary>
    /// Create a TemplateRunInput from a Double value.
    /// </summary>
    public static TemplateRunInput FromDouble(double value) => new("double", value);

    /// <summary>
    /// Create a TemplateRunInput from a TemplateInputReference value.
    /// </summary>
    public static TemplateRunInput FromTemplateInputReference(
        global::ElevenLabs.TemplateInputReference value
    ) => new("templateInputReference", value);

    /// <summary>
    /// Create a TemplateRunInput from a ListOfTemplateRunInputElement value.
    /// </summary>
    public static TemplateRunInput FromListOfTemplateRunInputElement(
        IEnumerable<global::ElevenLabs.TemplateRunInputElement> value
    ) => new("list", value);

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
    public bool IsListOfTemplateRunInputElement() => Type == "list";

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
    /// Returns the value as a ListOfTemplateRunInputElement if <see cref="Type"/> is "list", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'list'.</exception>
    public IEnumerable<global::ElevenLabs.TemplateRunInputElement> AsListOfTemplateRunInputElement() =>
        IsListOfTemplateRunInputElement()
            ? (IEnumerable<global::ElevenLabs.TemplateRunInputElement>)Value!
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
    /// Attempts to cast the value to a ListOfTemplateRunInputElement and returns true if successful.
    /// </summary>
    public bool TryGetListOfTemplateRunInputElement(
        out IEnumerable<global::ElevenLabs.TemplateRunInputElement>? value
    )
    {
        if (Type == "list")
        {
            value = (IEnumerable<global::ElevenLabs.TemplateRunInputElement>)Value!;
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
        global::System.Func<
            IEnumerable<global::ElevenLabs.TemplateRunInputElement>,
            T
        > onListOfTemplateRunInputElement
    )
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "bool" => onBool(AsBool()),
            "int" => onInt(AsInt()),
            "double" => onDouble(AsDouble()),
            "templateInputReference" => onTemplateInputReference(AsTemplateInputReference()),
            "list" => onListOfTemplateRunInputElement(AsListOfTemplateRunInputElement()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<string> onString,
        global::System.Action<bool> onBool,
        global::System.Action<int> onInt,
        global::System.Action<double> onDouble,
        global::System.Action<global::ElevenLabs.TemplateInputReference> onTemplateInputReference,
        global::System.Action<
            IEnumerable<global::ElevenLabs.TemplateRunInputElement>
        > onListOfTemplateRunInputElement
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
                onListOfTemplateRunInputElement(AsListOfTemplateRunInputElement());
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
        if (obj is not TemplateRunInput other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TemplateRunInput(string value) => new("string", value);

    public static implicit operator TemplateRunInput(bool value) => new("bool", value);

    public static implicit operator TemplateRunInput(int value) => new("int", value);

    public static implicit operator TemplateRunInput(double value) => new("double", value);

    public static implicit operator TemplateRunInput(
        global::ElevenLabs.TemplateInputReference value
    ) => new("templateInputReference", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TemplateRunInput>
    {
        public override TemplateRunInput? Read(
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
                    TemplateRunInput intResult = new("int", intValue);
                    return intResult;
                }
                TemplateRunInput doubleResult = new("double", (double)reader.GetDouble());
                return doubleResult;
            }

            if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            {
                TemplateRunInput boolResult = new("bool", reader.GetBoolean());
                return boolResult;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                if (int.TryParse(stringValue, out var intFromStringValue))
                {
                    TemplateRunInput intFromStringResult = new("int", intFromStringValue);
                    return intFromStringResult;
                }

                TemplateRunInput stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var arrayDocument = JsonDocument.ParseValue(ref reader);

                var arrayTypes = new (string Key, global::System.Type Type)[]
                {
                    ("list", typeof(IEnumerable<global::ElevenLabs.TemplateRunInputElement>)),
                };

                foreach (var (key, type) in arrayTypes)
                {
                    try
                    {
                        var value = arrayDocument.Deserialize(type, options);
                        if (value != null)
                        {
                            return new TemplateRunInput(key, value);
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
                            return new TemplateRunInput(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into TemplateRunInput"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateRunInput value,
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

        public override TemplateRunInput ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            TemplateRunInput result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateRunInput value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
