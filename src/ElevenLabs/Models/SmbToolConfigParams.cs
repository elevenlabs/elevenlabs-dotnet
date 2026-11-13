// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SmbToolConfigParams.JsonConverter))]
[Serializable]
public record SmbToolConfigParams
{
    internal SmbToolConfigParams(string type, object? value)
    {
        SmbToolType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CancelCalendarEvent"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CancelCalendarEvent value)
    {
        SmbToolType = "cancel_calendar_event";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CancelGroupSessionForAll"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CancelGroupSessionForAll value)
    {
        SmbToolType = "cancel_group_session_for_all";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CancelGroupSessionRegistration"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CancelGroupSessionRegistration value)
    {
        SmbToolType = "cancel_group_session_registration";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CancelOrder"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CancelOrder value)
    {
        SmbToolType = "cancel_order";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CheckServiceAvailability"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CheckServiceAvailability value)
    {
        SmbToolType = "check_service_availability";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateAgentProcedure"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateAgentProcedure value)
    {
        SmbToolType = "create_agent_procedure";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateAgentRule"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateAgentRule value)
    {
        SmbToolType = "create_agent_rule";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateAsset"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateAsset value)
    {
        SmbToolType = "create_asset";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateClient"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateClient value)
    {
        SmbToolType = "create_client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateClientAppointment"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateClientAppointment value)
    {
        SmbToolType = "create_client_appointment";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateClientInteraction"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateClientInteraction value)
    {
        SmbToolType = "create_client_interaction";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateHoliday"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateHoliday value)
    {
        SmbToolType = "create_holiday";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateLocation"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateLocation value)
    {
        SmbToolType = "create_location";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateOrder"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateOrder value)
    {
        SmbToolType = "create_order";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateProduct"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateProduct value)
    {
        SmbToolType = "create_product";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateProductQuoteRequest"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateProductQuoteRequest value)
    {
        SmbToolType = "create_product_quote_request";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateService"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateService value)
    {
        SmbToolType = "create_service";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateServiceQuoteRequest"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateServiceQuoteRequest value)
    {
        SmbToolType = "create_service_quote_request";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateStaff"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateStaff value)
    {
        SmbToolType = "create_staff";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.CreateTransferRule"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.CreateTransferRule value)
    {
        SmbToolType = "create_transfer_rule";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteAgentProcedure"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteAgentProcedure value)
    {
        SmbToolType = "delete_agent_procedure";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteAgentRule"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteAgentRule value)
    {
        SmbToolType = "delete_agent_rule";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteAsset"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteAsset value)
    {
        SmbToolType = "delete_asset";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteCalendarEvent"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteCalendarEvent value)
    {
        SmbToolType = "delete_calendar_event";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteClient"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteClient value)
    {
        SmbToolType = "delete_client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteClientInteraction"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteClientInteraction value)
    {
        SmbToolType = "delete_client_interaction";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteGroupSession"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteGroupSession value)
    {
        SmbToolType = "delete_group_session";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteHoliday"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteHoliday value)
    {
        SmbToolType = "delete_holiday";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteLocation"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteLocation value)
    {
        SmbToolType = "delete_location";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteProduct"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteProduct value)
    {
        SmbToolType = "delete_product";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteService"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteService value)
    {
        SmbToolType = "delete_service";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteStaff"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteStaff value)
    {
        SmbToolType = "delete_staff";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.DeleteTransferRule"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.DeleteTransferRule value)
    {
        SmbToolType = "delete_transfer_rule";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetAgentConfig"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetAgentConfig value)
    {
        SmbToolType = "get_agent_config";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetAnalyticsSummary"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetAnalyticsSummary value)
    {
        SmbToolType = "get_analytics_summary";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetAppointmentByConfirmationNumber"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetAppointmentByConfirmationNumber value)
    {
        SmbToolType = "get_appointment_by_confirmation_number";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetBookingPageSettings"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetBookingPageSettings value)
    {
        SmbToolType = "get_booking_page_settings";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetBookingSlugStatus"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetBookingSlugStatus value)
    {
        SmbToolType = "get_booking_slug_status";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetClientAppointments"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetClientAppointments value)
    {
        SmbToolType = "get_client_appointments";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetClientByPhone"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetClientByPhone value)
    {
        SmbToolType = "get_client_by_phone";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetClientOrders"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetClientOrders value)
    {
        SmbToolType = "get_client_orders";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetOrderByConfirmationNumber"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetOrderByConfirmationNumber value)
    {
        SmbToolType = "get_order_by_confirmation_number";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetSchedule"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetSchedule value)
    {
        SmbToolType = "get_schedule";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.GetWorkspacePlan"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.GetWorkspacePlan value)
    {
        SmbToolType = "get_workspace_plan";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.LeaveMessage"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.LeaveMessage value)
    {
        SmbToolType = "leave_message";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListAgentProcedures"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListAgentProcedures value)
    {
        SmbToolType = "list_agent_procedures";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListAgentReferences"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListAgentReferences value)
    {
        SmbToolType = "list_agent_references";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListAgentRules"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListAgentRules value)
    {
        SmbToolType = "list_agent_rules";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListAssets"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListAssets value)
    {
        SmbToolType = "list_assets";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListCalendarEvents"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListCalendarEvents value)
    {
        SmbToolType = "list_calendar_events";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListClientInteractions"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListClientInteractions value)
    {
        SmbToolType = "list_client_interactions";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListClients"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListClients value)
    {
        SmbToolType = "list_clients";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListCustomerFacingAgents"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListCustomerFacingAgents value)
    {
        SmbToolType = "list_customer_facing_agents";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListGroupSessions"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListGroupSessions value)
    {
        SmbToolType = "list_group_sessions";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListHolidays"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListHolidays value)
    {
        SmbToolType = "list_holidays";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListLocations"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListLocations value)
    {
        SmbToolType = "list_locations";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListProducts"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListProducts value)
    {
        SmbToolType = "list_products";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListServices"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListServices value)
    {
        SmbToolType = "list_services";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListStaff"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListStaff value)
    {
        SmbToolType = "list_staff";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ListTransferRules"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ListTransferRules value)
    {
        SmbToolType = "list_transfer_rules";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OptInSmsReminder"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OptInSmsReminder value)
    {
        SmbToolType = "opt_in_sms_reminder";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OptOutSmsReminder"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OptOutSmsReminder value)
    {
        SmbToolType = "opt_out_sms_reminder";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OwnerGetClientAppointments"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OwnerGetClientAppointments value)
    {
        SmbToolType = "owner_get_client_appointments";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OwnerListAssets"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OwnerListAssets value)
    {
        SmbToolType = "owner_list_assets";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OwnerListLocations"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OwnerListLocations value)
    {
        SmbToolType = "owner_list_locations";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OwnerListProducts"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OwnerListProducts value)
    {
        SmbToolType = "owner_list_products";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OwnerListServices"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OwnerListServices value)
    {
        SmbToolType = "owner_list_services";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.OwnerListStaff"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.OwnerListStaff value)
    {
        SmbToolType = "owner_list_staff";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.RegisterForGroupSession"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.RegisterForGroupSession value)
    {
        SmbToolType = "register_for_group_session";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ReportKnowledgeGap"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ReportKnowledgeGap value)
    {
        SmbToolType = "report_knowledge_gap";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.RestoreCalendarEvent"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.RestoreCalendarEvent value)
    {
        SmbToolType = "restore_calendar_event";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ScheduleGroupSession"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ScheduleGroupSession value)
    {
        SmbToolType = "schedule_group_session";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.SearchClients"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.SearchClients value)
    {
        SmbToolType = "search_clients";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.SendCustomEmail"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.SendCustomEmail value)
    {
        SmbToolType = "send_custom_email";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.SetBookingSlug"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.SetBookingSlug value)
    {
        SmbToolType = "set_booking_slug";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.SubmitBusinessInfo"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.SubmitBusinessInfo value)
    {
        SmbToolType = "submit_business_info";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.TriggerUserVerification"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.TriggerUserVerification value)
    {
        SmbToolType = "trigger_user_verification";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateAgentConfig"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateAgentConfig value)
    {
        SmbToolType = "update_agent_config";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateAgentProcedure"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateAgentProcedure value)
    {
        SmbToolType = "update_agent_procedure";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateAgentRule"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateAgentRule value)
    {
        SmbToolType = "update_agent_rule";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateAsset"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateAsset value)
    {
        SmbToolType = "update_asset";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateBookingPageAppearance"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateBookingPageAppearance value)
    {
        SmbToolType = "update_booking_page_appearance";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateBookingPageSettings"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateBookingPageSettings value)
    {
        SmbToolType = "update_booking_page_settings";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateBusinessInfo"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateBusinessInfo value)
    {
        SmbToolType = "update_business_info";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateCalendarEvent"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateCalendarEvent value)
    {
        SmbToolType = "update_calendar_event";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateClient"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateClient value)
    {
        SmbToolType = "update_client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateGroupSessionSeats"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateGroupSessionSeats value)
    {
        SmbToolType = "update_group_session_seats";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateHoliday"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateHoliday value)
    {
        SmbToolType = "update_holiday";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateLocation"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateLocation value)
    {
        SmbToolType = "update_location";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateOrder"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateOrder value)
    {
        SmbToolType = "update_order";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateProduct"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateProduct value)
    {
        SmbToolType = "update_product";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateService"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateService value)
    {
        SmbToolType = "update_service";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateStaff"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateStaff value)
    {
        SmbToolType = "update_staff";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.UpdateTransferRule"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.UpdateTransferRule value)
    {
        SmbToolType = "update_transfer_rule";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SmbToolConfigParams with <see cref="SmbToolConfigParams.ValidateUserVerificationCode"/>.
    /// </summary>
    public SmbToolConfigParams(SmbToolConfigParams.ValidateUserVerificationCode value)
    {
        SmbToolType = "validate_user_verification_code";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("smb_tool_type")]
    public string SmbToolType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "cancel_calendar_event"
    /// </summary>
    public bool IsCancelCalendarEvent => SmbToolType == "cancel_calendar_event";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "cancel_group_session_for_all"
    /// </summary>
    public bool IsCancelGroupSessionForAll => SmbToolType == "cancel_group_session_for_all";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "cancel_group_session_registration"
    /// </summary>
    public bool IsCancelGroupSessionRegistration =>
        SmbToolType == "cancel_group_session_registration";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "cancel_order"
    /// </summary>
    public bool IsCancelOrder => SmbToolType == "cancel_order";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "check_service_availability"
    /// </summary>
    public bool IsCheckServiceAvailability => SmbToolType == "check_service_availability";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_agent_procedure"
    /// </summary>
    public bool IsCreateAgentProcedure => SmbToolType == "create_agent_procedure";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_agent_rule"
    /// </summary>
    public bool IsCreateAgentRule => SmbToolType == "create_agent_rule";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_asset"
    /// </summary>
    public bool IsCreateAsset => SmbToolType == "create_asset";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_client"
    /// </summary>
    public bool IsCreateClient => SmbToolType == "create_client";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_client_appointment"
    /// </summary>
    public bool IsCreateClientAppointment => SmbToolType == "create_client_appointment";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_client_interaction"
    /// </summary>
    public bool IsCreateClientInteraction => SmbToolType == "create_client_interaction";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_holiday"
    /// </summary>
    public bool IsCreateHoliday => SmbToolType == "create_holiday";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_location"
    /// </summary>
    public bool IsCreateLocation => SmbToolType == "create_location";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_order"
    /// </summary>
    public bool IsCreateOrder => SmbToolType == "create_order";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_product"
    /// </summary>
    public bool IsCreateProduct => SmbToolType == "create_product";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_product_quote_request"
    /// </summary>
    public bool IsCreateProductQuoteRequest => SmbToolType == "create_product_quote_request";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_service"
    /// </summary>
    public bool IsCreateService => SmbToolType == "create_service";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_service_quote_request"
    /// </summary>
    public bool IsCreateServiceQuoteRequest => SmbToolType == "create_service_quote_request";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_staff"
    /// </summary>
    public bool IsCreateStaff => SmbToolType == "create_staff";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "create_transfer_rule"
    /// </summary>
    public bool IsCreateTransferRule => SmbToolType == "create_transfer_rule";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_agent_procedure"
    /// </summary>
    public bool IsDeleteAgentProcedure => SmbToolType == "delete_agent_procedure";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_agent_rule"
    /// </summary>
    public bool IsDeleteAgentRule => SmbToolType == "delete_agent_rule";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_asset"
    /// </summary>
    public bool IsDeleteAsset => SmbToolType == "delete_asset";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_calendar_event"
    /// </summary>
    public bool IsDeleteCalendarEvent => SmbToolType == "delete_calendar_event";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_client"
    /// </summary>
    public bool IsDeleteClient => SmbToolType == "delete_client";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_client_interaction"
    /// </summary>
    public bool IsDeleteClientInteraction => SmbToolType == "delete_client_interaction";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_group_session"
    /// </summary>
    public bool IsDeleteGroupSession => SmbToolType == "delete_group_session";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_holiday"
    /// </summary>
    public bool IsDeleteHoliday => SmbToolType == "delete_holiday";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_location"
    /// </summary>
    public bool IsDeleteLocation => SmbToolType == "delete_location";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_product"
    /// </summary>
    public bool IsDeleteProduct => SmbToolType == "delete_product";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_service"
    /// </summary>
    public bool IsDeleteService => SmbToolType == "delete_service";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_staff"
    /// </summary>
    public bool IsDeleteStaff => SmbToolType == "delete_staff";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "delete_transfer_rule"
    /// </summary>
    public bool IsDeleteTransferRule => SmbToolType == "delete_transfer_rule";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_agent_config"
    /// </summary>
    public bool IsGetAgentConfig => SmbToolType == "get_agent_config";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_analytics_summary"
    /// </summary>
    public bool IsGetAnalyticsSummary => SmbToolType == "get_analytics_summary";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_appointment_by_confirmation_number"
    /// </summary>
    public bool IsGetAppointmentByConfirmationNumber =>
        SmbToolType == "get_appointment_by_confirmation_number";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_booking_page_settings"
    /// </summary>
    public bool IsGetBookingPageSettings => SmbToolType == "get_booking_page_settings";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_booking_slug_status"
    /// </summary>
    public bool IsGetBookingSlugStatus => SmbToolType == "get_booking_slug_status";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_client_appointments"
    /// </summary>
    public bool IsGetClientAppointments => SmbToolType == "get_client_appointments";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_client_by_phone"
    /// </summary>
    public bool IsGetClientByPhone => SmbToolType == "get_client_by_phone";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_client_orders"
    /// </summary>
    public bool IsGetClientOrders => SmbToolType == "get_client_orders";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_order_by_confirmation_number"
    /// </summary>
    public bool IsGetOrderByConfirmationNumber => SmbToolType == "get_order_by_confirmation_number";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_schedule"
    /// </summary>
    public bool IsGetSchedule => SmbToolType == "get_schedule";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "get_workspace_plan"
    /// </summary>
    public bool IsGetWorkspacePlan => SmbToolType == "get_workspace_plan";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "leave_message"
    /// </summary>
    public bool IsLeaveMessage => SmbToolType == "leave_message";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_agent_procedures"
    /// </summary>
    public bool IsListAgentProcedures => SmbToolType == "list_agent_procedures";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_agent_references"
    /// </summary>
    public bool IsListAgentReferences => SmbToolType == "list_agent_references";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_agent_rules"
    /// </summary>
    public bool IsListAgentRules => SmbToolType == "list_agent_rules";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_assets"
    /// </summary>
    public bool IsListAssets => SmbToolType == "list_assets";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_calendar_events"
    /// </summary>
    public bool IsListCalendarEvents => SmbToolType == "list_calendar_events";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_client_interactions"
    /// </summary>
    public bool IsListClientInteractions => SmbToolType == "list_client_interactions";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_clients"
    /// </summary>
    public bool IsListClients => SmbToolType == "list_clients";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_customer_facing_agents"
    /// </summary>
    public bool IsListCustomerFacingAgents => SmbToolType == "list_customer_facing_agents";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_group_sessions"
    /// </summary>
    public bool IsListGroupSessions => SmbToolType == "list_group_sessions";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_holidays"
    /// </summary>
    public bool IsListHolidays => SmbToolType == "list_holidays";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_locations"
    /// </summary>
    public bool IsListLocations => SmbToolType == "list_locations";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_products"
    /// </summary>
    public bool IsListProducts => SmbToolType == "list_products";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_services"
    /// </summary>
    public bool IsListServices => SmbToolType == "list_services";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_staff"
    /// </summary>
    public bool IsListStaff => SmbToolType == "list_staff";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "list_transfer_rules"
    /// </summary>
    public bool IsListTransferRules => SmbToolType == "list_transfer_rules";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "opt_in_sms_reminder"
    /// </summary>
    public bool IsOptInSmsReminder => SmbToolType == "opt_in_sms_reminder";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "opt_out_sms_reminder"
    /// </summary>
    public bool IsOptOutSmsReminder => SmbToolType == "opt_out_sms_reminder";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "owner_get_client_appointments"
    /// </summary>
    public bool IsOwnerGetClientAppointments => SmbToolType == "owner_get_client_appointments";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "owner_list_assets"
    /// </summary>
    public bool IsOwnerListAssets => SmbToolType == "owner_list_assets";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "owner_list_locations"
    /// </summary>
    public bool IsOwnerListLocations => SmbToolType == "owner_list_locations";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "owner_list_products"
    /// </summary>
    public bool IsOwnerListProducts => SmbToolType == "owner_list_products";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "owner_list_services"
    /// </summary>
    public bool IsOwnerListServices => SmbToolType == "owner_list_services";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "owner_list_staff"
    /// </summary>
    public bool IsOwnerListStaff => SmbToolType == "owner_list_staff";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "register_for_group_session"
    /// </summary>
    public bool IsRegisterForGroupSession => SmbToolType == "register_for_group_session";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "report_knowledge_gap"
    /// </summary>
    public bool IsReportKnowledgeGap => SmbToolType == "report_knowledge_gap";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "restore_calendar_event"
    /// </summary>
    public bool IsRestoreCalendarEvent => SmbToolType == "restore_calendar_event";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "schedule_group_session"
    /// </summary>
    public bool IsScheduleGroupSession => SmbToolType == "schedule_group_session";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "search_clients"
    /// </summary>
    public bool IsSearchClients => SmbToolType == "search_clients";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "send_custom_email"
    /// </summary>
    public bool IsSendCustomEmail => SmbToolType == "send_custom_email";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "set_booking_slug"
    /// </summary>
    public bool IsSetBookingSlug => SmbToolType == "set_booking_slug";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "submit_business_info"
    /// </summary>
    public bool IsSubmitBusinessInfo => SmbToolType == "submit_business_info";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "trigger_user_verification"
    /// </summary>
    public bool IsTriggerUserVerification => SmbToolType == "trigger_user_verification";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_agent_config"
    /// </summary>
    public bool IsUpdateAgentConfig => SmbToolType == "update_agent_config";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_agent_procedure"
    /// </summary>
    public bool IsUpdateAgentProcedure => SmbToolType == "update_agent_procedure";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_agent_rule"
    /// </summary>
    public bool IsUpdateAgentRule => SmbToolType == "update_agent_rule";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_asset"
    /// </summary>
    public bool IsUpdateAsset => SmbToolType == "update_asset";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_booking_page_appearance"
    /// </summary>
    public bool IsUpdateBookingPageAppearance => SmbToolType == "update_booking_page_appearance";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_booking_page_settings"
    /// </summary>
    public bool IsUpdateBookingPageSettings => SmbToolType == "update_booking_page_settings";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_business_info"
    /// </summary>
    public bool IsUpdateBusinessInfo => SmbToolType == "update_business_info";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_calendar_event"
    /// </summary>
    public bool IsUpdateCalendarEvent => SmbToolType == "update_calendar_event";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_client"
    /// </summary>
    public bool IsUpdateClient => SmbToolType == "update_client";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_group_session_seats"
    /// </summary>
    public bool IsUpdateGroupSessionSeats => SmbToolType == "update_group_session_seats";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_holiday"
    /// </summary>
    public bool IsUpdateHoliday => SmbToolType == "update_holiday";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_location"
    /// </summary>
    public bool IsUpdateLocation => SmbToolType == "update_location";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_order"
    /// </summary>
    public bool IsUpdateOrder => SmbToolType == "update_order";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_product"
    /// </summary>
    public bool IsUpdateProduct => SmbToolType == "update_product";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_service"
    /// </summary>
    public bool IsUpdateService => SmbToolType == "update_service";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_staff"
    /// </summary>
    public bool IsUpdateStaff => SmbToolType == "update_staff";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "update_transfer_rule"
    /// </summary>
    public bool IsUpdateTransferRule => SmbToolType == "update_transfer_rule";

    /// <summary>
    /// Returns true if <see cref="SmbToolType"/> is "validate_user_verification_code"
    /// </summary>
    public bool IsValidateUserVerificationCode => SmbToolType == "validate_user_verification_code";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CancelCalendarEventParams"/> if <see cref="SmbToolType"/> is 'cancel_calendar_event', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'cancel_calendar_event'.</exception>
    public global::ElevenLabs.CancelCalendarEventParams AsCancelCalendarEvent() =>
        IsCancelCalendarEvent
            ? (global::ElevenLabs.CancelCalendarEventParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'cancel_calendar_event'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CancelGroupSessionForAllParams"/> if <see cref="SmbToolType"/> is 'cancel_group_session_for_all', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'cancel_group_session_for_all'.</exception>
    public global::ElevenLabs.CancelGroupSessionForAllParams AsCancelGroupSessionForAll() =>
        IsCancelGroupSessionForAll
            ? (global::ElevenLabs.CancelGroupSessionForAllParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'cancel_group_session_for_all'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CancelGroupSessionRegistrationParams"/> if <see cref="SmbToolType"/> is 'cancel_group_session_registration', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'cancel_group_session_registration'.</exception>
    public global::ElevenLabs.CancelGroupSessionRegistrationParams AsCancelGroupSessionRegistration() =>
        IsCancelGroupSessionRegistration
            ? (global::ElevenLabs.CancelGroupSessionRegistrationParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'cancel_group_session_registration'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CancelOrderParams"/> if <see cref="SmbToolType"/> is 'cancel_order', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'cancel_order'.</exception>
    public global::ElevenLabs.CancelOrderParams AsCancelOrder() =>
        IsCancelOrder
            ? (global::ElevenLabs.CancelOrderParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'cancel_order'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CheckServiceAvailabilityParams"/> if <see cref="SmbToolType"/> is 'check_service_availability', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'check_service_availability'.</exception>
    public global::ElevenLabs.CheckServiceAvailabilityParams AsCheckServiceAvailability() =>
        IsCheckServiceAvailability
            ? (global::ElevenLabs.CheckServiceAvailabilityParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'check_service_availability'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateAgentProcedureParams"/> if <see cref="SmbToolType"/> is 'create_agent_procedure', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_agent_procedure'.</exception>
    public global::ElevenLabs.CreateAgentProcedureParams AsCreateAgentProcedure() =>
        IsCreateAgentProcedure
            ? (global::ElevenLabs.CreateAgentProcedureParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_agent_procedure'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateAgentRuleParams"/> if <see cref="SmbToolType"/> is 'create_agent_rule', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_agent_rule'.</exception>
    public global::ElevenLabs.CreateAgentRuleParams AsCreateAgentRule() =>
        IsCreateAgentRule
            ? (global::ElevenLabs.CreateAgentRuleParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_agent_rule'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateAssetParams"/> if <see cref="SmbToolType"/> is 'create_asset', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_asset'.</exception>
    public global::ElevenLabs.CreateAssetParams AsCreateAsset() =>
        IsCreateAsset
            ? (global::ElevenLabs.CreateAssetParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_asset'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateClientParams"/> if <see cref="SmbToolType"/> is 'create_client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_client'.</exception>
    public global::ElevenLabs.CreateClientParams AsCreateClient() =>
        IsCreateClient
            ? (global::ElevenLabs.CreateClientParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_client'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateClientAppointmentParams"/> if <see cref="SmbToolType"/> is 'create_client_appointment', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_client_appointment'.</exception>
    public global::ElevenLabs.CreateClientAppointmentParams AsCreateClientAppointment() =>
        IsCreateClientAppointment
            ? (global::ElevenLabs.CreateClientAppointmentParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_client_appointment'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateClientInteractionParams"/> if <see cref="SmbToolType"/> is 'create_client_interaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_client_interaction'.</exception>
    public global::ElevenLabs.CreateClientInteractionParams AsCreateClientInteraction() =>
        IsCreateClientInteraction
            ? (global::ElevenLabs.CreateClientInteractionParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_client_interaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateHolidayParams"/> if <see cref="SmbToolType"/> is 'create_holiday', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_holiday'.</exception>
    public global::ElevenLabs.CreateHolidayParams AsCreateHoliday() =>
        IsCreateHoliday
            ? (global::ElevenLabs.CreateHolidayParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_holiday'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateLocationParams"/> if <see cref="SmbToolType"/> is 'create_location', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_location'.</exception>
    public global::ElevenLabs.CreateLocationParams AsCreateLocation() =>
        IsCreateLocation
            ? (global::ElevenLabs.CreateLocationParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_location'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateOrderParams"/> if <see cref="SmbToolType"/> is 'create_order', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_order'.</exception>
    public global::ElevenLabs.CreateOrderParams AsCreateOrder() =>
        IsCreateOrder
            ? (global::ElevenLabs.CreateOrderParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_order'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateProductParams"/> if <see cref="SmbToolType"/> is 'create_product', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_product'.</exception>
    public global::ElevenLabs.CreateProductParams AsCreateProduct() =>
        IsCreateProduct
            ? (global::ElevenLabs.CreateProductParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_product'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateProductQuoteRequestParams"/> if <see cref="SmbToolType"/> is 'create_product_quote_request', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_product_quote_request'.</exception>
    public global::ElevenLabs.CreateProductQuoteRequestParams AsCreateProductQuoteRequest() =>
        IsCreateProductQuoteRequest
            ? (global::ElevenLabs.CreateProductQuoteRequestParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_product_quote_request'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateServiceParams"/> if <see cref="SmbToolType"/> is 'create_service', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_service'.</exception>
    public global::ElevenLabs.CreateServiceParams AsCreateService() =>
        IsCreateService
            ? (global::ElevenLabs.CreateServiceParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_service'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateServiceQuoteRequestParams"/> if <see cref="SmbToolType"/> is 'create_service_quote_request', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_service_quote_request'.</exception>
    public global::ElevenLabs.CreateServiceQuoteRequestParams AsCreateServiceQuoteRequest() =>
        IsCreateServiceQuoteRequest
            ? (global::ElevenLabs.CreateServiceQuoteRequestParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_service_quote_request'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateStaffParams"/> if <see cref="SmbToolType"/> is 'create_staff', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_staff'.</exception>
    public global::ElevenLabs.CreateStaffParams AsCreateStaff() =>
        IsCreateStaff
            ? (global::ElevenLabs.CreateStaffParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_staff'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreateTransferRuleParams"/> if <see cref="SmbToolType"/> is 'create_transfer_rule', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'create_transfer_rule'.</exception>
    public global::ElevenLabs.CreateTransferRuleParams AsCreateTransferRule() =>
        IsCreateTransferRule
            ? (global::ElevenLabs.CreateTransferRuleParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'create_transfer_rule'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteAgentProcedureParams"/> if <see cref="SmbToolType"/> is 'delete_agent_procedure', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_agent_procedure'.</exception>
    public global::ElevenLabs.DeleteAgentProcedureParams AsDeleteAgentProcedure() =>
        IsDeleteAgentProcedure
            ? (global::ElevenLabs.DeleteAgentProcedureParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_agent_procedure'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteAgentRuleParams"/> if <see cref="SmbToolType"/> is 'delete_agent_rule', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_agent_rule'.</exception>
    public global::ElevenLabs.DeleteAgentRuleParams AsDeleteAgentRule() =>
        IsDeleteAgentRule
            ? (global::ElevenLabs.DeleteAgentRuleParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_agent_rule'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteAssetParams"/> if <see cref="SmbToolType"/> is 'delete_asset', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_asset'.</exception>
    public global::ElevenLabs.DeleteAssetParams AsDeleteAsset() =>
        IsDeleteAsset
            ? (global::ElevenLabs.DeleteAssetParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_asset'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteCalendarEventParams"/> if <see cref="SmbToolType"/> is 'delete_calendar_event', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_calendar_event'.</exception>
    public global::ElevenLabs.DeleteCalendarEventParams AsDeleteCalendarEvent() =>
        IsDeleteCalendarEvent
            ? (global::ElevenLabs.DeleteCalendarEventParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_calendar_event'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteClientParams"/> if <see cref="SmbToolType"/> is 'delete_client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_client'.</exception>
    public global::ElevenLabs.DeleteClientParams AsDeleteClient() =>
        IsDeleteClient
            ? (global::ElevenLabs.DeleteClientParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_client'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteClientInteractionParams"/> if <see cref="SmbToolType"/> is 'delete_client_interaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_client_interaction'.</exception>
    public global::ElevenLabs.DeleteClientInteractionParams AsDeleteClientInteraction() =>
        IsDeleteClientInteraction
            ? (global::ElevenLabs.DeleteClientInteractionParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_client_interaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteGroupSessionParams"/> if <see cref="SmbToolType"/> is 'delete_group_session', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_group_session'.</exception>
    public global::ElevenLabs.DeleteGroupSessionParams AsDeleteGroupSession() =>
        IsDeleteGroupSession
            ? (global::ElevenLabs.DeleteGroupSessionParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_group_session'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteHolidayParams"/> if <see cref="SmbToolType"/> is 'delete_holiday', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_holiday'.</exception>
    public global::ElevenLabs.DeleteHolidayParams AsDeleteHoliday() =>
        IsDeleteHoliday
            ? (global::ElevenLabs.DeleteHolidayParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_holiday'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteLocationParams"/> if <see cref="SmbToolType"/> is 'delete_location', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_location'.</exception>
    public global::ElevenLabs.DeleteLocationParams AsDeleteLocation() =>
        IsDeleteLocation
            ? (global::ElevenLabs.DeleteLocationParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_location'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteProductParams"/> if <see cref="SmbToolType"/> is 'delete_product', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_product'.</exception>
    public global::ElevenLabs.DeleteProductParams AsDeleteProduct() =>
        IsDeleteProduct
            ? (global::ElevenLabs.DeleteProductParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_product'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteServiceParams"/> if <see cref="SmbToolType"/> is 'delete_service', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_service'.</exception>
    public global::ElevenLabs.DeleteServiceParams AsDeleteService() =>
        IsDeleteService
            ? (global::ElevenLabs.DeleteServiceParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_service'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteStaffParams"/> if <see cref="SmbToolType"/> is 'delete_staff', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_staff'.</exception>
    public global::ElevenLabs.DeleteStaffParams AsDeleteStaff() =>
        IsDeleteStaff
            ? (global::ElevenLabs.DeleteStaffParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_staff'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DeleteTransferRuleParams"/> if <see cref="SmbToolType"/> is 'delete_transfer_rule', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'delete_transfer_rule'.</exception>
    public global::ElevenLabs.DeleteTransferRuleParams AsDeleteTransferRule() =>
        IsDeleteTransferRule
            ? (global::ElevenLabs.DeleteTransferRuleParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'delete_transfer_rule'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetAgentConfigParams"/> if <see cref="SmbToolType"/> is 'get_agent_config', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_agent_config'.</exception>
    public global::ElevenLabs.GetAgentConfigParams AsGetAgentConfig() =>
        IsGetAgentConfig
            ? (global::ElevenLabs.GetAgentConfigParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_agent_config'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetAnalyticsSummaryParams"/> if <see cref="SmbToolType"/> is 'get_analytics_summary', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_analytics_summary'.</exception>
    public global::ElevenLabs.GetAnalyticsSummaryParams AsGetAnalyticsSummary() =>
        IsGetAnalyticsSummary
            ? (global::ElevenLabs.GetAnalyticsSummaryParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_analytics_summary'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetAppointmentByConfirmationNumberParams"/> if <see cref="SmbToolType"/> is 'get_appointment_by_confirmation_number', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_appointment_by_confirmation_number'.</exception>
    public global::ElevenLabs.GetAppointmentByConfirmationNumberParams AsGetAppointmentByConfirmationNumber() =>
        IsGetAppointmentByConfirmationNumber
            ? (global::ElevenLabs.GetAppointmentByConfirmationNumberParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_appointment_by_confirmation_number'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetBookingPageSettingsParams"/> if <see cref="SmbToolType"/> is 'get_booking_page_settings', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_booking_page_settings'.</exception>
    public global::ElevenLabs.GetBookingPageSettingsParams AsGetBookingPageSettings() =>
        IsGetBookingPageSettings
            ? (global::ElevenLabs.GetBookingPageSettingsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_booking_page_settings'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetBookingSlugStatusParams"/> if <see cref="SmbToolType"/> is 'get_booking_slug_status', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_booking_slug_status'.</exception>
    public global::ElevenLabs.GetBookingSlugStatusParams AsGetBookingSlugStatus() =>
        IsGetBookingSlugStatus
            ? (global::ElevenLabs.GetBookingSlugStatusParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_booking_slug_status'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetClientAppointmentsParams"/> if <see cref="SmbToolType"/> is 'get_client_appointments', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_client_appointments'.</exception>
    public global::ElevenLabs.GetClientAppointmentsParams AsGetClientAppointments() =>
        IsGetClientAppointments
            ? (global::ElevenLabs.GetClientAppointmentsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_client_appointments'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetClientByPhoneParams"/> if <see cref="SmbToolType"/> is 'get_client_by_phone', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_client_by_phone'.</exception>
    public global::ElevenLabs.GetClientByPhoneParams AsGetClientByPhone() =>
        IsGetClientByPhone
            ? (global::ElevenLabs.GetClientByPhoneParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_client_by_phone'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetClientOrdersParams"/> if <see cref="SmbToolType"/> is 'get_client_orders', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_client_orders'.</exception>
    public global::ElevenLabs.GetClientOrdersParams AsGetClientOrders() =>
        IsGetClientOrders
            ? (global::ElevenLabs.GetClientOrdersParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_client_orders'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetOrderByConfirmationNumberParams"/> if <see cref="SmbToolType"/> is 'get_order_by_confirmation_number', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_order_by_confirmation_number'.</exception>
    public global::ElevenLabs.GetOrderByConfirmationNumberParams AsGetOrderByConfirmationNumber() =>
        IsGetOrderByConfirmationNumber
            ? (global::ElevenLabs.GetOrderByConfirmationNumberParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_order_by_confirmation_number'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetScheduleParams"/> if <see cref="SmbToolType"/> is 'get_schedule', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_schedule'.</exception>
    public global::ElevenLabs.GetScheduleParams AsGetSchedule() =>
        IsGetSchedule
            ? (global::ElevenLabs.GetScheduleParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_schedule'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetWorkspacePlanParams"/> if <see cref="SmbToolType"/> is 'get_workspace_plan', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'get_workspace_plan'.</exception>
    public global::ElevenLabs.GetWorkspacePlanParams AsGetWorkspacePlan() =>
        IsGetWorkspacePlan
            ? (global::ElevenLabs.GetWorkspacePlanParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'get_workspace_plan'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.LeaveMessageParams"/> if <see cref="SmbToolType"/> is 'leave_message', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'leave_message'.</exception>
    public global::ElevenLabs.LeaveMessageParams AsLeaveMessage() =>
        IsLeaveMessage
            ? (global::ElevenLabs.LeaveMessageParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'leave_message'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListAgentProceduresParams"/> if <see cref="SmbToolType"/> is 'list_agent_procedures', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_agent_procedures'.</exception>
    public global::ElevenLabs.ListAgentProceduresParams AsListAgentProcedures() =>
        IsListAgentProcedures
            ? (global::ElevenLabs.ListAgentProceduresParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_agent_procedures'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListAgentReferencesParams"/> if <see cref="SmbToolType"/> is 'list_agent_references', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_agent_references'.</exception>
    public global::ElevenLabs.ListAgentReferencesParams AsListAgentReferences() =>
        IsListAgentReferences
            ? (global::ElevenLabs.ListAgentReferencesParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_agent_references'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListAgentRulesParams"/> if <see cref="SmbToolType"/> is 'list_agent_rules', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_agent_rules'.</exception>
    public global::ElevenLabs.ListAgentRulesParams AsListAgentRules() =>
        IsListAgentRules
            ? (global::ElevenLabs.ListAgentRulesParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_agent_rules'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListAssetsParams"/> if <see cref="SmbToolType"/> is 'list_assets', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_assets'.</exception>
    public global::ElevenLabs.ListAssetsParams AsListAssets() =>
        IsListAssets
            ? (global::ElevenLabs.ListAssetsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_assets'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListCalendarEventsParams"/> if <see cref="SmbToolType"/> is 'list_calendar_events', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_calendar_events'.</exception>
    public global::ElevenLabs.ListCalendarEventsParams AsListCalendarEvents() =>
        IsListCalendarEvents
            ? (global::ElevenLabs.ListCalendarEventsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_calendar_events'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListClientInteractionsParams"/> if <see cref="SmbToolType"/> is 'list_client_interactions', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_client_interactions'.</exception>
    public global::ElevenLabs.ListClientInteractionsParams AsListClientInteractions() =>
        IsListClientInteractions
            ? (global::ElevenLabs.ListClientInteractionsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_client_interactions'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListClientsParams"/> if <see cref="SmbToolType"/> is 'list_clients', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_clients'.</exception>
    public global::ElevenLabs.ListClientsParams AsListClients() =>
        IsListClients
            ? (global::ElevenLabs.ListClientsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_clients'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListCustomerFacingAgentsParams"/> if <see cref="SmbToolType"/> is 'list_customer_facing_agents', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_customer_facing_agents'.</exception>
    public global::ElevenLabs.ListCustomerFacingAgentsParams AsListCustomerFacingAgents() =>
        IsListCustomerFacingAgents
            ? (global::ElevenLabs.ListCustomerFacingAgentsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_customer_facing_agents'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListGroupSessionsParams"/> if <see cref="SmbToolType"/> is 'list_group_sessions', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_group_sessions'.</exception>
    public global::ElevenLabs.ListGroupSessionsParams AsListGroupSessions() =>
        IsListGroupSessions
            ? (global::ElevenLabs.ListGroupSessionsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_group_sessions'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListHolidaysParams"/> if <see cref="SmbToolType"/> is 'list_holidays', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_holidays'.</exception>
    public global::ElevenLabs.ListHolidaysParams AsListHolidays() =>
        IsListHolidays
            ? (global::ElevenLabs.ListHolidaysParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_holidays'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListLocationsParams"/> if <see cref="SmbToolType"/> is 'list_locations', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_locations'.</exception>
    public global::ElevenLabs.ListLocationsParams AsListLocations() =>
        IsListLocations
            ? (global::ElevenLabs.ListLocationsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_locations'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListProductsParams"/> if <see cref="SmbToolType"/> is 'list_products', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_products'.</exception>
    public global::ElevenLabs.ListProductsParams AsListProducts() =>
        IsListProducts
            ? (global::ElevenLabs.ListProductsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_products'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListServicesParams"/> if <see cref="SmbToolType"/> is 'list_services', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_services'.</exception>
    public global::ElevenLabs.ListServicesParams AsListServices() =>
        IsListServices
            ? (global::ElevenLabs.ListServicesParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_services'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListStaffParams"/> if <see cref="SmbToolType"/> is 'list_staff', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_staff'.</exception>
    public global::ElevenLabs.ListStaffParams AsListStaff() =>
        IsListStaff
            ? (global::ElevenLabs.ListStaffParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_staff'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ListTransferRulesParams"/> if <see cref="SmbToolType"/> is 'list_transfer_rules', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'list_transfer_rules'.</exception>
    public global::ElevenLabs.ListTransferRulesParams AsListTransferRules() =>
        IsListTransferRules
            ? (global::ElevenLabs.ListTransferRulesParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'list_transfer_rules'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OptInSmsReminderParams"/> if <see cref="SmbToolType"/> is 'opt_in_sms_reminder', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'opt_in_sms_reminder'.</exception>
    public global::ElevenLabs.OptInSmsReminderParams AsOptInSmsReminder() =>
        IsOptInSmsReminder
            ? (global::ElevenLabs.OptInSmsReminderParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'opt_in_sms_reminder'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OptOutSmsReminderParams"/> if <see cref="SmbToolType"/> is 'opt_out_sms_reminder', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'opt_out_sms_reminder'.</exception>
    public global::ElevenLabs.OptOutSmsReminderParams AsOptOutSmsReminder() =>
        IsOptOutSmsReminder
            ? (global::ElevenLabs.OptOutSmsReminderParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'opt_out_sms_reminder'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OwnerGetClientAppointmentsParams"/> if <see cref="SmbToolType"/> is 'owner_get_client_appointments', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'owner_get_client_appointments'.</exception>
    public global::ElevenLabs.OwnerGetClientAppointmentsParams AsOwnerGetClientAppointments() =>
        IsOwnerGetClientAppointments
            ? (global::ElevenLabs.OwnerGetClientAppointmentsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'owner_get_client_appointments'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OwnerListAssetsParams"/> if <see cref="SmbToolType"/> is 'owner_list_assets', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'owner_list_assets'.</exception>
    public global::ElevenLabs.OwnerListAssetsParams AsOwnerListAssets() =>
        IsOwnerListAssets
            ? (global::ElevenLabs.OwnerListAssetsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'owner_list_assets'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OwnerListLocationsParams"/> if <see cref="SmbToolType"/> is 'owner_list_locations', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'owner_list_locations'.</exception>
    public global::ElevenLabs.OwnerListLocationsParams AsOwnerListLocations() =>
        IsOwnerListLocations
            ? (global::ElevenLabs.OwnerListLocationsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'owner_list_locations'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OwnerListProductsParams"/> if <see cref="SmbToolType"/> is 'owner_list_products', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'owner_list_products'.</exception>
    public global::ElevenLabs.OwnerListProductsParams AsOwnerListProducts() =>
        IsOwnerListProducts
            ? (global::ElevenLabs.OwnerListProductsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'owner_list_products'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OwnerListServicesParams"/> if <see cref="SmbToolType"/> is 'owner_list_services', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'owner_list_services'.</exception>
    public global::ElevenLabs.OwnerListServicesParams AsOwnerListServices() =>
        IsOwnerListServices
            ? (global::ElevenLabs.OwnerListServicesParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'owner_list_services'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OwnerListStaffParams"/> if <see cref="SmbToolType"/> is 'owner_list_staff', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'owner_list_staff'.</exception>
    public global::ElevenLabs.OwnerListStaffParams AsOwnerListStaff() =>
        IsOwnerListStaff
            ? (global::ElevenLabs.OwnerListStaffParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'owner_list_staff'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.RegisterForGroupSessionParams"/> if <see cref="SmbToolType"/> is 'register_for_group_session', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'register_for_group_session'.</exception>
    public global::ElevenLabs.RegisterForGroupSessionParams AsRegisterForGroupSession() =>
        IsRegisterForGroupSession
            ? (global::ElevenLabs.RegisterForGroupSessionParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'register_for_group_session'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ReportKnowledgeGapParams"/> if <see cref="SmbToolType"/> is 'report_knowledge_gap', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'report_knowledge_gap'.</exception>
    public global::ElevenLabs.ReportKnowledgeGapParams AsReportKnowledgeGap() =>
        IsReportKnowledgeGap
            ? (global::ElevenLabs.ReportKnowledgeGapParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'report_knowledge_gap'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.RestoreCalendarEventParams"/> if <see cref="SmbToolType"/> is 'restore_calendar_event', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'restore_calendar_event'.</exception>
    public global::ElevenLabs.RestoreCalendarEventParams AsRestoreCalendarEvent() =>
        IsRestoreCalendarEvent
            ? (global::ElevenLabs.RestoreCalendarEventParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'restore_calendar_event'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ScheduleGroupSessionParams"/> if <see cref="SmbToolType"/> is 'schedule_group_session', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'schedule_group_session'.</exception>
    public global::ElevenLabs.ScheduleGroupSessionParams AsScheduleGroupSession() =>
        IsScheduleGroupSession
            ? (global::ElevenLabs.ScheduleGroupSessionParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'schedule_group_session'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SearchClientsParams"/> if <see cref="SmbToolType"/> is 'search_clients', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'search_clients'.</exception>
    public global::ElevenLabs.SearchClientsParams AsSearchClients() =>
        IsSearchClients
            ? (global::ElevenLabs.SearchClientsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'search_clients'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SendCustomEmailParams"/> if <see cref="SmbToolType"/> is 'send_custom_email', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'send_custom_email'.</exception>
    public global::ElevenLabs.SendCustomEmailParams AsSendCustomEmail() =>
        IsSendCustomEmail
            ? (global::ElevenLabs.SendCustomEmailParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'send_custom_email'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SetBookingSlugParams"/> if <see cref="SmbToolType"/> is 'set_booking_slug', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'set_booking_slug'.</exception>
    public global::ElevenLabs.SetBookingSlugParams AsSetBookingSlug() =>
        IsSetBookingSlug
            ? (global::ElevenLabs.SetBookingSlugParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'set_booking_slug'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubmitBusinessInfoParams"/> if <see cref="SmbToolType"/> is 'submit_business_info', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'submit_business_info'.</exception>
    public global::ElevenLabs.SubmitBusinessInfoParams AsSubmitBusinessInfo() =>
        IsSubmitBusinessInfo
            ? (global::ElevenLabs.SubmitBusinessInfoParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'submit_business_info'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TriggerUserVerificationParams"/> if <see cref="SmbToolType"/> is 'trigger_user_verification', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'trigger_user_verification'.</exception>
    public global::ElevenLabs.TriggerUserVerificationParams AsTriggerUserVerification() =>
        IsTriggerUserVerification
            ? (global::ElevenLabs.TriggerUserVerificationParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'trigger_user_verification'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateAgentConfigParams"/> if <see cref="SmbToolType"/> is 'update_agent_config', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_agent_config'.</exception>
    public global::ElevenLabs.UpdateAgentConfigParams AsUpdateAgentConfig() =>
        IsUpdateAgentConfig
            ? (global::ElevenLabs.UpdateAgentConfigParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_agent_config'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateAgentProcedureParams"/> if <see cref="SmbToolType"/> is 'update_agent_procedure', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_agent_procedure'.</exception>
    public global::ElevenLabs.UpdateAgentProcedureParams AsUpdateAgentProcedure() =>
        IsUpdateAgentProcedure
            ? (global::ElevenLabs.UpdateAgentProcedureParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_agent_procedure'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateAgentRuleParams"/> if <see cref="SmbToolType"/> is 'update_agent_rule', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_agent_rule'.</exception>
    public global::ElevenLabs.UpdateAgentRuleParams AsUpdateAgentRule() =>
        IsUpdateAgentRule
            ? (global::ElevenLabs.UpdateAgentRuleParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_agent_rule'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateAssetParams"/> if <see cref="SmbToolType"/> is 'update_asset', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_asset'.</exception>
    public global::ElevenLabs.UpdateAssetParams AsUpdateAsset() =>
        IsUpdateAsset
            ? (global::ElevenLabs.UpdateAssetParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_asset'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateBookingPageAppearanceParams"/> if <see cref="SmbToolType"/> is 'update_booking_page_appearance', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_booking_page_appearance'.</exception>
    public global::ElevenLabs.UpdateBookingPageAppearanceParams AsUpdateBookingPageAppearance() =>
        IsUpdateBookingPageAppearance
            ? (global::ElevenLabs.UpdateBookingPageAppearanceParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_booking_page_appearance'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateBookingPageSettingsParams"/> if <see cref="SmbToolType"/> is 'update_booking_page_settings', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_booking_page_settings'.</exception>
    public global::ElevenLabs.UpdateBookingPageSettingsParams AsUpdateBookingPageSettings() =>
        IsUpdateBookingPageSettings
            ? (global::ElevenLabs.UpdateBookingPageSettingsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_booking_page_settings'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateBusinessInfoParams"/> if <see cref="SmbToolType"/> is 'update_business_info', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_business_info'.</exception>
    public global::ElevenLabs.UpdateBusinessInfoParams AsUpdateBusinessInfo() =>
        IsUpdateBusinessInfo
            ? (global::ElevenLabs.UpdateBusinessInfoParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_business_info'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateCalendarEventParams"/> if <see cref="SmbToolType"/> is 'update_calendar_event', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_calendar_event'.</exception>
    public global::ElevenLabs.UpdateCalendarEventParams AsUpdateCalendarEvent() =>
        IsUpdateCalendarEvent
            ? (global::ElevenLabs.UpdateCalendarEventParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_calendar_event'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateClientParams"/> if <see cref="SmbToolType"/> is 'update_client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_client'.</exception>
    public global::ElevenLabs.UpdateClientParams AsUpdateClient() =>
        IsUpdateClient
            ? (global::ElevenLabs.UpdateClientParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_client'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateGroupSessionSeatsParams"/> if <see cref="SmbToolType"/> is 'update_group_session_seats', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_group_session_seats'.</exception>
    public global::ElevenLabs.UpdateGroupSessionSeatsParams AsUpdateGroupSessionSeats() =>
        IsUpdateGroupSessionSeats
            ? (global::ElevenLabs.UpdateGroupSessionSeatsParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_group_session_seats'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateHolidayParams"/> if <see cref="SmbToolType"/> is 'update_holiday', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_holiday'.</exception>
    public global::ElevenLabs.UpdateHolidayParams AsUpdateHoliday() =>
        IsUpdateHoliday
            ? (global::ElevenLabs.UpdateHolidayParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_holiday'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateLocationParams"/> if <see cref="SmbToolType"/> is 'update_location', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_location'.</exception>
    public global::ElevenLabs.UpdateLocationParams AsUpdateLocation() =>
        IsUpdateLocation
            ? (global::ElevenLabs.UpdateLocationParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_location'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateOrderParams"/> if <see cref="SmbToolType"/> is 'update_order', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_order'.</exception>
    public global::ElevenLabs.UpdateOrderParams AsUpdateOrder() =>
        IsUpdateOrder
            ? (global::ElevenLabs.UpdateOrderParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_order'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateProductParams"/> if <see cref="SmbToolType"/> is 'update_product', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_product'.</exception>
    public global::ElevenLabs.UpdateProductParams AsUpdateProduct() =>
        IsUpdateProduct
            ? (global::ElevenLabs.UpdateProductParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_product'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateServiceParams"/> if <see cref="SmbToolType"/> is 'update_service', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_service'.</exception>
    public global::ElevenLabs.UpdateServiceParams AsUpdateService() =>
        IsUpdateService
            ? (global::ElevenLabs.UpdateServiceParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_service'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateStaffParams"/> if <see cref="SmbToolType"/> is 'update_staff', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_staff'.</exception>
    public global::ElevenLabs.UpdateStaffParams AsUpdateStaff() =>
        IsUpdateStaff
            ? (global::ElevenLabs.UpdateStaffParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_staff'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UpdateTransferRuleParams"/> if <see cref="SmbToolType"/> is 'update_transfer_rule', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'update_transfer_rule'.</exception>
    public global::ElevenLabs.UpdateTransferRuleParams AsUpdateTransferRule() =>
        IsUpdateTransferRule
            ? (global::ElevenLabs.UpdateTransferRuleParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'update_transfer_rule'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ValidateUserVerificationCodeParams"/> if <see cref="SmbToolType"/> is 'validate_user_verification_code', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SmbToolType"/> is not 'validate_user_verification_code'.</exception>
    public global::ElevenLabs.ValidateUserVerificationCodeParams AsValidateUserVerificationCode() =>
        IsValidateUserVerificationCode
            ? (global::ElevenLabs.ValidateUserVerificationCodeParams)Value!
            : throw new global::System.Exception(
                "SmbToolConfigParams.SmbToolType is not 'validate_user_verification_code'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.CancelCalendarEventParams, T> onCancelCalendarEvent,
        Func<global::ElevenLabs.CancelGroupSessionForAllParams, T> onCancelGroupSessionForAll,
        Func<
            global::ElevenLabs.CancelGroupSessionRegistrationParams,
            T
        > onCancelGroupSessionRegistration,
        Func<global::ElevenLabs.CancelOrderParams, T> onCancelOrder,
        Func<global::ElevenLabs.CheckServiceAvailabilityParams, T> onCheckServiceAvailability,
        Func<global::ElevenLabs.CreateAgentProcedureParams, T> onCreateAgentProcedure,
        Func<global::ElevenLabs.CreateAgentRuleParams, T> onCreateAgentRule,
        Func<global::ElevenLabs.CreateAssetParams, T> onCreateAsset,
        Func<global::ElevenLabs.CreateClientParams, T> onCreateClient,
        Func<global::ElevenLabs.CreateClientAppointmentParams, T> onCreateClientAppointment,
        Func<global::ElevenLabs.CreateClientInteractionParams, T> onCreateClientInteraction,
        Func<global::ElevenLabs.CreateHolidayParams, T> onCreateHoliday,
        Func<global::ElevenLabs.CreateLocationParams, T> onCreateLocation,
        Func<global::ElevenLabs.CreateOrderParams, T> onCreateOrder,
        Func<global::ElevenLabs.CreateProductParams, T> onCreateProduct,
        Func<global::ElevenLabs.CreateProductQuoteRequestParams, T> onCreateProductQuoteRequest,
        Func<global::ElevenLabs.CreateServiceParams, T> onCreateService,
        Func<global::ElevenLabs.CreateServiceQuoteRequestParams, T> onCreateServiceQuoteRequest,
        Func<global::ElevenLabs.CreateStaffParams, T> onCreateStaff,
        Func<global::ElevenLabs.CreateTransferRuleParams, T> onCreateTransferRule,
        Func<global::ElevenLabs.DeleteAgentProcedureParams, T> onDeleteAgentProcedure,
        Func<global::ElevenLabs.DeleteAgentRuleParams, T> onDeleteAgentRule,
        Func<global::ElevenLabs.DeleteAssetParams, T> onDeleteAsset,
        Func<global::ElevenLabs.DeleteCalendarEventParams, T> onDeleteCalendarEvent,
        Func<global::ElevenLabs.DeleteClientParams, T> onDeleteClient,
        Func<global::ElevenLabs.DeleteClientInteractionParams, T> onDeleteClientInteraction,
        Func<global::ElevenLabs.DeleteGroupSessionParams, T> onDeleteGroupSession,
        Func<global::ElevenLabs.DeleteHolidayParams, T> onDeleteHoliday,
        Func<global::ElevenLabs.DeleteLocationParams, T> onDeleteLocation,
        Func<global::ElevenLabs.DeleteProductParams, T> onDeleteProduct,
        Func<global::ElevenLabs.DeleteServiceParams, T> onDeleteService,
        Func<global::ElevenLabs.DeleteStaffParams, T> onDeleteStaff,
        Func<global::ElevenLabs.DeleteTransferRuleParams, T> onDeleteTransferRule,
        Func<global::ElevenLabs.GetAgentConfigParams, T> onGetAgentConfig,
        Func<global::ElevenLabs.GetAnalyticsSummaryParams, T> onGetAnalyticsSummary,
        Func<
            global::ElevenLabs.GetAppointmentByConfirmationNumberParams,
            T
        > onGetAppointmentByConfirmationNumber,
        Func<global::ElevenLabs.GetBookingPageSettingsParams, T> onGetBookingPageSettings,
        Func<global::ElevenLabs.GetBookingSlugStatusParams, T> onGetBookingSlugStatus,
        Func<global::ElevenLabs.GetClientAppointmentsParams, T> onGetClientAppointments,
        Func<global::ElevenLabs.GetClientByPhoneParams, T> onGetClientByPhone,
        Func<global::ElevenLabs.GetClientOrdersParams, T> onGetClientOrders,
        Func<
            global::ElevenLabs.GetOrderByConfirmationNumberParams,
            T
        > onGetOrderByConfirmationNumber,
        Func<global::ElevenLabs.GetScheduleParams, T> onGetSchedule,
        Func<global::ElevenLabs.GetWorkspacePlanParams, T> onGetWorkspacePlan,
        Func<global::ElevenLabs.LeaveMessageParams, T> onLeaveMessage,
        Func<global::ElevenLabs.ListAgentProceduresParams, T> onListAgentProcedures,
        Func<global::ElevenLabs.ListAgentReferencesParams, T> onListAgentReferences,
        Func<global::ElevenLabs.ListAgentRulesParams, T> onListAgentRules,
        Func<global::ElevenLabs.ListAssetsParams, T> onListAssets,
        Func<global::ElevenLabs.ListCalendarEventsParams, T> onListCalendarEvents,
        Func<global::ElevenLabs.ListClientInteractionsParams, T> onListClientInteractions,
        Func<global::ElevenLabs.ListClientsParams, T> onListClients,
        Func<global::ElevenLabs.ListCustomerFacingAgentsParams, T> onListCustomerFacingAgents,
        Func<global::ElevenLabs.ListGroupSessionsParams, T> onListGroupSessions,
        Func<global::ElevenLabs.ListHolidaysParams, T> onListHolidays,
        Func<global::ElevenLabs.ListLocationsParams, T> onListLocations,
        Func<global::ElevenLabs.ListProductsParams, T> onListProducts,
        Func<global::ElevenLabs.ListServicesParams, T> onListServices,
        Func<global::ElevenLabs.ListStaffParams, T> onListStaff,
        Func<global::ElevenLabs.ListTransferRulesParams, T> onListTransferRules,
        Func<global::ElevenLabs.OptInSmsReminderParams, T> onOptInSmsReminder,
        Func<global::ElevenLabs.OptOutSmsReminderParams, T> onOptOutSmsReminder,
        Func<global::ElevenLabs.OwnerGetClientAppointmentsParams, T> onOwnerGetClientAppointments,
        Func<global::ElevenLabs.OwnerListAssetsParams, T> onOwnerListAssets,
        Func<global::ElevenLabs.OwnerListLocationsParams, T> onOwnerListLocations,
        Func<global::ElevenLabs.OwnerListProductsParams, T> onOwnerListProducts,
        Func<global::ElevenLabs.OwnerListServicesParams, T> onOwnerListServices,
        Func<global::ElevenLabs.OwnerListStaffParams, T> onOwnerListStaff,
        Func<global::ElevenLabs.RegisterForGroupSessionParams, T> onRegisterForGroupSession,
        Func<global::ElevenLabs.ReportKnowledgeGapParams, T> onReportKnowledgeGap,
        Func<global::ElevenLabs.RestoreCalendarEventParams, T> onRestoreCalendarEvent,
        Func<global::ElevenLabs.ScheduleGroupSessionParams, T> onScheduleGroupSession,
        Func<global::ElevenLabs.SearchClientsParams, T> onSearchClients,
        Func<global::ElevenLabs.SendCustomEmailParams, T> onSendCustomEmail,
        Func<global::ElevenLabs.SetBookingSlugParams, T> onSetBookingSlug,
        Func<global::ElevenLabs.SubmitBusinessInfoParams, T> onSubmitBusinessInfo,
        Func<global::ElevenLabs.TriggerUserVerificationParams, T> onTriggerUserVerification,
        Func<global::ElevenLabs.UpdateAgentConfigParams, T> onUpdateAgentConfig,
        Func<global::ElevenLabs.UpdateAgentProcedureParams, T> onUpdateAgentProcedure,
        Func<global::ElevenLabs.UpdateAgentRuleParams, T> onUpdateAgentRule,
        Func<global::ElevenLabs.UpdateAssetParams, T> onUpdateAsset,
        Func<global::ElevenLabs.UpdateBookingPageAppearanceParams, T> onUpdateBookingPageAppearance,
        Func<global::ElevenLabs.UpdateBookingPageSettingsParams, T> onUpdateBookingPageSettings,
        Func<global::ElevenLabs.UpdateBusinessInfoParams, T> onUpdateBusinessInfo,
        Func<global::ElevenLabs.UpdateCalendarEventParams, T> onUpdateCalendarEvent,
        Func<global::ElevenLabs.UpdateClientParams, T> onUpdateClient,
        Func<global::ElevenLabs.UpdateGroupSessionSeatsParams, T> onUpdateGroupSessionSeats,
        Func<global::ElevenLabs.UpdateHolidayParams, T> onUpdateHoliday,
        Func<global::ElevenLabs.UpdateLocationParams, T> onUpdateLocation,
        Func<global::ElevenLabs.UpdateOrderParams, T> onUpdateOrder,
        Func<global::ElevenLabs.UpdateProductParams, T> onUpdateProduct,
        Func<global::ElevenLabs.UpdateServiceParams, T> onUpdateService,
        Func<global::ElevenLabs.UpdateStaffParams, T> onUpdateStaff,
        Func<global::ElevenLabs.UpdateTransferRuleParams, T> onUpdateTransferRule,
        Func<
            global::ElevenLabs.ValidateUserVerificationCodeParams,
            T
        > onValidateUserVerificationCode,
        Func<string, object?, T> onUnknown_
    )
    {
        return SmbToolType switch
        {
            "cancel_calendar_event" => onCancelCalendarEvent(AsCancelCalendarEvent()),
            "cancel_group_session_for_all" => onCancelGroupSessionForAll(
                AsCancelGroupSessionForAll()
            ),
            "cancel_group_session_registration" => onCancelGroupSessionRegistration(
                AsCancelGroupSessionRegistration()
            ),
            "cancel_order" => onCancelOrder(AsCancelOrder()),
            "check_service_availability" => onCheckServiceAvailability(
                AsCheckServiceAvailability()
            ),
            "create_agent_procedure" => onCreateAgentProcedure(AsCreateAgentProcedure()),
            "create_agent_rule" => onCreateAgentRule(AsCreateAgentRule()),
            "create_asset" => onCreateAsset(AsCreateAsset()),
            "create_client" => onCreateClient(AsCreateClient()),
            "create_client_appointment" => onCreateClientAppointment(AsCreateClientAppointment()),
            "create_client_interaction" => onCreateClientInteraction(AsCreateClientInteraction()),
            "create_holiday" => onCreateHoliday(AsCreateHoliday()),
            "create_location" => onCreateLocation(AsCreateLocation()),
            "create_order" => onCreateOrder(AsCreateOrder()),
            "create_product" => onCreateProduct(AsCreateProduct()),
            "create_product_quote_request" => onCreateProductQuoteRequest(
                AsCreateProductQuoteRequest()
            ),
            "create_service" => onCreateService(AsCreateService()),
            "create_service_quote_request" => onCreateServiceQuoteRequest(
                AsCreateServiceQuoteRequest()
            ),
            "create_staff" => onCreateStaff(AsCreateStaff()),
            "create_transfer_rule" => onCreateTransferRule(AsCreateTransferRule()),
            "delete_agent_procedure" => onDeleteAgentProcedure(AsDeleteAgentProcedure()),
            "delete_agent_rule" => onDeleteAgentRule(AsDeleteAgentRule()),
            "delete_asset" => onDeleteAsset(AsDeleteAsset()),
            "delete_calendar_event" => onDeleteCalendarEvent(AsDeleteCalendarEvent()),
            "delete_client" => onDeleteClient(AsDeleteClient()),
            "delete_client_interaction" => onDeleteClientInteraction(AsDeleteClientInteraction()),
            "delete_group_session" => onDeleteGroupSession(AsDeleteGroupSession()),
            "delete_holiday" => onDeleteHoliday(AsDeleteHoliday()),
            "delete_location" => onDeleteLocation(AsDeleteLocation()),
            "delete_product" => onDeleteProduct(AsDeleteProduct()),
            "delete_service" => onDeleteService(AsDeleteService()),
            "delete_staff" => onDeleteStaff(AsDeleteStaff()),
            "delete_transfer_rule" => onDeleteTransferRule(AsDeleteTransferRule()),
            "get_agent_config" => onGetAgentConfig(AsGetAgentConfig()),
            "get_analytics_summary" => onGetAnalyticsSummary(AsGetAnalyticsSummary()),
            "get_appointment_by_confirmation_number" => onGetAppointmentByConfirmationNumber(
                AsGetAppointmentByConfirmationNumber()
            ),
            "get_booking_page_settings" => onGetBookingPageSettings(AsGetBookingPageSettings()),
            "get_booking_slug_status" => onGetBookingSlugStatus(AsGetBookingSlugStatus()),
            "get_client_appointments" => onGetClientAppointments(AsGetClientAppointments()),
            "get_client_by_phone" => onGetClientByPhone(AsGetClientByPhone()),
            "get_client_orders" => onGetClientOrders(AsGetClientOrders()),
            "get_order_by_confirmation_number" => onGetOrderByConfirmationNumber(
                AsGetOrderByConfirmationNumber()
            ),
            "get_schedule" => onGetSchedule(AsGetSchedule()),
            "get_workspace_plan" => onGetWorkspacePlan(AsGetWorkspacePlan()),
            "leave_message" => onLeaveMessage(AsLeaveMessage()),
            "list_agent_procedures" => onListAgentProcedures(AsListAgentProcedures()),
            "list_agent_references" => onListAgentReferences(AsListAgentReferences()),
            "list_agent_rules" => onListAgentRules(AsListAgentRules()),
            "list_assets" => onListAssets(AsListAssets()),
            "list_calendar_events" => onListCalendarEvents(AsListCalendarEvents()),
            "list_client_interactions" => onListClientInteractions(AsListClientInteractions()),
            "list_clients" => onListClients(AsListClients()),
            "list_customer_facing_agents" => onListCustomerFacingAgents(
                AsListCustomerFacingAgents()
            ),
            "list_group_sessions" => onListGroupSessions(AsListGroupSessions()),
            "list_holidays" => onListHolidays(AsListHolidays()),
            "list_locations" => onListLocations(AsListLocations()),
            "list_products" => onListProducts(AsListProducts()),
            "list_services" => onListServices(AsListServices()),
            "list_staff" => onListStaff(AsListStaff()),
            "list_transfer_rules" => onListTransferRules(AsListTransferRules()),
            "opt_in_sms_reminder" => onOptInSmsReminder(AsOptInSmsReminder()),
            "opt_out_sms_reminder" => onOptOutSmsReminder(AsOptOutSmsReminder()),
            "owner_get_client_appointments" => onOwnerGetClientAppointments(
                AsOwnerGetClientAppointments()
            ),
            "owner_list_assets" => onOwnerListAssets(AsOwnerListAssets()),
            "owner_list_locations" => onOwnerListLocations(AsOwnerListLocations()),
            "owner_list_products" => onOwnerListProducts(AsOwnerListProducts()),
            "owner_list_services" => onOwnerListServices(AsOwnerListServices()),
            "owner_list_staff" => onOwnerListStaff(AsOwnerListStaff()),
            "register_for_group_session" => onRegisterForGroupSession(AsRegisterForGroupSession()),
            "report_knowledge_gap" => onReportKnowledgeGap(AsReportKnowledgeGap()),
            "restore_calendar_event" => onRestoreCalendarEvent(AsRestoreCalendarEvent()),
            "schedule_group_session" => onScheduleGroupSession(AsScheduleGroupSession()),
            "search_clients" => onSearchClients(AsSearchClients()),
            "send_custom_email" => onSendCustomEmail(AsSendCustomEmail()),
            "set_booking_slug" => onSetBookingSlug(AsSetBookingSlug()),
            "submit_business_info" => onSubmitBusinessInfo(AsSubmitBusinessInfo()),
            "trigger_user_verification" => onTriggerUserVerification(AsTriggerUserVerification()),
            "update_agent_config" => onUpdateAgentConfig(AsUpdateAgentConfig()),
            "update_agent_procedure" => onUpdateAgentProcedure(AsUpdateAgentProcedure()),
            "update_agent_rule" => onUpdateAgentRule(AsUpdateAgentRule()),
            "update_asset" => onUpdateAsset(AsUpdateAsset()),
            "update_booking_page_appearance" => onUpdateBookingPageAppearance(
                AsUpdateBookingPageAppearance()
            ),
            "update_booking_page_settings" => onUpdateBookingPageSettings(
                AsUpdateBookingPageSettings()
            ),
            "update_business_info" => onUpdateBusinessInfo(AsUpdateBusinessInfo()),
            "update_calendar_event" => onUpdateCalendarEvent(AsUpdateCalendarEvent()),
            "update_client" => onUpdateClient(AsUpdateClient()),
            "update_group_session_seats" => onUpdateGroupSessionSeats(AsUpdateGroupSessionSeats()),
            "update_holiday" => onUpdateHoliday(AsUpdateHoliday()),
            "update_location" => onUpdateLocation(AsUpdateLocation()),
            "update_order" => onUpdateOrder(AsUpdateOrder()),
            "update_product" => onUpdateProduct(AsUpdateProduct()),
            "update_service" => onUpdateService(AsUpdateService()),
            "update_staff" => onUpdateStaff(AsUpdateStaff()),
            "update_transfer_rule" => onUpdateTransferRule(AsUpdateTransferRule()),
            "validate_user_verification_code" => onValidateUserVerificationCode(
                AsValidateUserVerificationCode()
            ),
            _ => onUnknown_(SmbToolType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.CancelCalendarEventParams> onCancelCalendarEvent,
        Action<global::ElevenLabs.CancelGroupSessionForAllParams> onCancelGroupSessionForAll,
        Action<global::ElevenLabs.CancelGroupSessionRegistrationParams> onCancelGroupSessionRegistration,
        Action<global::ElevenLabs.CancelOrderParams> onCancelOrder,
        Action<global::ElevenLabs.CheckServiceAvailabilityParams> onCheckServiceAvailability,
        Action<global::ElevenLabs.CreateAgentProcedureParams> onCreateAgentProcedure,
        Action<global::ElevenLabs.CreateAgentRuleParams> onCreateAgentRule,
        Action<global::ElevenLabs.CreateAssetParams> onCreateAsset,
        Action<global::ElevenLabs.CreateClientParams> onCreateClient,
        Action<global::ElevenLabs.CreateClientAppointmentParams> onCreateClientAppointment,
        Action<global::ElevenLabs.CreateClientInteractionParams> onCreateClientInteraction,
        Action<global::ElevenLabs.CreateHolidayParams> onCreateHoliday,
        Action<global::ElevenLabs.CreateLocationParams> onCreateLocation,
        Action<global::ElevenLabs.CreateOrderParams> onCreateOrder,
        Action<global::ElevenLabs.CreateProductParams> onCreateProduct,
        Action<global::ElevenLabs.CreateProductQuoteRequestParams> onCreateProductQuoteRequest,
        Action<global::ElevenLabs.CreateServiceParams> onCreateService,
        Action<global::ElevenLabs.CreateServiceQuoteRequestParams> onCreateServiceQuoteRequest,
        Action<global::ElevenLabs.CreateStaffParams> onCreateStaff,
        Action<global::ElevenLabs.CreateTransferRuleParams> onCreateTransferRule,
        Action<global::ElevenLabs.DeleteAgentProcedureParams> onDeleteAgentProcedure,
        Action<global::ElevenLabs.DeleteAgentRuleParams> onDeleteAgentRule,
        Action<global::ElevenLabs.DeleteAssetParams> onDeleteAsset,
        Action<global::ElevenLabs.DeleteCalendarEventParams> onDeleteCalendarEvent,
        Action<global::ElevenLabs.DeleteClientParams> onDeleteClient,
        Action<global::ElevenLabs.DeleteClientInteractionParams> onDeleteClientInteraction,
        Action<global::ElevenLabs.DeleteGroupSessionParams> onDeleteGroupSession,
        Action<global::ElevenLabs.DeleteHolidayParams> onDeleteHoliday,
        Action<global::ElevenLabs.DeleteLocationParams> onDeleteLocation,
        Action<global::ElevenLabs.DeleteProductParams> onDeleteProduct,
        Action<global::ElevenLabs.DeleteServiceParams> onDeleteService,
        Action<global::ElevenLabs.DeleteStaffParams> onDeleteStaff,
        Action<global::ElevenLabs.DeleteTransferRuleParams> onDeleteTransferRule,
        Action<global::ElevenLabs.GetAgentConfigParams> onGetAgentConfig,
        Action<global::ElevenLabs.GetAnalyticsSummaryParams> onGetAnalyticsSummary,
        Action<global::ElevenLabs.GetAppointmentByConfirmationNumberParams> onGetAppointmentByConfirmationNumber,
        Action<global::ElevenLabs.GetBookingPageSettingsParams> onGetBookingPageSettings,
        Action<global::ElevenLabs.GetBookingSlugStatusParams> onGetBookingSlugStatus,
        Action<global::ElevenLabs.GetClientAppointmentsParams> onGetClientAppointments,
        Action<global::ElevenLabs.GetClientByPhoneParams> onGetClientByPhone,
        Action<global::ElevenLabs.GetClientOrdersParams> onGetClientOrders,
        Action<global::ElevenLabs.GetOrderByConfirmationNumberParams> onGetOrderByConfirmationNumber,
        Action<global::ElevenLabs.GetScheduleParams> onGetSchedule,
        Action<global::ElevenLabs.GetWorkspacePlanParams> onGetWorkspacePlan,
        Action<global::ElevenLabs.LeaveMessageParams> onLeaveMessage,
        Action<global::ElevenLabs.ListAgentProceduresParams> onListAgentProcedures,
        Action<global::ElevenLabs.ListAgentReferencesParams> onListAgentReferences,
        Action<global::ElevenLabs.ListAgentRulesParams> onListAgentRules,
        Action<global::ElevenLabs.ListAssetsParams> onListAssets,
        Action<global::ElevenLabs.ListCalendarEventsParams> onListCalendarEvents,
        Action<global::ElevenLabs.ListClientInteractionsParams> onListClientInteractions,
        Action<global::ElevenLabs.ListClientsParams> onListClients,
        Action<global::ElevenLabs.ListCustomerFacingAgentsParams> onListCustomerFacingAgents,
        Action<global::ElevenLabs.ListGroupSessionsParams> onListGroupSessions,
        Action<global::ElevenLabs.ListHolidaysParams> onListHolidays,
        Action<global::ElevenLabs.ListLocationsParams> onListLocations,
        Action<global::ElevenLabs.ListProductsParams> onListProducts,
        Action<global::ElevenLabs.ListServicesParams> onListServices,
        Action<global::ElevenLabs.ListStaffParams> onListStaff,
        Action<global::ElevenLabs.ListTransferRulesParams> onListTransferRules,
        Action<global::ElevenLabs.OptInSmsReminderParams> onOptInSmsReminder,
        Action<global::ElevenLabs.OptOutSmsReminderParams> onOptOutSmsReminder,
        Action<global::ElevenLabs.OwnerGetClientAppointmentsParams> onOwnerGetClientAppointments,
        Action<global::ElevenLabs.OwnerListAssetsParams> onOwnerListAssets,
        Action<global::ElevenLabs.OwnerListLocationsParams> onOwnerListLocations,
        Action<global::ElevenLabs.OwnerListProductsParams> onOwnerListProducts,
        Action<global::ElevenLabs.OwnerListServicesParams> onOwnerListServices,
        Action<global::ElevenLabs.OwnerListStaffParams> onOwnerListStaff,
        Action<global::ElevenLabs.RegisterForGroupSessionParams> onRegisterForGroupSession,
        Action<global::ElevenLabs.ReportKnowledgeGapParams> onReportKnowledgeGap,
        Action<global::ElevenLabs.RestoreCalendarEventParams> onRestoreCalendarEvent,
        Action<global::ElevenLabs.ScheduleGroupSessionParams> onScheduleGroupSession,
        Action<global::ElevenLabs.SearchClientsParams> onSearchClients,
        Action<global::ElevenLabs.SendCustomEmailParams> onSendCustomEmail,
        Action<global::ElevenLabs.SetBookingSlugParams> onSetBookingSlug,
        Action<global::ElevenLabs.SubmitBusinessInfoParams> onSubmitBusinessInfo,
        Action<global::ElevenLabs.TriggerUserVerificationParams> onTriggerUserVerification,
        Action<global::ElevenLabs.UpdateAgentConfigParams> onUpdateAgentConfig,
        Action<global::ElevenLabs.UpdateAgentProcedureParams> onUpdateAgentProcedure,
        Action<global::ElevenLabs.UpdateAgentRuleParams> onUpdateAgentRule,
        Action<global::ElevenLabs.UpdateAssetParams> onUpdateAsset,
        Action<global::ElevenLabs.UpdateBookingPageAppearanceParams> onUpdateBookingPageAppearance,
        Action<global::ElevenLabs.UpdateBookingPageSettingsParams> onUpdateBookingPageSettings,
        Action<global::ElevenLabs.UpdateBusinessInfoParams> onUpdateBusinessInfo,
        Action<global::ElevenLabs.UpdateCalendarEventParams> onUpdateCalendarEvent,
        Action<global::ElevenLabs.UpdateClientParams> onUpdateClient,
        Action<global::ElevenLabs.UpdateGroupSessionSeatsParams> onUpdateGroupSessionSeats,
        Action<global::ElevenLabs.UpdateHolidayParams> onUpdateHoliday,
        Action<global::ElevenLabs.UpdateLocationParams> onUpdateLocation,
        Action<global::ElevenLabs.UpdateOrderParams> onUpdateOrder,
        Action<global::ElevenLabs.UpdateProductParams> onUpdateProduct,
        Action<global::ElevenLabs.UpdateServiceParams> onUpdateService,
        Action<global::ElevenLabs.UpdateStaffParams> onUpdateStaff,
        Action<global::ElevenLabs.UpdateTransferRuleParams> onUpdateTransferRule,
        Action<global::ElevenLabs.ValidateUserVerificationCodeParams> onValidateUserVerificationCode,
        Action<string, object?> onUnknown_
    )
    {
        switch (SmbToolType)
        {
            case "cancel_calendar_event":
                onCancelCalendarEvent(AsCancelCalendarEvent());
                break;
            case "cancel_group_session_for_all":
                onCancelGroupSessionForAll(AsCancelGroupSessionForAll());
                break;
            case "cancel_group_session_registration":
                onCancelGroupSessionRegistration(AsCancelGroupSessionRegistration());
                break;
            case "cancel_order":
                onCancelOrder(AsCancelOrder());
                break;
            case "check_service_availability":
                onCheckServiceAvailability(AsCheckServiceAvailability());
                break;
            case "create_agent_procedure":
                onCreateAgentProcedure(AsCreateAgentProcedure());
                break;
            case "create_agent_rule":
                onCreateAgentRule(AsCreateAgentRule());
                break;
            case "create_asset":
                onCreateAsset(AsCreateAsset());
                break;
            case "create_client":
                onCreateClient(AsCreateClient());
                break;
            case "create_client_appointment":
                onCreateClientAppointment(AsCreateClientAppointment());
                break;
            case "create_client_interaction":
                onCreateClientInteraction(AsCreateClientInteraction());
                break;
            case "create_holiday":
                onCreateHoliday(AsCreateHoliday());
                break;
            case "create_location":
                onCreateLocation(AsCreateLocation());
                break;
            case "create_order":
                onCreateOrder(AsCreateOrder());
                break;
            case "create_product":
                onCreateProduct(AsCreateProduct());
                break;
            case "create_product_quote_request":
                onCreateProductQuoteRequest(AsCreateProductQuoteRequest());
                break;
            case "create_service":
                onCreateService(AsCreateService());
                break;
            case "create_service_quote_request":
                onCreateServiceQuoteRequest(AsCreateServiceQuoteRequest());
                break;
            case "create_staff":
                onCreateStaff(AsCreateStaff());
                break;
            case "create_transfer_rule":
                onCreateTransferRule(AsCreateTransferRule());
                break;
            case "delete_agent_procedure":
                onDeleteAgentProcedure(AsDeleteAgentProcedure());
                break;
            case "delete_agent_rule":
                onDeleteAgentRule(AsDeleteAgentRule());
                break;
            case "delete_asset":
                onDeleteAsset(AsDeleteAsset());
                break;
            case "delete_calendar_event":
                onDeleteCalendarEvent(AsDeleteCalendarEvent());
                break;
            case "delete_client":
                onDeleteClient(AsDeleteClient());
                break;
            case "delete_client_interaction":
                onDeleteClientInteraction(AsDeleteClientInteraction());
                break;
            case "delete_group_session":
                onDeleteGroupSession(AsDeleteGroupSession());
                break;
            case "delete_holiday":
                onDeleteHoliday(AsDeleteHoliday());
                break;
            case "delete_location":
                onDeleteLocation(AsDeleteLocation());
                break;
            case "delete_product":
                onDeleteProduct(AsDeleteProduct());
                break;
            case "delete_service":
                onDeleteService(AsDeleteService());
                break;
            case "delete_staff":
                onDeleteStaff(AsDeleteStaff());
                break;
            case "delete_transfer_rule":
                onDeleteTransferRule(AsDeleteTransferRule());
                break;
            case "get_agent_config":
                onGetAgentConfig(AsGetAgentConfig());
                break;
            case "get_analytics_summary":
                onGetAnalyticsSummary(AsGetAnalyticsSummary());
                break;
            case "get_appointment_by_confirmation_number":
                onGetAppointmentByConfirmationNumber(AsGetAppointmentByConfirmationNumber());
                break;
            case "get_booking_page_settings":
                onGetBookingPageSettings(AsGetBookingPageSettings());
                break;
            case "get_booking_slug_status":
                onGetBookingSlugStatus(AsGetBookingSlugStatus());
                break;
            case "get_client_appointments":
                onGetClientAppointments(AsGetClientAppointments());
                break;
            case "get_client_by_phone":
                onGetClientByPhone(AsGetClientByPhone());
                break;
            case "get_client_orders":
                onGetClientOrders(AsGetClientOrders());
                break;
            case "get_order_by_confirmation_number":
                onGetOrderByConfirmationNumber(AsGetOrderByConfirmationNumber());
                break;
            case "get_schedule":
                onGetSchedule(AsGetSchedule());
                break;
            case "get_workspace_plan":
                onGetWorkspacePlan(AsGetWorkspacePlan());
                break;
            case "leave_message":
                onLeaveMessage(AsLeaveMessage());
                break;
            case "list_agent_procedures":
                onListAgentProcedures(AsListAgentProcedures());
                break;
            case "list_agent_references":
                onListAgentReferences(AsListAgentReferences());
                break;
            case "list_agent_rules":
                onListAgentRules(AsListAgentRules());
                break;
            case "list_assets":
                onListAssets(AsListAssets());
                break;
            case "list_calendar_events":
                onListCalendarEvents(AsListCalendarEvents());
                break;
            case "list_client_interactions":
                onListClientInteractions(AsListClientInteractions());
                break;
            case "list_clients":
                onListClients(AsListClients());
                break;
            case "list_customer_facing_agents":
                onListCustomerFacingAgents(AsListCustomerFacingAgents());
                break;
            case "list_group_sessions":
                onListGroupSessions(AsListGroupSessions());
                break;
            case "list_holidays":
                onListHolidays(AsListHolidays());
                break;
            case "list_locations":
                onListLocations(AsListLocations());
                break;
            case "list_products":
                onListProducts(AsListProducts());
                break;
            case "list_services":
                onListServices(AsListServices());
                break;
            case "list_staff":
                onListStaff(AsListStaff());
                break;
            case "list_transfer_rules":
                onListTransferRules(AsListTransferRules());
                break;
            case "opt_in_sms_reminder":
                onOptInSmsReminder(AsOptInSmsReminder());
                break;
            case "opt_out_sms_reminder":
                onOptOutSmsReminder(AsOptOutSmsReminder());
                break;
            case "owner_get_client_appointments":
                onOwnerGetClientAppointments(AsOwnerGetClientAppointments());
                break;
            case "owner_list_assets":
                onOwnerListAssets(AsOwnerListAssets());
                break;
            case "owner_list_locations":
                onOwnerListLocations(AsOwnerListLocations());
                break;
            case "owner_list_products":
                onOwnerListProducts(AsOwnerListProducts());
                break;
            case "owner_list_services":
                onOwnerListServices(AsOwnerListServices());
                break;
            case "owner_list_staff":
                onOwnerListStaff(AsOwnerListStaff());
                break;
            case "register_for_group_session":
                onRegisterForGroupSession(AsRegisterForGroupSession());
                break;
            case "report_knowledge_gap":
                onReportKnowledgeGap(AsReportKnowledgeGap());
                break;
            case "restore_calendar_event":
                onRestoreCalendarEvent(AsRestoreCalendarEvent());
                break;
            case "schedule_group_session":
                onScheduleGroupSession(AsScheduleGroupSession());
                break;
            case "search_clients":
                onSearchClients(AsSearchClients());
                break;
            case "send_custom_email":
                onSendCustomEmail(AsSendCustomEmail());
                break;
            case "set_booking_slug":
                onSetBookingSlug(AsSetBookingSlug());
                break;
            case "submit_business_info":
                onSubmitBusinessInfo(AsSubmitBusinessInfo());
                break;
            case "trigger_user_verification":
                onTriggerUserVerification(AsTriggerUserVerification());
                break;
            case "update_agent_config":
                onUpdateAgentConfig(AsUpdateAgentConfig());
                break;
            case "update_agent_procedure":
                onUpdateAgentProcedure(AsUpdateAgentProcedure());
                break;
            case "update_agent_rule":
                onUpdateAgentRule(AsUpdateAgentRule());
                break;
            case "update_asset":
                onUpdateAsset(AsUpdateAsset());
                break;
            case "update_booking_page_appearance":
                onUpdateBookingPageAppearance(AsUpdateBookingPageAppearance());
                break;
            case "update_booking_page_settings":
                onUpdateBookingPageSettings(AsUpdateBookingPageSettings());
                break;
            case "update_business_info":
                onUpdateBusinessInfo(AsUpdateBusinessInfo());
                break;
            case "update_calendar_event":
                onUpdateCalendarEvent(AsUpdateCalendarEvent());
                break;
            case "update_client":
                onUpdateClient(AsUpdateClient());
                break;
            case "update_group_session_seats":
                onUpdateGroupSessionSeats(AsUpdateGroupSessionSeats());
                break;
            case "update_holiday":
                onUpdateHoliday(AsUpdateHoliday());
                break;
            case "update_location":
                onUpdateLocation(AsUpdateLocation());
                break;
            case "update_order":
                onUpdateOrder(AsUpdateOrder());
                break;
            case "update_product":
                onUpdateProduct(AsUpdateProduct());
                break;
            case "update_service":
                onUpdateService(AsUpdateService());
                break;
            case "update_staff":
                onUpdateStaff(AsUpdateStaff());
                break;
            case "update_transfer_rule":
                onUpdateTransferRule(AsUpdateTransferRule());
                break;
            case "validate_user_verification_code":
                onValidateUserVerificationCode(AsValidateUserVerificationCode());
                break;
            default:
                onUnknown_(SmbToolType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CancelCalendarEventParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCancelCalendarEvent(out global::ElevenLabs.CancelCalendarEventParams? value)
    {
        if (SmbToolType == "cancel_calendar_event")
        {
            value = (global::ElevenLabs.CancelCalendarEventParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CancelGroupSessionForAllParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCancelGroupSessionForAll(
        out global::ElevenLabs.CancelGroupSessionForAllParams? value
    )
    {
        if (SmbToolType == "cancel_group_session_for_all")
        {
            value = (global::ElevenLabs.CancelGroupSessionForAllParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CancelGroupSessionRegistrationParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCancelGroupSessionRegistration(
        out global::ElevenLabs.CancelGroupSessionRegistrationParams? value
    )
    {
        if (SmbToolType == "cancel_group_session_registration")
        {
            value = (global::ElevenLabs.CancelGroupSessionRegistrationParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CancelOrderParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCancelOrder(out global::ElevenLabs.CancelOrderParams? value)
    {
        if (SmbToolType == "cancel_order")
        {
            value = (global::ElevenLabs.CancelOrderParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CheckServiceAvailabilityParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCheckServiceAvailability(
        out global::ElevenLabs.CheckServiceAvailabilityParams? value
    )
    {
        if (SmbToolType == "check_service_availability")
        {
            value = (global::ElevenLabs.CheckServiceAvailabilityParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateAgentProcedureParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateAgentProcedure(out global::ElevenLabs.CreateAgentProcedureParams? value)
    {
        if (SmbToolType == "create_agent_procedure")
        {
            value = (global::ElevenLabs.CreateAgentProcedureParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateAgentRuleParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateAgentRule(out global::ElevenLabs.CreateAgentRuleParams? value)
    {
        if (SmbToolType == "create_agent_rule")
        {
            value = (global::ElevenLabs.CreateAgentRuleParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateAssetParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateAsset(out global::ElevenLabs.CreateAssetParams? value)
    {
        if (SmbToolType == "create_asset")
        {
            value = (global::ElevenLabs.CreateAssetParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateClientParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateClient(out global::ElevenLabs.CreateClientParams? value)
    {
        if (SmbToolType == "create_client")
        {
            value = (global::ElevenLabs.CreateClientParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateClientAppointmentParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateClientAppointment(
        out global::ElevenLabs.CreateClientAppointmentParams? value
    )
    {
        if (SmbToolType == "create_client_appointment")
        {
            value = (global::ElevenLabs.CreateClientAppointmentParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateClientInteractionParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateClientInteraction(
        out global::ElevenLabs.CreateClientInteractionParams? value
    )
    {
        if (SmbToolType == "create_client_interaction")
        {
            value = (global::ElevenLabs.CreateClientInteractionParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateHolidayParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateHoliday(out global::ElevenLabs.CreateHolidayParams? value)
    {
        if (SmbToolType == "create_holiday")
        {
            value = (global::ElevenLabs.CreateHolidayParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateLocationParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateLocation(out global::ElevenLabs.CreateLocationParams? value)
    {
        if (SmbToolType == "create_location")
        {
            value = (global::ElevenLabs.CreateLocationParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateOrderParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateOrder(out global::ElevenLabs.CreateOrderParams? value)
    {
        if (SmbToolType == "create_order")
        {
            value = (global::ElevenLabs.CreateOrderParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateProductParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateProduct(out global::ElevenLabs.CreateProductParams? value)
    {
        if (SmbToolType == "create_product")
        {
            value = (global::ElevenLabs.CreateProductParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateProductQuoteRequestParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateProductQuoteRequest(
        out global::ElevenLabs.CreateProductQuoteRequestParams? value
    )
    {
        if (SmbToolType == "create_product_quote_request")
        {
            value = (global::ElevenLabs.CreateProductQuoteRequestParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateServiceParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateService(out global::ElevenLabs.CreateServiceParams? value)
    {
        if (SmbToolType == "create_service")
        {
            value = (global::ElevenLabs.CreateServiceParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateServiceQuoteRequestParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateServiceQuoteRequest(
        out global::ElevenLabs.CreateServiceQuoteRequestParams? value
    )
    {
        if (SmbToolType == "create_service_quote_request")
        {
            value = (global::ElevenLabs.CreateServiceQuoteRequestParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateStaffParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateStaff(out global::ElevenLabs.CreateStaffParams? value)
    {
        if (SmbToolType == "create_staff")
        {
            value = (global::ElevenLabs.CreateStaffParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreateTransferRuleParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreateTransferRule(out global::ElevenLabs.CreateTransferRuleParams? value)
    {
        if (SmbToolType == "create_transfer_rule")
        {
            value = (global::ElevenLabs.CreateTransferRuleParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteAgentProcedureParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteAgentProcedure(out global::ElevenLabs.DeleteAgentProcedureParams? value)
    {
        if (SmbToolType == "delete_agent_procedure")
        {
            value = (global::ElevenLabs.DeleteAgentProcedureParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteAgentRuleParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteAgentRule(out global::ElevenLabs.DeleteAgentRuleParams? value)
    {
        if (SmbToolType == "delete_agent_rule")
        {
            value = (global::ElevenLabs.DeleteAgentRuleParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteAssetParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteAsset(out global::ElevenLabs.DeleteAssetParams? value)
    {
        if (SmbToolType == "delete_asset")
        {
            value = (global::ElevenLabs.DeleteAssetParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteCalendarEventParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteCalendarEvent(out global::ElevenLabs.DeleteCalendarEventParams? value)
    {
        if (SmbToolType == "delete_calendar_event")
        {
            value = (global::ElevenLabs.DeleteCalendarEventParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteClientParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteClient(out global::ElevenLabs.DeleteClientParams? value)
    {
        if (SmbToolType == "delete_client")
        {
            value = (global::ElevenLabs.DeleteClientParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteClientInteractionParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteClientInteraction(
        out global::ElevenLabs.DeleteClientInteractionParams? value
    )
    {
        if (SmbToolType == "delete_client_interaction")
        {
            value = (global::ElevenLabs.DeleteClientInteractionParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteGroupSessionParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteGroupSession(out global::ElevenLabs.DeleteGroupSessionParams? value)
    {
        if (SmbToolType == "delete_group_session")
        {
            value = (global::ElevenLabs.DeleteGroupSessionParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteHolidayParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteHoliday(out global::ElevenLabs.DeleteHolidayParams? value)
    {
        if (SmbToolType == "delete_holiday")
        {
            value = (global::ElevenLabs.DeleteHolidayParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteLocationParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteLocation(out global::ElevenLabs.DeleteLocationParams? value)
    {
        if (SmbToolType == "delete_location")
        {
            value = (global::ElevenLabs.DeleteLocationParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteProductParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteProduct(out global::ElevenLabs.DeleteProductParams? value)
    {
        if (SmbToolType == "delete_product")
        {
            value = (global::ElevenLabs.DeleteProductParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteServiceParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteService(out global::ElevenLabs.DeleteServiceParams? value)
    {
        if (SmbToolType == "delete_service")
        {
            value = (global::ElevenLabs.DeleteServiceParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteStaffParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteStaff(out global::ElevenLabs.DeleteStaffParams? value)
    {
        if (SmbToolType == "delete_staff")
        {
            value = (global::ElevenLabs.DeleteStaffParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DeleteTransferRuleParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeleteTransferRule(out global::ElevenLabs.DeleteTransferRuleParams? value)
    {
        if (SmbToolType == "delete_transfer_rule")
        {
            value = (global::ElevenLabs.DeleteTransferRuleParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetAgentConfigParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetAgentConfig(out global::ElevenLabs.GetAgentConfigParams? value)
    {
        if (SmbToolType == "get_agent_config")
        {
            value = (global::ElevenLabs.GetAgentConfigParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetAnalyticsSummaryParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetAnalyticsSummary(out global::ElevenLabs.GetAnalyticsSummaryParams? value)
    {
        if (SmbToolType == "get_analytics_summary")
        {
            value = (global::ElevenLabs.GetAnalyticsSummaryParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetAppointmentByConfirmationNumberParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetAppointmentByConfirmationNumber(
        out global::ElevenLabs.GetAppointmentByConfirmationNumberParams? value
    )
    {
        if (SmbToolType == "get_appointment_by_confirmation_number")
        {
            value = (global::ElevenLabs.GetAppointmentByConfirmationNumberParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetBookingPageSettingsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetBookingPageSettings(
        out global::ElevenLabs.GetBookingPageSettingsParams? value
    )
    {
        if (SmbToolType == "get_booking_page_settings")
        {
            value = (global::ElevenLabs.GetBookingPageSettingsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetBookingSlugStatusParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetBookingSlugStatus(out global::ElevenLabs.GetBookingSlugStatusParams? value)
    {
        if (SmbToolType == "get_booking_slug_status")
        {
            value = (global::ElevenLabs.GetBookingSlugStatusParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetClientAppointmentsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetClientAppointments(
        out global::ElevenLabs.GetClientAppointmentsParams? value
    )
    {
        if (SmbToolType == "get_client_appointments")
        {
            value = (global::ElevenLabs.GetClientAppointmentsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetClientByPhoneParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetClientByPhone(out global::ElevenLabs.GetClientByPhoneParams? value)
    {
        if (SmbToolType == "get_client_by_phone")
        {
            value = (global::ElevenLabs.GetClientByPhoneParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetClientOrdersParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetClientOrders(out global::ElevenLabs.GetClientOrdersParams? value)
    {
        if (SmbToolType == "get_client_orders")
        {
            value = (global::ElevenLabs.GetClientOrdersParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetOrderByConfirmationNumberParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetOrderByConfirmationNumber(
        out global::ElevenLabs.GetOrderByConfirmationNumberParams? value
    )
    {
        if (SmbToolType == "get_order_by_confirmation_number")
        {
            value = (global::ElevenLabs.GetOrderByConfirmationNumberParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetScheduleParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetSchedule(out global::ElevenLabs.GetScheduleParams? value)
    {
        if (SmbToolType == "get_schedule")
        {
            value = (global::ElevenLabs.GetScheduleParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetWorkspacePlanParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsGetWorkspacePlan(out global::ElevenLabs.GetWorkspacePlanParams? value)
    {
        if (SmbToolType == "get_workspace_plan")
        {
            value = (global::ElevenLabs.GetWorkspacePlanParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.LeaveMessageParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsLeaveMessage(out global::ElevenLabs.LeaveMessageParams? value)
    {
        if (SmbToolType == "leave_message")
        {
            value = (global::ElevenLabs.LeaveMessageParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListAgentProceduresParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListAgentProcedures(out global::ElevenLabs.ListAgentProceduresParams? value)
    {
        if (SmbToolType == "list_agent_procedures")
        {
            value = (global::ElevenLabs.ListAgentProceduresParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListAgentReferencesParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListAgentReferences(out global::ElevenLabs.ListAgentReferencesParams? value)
    {
        if (SmbToolType == "list_agent_references")
        {
            value = (global::ElevenLabs.ListAgentReferencesParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListAgentRulesParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListAgentRules(out global::ElevenLabs.ListAgentRulesParams? value)
    {
        if (SmbToolType == "list_agent_rules")
        {
            value = (global::ElevenLabs.ListAgentRulesParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListAssetsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListAssets(out global::ElevenLabs.ListAssetsParams? value)
    {
        if (SmbToolType == "list_assets")
        {
            value = (global::ElevenLabs.ListAssetsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListCalendarEventsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListCalendarEvents(out global::ElevenLabs.ListCalendarEventsParams? value)
    {
        if (SmbToolType == "list_calendar_events")
        {
            value = (global::ElevenLabs.ListCalendarEventsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListClientInteractionsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListClientInteractions(
        out global::ElevenLabs.ListClientInteractionsParams? value
    )
    {
        if (SmbToolType == "list_client_interactions")
        {
            value = (global::ElevenLabs.ListClientInteractionsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListClientsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListClients(out global::ElevenLabs.ListClientsParams? value)
    {
        if (SmbToolType == "list_clients")
        {
            value = (global::ElevenLabs.ListClientsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListCustomerFacingAgentsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListCustomerFacingAgents(
        out global::ElevenLabs.ListCustomerFacingAgentsParams? value
    )
    {
        if (SmbToolType == "list_customer_facing_agents")
        {
            value = (global::ElevenLabs.ListCustomerFacingAgentsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListGroupSessionsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListGroupSessions(out global::ElevenLabs.ListGroupSessionsParams? value)
    {
        if (SmbToolType == "list_group_sessions")
        {
            value = (global::ElevenLabs.ListGroupSessionsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListHolidaysParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListHolidays(out global::ElevenLabs.ListHolidaysParams? value)
    {
        if (SmbToolType == "list_holidays")
        {
            value = (global::ElevenLabs.ListHolidaysParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListLocationsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListLocations(out global::ElevenLabs.ListLocationsParams? value)
    {
        if (SmbToolType == "list_locations")
        {
            value = (global::ElevenLabs.ListLocationsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListProductsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListProducts(out global::ElevenLabs.ListProductsParams? value)
    {
        if (SmbToolType == "list_products")
        {
            value = (global::ElevenLabs.ListProductsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListServicesParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListServices(out global::ElevenLabs.ListServicesParams? value)
    {
        if (SmbToolType == "list_services")
        {
            value = (global::ElevenLabs.ListServicesParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListStaffParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListStaff(out global::ElevenLabs.ListStaffParams? value)
    {
        if (SmbToolType == "list_staff")
        {
            value = (global::ElevenLabs.ListStaffParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ListTransferRulesParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsListTransferRules(out global::ElevenLabs.ListTransferRulesParams? value)
    {
        if (SmbToolType == "list_transfer_rules")
        {
            value = (global::ElevenLabs.ListTransferRulesParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OptInSmsReminderParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOptInSmsReminder(out global::ElevenLabs.OptInSmsReminderParams? value)
    {
        if (SmbToolType == "opt_in_sms_reminder")
        {
            value = (global::ElevenLabs.OptInSmsReminderParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OptOutSmsReminderParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOptOutSmsReminder(out global::ElevenLabs.OptOutSmsReminderParams? value)
    {
        if (SmbToolType == "opt_out_sms_reminder")
        {
            value = (global::ElevenLabs.OptOutSmsReminderParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OwnerGetClientAppointmentsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOwnerGetClientAppointments(
        out global::ElevenLabs.OwnerGetClientAppointmentsParams? value
    )
    {
        if (SmbToolType == "owner_get_client_appointments")
        {
            value = (global::ElevenLabs.OwnerGetClientAppointmentsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OwnerListAssetsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOwnerListAssets(out global::ElevenLabs.OwnerListAssetsParams? value)
    {
        if (SmbToolType == "owner_list_assets")
        {
            value = (global::ElevenLabs.OwnerListAssetsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OwnerListLocationsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOwnerListLocations(out global::ElevenLabs.OwnerListLocationsParams? value)
    {
        if (SmbToolType == "owner_list_locations")
        {
            value = (global::ElevenLabs.OwnerListLocationsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OwnerListProductsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOwnerListProducts(out global::ElevenLabs.OwnerListProductsParams? value)
    {
        if (SmbToolType == "owner_list_products")
        {
            value = (global::ElevenLabs.OwnerListProductsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OwnerListServicesParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOwnerListServices(out global::ElevenLabs.OwnerListServicesParams? value)
    {
        if (SmbToolType == "owner_list_services")
        {
            value = (global::ElevenLabs.OwnerListServicesParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OwnerListStaffParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsOwnerListStaff(out global::ElevenLabs.OwnerListStaffParams? value)
    {
        if (SmbToolType == "owner_list_staff")
        {
            value = (global::ElevenLabs.OwnerListStaffParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.RegisterForGroupSessionParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsRegisterForGroupSession(
        out global::ElevenLabs.RegisterForGroupSessionParams? value
    )
    {
        if (SmbToolType == "register_for_group_session")
        {
            value = (global::ElevenLabs.RegisterForGroupSessionParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ReportKnowledgeGapParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsReportKnowledgeGap(out global::ElevenLabs.ReportKnowledgeGapParams? value)
    {
        if (SmbToolType == "report_knowledge_gap")
        {
            value = (global::ElevenLabs.ReportKnowledgeGapParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.RestoreCalendarEventParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsRestoreCalendarEvent(out global::ElevenLabs.RestoreCalendarEventParams? value)
    {
        if (SmbToolType == "restore_calendar_event")
        {
            value = (global::ElevenLabs.RestoreCalendarEventParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ScheduleGroupSessionParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsScheduleGroupSession(out global::ElevenLabs.ScheduleGroupSessionParams? value)
    {
        if (SmbToolType == "schedule_group_session")
        {
            value = (global::ElevenLabs.ScheduleGroupSessionParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SearchClientsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsSearchClients(out global::ElevenLabs.SearchClientsParams? value)
    {
        if (SmbToolType == "search_clients")
        {
            value = (global::ElevenLabs.SearchClientsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SendCustomEmailParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsSendCustomEmail(out global::ElevenLabs.SendCustomEmailParams? value)
    {
        if (SmbToolType == "send_custom_email")
        {
            value = (global::ElevenLabs.SendCustomEmailParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SetBookingSlugParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsSetBookingSlug(out global::ElevenLabs.SetBookingSlugParams? value)
    {
        if (SmbToolType == "set_booking_slug")
        {
            value = (global::ElevenLabs.SetBookingSlugParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubmitBusinessInfoParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubmitBusinessInfo(out global::ElevenLabs.SubmitBusinessInfoParams? value)
    {
        if (SmbToolType == "submit_business_info")
        {
            value = (global::ElevenLabs.SubmitBusinessInfoParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TriggerUserVerificationParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsTriggerUserVerification(
        out global::ElevenLabs.TriggerUserVerificationParams? value
    )
    {
        if (SmbToolType == "trigger_user_verification")
        {
            value = (global::ElevenLabs.TriggerUserVerificationParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateAgentConfigParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateAgentConfig(out global::ElevenLabs.UpdateAgentConfigParams? value)
    {
        if (SmbToolType == "update_agent_config")
        {
            value = (global::ElevenLabs.UpdateAgentConfigParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateAgentProcedureParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateAgentProcedure(out global::ElevenLabs.UpdateAgentProcedureParams? value)
    {
        if (SmbToolType == "update_agent_procedure")
        {
            value = (global::ElevenLabs.UpdateAgentProcedureParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateAgentRuleParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateAgentRule(out global::ElevenLabs.UpdateAgentRuleParams? value)
    {
        if (SmbToolType == "update_agent_rule")
        {
            value = (global::ElevenLabs.UpdateAgentRuleParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateAssetParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateAsset(out global::ElevenLabs.UpdateAssetParams? value)
    {
        if (SmbToolType == "update_asset")
        {
            value = (global::ElevenLabs.UpdateAssetParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateBookingPageAppearanceParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateBookingPageAppearance(
        out global::ElevenLabs.UpdateBookingPageAppearanceParams? value
    )
    {
        if (SmbToolType == "update_booking_page_appearance")
        {
            value = (global::ElevenLabs.UpdateBookingPageAppearanceParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateBookingPageSettingsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateBookingPageSettings(
        out global::ElevenLabs.UpdateBookingPageSettingsParams? value
    )
    {
        if (SmbToolType == "update_booking_page_settings")
        {
            value = (global::ElevenLabs.UpdateBookingPageSettingsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateBusinessInfoParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateBusinessInfo(out global::ElevenLabs.UpdateBusinessInfoParams? value)
    {
        if (SmbToolType == "update_business_info")
        {
            value = (global::ElevenLabs.UpdateBusinessInfoParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateCalendarEventParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateCalendarEvent(out global::ElevenLabs.UpdateCalendarEventParams? value)
    {
        if (SmbToolType == "update_calendar_event")
        {
            value = (global::ElevenLabs.UpdateCalendarEventParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateClientParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateClient(out global::ElevenLabs.UpdateClientParams? value)
    {
        if (SmbToolType == "update_client")
        {
            value = (global::ElevenLabs.UpdateClientParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateGroupSessionSeatsParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateGroupSessionSeats(
        out global::ElevenLabs.UpdateGroupSessionSeatsParams? value
    )
    {
        if (SmbToolType == "update_group_session_seats")
        {
            value = (global::ElevenLabs.UpdateGroupSessionSeatsParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateHolidayParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateHoliday(out global::ElevenLabs.UpdateHolidayParams? value)
    {
        if (SmbToolType == "update_holiday")
        {
            value = (global::ElevenLabs.UpdateHolidayParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateLocationParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateLocation(out global::ElevenLabs.UpdateLocationParams? value)
    {
        if (SmbToolType == "update_location")
        {
            value = (global::ElevenLabs.UpdateLocationParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateOrderParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateOrder(out global::ElevenLabs.UpdateOrderParams? value)
    {
        if (SmbToolType == "update_order")
        {
            value = (global::ElevenLabs.UpdateOrderParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateProductParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateProduct(out global::ElevenLabs.UpdateProductParams? value)
    {
        if (SmbToolType == "update_product")
        {
            value = (global::ElevenLabs.UpdateProductParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateServiceParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateService(out global::ElevenLabs.UpdateServiceParams? value)
    {
        if (SmbToolType == "update_service")
        {
            value = (global::ElevenLabs.UpdateServiceParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateStaffParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateStaff(out global::ElevenLabs.UpdateStaffParams? value)
    {
        if (SmbToolType == "update_staff")
        {
            value = (global::ElevenLabs.UpdateStaffParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UpdateTransferRuleParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateTransferRule(out global::ElevenLabs.UpdateTransferRuleParams? value)
    {
        if (SmbToolType == "update_transfer_rule")
        {
            value = (global::ElevenLabs.UpdateTransferRuleParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ValidateUserVerificationCodeParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsValidateUserVerificationCode(
        out global::ElevenLabs.ValidateUserVerificationCodeParams? value
    )
    {
        if (SmbToolType == "validate_user_verification_code")
        {
            value = (global::ElevenLabs.ValidateUserVerificationCodeParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CancelCalendarEvent value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CancelGroupSessionForAll value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CancelGroupSessionRegistration value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CancelOrder value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CheckServiceAvailability value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CreateAgentProcedure value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CreateAgentRule value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateAsset value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateClient value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CreateClientAppointment value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CreateClientInteraction value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateHoliday value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateLocation value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateOrder value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateProduct value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CreateProductQuoteRequest value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateService value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CreateServiceQuoteRequest value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.CreateStaff value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.CreateTransferRule value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.DeleteAgentProcedure value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.DeleteAgentRule value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.DeleteAsset value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.DeleteCalendarEvent value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.DeleteClient value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.DeleteClientInteraction value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.DeleteGroupSession value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.DeleteHoliday value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.DeleteLocation value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.DeleteProduct value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.DeleteService value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.DeleteStaff value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.DeleteTransferRule value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.GetAgentConfig value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetAnalyticsSummary value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetAppointmentByConfirmationNumber value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetBookingPageSettings value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetBookingSlugStatus value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetClientAppointments value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetClientByPhone value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetClientOrders value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetOrderByConfirmationNumber value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.GetSchedule value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.GetWorkspacePlan value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.LeaveMessage value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ListAgentProcedures value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ListAgentReferences value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListAgentRules value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListAssets value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ListCalendarEvents value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ListClientInteractions value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListClients value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ListCustomerFacingAgents value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ListGroupSessions value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListHolidays value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListLocations value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListProducts value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListServices value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.ListStaff value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ListTransferRules value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.OptInSmsReminder value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.OptOutSmsReminder value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.OwnerGetClientAppointments value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.OwnerListAssets value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.OwnerListLocations value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.OwnerListProducts value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.OwnerListServices value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.OwnerListStaff value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.RegisterForGroupSession value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ReportKnowledgeGap value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.RestoreCalendarEvent value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ScheduleGroupSession value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.SearchClients value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.SendCustomEmail value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.SetBookingSlug value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.SubmitBusinessInfo value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.TriggerUserVerification value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateAgentConfig value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateAgentProcedure value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateAgentRule value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateAsset value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateBookingPageAppearance value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateBookingPageSettings value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateBusinessInfo value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateCalendarEvent value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateClient value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateGroupSessionSeats value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateHoliday value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateLocation value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateOrder value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateProduct value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateService value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(SmbToolConfigParams.UpdateStaff value) =>
        new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.UpdateTransferRule value
    ) => new(value);

    public static implicit operator SmbToolConfigParams(
        SmbToolConfigParams.ValidateUserVerificationCode value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SmbToolConfigParams>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SmbToolConfigParams).IsAssignableFrom(typeToConvert);

        public override SmbToolConfigParams Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("smb_tool_type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'smb_tool_type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'smb_tool_type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'smb_tool_type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'smb_tool_type' is null");

            var value = discriminator switch
            {
                "cancel_calendar_event" =>
                    json.Deserialize<global::ElevenLabs.CancelCalendarEventParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CancelCalendarEventParams"
                        ),
                "cancel_group_session_for_all" =>
                    json.Deserialize<global::ElevenLabs.CancelGroupSessionForAllParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CancelGroupSessionForAllParams"
                        ),
                "cancel_group_session_registration" =>
                    json.Deserialize<global::ElevenLabs.CancelGroupSessionRegistrationParams?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CancelGroupSessionRegistrationParams"
                        ),
                "cancel_order" => json.Deserialize<global::ElevenLabs.CancelOrderParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CancelOrderParams"
                    ),
                "check_service_availability" =>
                    json.Deserialize<global::ElevenLabs.CheckServiceAvailabilityParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CheckServiceAvailabilityParams"
                        ),
                "create_agent_procedure" =>
                    json.Deserialize<global::ElevenLabs.CreateAgentProcedureParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateAgentProcedureParams"
                        ),
                "create_agent_rule" => json.Deserialize<global::ElevenLabs.CreateAgentRuleParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateAgentRuleParams"
                    ),
                "create_asset" => json.Deserialize<global::ElevenLabs.CreateAssetParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateAssetParams"
                    ),
                "create_client" => json.Deserialize<global::ElevenLabs.CreateClientParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateClientParams"
                    ),
                "create_client_appointment" =>
                    json.Deserialize<global::ElevenLabs.CreateClientAppointmentParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateClientAppointmentParams"
                        ),
                "create_client_interaction" =>
                    json.Deserialize<global::ElevenLabs.CreateClientInteractionParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateClientInteractionParams"
                        ),
                "create_holiday" => json.Deserialize<global::ElevenLabs.CreateHolidayParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateHolidayParams"
                    ),
                "create_location" => json.Deserialize<global::ElevenLabs.CreateLocationParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateLocationParams"
                    ),
                "create_order" => json.Deserialize<global::ElevenLabs.CreateOrderParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateOrderParams"
                    ),
                "create_product" => json.Deserialize<global::ElevenLabs.CreateProductParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateProductParams"
                    ),
                "create_product_quote_request" =>
                    json.Deserialize<global::ElevenLabs.CreateProductQuoteRequestParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateProductQuoteRequestParams"
                        ),
                "create_service" => json.Deserialize<global::ElevenLabs.CreateServiceParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateServiceParams"
                    ),
                "create_service_quote_request" =>
                    json.Deserialize<global::ElevenLabs.CreateServiceQuoteRequestParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateServiceQuoteRequestParams"
                        ),
                "create_staff" => json.Deserialize<global::ElevenLabs.CreateStaffParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreateStaffParams"
                    ),
                "create_transfer_rule" =>
                    json.Deserialize<global::ElevenLabs.CreateTransferRuleParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CreateTransferRuleParams"
                        ),
                "delete_agent_procedure" =>
                    json.Deserialize<global::ElevenLabs.DeleteAgentProcedureParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DeleteAgentProcedureParams"
                        ),
                "delete_agent_rule" => json.Deserialize<global::ElevenLabs.DeleteAgentRuleParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteAgentRuleParams"
                    ),
                "delete_asset" => json.Deserialize<global::ElevenLabs.DeleteAssetParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteAssetParams"
                    ),
                "delete_calendar_event" =>
                    json.Deserialize<global::ElevenLabs.DeleteCalendarEventParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DeleteCalendarEventParams"
                        ),
                "delete_client" => json.Deserialize<global::ElevenLabs.DeleteClientParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteClientParams"
                    ),
                "delete_client_interaction" =>
                    json.Deserialize<global::ElevenLabs.DeleteClientInteractionParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DeleteClientInteractionParams"
                        ),
                "delete_group_session" =>
                    json.Deserialize<global::ElevenLabs.DeleteGroupSessionParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DeleteGroupSessionParams"
                        ),
                "delete_holiday" => json.Deserialize<global::ElevenLabs.DeleteHolidayParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteHolidayParams"
                    ),
                "delete_location" => json.Deserialize<global::ElevenLabs.DeleteLocationParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteLocationParams"
                    ),
                "delete_product" => json.Deserialize<global::ElevenLabs.DeleteProductParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteProductParams"
                    ),
                "delete_service" => json.Deserialize<global::ElevenLabs.DeleteServiceParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteServiceParams"
                    ),
                "delete_staff" => json.Deserialize<global::ElevenLabs.DeleteStaffParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DeleteStaffParams"
                    ),
                "delete_transfer_rule" =>
                    json.Deserialize<global::ElevenLabs.DeleteTransferRuleParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DeleteTransferRuleParams"
                        ),
                "get_agent_config" => json.Deserialize<global::ElevenLabs.GetAgentConfigParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetAgentConfigParams"
                    ),
                "get_analytics_summary" =>
                    json.Deserialize<global::ElevenLabs.GetAnalyticsSummaryParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetAnalyticsSummaryParams"
                        ),
                "get_appointment_by_confirmation_number" =>
                    json.Deserialize<global::ElevenLabs.GetAppointmentByConfirmationNumberParams?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetAppointmentByConfirmationNumberParams"
                        ),
                "get_booking_page_settings" =>
                    json.Deserialize<global::ElevenLabs.GetBookingPageSettingsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetBookingPageSettingsParams"
                        ),
                "get_booking_slug_status" =>
                    json.Deserialize<global::ElevenLabs.GetBookingSlugStatusParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetBookingSlugStatusParams"
                        ),
                "get_client_appointments" =>
                    json.Deserialize<global::ElevenLabs.GetClientAppointmentsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetClientAppointmentsParams"
                        ),
                "get_client_by_phone" =>
                    json.Deserialize<global::ElevenLabs.GetClientByPhoneParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetClientByPhoneParams"
                        ),
                "get_client_orders" => json.Deserialize<global::ElevenLabs.GetClientOrdersParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetClientOrdersParams"
                    ),
                "get_order_by_confirmation_number" =>
                    json.Deserialize<global::ElevenLabs.GetOrderByConfirmationNumberParams?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetOrderByConfirmationNumberParams"
                        ),
                "get_schedule" => json.Deserialize<global::ElevenLabs.GetScheduleParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetScheduleParams"
                    ),
                "get_workspace_plan" =>
                    json.Deserialize<global::ElevenLabs.GetWorkspacePlanParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetWorkspacePlanParams"
                        ),
                "leave_message" => json.Deserialize<global::ElevenLabs.LeaveMessageParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.LeaveMessageParams"
                    ),
                "list_agent_procedures" =>
                    json.Deserialize<global::ElevenLabs.ListAgentProceduresParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ListAgentProceduresParams"
                        ),
                "list_agent_references" =>
                    json.Deserialize<global::ElevenLabs.ListAgentReferencesParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ListAgentReferencesParams"
                        ),
                "list_agent_rules" => json.Deserialize<global::ElevenLabs.ListAgentRulesParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListAgentRulesParams"
                    ),
                "list_assets" => json.Deserialize<global::ElevenLabs.ListAssetsParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListAssetsParams"
                    ),
                "list_calendar_events" =>
                    json.Deserialize<global::ElevenLabs.ListCalendarEventsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ListCalendarEventsParams"
                        ),
                "list_client_interactions" =>
                    json.Deserialize<global::ElevenLabs.ListClientInteractionsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ListClientInteractionsParams"
                        ),
                "list_clients" => json.Deserialize<global::ElevenLabs.ListClientsParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListClientsParams"
                    ),
                "list_customer_facing_agents" =>
                    json.Deserialize<global::ElevenLabs.ListCustomerFacingAgentsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ListCustomerFacingAgentsParams"
                        ),
                "list_group_sessions" =>
                    json.Deserialize<global::ElevenLabs.ListGroupSessionsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ListGroupSessionsParams"
                        ),
                "list_holidays" => json.Deserialize<global::ElevenLabs.ListHolidaysParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListHolidaysParams"
                    ),
                "list_locations" => json.Deserialize<global::ElevenLabs.ListLocationsParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListLocationsParams"
                    ),
                "list_products" => json.Deserialize<global::ElevenLabs.ListProductsParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListProductsParams"
                    ),
                "list_services" => json.Deserialize<global::ElevenLabs.ListServicesParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListServicesParams"
                    ),
                "list_staff" => json.Deserialize<global::ElevenLabs.ListStaffParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ListStaffParams"
                    ),
                "list_transfer_rules" =>
                    json.Deserialize<global::ElevenLabs.ListTransferRulesParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ListTransferRulesParams"
                        ),
                "opt_in_sms_reminder" =>
                    json.Deserialize<global::ElevenLabs.OptInSmsReminderParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.OptInSmsReminderParams"
                        ),
                "opt_out_sms_reminder" =>
                    json.Deserialize<global::ElevenLabs.OptOutSmsReminderParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.OptOutSmsReminderParams"
                        ),
                "owner_get_client_appointments" =>
                    json.Deserialize<global::ElevenLabs.OwnerGetClientAppointmentsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.OwnerGetClientAppointmentsParams"
                        ),
                "owner_list_assets" => json.Deserialize<global::ElevenLabs.OwnerListAssetsParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.OwnerListAssetsParams"
                    ),
                "owner_list_locations" =>
                    json.Deserialize<global::ElevenLabs.OwnerListLocationsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.OwnerListLocationsParams"
                        ),
                "owner_list_products" =>
                    json.Deserialize<global::ElevenLabs.OwnerListProductsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.OwnerListProductsParams"
                        ),
                "owner_list_services" =>
                    json.Deserialize<global::ElevenLabs.OwnerListServicesParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.OwnerListServicesParams"
                        ),
                "owner_list_staff" => json.Deserialize<global::ElevenLabs.OwnerListStaffParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.OwnerListStaffParams"
                    ),
                "register_for_group_session" =>
                    json.Deserialize<global::ElevenLabs.RegisterForGroupSessionParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.RegisterForGroupSessionParams"
                        ),
                "report_knowledge_gap" =>
                    json.Deserialize<global::ElevenLabs.ReportKnowledgeGapParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ReportKnowledgeGapParams"
                        ),
                "restore_calendar_event" =>
                    json.Deserialize<global::ElevenLabs.RestoreCalendarEventParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.RestoreCalendarEventParams"
                        ),
                "schedule_group_session" =>
                    json.Deserialize<global::ElevenLabs.ScheduleGroupSessionParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ScheduleGroupSessionParams"
                        ),
                "search_clients" => json.Deserialize<global::ElevenLabs.SearchClientsParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SearchClientsParams"
                    ),
                "send_custom_email" => json.Deserialize<global::ElevenLabs.SendCustomEmailParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SendCustomEmailParams"
                    ),
                "set_booking_slug" => json.Deserialize<global::ElevenLabs.SetBookingSlugParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SetBookingSlugParams"
                    ),
                "submit_business_info" =>
                    json.Deserialize<global::ElevenLabs.SubmitBusinessInfoParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubmitBusinessInfoParams"
                        ),
                "trigger_user_verification" =>
                    json.Deserialize<global::ElevenLabs.TriggerUserVerificationParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TriggerUserVerificationParams"
                        ),
                "update_agent_config" =>
                    json.Deserialize<global::ElevenLabs.UpdateAgentConfigParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateAgentConfigParams"
                        ),
                "update_agent_procedure" =>
                    json.Deserialize<global::ElevenLabs.UpdateAgentProcedureParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateAgentProcedureParams"
                        ),
                "update_agent_rule" => json.Deserialize<global::ElevenLabs.UpdateAgentRuleParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateAgentRuleParams"
                    ),
                "update_asset" => json.Deserialize<global::ElevenLabs.UpdateAssetParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateAssetParams"
                    ),
                "update_booking_page_appearance" =>
                    json.Deserialize<global::ElevenLabs.UpdateBookingPageAppearanceParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateBookingPageAppearanceParams"
                        ),
                "update_booking_page_settings" =>
                    json.Deserialize<global::ElevenLabs.UpdateBookingPageSettingsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateBookingPageSettingsParams"
                        ),
                "update_business_info" =>
                    json.Deserialize<global::ElevenLabs.UpdateBusinessInfoParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateBusinessInfoParams"
                        ),
                "update_calendar_event" =>
                    json.Deserialize<global::ElevenLabs.UpdateCalendarEventParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateCalendarEventParams"
                        ),
                "update_client" => json.Deserialize<global::ElevenLabs.UpdateClientParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateClientParams"
                    ),
                "update_group_session_seats" =>
                    json.Deserialize<global::ElevenLabs.UpdateGroupSessionSeatsParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateGroupSessionSeatsParams"
                        ),
                "update_holiday" => json.Deserialize<global::ElevenLabs.UpdateHolidayParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateHolidayParams"
                    ),
                "update_location" => json.Deserialize<global::ElevenLabs.UpdateLocationParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateLocationParams"
                    ),
                "update_order" => json.Deserialize<global::ElevenLabs.UpdateOrderParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateOrderParams"
                    ),
                "update_product" => json.Deserialize<global::ElevenLabs.UpdateProductParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateProductParams"
                    ),
                "update_service" => json.Deserialize<global::ElevenLabs.UpdateServiceParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateServiceParams"
                    ),
                "update_staff" => json.Deserialize<global::ElevenLabs.UpdateStaffParams?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UpdateStaffParams"
                    ),
                "update_transfer_rule" =>
                    json.Deserialize<global::ElevenLabs.UpdateTransferRuleParams?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.UpdateTransferRuleParams"
                        ),
                "validate_user_verification_code" =>
                    json.Deserialize<global::ElevenLabs.ValidateUserVerificationCodeParams?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ValidateUserVerificationCodeParams"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SmbToolConfigParams(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmbToolConfigParams value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.SmbToolType switch
                {
                    "cancel_calendar_event" => JsonSerializer.SerializeToNode(value.Value, options),
                    "cancel_group_session_for_all" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "cancel_group_session_registration" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "cancel_order" => JsonSerializer.SerializeToNode(value.Value, options),
                    "check_service_availability" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "create_agent_procedure" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "create_agent_rule" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_asset" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_client" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_client_appointment" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "create_client_interaction" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "create_holiday" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_location" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_order" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_product" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_product_quote_request" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "create_service" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_service_quote_request" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "create_staff" => JsonSerializer.SerializeToNode(value.Value, options),
                    "create_transfer_rule" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_agent_procedure" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "delete_agent_rule" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_asset" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_calendar_event" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_client" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_client_interaction" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "delete_group_session" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_holiday" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_location" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_product" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_service" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_staff" => JsonSerializer.SerializeToNode(value.Value, options),
                    "delete_transfer_rule" => JsonSerializer.SerializeToNode(value.Value, options),
                    "get_agent_config" => JsonSerializer.SerializeToNode(value.Value, options),
                    "get_analytics_summary" => JsonSerializer.SerializeToNode(value.Value, options),
                    "get_appointment_by_confirmation_number" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "get_booking_page_settings" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "get_booking_slug_status" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "get_client_appointments" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "get_client_by_phone" => JsonSerializer.SerializeToNode(value.Value, options),
                    "get_client_orders" => JsonSerializer.SerializeToNode(value.Value, options),
                    "get_order_by_confirmation_number" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "get_schedule" => JsonSerializer.SerializeToNode(value.Value, options),
                    "get_workspace_plan" => JsonSerializer.SerializeToNode(value.Value, options),
                    "leave_message" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_agent_procedures" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_agent_references" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_agent_rules" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_assets" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_calendar_events" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_client_interactions" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "list_clients" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_customer_facing_agents" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "list_group_sessions" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_holidays" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_locations" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_products" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_services" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_staff" => JsonSerializer.SerializeToNode(value.Value, options),
                    "list_transfer_rules" => JsonSerializer.SerializeToNode(value.Value, options),
                    "opt_in_sms_reminder" => JsonSerializer.SerializeToNode(value.Value, options),
                    "opt_out_sms_reminder" => JsonSerializer.SerializeToNode(value.Value, options),
                    "owner_get_client_appointments" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "owner_list_assets" => JsonSerializer.SerializeToNode(value.Value, options),
                    "owner_list_locations" => JsonSerializer.SerializeToNode(value.Value, options),
                    "owner_list_products" => JsonSerializer.SerializeToNode(value.Value, options),
                    "owner_list_services" => JsonSerializer.SerializeToNode(value.Value, options),
                    "owner_list_staff" => JsonSerializer.SerializeToNode(value.Value, options),
                    "register_for_group_session" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "report_knowledge_gap" => JsonSerializer.SerializeToNode(value.Value, options),
                    "restore_calendar_event" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "schedule_group_session" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "search_clients" => JsonSerializer.SerializeToNode(value.Value, options),
                    "send_custom_email" => JsonSerializer.SerializeToNode(value.Value, options),
                    "set_booking_slug" => JsonSerializer.SerializeToNode(value.Value, options),
                    "submit_business_info" => JsonSerializer.SerializeToNode(value.Value, options),
                    "trigger_user_verification" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "update_agent_config" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_agent_procedure" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "update_agent_rule" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_asset" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_booking_page_appearance" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "update_booking_page_settings" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "update_business_info" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_calendar_event" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_client" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_group_session_seats" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "update_holiday" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_location" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_order" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_product" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_service" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_staff" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_transfer_rule" => JsonSerializer.SerializeToNode(value.Value, options),
                    "validate_user_verification_code" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["smb_tool_type"] = value.SmbToolType;
            json.WriteTo(writer, options);
        }

        public override SmbToolConfigParams ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SmbToolConfigParams(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmbToolConfigParams value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.SmbToolType);
        }
    }

    /// <summary>
    /// Discriminated union type for cancel_calendar_event
    /// </summary>
    [Serializable]
    public struct CancelCalendarEvent
    {
        public CancelCalendarEvent(global::ElevenLabs.CancelCalendarEventParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CancelCalendarEventParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CancelCalendarEvent(
            global::ElevenLabs.CancelCalendarEventParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for cancel_group_session_for_all
    /// </summary>
    [Serializable]
    public struct CancelGroupSessionForAll
    {
        public CancelGroupSessionForAll(global::ElevenLabs.CancelGroupSessionForAllParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CancelGroupSessionForAllParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CancelGroupSessionForAll(
            global::ElevenLabs.CancelGroupSessionForAllParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for cancel_group_session_registration
    /// </summary>
    [Serializable]
    public struct CancelGroupSessionRegistration
    {
        public CancelGroupSessionRegistration(
            global::ElevenLabs.CancelGroupSessionRegistrationParams value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.CancelGroupSessionRegistrationParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CancelGroupSessionRegistration(
            global::ElevenLabs.CancelGroupSessionRegistrationParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for cancel_order
    /// </summary>
    [Serializable]
    public struct CancelOrder
    {
        public CancelOrder(global::ElevenLabs.CancelOrderParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CancelOrderParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CancelOrder(
            global::ElevenLabs.CancelOrderParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for check_service_availability
    /// </summary>
    [Serializable]
    public struct CheckServiceAvailability
    {
        public CheckServiceAvailability(global::ElevenLabs.CheckServiceAvailabilityParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CheckServiceAvailabilityParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CheckServiceAvailability(
            global::ElevenLabs.CheckServiceAvailabilityParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_agent_procedure
    /// </summary>
    [Serializable]
    public struct CreateAgentProcedure
    {
        public CreateAgentProcedure(global::ElevenLabs.CreateAgentProcedureParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateAgentProcedureParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateAgentProcedure(
            global::ElevenLabs.CreateAgentProcedureParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_agent_rule
    /// </summary>
    [Serializable]
    public struct CreateAgentRule
    {
        public CreateAgentRule(global::ElevenLabs.CreateAgentRuleParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateAgentRuleParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateAgentRule(
            global::ElevenLabs.CreateAgentRuleParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_asset
    /// </summary>
    [Serializable]
    public struct CreateAsset
    {
        public CreateAsset(global::ElevenLabs.CreateAssetParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateAssetParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateAsset(
            global::ElevenLabs.CreateAssetParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_client
    /// </summary>
    [Serializable]
    public struct CreateClient
    {
        public CreateClient(global::ElevenLabs.CreateClientParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateClientParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateClient(
            global::ElevenLabs.CreateClientParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_client_appointment
    /// </summary>
    [Serializable]
    public struct CreateClientAppointment
    {
        public CreateClientAppointment(global::ElevenLabs.CreateClientAppointmentParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateClientAppointmentParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateClientAppointment(
            global::ElevenLabs.CreateClientAppointmentParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_client_interaction
    /// </summary>
    [Serializable]
    public struct CreateClientInteraction
    {
        public CreateClientInteraction(global::ElevenLabs.CreateClientInteractionParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateClientInteractionParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateClientInteraction(
            global::ElevenLabs.CreateClientInteractionParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_holiday
    /// </summary>
    [Serializable]
    public struct CreateHoliday
    {
        public CreateHoliday(global::ElevenLabs.CreateHolidayParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateHolidayParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateHoliday(
            global::ElevenLabs.CreateHolidayParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_location
    /// </summary>
    [Serializable]
    public struct CreateLocation
    {
        public CreateLocation(global::ElevenLabs.CreateLocationParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateLocationParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateLocation(
            global::ElevenLabs.CreateLocationParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_order
    /// </summary>
    [Serializable]
    public struct CreateOrder
    {
        public CreateOrder(global::ElevenLabs.CreateOrderParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateOrderParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateOrder(
            global::ElevenLabs.CreateOrderParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_product
    /// </summary>
    [Serializable]
    public struct CreateProduct
    {
        public CreateProduct(global::ElevenLabs.CreateProductParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateProductParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateProduct(
            global::ElevenLabs.CreateProductParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_product_quote_request
    /// </summary>
    [Serializable]
    public struct CreateProductQuoteRequest
    {
        public CreateProductQuoteRequest(global::ElevenLabs.CreateProductQuoteRequestParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateProductQuoteRequestParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateProductQuoteRequest(
            global::ElevenLabs.CreateProductQuoteRequestParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_service
    /// </summary>
    [Serializable]
    public struct CreateService
    {
        public CreateService(global::ElevenLabs.CreateServiceParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateServiceParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateService(
            global::ElevenLabs.CreateServiceParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_service_quote_request
    /// </summary>
    [Serializable]
    public struct CreateServiceQuoteRequest
    {
        public CreateServiceQuoteRequest(global::ElevenLabs.CreateServiceQuoteRequestParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateServiceQuoteRequestParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateServiceQuoteRequest(
            global::ElevenLabs.CreateServiceQuoteRequestParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_staff
    /// </summary>
    [Serializable]
    public struct CreateStaff
    {
        public CreateStaff(global::ElevenLabs.CreateStaffParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateStaffParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateStaff(
            global::ElevenLabs.CreateStaffParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for create_transfer_rule
    /// </summary>
    [Serializable]
    public struct CreateTransferRule
    {
        public CreateTransferRule(global::ElevenLabs.CreateTransferRuleParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreateTransferRuleParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.CreateTransferRule(
            global::ElevenLabs.CreateTransferRuleParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_agent_procedure
    /// </summary>
    [Serializable]
    public struct DeleteAgentProcedure
    {
        public DeleteAgentProcedure(global::ElevenLabs.DeleteAgentProcedureParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteAgentProcedureParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteAgentProcedure(
            global::ElevenLabs.DeleteAgentProcedureParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_agent_rule
    /// </summary>
    [Serializable]
    public struct DeleteAgentRule
    {
        public DeleteAgentRule(global::ElevenLabs.DeleteAgentRuleParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteAgentRuleParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteAgentRule(
            global::ElevenLabs.DeleteAgentRuleParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_asset
    /// </summary>
    [Serializable]
    public struct DeleteAsset
    {
        public DeleteAsset(global::ElevenLabs.DeleteAssetParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteAssetParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteAsset(
            global::ElevenLabs.DeleteAssetParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_calendar_event
    /// </summary>
    [Serializable]
    public struct DeleteCalendarEvent
    {
        public DeleteCalendarEvent(global::ElevenLabs.DeleteCalendarEventParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteCalendarEventParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteCalendarEvent(
            global::ElevenLabs.DeleteCalendarEventParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_client
    /// </summary>
    [Serializable]
    public struct DeleteClient
    {
        public DeleteClient(global::ElevenLabs.DeleteClientParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteClientParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteClient(
            global::ElevenLabs.DeleteClientParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_client_interaction
    /// </summary>
    [Serializable]
    public struct DeleteClientInteraction
    {
        public DeleteClientInteraction(global::ElevenLabs.DeleteClientInteractionParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteClientInteractionParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteClientInteraction(
            global::ElevenLabs.DeleteClientInteractionParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_group_session
    /// </summary>
    [Serializable]
    public struct DeleteGroupSession
    {
        public DeleteGroupSession(global::ElevenLabs.DeleteGroupSessionParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteGroupSessionParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteGroupSession(
            global::ElevenLabs.DeleteGroupSessionParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_holiday
    /// </summary>
    [Serializable]
    public struct DeleteHoliday
    {
        public DeleteHoliday(global::ElevenLabs.DeleteHolidayParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteHolidayParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteHoliday(
            global::ElevenLabs.DeleteHolidayParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_location
    /// </summary>
    [Serializable]
    public struct DeleteLocation
    {
        public DeleteLocation(global::ElevenLabs.DeleteLocationParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteLocationParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteLocation(
            global::ElevenLabs.DeleteLocationParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_product
    /// </summary>
    [Serializable]
    public struct DeleteProduct
    {
        public DeleteProduct(global::ElevenLabs.DeleteProductParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteProductParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteProduct(
            global::ElevenLabs.DeleteProductParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_service
    /// </summary>
    [Serializable]
    public struct DeleteService
    {
        public DeleteService(global::ElevenLabs.DeleteServiceParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteServiceParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteService(
            global::ElevenLabs.DeleteServiceParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_staff
    /// </summary>
    [Serializable]
    public struct DeleteStaff
    {
        public DeleteStaff(global::ElevenLabs.DeleteStaffParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteStaffParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteStaff(
            global::ElevenLabs.DeleteStaffParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for delete_transfer_rule
    /// </summary>
    [Serializable]
    public struct DeleteTransferRule
    {
        public DeleteTransferRule(global::ElevenLabs.DeleteTransferRuleParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DeleteTransferRuleParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.DeleteTransferRule(
            global::ElevenLabs.DeleteTransferRuleParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_agent_config
    /// </summary>
    [Serializable]
    public struct GetAgentConfig
    {
        public GetAgentConfig(global::ElevenLabs.GetAgentConfigParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetAgentConfigParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetAgentConfig(
            global::ElevenLabs.GetAgentConfigParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_analytics_summary
    /// </summary>
    [Serializable]
    public struct GetAnalyticsSummary
    {
        public GetAnalyticsSummary(global::ElevenLabs.GetAnalyticsSummaryParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetAnalyticsSummaryParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetAnalyticsSummary(
            global::ElevenLabs.GetAnalyticsSummaryParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_appointment_by_confirmation_number
    /// </summary>
    [Serializable]
    public struct GetAppointmentByConfirmationNumber
    {
        public GetAppointmentByConfirmationNumber(
            global::ElevenLabs.GetAppointmentByConfirmationNumberParams value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.GetAppointmentByConfirmationNumberParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetAppointmentByConfirmationNumber(
            global::ElevenLabs.GetAppointmentByConfirmationNumberParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_booking_page_settings
    /// </summary>
    [Serializable]
    public struct GetBookingPageSettings
    {
        public GetBookingPageSettings(global::ElevenLabs.GetBookingPageSettingsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetBookingPageSettingsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetBookingPageSettings(
            global::ElevenLabs.GetBookingPageSettingsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_booking_slug_status
    /// </summary>
    [Serializable]
    public struct GetBookingSlugStatus
    {
        public GetBookingSlugStatus(global::ElevenLabs.GetBookingSlugStatusParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetBookingSlugStatusParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetBookingSlugStatus(
            global::ElevenLabs.GetBookingSlugStatusParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_client_appointments
    /// </summary>
    [Serializable]
    public struct GetClientAppointments
    {
        public GetClientAppointments(global::ElevenLabs.GetClientAppointmentsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetClientAppointmentsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetClientAppointments(
            global::ElevenLabs.GetClientAppointmentsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_client_by_phone
    /// </summary>
    [Serializable]
    public struct GetClientByPhone
    {
        public GetClientByPhone(global::ElevenLabs.GetClientByPhoneParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetClientByPhoneParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetClientByPhone(
            global::ElevenLabs.GetClientByPhoneParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_client_orders
    /// </summary>
    [Serializable]
    public struct GetClientOrders
    {
        public GetClientOrders(global::ElevenLabs.GetClientOrdersParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetClientOrdersParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetClientOrders(
            global::ElevenLabs.GetClientOrdersParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_order_by_confirmation_number
    /// </summary>
    [Serializable]
    public struct GetOrderByConfirmationNumber
    {
        public GetOrderByConfirmationNumber(
            global::ElevenLabs.GetOrderByConfirmationNumberParams value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.GetOrderByConfirmationNumberParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetOrderByConfirmationNumber(
            global::ElevenLabs.GetOrderByConfirmationNumberParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_schedule
    /// </summary>
    [Serializable]
    public struct GetSchedule
    {
        public GetSchedule(global::ElevenLabs.GetScheduleParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetScheduleParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetSchedule(
            global::ElevenLabs.GetScheduleParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for get_workspace_plan
    /// </summary>
    [Serializable]
    public struct GetWorkspacePlan
    {
        public GetWorkspacePlan(global::ElevenLabs.GetWorkspacePlanParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetWorkspacePlanParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.GetWorkspacePlan(
            global::ElevenLabs.GetWorkspacePlanParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for leave_message
    /// </summary>
    [Serializable]
    public struct LeaveMessage
    {
        public LeaveMessage(global::ElevenLabs.LeaveMessageParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.LeaveMessageParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.LeaveMessage(
            global::ElevenLabs.LeaveMessageParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_agent_procedures
    /// </summary>
    [Serializable]
    public struct ListAgentProcedures
    {
        public ListAgentProcedures(global::ElevenLabs.ListAgentProceduresParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListAgentProceduresParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListAgentProcedures(
            global::ElevenLabs.ListAgentProceduresParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_agent_references
    /// </summary>
    [Serializable]
    public struct ListAgentReferences
    {
        public ListAgentReferences(global::ElevenLabs.ListAgentReferencesParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListAgentReferencesParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListAgentReferences(
            global::ElevenLabs.ListAgentReferencesParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_agent_rules
    /// </summary>
    [Serializable]
    public struct ListAgentRules
    {
        public ListAgentRules(global::ElevenLabs.ListAgentRulesParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListAgentRulesParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListAgentRules(
            global::ElevenLabs.ListAgentRulesParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_assets
    /// </summary>
    [Serializable]
    public struct ListAssets
    {
        public ListAssets(global::ElevenLabs.ListAssetsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListAssetsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListAssets(
            global::ElevenLabs.ListAssetsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_calendar_events
    /// </summary>
    [Serializable]
    public struct ListCalendarEvents
    {
        public ListCalendarEvents(global::ElevenLabs.ListCalendarEventsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListCalendarEventsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListCalendarEvents(
            global::ElevenLabs.ListCalendarEventsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_client_interactions
    /// </summary>
    [Serializable]
    public struct ListClientInteractions
    {
        public ListClientInteractions(global::ElevenLabs.ListClientInteractionsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListClientInteractionsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListClientInteractions(
            global::ElevenLabs.ListClientInteractionsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_clients
    /// </summary>
    [Serializable]
    public struct ListClients
    {
        public ListClients(global::ElevenLabs.ListClientsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListClientsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListClients(
            global::ElevenLabs.ListClientsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_customer_facing_agents
    /// </summary>
    [Serializable]
    public struct ListCustomerFacingAgents
    {
        public ListCustomerFacingAgents(global::ElevenLabs.ListCustomerFacingAgentsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListCustomerFacingAgentsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListCustomerFacingAgents(
            global::ElevenLabs.ListCustomerFacingAgentsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_group_sessions
    /// </summary>
    [Serializable]
    public struct ListGroupSessions
    {
        public ListGroupSessions(global::ElevenLabs.ListGroupSessionsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListGroupSessionsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListGroupSessions(
            global::ElevenLabs.ListGroupSessionsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_holidays
    /// </summary>
    [Serializable]
    public struct ListHolidays
    {
        public ListHolidays(global::ElevenLabs.ListHolidaysParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListHolidaysParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListHolidays(
            global::ElevenLabs.ListHolidaysParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_locations
    /// </summary>
    [Serializable]
    public struct ListLocations
    {
        public ListLocations(global::ElevenLabs.ListLocationsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListLocationsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListLocations(
            global::ElevenLabs.ListLocationsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_products
    /// </summary>
    [Serializable]
    public struct ListProducts
    {
        public ListProducts(global::ElevenLabs.ListProductsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListProductsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListProducts(
            global::ElevenLabs.ListProductsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_services
    /// </summary>
    [Serializable]
    public struct ListServices
    {
        public ListServices(global::ElevenLabs.ListServicesParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListServicesParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListServices(
            global::ElevenLabs.ListServicesParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_staff
    /// </summary>
    [Serializable]
    public struct ListStaff
    {
        public ListStaff(global::ElevenLabs.ListStaffParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListStaffParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListStaff(
            global::ElevenLabs.ListStaffParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for list_transfer_rules
    /// </summary>
    [Serializable]
    public struct ListTransferRules
    {
        public ListTransferRules(global::ElevenLabs.ListTransferRulesParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ListTransferRulesParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ListTransferRules(
            global::ElevenLabs.ListTransferRulesParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for opt_in_sms_reminder
    /// </summary>
    [Serializable]
    public struct OptInSmsReminder
    {
        public OptInSmsReminder(global::ElevenLabs.OptInSmsReminderParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OptInSmsReminderParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OptInSmsReminder(
            global::ElevenLabs.OptInSmsReminderParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for opt_out_sms_reminder
    /// </summary>
    [Serializable]
    public struct OptOutSmsReminder
    {
        public OptOutSmsReminder(global::ElevenLabs.OptOutSmsReminderParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OptOutSmsReminderParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OptOutSmsReminder(
            global::ElevenLabs.OptOutSmsReminderParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for owner_get_client_appointments
    /// </summary>
    [Serializable]
    public struct OwnerGetClientAppointments
    {
        public OwnerGetClientAppointments(global::ElevenLabs.OwnerGetClientAppointmentsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OwnerGetClientAppointmentsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OwnerGetClientAppointments(
            global::ElevenLabs.OwnerGetClientAppointmentsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for owner_list_assets
    /// </summary>
    [Serializable]
    public struct OwnerListAssets
    {
        public OwnerListAssets(global::ElevenLabs.OwnerListAssetsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OwnerListAssetsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OwnerListAssets(
            global::ElevenLabs.OwnerListAssetsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for owner_list_locations
    /// </summary>
    [Serializable]
    public struct OwnerListLocations
    {
        public OwnerListLocations(global::ElevenLabs.OwnerListLocationsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OwnerListLocationsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OwnerListLocations(
            global::ElevenLabs.OwnerListLocationsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for owner_list_products
    /// </summary>
    [Serializable]
    public struct OwnerListProducts
    {
        public OwnerListProducts(global::ElevenLabs.OwnerListProductsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OwnerListProductsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OwnerListProducts(
            global::ElevenLabs.OwnerListProductsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for owner_list_services
    /// </summary>
    [Serializable]
    public struct OwnerListServices
    {
        public OwnerListServices(global::ElevenLabs.OwnerListServicesParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OwnerListServicesParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OwnerListServices(
            global::ElevenLabs.OwnerListServicesParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for owner_list_staff
    /// </summary>
    [Serializable]
    public struct OwnerListStaff
    {
        public OwnerListStaff(global::ElevenLabs.OwnerListStaffParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OwnerListStaffParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.OwnerListStaff(
            global::ElevenLabs.OwnerListStaffParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for register_for_group_session
    /// </summary>
    [Serializable]
    public struct RegisterForGroupSession
    {
        public RegisterForGroupSession(global::ElevenLabs.RegisterForGroupSessionParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.RegisterForGroupSessionParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.RegisterForGroupSession(
            global::ElevenLabs.RegisterForGroupSessionParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for report_knowledge_gap
    /// </summary>
    [Serializable]
    public struct ReportKnowledgeGap
    {
        public ReportKnowledgeGap(global::ElevenLabs.ReportKnowledgeGapParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ReportKnowledgeGapParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ReportKnowledgeGap(
            global::ElevenLabs.ReportKnowledgeGapParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for restore_calendar_event
    /// </summary>
    [Serializable]
    public struct RestoreCalendarEvent
    {
        public RestoreCalendarEvent(global::ElevenLabs.RestoreCalendarEventParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.RestoreCalendarEventParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.RestoreCalendarEvent(
            global::ElevenLabs.RestoreCalendarEventParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for schedule_group_session
    /// </summary>
    [Serializable]
    public struct ScheduleGroupSession
    {
        public ScheduleGroupSession(global::ElevenLabs.ScheduleGroupSessionParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ScheduleGroupSessionParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ScheduleGroupSession(
            global::ElevenLabs.ScheduleGroupSessionParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for search_clients
    /// </summary>
    [Serializable]
    public struct SearchClients
    {
        public SearchClients(global::ElevenLabs.SearchClientsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SearchClientsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.SearchClients(
            global::ElevenLabs.SearchClientsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for send_custom_email
    /// </summary>
    [Serializable]
    public struct SendCustomEmail
    {
        public SendCustomEmail(global::ElevenLabs.SendCustomEmailParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SendCustomEmailParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.SendCustomEmail(
            global::ElevenLabs.SendCustomEmailParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for set_booking_slug
    /// </summary>
    [Serializable]
    public struct SetBookingSlug
    {
        public SetBookingSlug(global::ElevenLabs.SetBookingSlugParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SetBookingSlugParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.SetBookingSlug(
            global::ElevenLabs.SetBookingSlugParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for submit_business_info
    /// </summary>
    [Serializable]
    public struct SubmitBusinessInfo
    {
        public SubmitBusinessInfo(global::ElevenLabs.SubmitBusinessInfoParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubmitBusinessInfoParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.SubmitBusinessInfo(
            global::ElevenLabs.SubmitBusinessInfoParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for trigger_user_verification
    /// </summary>
    [Serializable]
    public struct TriggerUserVerification
    {
        public TriggerUserVerification(global::ElevenLabs.TriggerUserVerificationParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TriggerUserVerificationParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.TriggerUserVerification(
            global::ElevenLabs.TriggerUserVerificationParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_agent_config
    /// </summary>
    [Serializable]
    public struct UpdateAgentConfig
    {
        public UpdateAgentConfig(global::ElevenLabs.UpdateAgentConfigParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateAgentConfigParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateAgentConfig(
            global::ElevenLabs.UpdateAgentConfigParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_agent_procedure
    /// </summary>
    [Serializable]
    public struct UpdateAgentProcedure
    {
        public UpdateAgentProcedure(global::ElevenLabs.UpdateAgentProcedureParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateAgentProcedureParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateAgentProcedure(
            global::ElevenLabs.UpdateAgentProcedureParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_agent_rule
    /// </summary>
    [Serializable]
    public struct UpdateAgentRule
    {
        public UpdateAgentRule(global::ElevenLabs.UpdateAgentRuleParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateAgentRuleParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateAgentRule(
            global::ElevenLabs.UpdateAgentRuleParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_asset
    /// </summary>
    [Serializable]
    public struct UpdateAsset
    {
        public UpdateAsset(global::ElevenLabs.UpdateAssetParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateAssetParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateAsset(
            global::ElevenLabs.UpdateAssetParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_booking_page_appearance
    /// </summary>
    [Serializable]
    public struct UpdateBookingPageAppearance
    {
        public UpdateBookingPageAppearance(
            global::ElevenLabs.UpdateBookingPageAppearanceParams value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateBookingPageAppearanceParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateBookingPageAppearance(
            global::ElevenLabs.UpdateBookingPageAppearanceParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_booking_page_settings
    /// </summary>
    [Serializable]
    public struct UpdateBookingPageSettings
    {
        public UpdateBookingPageSettings(global::ElevenLabs.UpdateBookingPageSettingsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateBookingPageSettingsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateBookingPageSettings(
            global::ElevenLabs.UpdateBookingPageSettingsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_business_info
    /// </summary>
    [Serializable]
    public struct UpdateBusinessInfo
    {
        public UpdateBusinessInfo(global::ElevenLabs.UpdateBusinessInfoParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateBusinessInfoParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateBusinessInfo(
            global::ElevenLabs.UpdateBusinessInfoParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_calendar_event
    /// </summary>
    [Serializable]
    public struct UpdateCalendarEvent
    {
        public UpdateCalendarEvent(global::ElevenLabs.UpdateCalendarEventParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateCalendarEventParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateCalendarEvent(
            global::ElevenLabs.UpdateCalendarEventParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_client
    /// </summary>
    [Serializable]
    public struct UpdateClient
    {
        public UpdateClient(global::ElevenLabs.UpdateClientParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateClientParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateClient(
            global::ElevenLabs.UpdateClientParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_group_session_seats
    /// </summary>
    [Serializable]
    public struct UpdateGroupSessionSeats
    {
        public UpdateGroupSessionSeats(global::ElevenLabs.UpdateGroupSessionSeatsParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateGroupSessionSeatsParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateGroupSessionSeats(
            global::ElevenLabs.UpdateGroupSessionSeatsParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_holiday
    /// </summary>
    [Serializable]
    public struct UpdateHoliday
    {
        public UpdateHoliday(global::ElevenLabs.UpdateHolidayParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateHolidayParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateHoliday(
            global::ElevenLabs.UpdateHolidayParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_location
    /// </summary>
    [Serializable]
    public struct UpdateLocation
    {
        public UpdateLocation(global::ElevenLabs.UpdateLocationParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateLocationParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateLocation(
            global::ElevenLabs.UpdateLocationParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_order
    /// </summary>
    [Serializable]
    public struct UpdateOrder
    {
        public UpdateOrder(global::ElevenLabs.UpdateOrderParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateOrderParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateOrder(
            global::ElevenLabs.UpdateOrderParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_product
    /// </summary>
    [Serializable]
    public struct UpdateProduct
    {
        public UpdateProduct(global::ElevenLabs.UpdateProductParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateProductParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateProduct(
            global::ElevenLabs.UpdateProductParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_service
    /// </summary>
    [Serializable]
    public struct UpdateService
    {
        public UpdateService(global::ElevenLabs.UpdateServiceParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateServiceParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateService(
            global::ElevenLabs.UpdateServiceParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_staff
    /// </summary>
    [Serializable]
    public struct UpdateStaff
    {
        public UpdateStaff(global::ElevenLabs.UpdateStaffParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateStaffParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateStaff(
            global::ElevenLabs.UpdateStaffParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_transfer_rule
    /// </summary>
    [Serializable]
    public struct UpdateTransferRule
    {
        public UpdateTransferRule(global::ElevenLabs.UpdateTransferRuleParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UpdateTransferRuleParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.UpdateTransferRule(
            global::ElevenLabs.UpdateTransferRuleParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for validate_user_verification_code
    /// </summary>
    [Serializable]
    public struct ValidateUserVerificationCode
    {
        public ValidateUserVerificationCode(
            global::ElevenLabs.ValidateUserVerificationCodeParams value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.ValidateUserVerificationCodeParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SmbToolConfigParams.ValidateUserVerificationCode(
            global::ElevenLabs.ValidateUserVerificationCodeParams value
        ) => new(value);
    }
}
