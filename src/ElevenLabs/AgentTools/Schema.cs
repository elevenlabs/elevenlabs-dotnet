using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;

namespace ElevenLabs.AgentTools;

/// <summary>The kind of a <see cref="Schema"/>: its wire <c>type</c>.</summary>
public enum SchemaKind
{
    String,
    Integer,
    Number,
    Boolean,
    Object,
    Array,
}

/// <summary>Everything a schema holds. Immutable; schemas copy it with changes.</summary>
internal sealed record SchemaState
{
    public SchemaKind Kind { get; init; }

    /// <summary>A loaded literal's <c>type</c>, kept as is (the API also allows a list of types).</summary>
    public JsonNode? LiteralType { get; init; }
    public string? Description { get; init; }
    public string? DynamicVariable { get; init; }
    public bool HasConstant { get; init; }
    public JsonNode? ConstantValue { get; init; }
    public bool SystemProvided { get; init; }
    public bool Omitted { get; init; }
    public bool Optional { get; init; }
    public IReadOnlyList<string>? Choices { get; init; }
    public string? AllowedFrom { get; init; }

    /// <summary>A loaded literal's <c>allowed_values</c> object, so fields other than the variable survive edits.</summary>
    public JsonObject? AllowedValues { get; init; }
    public Schema? Items { get; init; }
    public IReadOnlyList<KeyValuePair<string, Schema>> Properties { get; init; } =
        global::System.Array.Empty<KeyValuePair<string, Schema>>();

    /// <summary>A loaded object's <c>required</c>, so its order survives edits.</summary>
    public IReadOnlyList<string>? LoadedRequired { get; init; }

    /// <summary>
    /// A loaded object's <c>required_constraints</c> fields other than <c>any_of</c> / <c>all_of</c>, or <c>null</c>
    /// if it had none.
    /// </summary>
    public JsonObject? ConstraintsExtra { get; init; }

    /// <summary>The <c>any_of</c> groups, each a wire object with <c>required</c> (and any loaded extras). <c>null</c> when absent.</summary>
    public IReadOnlyList<JsonNode?>? AnyOf { get; init; }

    /// <summary>The <c>all_of</c> groups, as <see cref="AnyOf"/>.</summary>
    public IReadOnlyList<JsonNode?>? AllOf { get; init; }

    /// <summary>Loaded fields the builder doesn't model, and loaded API defaults, written back unchanged. Never mutated.</summary>
    public JsonObject Extra { get; init; } = new();
}

/// <summary>
/// A tool param's JSON schema, and where its value comes from. Schemas are values: every method returns a new
/// schema and never changes the one it is called on, so one schema can be reused across tools and properties.
/// <see cref="String"/>, <see cref="Integer"/>, <see cref="Number"/> and <see cref="Bool"/> return a
/// <see cref="LiteralSchema"/>, <see cref="Object"/> an <see cref="ObjectSchema"/> and <see cref="Array"/> an
/// <see cref="ArraySchema"/>; methods that apply to one kind only live on that subtype.
/// </summary>
/// <example>
/// <code>
/// Schema.Object()
///     .Property("order_id", Schema.String().FromVariable("order_id"))
///     .Property("reason", Schema.String().Describe("Why the caller wants a refund").Choices("damaged", "late"))
///     .Property("note", Schema.String().Describe("Anything else the caller said").Optional());
/// </code>
/// </example>
public abstract class Schema
{
    // Fields the builder models (as JS MODELED_KEYS). Any other loaded field is kept in Extra.
    private static readonly HashSet<string> ModeledKeys = new()
    {
        "type",
        "description",
        "dynamic_variable",
        "constant_value",
        "is_system_provided",
        "is_omitted",
        "enum",
        "allowed_values",
        "items",
        "properties",
        "required",
        "required_constraints",
    };

    private protected Schema(SchemaState state) => State = state;

    internal SchemaState State { get; }

    /// <summary>A string.</summary>
    public static LiteralSchema String() => new(Initial(SchemaKind.String));

    /// <summary>An integer.</summary>
    public static LiteralSchema Integer() => new(Initial(SchemaKind.Integer));

    /// <summary>A number.</summary>
    public static LiteralSchema Number() => new(Initial(SchemaKind.Number));

    /// <summary>A boolean. Named <c>Bool</c> as in every SDK, because <c>boolean</c> is reserved in Java.</summary>
    public static LiteralSchema Bool() => new(Initial(SchemaKind.Boolean));

    /// <summary>An object. Add properties with <see cref="ObjectSchema.Property"/>.</summary>
    public static ObjectSchema Object() => new(Initial(SchemaKind.Object));

    /// <summary>An array whose elements match <paramref name="items"/>.</summary>
    public static ArraySchema Array(Schema items) => new(Initial(SchemaKind.Array) with { Items = items });

    /// <summary>Loads a schema in API format (snake_case), given as a JSON string.</summary>
    public static Schema FromJson(string json) =>
        FromJson(JsonNode.Parse(json) ?? throw new global::System.ArgumentException("The schema JSON is null", nameof(json)));

    /// <summary>Loads a schema in API format (snake_case), given as a parsed JSON object.</summary>
    public static Schema FromJson(JsonNode json) =>
        FromWire(
            ToolWire.WithoutNulls(
                json as JsonObject ?? throw new global::System.ArgumentException("A schema must be a JSON object", nameof(json))
            )
        );

    /// <summary><c>String</c>, <c>Integer</c>, <c>Number</c>, <c>Boolean</c>, <c>Object</c> or <c>Array</c>.</summary>
    public SchemaKind Kind => State.Kind;

    /// <summary>Whether the parent leaves this property out of <c>required</c>.</summary>
    public bool IsOptional => State.Optional;

    /// <summary>The LLM provides the value, guided by <paramref name="text"/>. On an object or array, documents the container.</summary>
    public Schema Describe(string text) => Create(State with { Description = text });

    /// <summary>The value is read from the dynamic variable <paramref name="name"/> when the tool runs.</summary>
    public Schema FromVariable(string name) => Create(State with { DynamicVariable = name });

    /// <summary>
    /// The value is always <paramref name="value"/>, a JSON value matching the schema's type (<c>Build()</c> checks
    /// it). Strings, numbers and booleans convert to <see cref="JsonNode"/> implicitly.
    /// </summary>
    public Schema Constant(JsonNode? value) =>
        Create(State with { HasConstant = true, ConstantValue = value?.DeepClone() });

    /// <summary>The param is left out of the request. Only allowed on an optional property.</summary>
    public Schema Omit() => Create(State with { Omitted = true });

    /// <summary>Leaves this property out of its parent's <c>required</c>. Properties are required unless marked optional.</summary>
    public Schema Optional() => Create(State with { Optional = true });

    /// <summary>The schema in API format (snake_case keys, sorted at every level). Doesn't validate.</summary>
    public JsonObject ToJson() => (JsonObject)Wire.Canonicalize(ToWire())!;

    private protected abstract Schema Create(SchemaState state);

    /// <summary>
    /// Loads a wire-format schema (nulls already removed, except a constant's). <paramref name="optional"/> is whether
    /// its parent leaves it out of <c>required</c>. <paramref name="untypedKind"/> is the kind to infer when the schema
    /// has no <c>type</c>, where the API expects one kind (e.g. a tool's params object); a declared <c>type</c> always
    /// wins, so validation can report a schema of the wrong kind instead of it being rewritten.
    /// </summary>
    internal static Schema FromWire(JsonObject m, bool optional = false, SchemaKind? untypedKind = null)
    {
        var k = untypedKind != null && !m.ContainsKey("type") ? untypedKind.Value : KindOf(m);
        // The API fills unset fields with defaults ("", false, [], {}). They aren't value sources, but are kept as
        // extra fields so a pulled config writes back unchanged.
        var extra = new JsonObject();
        foreach (var field in m)
        {
            if (!ModeledKeys.Contains(field.Key) || IsUnsetValue(field.Key, field.Value, k))
            {
                extra[field.Key] = field.Value?.DeepClone();
            }
        }
        JsonNode? Set(string key) =>
            m.TryGetPropertyValue(key, out var value) && value != null && !IsUnsetValue(key, value, k) ? value : null;

        var constant = Set("constant_value");
        // A null constant is only a value for a literal whose type list includes "null"; anywhere else it is absent.
        var nullConstant =
            constant == null
            && m.TryGetPropertyValue("constant_value", out var loadedConstant)
            && loadedConstant == null
            && IsLiteral(k)
            && IsNullableType(m["type"]);
        var state = Initial(k) with
        {
            Description = ToolWire.Str(Set("description")),
            DynamicVariable = ToolWire.Str(Set("dynamic_variable")),
            HasConstant = constant != null || nullConstant,
            ConstantValue = constant?.DeepClone(),
            Omitted = ToolWire.IsTrue(m["is_omitted"]),
            Optional = optional,
            Extra = extra,
        };

        if (k == SchemaKind.Object)
        {
            var required = ToolWire.StrList(Set("required"));
            var properties = new List<KeyValuePair<string, Schema>>();
            if (Set("properties") is JsonObject props)
            {
                foreach (var prop in props)
                {
                    var child = prop.Value as JsonObject ?? new JsonObject();
                    var isOptional = required == null || !required.Contains(prop.Key);
                    properties.Add(new KeyValuePair<string, Schema>(prop.Key, FromWire(child, isOptional)));
                }
            }
            var constraints = m["required_constraints"] as JsonObject;
            JsonObject? constraintsExtra = null;
            if (constraints != null)
            {
                constraintsExtra = new JsonObject();
                foreach (var field in constraints)
                {
                    if (field.Key != "any_of" && field.Key != "all_of")
                    {
                        constraintsExtra[field.Key] = field.Value?.DeepClone();
                    }
                }
            }
            return new ObjectSchema(
                state with
                {
                    Properties = properties,
                    LoadedRequired = required,
                    ConstraintsExtra = constraintsExtra,
                    AnyOf = ConstraintGroups(constraints?["any_of"]),
                    AllOf = ConstraintGroups(constraints?["all_of"]),
                }
            );
        }
        if (k == SchemaKind.Array)
        {
            var items = Set("items") is JsonObject itemsModel ? FromWire(itemsModel, true) : null;
            return new ArraySchema(state with { Items = items });
        }
        var allowedValues = Set("allowed_values") as JsonObject;
        return new LiteralSchema(
            state with
            {
                LiteralType = m["type"]?.DeepClone(),
                SystemProvided = ToolWire.IsTrue(m["is_system_provided"]),
                Choices = ToolWire.StrList(Set("enum")),
                AllowedFrom = ToolWire.Str(allowedValues?["dynamic_variable"]),
                AllowedValues = (JsonObject?)allowedValues?.DeepClone(),
            }
        );
    }

    /// <summary>The schema in API wire format, unsorted.</summary>
    internal JsonObject ToWire()
    {
        var s = State;
        // Modeled fields that are unset leave the matching extra field (an API default) in place.
        var o = new JsonObject();
        foreach (var field in s.Extra)
        {
            o[field.Key] = field.Value?.DeepClone();
        }
        if (s.Description != null)
        {
            o["description"] = s.Description;
        }
        if (s.DynamicVariable != null)
        {
            o["dynamic_variable"] = s.DynamicVariable;
        }
        if (s.Omitted)
        {
            o["is_omitted"] = true;
        }
        if (s.HasConstant)
        {
            o["constant_value"] = s.ConstantValue?.DeepClone();
        }

        if (s.Kind == SchemaKind.Object)
        {
            o["type"] = "object";
            if (s.Properties.Count > 0)
            {
                var props = new JsonObject();
                foreach (var prop in s.Properties)
                {
                    props[prop.Key] = prop.Value.ToWire();
                }
                o["properties"] = props;
            }
            var required = RequiredOf(s);
            if (required.Count > 0)
            {
                o["required"] = ToolWire.ToArray(required);
            }
            // A loaded wrapper is kept with its own fields, and a loaded (even empty) group list with it.
            if (s.ConstraintsExtra != null || s.AnyOf != null || s.AllOf != null)
            {
                var constraints = (JsonObject?)s.ConstraintsExtra?.DeepClone() ?? new JsonObject();
                if (s.AnyOf != null)
                {
                    constraints["any_of"] = ConstraintsToWire(s.AnyOf);
                }
                if (s.AllOf != null)
                {
                    constraints["all_of"] = ConstraintsToWire(s.AllOf);
                }
                o["required_constraints"] = constraints;
            }
            return o;
        }
        if (s.Kind == SchemaKind.Array)
        {
            o["type"] = "array";
            if (s.Items != null)
            {
                o["items"] = s.Items.ToWire();
            }
            return o;
        }
        o["type"] = s.LiteralType?.DeepClone() ?? KindName(s.Kind);
        if (s.SystemProvided)
        {
            o["is_system_provided"] = true;
        }
        if (s.Choices != null)
        {
            o["enum"] = ToolWire.ToArray(s.Choices);
        }
        if (s.AllowedValues != null || s.AllowedFrom != null)
        {
            // The loaded object keeps its other fields; the variable name is overlaid.
            var allowed = (JsonObject?)s.AllowedValues?.DeepClone() ?? new JsonObject();
            if (s.AllowedFrom != null)
            {
                allowed["dynamic_variable"] = s.AllowedFrom;
            }
            o["allowed_values"] = allowed;
        }
        return o;
    }

    /// <summary>The wire <c>type</c> of a kind.</summary>
    internal static string KindName(SchemaKind kind) =>
        kind switch
        {
            SchemaKind.String => "string",
            SchemaKind.Integer => "integer",
            SchemaKind.Number => "number",
            SchemaKind.Boolean => "boolean",
            SchemaKind.Object => "object",
            _ => "array",
        };

    internal static bool IsLiteral(SchemaKind kind) => kind != SchemaKind.Object && kind != SchemaKind.Array;

    private static SchemaState Initial(SchemaKind kind) => new() { Kind = kind };

    /// <summary>
    /// Whether <paramref name="value"/> is what the API returns for an unset field. A literal's unset constant is
    /// <c>""</c>, so <c>""</c> can't be a literal's constant.
    /// </summary>
    private static bool IsUnsetValue(string key, JsonNode? value, SchemaKind kind)
    {
        switch (key)
        {
            case "description":
            case "dynamic_variable":
                return ToolWire.IsEmptyString(value);
            case "constant_value":
                return IsLiteral(kind) && ToolWire.IsEmptyString(value);
            case "is_system_provided":
            case "is_omitted":
                return value is JsonValue v && v.GetValueKind() == global::System.Text.Json.JsonValueKind.False;
            case "required":
                return value is JsonArray arr && arr.Count == 0;
            case "properties":
                return value is JsonObject obj && obj.Count == 0;
            default:
                return false;
        }
    }

    private static SchemaKind KindOf(JsonObject m)
    {
        var type = m["type"];
        var name = ToolWire.Str(type);
        if (name == "object" || (type == null && m.ContainsKey("properties")))
        {
            return SchemaKind.Object;
        }
        if (name == "array" || (type == null && m.ContainsKey("items")))
        {
            return SchemaKind.Array;
        }
        // A literal's type can be a list such as ["integer", "null"]; its kind is the non-null member.
        if (type is JsonArray list)
        {
            name = list.Select(ToolWire.Str).FirstOrDefault(t => t != "null");
        }
        return name switch
        {
            "integer" => SchemaKind.Integer,
            "number" => SchemaKind.Number,
            "boolean" => SchemaKind.Boolean,
            _ => SchemaKind.String,
        };
    }

    /// <summary>Whether a literal's <c>type</c> is a list that includes <c>"null"</c>, e.g. <c>["integer", "null"]</c>.</summary>
    internal static bool IsNullableType(JsonNode? type) =>
        type is JsonArray list && list.Any(item => ToolWire.Str(item) == "null");

    /// <summary>The names a <c>required_constraints</c> group requires.</summary>
    internal static List<string> GroupNames(JsonNode? group) =>
        ToolWire.StrList((group as JsonObject)?["required"]) ?? new List<string>();

    private static IReadOnlyList<JsonNode?>? ConstraintGroups(JsonNode? node) =>
        node is JsonArray groups ? groups.Select(group => group?.DeepClone()).ToList() : null;

    private static JsonArray ConstraintsToWire(IReadOnlyList<JsonNode?> groups)
    {
        var arr = new JsonArray();
        foreach (var group in groups)
        {
            arr.Add(group?.DeepClone());
        }
        return arr;
    }

    /// <summary>A loaded object's <c>required</c> order for the required properties it still has, then new ones in property order.</summary>
    private static List<string> RequiredOf(SchemaState state)
    {
        var required = state.Properties.Where(prop => !prop.Value.IsOptional).Select(prop => prop.Key).ToList();
        var kept = (state.LoadedRequired ?? new List<string>()).Where(required.Contains).ToList();
        var result = new List<string>(kept);
        result.AddRange(required.Where(name => !kept.Contains(name)));
        return result;
    }
}

/// <summary>A string, integer, number or boolean.</summary>
public sealed class LiteralSchema : Schema
{
    internal LiteralSchema(SchemaState state)
        : base(state) { }

    /// <inheritdoc cref="Schema.Describe"/>
    public new LiteralSchema Describe(string text) => (LiteralSchema)base.Describe(text);

    /// <inheritdoc cref="Schema.FromVariable"/>
    public new LiteralSchema FromVariable(string name) => (LiteralSchema)base.FromVariable(name);

    /// <inheritdoc cref="Schema.Constant"/>
    public new LiteralSchema Constant(JsonNode? value) => (LiteralSchema)base.Constant(value);

    /// <inheritdoc cref="Schema.Omit"/>
    public new LiteralSchema Omit() => (LiteralSchema)base.Omit();

    /// <inheritdoc cref="Schema.Optional"/>
    public new LiteralSchema Optional() => (LiteralSchema)base.Optional();

    /// <summary>The values the LLM may choose from (<c>enum</c>). Strings only. Named <c>Choices</c> because <c>enum</c> is reserved.</summary>
    public LiteralSchema Choices(IEnumerable<string> values) => new(State with { Choices = values.ToList() });

    /// <inheritdoc cref="Choices(IEnumerable{string})"/>
    public LiteralSchema Choices(params string[] values) => Choices((IEnumerable<string>)values);

    /// <summary>The value is filled in by the system at runtime.</summary>
    public LiteralSchema SystemProvided() => new(State with { SystemProvided = true });

    /// <summary>
    /// Rejects an LLM value that isn't in the list held by the dynamic variable <paramref name="variable"/>. The list
    /// isn't shown to the LLM. Needs <see cref="Describe"/>.
    /// </summary>
    public LiteralSchema AllowedFrom(string variable) => new(State with { AllowedFrom = variable });

    private protected override Schema Create(SchemaState state) => new LiteralSchema(state);
}

/// <summary>An object with named properties.</summary>
public sealed class ObjectSchema : Schema
{
    internal ObjectSchema(SchemaState state)
        : base(state) { }

    /// <inheritdoc cref="Schema.Describe"/>
    public new ObjectSchema Describe(string text) => (ObjectSchema)base.Describe(text);

    /// <inheritdoc cref="Schema.FromVariable"/>
    public new ObjectSchema FromVariable(string name) => (ObjectSchema)base.FromVariable(name);

    /// <inheritdoc cref="Schema.Constant"/>
    public new ObjectSchema Constant(JsonNode? value) => (ObjectSchema)base.Constant(value);

    /// <inheritdoc cref="Schema.Omit"/>
    public new ObjectSchema Omit() => (ObjectSchema)base.Omit();

    /// <inheritdoc cref="Schema.Optional"/>
    public new ObjectSchema Optional() => (ObjectSchema)base.Optional();

    /// <summary>Adds the property <paramref name="name"/>, or replaces it in place if it exists.</summary>
    public ObjectSchema Property(string name, Schema schema)
    {
        var properties = State.Properties.ToList();
        var index = properties.FindIndex(prop => prop.Key == name);
        var entry = new KeyValuePair<string, Schema>(name, schema);
        if (index == -1)
        {
            properties.Add(entry);
        }
        else
        {
            properties[index] = entry;
        }
        return new ObjectSchema(State with { Properties = properties });
    }

    /// <summary>Removes the property <paramref name="name"/>.</summary>
    public ObjectSchema Without(string name) =>
        new(State with { Properties = State.Properties.Where(prop => prop.Key != name).ToList() });

    /// <summary>Requires at least one of these sets of properties: appends <paramref name="names"/> to <c>required_constraints.any_of</c>.</summary>
    public ObjectSchema RequireAnyOf(IEnumerable<string> names) =>
        new(State with { AnyOf = Appended(State.AnyOf, names) });

    /// <inheritdoc cref="RequireAnyOf(IEnumerable{string})"/>
    public ObjectSchema RequireAnyOf(params string[] names) => RequireAnyOf((IEnumerable<string>)names);

    /// <summary>Requires all of these sets of properties: appends <paramref name="names"/> to <c>required_constraints.all_of</c>.</summary>
    public ObjectSchema RequireAllOf(IEnumerable<string> names) =>
        new(State with { AllOf = Appended(State.AllOf, names) });

    /// <inheritdoc cref="RequireAllOf(IEnumerable{string})"/>
    public ObjectSchema RequireAllOf(params string[] names) => RequireAllOf((IEnumerable<string>)names);

    /// <summary>Property names, in order.</summary>
    public IReadOnlyList<string> PropertyNames => State.Properties.Select(prop => prop.Key).ToList();

    /// <summary>The schema of property <paramref name="name"/>, or <c>null</c> if there is none.</summary>
    public Schema? PropertySchema(string name)
    {
        foreach (var prop in State.Properties)
        {
            if (prop.Key == name)
            {
                return prop.Value;
            }
        }
        return null;
    }

    private protected override Schema Create(SchemaState state) => new ObjectSchema(state);

    private static List<JsonNode?> Appended(IReadOnlyList<JsonNode?>? groups, IEnumerable<string> names)
    {
        var result = new List<JsonNode?>(groups ?? new List<JsonNode?>());
        result.Add(new JsonObject { ["required"] = ToolWire.ToArray(names) });
        return result;
    }
}

/// <summary>A list whose elements match one schema.</summary>
public sealed class ArraySchema : Schema
{
    internal ArraySchema(SchemaState state)
        : base(state) { }

    /// <inheritdoc cref="Schema.Describe"/>
    public new ArraySchema Describe(string text) => (ArraySchema)base.Describe(text);

    /// <inheritdoc cref="Schema.FromVariable"/>
    public new ArraySchema FromVariable(string name) => (ArraySchema)base.FromVariable(name);

    /// <inheritdoc cref="Schema.Constant"/>
    public new ArraySchema Constant(JsonNode? value) => (ArraySchema)base.Constant(value);

    /// <inheritdoc cref="Schema.Omit"/>
    public new ArraySchema Omit() => (ArraySchema)base.Omit();

    /// <inheritdoc cref="Schema.Optional"/>
    public new ArraySchema Optional() => (ArraySchema)base.Optional();

    /// <summary>The element schema. <c>null</c> only for a loaded array without one, which <c>Build()</c> rejects.</summary>
    public Schema? Items => State.Items;

    private protected override Schema Create(SchemaState state) => new ArraySchema(state);
}
