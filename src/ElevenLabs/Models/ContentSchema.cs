// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ContentSchema.JsonConverter))]
[Serializable]
public record ContentSchema
{
    internal ContentSchema(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Array"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Array value)
    {
        Type = "array";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Audio"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Audio value)
    {
        Type = "audio";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Boolean"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Boolean value)
    {
        Type = "boolean";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Image"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Image value)
    {
        Type = "image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Integer"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Integer value)
    {
        Type = "integer";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Number"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Number value)
    {
        Type = "number";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Object"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Object value)
    {
        Type = "object";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.String"/>.
    /// </summary>
    public ContentSchema(ContentSchema.String value)
    {
        Type = "string";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Video"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Video value)
    {
        Type = "video";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ContentSchema with <see cref="ContentSchema.Voice"/>.
    /// </summary>
    public ContentSchema(ContentSchema.Voice value)
    {
        Type = "voice";
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
    /// Returns true if <see cref="Type"/> is "voice"
    /// </summary>
    public bool IsVoice => Type == "voice";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ArraySchema"/> if <see cref="Type"/> is 'array', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'array'.</exception>
    public global::ElevenLabs.ArraySchema AsArray() =>
        IsArray
            ? (global::ElevenLabs.ArraySchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'array'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AudioSchema"/> if <see cref="Type"/> is 'audio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'audio'.</exception>
    public global::ElevenLabs.AudioSchema AsAudio() =>
        IsAudio
            ? (global::ElevenLabs.AudioSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'audio'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BooleanSchema"/> if <see cref="Type"/> is 'boolean', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'boolean'.</exception>
    public global::ElevenLabs.BooleanSchema AsBoolean() =>
        IsBoolean
            ? (global::ElevenLabs.BooleanSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'boolean'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ImageSchema"/> if <see cref="Type"/> is 'image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'image'.</exception>
    public global::ElevenLabs.ImageSchema AsImage() =>
        IsImage
            ? (global::ElevenLabs.ImageSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'image'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.IntegerSchema"/> if <see cref="Type"/> is 'integer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'integer'.</exception>
    public global::ElevenLabs.IntegerSchema AsInteger() =>
        IsInteger
            ? (global::ElevenLabs.IntegerSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'integer'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.NumberSchema"/> if <see cref="Type"/> is 'number', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'number'.</exception>
    public global::ElevenLabs.NumberSchema AsNumber() =>
        IsNumber
            ? (global::ElevenLabs.NumberSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'number'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ObjectSchema"/> if <see cref="Type"/> is 'object', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'object'.</exception>
    public global::ElevenLabs.ObjectSchema AsObject() =>
        IsObject
            ? (global::ElevenLabs.ObjectSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'object'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.StringSchema"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public global::ElevenLabs.StringSchema AsString() =>
        IsString
            ? (global::ElevenLabs.StringSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.VideoSchema"/> if <see cref="Type"/> is 'video', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'video'.</exception>
    public global::ElevenLabs.VideoSchema AsVideo() =>
        IsVideo
            ? (global::ElevenLabs.VideoSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'video'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.VoiceSchema"/> if <see cref="Type"/> is 'voice', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'voice'.</exception>
    public global::ElevenLabs.VoiceSchema AsVoice() =>
        IsVoice
            ? (global::ElevenLabs.VoiceSchema)Value!
            : throw new global::System.Exception("ContentSchema.Type is not 'voice'");

    public T Match<T>(
        Func<global::ElevenLabs.ArraySchema, T> onArray,
        Func<global::ElevenLabs.AudioSchema, T> onAudio,
        Func<global::ElevenLabs.BooleanSchema, T> onBoolean,
        Func<global::ElevenLabs.ImageSchema, T> onImage,
        Func<global::ElevenLabs.IntegerSchema, T> onInteger,
        Func<global::ElevenLabs.NumberSchema, T> onNumber,
        Func<global::ElevenLabs.ObjectSchema, T> onObject,
        Func<global::ElevenLabs.StringSchema, T> onString,
        Func<global::ElevenLabs.VideoSchema, T> onVideo,
        Func<global::ElevenLabs.VoiceSchema, T> onVoice,
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
            "voice" => onVoice(AsVoice()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ArraySchema> onArray,
        Action<global::ElevenLabs.AudioSchema> onAudio,
        Action<global::ElevenLabs.BooleanSchema> onBoolean,
        Action<global::ElevenLabs.ImageSchema> onImage,
        Action<global::ElevenLabs.IntegerSchema> onInteger,
        Action<global::ElevenLabs.NumberSchema> onNumber,
        Action<global::ElevenLabs.ObjectSchema> onObject,
        Action<global::ElevenLabs.StringSchema> onString,
        Action<global::ElevenLabs.VideoSchema> onVideo,
        Action<global::ElevenLabs.VoiceSchema> onVoice,
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
            case "voice":
                onVoice(AsVoice());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ArraySchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsArray(out global::ElevenLabs.ArraySchema? value)
    {
        if (Type == "array")
        {
            value = (global::ElevenLabs.ArraySchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AudioSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudio(out global::ElevenLabs.AudioSchema? value)
    {
        if (Type == "audio")
        {
            value = (global::ElevenLabs.AudioSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BooleanSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsBoolean(out global::ElevenLabs.BooleanSchema? value)
    {
        if (Type == "boolean")
        {
            value = (global::ElevenLabs.BooleanSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ImageSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsImage(out global::ElevenLabs.ImageSchema? value)
    {
        if (Type == "image")
        {
            value = (global::ElevenLabs.ImageSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.IntegerSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsInteger(out global::ElevenLabs.IntegerSchema? value)
    {
        if (Type == "integer")
        {
            value = (global::ElevenLabs.IntegerSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.NumberSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsNumber(out global::ElevenLabs.NumberSchema? value)
    {
        if (Type == "number")
        {
            value = (global::ElevenLabs.NumberSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ObjectSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsObject(out global::ElevenLabs.ObjectSchema? value)
    {
        if (Type == "object")
        {
            value = (global::ElevenLabs.ObjectSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.StringSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsString(out global::ElevenLabs.StringSchema? value)
    {
        if (Type == "string")
        {
            value = (global::ElevenLabs.StringSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.VideoSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsVideo(out global::ElevenLabs.VideoSchema? value)
    {
        if (Type == "video")
        {
            value = (global::ElevenLabs.VideoSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.VoiceSchema"/> and returns true if successful.
    /// </summary>
    public bool TryAsVoice(out global::ElevenLabs.VoiceSchema? value)
    {
        if (Type == "voice")
        {
            value = (global::ElevenLabs.VoiceSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ContentSchema(ContentSchema.Array value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Audio value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Boolean value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Image value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Integer value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Number value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Object value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.String value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Video value) => new(value);

    public static implicit operator ContentSchema(ContentSchema.Voice value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ContentSchema>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ContentSchema).IsAssignableFrom(typeToConvert);

        public override ContentSchema Read(
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
                "array" => json.Deserialize<global::ElevenLabs.ArraySchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ArraySchema"
                    ),
                "audio" => json.Deserialize<global::ElevenLabs.AudioSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AudioSchema"
                    ),
                "boolean" => json.Deserialize<global::ElevenLabs.BooleanSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BooleanSchema"
                    ),
                "image" => json.Deserialize<global::ElevenLabs.ImageSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ImageSchema"
                    ),
                "integer" => json.Deserialize<global::ElevenLabs.IntegerSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.IntegerSchema"
                    ),
                "number" => json.Deserialize<global::ElevenLabs.NumberSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.NumberSchema"
                    ),
                "object" => json.Deserialize<global::ElevenLabs.ObjectSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ObjectSchema"
                    ),
                "string" => json.Deserialize<global::ElevenLabs.StringSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.StringSchema"
                    ),
                "video" => json.Deserialize<global::ElevenLabs.VideoSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.VideoSchema"
                    ),
                "voice" => json.Deserialize<global::ElevenLabs.VoiceSchema?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.VoiceSchema"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ContentSchema(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContentSchema value,
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
                    "voice" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ContentSchema ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ContentSchema(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContentSchema value,
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
        public Array(global::ElevenLabs.ArraySchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ArraySchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Array(global::ElevenLabs.ArraySchema value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for audio
    /// </summary>
    [Serializable]
    public struct Audio
    {
        public Audio(global::ElevenLabs.AudioSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AudioSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Audio(global::ElevenLabs.AudioSchema value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for boolean
    /// </summary>
    [Serializable]
    public struct Boolean
    {
        public Boolean(global::ElevenLabs.BooleanSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BooleanSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Boolean(
            global::ElevenLabs.BooleanSchema value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for image
    /// </summary>
    [Serializable]
    public struct Image
    {
        public Image(global::ElevenLabs.ImageSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ImageSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Image(global::ElevenLabs.ImageSchema value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for integer
    /// </summary>
    [Serializable]
    public struct Integer
    {
        public Integer(global::ElevenLabs.IntegerSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.IntegerSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Integer(
            global::ElevenLabs.IntegerSchema value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for number
    /// </summary>
    [Serializable]
    public struct Number
    {
        public Number(global::ElevenLabs.NumberSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.NumberSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Number(
            global::ElevenLabs.NumberSchema value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for object
    /// </summary>
    [Serializable]
    public struct Object
    {
        public Object(global::ElevenLabs.ObjectSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ObjectSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Object(
            global::ElevenLabs.ObjectSchema value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for string
    /// </summary>
    [Serializable]
    public struct String
    {
        public String(global::ElevenLabs.StringSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.StringSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.String(
            global::ElevenLabs.StringSchema value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for video
    /// </summary>
    [Serializable]
    public struct Video
    {
        public Video(global::ElevenLabs.VideoSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.VideoSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Video(global::ElevenLabs.VideoSchema value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for voice
    /// </summary>
    [Serializable]
    public struct Voice
    {
        public Voice(global::ElevenLabs.VoiceSchema value)
        {
            Value = value;
        }

        internal global::ElevenLabs.VoiceSchema Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ContentSchema.Voice(global::ElevenLabs.VoiceSchema value) =>
            new(value);
    }
}
