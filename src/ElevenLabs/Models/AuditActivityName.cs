using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace;

/// <summary>Audit log `activity_name` values that can be stored in a customer workspace's audit log.</summary>
[JsonConverter(typeof(AuditActivityName.AuditActivityNameSerializer))]
[Serializable]
public readonly record struct AuditActivityName : IStringEnum
{
    public static readonly AuditActivityName AccountSecurityChange = new(
        Values.AccountSecurityChange
    );

    public static readonly AuditActivityName AgentsUserMemoryEntityDeleted = new(
        Values.AgentsUserMemoryEntityDeleted
    );

    public static readonly AuditActivityName AgentsUserMemoryErased = new(
        Values.AgentsUserMemoryErased
    );

    public static readonly AuditActivityName AgentsUserMemoryExported = new(
        Values.AgentsUserMemoryExported
    );

    public static readonly AuditActivityName AgentsUserMemoryFactDeleted = new(
        Values.AgentsUserMemoryFactDeleted
    );

    public static readonly AuditActivityName AgentsUserMemoryViewed = new(
        Values.AgentsUserMemoryViewed
    );

    public static readonly AuditActivityName AgentsUserPropertiesReordered = new(
        Values.AgentsUserPropertiesReordered
    );

    public static readonly AuditActivityName AgentsUserPropertyArchived = new(
        Values.AgentsUserPropertyArchived
    );

    public static readonly AuditActivityName AgentsUserPropertyCreated = new(
        Values.AgentsUserPropertyCreated
    );

    public static readonly AuditActivityName AgentsUserPropertyUnarchived = new(
        Values.AgentsUserPropertyUnarchived
    );

    public static readonly AuditActivityName AgentsUserPropertyUpdated = new(
        Values.AgentsUserPropertyUpdated
    );

    public static readonly AuditActivityName ApiKeyCreation = new(Values.ApiKeyCreation);

    public static readonly AuditActivityName ApiKeyDeletion = new(Values.ApiKeyDeletion);

    public static readonly AuditActivityName ApiKeyManagement = new(Values.ApiKeyManagement);

    public static readonly AuditActivityName ApiKeyUpdate = new(Values.ApiKeyUpdate);

    public static readonly AuditActivityName ArchitectMemberSpendLimitsUpdate = new(
        Values.ArchitectMemberSpendLimitsUpdate
    );

    public static readonly AuditActivityName AuthConnectionCreation = new(
        Values.AuthConnectionCreation
    );

    public static readonly AuditActivityName AuthConnectionDeletion = new(
        Values.AuthConnectionDeletion
    );

    public static readonly AuditActivityName AuthConnectionManagement = new(
        Values.AuthConnectionManagement
    );

    public static readonly AuditActivityName AuthConnectionUpdate = new(
        Values.AuthConnectionUpdate
    );

    public static readonly AuditActivityName BillingManagement = new(Values.BillingManagement);

    public static readonly AuditActivityName ChildWorkspaceResourceOverride = new(
        Values.ChildWorkspaceResourceOverride
    );

    public static readonly AuditActivityName ContentGenerationTermsUpdate = new(
        Values.ContentGenerationTermsUpdate
    );

    public static readonly AuditActivityName CreateWorkspaceCustomRole = new(
        Values.CreateWorkspaceCustomRole
    );

    public static readonly AuditActivityName CustomAuthTokenCreated = new(
        Values.CustomAuthTokenCreated
    );

    public static readonly AuditActivityName DataExportRequest = new(Values.DataExportRequest);

    public static readonly AuditActivityName DeleteScribeMeeting = new(Values.DeleteScribeMeeting);

    public static readonly AuditActivityName DeleteWorkspaceCustomRole = new(
        Values.DeleteWorkspaceCustomRole
    );

    public static readonly AuditActivityName DomainVerificationAddition = new(
        Values.DomainVerificationAddition
    );

    public static readonly AuditActivityName DomainVerificationManagement = new(
        Values.DomainVerificationManagement
    );

    public static readonly AuditActivityName DomainVerificationRemoval = new(
        Values.DomainVerificationRemoval
    );

    public static readonly AuditActivityName DomainVerificationStatusUpdate = new(
        Values.DomainVerificationStatusUpdate
    );

    public static readonly AuditActivityName EncryptionKeyDeleted = new(
        Values.EncryptionKeyDeleted
    );

    public static readonly AuditActivityName EncryptionKeyPaused = new(Values.EncryptionKeyPaused);

    public static readonly AuditActivityName EncryptionKeyRegistered = new(
        Values.EncryptionKeyRegistered
    );

    public static readonly AuditActivityName EncryptionKeyUnpaused = new(
        Values.EncryptionKeyUnpaused
    );

    public static readonly AuditActivityName EnterpriseCopyingToggle = new(
        Values.EnterpriseCopyingToggle
    );

    public static readonly AuditActivityName GiftCreditCodeApplied = new(
        Values.GiftCreditCodeApplied
    );

    public static readonly AuditActivityName GroupCreation = new(Values.GroupCreation);

    public static readonly AuditActivityName GroupDeletion = new(Values.GroupDeletion);

    public static readonly AuditActivityName GroupManagement = new(Values.GroupManagement);

    public static readonly AuditActivityName GroupMemberAddition = new(Values.GroupMemberAddition);

    public static readonly AuditActivityName GroupMemberRemoval = new(Values.GroupMemberRemoval);

    public static readonly AuditActivityName GroupToBillingGroupConversion = new(
        Values.GroupToBillingGroupConversion
    );

    public static readonly AuditActivityName GroupUpdate = new(Values.GroupUpdate);

    public static readonly AuditActivityName IdentityProviderUpdate = new(
        Values.IdentityProviderUpdate
    );

    public static readonly AuditActivityName InfluencerCodeApplied = new(
        Values.InfluencerCodeApplied
    );

    public static readonly AuditActivityName InAppTermAcceptance = new(Values.InAppTermAcceptance);

    public static readonly AuditActivityName Logon = new(Values.Logon);

    public static readonly AuditActivityName MfaFactorEnrollment = new(Values.MfaFactorEnrollment);

    public static readonly AuditActivityName MfaFactorEnrollmentRevertedUnverified = new(
        Values.MfaFactorEnrollmentRevertedUnverified
    );

    public static readonly AuditActivityName MfaFactorRemoval = new(Values.MfaFactorRemoval);

    public static readonly AuditActivityName MfaRemovalViaBackupCode = new(
        Values.MfaRemovalViaBackupCode
    );

    public static readonly AuditActivityName ModelApprovalsUpdate = new(
        Values.ModelApprovalsUpdate
    );

    public static readonly AuditActivityName NotificationPreferenceCreation = new(
        Values.NotificationPreferenceCreation
    );

    public static readonly AuditActivityName NotificationPreferenceDeletion = new(
        Values.NotificationPreferenceDeletion
    );

    public static readonly AuditActivityName NotificationPreferenceManagement = new(
        Values.NotificationPreferenceManagement
    );

    public static readonly AuditActivityName NotificationPreferenceUpdate = new(
        Values.NotificationPreferenceUpdate
    );

    public static readonly AuditActivityName PasswordResetEmailRequest = new(
        Values.PasswordResetEmailRequest
    );

    public static readonly AuditActivityName PasswordResetLinkGeneration = new(
        Values.PasswordResetLinkGeneration
    );

    public static readonly AuditActivityName ReportingWorkspaceSsoInheritanceUpdate = new(
        Values.ReportingWorkspaceSsoInheritanceUpdate
    );

    public static readonly AuditActivityName ResourceAccessGranted = new(
        Values.ResourceAccessGranted
    );

    public static readonly AuditActivityName ResourceAccessManagement = new(
        Values.ResourceAccessManagement
    );

    public static readonly AuditActivityName ResourceAccessRevoked = new(
        Values.ResourceAccessRevoked
    );

    public static readonly AuditActivityName ResourceCopiedToWorkspace = new(
        Values.ResourceCopiedToWorkspace
    );

    public static readonly AuditActivityName ResourceLocatorCreation = new(
        Values.ResourceLocatorCreation
    );

    public static readonly AuditActivityName ResourceLocatorDeletion = new(
        Values.ResourceLocatorDeletion
    );

    public static readonly AuditActivityName ResourceLocatorManagement = new(
        Values.ResourceLocatorManagement
    );

    public static readonly AuditActivityName ResourceLocatorUpdate = new(
        Values.ResourceLocatorUpdate
    );

    public static readonly AuditActivityName ResourceOwnershipTransferred = new(
        Values.ResourceOwnershipTransferred
    );

    public static readonly AuditActivityName ScimGroupCreation = new(Values.ScimGroupCreation);

    public static readonly AuditActivityName ScimGroupDeletion = new(Values.ScimGroupDeletion);

    public static readonly AuditActivityName ScimGroupManagement = new(Values.ScimGroupManagement);

    public static readonly AuditActivityName ScimGroupUpdate = new(Values.ScimGroupUpdate);

    public static readonly AuditActivityName ScimProvisioningSeatTypeUpdated = new(
        Values.ScimProvisioningSeatTypeUpdated
    );

    public static readonly AuditActivityName ScimTokenDeleted = new(Values.ScimTokenDeleted);

    public static readonly AuditActivityName ScimTokenGenerated = new(Values.ScimTokenGenerated);

    public static readonly AuditActivityName ScimTokenManagement = new(Values.ScimTokenManagement);

    public static readonly AuditActivityName ScimTokenRotated = new(Values.ScimTokenRotated);

    public static readonly AuditActivityName ScimUserCreation = new(Values.ScimUserCreation);

    public static readonly AuditActivityName ScimUserDeletion = new(Values.ScimUserDeletion);

    public static readonly AuditActivityName ScimUserManagement = new(Values.ScimUserManagement);

    public static readonly AuditActivityName ScimUserUpdate = new(Values.ScimUserUpdate);

    public static readonly AuditActivityName SensitiveActionVerification = new(
        Values.SensitiveActionVerification
    );

    public static readonly AuditActivityName ServiceAccountCreation = new(
        Values.ServiceAccountCreation
    );

    public static readonly AuditActivityName ServiceAccountDeletion = new(
        Values.ServiceAccountDeletion
    );

    public static readonly AuditActivityName ServiceAccountManagement = new(
        Values.ServiceAccountManagement
    );

    public static readonly AuditActivityName ServiceAccountUpdate = new(
        Values.ServiceAccountUpdate
    );

    public static readonly AuditActivityName SharedSsoSiblingWorkspacesUpdate = new(
        Values.SharedSsoSiblingWorkspacesUpdate
    );

    public static readonly AuditActivityName SignInRequestApproval = new(
        Values.SignInRequestApproval
    );

    public static readonly AuditActivityName SignInRequestDecline = new(
        Values.SignInRequestDecline
    );

    public static readonly AuditActivityName SmbFreeTrialActivation = new(
        Values.SmbFreeTrialActivation
    );

    public static readonly AuditActivityName SmbResellerSubscriptionLifecycle = new(
        Values.SmbResellerSubscriptionLifecycle
    );

    public static readonly AuditActivityName SmbResellerTierAssignment = new(
        Values.SmbResellerTierAssignment
    );

    public static readonly AuditActivityName SmbResellerTierChange = new(
        Values.SmbResellerTierChange
    );

    public static readonly AuditActivityName SsoManagement = new(Values.SsoManagement);

    public static readonly AuditActivityName SsoProviderConfiguration = new(
        Values.SsoProviderConfiguration
    );

    public static readonly AuditActivityName SsoProviderRemoval = new(Values.SsoProviderRemoval);

    public static readonly AuditActivityName UpdateWorkspaceCustomRole = new(
        Values.UpdateWorkspaceCustomRole
    );

    public static readonly AuditActivityName UserApiKeyCreation = new(Values.UserApiKeyCreation);

    public static readonly AuditActivityName UserApiKeyDeletion = new(Values.UserApiKeyDeletion);

    public static readonly AuditActivityName UserApiKeyManagement = new(
        Values.UserApiKeyManagement
    );

    public static readonly AuditActivityName UserApiKeyUpdate = new(Values.UserApiKeyUpdate);

    public static readonly AuditActivityName UserAutoProvisioningDisabled = new(
        Values.UserAutoProvisioningDisabled
    );

    public static readonly AuditActivityName UserAutoProvisioningEnabled = new(
        Values.UserAutoProvisioningEnabled
    );

    public static readonly AuditActivityName UserCreation = new(Values.UserCreation);

    public static readonly AuditActivityName UserMetadataUpdate = new(Values.UserMetadataUpdate);

    public static readonly AuditActivityName UserSelfDeletion = new(Values.UserSelfDeletion);

    public static readonly AuditActivityName UserSharingPreferencesUpdate = new(
        Values.UserSharingPreferencesUpdate
    );

    public static readonly AuditActivityName UserSharingPreferencesUpdateAdmin = new(
        Values.UserSharingPreferencesUpdateAdmin
    );

    public static readonly AuditActivityName WebhookCreation = new(Values.WebhookCreation);

    public static readonly AuditActivityName WebhookDeletion = new(Values.WebhookDeletion);

    public static readonly AuditActivityName WebhookManagement = new(Values.WebhookManagement);

    public static readonly AuditActivityName WebhookUpdate = new(Values.WebhookUpdate);

    public static readonly AuditActivityName WorkspaceCreation = new(Values.WorkspaceCreation);

    public static readonly AuditActivityName WorkspaceDeletion = new(Values.WorkspaceDeletion);

    public static readonly AuditActivityName WorkspaceDeletionCancellation = new(
        Values.WorkspaceDeletionCancellation
    );

    public static readonly AuditActivityName WorkspaceInvitationAccepted = new(
        Values.WorkspaceInvitationAccepted
    );

    public static readonly AuditActivityName WorkspaceInvitationDeclined = new(
        Values.WorkspaceInvitationDeclined
    );

    public static readonly AuditActivityName WorkspaceInvitationManagement = new(
        Values.WorkspaceInvitationManagement
    );

    public static readonly AuditActivityName WorkspaceInvitationReminderSent = new(
        Values.WorkspaceInvitationReminderSent
    );

    public static readonly AuditActivityName WorkspaceInvitationRevoked = new(
        Values.WorkspaceInvitationRevoked
    );

    public static readonly AuditActivityName WorkspaceInvitationSent = new(
        Values.WorkspaceInvitationSent
    );

    public static readonly AuditActivityName WorkspaceMemberRemoval = new(
        Values.WorkspaceMemberRemoval
    );

    public static readonly AuditActivityName WorkspaceMemberResourceTransfer = new(
        Values.WorkspaceMemberResourceTransfer
    );

    public static readonly AuditActivityName WorkspaceMemberUpdate = new(
        Values.WorkspaceMemberUpdate
    );

    public static readonly AuditActivityName WorkspaceMemberUsageLimitUpdate = new(
        Values.WorkspaceMemberUsageLimitUpdate
    );

    public static readonly AuditActivityName WorkspaceMetadataUpdate = new(
        Values.WorkspaceMetadataUpdate
    );

    public static readonly AuditActivityName WorkspaceOwnershipTransfer = new(
        Values.WorkspaceOwnershipTransfer
    );

    public static readonly AuditActivityName WorkspaceSignIn = new(Values.WorkspaceSignIn);

    public AuditActivityName(string value)
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
    public static AuditActivityName FromCustom(string value)
    {
        return new AuditActivityName(value);
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

    public static bool operator ==(AuditActivityName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AuditActivityName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AuditActivityName value) => value.Value;

    public static explicit operator AuditActivityName(string value) => new(value);

    internal class AuditActivityNameSerializer : JsonConverter<AuditActivityName>
    {
        public override AuditActivityName Read(
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
            return new AuditActivityName(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuditActivityName value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AuditActivityName ReadAsPropertyName(
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
            return new AuditActivityName(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AuditActivityName value,
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
        public const string AccountSecurityChange = "Account Security Change";

        public const string AgentsUserMemoryEntityDeleted = "Agents User Memory Entity Deleted";

        public const string AgentsUserMemoryErased = "Agents User Memory Erased";

        public const string AgentsUserMemoryExported = "Agents User Memory Exported";

        public const string AgentsUserMemoryFactDeleted = "Agents User Memory Fact Deleted";

        public const string AgentsUserMemoryViewed = "Agents User Memory Viewed";

        public const string AgentsUserPropertiesReordered = "Agents User Properties Reordered";

        public const string AgentsUserPropertyArchived = "Agents User Property Archived";

        public const string AgentsUserPropertyCreated = "Agents User Property Created";

        public const string AgentsUserPropertyUnarchived = "Agents User Property Unarchived";

        public const string AgentsUserPropertyUpdated = "Agents User Property Updated";

        public const string ApiKeyCreation = "API Key Creation";

        public const string ApiKeyDeletion = "API Key Deletion";

        public const string ApiKeyManagement = "API Key Management";

        public const string ApiKeyUpdate = "API Key Update";

        public const string ArchitectMemberSpendLimitsUpdate =
            "Architect Member Spend Limits Update";

        public const string AuthConnectionCreation = "Auth Connection Creation";

        public const string AuthConnectionDeletion = "Auth Connection Deletion";

        public const string AuthConnectionManagement = "Auth Connection Management";

        public const string AuthConnectionUpdate = "Auth Connection Update";

        public const string BillingManagement = "Billing Management";

        public const string ChildWorkspaceResourceOverride = "Child Workspace Resource Override";

        public const string ContentGenerationTermsUpdate = "Content Generation Terms Update";

        public const string CreateWorkspaceCustomRole = "Create workspace custom role";

        public const string CustomAuthTokenCreated = "Custom Auth Token Created";

        public const string DataExportRequest = "Data Export Request";

        public const string DeleteScribeMeeting = "Delete Scribe meeting";

        public const string DeleteWorkspaceCustomRole = "Delete workspace custom role";

        public const string DomainVerificationAddition = "Domain Verification Addition";

        public const string DomainVerificationManagement = "Domain Verification Management";

        public const string DomainVerificationRemoval = "Domain Verification Removal";

        public const string DomainVerificationStatusUpdate = "Domain Verification Status Update";

        public const string EncryptionKeyDeleted = "Encryption Key Deleted";

        public const string EncryptionKeyPaused = "Encryption Key Paused";

        public const string EncryptionKeyRegistered = "Encryption Key Registered";

        public const string EncryptionKeyUnpaused = "Encryption Key Unpaused";

        public const string EnterpriseCopyingToggle = "Enterprise Copying Toggle";

        public const string GiftCreditCodeApplied = "Gift Credit Code Applied";

        public const string GroupCreation = "Group Creation";

        public const string GroupDeletion = "Group Deletion";

        public const string GroupManagement = "Group Management";

        public const string GroupMemberAddition = "Group Member Addition";

        public const string GroupMemberRemoval = "Group Member Removal";

        public const string GroupToBillingGroupConversion = "Group to Billing Group Conversion";

        public const string GroupUpdate = "Group Update";

        public const string IdentityProviderUpdate = "Identity Provider Update";

        public const string InfluencerCodeApplied = "Influencer Code Applied";

        public const string InAppTermAcceptance = "In-App Term Acceptance";

        public const string Logon = "Logon";

        public const string MfaFactorEnrollment = "MFA Factor Enrollment";

        public const string MfaFactorEnrollmentRevertedUnverified =
            "MFA Factor Enrollment Reverted (unverified)";

        public const string MfaFactorRemoval = "MFA Factor Removal";

        public const string MfaRemovalViaBackupCode = "MFA Removal via Backup Code";

        public const string ModelApprovalsUpdate = "Model Approvals Update";

        public const string NotificationPreferenceCreation = "Notification Preference Creation";

        public const string NotificationPreferenceDeletion = "Notification Preference Deletion";

        public const string NotificationPreferenceManagement = "Notification Preference Management";

        public const string NotificationPreferenceUpdate = "Notification Preference Update";

        public const string PasswordResetEmailRequest = "Password Reset Email Request";

        public const string PasswordResetLinkGeneration = "Password Reset Link Generation";

        public const string ReportingWorkspaceSsoInheritanceUpdate =
            "Reporting Workspace SSO Inheritance Update";

        public const string ResourceAccessGranted = "Resource Access Granted";

        public const string ResourceAccessManagement = "Resource Access Management";

        public const string ResourceAccessRevoked = "Resource Access Revoked";

        public const string ResourceCopiedToWorkspace = "Resource Copied to Workspace";

        public const string ResourceLocatorCreation = "Resource Locator Creation";

        public const string ResourceLocatorDeletion = "Resource Locator Deletion";

        public const string ResourceLocatorManagement = "Resource Locator Management";

        public const string ResourceLocatorUpdate = "Resource Locator Update";

        public const string ResourceOwnershipTransferred = "Resource Ownership Transferred";

        public const string ScimGroupCreation = "SCIM Group Creation";

        public const string ScimGroupDeletion = "SCIM Group Deletion";

        public const string ScimGroupManagement = "SCIM Group Management";

        public const string ScimGroupUpdate = "SCIM Group Update";

        public const string ScimProvisioningSeatTypeUpdated = "SCIM Provisioning Seat Type Updated";

        public const string ScimTokenDeleted = "SCIM Token Deleted";

        public const string ScimTokenGenerated = "SCIM Token Generated";

        public const string ScimTokenManagement = "SCIM Token Management";

        public const string ScimTokenRotated = "SCIM Token Rotated";

        public const string ScimUserCreation = "SCIM User Creation";

        public const string ScimUserDeletion = "SCIM User Deletion";

        public const string ScimUserManagement = "SCIM User Management";

        public const string ScimUserUpdate = "SCIM User Update";

        public const string SensitiveActionVerification = "Sensitive Action Verification";

        public const string ServiceAccountCreation = "Service Account Creation";

        public const string ServiceAccountDeletion = "Service Account Deletion";

        public const string ServiceAccountManagement = "Service Account Management";

        public const string ServiceAccountUpdate = "Service Account Update";

        public const string SharedSsoSiblingWorkspacesUpdate =
            "Shared SSO Sibling Workspaces Update";

        public const string SignInRequestApproval = "Sign-In Request Approval";

        public const string SignInRequestDecline = "Sign-In Request Decline";

        public const string SmbFreeTrialActivation = "SMB Free Trial Activation";

        public const string SmbResellerSubscriptionLifecycle =
            "SMB Reseller Subscription Lifecycle";

        public const string SmbResellerTierAssignment = "SMB Reseller Tier Assignment";

        public const string SmbResellerTierChange = "SMB Reseller Tier Change";

        public const string SsoManagement = "SSO Management";

        public const string SsoProviderConfiguration = "SSO Provider Configuration";

        public const string SsoProviderRemoval = "SSO Provider Removal";

        public const string UpdateWorkspaceCustomRole = "Update workspace custom role";

        public const string UserApiKeyCreation = "User API Key Creation";

        public const string UserApiKeyDeletion = "User API Key Deletion";

        public const string UserApiKeyManagement = "User API Key Management";

        public const string UserApiKeyUpdate = "User API Key Update";

        public const string UserAutoProvisioningDisabled = "User Auto-Provisioning Disabled";

        public const string UserAutoProvisioningEnabled = "User Auto-Provisioning Enabled";

        public const string UserCreation = "User Creation";

        public const string UserMetadataUpdate = "User Metadata Update";

        public const string UserSelfDeletion = "User Self-Deletion";

        public const string UserSharingPreferencesUpdate = "User Sharing Preferences Update";

        public const string UserSharingPreferencesUpdateAdmin =
            "User Sharing Preferences Update (Admin)";

        public const string WebhookCreation = "Webhook Creation";

        public const string WebhookDeletion = "Webhook Deletion";

        public const string WebhookManagement = "Webhook Management";

        public const string WebhookUpdate = "Webhook Update";

        public const string WorkspaceCreation = "Workspace Creation";

        public const string WorkspaceDeletion = "Workspace Deletion";

        public const string WorkspaceDeletionCancellation = "Workspace Deletion Cancellation";

        public const string WorkspaceInvitationAccepted = "Workspace Invitation Accepted";

        public const string WorkspaceInvitationDeclined = "Workspace Invitation Declined";

        public const string WorkspaceInvitationManagement = "Workspace Invitation Management";

        public const string WorkspaceInvitationReminderSent = "Workspace Invitation Reminder Sent";

        public const string WorkspaceInvitationRevoked = "Workspace Invitation Revoked";

        public const string WorkspaceInvitationSent = "Workspace Invitation Sent";

        public const string WorkspaceMemberRemoval = "Workspace Member Removal";

        public const string WorkspaceMemberResourceTransfer = "Workspace Member Resource Transfer";

        public const string WorkspaceMemberUpdate = "Workspace Member Update";

        public const string WorkspaceMemberUsageLimitUpdate = "Workspace Member Usage Limit Update";

        public const string WorkspaceMetadataUpdate = "Workspace Metadata Update";

        public const string WorkspaceOwnershipTransfer = "Workspace Ownership Transfer";

        public const string WorkspaceSignIn = "Workspace Sign-In";
    }
}
