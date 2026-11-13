// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OptionValue.JsonConverter))]
[Serializable]
public class OptionValue
{
    private OptionValue(string type, object? value)
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
    /// Create a OptionValue from a Double value.
    /// </summary>
    public static OptionValue FromDouble(double value) => new("double", value);

    /// <summary>
    /// Create a OptionValue from a String value.
    /// </summary>
    public static OptionValue FromString(string value) => new("string", value);

    /// <summary>
    /// Create a OptionValue from a Bool value.
    /// </summary>
    public static OptionValue FromBool(bool value) => new("bool", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "double".
    /// </summary>
    public bool IsDouble() => Type == "double";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string".
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "bool".
    /// </summary>
    public bool IsBool() => Type == "bool";

    /// <summary>
    /// Returns the value as a Double if <see cref="Type"/> is "double", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'double'.</exception>
    public double AsDouble() =>
        IsDouble()
            ? (double)Value!
            : throw new ElevenLabsClientException("Union type is not 'double'");

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

    public T Match<T>(
        global::System.Func<double, T> onDouble,
        global::System.Func<string, T> onString,
        global::System.Func<bool, T> onBool
    )
    {
        return Type switch
        {
            "double" => onDouble(AsDouble()),
            "string" => onString(AsString()),
            "bool" => onBool(AsBool()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<double> onDouble,
        global::System.Action<string> onString,
        global::System.Action<bool> onBool
    )
    {
        switch (Type)
        {
            case "double":
                onDouble(AsDouble());
                break;
            case "string":
                onString(AsString());
                break;
            case "bool":
                onBool(AsBool());
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
        if (obj is not OptionValue other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator OptionValue(double value) => new("double", value);

    public static implicit operator OptionValue(string value) => new("string", value);

    public static implicit operator OptionValue(bool value) => new("bool", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<OptionValue>
    {
        public override OptionValue? Read(
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
                OptionValue doubleResult = new("double", (double)reader.GetDouble());
                return doubleResult;
            }

            if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            {
                OptionValue boolResult = new("bool", reader.GetBoolean());
                return boolResult;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                OptionValue stringResult = new("string", stringValue);
                return stringResult;
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into OptionValue"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            OptionValue value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                num => writer.WriteNumberValue(num),
                str => writer.WriteStringValue(str),
                b => writer.WriteBooleanValue(b)
            );
        }

        public override OptionValue ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            OptionValue result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OptionValue value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
