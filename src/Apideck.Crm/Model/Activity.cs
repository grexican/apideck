/*
 * CRM API
 *
 * Welcome to the CRM API.  You can use this API to access all CRM API endpoints.  ## Base URL  The base URL for all API requests is `https://unify.apideck.com`  ## GraphQL  Use the [GraphQL playground](https://developers.apideck.com/graphql/playground) to test out the GraphQL API.  ## Headers  Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.  | Name                  | Type    | Required | Description                                                                                                                                                    | | - -- -- -- -- -- -- -- -- -- -- | - -- -- -- | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | x-apideck-consumer-id | String  | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app. | | x-apideck-service-id  | String  | No       | Describe the service you want to call (e.g., pipedrive). Only needed when a customer has activated multiple integrations for the same Unified API.             | | x-apideck-raw         | Boolean | No       | Include raw response. Mostly used for debugging purposes.                                                                                                      | | x-apideck-app-id      | String  | Yes      | The application id of your Unify application. Available at https://app.apideck.com/unify/api-keys.                                                             | | Authorization         | String  | Yes      | Bearer API KEY                                                                                                                                                 |  ## Authorization  You can interact with the API through the authorization methods below.  <!- - ReDoc-Inject: <security-definitions> - ->  ## Pagination  All API resources have support for bulk retrieval via list APIs. For example, you can list [opportunities](#tag/Opportunities), [companies](#tag/Companies) and [leads](#tag/Leads). Apideck uses cursor-based pagination via the optional `cursor` and `limit` parameters.  To fetch the first page of results, call the list API without a `cursor` parameter. Afterwards you can fetch subsequent pages by providing a cursor parameter. You will find the next cursor in the response body in `meta.cursors.next`. If `meta.cursors.next` is `null` you're at the end of the list.  In the REST API you can also use the `links` from the response for added convenience. Simply call the URL in `links.next` to get the next page of results.  ### Query Parameters  | Name   | Type   | Required | Description                                                                                                        | | - -- -- - | - -- -- - | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | cursor | String | No       | Cursor to start from. You can find cursors for next & previous pages in the meta.cursors property of the response. | | limit  | Number | No       | Number of results to return. Minimum 1, Maximum 200, Default 20                                                    |  ### Response Body  | Name                  | Type   | Description                                                        | | - -- -- -- -- -- -- -- -- -- -- | - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | meta.cursors.previous | String | Cursor to navigate to the previous page of results through the API | | meta.cursors.current  | String | Cursor to navigate to the current page of results through the API  | | meta.cursors.next     | String | Cursor to navigate to the next page of results through the API     | | meta.items_on_page    | Number | Number of items returned in the data property of the response      | | links.previous        | String | Link to navigate to the previous page of results through the API   | | links.current         | String | Link to navigate to the current page of results through the API    | | links.next            | String | Link to navigate to the next page of results through the API       |  ⚠️ `meta.cursors.previous`/`links.previous` is not available for all connectors.  ## SDKs and API Clients  Upcoming. [Request the SDK of your choice](https://integrations.apideck.com/request).  ## Debugging  Because of the nature of the abstraction we do in Apideck Unify we still provide the option to the receive raw requests and responses being handled underlying. By including the raw flag `?raw=true` in your requests you can still receive the full request. Please note that this increases the response size and can introduce extra latency.  ## Errors  The API returns standard HTTP response codes to indicate success or failure of the API requests. For errors, we also return a customized error message inside the JSON response. You can see the returned HTTP status codes below.  | Code | Title                | Description                                                                                                                                                                                              | | - -- - | - -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | 200  | OK                   | The request message has been successfully processed, and it has produced a response. The response message varies, depending on the request method and the requested data.                                | | 201  | Created              | The request has been fulfilled and has resulted in one or more new resources being created.                                                                                                              | | 204  | No Content           | The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.                                                                          | | 400  | Bad Request          | The receiving server cannot understand the request because of malformed syntax. Do not repeat the request without first modifying it; check the request for errors, fix them and then retry the request. | | 401  | Unauthorized         | The request has not been applied because it lacks valid authentication credentials for the target resource.                                                                                              | | 402  | Payment Required     | Subscription data is incomplete or out of date. You'll need to provide payment details to continue.                                                                                                      | | 403  | Forbidden            | You do not have the appropriate user rights to access the request. Do not repeat the request.                                                                                                            | | 404  | Not Found            | The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.                                                                           | | 409  | Conflict             | The request could not be completed due to a conflict with the current state of the target resource.                                                                                                      | | 422  | Unprocessable Entity | The server understands the content type of the request entity, and the syntax of the request entity is correct but was unable to process the contained instructions.                                     | | 5xx  | Server Errors        | Something went wrong with the Unify API. These errors are logged on our side. You can contact our team to resolve the issue.                                                                             |  ### Handling errors  The Unify API and SDKs can produce errors for many reasons, such as a failed requests due to misconfigured integrations, invalid parameters, authentication errors, and network unavailability.  ### Error Types  #### RequestValidationError  Request is not valid for the current endpoint. The response body will include details on the validation error. Check the spelling and types of your attributes, and ensure you are not passing data that is outside of the specification.  #### UnsupportedFiltersError  Filters in the request are valid, but not supported by the connector. Remove the unsupported filter(s) to get a successful response.  #### UnsupportedSortFieldError  Sort field (`sort[by]`) in the request is valid, but not supported by the connector. Replace or remove the sort field to get a successful response.  #### InvalidCursorError  Pagination cursor in the request is not valid for the current connector. Make sure to use a cursor returned from the API, for the same connector.  #### ConnectorExecutionError  A Unified API request made via one of our downstream connectors returned an unexpected error. The `status_code` returned is proxied through to error response along with their original response via the error detail.  #### ConnectorProcessingError  A Unified API request made via one of our downstream connectors returned a status code that was less than 400, along with a description of why the request could not be processed. Often this is due to the shape of request data being valid, but unable to be processed due to internal business logic - for example: an invalid relationship or `ID` present in your request.  #### UnauthorizedError  We were unable to authorize the request as made. This can happen for a number of reasons, from missing header params to passing an incorrect authorization token. Verify your Api Key is being set correctly in the authorization header. ie: `Authorization: 'Bearer sk_live_***'`  #### ConnectorCredentialsError  A request using a given connector has not been authorized. Ensure the connector you are trying to use has been configured correctly and been authorized for use.  #### ConnectorDisabledError  A request has been made to a connector that has since been disabled. This may be temporary - You can contact our team to resolve the issue.  #### RequestLimitError  You have reached the number of requests included in your Free Tier Subscription. You will no be able to make further requests until this limit resets at the end of the month, or talk to us about upgrading your subscription to continue immediately.  #### EntityNotFoundError  You've made a request for a resource or route that does not exist. Verify your path parameters or any identifiers used to fetch this resource.  #### OAuthCredentialsNotFoundError  When adding a connector integration that implements OAuth, both a `client_id` and `client_secret` must be provided before any authorizations can be performed. Verify the integration has been configured properly before continuing.  #### IntegrationNotFoundError  The requested connector integration could not be found associated to your `application_id`. Verify your `application_id` is correct, and that this connector has been added and configured for your application.  #### ConnectionNotFoundError  A valid connection could not be found associated to your `application_id`. Something _may_ have interrupted the authorization flow. You may need to start the connector authorization process again.  #### ConnectorNotFoundError  A request was made for an unknown connector. Verify your `service_id` is spelled correctly, and that this connector is enabled for your provided `unified_api`.  #### OAuthRedirectUriError  A request was made either in a connector authorization flow, or attempting to revoke connector access without a valid `redirect_uri`. This is the url the user should be returned to on completion of process.  #### OAuthInvalidStateError  The state param is required and is used to ensure the outgoing authorization state has not been altered before the user is redirected back. It also contains required params needed to identify the connector being used. If this has been altered, the authorization will not succeed.  #### OAuthCodeExchangeError  When attempting to exchange the authorization code for an `access_token` during an OAuth flow, an error occurred. This may be temporary. You can reattempt authorization or contact our team to resolve the issue.  #### MappingError  There was an error attempting to retrieve the mapping for a given attribute. We've been notified and are working to fix this issue.  #### ConnectorMappingNotFoundError  It seems the implementation for this connector is incomplete. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorResponseMappingNotFoundError  We were unable to retrieve the response mapping for this connector. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorOperationMappingNotFoundError  Connector mapping has not been implemented for the requested operation. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorWorkflowMappingError  The composite api calls required for this operation have not been mapped entirely. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### PaginationNotSupportedError  Pagination is not yet supported for this connector, try removing limit and/or cursor from the query. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  ## API Design  ### API Styles and data formats  #### REST API  The API is organized around [REST](https://restfulapi.net/), providing simple and predictable URIs to access and modify objects. Requests support standard HTTP methods like GET, PUT, POST, and DELETE and standard status codes. JSON is returned by all API responses, including errors. In all API requests, you must set the content-type HTTP header to application/json. All API requests must be made over HTTPS. Calls made over HTTP will fail.  ##### Available HTTP methods  The Apideck API uses HTTP verbs to understand if you want to read (GET), delete (DELETE) or create (POST) an object. When your web application cannot do a POST or DELETE, we provide the ability to set the method through the query parameter \\_method.  ``` POST /messages GET /messages GET /messages/{messageId} PATCH /messages/{messageId} DELETE /messages/{messageId} ```  Response bodies are always UTF-8 encoded JSON objects, unless explicitly documented otherwise. For some endpoints and use cases we divert from REST to provide a better developer experience.  ### Schema  All API requests and response bodies adhere to a common JSON format representing individual items, collections of items, links to related items and additional meta data.  ### Meta  Meta data can be represented as a top level member named “meta”. Any information may be provided in the meta data. It’s most common use is to return the total number of records when requesting a collection of resources.  ### Idempotence (upcoming)  To prevent the creation of duplicate resources, every POST method (such as one that creates a consumer record) must specify a unique value for the X-Unique-Transaction-ID header name. Uniquely identifying each unique POST request ensures that the API processes a given request once and only once.  Uniquely identifying new resource-creation POSTs is especially important when the outcome of a response is ambiguous because of a transient service interruption, such as a server-side timeout or network disruption. If a service interruption occurs, then the client application can safely retry the uniquely identified request without creating duplicate operations. (API endpoints that guarantee that every uniquely identified request is processed only once no matter how many times that uniquely identifiable request is made are described as idempotent.)  ### Request IDs  Each API request has an associated request identifier. You can find this value in the response headers, under Request-Id. You can also find request identifiers in the URLs of individual request logs in your Dashboard. If you need to contact us about a specific request, providing the request identifier will ensure the fastest possible resolution.  ### Fixed field types  #### Dates  The dates returned by the API are all represented in UTC (ISO8601 format).  This example `2019-11-14T00:55:31.820Z` is defined by the ISO 8601 standard. The T in the middle separates the year-month-day portion from the hour-minute-second portion. The Z on the end means UTC, that is, an offset-from-UTC of zero hours-minutes-seconds. The Z is pronounced \"Zulu\" per military/aviation tradition.  The ISO 8601 standard is more modern. The formats are wisely designed to be easy to parse by machine as well as easy to read by humans across cultures.  #### Prices and Currencies  All prices returned by the API are represented as integer amounts in a currency’s smallest unit. For example, $5 USD would be returned as 500 (i.e, 500 cents).  For zero-decimal currencies, amounts will still be provided as an integer but without the need to divide by 100. For example, an amount of ¥5 (JPY) would be returned as 5.  All currency codes conform to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).  ## Support  If you have problems or need help with your case, you can always reach out to our Support. 
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
using OpenAPIDateConverter = Apideck.Crm.Client.OpenAPIDateConverter;

namespace Apideck.Crm.Model
{
    /// <summary>
    /// Activity
    /// </summary>
    [DataContract(Name = "Activity")]
    public partial class Activity : IEquatable<Activity>, IValidatableObject
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Call for value: call
            /// </summary>
            [EnumMember(Value = "call")]
            Call = 1,

            /// <summary>
            /// Enum Meeting for value: meeting
            /// </summary>
            [EnumMember(Value = "meeting")]
            Meeting = 2,

            /// <summary>
            /// Enum Email for value: email
            /// </summary>
            [EnumMember(Value = "email")]
            Email = 3,

            /// <summary>
            /// Enum Note for value: note
            /// </summary>
            [EnumMember(Value = "note")]
            Note = 4,

            /// <summary>
            /// Enum Task for value: task
            /// </summary>
            [EnumMember(Value = "task")]
            Task = 5,

            /// <summary>
            /// Enum Deadline for value: deadline
            /// </summary>
            [EnumMember(Value = "deadline")]
            Deadline = 6,

            /// <summary>
            /// Enum SendLetter for value: send-letter
            /// </summary>
            [EnumMember(Value = "send-letter")]
            SendLetter = 7,

            /// <summary>
            /// Enum SendQuote for value: send-quote
            /// </summary>
            [EnumMember(Value = "send-quote")]
            SendQuote = 8,

            /// <summary>
            /// Enum Other for value: other
            /// </summary>
            [EnumMember(Value = "other")]
            Other = 9

        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Defines ShowAs
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShowAsEnum
        {
            /// <summary>
            /// Enum Free for value: free
            /// </summary>
            [EnumMember(Value = "free")]
            Free = 1,

            /// <summary>
            /// Enum Busy for value: busy
            /// </summary>
            [EnumMember(Value = "busy")]
            Busy = 2

        }


        /// <summary>
        /// Gets or Sets ShowAs
        /// </summary>
        [DataMember(Name = "show_as", EmitDefaultValue = false)]
        public ShowAsEnum? ShowAs { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Activity" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Activity() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Activity" /> class.
        /// </summary>
        /// <param name="activityDatetime">activityDatetime.</param>
        /// <param name="durationSeconds">durationSeconds.</param>
        /// <param name="userId">userId.</param>
        /// <param name="accountId">accountId.</param>
        /// <param name="contactId">contactId.</param>
        /// <param name="companyId">companyId.</param>
        /// <param name="opportunityId">opportunityId.</param>
        /// <param name="leadId">leadId.</param>
        /// <param name="ownerId">ownerId.</param>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="caseId">caseId.</param>
        /// <param name="assetId">assetId.</param>
        /// <param name="contractId">contractId.</param>
        /// <param name="productId">productId.</param>
        /// <param name="solutionId">solutionId.</param>
        /// <param name="customObjectId">customObjectId.</param>
        /// <param name="type">type (required).</param>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="note">note.</param>
        /// <param name="location">location.</param>
        /// <param name="locationAddress">locationAddress.</param>
        /// <param name="allDayEvent">allDayEvent.</param>
        /// <param name="_private">_private.</param>
        /// <param name="groupEvent">groupEvent.</param>
        /// <param name="eventSubType">eventSubType.</param>
        /// <param name="groupEventType">groupEventType.</param>
        /// <param name="child">child.</param>
        /// <param name="archived">archived.</param>
        /// <param name="deleted">deleted.</param>
        /// <param name="showAs">showAs.</param>
        /// <param name="done">Whether the Activity is done or not.</param>
        /// <param name="startDatetime">startDatetime.</param>
        /// <param name="endDatetime">endDatetime.</param>
        /// <param name="activityDate">activityDate.</param>
        /// <param name="endDate">endDate.</param>
        /// <param name="recurrent">recurrent.</param>
        /// <param name="reminderDatetime">reminderDatetime.</param>
        /// <param name="reminderSet">reminderSet.</param>
        /// <param name="videoConferenceUrl">videoConferenceUrl.</param>
        /// <param name="videoConferenceId">videoConferenceId.</param>
        /// <param name="customFields">customFields.</param>
        /// <param name="attendees">attendees.</param>
        public Activity(string activityDatetime = default(string), int? durationSeconds = default(int?), string userId = default(string), string accountId = default(string), string contactId = default(string), string companyId = default(string), string opportunityId = default(string), string leadId = default(string), string ownerId = default(string), string campaignId = default(string), string caseId = default(string), string assetId = default(string), string contractId = default(string), string productId = default(string), string solutionId = default(string), string customObjectId = default(string), TypeEnum type = default(TypeEnum), string title = default(string), string description = default(string), string note = default(string), string location = default(string), Address locationAddress = default(Address), bool allDayEvent = default(bool), bool _private = default(bool), bool groupEvent = default(bool), string eventSubType = default(string), string groupEventType = default(string), bool child = default(bool), bool archived = default(bool), bool deleted = default(bool), ShowAsEnum? showAs = default(ShowAsEnum?), bool done = default(bool), string startDatetime = default(string), string endDatetime = default(string), string activityDate = default(string), string endDate = default(string), bool recurrent = default(bool), string reminderDatetime = default(string), bool? reminderSet = default(bool?), string videoConferenceUrl = default(string), string videoConferenceId = default(string), List<CustomField> customFields = default(List<CustomField>), List<ActivityAttendee> attendees = default(List<ActivityAttendee>))
        {
            this.Type = type;
            this.ActivityDatetime = activityDatetime;
            this.DurationSeconds = durationSeconds;
            this.UserId = userId;
            this.AccountId = accountId;
            this.ContactId = contactId;
            this.CompanyId = companyId;
            this.OpportunityId = opportunityId;
            this.LeadId = leadId;
            this.OwnerId = ownerId;
            this.CampaignId = campaignId;
            this.CaseId = caseId;
            this.AssetId = assetId;
            this.ContractId = contractId;
            this.ProductId = productId;
            this.SolutionId = solutionId;
            this.CustomObjectId = customObjectId;
            this.Title = title;
            this.Description = description;
            this.Note = note;
            this.Location = location;
            this.LocationAddress = locationAddress;
            this.AllDayEvent = allDayEvent;
            this.Private = _private;
            this.GroupEvent = groupEvent;
            this.EventSubType = eventSubType;
            this.GroupEventType = groupEventType;
            this.Child = child;
            this.Archived = archived;
            this.Deleted = deleted;
            this.ShowAs = showAs;
            this.Done = done;
            this.StartDatetime = startDatetime;
            this.EndDatetime = endDatetime;
            this.ActivityDate = activityDate;
            this.EndDate = endDate;
            this.Recurrent = recurrent;
            this.ReminderDatetime = reminderDatetime;
            this.ReminderSet = reminderSet;
            this.VideoConferenceUrl = videoConferenceUrl;
            this.VideoConferenceId = videoConferenceId;
            this.CustomFields = customFields;
            this.Attendees = attendees;
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
        /// The third-party API ID of original entity
        /// </summary>
        /// <value>The third-party API ID of original entity</value>
        [DataMember(Name = "downstream_id", EmitDefaultValue = true)]
        public string DownstreamId { get; private set; }

        /// <summary>
        /// Returns false as DownstreamId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDownstreamId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets ActivityDatetime
        /// </summary>
        [DataMember(Name = "activity_datetime", EmitDefaultValue = true)]
        public string ActivityDatetime { get; set; }

        /// <summary>
        /// Gets or Sets DurationSeconds
        /// </summary>
        [DataMember(Name = "duration_seconds", EmitDefaultValue = true)]
        public int? DurationSeconds { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name = "user_id", EmitDefaultValue = true)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or Sets AccountId
        /// </summary>
        [DataMember(Name = "account_id", EmitDefaultValue = true)]
        public string AccountId { get; set; }

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
        /// Gets or Sets OpportunityId
        /// </summary>
        [DataMember(Name = "opportunity_id", EmitDefaultValue = true)]
        public string OpportunityId { get; set; }

        /// <summary>
        /// Gets or Sets LeadId
        /// </summary>
        [DataMember(Name = "lead_id", EmitDefaultValue = true)]
        public string LeadId { get; set; }

        /// <summary>
        /// Gets or Sets OwnerId
        /// </summary>
        [DataMember(Name = "owner_id", EmitDefaultValue = true)]
        public string OwnerId { get; set; }

        /// <summary>
        /// Gets or Sets CampaignId
        /// </summary>
        [DataMember(Name = "campaign_id", EmitDefaultValue = true)]
        public string CampaignId { get; set; }

        /// <summary>
        /// Gets or Sets CaseId
        /// </summary>
        [DataMember(Name = "case_id", EmitDefaultValue = true)]
        public string CaseId { get; set; }

        /// <summary>
        /// Gets or Sets AssetId
        /// </summary>
        [DataMember(Name = "asset_id", EmitDefaultValue = true)]
        public string AssetId { get; set; }

        /// <summary>
        /// Gets or Sets ContractId
        /// </summary>
        [DataMember(Name = "contract_id", EmitDefaultValue = true)]
        public string ContractId { get; set; }

        /// <summary>
        /// Gets or Sets ProductId
        /// </summary>
        [DataMember(Name = "product_id", EmitDefaultValue = true)]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or Sets SolutionId
        /// </summary>
        [DataMember(Name = "solution_id", EmitDefaultValue = true)]
        public string SolutionId { get; set; }

        /// <summary>
        /// Gets or Sets CustomObjectId
        /// </summary>
        [DataMember(Name = "custom_object_id", EmitDefaultValue = true)]
        public string CustomObjectId { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = true)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name = "note", EmitDefaultValue = true)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [DataMember(Name = "location", EmitDefaultValue = true)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or Sets LocationAddress
        /// </summary>
        [DataMember(Name = "location_address", EmitDefaultValue = false)]
        public Address LocationAddress { get; set; }

        /// <summary>
        /// Gets or Sets AllDayEvent
        /// </summary>
        [DataMember(Name = "all_day_event", EmitDefaultValue = true)]
        public bool AllDayEvent { get; set; }

        /// <summary>
        /// Gets or Sets Private
        /// </summary>
        [DataMember(Name = "private", EmitDefaultValue = true)]
        public bool Private { get; set; }

        /// <summary>
        /// Gets or Sets GroupEvent
        /// </summary>
        [DataMember(Name = "group_event", EmitDefaultValue = true)]
        public bool GroupEvent { get; set; }

        /// <summary>
        /// Gets or Sets EventSubType
        /// </summary>
        [DataMember(Name = "event_sub_type", EmitDefaultValue = true)]
        public string EventSubType { get; set; }

        /// <summary>
        /// Gets or Sets GroupEventType
        /// </summary>
        [DataMember(Name = "group_event_type", EmitDefaultValue = true)]
        public string GroupEventType { get; set; }

        /// <summary>
        /// Gets or Sets Child
        /// </summary>
        [DataMember(Name = "child", EmitDefaultValue = true)]
        public bool Child { get; set; }

        /// <summary>
        /// Gets or Sets Archived
        /// </summary>
        [DataMember(Name = "archived", EmitDefaultValue = true)]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or Sets Deleted
        /// </summary>
        [DataMember(Name = "deleted", EmitDefaultValue = true)]
        public bool Deleted { get; set; }

        /// <summary>
        /// Whether the Activity is done or not
        /// </summary>
        /// <value>Whether the Activity is done or not</value>
        [DataMember(Name = "done", EmitDefaultValue = true)]
        public bool Done { get; set; }

        /// <summary>
        /// Gets or Sets StartDatetime
        /// </summary>
        [DataMember(Name = "start_datetime", EmitDefaultValue = true)]
        public string StartDatetime { get; set; }

        /// <summary>
        /// Gets or Sets EndDatetime
        /// </summary>
        [DataMember(Name = "end_datetime", EmitDefaultValue = true)]
        public string EndDatetime { get; set; }

        /// <summary>
        /// Gets or Sets DurationMinutes
        /// </summary>
        [DataMember(Name = "duration_minutes", EmitDefaultValue = true)]
        public int? DurationMinutes { get; private set; }

        /// <summary>
        /// Returns false as DurationMinutes should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDurationMinutes()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets ActivityDate
        /// </summary>
        [DataMember(Name = "activity_date", EmitDefaultValue = true)]
        public string ActivityDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        [DataMember(Name = "end_date", EmitDefaultValue = true)]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or Sets Recurrent
        /// </summary>
        [DataMember(Name = "recurrent", EmitDefaultValue = true)]
        public bool Recurrent { get; set; }

        /// <summary>
        /// Gets or Sets ReminderDatetime
        /// </summary>
        [DataMember(Name = "reminder_datetime", EmitDefaultValue = true)]
        public string ReminderDatetime { get; set; }

        /// <summary>
        /// Gets or Sets ReminderSet
        /// </summary>
        [DataMember(Name = "reminder_set", EmitDefaultValue = true)]
        public bool? ReminderSet { get; set; }

        /// <summary>
        /// Gets or Sets VideoConferenceUrl
        /// </summary>
        [DataMember(Name = "video_conference_url", EmitDefaultValue = false)]
        public string VideoConferenceUrl { get; set; }

        /// <summary>
        /// Gets or Sets VideoConferenceId
        /// </summary>
        [DataMember(Name = "video_conference_id", EmitDefaultValue = false)]
        public string VideoConferenceId { get; set; }

        /// <summary>
        /// Gets or Sets CustomFields
        /// </summary>
        [DataMember(Name = "custom_fields", EmitDefaultValue = false)]
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or Sets Attendees
        /// </summary>
        [DataMember(Name = "attendees", EmitDefaultValue = false)]
        public List<ActivityAttendee> Attendees { get; set; }

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
        public string UpdatedAt { get; private set; }

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
        public string CreatedAt { get; private set; }

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
            sb.Append("class Activity {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DownstreamId: ").Append(DownstreamId).Append("\n");
            sb.Append("  ActivityDatetime: ").Append(ActivityDatetime).Append("\n");
            sb.Append("  DurationSeconds: ").Append(DurationSeconds).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  ContactId: ").Append(ContactId).Append("\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  OpportunityId: ").Append(OpportunityId).Append("\n");
            sb.Append("  LeadId: ").Append(LeadId).Append("\n");
            sb.Append("  OwnerId: ").Append(OwnerId).Append("\n");
            sb.Append("  CampaignId: ").Append(CampaignId).Append("\n");
            sb.Append("  CaseId: ").Append(CaseId).Append("\n");
            sb.Append("  AssetId: ").Append(AssetId).Append("\n");
            sb.Append("  ContractId: ").Append(ContractId).Append("\n");
            sb.Append("  ProductId: ").Append(ProductId).Append("\n");
            sb.Append("  SolutionId: ").Append(SolutionId).Append("\n");
            sb.Append("  CustomObjectId: ").Append(CustomObjectId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  LocationAddress: ").Append(LocationAddress).Append("\n");
            sb.Append("  AllDayEvent: ").Append(AllDayEvent).Append("\n");
            sb.Append("  Private: ").Append(Private).Append("\n");
            sb.Append("  GroupEvent: ").Append(GroupEvent).Append("\n");
            sb.Append("  EventSubType: ").Append(EventSubType).Append("\n");
            sb.Append("  GroupEventType: ").Append(GroupEventType).Append("\n");
            sb.Append("  Child: ").Append(Child).Append("\n");
            sb.Append("  Archived: ").Append(Archived).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
            sb.Append("  ShowAs: ").Append(ShowAs).Append("\n");
            sb.Append("  Done: ").Append(Done).Append("\n");
            sb.Append("  StartDatetime: ").Append(StartDatetime).Append("\n");
            sb.Append("  EndDatetime: ").Append(EndDatetime).Append("\n");
            sb.Append("  DurationMinutes: ").Append(DurationMinutes).Append("\n");
            sb.Append("  ActivityDate: ").Append(ActivityDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  Recurrent: ").Append(Recurrent).Append("\n");
            sb.Append("  ReminderDatetime: ").Append(ReminderDatetime).Append("\n");
            sb.Append("  ReminderSet: ").Append(ReminderSet).Append("\n");
            sb.Append("  VideoConferenceUrl: ").Append(VideoConferenceUrl).Append("\n");
            sb.Append("  VideoConferenceId: ").Append(VideoConferenceId).Append("\n");
            sb.Append("  CustomFields: ").Append(CustomFields).Append("\n");
            sb.Append("  Attendees: ").Append(Attendees).Append("\n");
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
            return this.Equals(input as Activity);
        }

        /// <summary>
        /// Returns true if Activity instances are equal
        /// </summary>
        /// <param name="input">Instance of Activity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Activity input)
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
                    this.DownstreamId == input.DownstreamId ||
                    (this.DownstreamId != null &&
                    this.DownstreamId.Equals(input.DownstreamId))
                ) && 
                (
                    this.ActivityDatetime == input.ActivityDatetime ||
                    (this.ActivityDatetime != null &&
                    this.ActivityDatetime.Equals(input.ActivityDatetime))
                ) && 
                (
                    this.DurationSeconds == input.DurationSeconds ||
                    (this.DurationSeconds != null &&
                    this.DurationSeconds.Equals(input.DurationSeconds))
                ) && 
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
                ) && 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
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
                    this.OpportunityId == input.OpportunityId ||
                    (this.OpportunityId != null &&
                    this.OpportunityId.Equals(input.OpportunityId))
                ) && 
                (
                    this.LeadId == input.LeadId ||
                    (this.LeadId != null &&
                    this.LeadId.Equals(input.LeadId))
                ) && 
                (
                    this.OwnerId == input.OwnerId ||
                    (this.OwnerId != null &&
                    this.OwnerId.Equals(input.OwnerId))
                ) && 
                (
                    this.CampaignId == input.CampaignId ||
                    (this.CampaignId != null &&
                    this.CampaignId.Equals(input.CampaignId))
                ) && 
                (
                    this.CaseId == input.CaseId ||
                    (this.CaseId != null &&
                    this.CaseId.Equals(input.CaseId))
                ) && 
                (
                    this.AssetId == input.AssetId ||
                    (this.AssetId != null &&
                    this.AssetId.Equals(input.AssetId))
                ) && 
                (
                    this.ContractId == input.ContractId ||
                    (this.ContractId != null &&
                    this.ContractId.Equals(input.ContractId))
                ) && 
                (
                    this.ProductId == input.ProductId ||
                    (this.ProductId != null &&
                    this.ProductId.Equals(input.ProductId))
                ) && 
                (
                    this.SolutionId == input.SolutionId ||
                    (this.SolutionId != null &&
                    this.SolutionId.Equals(input.SolutionId))
                ) && 
                (
                    this.CustomObjectId == input.CustomObjectId ||
                    (this.CustomObjectId != null &&
                    this.CustomObjectId.Equals(input.CustomObjectId))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) && 
                (
                    this.Location == input.Location ||
                    (this.Location != null &&
                    this.Location.Equals(input.Location))
                ) && 
                (
                    this.LocationAddress == input.LocationAddress ||
                    (this.LocationAddress != null &&
                    this.LocationAddress.Equals(input.LocationAddress))
                ) && 
                (
                    this.AllDayEvent == input.AllDayEvent ||
                    this.AllDayEvent.Equals(input.AllDayEvent)
                ) && 
                (
                    this.Private == input.Private ||
                    this.Private.Equals(input.Private)
                ) && 
                (
                    this.GroupEvent == input.GroupEvent ||
                    this.GroupEvent.Equals(input.GroupEvent)
                ) && 
                (
                    this.EventSubType == input.EventSubType ||
                    (this.EventSubType != null &&
                    this.EventSubType.Equals(input.EventSubType))
                ) && 
                (
                    this.GroupEventType == input.GroupEventType ||
                    (this.GroupEventType != null &&
                    this.GroupEventType.Equals(input.GroupEventType))
                ) && 
                (
                    this.Child == input.Child ||
                    this.Child.Equals(input.Child)
                ) && 
                (
                    this.Archived == input.Archived ||
                    this.Archived.Equals(input.Archived)
                ) && 
                (
                    this.Deleted == input.Deleted ||
                    this.Deleted.Equals(input.Deleted)
                ) && 
                (
                    this.ShowAs == input.ShowAs ||
                    this.ShowAs.Equals(input.ShowAs)
                ) && 
                (
                    this.Done == input.Done ||
                    this.Done.Equals(input.Done)
                ) && 
                (
                    this.StartDatetime == input.StartDatetime ||
                    (this.StartDatetime != null &&
                    this.StartDatetime.Equals(input.StartDatetime))
                ) && 
                (
                    this.EndDatetime == input.EndDatetime ||
                    (this.EndDatetime != null &&
                    this.EndDatetime.Equals(input.EndDatetime))
                ) && 
                (
                    this.DurationMinutes == input.DurationMinutes ||
                    (this.DurationMinutes != null &&
                    this.DurationMinutes.Equals(input.DurationMinutes))
                ) && 
                (
                    this.ActivityDate == input.ActivityDate ||
                    (this.ActivityDate != null &&
                    this.ActivityDate.Equals(input.ActivityDate))
                ) && 
                (
                    this.EndDate == input.EndDate ||
                    (this.EndDate != null &&
                    this.EndDate.Equals(input.EndDate))
                ) && 
                (
                    this.Recurrent == input.Recurrent ||
                    this.Recurrent.Equals(input.Recurrent)
                ) && 
                (
                    this.ReminderDatetime == input.ReminderDatetime ||
                    (this.ReminderDatetime != null &&
                    this.ReminderDatetime.Equals(input.ReminderDatetime))
                ) && 
                (
                    this.ReminderSet == input.ReminderSet ||
                    (this.ReminderSet != null &&
                    this.ReminderSet.Equals(input.ReminderSet))
                ) && 
                (
                    this.VideoConferenceUrl == input.VideoConferenceUrl ||
                    (this.VideoConferenceUrl != null &&
                    this.VideoConferenceUrl.Equals(input.VideoConferenceUrl))
                ) && 
                (
                    this.VideoConferenceId == input.VideoConferenceId ||
                    (this.VideoConferenceId != null &&
                    this.VideoConferenceId.Equals(input.VideoConferenceId))
                ) && 
                (
                    this.CustomFields == input.CustomFields ||
                    this.CustomFields != null &&
                    input.CustomFields != null &&
                    this.CustomFields.SequenceEqual(input.CustomFields)
                ) && 
                (
                    this.Attendees == input.Attendees ||
                    this.Attendees != null &&
                    input.Attendees != null &&
                    this.Attendees.SequenceEqual(input.Attendees)
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
                if (this.DownstreamId != null)
                {
                    hashCode = (hashCode * 59) + this.DownstreamId.GetHashCode();
                }
                if (this.ActivityDatetime != null)
                {
                    hashCode = (hashCode * 59) + this.ActivityDatetime.GetHashCode();
                }
                if (this.DurationSeconds != null)
                {
                    hashCode = (hashCode * 59) + this.DurationSeconds.GetHashCode();
                }
                if (this.UserId != null)
                {
                    hashCode = (hashCode * 59) + this.UserId.GetHashCode();
                }
                if (this.AccountId != null)
                {
                    hashCode = (hashCode * 59) + this.AccountId.GetHashCode();
                }
                if (this.ContactId != null)
                {
                    hashCode = (hashCode * 59) + this.ContactId.GetHashCode();
                }
                if (this.CompanyId != null)
                {
                    hashCode = (hashCode * 59) + this.CompanyId.GetHashCode();
                }
                if (this.OpportunityId != null)
                {
                    hashCode = (hashCode * 59) + this.OpportunityId.GetHashCode();
                }
                if (this.LeadId != null)
                {
                    hashCode = (hashCode * 59) + this.LeadId.GetHashCode();
                }
                if (this.OwnerId != null)
                {
                    hashCode = (hashCode * 59) + this.OwnerId.GetHashCode();
                }
                if (this.CampaignId != null)
                {
                    hashCode = (hashCode * 59) + this.CampaignId.GetHashCode();
                }
                if (this.CaseId != null)
                {
                    hashCode = (hashCode * 59) + this.CaseId.GetHashCode();
                }
                if (this.AssetId != null)
                {
                    hashCode = (hashCode * 59) + this.AssetId.GetHashCode();
                }
                if (this.ContractId != null)
                {
                    hashCode = (hashCode * 59) + this.ContractId.GetHashCode();
                }
                if (this.ProductId != null)
                {
                    hashCode = (hashCode * 59) + this.ProductId.GetHashCode();
                }
                if (this.SolutionId != null)
                {
                    hashCode = (hashCode * 59) + this.SolutionId.GetHashCode();
                }
                if (this.CustomObjectId != null)
                {
                    hashCode = (hashCode * 59) + this.CustomObjectId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.Title != null)
                {
                    hashCode = (hashCode * 59) + this.Title.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.Note != null)
                {
                    hashCode = (hashCode * 59) + this.Note.GetHashCode();
                }
                if (this.Location != null)
                {
                    hashCode = (hashCode * 59) + this.Location.GetHashCode();
                }
                if (this.LocationAddress != null)
                {
                    hashCode = (hashCode * 59) + this.LocationAddress.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.AllDayEvent.GetHashCode();
                hashCode = (hashCode * 59) + this.Private.GetHashCode();
                hashCode = (hashCode * 59) + this.GroupEvent.GetHashCode();
                if (this.EventSubType != null)
                {
                    hashCode = (hashCode * 59) + this.EventSubType.GetHashCode();
                }
                if (this.GroupEventType != null)
                {
                    hashCode = (hashCode * 59) + this.GroupEventType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Child.GetHashCode();
                hashCode = (hashCode * 59) + this.Archived.GetHashCode();
                hashCode = (hashCode * 59) + this.Deleted.GetHashCode();
                hashCode = (hashCode * 59) + this.ShowAs.GetHashCode();
                hashCode = (hashCode * 59) + this.Done.GetHashCode();
                if (this.StartDatetime != null)
                {
                    hashCode = (hashCode * 59) + this.StartDatetime.GetHashCode();
                }
                if (this.EndDatetime != null)
                {
                    hashCode = (hashCode * 59) + this.EndDatetime.GetHashCode();
                }
                if (this.DurationMinutes != null)
                {
                    hashCode = (hashCode * 59) + this.DurationMinutes.GetHashCode();
                }
                if (this.ActivityDate != null)
                {
                    hashCode = (hashCode * 59) + this.ActivityDate.GetHashCode();
                }
                if (this.EndDate != null)
                {
                    hashCode = (hashCode * 59) + this.EndDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Recurrent.GetHashCode();
                if (this.ReminderDatetime != null)
                {
                    hashCode = (hashCode * 59) + this.ReminderDatetime.GetHashCode();
                }
                if (this.ReminderSet != null)
                {
                    hashCode = (hashCode * 59) + this.ReminderSet.GetHashCode();
                }
                if (this.VideoConferenceUrl != null)
                {
                    hashCode = (hashCode * 59) + this.VideoConferenceUrl.GetHashCode();
                }
                if (this.VideoConferenceId != null)
                {
                    hashCode = (hashCode * 59) + this.VideoConferenceId.GetHashCode();
                }
                if (this.CustomFields != null)
                {
                    hashCode = (hashCode * 59) + this.CustomFields.GetHashCode();
                }
                if (this.Attendees != null)
                {
                    hashCode = (hashCode * 59) + this.Attendees.GetHashCode();
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
            // ActivityDatetime (string) minLength
            if (this.ActivityDatetime != null && this.ActivityDatetime.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ActivityDatetime, length must be greater than 1.", new [] { "ActivityDatetime" });
            }

            // DurationSeconds (int?) minimum
            if (this.DurationSeconds < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DurationSeconds, must be a value greater than or equal to 0.", new [] { "DurationSeconds" });
            }

            yield break;
        }
    }

}
