// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// One output of a template run, discriminated on `type`: the `type` of the
/// port's `content_schema`. Check `status` for where it is in its lifecycle.
/// </summary>
[JsonConverter(typeof(TemplateOutput.JsonConverter))]
[Serializable]
public record TemplateOutput
{
    internal TemplateOutput(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Array"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Array value)
    {
        Type = "array";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Audio"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Audio value)
    {
        Type = "audio";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Boolean"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Boolean value)
    {
        Type = "boolean";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Image"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Image value)
    {
        Type = "image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Integer"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Integer value)
    {
        Type = "integer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Number"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Number value)
    {
        Type = "number";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Object"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Object value)
    {
        Type = "object";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.String"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.String value)
    {
        Type = "string";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateOutput with <see cref="TemplateOutput.Video"/>.
    /// </summary>
    public TemplateOutput(TemplateOutput.Video value)
    {
        Type = "video";
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
    /// Returns true if <see cref="Type"/> is "array"
    /// </summary>
    public bool IsArray => Type == "array";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "audio"
    /// </summary>
    public bool IsAudio => Type == "audio";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "boolean"
    /// </summary>
    public bool IsBoolean => Type == "boolean";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "image"
    /// </summary>
    public bool IsImage => Type == "image";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "integer"
    /// </summary>
    public bool IsInteger => Type == "integer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "number"
    /// </summary>
    public bool IsNumber => Type == "number";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "object"
    /// </summary>
    public bool IsObject => Type == "object";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "video"
    /// </summary>
    public bool IsVideo => Type == "video";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateArrayOutput"/> if <see cref="Type"/> is 'array', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'array'.</exception>
    public global::ElevenLabs.TemplateArrayOutput AsArray() =>
        IsArray
            ? (global::ElevenLabs.TemplateArrayOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'array'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateAudioOutput"/> if <see cref="Type"/> is 'audio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'audio'.</exception>
    public global::ElevenLabs.TemplateAudioOutput AsAudio() =>
        IsAudio
            ? (global::ElevenLabs.TemplateAudioOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'audio'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateBooleanOutput"/> if <see cref="Type"/> is 'boolean', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'boolean'.</exception>
    public global::ElevenLabs.TemplateBooleanOutput AsBoolean() =>
        IsBoolean
            ? (global::ElevenLabs.TemplateBooleanOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'boolean'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateImageOutput"/> if <see cref="Type"/> is 'image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'image'.</exception>
    public global::ElevenLabs.TemplateImageOutput AsImage() =>
        IsImage
            ? (global::ElevenLabs.TemplateImageOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'image'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateIntegerOutput"/> if <see cref="Type"/> is 'integer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'integer'.</exception>
    public global::ElevenLabs.TemplateIntegerOutput AsInteger() =>
        IsInteger
            ? (global::ElevenLabs.TemplateIntegerOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'integer'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateNumberOutput"/> if <see cref="Type"/> is 'number', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'number'.</exception>
    public global::ElevenLabs.TemplateNumberOutput AsNumber() =>
        IsNumber
            ? (global::ElevenLabs.TemplateNumberOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'number'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateObjectOutput"/> if <see cref="Type"/> is 'object', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'object'.</exception>
    public global::ElevenLabs.TemplateObjectOutput AsObject() =>
        IsObject
            ? (global::ElevenLabs.TemplateObjectOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'object'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateStringOutput"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public global::ElevenLabs.TemplateStringOutput AsString() =>
        IsString
            ? (global::ElevenLabs.TemplateStringOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TemplateVideoOutput"/> if <see cref="Type"/> is 'video', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'video'.</exception>
    public global::ElevenLabs.TemplateVideoOutput AsVideo() =>
        IsVideo
            ? (global::ElevenLabs.TemplateVideoOutput)Value!
            : throw new global::System.Exception("TemplateOutput.Type is not 'video'");

    public T Match<T>(
        Func<global::ElevenLabs.TemplateArrayOutput, T> onArray,
        Func<global::ElevenLabs.TemplateAudioOutput, T> onAudio,
        Func<global::ElevenLabs.TemplateBooleanOutput, T> onBoolean,
        Func<global::ElevenLabs.TemplateImageOutput, T> onImage,
        Func<global::ElevenLabs.TemplateIntegerOutput, T> onInteger,
        Func<global::ElevenLabs.TemplateNumberOutput, T> onNumber,
        Func<global::ElevenLabs.TemplateObjectOutput, T> onObject,
        Func<global::ElevenLabs.TemplateStringOutput, T> onString,
        Func<global::ElevenLabs.TemplateVideoOutput, T> onVideo,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "array" => onArray(AsArray()),
            "audio" => onAudio(AsAudio()),
            "boolean" => onBoolean(AsBoolean()),
            "image" => onImage(AsImage()),
            "integer" => onInteger(AsInteger()),
            "number" => onNumber(AsNumber()),
            "object" => onObject(AsObject()),
            "string" => onString(AsString()),
            "video" => onVideo(AsVideo()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TemplateArrayOutput> onArray,
        Action<global::ElevenLabs.TemplateAudioOutput> onAudio,
        Action<global::ElevenLabs.TemplateBooleanOutput> onBoolean,
        Action<global::ElevenLabs.TemplateImageOutput> onImage,
        Action<global::ElevenLabs.TemplateIntegerOutput> onInteger,
        Action<global::ElevenLabs.TemplateNumberOutput> onNumber,
        Action<global::ElevenLabs.TemplateObjectOutput> onObject,
        Action<global::ElevenLabs.TemplateStringOutput> onString,
        Action<global::ElevenLabs.TemplateVideoOutput> onVideo,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "array":
                onArray(AsArray());
                break;
            case "audio":
                onAudio(AsAudio());
                break;
            case "boolean":
                onBoolean(AsBoolean());
                break;
            case "image":
                onImage(AsImage());
                break;
            case "integer":
                onInteger(AsInteger());
                break;
            case "number":
                onNumber(AsNumber());
                break;
            case "object":
                onObject(AsObject());
                break;
            case "string":
                onString(AsString());
                break;
            case "video":
                onVideo(AsVideo());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateArrayOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsArray(out global::ElevenLabs.TemplateArrayOutput? value)
    {
        if (Type == "array")
        {
            value = (global::ElevenLabs.TemplateArrayOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateAudioOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudio(out global::ElevenLabs.TemplateAudioOutput? value)
    {
        if (Type == "audio")
        {
            value = (global::ElevenLabs.TemplateAudioOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateBooleanOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsBoolean(out global::ElevenLabs.TemplateBooleanOutput? value)
    {
        if (Type == "boolean")
        {
            value = (global::ElevenLabs.TemplateBooleanOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateImageOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsImage(out global::ElevenLabs.TemplateImageOutput? value)
    {
        if (Type == "image")
        {
            value = (global::ElevenLabs.TemplateImageOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateIntegerOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsInteger(out global::ElevenLabs.TemplateIntegerOutput? value)
    {
        if (Type == "integer")
        {
            value = (global::ElevenLabs.TemplateIntegerOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateNumberOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNumber(out global::ElevenLabs.TemplateNumberOutput? value)
    {
        if (Type == "number")
        {
            value = (global::ElevenLabs.TemplateNumberOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateObjectOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsObject(out global::ElevenLabs.TemplateObjectOutput? value)
    {
        if (Type == "object")
        {
            value = (global::ElevenLabs.TemplateObjectOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateStringOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsString(out global::ElevenLabs.TemplateStringOutput? value)
    {
        if (Type == "string")
        {
            value = (global::ElevenLabs.TemplateStringOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TemplateVideoOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsVideo(out global::ElevenLabs.TemplateVideoOutput? value)
    {
        if (Type == "video")
        {
            value = (global::ElevenLabs.TemplateVideoOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TemplateOutput(TemplateOutput.Array value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.Audio value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.Boolean value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.Image value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.Integer value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.Number value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.Object value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.String value) => new(value);

    public static implicit operator TemplateOutput(TemplateOutput.Video value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TemplateOutput>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TemplateOutput).IsAssignableFrom(typeToConvert);

        public override TemplateOutput Read(
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
                "array" => json.Deserialize<global::ElevenLabs.TemplateArrayOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateArrayOutput"
                    ),
                "audio" => json.Deserialize<global::ElevenLabs.TemplateAudioOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateAudioOutput"
                    ),
                "boolean" => json.Deserialize<global::ElevenLabs.TemplateBooleanOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateBooleanOutput"
                    ),
                "image" => json.Deserialize<global::ElevenLabs.TemplateImageOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateImageOutput"
                    ),
                "integer" => json.Deserialize<global::ElevenLabs.TemplateIntegerOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateIntegerOutput"
                    ),
                "number" => json.Deserialize<global::ElevenLabs.TemplateNumberOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateNumberOutput"
                    ),
                "object" => json.Deserialize<global::ElevenLabs.TemplateObjectOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateObjectOutput"
                    ),
                "string" => json.Deserialize<global::ElevenLabs.TemplateStringOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateStringOutput"
                    ),
                "video" => json.Deserialize<global::ElevenLabs.TemplateVideoOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TemplateVideoOutput"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new TemplateOutput(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateOutput value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "array" => JsonSerializer.SerializeToNode(value.Value, options),
                    "audio" => JsonSerializer.SerializeToNode(value.Value, options),
                    "boolean" => JsonSerializer.SerializeToNode(value.Value, options),
                    "image" => JsonSerializer.SerializeToNode(value.Value, options),
                    "integer" => JsonSerializer.SerializeToNode(value.Value, options),
                    "number" => JsonSerializer.SerializeToNode(value.Value, options),
                    "object" => JsonSerializer.SerializeToNode(value.Value, options),
                    "string" => JsonSerializer.SerializeToNode(value.Value, options),
                    "video" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override TemplateOutput ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TemplateOutput(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateOutput value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for array
    /// </summary>
    [Serializable]
    public struct Array
    {
        public Array(global::ElevenLabs.TemplateArrayOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateArrayOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Array(
            global::ElevenLabs.TemplateArrayOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for audio
    /// </summary>
    [Serializable]
    public struct Audio
    {
        public Audio(global::ElevenLabs.TemplateAudioOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateAudioOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Audio(
            global::ElevenLabs.TemplateAudioOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for boolean
    /// </summary>
    [Serializable]
    public struct Boolean
    {
        public Boolean(global::ElevenLabs.TemplateBooleanOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateBooleanOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Boolean(
            global::ElevenLabs.TemplateBooleanOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for image
    /// </summary>
    [Serializable]
    public struct Image
    {
        public Image(global::ElevenLabs.TemplateImageOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateImageOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Image(
            global::ElevenLabs.TemplateImageOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for integer
    /// </summary>
    [Serializable]
    public struct Integer
    {
        public Integer(global::ElevenLabs.TemplateIntegerOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateIntegerOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Integer(
            global::ElevenLabs.TemplateIntegerOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for number
    /// </summary>
    [Serializable]
    public struct Number
    {
        public Number(global::ElevenLabs.TemplateNumberOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateNumberOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Number(
            global::ElevenLabs.TemplateNumberOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for object
    /// </summary>
    [Serializable]
    public struct Object
    {
        public Object(global::ElevenLabs.TemplateObjectOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateObjectOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Object(
            global::ElevenLabs.TemplateObjectOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for string
    /// </summary>
    [Serializable]
    public struct String
    {
        public String(global::ElevenLabs.TemplateStringOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateStringOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.String(
            global::ElevenLabs.TemplateStringOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for video
    /// </summary>
    [Serializable]
    public struct Video
    {
        public Video(global::ElevenLabs.TemplateVideoOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TemplateVideoOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateOutput.Video(
            global::ElevenLabs.TemplateVideoOutput value
        ) => new(value);
    }
}
