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
    /// SessionSettings
    /// </summary>
    [DataContract(Name = "Session_settings")]
    public partial class SessionSettings : IEquatable<SessionSettings>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionSettings" /> class.
        /// </summary>
        /// <param name="unifiedApis">Provide the IDs of the Unified APIs you want to be visible. Leaving it empty or omiting this field will show all Unified APIs..</param>
        /// <param name="hideResourceSettings">hideResourceSettings (default to false).</param>
        /// <param name="sandboxMode">Configure [Vault](/apis/vault/reference#section/Get-Started) to show a banner informing the logged in user is in a test environment. (default to false).</param>
        /// <param name="isolationMode">Configure [Vault](/apis/vault/reference#section/Get-Started) to run in isolation mode, meaning it only shows the connection settings and hides the navigation items. (default to false).</param>
        /// <param name="sessionLength">The duration of time the session is valid for (maximum 1 week). (default to &quot;1h&quot;).</param>
        /// <param name="showLogs">Configure [Vault](/apis/vault/reference#section/Get-Started) to show the logs page. Defaults to &#x60;true&#x60;. (default to true).</param>
        /// <param name="showSuggestions">Configure [Vault](/apis/vault/reference#section/Get-Started) to show the suggestions page. Defaults to &#x60;true&#x60;. (default to false).</param>
        /// <param name="autoRedirect">Automatically redirect to redirect uri after the connection has been configured as callable. Defaults to &#x60;false&#x60;. (default to false).</param>
        public SessionSettings(List<UnifiedApiId> unifiedApis = default(List<UnifiedApiId>), bool hideResourceSettings = false, bool sandboxMode = false, bool isolationMode = false, string sessionLength = "1h", bool showLogs = true, bool showSuggestions = false, bool autoRedirect = false)
        {
            this.UnifiedApis = unifiedApis;
            this.HideResourceSettings = hideResourceSettings;
            this.SandboxMode = sandboxMode;
            this.IsolationMode = isolationMode;
            // use default value if no "sessionLength" provided
            this.SessionLength = sessionLength ?? "1h";
            this.ShowLogs = showLogs;
            this.ShowSuggestions = showSuggestions;
            this.AutoRedirect = autoRedirect;
        }

        /// <summary>
        /// Provide the IDs of the Unified APIs you want to be visible. Leaving it empty or omiting this field will show all Unified APIs.
        /// </summary>
        /// <value>Provide the IDs of the Unified APIs you want to be visible. Leaving it empty or omiting this field will show all Unified APIs.</value>
        [DataMember(Name = "unified_apis", EmitDefaultValue = false)]
        public List<UnifiedApiId> UnifiedApis { get; set; }

        /// <summary>
        /// Gets or Sets HideResourceSettings
        /// </summary>
        [DataMember(Name = "hide_resource_settings", EmitDefaultValue = true)]
        public bool HideResourceSettings { get; set; }

        /// <summary>
        /// Configure [Vault](/apis/vault/reference#section/Get-Started) to show a banner informing the logged in user is in a test environment.
        /// </summary>
        /// <value>Configure [Vault](/apis/vault/reference#section/Get-Started) to show a banner informing the logged in user is in a test environment.</value>
        [DataMember(Name = "sandbox_mode", EmitDefaultValue = true)]
        public bool SandboxMode { get; set; }

        /// <summary>
        /// Configure [Vault](/apis/vault/reference#section/Get-Started) to run in isolation mode, meaning it only shows the connection settings and hides the navigation items.
        /// </summary>
        /// <value>Configure [Vault](/apis/vault/reference#section/Get-Started) to run in isolation mode, meaning it only shows the connection settings and hides the navigation items.</value>
        [DataMember(Name = "isolation_mode", EmitDefaultValue = true)]
        public bool IsolationMode { get; set; }

        /// <summary>
        /// The duration of time the session is valid for (maximum 1 week).
        /// </summary>
        /// <value>The duration of time the session is valid for (maximum 1 week).</value>
        [DataMember(Name = "session_length", EmitDefaultValue = false)]
        public string SessionLength { get; set; }

        /// <summary>
        /// Configure [Vault](/apis/vault/reference#section/Get-Started) to show the logs page. Defaults to &#x60;true&#x60;.
        /// </summary>
        /// <value>Configure [Vault](/apis/vault/reference#section/Get-Started) to show the logs page. Defaults to &#x60;true&#x60;.</value>
        [DataMember(Name = "show_logs", EmitDefaultValue = true)]
        public bool ShowLogs { get; set; }

        /// <summary>
        /// Configure [Vault](/apis/vault/reference#section/Get-Started) to show the suggestions page. Defaults to &#x60;true&#x60;.
        /// </summary>
        /// <value>Configure [Vault](/apis/vault/reference#section/Get-Started) to show the suggestions page. Defaults to &#x60;true&#x60;.</value>
        [DataMember(Name = "show_suggestions", EmitDefaultValue = true)]
        public bool ShowSuggestions { get; set; }

        /// <summary>
        /// Automatically redirect to redirect uri after the connection has been configured as callable. Defaults to &#x60;false&#x60;.
        /// </summary>
        /// <value>Automatically redirect to redirect uri after the connection has been configured as callable. Defaults to &#x60;false&#x60;.</value>
        [DataMember(Name = "auto_redirect", EmitDefaultValue = true)]
        public bool AutoRedirect { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SessionSettings {\n");
            sb.Append("  UnifiedApis: ").Append(UnifiedApis).Append("\n");
            sb.Append("  HideResourceSettings: ").Append(HideResourceSettings).Append("\n");
            sb.Append("  SandboxMode: ").Append(SandboxMode).Append("\n");
            sb.Append("  IsolationMode: ").Append(IsolationMode).Append("\n");
            sb.Append("  SessionLength: ").Append(SessionLength).Append("\n");
            sb.Append("  ShowLogs: ").Append(ShowLogs).Append("\n");
            sb.Append("  ShowSuggestions: ").Append(ShowSuggestions).Append("\n");
            sb.Append("  AutoRedirect: ").Append(AutoRedirect).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as SessionSettings);
        }

        /// <summary>
        /// Returns true if SessionSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of SessionSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SessionSettings input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.UnifiedApis == input.UnifiedApis ||
                    this.UnifiedApis != null &&
                    input.UnifiedApis != null &&
                    this.UnifiedApis.SequenceEqual(input.UnifiedApis)
                ) && 
                (
                    this.HideResourceSettings == input.HideResourceSettings ||
                    this.HideResourceSettings.Equals(input.HideResourceSettings)
                ) && 
                (
                    this.SandboxMode == input.SandboxMode ||
                    this.SandboxMode.Equals(input.SandboxMode)
                ) && 
                (
                    this.IsolationMode == input.IsolationMode ||
                    this.IsolationMode.Equals(input.IsolationMode)
                ) && 
                (
                    this.SessionLength == input.SessionLength ||
                    (this.SessionLength != null &&
                    this.SessionLength.Equals(input.SessionLength))
                ) && 
                (
                    this.ShowLogs == input.ShowLogs ||
                    this.ShowLogs.Equals(input.ShowLogs)
                ) && 
                (
                    this.ShowSuggestions == input.ShowSuggestions ||
                    this.ShowSuggestions.Equals(input.ShowSuggestions)
                ) && 
                (
                    this.AutoRedirect == input.AutoRedirect ||
                    this.AutoRedirect.Equals(input.AutoRedirect)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.UnifiedApis != null)
                {
                    hashCode = (hashCode * 59) + this.UnifiedApis.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.HideResourceSettings.GetHashCode();
                hashCode = (hashCode * 59) + this.SandboxMode.GetHashCode();
                hashCode = (hashCode * 59) + this.IsolationMode.GetHashCode();
                if (this.SessionLength != null)
                {
                    hashCode = (hashCode * 59) + this.SessionLength.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ShowLogs.GetHashCode();
                hashCode = (hashCode * 59) + this.ShowSuggestions.GetHashCode();
                hashCode = (hashCode * 59) + this.AutoRedirect.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
