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
    /// ConsumerWebhook
    /// </summary>
    [DataContract(Name = "ConsumerWebhook")]
    public partial class ConsumerWebhook : IEquatable<ConsumerWebhook>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets UnifiedApi
        /// </summary>
        [DataMember(Name = "unified_api", IsRequired = true, EmitDefaultValue = false)]
        public UnifiedApiId UnifiedApi { get; set; }
        /// <summary>
        /// The status of the webhook.
        /// </summary>
        /// <value>The status of the webhook.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Enabled for value: enabled
            /// </summary>
            [EnumMember(Value = "enabled")]
            Enabled = 1,

            /// <summary>
            /// Enum Disabled for value: disabled
            /// </summary>
            [EnumMember(Value = "disabled")]
            Disabled = 2

        }


        /// <summary>
        /// The status of the webhook.
        /// </summary>
        /// <value>The status of the webhook.</value>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Defines Events
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventsEnum
        {
            /// <summary>
            /// Enum Star for value: *
            /// </summary>
            [EnumMember(Value = "*")]
            Star = 1,

            /// <summary>
            /// Enum CrmActivityCreated for value: crm.activity.created
            /// </summary>
            [EnumMember(Value = "crm.activity.created")]
            CrmActivityCreated = 2,

            /// <summary>
            /// Enum CrmActivityUpdated for value: crm.activity.updated
            /// </summary>
            [EnumMember(Value = "crm.activity.updated")]
            CrmActivityUpdated = 3,

            /// <summary>
            /// Enum CrmActivityDeleted for value: crm.activity.deleted
            /// </summary>
            [EnumMember(Value = "crm.activity.deleted")]
            CrmActivityDeleted = 4,

            /// <summary>
            /// Enum CrmCompanyCreated for value: crm.company.created
            /// </summary>
            [EnumMember(Value = "crm.company.created")]
            CrmCompanyCreated = 5,

            /// <summary>
            /// Enum CrmCompanyUpdated for value: crm.company.updated
            /// </summary>
            [EnumMember(Value = "crm.company.updated")]
            CrmCompanyUpdated = 6,

            /// <summary>
            /// Enum CrmCompanyDeleted for value: crm.company.deleted
            /// </summary>
            [EnumMember(Value = "crm.company.deleted")]
            CrmCompanyDeleted = 7,

            /// <summary>
            /// Enum CrmContactCreated for value: crm.contact.created
            /// </summary>
            [EnumMember(Value = "crm.contact.created")]
            CrmContactCreated = 8,

            /// <summary>
            /// Enum CrmContactUpdated for value: crm.contact.updated
            /// </summary>
            [EnumMember(Value = "crm.contact.updated")]
            CrmContactUpdated = 9,

            /// <summary>
            /// Enum CrmContactDeleted for value: crm.contact.deleted
            /// </summary>
            [EnumMember(Value = "crm.contact.deleted")]
            CrmContactDeleted = 10,

            /// <summary>
            /// Enum CrmLeadCreated for value: crm.lead.created
            /// </summary>
            [EnumMember(Value = "crm.lead.created")]
            CrmLeadCreated = 11,

            /// <summary>
            /// Enum CrmLeadUpdated for value: crm.lead.updated
            /// </summary>
            [EnumMember(Value = "crm.lead.updated")]
            CrmLeadUpdated = 12,

            /// <summary>
            /// Enum CrmLeadDeleted for value: crm.lead.deleted
            /// </summary>
            [EnumMember(Value = "crm.lead.deleted")]
            CrmLeadDeleted = 13,

            /// <summary>
            /// Enum CrmNoteCreated for value: crm.note.created
            /// </summary>
            [EnumMember(Value = "crm.note.created")]
            CrmNoteCreated = 14,

            /// <summary>
            /// Enum CrmNotesUpdated for value: crm.notes.updated
            /// </summary>
            [EnumMember(Value = "crm.notes.updated")]
            CrmNotesUpdated = 15,

            /// <summary>
            /// Enum CrmNotesDeleted for value: crm.notes.deleted
            /// </summary>
            [EnumMember(Value = "crm.notes.deleted")]
            CrmNotesDeleted = 16,

            /// <summary>
            /// Enum CrmOpportunityCreated for value: crm.opportunity.created
            /// </summary>
            [EnumMember(Value = "crm.opportunity.created")]
            CrmOpportunityCreated = 17,

            /// <summary>
            /// Enum CrmOpportunityUpdated for value: crm.opportunity.updated
            /// </summary>
            [EnumMember(Value = "crm.opportunity.updated")]
            CrmOpportunityUpdated = 18,

            /// <summary>
            /// Enum CrmOpportunityDeleted for value: crm.opportunity.deleted
            /// </summary>
            [EnumMember(Value = "crm.opportunity.deleted")]
            CrmOpportunityDeleted = 19,

            /// <summary>
            /// Enum LeadLeadCreated for value: lead.lead.created
            /// </summary>
            [EnumMember(Value = "lead.lead.created")]
            LeadLeadCreated = 20,

            /// <summary>
            /// Enum LeadLeadUpdated for value: lead.lead.updated
            /// </summary>
            [EnumMember(Value = "lead.lead.updated")]
            LeadLeadUpdated = 21,

            /// <summary>
            /// Enum LeadLeadDeleted for value: lead.lead.deleted
            /// </summary>
            [EnumMember(Value = "lead.lead.deleted")]
            LeadLeadDeleted = 22,

            /// <summary>
            /// Enum VaultConnectionCreated for value: vault.connection.created
            /// </summary>
            [EnumMember(Value = "vault.connection.created")]
            VaultConnectionCreated = 23,

            /// <summary>
            /// Enum VaultConnectionUpdated for value: vault.connection.updated
            /// </summary>
            [EnumMember(Value = "vault.connection.updated")]
            VaultConnectionUpdated = 24,

            /// <summary>
            /// Enum VaultConnectionDeleted for value: vault.connection.deleted
            /// </summary>
            [EnumMember(Value = "vault.connection.deleted")]
            VaultConnectionDeleted = 25,

            /// <summary>
            /// Enum VaultConnectionCallable for value: vault.connection.callable
            /// </summary>
            [EnumMember(Value = "vault.connection.callable")]
            VaultConnectionCallable = 26,

            /// <summary>
            /// Enum AtsJobCreated for value: ats.job.created
            /// </summary>
            [EnumMember(Value = "ats.job.created")]
            AtsJobCreated = 27,

            /// <summary>
            /// Enum AtsJobUpdated for value: ats.job.updated
            /// </summary>
            [EnumMember(Value = "ats.job.updated")]
            AtsJobUpdated = 28,

            /// <summary>
            /// Enum AtsJobDeleted for value: ats.job.deleted
            /// </summary>
            [EnumMember(Value = "ats.job.deleted")]
            AtsJobDeleted = 29,

            /// <summary>
            /// Enum AtsApplicantCreated for value: ats.applicant.created
            /// </summary>
            [EnumMember(Value = "ats.applicant.created")]
            AtsApplicantCreated = 30,

            /// <summary>
            /// Enum AtsApplicantUpdated for value: ats.applicant.updated
            /// </summary>
            [EnumMember(Value = "ats.applicant.updated")]
            AtsApplicantUpdated = 31,

            /// <summary>
            /// Enum AtsApplicantDeleted for value: ats.applicant.deleted
            /// </summary>
            [EnumMember(Value = "ats.applicant.deleted")]
            AtsApplicantDeleted = 32,

            /// <summary>
            /// Enum PosOrderCreated for value: pos.order.created
            /// </summary>
            [EnumMember(Value = "pos.order.created")]
            PosOrderCreated = 33,

            /// <summary>
            /// Enum PosOrderUpdated for value: pos.order.updated
            /// </summary>
            [EnumMember(Value = "pos.order.updated")]
            PosOrderUpdated = 34,

            /// <summary>
            /// Enum PosOrderDeleted for value: pos.order.deleted
            /// </summary>
            [EnumMember(Value = "pos.order.deleted")]
            PosOrderDeleted = 35

        }



        /// <summary>
        /// The list of subscribed events for this webhook. [&#x60;*&#x60;] indicates that all events are enabled.
        /// </summary>
        /// <value>The list of subscribed events for this webhook. [&#x60;*&#x60;] indicates that all events are enabled.</value>
        [DataMember(Name = "events", IsRequired = true, EmitDefaultValue = false)]
        public List<EventsEnum> Events { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumerWebhook" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ConsumerWebhook() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumerWebhook" /> class.
        /// </summary>
        /// <param name="description">description.</param>
        /// <param name="unifiedApi">unifiedApi (required).</param>
        /// <param name="status">The status of the webhook. (required).</param>
        /// <param name="deliveryUrl">The delivery url of the webhook endpoint. (required).</param>
        /// <param name="events">The list of subscribed events for this webhook. [&#x60;*&#x60;] indicates that all events are enabled. (required).</param>
        public ConsumerWebhook(string description = default(string), UnifiedApiId unifiedApi = default(UnifiedApiId), StatusEnum status = default(StatusEnum), string deliveryUrl = default(string), List<EventsEnum> events = default(List<EventsEnum>))
        {
            this.UnifiedApi = unifiedApi;
            this.Status = status;
            // to ensure "deliveryUrl" is required (not null)
            if (deliveryUrl == null) {
                throw new ArgumentNullException("deliveryUrl is a required property for ConsumerWebhook and cannot be null");
            }
            this.DeliveryUrl = deliveryUrl;
            // to ensure "events" is required (not null)
            if (events == null) {
                throw new ArgumentNullException("events is a required property for ConsumerWebhook and cannot be null");
            }
            this.Events = events;
            this.Description = description;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// The delivery url of the webhook endpoint.
        /// </summary>
        /// <value>The delivery url of the webhook endpoint.</value>
        [DataMember(Name = "delivery_url", IsRequired = true, EmitDefaultValue = false)]
        public string DeliveryUrl { get; set; }

        /// <summary>
        /// The Unify Base URL events from connectors will be sent to after service id is appended.
        /// </summary>
        /// <value>The Unify Base URL events from connectors will be sent to after service id is appended.</value>
        [DataMember(Name = "execute_base_url", IsRequired = true, EmitDefaultValue = false)]
        public string ExecuteBaseUrl { get; private set; }

        /// <summary>
        /// Returns false as ExecuteBaseUrl should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeExecuteBaseUrl()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updated_at", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Returns false as UpdatedAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeUpdatedAt()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Returns false as CreatedAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCreatedAt()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConsumerWebhook {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  UnifiedApi: ").Append(UnifiedApi).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  DeliveryUrl: ").Append(DeliveryUrl).Append("\n");
            sb.Append("  ExecuteBaseUrl: ").Append(ExecuteBaseUrl).Append("\n");
            sb.Append("  Events: ").Append(Events).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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
            return this.Equals(input as ConsumerWebhook);
        }

        /// <summary>
        /// Returns true if ConsumerWebhook instances are equal
        /// </summary>
        /// <param name="input">Instance of ConsumerWebhook to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConsumerWebhook input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.UnifiedApi == input.UnifiedApi ||
                    this.UnifiedApi.Equals(input.UnifiedApi)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.DeliveryUrl == input.DeliveryUrl ||
                    (this.DeliveryUrl != null &&
                    this.DeliveryUrl.Equals(input.DeliveryUrl))
                ) && 
                (
                    this.ExecuteBaseUrl == input.ExecuteBaseUrl ||
                    (this.ExecuteBaseUrl != null &&
                    this.ExecuteBaseUrl.Equals(input.ExecuteBaseUrl))
                ) && 
                (
                    this.Events == input.Events ||
                    this.Events.SequenceEqual(input.Events)
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UnifiedApi.GetHashCode();
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                if (this.DeliveryUrl != null)
                {
                    hashCode = (hashCode * 59) + this.DeliveryUrl.GetHashCode();
                }
                if (this.ExecuteBaseUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ExecuteBaseUrl.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Events.GetHashCode();
                if (this.UpdatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                }
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
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
            // DeliveryUrl (string) pattern
            Regex regexDeliveryUrl = new Regex(@"^(https?):\/\/", RegexOptions.CultureInvariant);
            if (false == regexDeliveryUrl.Match(this.DeliveryUrl).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DeliveryUrl, must match a pattern of " + regexDeliveryUrl, new [] { "DeliveryUrl" });
            }

            // ExecuteBaseUrl (string) pattern
            Regex regexExecuteBaseUrl = new Regex(@"^(https?):\/\/", RegexOptions.CultureInvariant);
            if (false == regexExecuteBaseUrl.Match(this.ExecuteBaseUrl).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ExecuteBaseUrl, must match a pattern of " + regexExecuteBaseUrl, new [] { "ExecuteBaseUrl" });
            }

            yield break;
        }
    }

}
