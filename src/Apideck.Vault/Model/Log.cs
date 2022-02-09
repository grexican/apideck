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
    /// Log
    /// </summary>
    [DataContract(Name = "Log")]
    public partial class Log : IEquatable<Log>, IValidatableObject
    {
        /// <summary>
        /// Which Unified Api request was made to.
        /// </summary>
        /// <value>Which Unified Api request was made to.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UnifiedApiEnum
        {
            /// <summary>
            /// Enum Crm for value: crm
            /// </summary>
            [EnumMember(Value = "crm")]
            Crm = 1,

            /// <summary>
            /// Enum Lead for value: lead
            /// </summary>
            [EnumMember(Value = "lead")]
            Lead = 2,

            /// <summary>
            /// Enum Proxy for value: proxy
            /// </summary>
            [EnumMember(Value = "proxy")]
            Proxy = 3,

            /// <summary>
            /// Enum Vault for value: vault
            /// </summary>
            [EnumMember(Value = "vault")]
            Vault = 4,

            /// <summary>
            /// Enum Accounting for value: accounting
            /// </summary>
            [EnumMember(Value = "accounting")]
            Accounting = 5

        }


        /// <summary>
        /// Which Unified Api request was made to.
        /// </summary>
        /// <value>Which Unified Api request was made to.</value>
        [DataMember(Name = "unified_api", IsRequired = true, EmitDefaultValue = false)]
        public UnifiedApiEnum UnifiedApi { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Log" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Log() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Log" /> class.
        /// </summary>
        /// <param name="apiStyle">Indicates if the request was made via REST or Graphql endpoint. (required).</param>
        /// <param name="baseUrl">The Apideck base URL the request was made to. (required).</param>
        /// <param name="childRequest">Indicates whether or not this is a child or parent request. (required).</param>
        /// <param name="consumerId">The consumer Id associated with the request. (required).</param>
        /// <param name="duration">The entire execution time in milliseconds it took to call the Apideck service provider. (required).</param>
        /// <param name="errorMessage">If error occurred, this is brief explanation.</param>
        /// <param name="execution">The entire execution time in milliseconds it took to make the request. (required).</param>
        /// <param name="hasChildren">When request is a parent request, this indicates if there are child requests associated. (required).</param>
        /// <param name="httpMethod">HTTP Method of request. (required).</param>
        /// <param name="id">UUID acting as Request Identifier. (required).</param>
        /// <param name="latency">Latency added by making this request via Unified Api. (required).</param>
        /// <param name="operation">operation (required).</param>
        /// <param name="parentId">When request is a child request, this UUID indicates it&#39;s parent request. (required).</param>
        /// <param name="path">The path component of the URI the request was made to. (required).</param>
        /// <param name="sandbox">Indicates whether the request was made using Apidecks sandbox credentials or not. (required).</param>
        /// <param name="service">service (required).</param>
        /// <param name="sourceIp">The IP address of the source of the request..</param>
        /// <param name="statusCode">HTTP Status code that was returned. (required).</param>
        /// <param name="success">Whether or not the request was successful. (required).</param>
        /// <param name="timestamp">ISO Date and time when the request was made. (required).</param>
        /// <param name="unifiedApi">Which Unified Api request was made to. (required).</param>
        public Log(string apiStyle = default(string), string baseUrl = default(string), bool childRequest = default(bool), string consumerId = default(string), decimal duration = default(decimal), string errorMessage = default(string), int execution = default(int), bool hasChildren = default(bool), string httpMethod = default(string), string id = default(string), decimal latency = default(decimal), LogOperation operation = default(LogOperation), string parentId = default(string), string path = default(string), bool sandbox = default(bool), LogService service = default(LogService), string sourceIp = default(string), int statusCode = default(int), bool success = default(bool), string timestamp = default(string), UnifiedApiEnum unifiedApi = default(UnifiedApiEnum))
        {
            // to ensure "apiStyle" is required (not null)
            if (apiStyle == null) {
                throw new ArgumentNullException("apiStyle is a required property for Log and cannot be null");
            }
            this.ApiStyle = apiStyle;
            // to ensure "baseUrl" is required (not null)
            if (baseUrl == null) {
                throw new ArgumentNullException("baseUrl is a required property for Log and cannot be null");
            }
            this.BaseUrl = baseUrl;
            this.ChildRequest = childRequest;
            // to ensure "consumerId" is required (not null)
            if (consumerId == null) {
                throw new ArgumentNullException("consumerId is a required property for Log and cannot be null");
            }
            this.ConsumerId = consumerId;
            this.Duration = duration;
            this.Execution = execution;
            this.HasChildren = hasChildren;
            // to ensure "httpMethod" is required (not null)
            if (httpMethod == null) {
                throw new ArgumentNullException("httpMethod is a required property for Log and cannot be null");
            }
            this.HttpMethod = httpMethod;
            // to ensure "id" is required (not null)
            if (id == null) {
                throw new ArgumentNullException("id is a required property for Log and cannot be null");
            }
            this.Id = id;
            this.Latency = latency;
            // to ensure "operation" is required (not null)
            if (operation == null) {
                throw new ArgumentNullException("operation is a required property for Log and cannot be null");
            }
            this.Operation = operation;
            // to ensure "parentId" is required (not null)
            if (parentId == null) {
                throw new ArgumentNullException("parentId is a required property for Log and cannot be null");
            }
            this.ParentId = parentId;
            // to ensure "path" is required (not null)
            if (path == null) {
                throw new ArgumentNullException("path is a required property for Log and cannot be null");
            }
            this.Path = path;
            this.Sandbox = sandbox;
            // to ensure "service" is required (not null)
            if (service == null) {
                throw new ArgumentNullException("service is a required property for Log and cannot be null");
            }
            this.Service = service;
            this.StatusCode = statusCode;
            this.Success = success;
            // to ensure "timestamp" is required (not null)
            if (timestamp == null) {
                throw new ArgumentNullException("timestamp is a required property for Log and cannot be null");
            }
            this.Timestamp = timestamp;
            this.UnifiedApi = unifiedApi;
            this.ErrorMessage = errorMessage;
            this.SourceIp = sourceIp;
        }

        /// <summary>
        /// Indicates if the request was made via REST or Graphql endpoint.
        /// </summary>
        /// <value>Indicates if the request was made via REST or Graphql endpoint.</value>
        [DataMember(Name = "api_style", IsRequired = true, EmitDefaultValue = false)]
        public string ApiStyle { get; set; }

        /// <summary>
        /// The Apideck base URL the request was made to.
        /// </summary>
        /// <value>The Apideck base URL the request was made to.</value>
        [DataMember(Name = "base_url", IsRequired = true, EmitDefaultValue = false)]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Indicates whether or not this is a child or parent request.
        /// </summary>
        /// <value>Indicates whether or not this is a child or parent request.</value>
        [DataMember(Name = "child_request", IsRequired = true, EmitDefaultValue = true)]
        public bool ChildRequest { get; set; }

        /// <summary>
        /// The consumer Id associated with the request.
        /// </summary>
        /// <value>The consumer Id associated with the request.</value>
        [DataMember(Name = "consumer_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConsumerId { get; set; }

        /// <summary>
        /// The entire execution time in milliseconds it took to call the Apideck service provider.
        /// </summary>
        /// <value>The entire execution time in milliseconds it took to call the Apideck service provider.</value>
        [DataMember(Name = "duration", IsRequired = true, EmitDefaultValue = false)]
        public decimal Duration { get; set; }

        /// <summary>
        /// If error occurred, this is brief explanation
        /// </summary>
        /// <value>If error occurred, this is brief explanation</value>
        [DataMember(Name = "error_message", EmitDefaultValue = true)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The entire execution time in milliseconds it took to make the request.
        /// </summary>
        /// <value>The entire execution time in milliseconds it took to make the request.</value>
        [DataMember(Name = "execution", IsRequired = true, EmitDefaultValue = false)]
        public int Execution { get; set; }

        /// <summary>
        /// When request is a parent request, this indicates if there are child requests associated.
        /// </summary>
        /// <value>When request is a parent request, this indicates if there are child requests associated.</value>
        [DataMember(Name = "has_children", IsRequired = true, EmitDefaultValue = true)]
        public bool HasChildren { get; set; }

        /// <summary>
        /// HTTP Method of request.
        /// </summary>
        /// <value>HTTP Method of request.</value>
        [DataMember(Name = "http_method", IsRequired = true, EmitDefaultValue = false)]
        public string HttpMethod { get; set; }

        /// <summary>
        /// UUID acting as Request Identifier.
        /// </summary>
        /// <value>UUID acting as Request Identifier.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Latency added by making this request via Unified Api.
        /// </summary>
        /// <value>Latency added by making this request via Unified Api.</value>
        [DataMember(Name = "latency", IsRequired = true, EmitDefaultValue = false)]
        public decimal Latency { get; set; }

        /// <summary>
        /// Gets or Sets Operation
        /// </summary>
        [DataMember(Name = "operation", IsRequired = true, EmitDefaultValue = false)]
        public LogOperation Operation { get; set; }

        /// <summary>
        /// When request is a child request, this UUID indicates it&#39;s parent request.
        /// </summary>
        /// <value>When request is a child request, this UUID indicates it&#39;s parent request.</value>
        [DataMember(Name = "parent_id", IsRequired = true, EmitDefaultValue = true)]
        public string ParentId { get; set; }

        /// <summary>
        /// The path component of the URI the request was made to.
        /// </summary>
        /// <value>The path component of the URI the request was made to.</value>
        [DataMember(Name = "path", IsRequired = true, EmitDefaultValue = false)]
        public string Path { get; set; }

        /// <summary>
        /// Indicates whether the request was made using Apidecks sandbox credentials or not.
        /// </summary>
        /// <value>Indicates whether the request was made using Apidecks sandbox credentials or not.</value>
        [DataMember(Name = "sandbox", IsRequired = true, EmitDefaultValue = true)]
        public bool Sandbox { get; set; }

        /// <summary>
        /// Gets or Sets Service
        /// </summary>
        [DataMember(Name = "service", IsRequired = true, EmitDefaultValue = false)]
        public LogService Service { get; set; }

        /// <summary>
        /// The IP address of the source of the request.
        /// </summary>
        /// <value>The IP address of the source of the request.</value>
        [DataMember(Name = "source_ip", EmitDefaultValue = true)]
        public string SourceIp { get; set; }

        /// <summary>
        /// HTTP Status code that was returned.
        /// </summary>
        /// <value>HTTP Status code that was returned.</value>
        [DataMember(Name = "status_code", IsRequired = true, EmitDefaultValue = false)]
        public int StatusCode { get; set; }

        /// <summary>
        /// Whether or not the request was successful.
        /// </summary>
        /// <value>Whether or not the request was successful.</value>
        [DataMember(Name = "success", IsRequired = true, EmitDefaultValue = true)]
        public bool Success { get; set; }

        /// <summary>
        /// ISO Date and time when the request was made.
        /// </summary>
        /// <value>ISO Date and time when the request was made.</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public string Timestamp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Log {\n");
            sb.Append("  ApiStyle: ").Append(ApiStyle).Append("\n");
            sb.Append("  BaseUrl: ").Append(BaseUrl).Append("\n");
            sb.Append("  ChildRequest: ").Append(ChildRequest).Append("\n");
            sb.Append("  ConsumerId: ").Append(ConsumerId).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  ErrorMessage: ").Append(ErrorMessage).Append("\n");
            sb.Append("  Execution: ").Append(Execution).Append("\n");
            sb.Append("  HasChildren: ").Append(HasChildren).Append("\n");
            sb.Append("  HttpMethod: ").Append(HttpMethod).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Latency: ").Append(Latency).Append("\n");
            sb.Append("  Operation: ").Append(Operation).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Sandbox: ").Append(Sandbox).Append("\n");
            sb.Append("  Service: ").Append(Service).Append("\n");
            sb.Append("  SourceIp: ").Append(SourceIp).Append("\n");
            sb.Append("  StatusCode: ").Append(StatusCode).Append("\n");
            sb.Append("  Success: ").Append(Success).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  UnifiedApi: ").Append(UnifiedApi).Append("\n");
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
            return this.Equals(input as Log);
        }

        /// <summary>
        /// Returns true if Log instances are equal
        /// </summary>
        /// <param name="input">Instance of Log to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Log input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ApiStyle == input.ApiStyle ||
                    (this.ApiStyle != null &&
                    this.ApiStyle.Equals(input.ApiStyle))
                ) && 
                (
                    this.BaseUrl == input.BaseUrl ||
                    (this.BaseUrl != null &&
                    this.BaseUrl.Equals(input.BaseUrl))
                ) && 
                (
                    this.ChildRequest == input.ChildRequest ||
                    this.ChildRequest.Equals(input.ChildRequest)
                ) && 
                (
                    this.ConsumerId == input.ConsumerId ||
                    (this.ConsumerId != null &&
                    this.ConsumerId.Equals(input.ConsumerId))
                ) && 
                (
                    this.Duration == input.Duration ||
                    this.Duration.Equals(input.Duration)
                ) && 
                (
                    this.ErrorMessage == input.ErrorMessage ||
                    (this.ErrorMessage != null &&
                    this.ErrorMessage.Equals(input.ErrorMessage))
                ) && 
                (
                    this.Execution == input.Execution ||
                    this.Execution.Equals(input.Execution)
                ) && 
                (
                    this.HasChildren == input.HasChildren ||
                    this.HasChildren.Equals(input.HasChildren)
                ) && 
                (
                    this.HttpMethod == input.HttpMethod ||
                    (this.HttpMethod != null &&
                    this.HttpMethod.Equals(input.HttpMethod))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Latency == input.Latency ||
                    this.Latency.Equals(input.Latency)
                ) && 
                (
                    this.Operation == input.Operation ||
                    (this.Operation != null &&
                    this.Operation.Equals(input.Operation))
                ) && 
                (
                    this.ParentId == input.ParentId ||
                    (this.ParentId != null &&
                    this.ParentId.Equals(input.ParentId))
                ) && 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.Sandbox == input.Sandbox ||
                    this.Sandbox.Equals(input.Sandbox)
                ) && 
                (
                    this.Service == input.Service ||
                    (this.Service != null &&
                    this.Service.Equals(input.Service))
                ) && 
                (
                    this.SourceIp == input.SourceIp ||
                    (this.SourceIp != null &&
                    this.SourceIp.Equals(input.SourceIp))
                ) && 
                (
                    this.StatusCode == input.StatusCode ||
                    this.StatusCode.Equals(input.StatusCode)
                ) && 
                (
                    this.Success == input.Success ||
                    this.Success.Equals(input.Success)
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.UnifiedApi == input.UnifiedApi ||
                    this.UnifiedApi.Equals(input.UnifiedApi)
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
                if (this.ApiStyle != null)
                {
                    hashCode = (hashCode * 59) + this.ApiStyle.GetHashCode();
                }
                if (this.BaseUrl != null)
                {
                    hashCode = (hashCode * 59) + this.BaseUrl.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChildRequest.GetHashCode();
                if (this.ConsumerId != null)
                {
                    hashCode = (hashCode * 59) + this.ConsumerId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Duration.GetHashCode();
                if (this.ErrorMessage != null)
                {
                    hashCode = (hashCode * 59) + this.ErrorMessage.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Execution.GetHashCode();
                hashCode = (hashCode * 59) + this.HasChildren.GetHashCode();
                if (this.HttpMethod != null)
                {
                    hashCode = (hashCode * 59) + this.HttpMethod.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Latency.GetHashCode();
                if (this.Operation != null)
                {
                    hashCode = (hashCode * 59) + this.Operation.GetHashCode();
                }
                if (this.ParentId != null)
                {
                    hashCode = (hashCode * 59) + this.ParentId.GetHashCode();
                }
                if (this.Path != null)
                {
                    hashCode = (hashCode * 59) + this.Path.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Sandbox.GetHashCode();
                if (this.Service != null)
                {
                    hashCode = (hashCode * 59) + this.Service.GetHashCode();
                }
                if (this.SourceIp != null)
                {
                    hashCode = (hashCode * 59) + this.SourceIp.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.StatusCode.GetHashCode();
                hashCode = (hashCode * 59) + this.Success.GetHashCode();
                if (this.Timestamp != null)
                {
                    hashCode = (hashCode * 59) + this.Timestamp.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UnifiedApi.GetHashCode();
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
