/*
 * Vault API
 *
 * Welcome to the Vault API 👋  When you're looking to connect to an API, the first step is authentication.  Vault helps you handle OAuth flows, store API keys, and refresh access tokens from users (called consumers in Apideck).  ## Base URL  The base URL for all API requests is `https://unify.apideck.com`  ## Get Started  To use the Apideck APIs, you need to sign up for free at [https://app.apideck.com/signup](). Follow the steps below to get started.  - [Create a free account.](https://app.apideck.com/signup) - Go to the [Dashboard](https://app.apideck.com/unify/unified-apis/dashboard). - Get your API key and the application ID. - Select and configure the integrations you want to make available to your users. Through the Unify dashboard, you can configure which connectors you want to support as integrations. - Retrieve the client_id and client_secret for the integration you want to activate (Only needed for OAuth integrations). - Soon, you can skip the previous step and use the Apideck sandbox credentials to get you started instead (upcoming) - Register the redirect URI for the example app (https://unify.apideck.com/vault/callback) in the list of redirect URIs under your app's settings - Use the [publishing guides](/app-listing-requirements) to get your integration listed across app marketplaces.  ### Hosted Vault  Hosted Vault (vault.apideck.com) is a no-code solution, so you don't need to build your own UI to handle the integration settings and authentication.  ![Hosted Vault - Integrations portal](https://github.com/apideck-samples/integration-settings/raw/master/public/img/vault.png)  Behind the scenes, Hosted Vault implements the Vault API endpoints and handles the following features for your customers:  - Add a connection - Handle the OAuth flow - Configure connection settings per integration - Manage connections - Discover and propose integration options - Search for integrations (upcoming) - Give integration suggestions based on provided metadata (email or website) when creating the session (upcoming)  To use Hosted Vault, you will need to first [__create a session__](https://developers.apideck.com/apis/vault/reference#operation/sessionsCreate). This can be achieved by making a POST request to the Vault API to create a valid session for a user, hereafter referred to as the consumer ID.  Example using curl:  ``` curl -X POST https://unify.apideck.com/vault/sessions     -H \"Content-Type: application/json\"     -H \"Authorization: Bearer <your-api-key>\"     -H \"X-APIDECK-CONSUMER-ID: <consumer-id>\"     -H \"X-APIDECK-APP-ID: <application-id>\"     -d '{\"consumer_metadata\": { \"account_name\" : \"Sample\", \"user_name\": \"Sand Box\", \"email\": \"sand@box.com\", \"image\": \"https://unavatar.now.sh/jake\" }, \"theme\": { \"vault_name\": \"Intercom\", \"primary_color\": \"#286efa\", \"sidepanel_background_color\": \"#286efa\",\"sidepanel_text_color\": \"#FFFFFF\", \"favicon\": \"https://res.cloudinary.com/apideck/icons/intercom\" }}' ```  ### Vault API  _Beware, this is strategy takes more time to implement in comparison to Hosted Vault._  If you are building your integration settings UI manually, you can call the Vault API directly.  The Vault API is for those who want to completely white label the in-app integrations overview and authentication experience. All the available endpoints are listed below.  Through the API, your customers authenticate directly in your app, where Vault will still take care of redirecting to the auth provider and back to your app.  If you're already storing access tokens, we will help you migrate through our Vault Migration API (upcoming).  ## Domain model  At its core, a domain model creates a web of interconnected entities.  Our domain model contains five main entity types: Consumer (user, account, team, machine), Application, Connector, Integration, and Connection.  ## Connection state  The connection state is computed based on the connection flow below.  ![](https://developers.apideck.com/api-references/vault/connection-flow.png)  ## Unify and Proxy integration  The only thing you need to use the Unify APIs and Proxy is the consumer id; thereafter, Vault will do the look-up in the background to handle the token injection before performing the API call(s).  ## Headers  Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.  | Name                  | Type    | Required | Description                                                                                                                                                    | | - -- -- -- -- -- -- -- -- -- -- | - -- -- -- | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | x-apideck-app-id      | String  | Yes      | The id of your Unify application. Available at https://app.apideck.com/api-keys.                                                                               | | x-apideck-consumer-id | String  | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app. | | x-apideck-raw         | Boolean | No       | Include raw response. Mostly used for debugging purposes.                                                                                                      |  ## Sandbox (upcoming)  The sandbox is pre-loaded with data similar to a real-life integrations setup. You can use the preconfigured OAauth configured connectors for testing purposes and can skip this step by using the Apideck sandbox credentials to get you started.  ## Guides  - [How to build an integrations UI with Vault](https://github.com/apideck-samples/integration-settings) - How to configure the OAuth credentials for integration providers (COMING SOON)  ## FAQ  **What purpose does Vault serve? Can I just handle the authentication and access token myself?** You can store everything yourself, but that defeats the purpose of using Apideck Unify. Handling tokens for multiple providers can quickly become very complex.  ### Is my data secure?  Vault employs data minimization, therefore only requesting the minimum amount of scopes needed to perform an API request.  ### How do I migrate existing data?  Using our migration API, you can migrate the access tokens and accounts to Apideck Vault. (COMING SOON)  ### Can I use Vault in combination with existing integrations?  Yes, you can. The flexibility of Unify allows you to quickly the use cases you need while keeping a gradual migration path based on your timeline and requirements.  ### How does Vault work for Apideck Ecosystem customers?  Once logged in, pick your ecosystem; on the left-hand side of the screen, you'll have the option to create an application underneath the Unify section.  ### How to integrate Apideck Vault  This section covers everything you need to know to authenticate your customers through Vault. Vault provides **three auth strategies** to use API tokens from your customers:  - Vault API - Hosted Vault - Apideck Ecosystem _(COMING SOON)_  You can also opt to bypass Vault and still take care of authentication flows yourself. Make sure to put the right safeguards in place to protect your customers' tokens and other sensitive data.  ### What auth types does Vault support?  What auth strategies does Vault handle? We currently support three flows so your customers can activate an integration.  #### API keys  For Services supporting the API key strategy, you can use Hosted Vault will need to provide an in-app form where users can configure their API keys provided by the integration service.  #### OAuth 2.0  ##### Authorization Code Grant Type Flow  Vault handles the complete Authorization Code Grant Type Flow for you. This flow only supports browser-based (passive) authentication because most identity providers don't allow entering a username and password to be entered into applications that they don't own.  Certain connectors require an OAuth redirect authentication flow, where the end-user is redirected to the provider's website or mobile app to authenticate.  This is being handled by the `/authorize` endpoint.  #### Basic auth  Basic authentication is a simple authentication scheme built into the HTTP protocol. The required fields to complete basic auth are handled by Hosted Vault or by updating the connection through the Vault API below. 
 *
 * The version of the OpenAPI document: 8.11.0
 * Contact: hello@apideck.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Apideck.Vault.Client.OpenAPIDateConverter;

namespace Apideck.Vault.Model
{
    /// <summary>
    /// Name of Apideck Unified API
    /// </summary>
    /// <value>Name of Apideck Unified API</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnifiedApiId
    {
        /// <summary>
        /// Enum Vault for value: vault
        /// </summary>
        [EnumMember(Value = "vault")]
        Vault = 1,

        /// <summary>
        /// Enum Lead for value: lead
        /// </summary>
        [EnumMember(Value = "lead")]
        Lead = 2,

        /// <summary>
        /// Enum Crm for value: crm
        /// </summary>
        [EnumMember(Value = "crm")]
        Crm = 3,

        /// <summary>
        /// Enum Accounting for value: accounting
        /// </summary>
        [EnumMember(Value = "accounting")]
        Accounting = 4,

        /// <summary>
        /// Enum FileStorage for value: file-storage
        /// </summary>
        [EnumMember(Value = "file-storage")]
        FileStorage = 5,

        /// <summary>
        /// Enum Spreadsheet for value: spreadsheet
        /// </summary>
        [EnumMember(Value = "spreadsheet")]
        Spreadsheet = 6,

        /// <summary>
        /// Enum Email for value: email
        /// </summary>
        [EnumMember(Value = "email")]
        Email = 7,

        /// <summary>
        /// Enum Script for value: script
        /// </summary>
        [EnumMember(Value = "script")]
        Script = 8,

        /// <summary>
        /// Enum Sms for value: sms
        /// </summary>
        [EnumMember(Value = "sms")]
        Sms = 9,

        /// <summary>
        /// Enum TeamMessaging for value: team-messaging
        /// </summary>
        [EnumMember(Value = "team-messaging")]
        TeamMessaging = 10,

        /// <summary>
        /// Enum Ecommerce for value: ecommerce
        /// </summary>
        [EnumMember(Value = "ecommerce")]
        Ecommerce = 11,

        /// <summary>
        /// Enum Payroll for value: payroll
        /// </summary>
        [EnumMember(Value = "payroll")]
        Payroll = 12,

        /// <summary>
        /// Enum CustomerSupport for value: customer-support
        /// </summary>
        [EnumMember(Value = "customer-support")]
        CustomerSupport = 13,

        /// <summary>
        /// Enum TimeRegistration for value: time-registration
        /// </summary>
        [EnumMember(Value = "time-registration")]
        TimeRegistration = 14,

        /// <summary>
        /// Enum TransactionalEmail for value: transactional-email
        /// </summary>
        [EnumMember(Value = "transactional-email")]
        TransactionalEmail = 15,

        /// <summary>
        /// Enum Hcm for value: hcm
        /// </summary>
        [EnumMember(Value = "hcm")]
        Hcm = 16,

        /// <summary>
        /// Enum Form for value: form
        /// </summary>
        [EnumMember(Value = "form")]
        Form = 17,

        /// <summary>
        /// Enum Csp for value: csp
        /// </summary>
        [EnumMember(Value = "csp")]
        Csp = 18,

        /// <summary>
        /// Enum EmailMarketing for value: email-marketing
        /// </summary>
        [EnumMember(Value = "email-marketing")]
        EmailMarketing = 19,

        /// <summary>
        /// Enum Ats for value: ats
        /// </summary>
        [EnumMember(Value = "ats")]
        Ats = 20,

        /// <summary>
        /// Enum Hris for value: hris
        /// </summary>
        [EnumMember(Value = "hris")]
        Hris = 21,

        /// <summary>
        /// Enum Pos for value: pos
        /// </summary>
        [EnumMember(Value = "pos")]
        Pos = 22

    }

}