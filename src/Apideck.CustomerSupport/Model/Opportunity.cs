/*
 * Customer Support
 *
 * Welcome to the Customer Support.  You can use this API to access all Customer Support endpoints.  ## Base URL  The base URL for all API requests is `https://unify.apideck.com`  ## GraphQL  Use the [GraphQL playground](https://developers.apideck.com/graphql/playground) to test out the GraphQL API.  ## Headers  Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.  | Name                  | Type    | Required | Description                                                                                                                                                    | | - -- -- -- -- -- -- -- -- -- -- | - -- -- -- | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | x-apideck-consumer-id | String  | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app. | | x-apideck-service-id  | String  | No       | Describe the service you want to call (e.g., pipedrive). Only needed when a customer has activated multiple integrations for the same Unified API.             | | x-apideck-raw         | Boolean | No       | Include raw response. Mostly used for debugging purposes.                                                                                                      | | x-apideck-app-id      | String  | Yes      | The application id of your Unify application. Available at https://app.apideck.com/unify/api-keys.                                                             | | Authorization         | String  | Yes      | Bearer API KEY                                                                                                                                                 |  ## Authorization  You can interact with the API through the authorization methods below.  <!- - ReDoc-Inject: <security-definitions> - ->  ## Pagination  All API resources have support for bulk retrieval via list APIs.  Apideck uses cursor-based pagination via the optional `cursor` and `limit` parameters.  To fetch the first page of results, call the list API without a `cursor` parameter. Afterwards you can fetch subsequent pages by providing a cursor parameter. You will find the next cursor in the response body in `meta.cursors.next`. If `meta.cursors.next` is `null` you're at the end of the list.  In the REST API you can also use the `links` from the response for added convenience. Simply call the URL in `links.next` to get the next page of results.  ### Query Parameters  | Name   | Type   | Required | Description                                                                                                        | | - -- -- - | - -- -- - | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | cursor | String | No       | Cursor to start from. You can find cursors for next & previous pages in the meta.cursors property of the response. | | limit  | Number | No       | Number of results to return. Minimum 1, Maximum 200, Default 20                                                    |  ### Response Body  | Name                  | Type   | Description                                                        | | - -- -- -- -- -- -- -- -- -- -- | - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | meta.cursors.previous | String | Cursor to navigate to the previous page of results through the API | | meta.cursors.current  | String | Cursor to navigate to the current page of results through the API  | | meta.cursors.next     | String | Cursor to navigate to the next page of results through the API     | | meta.items_on_page    | Number | Number of items returned in the data property of the response      | | links.previous        | String | Link to navigate to the previous page of results through the API   | | links.current         | String | Link to navigate to the current page of results through the API    | | links.next            | String | Link to navigate to the next page of results through the API       |  ⚠️ `meta.cursors.previous`/`links.previous` is not available for all connectors.  ## SDKs and API Clients  Upcoming. [Request the SDK of your choice](https://integrations.apideck.com/request).  ## Debugging  Because of the nature of the abstraction we do in Apideck Unify we still provide the option to the receive raw requests and responses being handled underlying. By including the raw flag `?raw=true` in your requests you can still receive the full request. Please note that this increases the response size and can introduce extra latency.  ## Errors  The API returns standard HTTP response codes to indicate success or failure of the API requests. For errors, we also return a customized error message inside the JSON response. You can see the returned HTTP status codes below.  | Code | Title                | Description                                                                                                                                                                                              | | - -- - | - -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | 200  | OK                   | The request message has been successfully processed, and it has produced a response. The response message varies, depending on the request method and the requested data.                                | | 201  | Created              | The request has been fulfilled and has resulted in one or more new resources being created.                                                                                                              | | 204  | No Content           | The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.                                                                          | | 400  | Bad Request          | The receiving server cannot understand the request because of malformed syntax. Do not repeat the request without first modifying it; check the request for errors, fix them and then retry the request. | | 401  | Unauthorized         | The request has not been applied because it lacks valid authentication credentials for the target resource.                                                                                              | | 402  | Payment Required     | Subscription data is incomplete or out of date. You'll need to provide payment details to continue.                                                                                                      | | 403  | Forbidden            | You do not have the appropriate user rights to access the request. Do not repeat the request.                                                                                                            | | 404  | Not Found            | The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.                                                                           | | 409  | Conflict             | The request could not be completed due to a conflict with the current state of the target resource.                                                                                                      | | 422  | Unprocessable Entity | The server understands the content type of the request entity, and the syntax of the request entity is correct but was unable to process the contained instructions.                                     | | 5xx  | Server Errors        | Something went wrong with the Unify API. These errors are logged on our side. You can contact our team to resolve the issue.                                                                             |  ### Handling errors  The Unify API and SDKs can produce errors for many reasons, such as a failed requests due to misconfigured integrations, invalid parameters, authentication errors, and network unavailability.  ### Error Types  #### RequestValidationError  Request is not valid for the current endpoint. The response body will include details on the validation error. Check the spelling and types of your attributes, and ensure you are not passing data that is outside of the specification.  #### UnsupportedFiltersError  Filters in the request are valid, but not supported by the connector. Remove the unsupported filter(s) to get a successful response.  #### UnsupportedSortFieldError  Sort field (`sort[by]`) in the request is valid, but not supported by the connector. Replace or remove the sort field to get a successful response.  #### InvalidCursorError  Pagination cursor in the request is not valid for the current connector. Make sure to use a cursor returned from the API, for the same connector.  #### ConnectorExecutionError  A Unified API request made via one of our downstream connectors returned an unexpected error. The `status_code` returned is proxied through to error response along with their original response via the error detail.  #### ConnectorProcessingError  A Unified API request made via one of our downstream connectors returned a status code that was less than 400, along with a description of why the request could not be processed. Often this is due to the shape of request data being valid, but unable to be processed due to internal business logic - for example: an invalid relationship or `ID` present in your request.  #### UnauthorizedError  We were unable to authorize the request as made. This can happen for a number of reasons, from missing header params to passing an incorrect authorization token. Verify your Api Key is being set correctly in the authorization header. ie: `Authorization: 'Bearer sk_live_***'`  #### ConnectorCredentialsError  A request using a given connector has not been authorized. Ensure the connector you are trying to use has been configured correctly and been authorized for use.  #### ConnectorDisabledError  A request has been made to a connector that has since been disabled. This may be temporary - You can contact our team to resolve the issue.  #### RequestLimitError  You have reached the number of requests included in your Free Tier Subscription. You will no be able to make further requests until this limit resets at the end of the month, or talk to us about upgrading your subscription to continue immediately.  #### EntityNotFoundError  You've made a request for a resource or route that does not exist. Verify your path parameters or any identifiers used to fetch this resource.  #### OAuthCredentialsNotFoundError  When adding a connector integration that implements OAuth, both a `client_id` and `client_secret` must be provided before any authorizations can be performed. Verify the integration has been configured properly before continuing.  #### IntegrationNotFoundError  The requested connector integration could not be found associated to your `application_id`. Verify your `application_id` is correct, and that this connector has been added and configured for your application.  #### ConnectionNotFoundError  A valid connection could not be found associated to your `application_id`. Something _may_ have interrupted the authorization flow. You may need to start the connector authorization process again.  #### ConnectorNotFoundError  A request was made for an unknown connector. Verify your `service_id` is spelled correctly, and that this connector is enabled for your provided `unified_api`.  #### OAuthRedirectUriError  A request was made either in a connector authorization flow, or attempting to revoke connector access without a valid `redirect_uri`. This is the url the user should be returned to on completion of process.  #### OAuthInvalidStateError  The state param is required and is used to ensure the outgoing authorization state has not been altered before the user is redirected back. It also contains required params needed to identify the connector being used. If this has been altered, the authorization will not succeed.  #### OAuthCodeExchangeError  When attempting to exchange the authorization code for an `access_token` during an OAuth flow, an error occurred. This may be temporary. You can reattempt authorization or contact our team to resolve the issue.  #### MappingError  There was an error attempting to retrieve the mapping for a given attribute. We've been notified and are working to fix this issue.  #### ConnectorMappingNotFoundError  It seems the implementation for this connector is incomplete. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorResponseMappingNotFoundError  We were unable to retrieve the response mapping for this connector. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorOperationMappingNotFoundError  Connector mapping has not been implemented for the requested operation. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorWorkflowMappingError  The composite api calls required for this operation have not been mapped entirely. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### PaginationNotSupportedError  Pagination is not yet supported for this connector, try removing limit and/or cursor from the query. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  ## API Design  ### API Styles and data formats  #### REST API  The API is organized around [REST](https://restfulapi.net/), providing simple and predictable URIs to access and modify objects. Requests support standard HTTP methods like GET, PUT, POST, and DELETE and standard status codes. JSON is returned by all API responses, including errors. In all API requests, you must set the content-type HTTP header to application/json. All API requests must be made over HTTPS. Calls made over HTTP will fail.  ##### Available HTTP methods  The Apideck API uses HTTP verbs to understand if you want to read (GET), delete (DELETE) or create (POST) an object. When your web application cannot do a POST or DELETE, we provide the ability to set the method through the query parameter \\_method.  ``` POST /messages GET /messages GET /messages/{messageId} PATCH /messages/{messageId} DELETE /messages/{messageId} ```  Response bodies are always UTF-8 encoded JSON objects, unless explicitly documented otherwise. For some endpoints and use cases we divert from REST to provide a better developer experience.  ### Schema  All API requests and response bodies adhere to a common JSON format representing individual items, collections of items, links to related items and additional meta data.  ### Meta  Meta data can be represented as a top level member named “meta”. Any information may be provided in the meta data. It’s most common use is to return the total number of records when requesting a collection of resources.  ### Idempotence (upcoming)  To prevent the creation of duplicate resources, every POST method (such as one that creates a consumer record) must specify a unique value for the X-Unique-Transaction-ID header name. Uniquely identifying each unique POST request ensures that the API processes a given request once and only once.  Uniquely identifying new resource-creation POSTs is especially important when the outcome of a response is ambiguous because of a transient service interruption, such as a server-side timeout or network disruption. If a service interruption occurs, then the client application can safely retry the uniquely identified request without creating duplicate operations. (API endpoints that guarantee that every uniquely identified request is processed only once no matter how many times that uniquely identifiable request is made are described as idempotent.)  ### Request IDs  Each API request has an associated request identifier. You can find this value in the response headers, under Request-Id. You can also find request identifiers in the URLs of individual request logs in your Dashboard. If you need to contact us about a specific request, providing the request identifier will ensure the fastest possible resolution.  ### Fixed field types  #### Dates  The dates returned by the API are all represented in UTC (ISO8601 format).  This example `2019-11-14T00:55:31.820Z` is defined by the ISO 8601 standard. The T in the middle separates the year-month-day portion from the hour-minute-second portion. The Z on the end means UTC, that is, an offset-from-UTC of zero hours-minutes-seconds. The Z is pronounced \"Zulu\" per military/aviation tradition.  The ISO 8601 standard is more modern. The formats are wisely designed to be easy to parse by machine as well as easy to read by humans across cultures.  #### Prices and Currencies  All prices returned by the API are represented as integer amounts in a currency’s smallest unit. For example, $5 USD would be returned as 500 (i.e, 500 cents).  For zero-decimal currencies, amounts will still be provided as an integer but without the need to divide by 100. For example, an amount of ¥5 (JPY) would be returned as 5.  All currency codes conform to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).  ## Support  If you have problems or need help with your case, you can always reach out to our Support. 
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
using OpenAPIDateConverter = Apideck.CustomerSupport.Client.OpenAPIDateConverter;

namespace Apideck.CustomerSupport.Model
{
    /// <summary>
    /// Opportunity
    /// </summary>
    [DataContract(Name = "Opportunity")]
    public partial class Opportunity : IEquatable<Opportunity>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name = "currency", EmitDefaultValue = true)]
        public Currency? Currency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Opportunity" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Opportunity() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Opportunity" /> class.
        /// </summary>
        /// <param name="title">title (required).</param>
        /// <param name="primaryContactId">primaryContactId (required).</param>
        /// <param name="description">description.</param>
        /// <param name="type">type.</param>
        /// <param name="monetaryAmount">monetaryAmount.</param>
        /// <param name="currency">currency.</param>
        /// <param name="winProbability">winProbability.</param>
        /// <param name="closeDate">closeDate.</param>
        /// <param name="lossReasonId">lossReasonId.</param>
        /// <param name="lossReason">lossReason.</param>
        /// <param name="wonReasonId">wonReasonId.</param>
        /// <param name="wonReason">wonReason.</param>
        /// <param name="pipelineId">pipelineId.</param>
        /// <param name="pipelineStageId">pipelineStageId.</param>
        /// <param name="sourceId">sourceId.</param>
        /// <param name="leadId">leadId.</param>
        /// <param name="leadSource">Lead source.</param>
        /// <param name="contactId">contactId.</param>
        /// <param name="companyId">companyId.</param>
        /// <param name="companyName">companyName.</param>
        /// <param name="ownerId">ownerId.</param>
        /// <param name="priority">priority.</param>
        /// <param name="status">status.</param>
        /// <param name="statusId">statusId.</param>
        /// <param name="tags">tags.</param>
        /// <param name="customFields">customFields.</param>
        /// <param name="stageLastChangedAt">stageLastChangedAt.</param>
        public Opportunity(string title = default(string), string primaryContactId = default(string), string description = default(string), string type = default(string), decimal? monetaryAmount = default(decimal?), Currency? currency = default(Currency?), decimal? winProbability = default(decimal?), DateTime? closeDate = default(DateTime?), string lossReasonId = default(string), string lossReason = default(string), string wonReasonId = default(string), string wonReason = default(string), string pipelineId = default(string), string pipelineStageId = default(string), string sourceId = default(string), string leadId = default(string), string leadSource = default(string), string contactId = default(string), string companyId = default(string), string companyName = default(string), string ownerId = default(string), string priority = default(string), string status = default(string), string statusId = default(string), List<string> tags = default(List<string>), List<CustomField> customFields = default(List<CustomField>), DateTime? stageLastChangedAt = default(DateTime?))
        {
            // to ensure "title" is required (not null)
            if (title == null) {
                throw new ArgumentNullException("title is a required property for Opportunity and cannot be null");
            }
            this.Title = title;
            // to ensure "primaryContactId" is required (not null)
            if (primaryContactId == null) {
                throw new ArgumentNullException("primaryContactId is a required property for Opportunity and cannot be null");
            }
            this.PrimaryContactId = primaryContactId;
            this.Description = description;
            this.Type = type;
            this.MonetaryAmount = monetaryAmount;
            this.Currency = currency;
            this.WinProbability = winProbability;
            this.CloseDate = closeDate;
            this.LossReasonId = lossReasonId;
            this.LossReason = lossReason;
            this.WonReasonId = wonReasonId;
            this.WonReason = wonReason;
            this.PipelineId = pipelineId;
            this.PipelineStageId = pipelineStageId;
            this.SourceId = sourceId;
            this.LeadId = leadId;
            this.LeadSource = leadSource;
            this.ContactId = contactId;
            this.CompanyId = companyId;
            this.CompanyName = companyName;
            this.OwnerId = ownerId;
            this.Priority = priority;
            this.Status = status;
            this.StatusId = statusId;
            this.Tags = tags;
            this.CustomFields = customFields;
            this.StageLastChangedAt = stageLastChangedAt;
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
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets PrimaryContactId
        /// </summary>
        [DataMember(Name = "primary_contact_id", IsRequired = true, EmitDefaultValue = true)]
        public string PrimaryContactId { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets MonetaryAmount
        /// </summary>
        [DataMember(Name = "monetary_amount", EmitDefaultValue = true)]
        public decimal? MonetaryAmount { get; set; }

        /// <summary>
        /// Gets or Sets WinProbability
        /// </summary>
        [DataMember(Name = "win_probability", EmitDefaultValue = true)]
        public decimal? WinProbability { get; set; }

        /// <summary>
        /// Expected Revenue
        /// </summary>
        /// <value>Expected Revenue</value>
        [DataMember(Name = "expected_revenue", EmitDefaultValue = true)]
        public decimal? ExpectedRevenue { get; private set; }

        /// <summary>
        /// Returns false as ExpectedRevenue should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeExpectedRevenue()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets CloseDate
        /// </summary>
        [DataMember(Name = "close_date", EmitDefaultValue = true)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// Gets or Sets LossReasonId
        /// </summary>
        [DataMember(Name = "loss_reason_id", EmitDefaultValue = true)]
        public string LossReasonId { get; set; }

        /// <summary>
        /// Gets or Sets LossReason
        /// </summary>
        [DataMember(Name = "loss_reason", EmitDefaultValue = true)]
        public string LossReason { get; set; }

        /// <summary>
        /// Gets or Sets WonReasonId
        /// </summary>
        [DataMember(Name = "won_reason_id", EmitDefaultValue = true)]
        public string WonReasonId { get; set; }

        /// <summary>
        /// Gets or Sets WonReason
        /// </summary>
        [DataMember(Name = "won_reason", EmitDefaultValue = true)]
        public string WonReason { get; set; }

        /// <summary>
        /// Gets or Sets PipelineId
        /// </summary>
        [DataMember(Name = "pipeline_id", EmitDefaultValue = true)]
        public string PipelineId { get; set; }

        /// <summary>
        /// Gets or Sets PipelineStageId
        /// </summary>
        [DataMember(Name = "pipeline_stage_id", EmitDefaultValue = true)]
        public string PipelineStageId { get; set; }

        /// <summary>
        /// Gets or Sets SourceId
        /// </summary>
        [DataMember(Name = "source_id", EmitDefaultValue = true)]
        public string SourceId { get; set; }

        /// <summary>
        /// Gets or Sets LeadId
        /// </summary>
        [DataMember(Name = "lead_id", EmitDefaultValue = true)]
        public string LeadId { get; set; }

        /// <summary>
        /// Lead source
        /// </summary>
        /// <value>Lead source</value>
        [DataMember(Name = "lead_source", EmitDefaultValue = true)]
        public string LeadSource { get; set; }

        /// <summary>
        /// Gets or Sets ContactId
        /// </summary>
        [DataMember(Name = "contact_id", EmitDefaultValue = true)]
        public string ContactId { get; set; }

        /// <summary>
        /// Gets or Sets CompanyId
        /// </summary>
        [DataMember(Name = "company_id", EmitDefaultValue = true)]
        public string CompanyId { get; set; }

        /// <summary>
        /// Gets or Sets CompanyName
        /// </summary>
        [DataMember(Name = "company_name", EmitDefaultValue = true)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or Sets OwnerId
        /// </summary>
        [DataMember(Name = "owner_id", EmitDefaultValue = true)]
        public string OwnerId { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>
        [DataMember(Name = "priority", EmitDefaultValue = true)]
        public string Priority { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets StatusId
        /// </summary>
        [DataMember(Name = "status_id", EmitDefaultValue = true)]
        public string StatusId { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or Sets InteractionCount
        /// </summary>
        [DataMember(Name = "interaction_count", EmitDefaultValue = true)]
        public decimal? InteractionCount { get; private set; }

        /// <summary>
        /// Returns false as InteractionCount should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeInteractionCount()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets CustomFields
        /// </summary>
        [DataMember(Name = "custom_fields", EmitDefaultValue = false)]
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or Sets StageLastChangedAt
        /// </summary>
        [DataMember(Name = "stage_last_changed_at", EmitDefaultValue = true)]
        public DateTime? StageLastChangedAt { get; set; }

        /// <summary>
        /// Gets or Sets LastActivityAt
        /// </summary>
        [DataMember(Name = "last_activity_at", EmitDefaultValue = true)]
        public string LastActivityAt { get; private set; }

        /// <summary>
        /// Returns false as LastActivityAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeLastActivityAt()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Deleted
        /// </summary>
        [DataMember(Name = "deleted", EmitDefaultValue = true)]
        public bool Deleted { get; private set; }

        /// <summary>
        /// Returns false as Deleted should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDeleted()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets DateStageChanged
        /// </summary>
        [DataMember(Name = "date_stage_changed", EmitDefaultValue = true)]
        public DateTime? DateStageChanged { get; private set; }

        /// <summary>
        /// Returns false as DateStageChanged should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDateStageChanged()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets DateLastContacted
        /// </summary>
        [DataMember(Name = "date_last_contacted", EmitDefaultValue = true)]
        public DateTime? DateLastContacted { get; private set; }

        /// <summary>
        /// Returns false as DateLastContacted should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDateLastContacted()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets DateLeadCreated
        /// </summary>
        [DataMember(Name = "date_lead_created", EmitDefaultValue = true)]
        public DateTime? DateLeadCreated { get; private set; }

        /// <summary>
        /// Returns false as DateLeadCreated should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDateLeadCreated()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets UpdatedBy
        /// </summary>
        [DataMember(Name = "updated_by", EmitDefaultValue = true)]
        public string UpdatedBy { get; private set; }

        /// <summary>
        /// Returns false as UpdatedBy should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeUpdatedBy()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name = "created_by", EmitDefaultValue = true)]
        public string CreatedBy { get; private set; }

        /// <summary>
        /// Returns false as CreatedBy should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCreatedBy()
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
            sb.Append("class Opportunity {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  PrimaryContactId: ").Append(PrimaryContactId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  MonetaryAmount: ").Append(MonetaryAmount).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  WinProbability: ").Append(WinProbability).Append("\n");
            sb.Append("  ExpectedRevenue: ").Append(ExpectedRevenue).Append("\n");
            sb.Append("  CloseDate: ").Append(CloseDate).Append("\n");
            sb.Append("  LossReasonId: ").Append(LossReasonId).Append("\n");
            sb.Append("  LossReason: ").Append(LossReason).Append("\n");
            sb.Append("  WonReasonId: ").Append(WonReasonId).Append("\n");
            sb.Append("  WonReason: ").Append(WonReason).Append("\n");
            sb.Append("  PipelineId: ").Append(PipelineId).Append("\n");
            sb.Append("  PipelineStageId: ").Append(PipelineStageId).Append("\n");
            sb.Append("  SourceId: ").Append(SourceId).Append("\n");
            sb.Append("  LeadId: ").Append(LeadId).Append("\n");
            sb.Append("  LeadSource: ").Append(LeadSource).Append("\n");
            sb.Append("  ContactId: ").Append(ContactId).Append("\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
            sb.Append("  OwnerId: ").Append(OwnerId).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  StatusId: ").Append(StatusId).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  InteractionCount: ").Append(InteractionCount).Append("\n");
            sb.Append("  CustomFields: ").Append(CustomFields).Append("\n");
            sb.Append("  StageLastChangedAt: ").Append(StageLastChangedAt).Append("\n");
            sb.Append("  LastActivityAt: ").Append(LastActivityAt).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
            sb.Append("  DateStageChanged: ").Append(DateStageChanged).Append("\n");
            sb.Append("  DateLastContacted: ").Append(DateLastContacted).Append("\n");
            sb.Append("  DateLeadCreated: ").Append(DateLeadCreated).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
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
            return this.Equals(input as Opportunity);
        }

        /// <summary>
        /// Returns true if Opportunity instances are equal
        /// </summary>
        /// <param name="input">Instance of Opportunity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Opportunity input)
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
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.PrimaryContactId == input.PrimaryContactId ||
                    (this.PrimaryContactId != null &&
                    this.PrimaryContactId.Equals(input.PrimaryContactId))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.MonetaryAmount == input.MonetaryAmount ||
                    (this.MonetaryAmount != null &&
                    this.MonetaryAmount.Equals(input.MonetaryAmount))
                ) && 
                (
                    this.Currency == input.Currency ||
                    this.Currency.Equals(input.Currency)
                ) && 
                (
                    this.WinProbability == input.WinProbability ||
                    (this.WinProbability != null &&
                    this.WinProbability.Equals(input.WinProbability))
                ) && 
                (
                    this.ExpectedRevenue == input.ExpectedRevenue ||
                    (this.ExpectedRevenue != null &&
                    this.ExpectedRevenue.Equals(input.ExpectedRevenue))
                ) && 
                (
                    this.CloseDate == input.CloseDate ||
                    (this.CloseDate != null &&
                    this.CloseDate.Equals(input.CloseDate))
                ) && 
                (
                    this.LossReasonId == input.LossReasonId ||
                    (this.LossReasonId != null &&
                    this.LossReasonId.Equals(input.LossReasonId))
                ) && 
                (
                    this.LossReason == input.LossReason ||
                    (this.LossReason != null &&
                    this.LossReason.Equals(input.LossReason))
                ) && 
                (
                    this.WonReasonId == input.WonReasonId ||
                    (this.WonReasonId != null &&
                    this.WonReasonId.Equals(input.WonReasonId))
                ) && 
                (
                    this.WonReason == input.WonReason ||
                    (this.WonReason != null &&
                    this.WonReason.Equals(input.WonReason))
                ) && 
                (
                    this.PipelineId == input.PipelineId ||
                    (this.PipelineId != null &&
                    this.PipelineId.Equals(input.PipelineId))
                ) && 
                (
                    this.PipelineStageId == input.PipelineStageId ||
                    (this.PipelineStageId != null &&
                    this.PipelineStageId.Equals(input.PipelineStageId))
                ) && 
                (
                    this.SourceId == input.SourceId ||
                    (this.SourceId != null &&
                    this.SourceId.Equals(input.SourceId))
                ) && 
                (
                    this.LeadId == input.LeadId ||
                    (this.LeadId != null &&
                    this.LeadId.Equals(input.LeadId))
                ) && 
                (
                    this.LeadSource == input.LeadSource ||
                    (this.LeadSource != null &&
                    this.LeadSource.Equals(input.LeadSource))
                ) && 
                (
                    this.ContactId == input.ContactId ||
                    (this.ContactId != null &&
                    this.ContactId.Equals(input.ContactId))
                ) && 
                (
                    this.CompanyId == input.CompanyId ||
                    (this.CompanyId != null &&
                    this.CompanyId.Equals(input.CompanyId))
                ) && 
                (
                    this.CompanyName == input.CompanyName ||
                    (this.CompanyName != null &&
                    this.CompanyName.Equals(input.CompanyName))
                ) && 
                (
                    this.OwnerId == input.OwnerId ||
                    (this.OwnerId != null &&
                    this.OwnerId.Equals(input.OwnerId))
                ) && 
                (
                    this.Priority == input.Priority ||
                    (this.Priority != null &&
                    this.Priority.Equals(input.Priority))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.StatusId == input.StatusId ||
                    (this.StatusId != null &&
                    this.StatusId.Equals(input.StatusId))
                ) && 
                (
                    this.Tags == input.Tags ||
                    this.Tags != null &&
                    input.Tags != null &&
                    this.Tags.SequenceEqual(input.Tags)
                ) && 
                (
                    this.InteractionCount == input.InteractionCount ||
                    (this.InteractionCount != null &&
                    this.InteractionCount.Equals(input.InteractionCount))
                ) && 
                (
                    this.CustomFields == input.CustomFields ||
                    this.CustomFields != null &&
                    input.CustomFields != null &&
                    this.CustomFields.SequenceEqual(input.CustomFields)
                ) && 
                (
                    this.StageLastChangedAt == input.StageLastChangedAt ||
                    (this.StageLastChangedAt != null &&
                    this.StageLastChangedAt.Equals(input.StageLastChangedAt))
                ) && 
                (
                    this.LastActivityAt == input.LastActivityAt ||
                    (this.LastActivityAt != null &&
                    this.LastActivityAt.Equals(input.LastActivityAt))
                ) && 
                (
                    this.Deleted == input.Deleted ||
                    this.Deleted.Equals(input.Deleted)
                ) && 
                (
                    this.DateStageChanged == input.DateStageChanged ||
                    (this.DateStageChanged != null &&
                    this.DateStageChanged.Equals(input.DateStageChanged))
                ) && 
                (
                    this.DateLastContacted == input.DateLastContacted ||
                    (this.DateLastContacted != null &&
                    this.DateLastContacted.Equals(input.DateLastContacted))
                ) && 
                (
                    this.DateLeadCreated == input.DateLeadCreated ||
                    (this.DateLeadCreated != null &&
                    this.DateLeadCreated.Equals(input.DateLeadCreated))
                ) && 
                (
                    this.UpdatedBy == input.UpdatedBy ||
                    (this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(input.UpdatedBy))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
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
                if (this.Title != null)
                {
                    hashCode = (hashCode * 59) + this.Title.GetHashCode();
                }
                if (this.PrimaryContactId != null)
                {
                    hashCode = (hashCode * 59) + this.PrimaryContactId.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.MonetaryAmount != null)
                {
                    hashCode = (hashCode * 59) + this.MonetaryAmount.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Currency.GetHashCode();
                if (this.WinProbability != null)
                {
                    hashCode = (hashCode * 59) + this.WinProbability.GetHashCode();
                }
                if (this.ExpectedRevenue != null)
                {
                    hashCode = (hashCode * 59) + this.ExpectedRevenue.GetHashCode();
                }
                if (this.CloseDate != null)
                {
                    hashCode = (hashCode * 59) + this.CloseDate.GetHashCode();
                }
                if (this.LossReasonId != null)
                {
                    hashCode = (hashCode * 59) + this.LossReasonId.GetHashCode();
                }
                if (this.LossReason != null)
                {
                    hashCode = (hashCode * 59) + this.LossReason.GetHashCode();
                }
                if (this.WonReasonId != null)
                {
                    hashCode = (hashCode * 59) + this.WonReasonId.GetHashCode();
                }
                if (this.WonReason != null)
                {
                    hashCode = (hashCode * 59) + this.WonReason.GetHashCode();
                }
                if (this.PipelineId != null)
                {
                    hashCode = (hashCode * 59) + this.PipelineId.GetHashCode();
                }
                if (this.PipelineStageId != null)
                {
                    hashCode = (hashCode * 59) + this.PipelineStageId.GetHashCode();
                }
                if (this.SourceId != null)
                {
                    hashCode = (hashCode * 59) + this.SourceId.GetHashCode();
                }
                if (this.LeadId != null)
                {
                    hashCode = (hashCode * 59) + this.LeadId.GetHashCode();
                }
                if (this.LeadSource != null)
                {
                    hashCode = (hashCode * 59) + this.LeadSource.GetHashCode();
                }
                if (this.ContactId != null)
                {
                    hashCode = (hashCode * 59) + this.ContactId.GetHashCode();
                }
                if (this.CompanyId != null)
                {
                    hashCode = (hashCode * 59) + this.CompanyId.GetHashCode();
                }
                if (this.CompanyName != null)
                {
                    hashCode = (hashCode * 59) + this.CompanyName.GetHashCode();
                }
                if (this.OwnerId != null)
                {
                    hashCode = (hashCode * 59) + this.OwnerId.GetHashCode();
                }
                if (this.Priority != null)
                {
                    hashCode = (hashCode * 59) + this.Priority.GetHashCode();
                }
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
                if (this.StatusId != null)
                {
                    hashCode = (hashCode * 59) + this.StatusId.GetHashCode();
                }
                if (this.Tags != null)
                {
                    hashCode = (hashCode * 59) + this.Tags.GetHashCode();
                }
                if (this.InteractionCount != null)
                {
                    hashCode = (hashCode * 59) + this.InteractionCount.GetHashCode();
                }
                if (this.CustomFields != null)
                {
                    hashCode = (hashCode * 59) + this.CustomFields.GetHashCode();
                }
                if (this.StageLastChangedAt != null)
                {
                    hashCode = (hashCode * 59) + this.StageLastChangedAt.GetHashCode();
                }
                if (this.LastActivityAt != null)
                {
                    hashCode = (hashCode * 59) + this.LastActivityAt.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Deleted.GetHashCode();
                if (this.DateStageChanged != null)
                {
                    hashCode = (hashCode * 59) + this.DateStageChanged.GetHashCode();
                }
                if (this.DateLastContacted != null)
                {
                    hashCode = (hashCode * 59) + this.DateLastContacted.GetHashCode();
                }
                if (this.DateLeadCreated != null)
                {
                    hashCode = (hashCode * 59) + this.DateLeadCreated.GetHashCode();
                }
                if (this.UpdatedBy != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedBy.GetHashCode();
                }
                if (this.CreatedBy != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedBy.GetHashCode();
                }
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
            // Title (string) minLength
            if (this.Title != null && this.Title.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Title, length must be greater than 1.", new [] { "Title" });
            }

            // Description (string) minLength
            if (this.Description != null && this.Description.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be greater than 1.", new [] { "Description" });
            }

            // Type (string) minLength
            if (this.Type != null && this.Type.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Type, length must be greater than 1.", new [] { "Type" });
            }

            // Priority (string) minLength
            if (this.Priority != null && this.Priority.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Priority, length must be greater than 1.", new [] { "Priority" });
            }

            // Status (string) minLength
            if (this.Status != null && this.Status.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Status, length must be greater than 1.", new [] { "Status" });
            }

            yield break;
        }
    }

}
