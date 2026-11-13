// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectExtendedResponseAssetsItem.JsonConverter))]
[Serializable]
public class ProjectExtendedResponseAssetsItem
{
    private ProjectExtendedResponseAssetsItem(string type, object? value)
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
    /// Create a ProjectExtendedResponseAssetsItem from a ProjectVideoResponseModel value.
    /// </summary>
    public static ProjectExtendedResponseAssetsItem FromProjectVideoResponseModel(
        global::ElevenLabs.ProjectVideoResponseModel value
    ) => new("projectVideoResponseModel", value);

    /// <summary>
    /// Create a ProjectExtendedResponseAssetsItem from a ProjectExternalAudioResponseModel value.
    /// </summary>
    public static ProjectExtendedResponseAssetsItem FromProjectExternalAudioResponseModel(
        global::ElevenLabs.ProjectExternalAudioResponseModel value
    ) => new("projectExternalAudioResponseModel", value);

    /// <summary>
    /// Create a ProjectExtendedResponseAssetsItem from a ProjectImageResponseModel value.
    /// </summary>
    public static ProjectExtendedResponseAssetsItem FromProjectImageResponseModel(
        global::ElevenLabs.ProjectImageResponseModel value
    ) => new("projectImageResponseModel", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "projectVideoResponseModel".
    /// </summary>
    public bool IsProjectVideoResponseModel() => Type == "projectVideoResponseModel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "projectExternalAudioResponseModel".
    /// </summary>
    public bool IsProjectExternalAudioResponseModel() =>
        Type == "projectExternalAudioResponseModel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "projectImageResponseModel".
    /// </summary>
    public bool IsProjectImageResponseModel() => Type == "projectImageResponseModel";

    /// <summary>
    /// Returns the value as a ProjectVideoResponseModel if <see cref="Type"/> is "projectVideoResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'projectVideoResponseModel'.</exception>
    public global::ElevenLabs.ProjectVideoResponseModel AsProjectVideoResponseModel() =>
        IsProjectVideoResponseModel()
            ? (global::ElevenLabs.ProjectVideoResponseModel)Value!
            : throw new ElevenLabsClientException("Union type is not 'projectVideoResponseModel'");

    /// <summary>
    /// Returns the value as a ProjectExternalAudioResponseModel if <see cref="Type"/> is "projectExternalAudioResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'projectExternalAudioResponseModel'.</exception>
    public global::ElevenLabs.ProjectExternalAudioResponseModel AsProjectExternalAudioResponseModel() =>
        IsProjectExternalAudioResponseModel()
            ? (global::ElevenLabs.ProjectExternalAudioResponseModel)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'projectExternalAudioResponseModel'"
            );

    /// <summary>
    /// Returns the value as a ProjectImageResponseModel if <see cref="Type"/> is "projectImageResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'projectImageResponseModel'.</exception>
    public global::ElevenLabs.ProjectImageResponseModel AsProjectImageResponseModel() =>
        IsProjectImageResponseModel()
            ? (global::ElevenLabs.ProjectImageResponseModel)Value!
            : throw new ElevenLabsClientException("Union type is not 'projectImageResponseModel'");

    /// <summary>
    /// Attempts to cast the value to a ProjectVideoResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetProjectVideoResponseModel(
        out global::ElevenLabs.ProjectVideoResponseModel? value
    )
    {
        if (Type == "projectVideoResponseModel")
        {
            value = (global::ElevenLabs.ProjectVideoResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ProjectExternalAudioResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetProjectExternalAudioResponseModel(
        out global::ElevenLabs.ProjectExternalAudioResponseModel? value
    )
    {
        if (Type == "projectExternalAudioResponseModel")
        {
            value = (global::ElevenLabs.ProjectExternalAudioResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ProjectImageResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetProjectImageResponseModel(
        out global::ElevenLabs.ProjectImageResponseModel? value
    )
    {
        if (Type == "projectImageResponseModel")
        {
            value = (global::ElevenLabs.ProjectImageResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.ProjectVideoResponseModel,
            T
        > onProjectVideoResponseModel,
        global::System.Func<
            global::ElevenLabs.ProjectExternalAudioResponseModel,
            T
        > onProjectExternalAudioResponseModel,
        global::System.Func<
            global::ElevenLabs.ProjectImageResponseModel,
            T
        > onProjectImageResponseModel
    )
    {
        return Type switch
        {
            "projectVideoResponseModel" => onProjectVideoResponseModel(
                AsProjectVideoResponseModel()
            ),
            "projectExternalAudioResponseModel" => onProjectExternalAudioResponseModel(
                AsProjectExternalAudioResponseModel()
            ),
            "projectImageResponseModel" => onProjectImageResponseModel(
                AsProjectImageResponseModel()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.ProjectVideoResponseModel> onProjectVideoResponseModel,
        global::System.Action<global::ElevenLabs.ProjectExternalAudioResponseModel> onProjectExternalAudioResponseModel,
        global::System.Action<global::ElevenLabs.ProjectImageResponseModel> onProjectImageResponseModel
    )
    {
        switch (Type)
        {
            case "projectVideoResponseModel":
                onProjectVideoResponseModel(AsProjectVideoResponseModel());
                break;
            case "projectExternalAudioResponseModel":
                onProjectExternalAudioResponseModel(AsProjectExternalAudioResponseModel());
                break;
            case "projectImageResponseModel":
                onProjectImageResponseModel(AsProjectImageResponseModel());
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
        if (obj is not ProjectExtendedResponseAssetsItem other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ProjectExtendedResponseAssetsItem(
        global::ElevenLabs.ProjectVideoResponseModel value
    ) => new("projectVideoResponseModel", value);

    public static implicit operator ProjectExtendedResponseAssetsItem(
        global::ElevenLabs.ProjectExternalAudioResponseModel value
    ) => new("projectExternalAudioResponseModel", value);

    public static implicit operator ProjectExtendedResponseAssetsItem(
        global::ElevenLabs.ProjectImageResponseModel value
    ) => new("projectImageResponseModel", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ProjectExtendedResponseAssetsItem>
    {
        public override ProjectExtendedResponseAssetsItem? Read(
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

                // A payload carrying a member's literal decodes as that member or not at all.
                var matchedLiteral = false;

                if (HasLiteral(document, "type", "video"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ProjectVideoResponseModel),
                            options
                        );
                        if (value != null)
                        {
                            return new ProjectExtendedResponseAssetsItem(
                                "projectVideoResponseModel",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "audio"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ProjectExternalAudioResponseModel),
                            options
                        );
                        if (value != null)
                        {
                            return new ProjectExtendedResponseAssetsItem(
                                "projectExternalAudioResponseModel",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (
                    HasLiteral(document, "type", "image")
                    && HasLiteral(document, "source", "upload")
                )
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ProjectImageResponseModel),
                            options
                        );
                        if (value != null)
                        {
                            return new ProjectExtendedResponseAssetsItem(
                                "projectImageResponseModel",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (matchedLiteral)
                {
                    throw new JsonException(
                        "Cannot deserialize JSON object into ProjectExtendedResponseAssetsItem: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "projectVideoResponseModel",
                        typeof(global::ElevenLabs.ProjectVideoResponseModel)
                    ),
                    (
                        "projectExternalAudioResponseModel",
                        typeof(global::ElevenLabs.ProjectExternalAudioResponseModel)
                    ),
                    (
                        "projectImageResponseModel",
                        typeof(global::ElevenLabs.ProjectImageResponseModel)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new ProjectExtendedResponseAssetsItem(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ProjectExtendedResponseAssetsItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectExtendedResponseAssetsItem value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override ProjectExtendedResponseAssetsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ProjectExtendedResponseAssetsItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectExtendedResponseAssetsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }

        private static bool HasLiteral(JsonDocument document, string key, string expected)
        {
            if (!document.RootElement.TryGetProperty(key, out var property))
            {
                return false;
            }

            return property.ValueKind == JsonValueKind.String && property.GetString() == expected;
        }
    }
}
