using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Entity types for the API configuration.
///
/// This enum contains all valid entity type configurations that users can specify:
/// - Parent types (e.g., "name", "financial_id") that expand to all subtypes
/// - Specific subtypes using dot notation (e.g., "name.full_name")
/// - Standalone terminal types (e.g., "email_address")
///
/// When converted for service use, parent types expand to all their terminal subtypes.
/// </summary>
[JsonConverter(typeof(ConfigEntityType.ConfigEntityTypeSerializer))]
[Serializable]
public readonly record struct ConfigEntityType : IStringEnum
{
    public static readonly ConfigEntityType Name = new(Values.Name);

    public static readonly ConfigEntityType NameNameGiven = new(Values.NameNameGiven);

    public static readonly ConfigEntityType NameNameFamily = new(Values.NameNameFamily);

    public static readonly ConfigEntityType NameNameOther = new(Values.NameNameOther);

    public static readonly ConfigEntityType EmailAddress = new(Values.EmailAddress);

    public static readonly ConfigEntityType ContactNumber = new(Values.ContactNumber);

    public static readonly ConfigEntityType Dob = new(Values.Dob);

    public static readonly ConfigEntityType Age = new(Values.Age);

    public static readonly ConfigEntityType ReligiousBelief = new(Values.ReligiousBelief);

    public static readonly ConfigEntityType PoliticalOpinion = new(Values.PoliticalOpinion);

    public static readonly ConfigEntityType SexualOrientation = new(Values.SexualOrientation);

    public static readonly ConfigEntityType EthnicityRace = new(Values.EthnicityRace);

    public static readonly ConfigEntityType MaritalStatus = new(Values.MaritalStatus);

    public static readonly ConfigEntityType Occupation = new(Values.Occupation);

    public static readonly ConfigEntityType PhysicalAttribute = new(Values.PhysicalAttribute);

    public static readonly ConfigEntityType Language = new(Values.Language);

    public static readonly ConfigEntityType Username = new(Values.Username);

    public static readonly ConfigEntityType Password = new(Values.Password);

    public static readonly ConfigEntityType Url = new(Values.Url);

    public static readonly ConfigEntityType Organization = new(Values.Organization);

    public static readonly ConfigEntityType FinancialId = new(Values.FinancialId);

    public static readonly ConfigEntityType FinancialIdPaymentCard = new(
        Values.FinancialIdPaymentCard
    );

    public static readonly ConfigEntityType FinancialIdPaymentCardPaymentCardNumber = new(
        Values.FinancialIdPaymentCardPaymentCardNumber
    );

    public static readonly ConfigEntityType FinancialIdPaymentCardPaymentCardExpirationDate = new(
        Values.FinancialIdPaymentCardPaymentCardExpirationDate
    );

    public static readonly ConfigEntityType FinancialIdPaymentCardPaymentCardCvv = new(
        Values.FinancialIdPaymentCardPaymentCardCvv
    );

    public static readonly ConfigEntityType FinancialIdBankAccount = new(
        Values.FinancialIdBankAccount
    );

    public static readonly ConfigEntityType FinancialIdBankAccountBankAccountNumber = new(
        Values.FinancialIdBankAccountBankAccountNumber
    );

    public static readonly ConfigEntityType FinancialIdBankAccountBankRoutingNumber = new(
        Values.FinancialIdBankAccountBankRoutingNumber
    );

    public static readonly ConfigEntityType FinancialIdBankAccountSwiftBicCode = new(
        Values.FinancialIdBankAccountSwiftBicCode
    );

    public static readonly ConfigEntityType FinancialIdFinancialIdOther = new(
        Values.FinancialIdFinancialIdOther
    );

    public static readonly ConfigEntityType Location = new(Values.Location);

    public static readonly ConfigEntityType LocationLocationAddress = new(
        Values.LocationLocationAddress
    );

    public static readonly ConfigEntityType LocationLocationCity = new(Values.LocationLocationCity);

    public static readonly ConfigEntityType LocationLocationPostalCode = new(
        Values.LocationLocationPostalCode
    );

    public static readonly ConfigEntityType LocationLocationCoordinate = new(
        Values.LocationLocationCoordinate
    );

    public static readonly ConfigEntityType LocationLocationState = new(
        Values.LocationLocationState
    );

    public static readonly ConfigEntityType LocationLocationCountry = new(
        Values.LocationLocationCountry
    );

    public static readonly ConfigEntityType LocationLocationOther = new(
        Values.LocationLocationOther
    );

    public static readonly ConfigEntityType Date = new(Values.Date);

    public static readonly ConfigEntityType DateInterval = new(Values.DateInterval);

    public static readonly ConfigEntityType UniqueId = new(Values.UniqueId);

    public static readonly ConfigEntityType UniqueIdGovernmentIssuedId = new(
        Values.UniqueIdGovernmentIssuedId
    );

    public static readonly ConfigEntityType UniqueIdAccountNumber = new(
        Values.UniqueIdAccountNumber
    );

    public static readonly ConfigEntityType UniqueIdVehicleId = new(Values.UniqueIdVehicleId);

    public static readonly ConfigEntityType UniqueIdHealthcareNumber = new(
        Values.UniqueIdHealthcareNumber
    );

    public static readonly ConfigEntityType UniqueIdHealthcareNumberMedicalRecordNumber = new(
        Values.UniqueIdHealthcareNumberMedicalRecordNumber
    );

    public static readonly ConfigEntityType UniqueIdHealthcareNumberHealthPlanBeneficiaryNumber =
        new(Values.UniqueIdHealthcareNumberHealthPlanBeneficiaryNumber);

    public static readonly ConfigEntityType UniqueIdDeviceId = new(Values.UniqueIdDeviceId);

    public static readonly ConfigEntityType UniqueIdUniqueIdOther = new(
        Values.UniqueIdUniqueIdOther
    );

    public static readonly ConfigEntityType Medical = new(Values.Medical);

    public static readonly ConfigEntityType MedicalMedicalCondition = new(
        Values.MedicalMedicalCondition
    );

    public static readonly ConfigEntityType MedicalMedication = new(Values.MedicalMedication);

    public static readonly ConfigEntityType MedicalMedicalProcedure = new(
        Values.MedicalMedicalProcedure
    );

    public static readonly ConfigEntityType MedicalMedicalMeasurement = new(
        Values.MedicalMedicalMeasurement
    );

    public static readonly ConfigEntityType MedicalMedicalOther = new(Values.MedicalMedicalOther);

    public ConfigEntityType(string value)
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
    public static ConfigEntityType FromCustom(string value)
    {
        return new ConfigEntityType(value);
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

    public static bool operator ==(ConfigEntityType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConfigEntityType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConfigEntityType value) => value.Value;

    public static explicit operator ConfigEntityType(string value) => new(value);

    internal class ConfigEntityTypeSerializer : JsonConverter<ConfigEntityType>
    {
        public override ConfigEntityType Read(
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
            return new ConfigEntityType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConfigEntityType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConfigEntityType ReadAsPropertyName(
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
            return new ConfigEntityType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConfigEntityType value,
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
        public const string Name = "name";

        public const string NameNameGiven = "name.name_given";

        public const string NameNameFamily = "name.name_family";

        public const string NameNameOther = "name.name_other";

        public const string EmailAddress = "email_address";

        public const string ContactNumber = "contact_number";

        public const string Dob = "dob";

        public const string Age = "age";

        public const string ReligiousBelief = "religious_belief";

        public const string PoliticalOpinion = "political_opinion";

        public const string SexualOrientation = "sexual_orientation";

        public const string EthnicityRace = "ethnicity_race";

        public const string MaritalStatus = "marital_status";

        public const string Occupation = "occupation";

        public const string PhysicalAttribute = "physical_attribute";

        public const string Language = "language";

        public const string Username = "username";

        public const string Password = "password";

        public const string Url = "url";

        public const string Organization = "organization";

        public const string FinancialId = "financial_id";

        public const string FinancialIdPaymentCard = "financial_id.payment_card";

        public const string FinancialIdPaymentCardPaymentCardNumber =
            "financial_id.payment_card.payment_card_number";

        public const string FinancialIdPaymentCardPaymentCardExpirationDate =
            "financial_id.payment_card.payment_card_expiration_date";

        public const string FinancialIdPaymentCardPaymentCardCvv =
            "financial_id.payment_card.payment_card_cvv";

        public const string FinancialIdBankAccount = "financial_id.bank_account";

        public const string FinancialIdBankAccountBankAccountNumber =
            "financial_id.bank_account.bank_account_number";

        public const string FinancialIdBankAccountBankRoutingNumber =
            "financial_id.bank_account.bank_routing_number";

        public const string FinancialIdBankAccountSwiftBicCode =
            "financial_id.bank_account.swift_bic_code";

        public const string FinancialIdFinancialIdOther = "financial_id.financial_id_other";

        public const string Location = "location";

        public const string LocationLocationAddress = "location.location_address";

        public const string LocationLocationCity = "location.location_city";

        public const string LocationLocationPostalCode = "location.location_postal_code";

        public const string LocationLocationCoordinate = "location.location_coordinate";

        public const string LocationLocationState = "location.location_state";

        public const string LocationLocationCountry = "location.location_country";

        public const string LocationLocationOther = "location.location_other";

        public const string Date = "date";

        public const string DateInterval = "date_interval";

        public const string UniqueId = "unique_id";

        public const string UniqueIdGovernmentIssuedId = "unique_id.government_issued_id";

        public const string UniqueIdAccountNumber = "unique_id.account_number";

        public const string UniqueIdVehicleId = "unique_id.vehicle_id";

        public const string UniqueIdHealthcareNumber = "unique_id.healthcare_number";

        public const string UniqueIdHealthcareNumberMedicalRecordNumber =
            "unique_id.healthcare_number.medical_record_number";

        public const string UniqueIdHealthcareNumberHealthPlanBeneficiaryNumber =
            "unique_id.healthcare_number.health_plan_beneficiary_number";

        public const string UniqueIdDeviceId = "unique_id.device_id";

        public const string UniqueIdUniqueIdOther = "unique_id.unique_id_other";

        public const string Medical = "medical";

        public const string MedicalMedicalCondition = "medical.medical_condition";

        public const string MedicalMedication = "medical.medication";

        public const string MedicalMedicalProcedure = "medical.medical_procedure";

        public const string MedicalMedicalMeasurement = "medical.medical_measurement";

        public const string MedicalMedicalOther = "medical.medical_other";
    }
}
