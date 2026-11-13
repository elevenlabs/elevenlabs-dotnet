// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExportOptions.JsonConverter))]
[Serializable]
public record ExportOptions
{
    internal ExportOptions(string type, object? value)
    {
        Format = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ExportOptions with <see cref="ExportOptions.Docx"/>.
    /// </summary>
    public ExportOptions(ExportOptions.Docx value)
    {
        Format = "docx";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ExportOptions with <see cref="ExportOptions.Html"/>.
    /// </summary>
    public ExportOptions(ExportOptions.Html value)
    {
        Format = "html";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ExportOptions with <see cref="ExportOptions.Pdf"/>.
    /// </summary>
    public ExportOptions(ExportOptions.Pdf value)
    {
        Format = "pdf";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ExportOptions with <see cref="ExportOptions.SegmentedJson"/>.
    /// </summary>
    public ExportOptions(ExportOptions.SegmentedJson value)
    {
        Format = "segmented_json";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ExportOptions with <see cref="ExportOptions.Srt"/>.
    /// </summary>
    public ExportOptions(ExportOptions.Srt value)
    {
        Format = "srt";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ExportOptions with <see cref="ExportOptions.Txt"/>.
    /// </summary>
    public ExportOptions(ExportOptions.Txt value)
    {
        Format = "txt";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Format"/> is "docx"
    /// </summary>
    public bool IsDocx => Format == "docx";

    /// <summary>
    /// Returns true if <see cref="Format"/> is "html"
    /// </summary>
    public bool IsHtml => Format == "html";

    /// <summary>
    /// Returns true if <see cref="Format"/> is "pdf"
    /// </summary>
    public bool IsPdf => Format == "pdf";

    /// <summary>
    /// Returns true if <see cref="Format"/> is "segmented_json"
    /// </summary>
    public bool IsSegmentedJson => Format == "segmented_json";

    /// <summary>
    /// Returns true if <see cref="Format"/> is "srt"
    /// </summary>
    public bool IsSrt => Format == "srt";

    /// <summary>
    /// Returns true if <see cref="Format"/> is "txt"
    /// </summary>
    public bool IsTxt => Format == "txt";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DocxExportOptions"/> if <see cref="Format"/> is 'docx', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'docx'.</exception>
    public global::ElevenLabs.DocxExportOptions AsDocx() =>
        IsDocx
            ? (global::ElevenLabs.DocxExportOptions)Value!
            : throw new global::System.Exception("ExportOptions.Format is not 'docx'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.HtmlExportOptions"/> if <see cref="Format"/> is 'html', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'html'.</exception>
    public global::ElevenLabs.HtmlExportOptions AsHtml() =>
        IsHtml
            ? (global::ElevenLabs.HtmlExportOptions)Value!
            : throw new global::System.Exception("ExportOptions.Format is not 'html'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PdfExportOptions"/> if <see cref="Format"/> is 'pdf', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'pdf'.</exception>
    public global::ElevenLabs.PdfExportOptions AsPdf() =>
        IsPdf
            ? (global::ElevenLabs.PdfExportOptions)Value!
            : throw new global::System.Exception("ExportOptions.Format is not 'pdf'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SegmentedJsonExportOptions"/> if <see cref="Format"/> is 'segmented_json', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'segmented_json'.</exception>
    public global::ElevenLabs.SegmentedJsonExportOptions AsSegmentedJson() =>
        IsSegmentedJson
            ? (global::ElevenLabs.SegmentedJsonExportOptions)Value!
            : throw new global::System.Exception("ExportOptions.Format is not 'segmented_json'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SrtExportOptions"/> if <see cref="Format"/> is 'srt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'srt'.</exception>
    public global::ElevenLabs.SrtExportOptions AsSrt() =>
        IsSrt
            ? (global::ElevenLabs.SrtExportOptions)Value!
            : throw new global::System.Exception("ExportOptions.Format is not 'srt'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TxtExportOptions"/> if <see cref="Format"/> is 'txt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'txt'.</exception>
    public global::ElevenLabs.TxtExportOptions AsTxt() =>
        IsTxt
            ? (global::ElevenLabs.TxtExportOptions)Value!
            : throw new global::System.Exception("ExportOptions.Format is not 'txt'");

    public T Match<T>(
        Func<global::ElevenLabs.DocxExportOptions, T> onDocx,
        Func<global::ElevenLabs.HtmlExportOptions, T> onHtml,
        Func<global::ElevenLabs.PdfExportOptions, T> onPdf,
        Func<global::ElevenLabs.SegmentedJsonExportOptions, T> onSegmentedJson,
        Func<global::ElevenLabs.SrtExportOptions, T> onSrt,
        Func<global::ElevenLabs.TxtExportOptions, T> onTxt,
        Func<string, object?, T> onUnknown_
    )
    {
        return Format switch
        {
            "docx" => onDocx(AsDocx()),
            "html" => onHtml(AsHtml()),
            "pdf" => onPdf(AsPdf()),
            "segmented_json" => onSegmentedJson(AsSegmentedJson()),
            "srt" => onSrt(AsSrt()),
            "txt" => onTxt(AsTxt()),
            _ => onUnknown_(Format, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.DocxExportOptions> onDocx,
        Action<global::ElevenLabs.HtmlExportOptions> onHtml,
        Action<global::ElevenLabs.PdfExportOptions> onPdf,
        Action<global::ElevenLabs.SegmentedJsonExportOptions> onSegmentedJson,
        Action<global::ElevenLabs.SrtExportOptions> onSrt,
        Action<global::ElevenLabs.TxtExportOptions> onTxt,
        Action<string, object?> onUnknown_
    )
    {
        switch (Format)
        {
            case "docx":
                onDocx(AsDocx());
                break;
            case "html":
                onHtml(AsHtml());
                break;
            case "pdf":
                onPdf(AsPdf());
                break;
            case "segmented_json":
                onSegmentedJson(AsSegmentedJson());
                break;
            case "srt":
                onSrt(AsSrt());
                break;
            case "txt":
                onTxt(AsTxt());
                break;
            default:
                onUnknown_(Format, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DocxExportOptions"/> and returns true if successful.
    /// </summary>
    public bool TryAsDocx(out global::ElevenLabs.DocxExportOptions? value)
    {
        if (Format == "docx")
        {
            value = (global::ElevenLabs.DocxExportOptions)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.HtmlExportOptions"/> and returns true if successful.
    /// </summary>
    public bool TryAsHtml(out global::ElevenLabs.HtmlExportOptions? value)
    {
        if (Format == "html")
        {
            value = (global::ElevenLabs.HtmlExportOptions)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PdfExportOptions"/> and returns true if successful.
    /// </summary>
    public bool TryAsPdf(out global::ElevenLabs.PdfExportOptions? value)
    {
        if (Format == "pdf")
        {
            value = (global::ElevenLabs.PdfExportOptions)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SegmentedJsonExportOptions"/> and returns true if successful.
    /// </summary>
    public bool TryAsSegmentedJson(out global::ElevenLabs.SegmentedJsonExportOptions? value)
    {
        if (Format == "segmented_json")
        {
            value = (global::ElevenLabs.SegmentedJsonExportOptions)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SrtExportOptions"/> and returns true if successful.
    /// </summary>
    public bool TryAsSrt(out global::ElevenLabs.SrtExportOptions? value)
    {
        if (Format == "srt")
        {
            value = (global::ElevenLabs.SrtExportOptions)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TxtExportOptions"/> and returns true if successful.
    /// </summary>
    public bool TryAsTxt(out global::ElevenLabs.TxtExportOptions? value)
    {
        if (Format == "txt")
        {
            value = (global::ElevenLabs.TxtExportOptions)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ExportOptions(ExportOptions.Docx value) => new(value);

    public static implicit operator ExportOptions(ExportOptions.Html value) => new(value);

    public static implicit operator ExportOptions(ExportOptions.Pdf value) => new(value);

    public static implicit operator ExportOptions(ExportOptions.SegmentedJson value) => new(value);

    public static implicit operator ExportOptions(ExportOptions.Srt value) => new(value);

    public static implicit operator ExportOptions(ExportOptions.Txt value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ExportOptions>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ExportOptions).IsAssignableFrom(typeToConvert);

        public override ExportOptions Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("format", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'format'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'format' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'format' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'format' is null");

            var value = discriminator switch
            {
                "docx" => json.Deserialize<global::ElevenLabs.DocxExportOptions?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DocxExportOptions"
                    ),
                "html" => json.Deserialize<global::ElevenLabs.HtmlExportOptions?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.HtmlExportOptions"
                    ),
                "pdf" => json.Deserialize<global::ElevenLabs.PdfExportOptions?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PdfExportOptions"
                    ),
                "segmented_json" =>
                    json.Deserialize<global::ElevenLabs.SegmentedJsonExportOptions?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SegmentedJsonExportOptions"
                        ),
                "srt" => json.Deserialize<global::ElevenLabs.SrtExportOptions?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SrtExportOptions"
                    ),
                "txt" => json.Deserialize<global::ElevenLabs.TxtExportOptions?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TxtExportOptions"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ExportOptions(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExportOptions value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Format switch
                {
                    "docx" => JsonSerializer.SerializeToNode(value.Value, options),
                    "html" => JsonSerializer.SerializeToNode(value.Value, options),
                    "pdf" => JsonSerializer.SerializeToNode(value.Value, options),
                    "segmented_json" => JsonSerializer.SerializeToNode(value.Value, options),
                    "srt" => JsonSerializer.SerializeToNode(value.Value, options),
                    "txt" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["format"] = value.Format;
            json.WriteTo(writer, options);
        }

        public override ExportOptions ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ExportOptions(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExportOptions value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Format);
        }
    }

    /// <summary>
    /// Discriminated union type for docx
    /// </summary>
    [Serializable]
    public struct Docx
    {
        public Docx(global::ElevenLabs.DocxExportOptions value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DocxExportOptions Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExportOptions.Docx(
            global::ElevenLabs.DocxExportOptions value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for html
    /// </summary>
    [Serializable]
    public struct Html
    {
        public Html(global::ElevenLabs.HtmlExportOptions value)
        {
            Value = value;
        }

        internal global::ElevenLabs.HtmlExportOptions Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExportOptions.Html(
            global::ElevenLabs.HtmlExportOptions value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for pdf
    /// </summary>
    [Serializable]
    public struct Pdf
    {
        public Pdf(global::ElevenLabs.PdfExportOptions value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PdfExportOptions Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExportOptions.Pdf(
            global::ElevenLabs.PdfExportOptions value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for segmented_json
    /// </summary>
    [Serializable]
    public struct SegmentedJson
    {
        public SegmentedJson(global::ElevenLabs.SegmentedJsonExportOptions value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SegmentedJsonExportOptions Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExportOptions.SegmentedJson(
            global::ElevenLabs.SegmentedJsonExportOptions value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for srt
    /// </summary>
    [Serializable]
    public struct Srt
    {
        public Srt(global::ElevenLabs.SrtExportOptions value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SrtExportOptions Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExportOptions.Srt(
            global::ElevenLabs.SrtExportOptions value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for txt
    /// </summary>
    [Serializable]
    public struct Txt
    {
        public Txt(global::ElevenLabs.TxtExportOptions value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TxtExportOptions Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ExportOptions.Txt(
            global::ElevenLabs.TxtExportOptions value
        ) => new(value);
    }
}
