using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DirectPublishingReadResponseModelGenreItem.DirectPublishingReadResponseModelGenreItemSerializer)
)]
[Serializable]
public readonly record struct DirectPublishingReadResponseModelGenreItem : IStringEnum
{
    public static readonly DirectPublishingReadResponseModelGenreItem Fantasy = new(Values.Fantasy);

    public static readonly DirectPublishingReadResponseModelGenreItem Romance = new(Values.Romance);

    public static readonly DirectPublishingReadResponseModelGenreItem ScienceFiction = new(
        Values.ScienceFiction
    );

    public static readonly DirectPublishingReadResponseModelGenreItem MysteryAndThriller = new(
        Values.MysteryAndThriller
    );

    public static readonly DirectPublishingReadResponseModelGenreItem ActionAndAdventure = new(
        Values.ActionAndAdventure
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Dystopia = new(
        Values.Dystopia
    );

    public static readonly DirectPublishingReadResponseModelGenreItem BusinessAndEconomics = new(
        Values.BusinessAndEconomics
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Technology = new(
        Values.Technology
    );

    public static readonly DirectPublishingReadResponseModelGenreItem ChristianInspirational = new(
        Values.ChristianInspirational
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Horror = new(Values.Horror);

    public static readonly DirectPublishingReadResponseModelGenreItem BiographyAndMemoir = new(
        Values.BiographyAndMemoir
    );

    public static readonly DirectPublishingReadResponseModelGenreItem EducationAndLearning = new(
        Values.EducationAndLearning
    );

    public static readonly DirectPublishingReadResponseModelGenreItem History = new(Values.History);

    public static readonly DirectPublishingReadResponseModelGenreItem ChildrensLiterature = new(
        Values.ChildrensLiterature
    );

    public static readonly DirectPublishingReadResponseModelGenreItem YoungAdult = new(
        Values.YoungAdult
    );

    public static readonly DirectPublishingReadResponseModelGenreItem FairyTalesAndFolklore = new(
        Values.FairyTalesAndFolklore
    );

    public static readonly DirectPublishingReadResponseModelGenreItem FanFiction = new(
        Values.FanFiction
    );

    public static readonly DirectPublishingReadResponseModelGenreItem GeneralFiction = new(
        Values.GeneralFiction
    );

    public static readonly DirectPublishingReadResponseModelGenreItem HealthAndWellness = new(
        Values.HealthAndWellness
    );

    public static readonly DirectPublishingReadResponseModelGenreItem HistoricalFiction = new(
        Values.HistoricalFiction
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Humor = new(Values.Humor);

    public static readonly DirectPublishingReadResponseModelGenreItem LiteraryClassics = new(
        Values.LiteraryClassics
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Philosophy = new(
        Values.Philosophy
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Poetry = new(Values.Poetry);

    public static readonly DirectPublishingReadResponseModelGenreItem PoliticsAndGovernment = new(
        Values.PoliticsAndGovernment
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Psychology = new(
        Values.Psychology
    );

    public static readonly DirectPublishingReadResponseModelGenreItem ScienceAndNature = new(
        Values.ScienceAndNature
    );

    public static readonly DirectPublishingReadResponseModelGenreItem SelfHelp = new(
        Values.SelfHelp
    );

    public static readonly DirectPublishingReadResponseModelGenreItem SpiritualityAndReligion = new(
        Values.SpiritualityAndReligion
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Travel = new(Values.Travel);

    public static readonly DirectPublishingReadResponseModelGenreItem TrueCrime = new(
        Values.TrueCrime
    );

    public static readonly DirectPublishingReadResponseModelGenreItem Other = new(Values.Other);

    public DirectPublishingReadResponseModelGenreItem(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static DirectPublishingReadResponseModelGenreItem FromCustom(string value)
    {
        return new DirectPublishingReadResponseModelGenreItem(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        DirectPublishingReadResponseModelGenreItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DirectPublishingReadResponseModelGenreItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DirectPublishingReadResponseModelGenreItem value) =>
        value.Value;

    public static explicit operator DirectPublishingReadResponseModelGenreItem(string value) =>
        new(value);

    internal class DirectPublishingReadResponseModelGenreItemSerializer
        : JsonConverter<DirectPublishingReadResponseModelGenreItem>
    {
        public override DirectPublishingReadResponseModelGenreItem Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new DirectPublishingReadResponseModelGenreItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelGenreItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DirectPublishingReadResponseModelGenreItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new DirectPublishingReadResponseModelGenreItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelGenreItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Fantasy = "Fantasy";

        public const string Romance = "Romance";

        public const string ScienceFiction = "Science Fiction";

        public const string MysteryAndThriller = "Mystery and Thriller";

        public const string ActionAndAdventure = "Action and Adventure";

        public const string Dystopia = "Dystopia";

        public const string BusinessAndEconomics = "Business and Economics";

        public const string Technology = "Technology";

        public const string ChristianInspirational = "Christian & Inspirational";

        public const string Horror = "Horror";

        public const string BiographyAndMemoir = "Biography and Memoir";

        public const string EducationAndLearning = "Education and Learning";

        public const string History = "History";

        public const string ChildrensLiterature = "Children's Literature";

        public const string YoungAdult = "Young Adult";

        public const string FairyTalesAndFolklore = "Fairy Tales and Folklore";

        public const string FanFiction = "Fan Fiction";

        public const string GeneralFiction = "General Fiction";

        public const string HealthAndWellness = "Health and Wellness";

        public const string HistoricalFiction = "Historical Fiction";

        public const string Humor = "Humor";

        public const string LiteraryClassics = "Literary Classics";

        public const string Philosophy = "Philosophy";

        public const string Poetry = "Poetry";

        public const string PoliticsAndGovernment = "Politics and Government";

        public const string Psychology = "Psychology";

        public const string ScienceAndNature = "Science and Nature";

        public const string SelfHelp = "Self-Help";

        public const string SpiritualityAndReligion = "Spirituality and Religion";

        public const string Travel = "Travel";

        public const string TrueCrime = "True Crime";

        public const string Other = "Other";
    }
}
