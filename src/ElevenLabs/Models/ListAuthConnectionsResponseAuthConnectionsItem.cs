// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of auth connection config</summary>
[JsonConverter(typeof(ListAuthConnectionsResponseAuthConnectionsItem.JsonConverter))]
[Serializable]
public record ListAuthConnectionsResponseAuthConnectionsItem
{
    internal ListAuthConnectionsResponseAuthConnectionsItem(string type, object? value)
    {
        AuthType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2AuthCode"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2AuthCode value
    )
    {
        AuthType = "api_integration_oauth2_auth_code";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2CustomApp"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2CustomApp value
    )
    {
        AuthType = "api_integration_oauth2_custom_app";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.BasicAuth"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.BasicAuth value
    )
    {
        AuthType = "basic_auth";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.BearerAuth"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.BearerAuth value
    )
    {
        AuthType = "bearer_auth";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.CustomHeaderAuth"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.CustomHeaderAuth value
    )
    {
        AuthType = "custom_header_auth";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.Mtls"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.Mtls value
    )
    {
        AuthType = "mtls";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.Oauth2ClientCredentials"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.Oauth2ClientCredentials value
    )
    {
        AuthType = "oauth2_client_credentials";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.Oauth2Jwt"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.Oauth2Jwt value
    )
    {
        AuthType = "oauth2_jwt";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.PrivateKeyJwt"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.PrivateKeyJwt value
    )
    {
        AuthType = "private_key_jwt";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.RefreshTokenAuth"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.RefreshTokenAuth value
    )
    {
        AuthType = "refresh_token_auth";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.SlackBotAuth"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.SlackBotAuth value
    )
    {
        AuthType = "slack_bot_auth";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.UrlSecret"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.UrlSecret value
    )
    {
        AuthType = "url_secret";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListAuthConnectionsResponseAuthConnectionsItem with <see cref="ListAuthConnectionsResponseAuthConnectionsItem.WhatsappAuth"/>.
    /// </summary>
    public ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.WhatsappAuth value
    )
    {
        AuthType = "whatsapp_auth";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("auth_type")]
    public string AuthType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "api_integration_oauth2_auth_code"
    /// </summary>
    public bool IsApiIntegrationOauth2AuthCode => AuthType == "api_integration_oauth2_auth_code";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "api_integration_oauth2_custom_app"
    /// </summary>
    public bool IsApiIntegrationOauth2CustomApp => AuthType == "api_integration_oauth2_custom_app";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "basic_auth"
    /// </summary>
    public bool IsBasicAuth => AuthType == "basic_auth";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "bearer_auth"
    /// </summary>
    public bool IsBearerAuth => AuthType == "bearer_auth";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "custom_header_auth"
    /// </summary>
    public bool IsCustomHeaderAuth => AuthType == "custom_header_auth";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "mtls"
    /// </summary>
    public bool IsMtls => AuthType == "mtls";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "oauth2_client_credentials"
    /// </summary>
    public bool IsOauth2ClientCredentials => AuthType == "oauth2_client_credentials";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "oauth2_jwt"
    /// </summary>
    public bool IsOauth2Jwt => AuthType == "oauth2_jwt";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "private_key_jwt"
    /// </summary>
    public bool IsPrivateKeyJwt => AuthType == "private_key_jwt";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "refresh_token_auth"
    /// </summary>
    public bool IsRefreshTokenAuth => AuthType == "refresh_token_auth";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "slack_bot_auth"
    /// </summary>
    public bool IsSlackBotAuth => AuthType == "slack_bot_auth";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "url_secret"
    /// </summary>
    public bool IsUrlSecret => AuthType == "url_secret";

    /// <summary>
    /// Returns true if <see cref="AuthType"/> is "whatsapp_auth"
    /// </summary>
    public bool IsWhatsappAuth => AuthType == "whatsapp_auth";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse"/> if <see cref="AuthType"/> is 'api_integration_oauth2_auth_code', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'api_integration_oauth2_auth_code'.</exception>
    public global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse AsApiIntegrationOauth2AuthCode() =>
        IsApiIntegrationOauth2AuthCode
            ? (global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'api_integration_oauth2_auth_code'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse"/> if <see cref="AuthType"/> is 'api_integration_oauth2_custom_app', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'api_integration_oauth2_custom_app'.</exception>
    public global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse AsApiIntegrationOauth2CustomApp() =>
        IsApiIntegrationOauth2CustomApp
            ? (global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'api_integration_oauth2_custom_app'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BasicAuthResponse"/> if <see cref="AuthType"/> is 'basic_auth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'basic_auth'.</exception>
    public global::ElevenLabs.BasicAuthResponse AsBasicAuth() =>
        IsBasicAuth
            ? (global::ElevenLabs.BasicAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'basic_auth'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BearerAuthResponse"/> if <see cref="AuthType"/> is 'bearer_auth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'bearer_auth'.</exception>
    public global::ElevenLabs.BearerAuthResponse AsBearerAuth() =>
        IsBearerAuth
            ? (global::ElevenLabs.BearerAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'bearer_auth'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CustomHeaderAuthResponse"/> if <see cref="AuthType"/> is 'custom_header_auth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'custom_header_auth'.</exception>
    public global::ElevenLabs.CustomHeaderAuthResponse AsCustomHeaderAuth() =>
        IsCustomHeaderAuth
            ? (global::ElevenLabs.CustomHeaderAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'custom_header_auth'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MtlsAuthResponse"/> if <see cref="AuthType"/> is 'mtls', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'mtls'.</exception>
    public global::ElevenLabs.MtlsAuthResponse AsMtls() =>
        IsMtls
            ? (global::ElevenLabs.MtlsAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'mtls'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OAuth2ClientCredsResponse"/> if <see cref="AuthType"/> is 'oauth2_client_credentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'oauth2_client_credentials'.</exception>
    public global::ElevenLabs.OAuth2ClientCredsResponse AsOauth2ClientCredentials() =>
        IsOauth2ClientCredentials
            ? (global::ElevenLabs.OAuth2ClientCredsResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'oauth2_client_credentials'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OAuth2JwtResponse"/> if <see cref="AuthType"/> is 'oauth2_jwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'oauth2_jwt'.</exception>
    public global::ElevenLabs.OAuth2JwtResponse AsOauth2Jwt() =>
        IsOauth2Jwt
            ? (global::ElevenLabs.OAuth2JwtResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'oauth2_jwt'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PrivateKeyJwtResponse"/> if <see cref="AuthType"/> is 'private_key_jwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'private_key_jwt'.</exception>
    public global::ElevenLabs.PrivateKeyJwtResponse AsPrivateKeyJwt() =>
        IsPrivateKeyJwt
            ? (global::ElevenLabs.PrivateKeyJwtResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'private_key_jwt'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.RefreshTokenAuthResponse"/> if <see cref="AuthType"/> is 'refresh_token_auth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'refresh_token_auth'.</exception>
    public global::ElevenLabs.RefreshTokenAuthResponse AsRefreshTokenAuth() =>
        IsRefreshTokenAuth
            ? (global::ElevenLabs.RefreshTokenAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'refresh_token_auth'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SlackBotAuthResponse"/> if <see cref="AuthType"/> is 'slack_bot_auth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'slack_bot_auth'.</exception>
    public global::ElevenLabs.SlackBotAuthResponse AsSlackBotAuth() =>
        IsSlackBotAuth
            ? (global::ElevenLabs.SlackBotAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'slack_bot_auth'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.UrlSecretAuthResponse"/> if <see cref="AuthType"/> is 'url_secret', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'url_secret'.</exception>
    public global::ElevenLabs.UrlSecretAuthResponse AsUrlSecret() =>
        IsUrlSecret
            ? (global::ElevenLabs.UrlSecretAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'url_secret'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppAuthResponse"/> if <see cref="AuthType"/> is 'whatsapp_auth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="AuthType"/> is not 'whatsapp_auth'.</exception>
    public global::ElevenLabs.WhatsAppAuthResponse AsWhatsappAuth() =>
        IsWhatsappAuth
            ? (global::ElevenLabs.WhatsAppAuthResponse)Value!
            : throw new global::System.Exception(
                "ListAuthConnectionsResponseAuthConnectionsItem.AuthType is not 'whatsapp_auth'"
            );

    public T Match<T>(
        Func<
            global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse,
            T
        > onApiIntegrationOauth2AuthCode,
        Func<
            global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse,
            T
        > onApiIntegrationOauth2CustomApp,
        Func<global::ElevenLabs.BasicAuthResponse, T> onBasicAuth,
        Func<global::ElevenLabs.BearerAuthResponse, T> onBearerAuth,
        Func<global::ElevenLabs.CustomHeaderAuthResponse, T> onCustomHeaderAuth,
        Func<global::ElevenLabs.MtlsAuthResponse, T> onMtls,
        Func<global::ElevenLabs.OAuth2ClientCredsResponse, T> onOauth2ClientCredentials,
        Func<global::ElevenLabs.OAuth2JwtResponse, T> onOauth2Jwt,
        Func<global::ElevenLabs.PrivateKeyJwtResponse, T> onPrivateKeyJwt,
        Func<global::ElevenLabs.RefreshTokenAuthResponse, T> onRefreshTokenAuth,
        Func<global::ElevenLabs.SlackBotAuthResponse, T> onSlackBotAuth,
        Func<global::ElevenLabs.UrlSecretAuthResponse, T> onUrlSecret,
        Func<global::ElevenLabs.WhatsAppAuthResponse, T> onWhatsappAuth,
        Func<string, object?, T> onUnknown_
    )
    {
        return AuthType switch
        {
            "api_integration_oauth2_auth_code" => onApiIntegrationOauth2AuthCode(
                AsApiIntegrationOauth2AuthCode()
            ),
            "api_integration_oauth2_custom_app" => onApiIntegrationOauth2CustomApp(
                AsApiIntegrationOauth2CustomApp()
            ),
            "basic_auth" => onBasicAuth(AsBasicAuth()),
            "bearer_auth" => onBearerAuth(AsBearerAuth()),
            "custom_header_auth" => onCustomHeaderAuth(AsCustomHeaderAuth()),
            "mtls" => onMtls(AsMtls()),
            "oauth2_client_credentials" => onOauth2ClientCredentials(AsOauth2ClientCredentials()),
            "oauth2_jwt" => onOauth2Jwt(AsOauth2Jwt()),
            "private_key_jwt" => onPrivateKeyJwt(AsPrivateKeyJwt()),
            "refresh_token_auth" => onRefreshTokenAuth(AsRefreshTokenAuth()),
            "slack_bot_auth" => onSlackBotAuth(AsSlackBotAuth()),
            "url_secret" => onUrlSecret(AsUrlSecret()),
            "whatsapp_auth" => onWhatsappAuth(AsWhatsappAuth()),
            _ => onUnknown_(AuthType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse> onApiIntegrationOauth2AuthCode,
        Action<global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse> onApiIntegrationOauth2CustomApp,
        Action<global::ElevenLabs.BasicAuthResponse> onBasicAuth,
        Action<global::ElevenLabs.BearerAuthResponse> onBearerAuth,
        Action<global::ElevenLabs.CustomHeaderAuthResponse> onCustomHeaderAuth,
        Action<global::ElevenLabs.MtlsAuthResponse> onMtls,
        Action<global::ElevenLabs.OAuth2ClientCredsResponse> onOauth2ClientCredentials,
        Action<global::ElevenLabs.OAuth2JwtResponse> onOauth2Jwt,
        Action<global::ElevenLabs.PrivateKeyJwtResponse> onPrivateKeyJwt,
        Action<global::ElevenLabs.RefreshTokenAuthResponse> onRefreshTokenAuth,
        Action<global::ElevenLabs.SlackBotAuthResponse> onSlackBotAuth,
        Action<global::ElevenLabs.UrlSecretAuthResponse> onUrlSecret,
        Action<global::ElevenLabs.WhatsAppAuthResponse> onWhatsappAuth,
        Action<string, object?> onUnknown_
    )
    {
        switch (AuthType)
        {
            case "api_integration_oauth2_auth_code":
                onApiIntegrationOauth2AuthCode(AsApiIntegrationOauth2AuthCode());
                break;
            case "api_integration_oauth2_custom_app":
                onApiIntegrationOauth2CustomApp(AsApiIntegrationOauth2CustomApp());
                break;
            case "basic_auth":
                onBasicAuth(AsBasicAuth());
                break;
            case "bearer_auth":
                onBearerAuth(AsBearerAuth());
                break;
            case "custom_header_auth":
                onCustomHeaderAuth(AsCustomHeaderAuth());
                break;
            case "mtls":
                onMtls(AsMtls());
                break;
            case "oauth2_client_credentials":
                onOauth2ClientCredentials(AsOauth2ClientCredentials());
                break;
            case "oauth2_jwt":
                onOauth2Jwt(AsOauth2Jwt());
                break;
            case "private_key_jwt":
                onPrivateKeyJwt(AsPrivateKeyJwt());
                break;
            case "refresh_token_auth":
                onRefreshTokenAuth(AsRefreshTokenAuth());
                break;
            case "slack_bot_auth":
                onSlackBotAuth(AsSlackBotAuth());
                break;
            case "url_secret":
                onUrlSecret(AsUrlSecret());
                break;
            case "whatsapp_auth":
                onWhatsappAuth(AsWhatsappAuth());
                break;
            default:
                onUnknown_(AuthType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsApiIntegrationOauth2AuthCode(
        out global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse? value
    )
    {
        if (AuthType == "api_integration_oauth2_auth_code")
        {
            value = (global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsApiIntegrationOauth2CustomApp(
        out global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse? value
    )
    {
        if (AuthType == "api_integration_oauth2_custom_app")
        {
            value = (global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BasicAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsBasicAuth(out global::ElevenLabs.BasicAuthResponse? value)
    {
        if (AuthType == "basic_auth")
        {
            value = (global::ElevenLabs.BasicAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BearerAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsBearerAuth(out global::ElevenLabs.BearerAuthResponse? value)
    {
        if (AuthType == "bearer_auth")
        {
            value = (global::ElevenLabs.BearerAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CustomHeaderAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsCustomHeaderAuth(out global::ElevenLabs.CustomHeaderAuthResponse? value)
    {
        if (AuthType == "custom_header_auth")
        {
            value = (global::ElevenLabs.CustomHeaderAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MtlsAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsMtls(out global::ElevenLabs.MtlsAuthResponse? value)
    {
        if (AuthType == "mtls")
        {
            value = (global::ElevenLabs.MtlsAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OAuth2ClientCredsResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsOauth2ClientCredentials(
        out global::ElevenLabs.OAuth2ClientCredsResponse? value
    )
    {
        if (AuthType == "oauth2_client_credentials")
        {
            value = (global::ElevenLabs.OAuth2ClientCredsResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OAuth2JwtResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsOauth2Jwt(out global::ElevenLabs.OAuth2JwtResponse? value)
    {
        if (AuthType == "oauth2_jwt")
        {
            value = (global::ElevenLabs.OAuth2JwtResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PrivateKeyJwtResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsPrivateKeyJwt(out global::ElevenLabs.PrivateKeyJwtResponse? value)
    {
        if (AuthType == "private_key_jwt")
        {
            value = (global::ElevenLabs.PrivateKeyJwtResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.RefreshTokenAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsRefreshTokenAuth(out global::ElevenLabs.RefreshTokenAuthResponse? value)
    {
        if (AuthType == "refresh_token_auth")
        {
            value = (global::ElevenLabs.RefreshTokenAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SlackBotAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsSlackBotAuth(out global::ElevenLabs.SlackBotAuthResponse? value)
    {
        if (AuthType == "slack_bot_auth")
        {
            value = (global::ElevenLabs.SlackBotAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.UrlSecretAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsUrlSecret(out global::ElevenLabs.UrlSecretAuthResponse? value)
    {
        if (AuthType == "url_secret")
        {
            value = (global::ElevenLabs.UrlSecretAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppAuthResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsWhatsappAuth(out global::ElevenLabs.WhatsAppAuthResponse? value)
    {
        if (AuthType == "whatsapp_auth")
        {
            value = (global::ElevenLabs.WhatsAppAuthResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2AuthCode value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2CustomApp value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.BasicAuth value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.BearerAuth value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.CustomHeaderAuth value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.Mtls value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.Oauth2ClientCredentials value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.Oauth2Jwt value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.PrivateKeyJwt value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.RefreshTokenAuth value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.SlackBotAuth value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.UrlSecret value
    ) => new(value);

    public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem(
        ListAuthConnectionsResponseAuthConnectionsItem.WhatsappAuth value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ListAuthConnectionsResponseAuthConnectionsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ListAuthConnectionsResponseAuthConnectionsItem).IsAssignableFrom(typeToConvert);

        public override ListAuthConnectionsResponseAuthConnectionsItem Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("auth_type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'auth_type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'auth_type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'auth_type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'auth_type' is null");

            var value = discriminator switch
            {
                "api_integration_oauth2_auth_code" =>
                    json.Deserialize<global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse"
                        ),
                "api_integration_oauth2_custom_app" =>
                    json.Deserialize<global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse"
                        ),
                "basic_auth" => json.Deserialize<global::ElevenLabs.BasicAuthResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BasicAuthResponse"
                    ),
                "bearer_auth" => json.Deserialize<global::ElevenLabs.BearerAuthResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BearerAuthResponse"
                    ),
                "custom_header_auth" =>
                    json.Deserialize<global::ElevenLabs.CustomHeaderAuthResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CustomHeaderAuthResponse"
                        ),
                "mtls" => json.Deserialize<global::ElevenLabs.MtlsAuthResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.MtlsAuthResponse"
                    ),
                "oauth2_client_credentials" =>
                    json.Deserialize<global::ElevenLabs.OAuth2ClientCredsResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.OAuth2ClientCredsResponse"
                        ),
                "oauth2_jwt" => json.Deserialize<global::ElevenLabs.OAuth2JwtResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.OAuth2JwtResponse"
                    ),
                "private_key_jwt" => json.Deserialize<global::ElevenLabs.PrivateKeyJwtResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PrivateKeyJwtResponse"
                    ),
                "refresh_token_auth" =>
                    json.Deserialize<global::ElevenLabs.RefreshTokenAuthResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.RefreshTokenAuthResponse"
                        ),
                "slack_bot_auth" => json.Deserialize<global::ElevenLabs.SlackBotAuthResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SlackBotAuthResponse"
                    ),
                "url_secret" => json.Deserialize<global::ElevenLabs.UrlSecretAuthResponse?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.UrlSecretAuthResponse"
                    ),
                "whatsapp_auth" => json.Deserialize<global::ElevenLabs.WhatsAppAuthResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppAuthResponse"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ListAuthConnectionsResponseAuthConnectionsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListAuthConnectionsResponseAuthConnectionsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.AuthType switch
                {
                    "api_integration_oauth2_auth_code" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "api_integration_oauth2_custom_app" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "basic_auth" => JsonSerializer.SerializeToNode(value.Value, options),
                    "bearer_auth" => JsonSerializer.SerializeToNode(value.Value, options),
                    "custom_header_auth" => JsonSerializer.SerializeToNode(value.Value, options),
                    "mtls" => JsonSerializer.SerializeToNode(value.Value, options),
                    "oauth2_client_credentials" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "oauth2_jwt" => JsonSerializer.SerializeToNode(value.Value, options),
                    "private_key_jwt" => JsonSerializer.SerializeToNode(value.Value, options),
                    "refresh_token_auth" => JsonSerializer.SerializeToNode(value.Value, options),
                    "slack_bot_auth" => JsonSerializer.SerializeToNode(value.Value, options),
                    "url_secret" => JsonSerializer.SerializeToNode(value.Value, options),
                    "whatsapp_auth" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["auth_type"] = value.AuthType;
            json.WriteTo(writer, options);
        }

        public override ListAuthConnectionsResponseAuthConnectionsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ListAuthConnectionsResponseAuthConnectionsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListAuthConnectionsResponseAuthConnectionsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.AuthType);
        }
    }

    /// <summary>
    /// Discriminated union type for api_integration_oauth2_auth_code
    /// </summary>
    [Serializable]
    public struct ApiIntegrationOauth2AuthCode
    {
        public ApiIntegrationOauth2AuthCode(
            global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2AuthCode(
            global::ElevenLabs.ApiIntegrationOAuth2AuthCodeResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for api_integration_oauth2_custom_app
    /// </summary>
    [Serializable]
    public struct ApiIntegrationOauth2CustomApp
    {
        public ApiIntegrationOauth2CustomApp(
            global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.ApiIntegrationOauth2CustomApp(
            global::ElevenLabs.ApiIntegrationOAuth2CustomAppResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for basic_auth
    /// </summary>
    [Serializable]
    public struct BasicAuth
    {
        public BasicAuth(global::ElevenLabs.BasicAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BasicAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.BasicAuth(
            global::ElevenLabs.BasicAuthResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for bearer_auth
    /// </summary>
    [Serializable]
    public struct BearerAuth
    {
        public BearerAuth(global::ElevenLabs.BearerAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BearerAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.BearerAuth(
            global::ElevenLabs.BearerAuthResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for custom_header_auth
    /// </summary>
    [Serializable]
    public struct CustomHeaderAuth
    {
        public CustomHeaderAuth(global::ElevenLabs.CustomHeaderAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CustomHeaderAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.CustomHeaderAuth(
            global::ElevenLabs.CustomHeaderAuthResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for mtls
    /// </summary>
    [Serializable]
    public struct Mtls
    {
        public Mtls(global::ElevenLabs.MtlsAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MtlsAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.Mtls(
            global::ElevenLabs.MtlsAuthResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for oauth2_client_credentials
    /// </summary>
    [Serializable]
    public struct Oauth2ClientCredentials
    {
        public Oauth2ClientCredentials(global::ElevenLabs.OAuth2ClientCredsResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OAuth2ClientCredsResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.Oauth2ClientCredentials(
            global::ElevenLabs.OAuth2ClientCredsResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for oauth2_jwt
    /// </summary>
    [Serializable]
    public struct Oauth2Jwt
    {
        public Oauth2Jwt(global::ElevenLabs.OAuth2JwtResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OAuth2JwtResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.Oauth2Jwt(
            global::ElevenLabs.OAuth2JwtResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for private_key_jwt
    /// </summary>
    [Serializable]
    public struct PrivateKeyJwt
    {
        public PrivateKeyJwt(global::ElevenLabs.PrivateKeyJwtResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PrivateKeyJwtResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.PrivateKeyJwt(
            global::ElevenLabs.PrivateKeyJwtResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for refresh_token_auth
    /// </summary>
    [Serializable]
    public struct RefreshTokenAuth
    {
        public RefreshTokenAuth(global::ElevenLabs.RefreshTokenAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.RefreshTokenAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.RefreshTokenAuth(
            global::ElevenLabs.RefreshTokenAuthResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for slack_bot_auth
    /// </summary>
    [Serializable]
    public struct SlackBotAuth
    {
        public SlackBotAuth(global::ElevenLabs.SlackBotAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SlackBotAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.SlackBotAuth(
            global::ElevenLabs.SlackBotAuthResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for url_secret
    /// </summary>
    [Serializable]
    public struct UrlSecret
    {
        public UrlSecret(global::ElevenLabs.UrlSecretAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.UrlSecretAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.UrlSecret(
            global::ElevenLabs.UrlSecretAuthResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for whatsapp_auth
    /// </summary>
    [Serializable]
    public struct WhatsappAuth
    {
        public WhatsappAuth(global::ElevenLabs.WhatsAppAuthResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppAuthResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListAuthConnectionsResponseAuthConnectionsItem.WhatsappAuth(
            global::ElevenLabs.WhatsAppAuthResponse value
        ) => new(value);
    }
}
