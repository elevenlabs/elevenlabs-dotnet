// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GetTicketResponseEventsItem.JsonConverter))]
[Serializable]
public record GetTicketResponseEventsItem
{
    internal GetTicketResponseEventsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.AssigneeChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.AssigneeChanged value)
    {
        Type = "assignee_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.DeadlineChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.DeadlineChanged value)
    {
        Type = "deadline_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.Message"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.Message value)
    {
        Type = "message";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.PriorityChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.PriorityChanged value)
    {
        Type = "priority_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.SecondaryAssigneeChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.SecondaryAssigneeChanged value)
    {
        Type = "secondary_assignee_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.StatusChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.StatusChanged value)
    {
        Type = "status_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.SubjectChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.SubjectChanged value)
    {
        Type = "subject_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.SubscribersChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.SubscribersChanged value)
    {
        Type = "subscribers_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.TagIdsChanged"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.TagIdsChanged value)
    {
        Type = "tag_ids_changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.TicketCreated"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.TicketCreated value)
    {
        Type = "ticket_created";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetTicketResponseEventsItem with <see cref="GetTicketResponseEventsItem.TicketDeleted"/>.
    /// </summary>
    public GetTicketResponseEventsItem(GetTicketResponseEventsItem.TicketDeleted value)
    {
        Type = "ticket_deleted";
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
    /// Returns true if <see cref="Type"/> is "assignee_changed"
    /// </summary>
    public bool IsAssigneeChanged => Type == "assignee_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "deadline_changed"
    /// </summary>
    public bool IsDeadlineChanged => Type == "deadline_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "message"
    /// </summary>
    public bool IsMessage => Type == "message";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "priority_changed"
    /// </summary>
    public bool IsPriorityChanged => Type == "priority_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "secondary_assignee_changed"
    /// </summary>
    public bool IsSecondaryAssigneeChanged => Type == "secondary_assignee_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "status_changed"
    /// </summary>
    public bool IsStatusChanged => Type == "status_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "subject_changed"
    /// </summary>
    public bool IsSubjectChanged => Type == "subject_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "subscribers_changed"
    /// </summary>
    public bool IsSubscribersChanged => Type == "subscribers_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "tag_ids_changed"
    /// </summary>
    public bool IsTagIdsChanged => Type == "tag_ids_changed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ticket_created"
    /// </summary>
    public bool IsTicketCreated => Type == "ticket_created";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "ticket_deleted"
    /// </summary>
    public bool IsTicketDeleted => Type == "ticket_deleted";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketAssigneeChangedEventResponse"/> if <see cref="Type"/> is 'assignee_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'assignee_changed'.</exception>
    public global::ElevenLabs.TicketAssigneeChangedEventResponse AsAssigneeChanged() =>
        IsAssigneeChanged
            ? (global::ElevenLabs.TicketAssigneeChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'assignee_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketDeadlineChangedEventResponse"/> if <see cref="Type"/> is 'deadline_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'deadline_changed'.</exception>
    public global::ElevenLabs.TicketDeadlineChangedEventResponse AsDeadlineChanged() =>
        IsDeadlineChanged
            ? (global::ElevenLabs.TicketDeadlineChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'deadline_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketMessageEventResponse"/> if <see cref="Type"/> is 'message', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'message'.</exception>
    public global::ElevenLabs.TicketMessageEventResponse AsMessage() =>
        IsMessage
            ? (global::ElevenLabs.TicketMessageEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'message'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketPriorityChangedEventResponse"/> if <see cref="Type"/> is 'priority_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'priority_changed'.</exception>
    public global::ElevenLabs.TicketPriorityChangedEventResponse AsPriorityChanged() =>
        IsPriorityChanged
            ? (global::ElevenLabs.TicketPriorityChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'priority_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse"/> if <see cref="Type"/> is 'secondary_assignee_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'secondary_assignee_changed'.</exception>
    public global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse AsSecondaryAssigneeChanged() =>
        IsSecondaryAssigneeChanged
            ? (global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'secondary_assignee_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketStatusChangedEventResponse"/> if <see cref="Type"/> is 'status_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'status_changed'.</exception>
    public global::ElevenLabs.TicketStatusChangedEventResponse AsStatusChanged() =>
        IsStatusChanged
            ? (global::ElevenLabs.TicketStatusChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'status_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketSubjectChangedEventResponse"/> if <see cref="Type"/> is 'subject_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'subject_changed'.</exception>
    public global::ElevenLabs.TicketSubjectChangedEventResponse AsSubjectChanged() =>
        IsSubjectChanged
            ? (global::ElevenLabs.TicketSubjectChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'subject_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketSubscribersChangedEventResponse"/> if <see cref="Type"/> is 'subscribers_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'subscribers_changed'.</exception>
    public global::ElevenLabs.TicketSubscribersChangedEventResponse AsSubscribersChanged() =>
        IsSubscribersChanged
            ? (global::ElevenLabs.TicketSubscribersChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'subscribers_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketTagIdsChangedEventResponse"/> if <see cref="Type"/> is 'tag_ids_changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'tag_ids_changed'.</exception>
    public global::ElevenLabs.TicketTagIdsChangedEventResponse AsTagIdsChanged() =>
        IsTagIdsChanged
            ? (global::ElevenLabs.TicketTagIdsChangedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'tag_ids_changed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketCreatedEventResponse"/> if <see cref="Type"/> is 'ticket_created', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ticket_created'.</exception>
    public global::ElevenLabs.TicketCreatedEventResponse AsTicketCreated() =>
        IsTicketCreated
            ? (global::ElevenLabs.TicketCreatedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'ticket_created'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TicketDeletedEventResponse"/> if <see cref="Type"/> is 'ticket_deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'ticket_deleted'.</exception>
    public global::ElevenLabs.TicketDeletedEventResponse AsTicketDeleted() =>
        IsTicketDeleted
            ? (global::ElevenLabs.TicketDeletedEventResponse)Value!
            : throw new global::System.Exception(
                "GetTicketResponseEventsItem.Type is not 'ticket_deleted'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TicketAssigneeChangedEventResponse, T> onAssigneeChanged,
        Func<global::ElevenLabs.TicketDeadlineChangedEventResponse, T> onDeadlineChanged,
        Func<global::ElevenLabs.TicketMessageEventResponse, T> onMessage,
        Func<global::ElevenLabs.TicketPriorityChangedEventResponse, T> onPriorityChanged,
        Func<
            global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse,
            T
        > onSecondaryAssigneeChanged,
        Func<global::ElevenLabs.TicketStatusChangedEventResponse, T> onStatusChanged,
        Func<global::ElevenLabs.TicketSubjectChangedEventResponse, T> onSubjectChanged,
        Func<global::ElevenLabs.TicketSubscribersChangedEventResponse, T> onSubscribersChanged,
        Func<global::ElevenLabs.TicketTagIdsChangedEventResponse, T> onTagIdsChanged,
        Func<global::ElevenLabs.TicketCreatedEventResponse, T> onTicketCreated,
        Func<global::ElevenLabs.TicketDeletedEventResponse, T> onTicketDeleted,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "assignee_changed" => onAssigneeChanged(AsAssigneeChanged()),
            "deadline_changed" => onDeadlineChanged(AsDeadlineChanged()),
            "message" => onMessage(AsMessage()),
            "priority_changed" => onPriorityChanged(AsPriorityChanged()),
            "secondary_assignee_changed" => onSecondaryAssigneeChanged(
                AsSecondaryAssigneeChanged()
            ),
            "status_changed" => onStatusChanged(AsStatusChanged()),
            "subject_changed" => onSubjectChanged(AsSubjectChanged()),
            "subscribers_changed" => onSubscribersChanged(AsSubscribersChanged()),
            "tag_ids_changed" => onTagIdsChanged(AsTagIdsChanged()),
            "ticket_created" => onTicketCreated(AsTicketCreated()),
            "ticket_deleted" => onTicketDeleted(AsTicketDeleted()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TicketAssigneeChangedEventResponse> onAssigneeChanged,
        Action<global::ElevenLabs.TicketDeadlineChangedEventResponse> onDeadlineChanged,
        Action<global::ElevenLabs.TicketMessageEventResponse> onMessage,
        Action<global::ElevenLabs.TicketPriorityChangedEventResponse> onPriorityChanged,
        Action<global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse> onSecondaryAssigneeChanged,
        Action<global::ElevenLabs.TicketStatusChangedEventResponse> onStatusChanged,
        Action<global::ElevenLabs.TicketSubjectChangedEventResponse> onSubjectChanged,
        Action<global::ElevenLabs.TicketSubscribersChangedEventResponse> onSubscribersChanged,
        Action<global::ElevenLabs.TicketTagIdsChangedEventResponse> onTagIdsChanged,
        Action<global::ElevenLabs.TicketCreatedEventResponse> onTicketCreated,
        Action<global::ElevenLabs.TicketDeletedEventResponse> onTicketDeleted,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "assignee_changed":
                onAssigneeChanged(AsAssigneeChanged());
                break;
            case "deadline_changed":
                onDeadlineChanged(AsDeadlineChanged());
                break;
            case "message":
                onMessage(AsMessage());
                break;
            case "priority_changed":
                onPriorityChanged(AsPriorityChanged());
                break;
            case "secondary_assignee_changed":
                onSecondaryAssigneeChanged(AsSecondaryAssigneeChanged());
                break;
            case "status_changed":
                onStatusChanged(AsStatusChanged());
                break;
            case "subject_changed":
                onSubjectChanged(AsSubjectChanged());
                break;
            case "subscribers_changed":
                onSubscribersChanged(AsSubscribersChanged());
                break;
            case "tag_ids_changed":
                onTagIdsChanged(AsTagIdsChanged());
                break;
            case "ticket_created":
                onTicketCreated(AsTicketCreated());
                break;
            case "ticket_deleted":
                onTicketDeleted(AsTicketDeleted());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketAssigneeChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsAssigneeChanged(
        out global::ElevenLabs.TicketAssigneeChangedEventResponse? value
    )
    {
        if (Type == "assignee_changed")
        {
            value = (global::ElevenLabs.TicketAssigneeChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketDeadlineChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeadlineChanged(
        out global::ElevenLabs.TicketDeadlineChangedEventResponse? value
    )
    {
        if (Type == "deadline_changed")
        {
            value = (global::ElevenLabs.TicketDeadlineChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketMessageEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsMessage(out global::ElevenLabs.TicketMessageEventResponse? value)
    {
        if (Type == "message")
        {
            value = (global::ElevenLabs.TicketMessageEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketPriorityChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsPriorityChanged(
        out global::ElevenLabs.TicketPriorityChangedEventResponse? value
    )
    {
        if (Type == "priority_changed")
        {
            value = (global::ElevenLabs.TicketPriorityChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsSecondaryAssigneeChanged(
        out global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse? value
    )
    {
        if (Type == "secondary_assignee_changed")
        {
            value = (global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketStatusChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsStatusChanged(out global::ElevenLabs.TicketStatusChangedEventResponse? value)
    {
        if (Type == "status_changed")
        {
            value = (global::ElevenLabs.TicketStatusChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketSubjectChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubjectChanged(out global::ElevenLabs.TicketSubjectChangedEventResponse? value)
    {
        if (Type == "subject_changed")
        {
            value = (global::ElevenLabs.TicketSubjectChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketSubscribersChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubscribersChanged(
        out global::ElevenLabs.TicketSubscribersChangedEventResponse? value
    )
    {
        if (Type == "subscribers_changed")
        {
            value = (global::ElevenLabs.TicketSubscribersChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketTagIdsChangedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsTagIdsChanged(out global::ElevenLabs.TicketTagIdsChangedEventResponse? value)
    {
        if (Type == "tag_ids_changed")
        {
            value = (global::ElevenLabs.TicketTagIdsChangedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketCreatedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsTicketCreated(out global::ElevenLabs.TicketCreatedEventResponse? value)
    {
        if (Type == "ticket_created")
        {
            value = (global::ElevenLabs.TicketCreatedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TicketDeletedEventResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsTicketDeleted(out global::ElevenLabs.TicketDeletedEventResponse? value)
    {
        if (Type == "ticket_deleted")
        {
            value = (global::ElevenLabs.TicketDeletedEventResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.AssigneeChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.DeadlineChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.Message value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.PriorityChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.SecondaryAssigneeChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.StatusChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.SubjectChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.SubscribersChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.TagIdsChanged value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.TicketCreated value
    ) => new(value);

    public static implicit operator GetTicketResponseEventsItem(
        GetTicketResponseEventsItem.TicketDeleted value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GetTicketResponseEventsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(GetTicketResponseEventsItem).IsAssignableFrom(typeToConvert);

        public override GetTicketResponseEventsItem Read(
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
                "assignee_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketAssigneeChangedEventResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketAssigneeChangedEventResponse"
                        ),
                "deadline_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketDeadlineChangedEventResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketDeadlineChangedEventResponse"
                        ),
                "message" => json.Deserialize<global::ElevenLabs.TicketMessageEventResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TicketMessageEventResponse"
                    ),
                "priority_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketPriorityChangedEventResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketPriorityChangedEventResponse"
                        ),
                "secondary_assignee_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse"
                        ),
                "status_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketStatusChangedEventResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketStatusChangedEventResponse"
                        ),
                "subject_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketSubjectChangedEventResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketSubjectChangedEventResponse"
                        ),
                "subscribers_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketSubscribersChangedEventResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketSubscribersChangedEventResponse"
                        ),
                "tag_ids_changed" =>
                    json.Deserialize<global::ElevenLabs.TicketTagIdsChangedEventResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketTagIdsChangedEventResponse"
                        ),
                "ticket_created" =>
                    json.Deserialize<global::ElevenLabs.TicketCreatedEventResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketCreatedEventResponse"
                        ),
                "ticket_deleted" =>
                    json.Deserialize<global::ElevenLabs.TicketDeletedEventResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TicketDeletedEventResponse"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new GetTicketResponseEventsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetTicketResponseEventsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "assignee_changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "deadline_changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "message" => JsonSerializer.SerializeToNode(value.Value, options),
                    "priority_changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "secondary_assignee_changed" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "status_changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "subject_changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "subscribers_changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "tag_ids_changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ticket_created" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ticket_deleted" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override GetTicketResponseEventsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new GetTicketResponseEventsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetTicketResponseEventsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for assignee_changed
    /// </summary>
    [Serializable]
    public struct AssigneeChanged
    {
        public AssigneeChanged(global::ElevenLabs.TicketAssigneeChangedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketAssigneeChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.AssigneeChanged(
            global::ElevenLabs.TicketAssigneeChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for deadline_changed
    /// </summary>
    [Serializable]
    public struct DeadlineChanged
    {
        public DeadlineChanged(global::ElevenLabs.TicketDeadlineChangedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketDeadlineChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.DeadlineChanged(
            global::ElevenLabs.TicketDeadlineChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for message
    /// </summary>
    [Serializable]
    public struct Message
    {
        public Message(global::ElevenLabs.TicketMessageEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketMessageEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.Message(
            global::ElevenLabs.TicketMessageEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for priority_changed
    /// </summary>
    [Serializable]
    public struct PriorityChanged
    {
        public PriorityChanged(global::ElevenLabs.TicketPriorityChangedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketPriorityChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.PriorityChanged(
            global::ElevenLabs.TicketPriorityChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for secondary_assignee_changed
    /// </summary>
    [Serializable]
    public struct SecondaryAssigneeChanged
    {
        public SecondaryAssigneeChanged(
            global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.SecondaryAssigneeChanged(
            global::ElevenLabs.TicketSecondaryAssigneeChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for status_changed
    /// </summary>
    [Serializable]
    public struct StatusChanged
    {
        public StatusChanged(global::ElevenLabs.TicketStatusChangedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketStatusChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.StatusChanged(
            global::ElevenLabs.TicketStatusChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for subject_changed
    /// </summary>
    [Serializable]
    public struct SubjectChanged
    {
        public SubjectChanged(global::ElevenLabs.TicketSubjectChangedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketSubjectChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.SubjectChanged(
            global::ElevenLabs.TicketSubjectChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for subscribers_changed
    /// </summary>
    [Serializable]
    public struct SubscribersChanged
    {
        public SubscribersChanged(global::ElevenLabs.TicketSubscribersChangedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketSubscribersChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.SubscribersChanged(
            global::ElevenLabs.TicketSubscribersChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for tag_ids_changed
    /// </summary>
    [Serializable]
    public struct TagIdsChanged
    {
        public TagIdsChanged(global::ElevenLabs.TicketTagIdsChangedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketTagIdsChangedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.TagIdsChanged(
            global::ElevenLabs.TicketTagIdsChangedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ticket_created
    /// </summary>
    [Serializable]
    public struct TicketCreated
    {
        public TicketCreated(global::ElevenLabs.TicketCreatedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketCreatedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.TicketCreated(
            global::ElevenLabs.TicketCreatedEventResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ticket_deleted
    /// </summary>
    [Serializable]
    public struct TicketDeleted
    {
        public TicketDeleted(global::ElevenLabs.TicketDeletedEventResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TicketDeletedEventResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetTicketResponseEventsItem.TicketDeleted(
            global::ElevenLabs.TicketDeletedEventResponse value
        ) => new(value);
    }
}
