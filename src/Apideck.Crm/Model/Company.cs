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
    /// Company
    /// </summary>
    [DataContract(Name = "Company")]
    public partial class Company : IEquatable<Company>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name = "currency", EmitDefaultValue = true)]
        public Currency? Currency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Company" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Company() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Company" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="ownerId">ownerId.</param>
        /// <param name="image">image.</param>
        /// <param name="description">description.</param>
        /// <param name="vatNumber">VAT number.</param>
        /// <param name="currency">currency.</param>
        /// <param name="status">status.</param>
        /// <param name="fax">fax.</param>
        /// <param name="annualRevenue">Annual revenue.</param>
        /// <param name="numberOfEmployees">Number of employees.</param>
        /// <param name="industry">Industry.</param>
        /// <param name="ownership">Ownership.</param>
        /// <param name="salesTaxNumber">salesTaxNumber.</param>
        /// <param name="payeeNumber">payeeNumber.</param>
        /// <param name="abnOrTfn">An ABN is necessary for operating a business, while a TFN (Tax File Number) is required for any person working in Australia..</param>
        /// <param name="abnBranch">An ABN Branch (also known as a GST Branch) is used if part of your business needs to account for GST separately from its parent entity..</param>
        /// <param name="acn">The Australian Company Number (ACN) is a nine digit number with the last digit being a check digit calculated using a modified modulus 10 calculation. ASIC has adopted a convention of always printing and displaying the ACN in the format XXX XXX XXX; three blocks of three characters, each block separated by a blank..</param>
        /// <param name="bankAccounts">bankAccounts.</param>
        /// <param name="websites">websites.</param>
        /// <param name="addresses">addresses.</param>
        /// <param name="socialLinks">socialLinks.</param>
        /// <param name="phoneNumbers">phoneNumbers.</param>
        /// <param name="emails">emails.</param>
        /// <param name="customFields">customFields.</param>
        /// <param name="tags">tags.</param>
        /// <param name="readOnly">readOnly.</param>
        public Company(string name = default(string), string ownerId = default(string), string image = default(string), string description = default(string), string vatNumber = default(string), Currency? currency = default(Currency?), string status = default(string), string fax = default(string), string annualRevenue = default(string), string numberOfEmployees = default(string), string industry = default(string), string ownership = default(string), string salesTaxNumber = default(string), string payeeNumber = default(string), string abnOrTfn = default(string), string abnBranch = default(string), string acn = default(string), List<BankAccount> bankAccounts = default(List<BankAccount>), List<Website> websites = default(List<Website>), List<Address> addresses = default(List<Address>), List<SocialLink> socialLinks = default(List<SocialLink>), List<PhoneNumber> phoneNumbers = default(List<PhoneNumber>), List<Email> emails = default(List<Email>), List<CustomField> customFields = default(List<CustomField>), List<string> tags = default(List<string>), bool? readOnly = default(bool?))
        {
            // to ensure "name" is required (not null)
            if (name == null) {
                throw new ArgumentNullException("name is a required property for Company and cannot be null");
            }
            this.Name = name;
            this.OwnerId = ownerId;
            this.Image = image;
            this.Description = description;
            this.VatNumber = vatNumber;
            this.Currency = currency;
            this.Status = status;
            this.Fax = fax;
            this.AnnualRevenue = annualRevenue;
            this.NumberOfEmployees = numberOfEmployees;
            this.Industry = industry;
            this.Ownership = ownership;
            this.SalesTaxNumber = salesTaxNumber;
            this.PayeeNumber = payeeNumber;
            this.AbnOrTfn = abnOrTfn;
            this.AbnBranch = abnBranch;
            this.Acn = acn;
            this.BankAccounts = bankAccounts;
            this.Websites = websites;
            this.Addresses = addresses;
            this.SocialLinks = socialLinks;
            this.PhoneNumbers = phoneNumbers;
            this.Emails = emails;
            this.CustomFields = customFields;
            this.Tags = tags;
            this.ReadOnly = readOnly;
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
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets InteractionCount
        /// </summary>
        [DataMember(Name = "interaction_count", EmitDefaultValue = true)]
        public int? InteractionCount { get; private set; }

        /// <summary>
        /// Returns false as InteractionCount should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeInteractionCount()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets OwnerId
        /// </summary>
        [DataMember(Name = "owner_id", EmitDefaultValue = false)]
        public string OwnerId { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name = "image", EmitDefaultValue = true)]
        public string Image { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// VAT number
        /// </summary>
        /// <value>VAT number</value>
        [DataMember(Name = "vat_number", EmitDefaultValue = true)]
        public string VatNumber { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets Fax
        /// </summary>
        [DataMember(Name = "fax", EmitDefaultValue = true)]
        public string Fax { get; set; }

        /// <summary>
        /// Annual revenue
        /// </summary>
        /// <value>Annual revenue</value>
        [DataMember(Name = "annual_revenue", EmitDefaultValue = true)]
        public string AnnualRevenue { get; set; }

        /// <summary>
        /// Number of employees
        /// </summary>
        /// <value>Number of employees</value>
        [DataMember(Name = "number_of_employees", EmitDefaultValue = true)]
        public string NumberOfEmployees { get; set; }

        /// <summary>
        /// Industry
        /// </summary>
        /// <value>Industry</value>
        [DataMember(Name = "industry", EmitDefaultValue = true)]
        public string Industry { get; set; }

        /// <summary>
        /// Ownership
        /// </summary>
        /// <value>Ownership</value>
        [DataMember(Name = "ownership", EmitDefaultValue = true)]
        public string Ownership { get; set; }

        /// <summary>
        /// Gets or Sets SalesTaxNumber
        /// </summary>
        [DataMember(Name = "sales_tax_number", EmitDefaultValue = true)]
        public string SalesTaxNumber { get; set; }

        /// <summary>
        /// Gets or Sets PayeeNumber
        /// </summary>
        [DataMember(Name = "payee_number", EmitDefaultValue = true)]
        public string PayeeNumber { get; set; }

        /// <summary>
        /// An ABN is necessary for operating a business, while a TFN (Tax File Number) is required for any person working in Australia.
        /// </summary>
        /// <value>An ABN is necessary for operating a business, while a TFN (Tax File Number) is required for any person working in Australia.</value>
        [DataMember(Name = "abn_or_tfn", EmitDefaultValue = true)]
        public string AbnOrTfn { get; set; }

        /// <summary>
        /// An ABN Branch (also known as a GST Branch) is used if part of your business needs to account for GST separately from its parent entity.
        /// </summary>
        /// <value>An ABN Branch (also known as a GST Branch) is used if part of your business needs to account for GST separately from its parent entity.</value>
        [DataMember(Name = "abn_branch", EmitDefaultValue = true)]
        public string AbnBranch { get; set; }

        /// <summary>
        /// The Australian Company Number (ACN) is a nine digit number with the last digit being a check digit calculated using a modified modulus 10 calculation. ASIC has adopted a convention of always printing and displaying the ACN in the format XXX XXX XXX; three blocks of three characters, each block separated by a blank.
        /// </summary>
        /// <value>The Australian Company Number (ACN) is a nine digit number with the last digit being a check digit calculated using a modified modulus 10 calculation. ASIC has adopted a convention of always printing and displaying the ACN in the format XXX XXX XXX; three blocks of three characters, each block separated by a blank.</value>
        [DataMember(Name = "acn", EmitDefaultValue = true)]
        public string Acn { get; set; }

        /// <summary>
        /// Parent ID
        /// </summary>
        /// <value>Parent ID</value>
        [DataMember(Name = "parent_id", EmitDefaultValue = false)]
        public string ParentId { get; private set; }

        /// <summary>
        /// Returns false as ParentId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeParentId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets BankAccounts
        /// </summary>
        [DataMember(Name = "bank_accounts", EmitDefaultValue = false)]
        public List<BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// Gets or Sets Websites
        /// </summary>
        [DataMember(Name = "websites", EmitDefaultValue = false)]
        public List<Website> Websites { get; set; }

        /// <summary>
        /// Gets or Sets Addresses
        /// </summary>
        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or Sets SocialLinks
        /// </summary>
        [DataMember(Name = "social_links", EmitDefaultValue = false)]
        public List<SocialLink> SocialLinks { get; set; }

        /// <summary>
        /// Gets or Sets PhoneNumbers
        /// </summary>
        [DataMember(Name = "phone_numbers", EmitDefaultValue = false)]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or Sets Emails
        /// </summary>
        [DataMember(Name = "emails", EmitDefaultValue = false)]
        public List<Email> Emails { get; set; }

        /// <summary>
        /// Gets or Sets CustomFields
        /// </summary>
        [DataMember(Name = "custom_fields", EmitDefaultValue = false)]
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or Sets ReadOnly
        /// </summary>
        [DataMember(Name = "read_only", EmitDefaultValue = true)]
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// Gets or Sets LastActivityAt
        /// </summary>
        [DataMember(Name = "last_activity_at", EmitDefaultValue = true)]
        public DateTime? LastActivityAt { get; private set; }

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
            sb.Append("class Company {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  InteractionCount: ").Append(InteractionCount).Append("\n");
            sb.Append("  OwnerId: ").Append(OwnerId).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  VatNumber: ").Append(VatNumber).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Fax: ").Append(Fax).Append("\n");
            sb.Append("  AnnualRevenue: ").Append(AnnualRevenue).Append("\n");
            sb.Append("  NumberOfEmployees: ").Append(NumberOfEmployees).Append("\n");
            sb.Append("  Industry: ").Append(Industry).Append("\n");
            sb.Append("  Ownership: ").Append(Ownership).Append("\n");
            sb.Append("  SalesTaxNumber: ").Append(SalesTaxNumber).Append("\n");
            sb.Append("  PayeeNumber: ").Append(PayeeNumber).Append("\n");
            sb.Append("  AbnOrTfn: ").Append(AbnOrTfn).Append("\n");
            sb.Append("  AbnBranch: ").Append(AbnBranch).Append("\n");
            sb.Append("  Acn: ").Append(Acn).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  BankAccounts: ").Append(BankAccounts).Append("\n");
            sb.Append("  Websites: ").Append(Websites).Append("\n");
            sb.Append("  Addresses: ").Append(Addresses).Append("\n");
            sb.Append("  SocialLinks: ").Append(SocialLinks).Append("\n");
            sb.Append("  PhoneNumbers: ").Append(PhoneNumbers).Append("\n");
            sb.Append("  Emails: ").Append(Emails).Append("\n");
            sb.Append("  CustomFields: ").Append(CustomFields).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  ReadOnly: ").Append(ReadOnly).Append("\n");
            sb.Append("  LastActivityAt: ").Append(LastActivityAt).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
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
            return this.Equals(input as Company);
        }

        /// <summary>
        /// Returns true if Company instances are equal
        /// </summary>
        /// <param name="input">Instance of Company to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Company input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.InteractionCount == input.InteractionCount ||
                    (this.InteractionCount != null &&
                    this.InteractionCount.Equals(input.InteractionCount))
                ) && 
                (
                    this.OwnerId == input.OwnerId ||
                    (this.OwnerId != null &&
                    this.OwnerId.Equals(input.OwnerId))
                ) && 
                (
                    this.Image == input.Image ||
                    (this.Image != null &&
                    this.Image.Equals(input.Image))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.VatNumber == input.VatNumber ||
                    (this.VatNumber != null &&
                    this.VatNumber.Equals(input.VatNumber))
                ) && 
                (
                    this.Currency == input.Currency ||
                    this.Currency.Equals(input.Currency)
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.Fax == input.Fax ||
                    (this.Fax != null &&
                    this.Fax.Equals(input.Fax))
                ) && 
                (
                    this.AnnualRevenue == input.AnnualRevenue ||
                    (this.AnnualRevenue != null &&
                    this.AnnualRevenue.Equals(input.AnnualRevenue))
                ) && 
                (
                    this.NumberOfEmployees == input.NumberOfEmployees ||
                    (this.NumberOfEmployees != null &&
                    this.NumberOfEmployees.Equals(input.NumberOfEmployees))
                ) && 
                (
                    this.Industry == input.Industry ||
                    (this.Industry != null &&
                    this.Industry.Equals(input.Industry))
                ) && 
                (
                    this.Ownership == input.Ownership ||
                    (this.Ownership != null &&
                    this.Ownership.Equals(input.Ownership))
                ) && 
                (
                    this.SalesTaxNumber == input.SalesTaxNumber ||
                    (this.SalesTaxNumber != null &&
                    this.SalesTaxNumber.Equals(input.SalesTaxNumber))
                ) && 
                (
                    this.PayeeNumber == input.PayeeNumber ||
                    (this.PayeeNumber != null &&
                    this.PayeeNumber.Equals(input.PayeeNumber))
                ) && 
                (
                    this.AbnOrTfn == input.AbnOrTfn ||
                    (this.AbnOrTfn != null &&
                    this.AbnOrTfn.Equals(input.AbnOrTfn))
                ) && 
                (
                    this.AbnBranch == input.AbnBranch ||
                    (this.AbnBranch != null &&
                    this.AbnBranch.Equals(input.AbnBranch))
                ) && 
                (
                    this.Acn == input.Acn ||
                    (this.Acn != null &&
                    this.Acn.Equals(input.Acn))
                ) && 
                (
                    this.ParentId == input.ParentId ||
                    (this.ParentId != null &&
                    this.ParentId.Equals(input.ParentId))
                ) && 
                (
                    this.BankAccounts == input.BankAccounts ||
                    this.BankAccounts != null &&
                    input.BankAccounts != null &&
                    this.BankAccounts.SequenceEqual(input.BankAccounts)
                ) && 
                (
                    this.Websites == input.Websites ||
                    this.Websites != null &&
                    input.Websites != null &&
                    this.Websites.SequenceEqual(input.Websites)
                ) && 
                (
                    this.Addresses == input.Addresses ||
                    this.Addresses != null &&
                    input.Addresses != null &&
                    this.Addresses.SequenceEqual(input.Addresses)
                ) && 
                (
                    this.SocialLinks == input.SocialLinks ||
                    this.SocialLinks != null &&
                    input.SocialLinks != null &&
                    this.SocialLinks.SequenceEqual(input.SocialLinks)
                ) && 
                (
                    this.PhoneNumbers == input.PhoneNumbers ||
                    this.PhoneNumbers != null &&
                    input.PhoneNumbers != null &&
                    this.PhoneNumbers.SequenceEqual(input.PhoneNumbers)
                ) && 
                (
                    this.Emails == input.Emails ||
                    this.Emails != null &&
                    input.Emails != null &&
                    this.Emails.SequenceEqual(input.Emails)
                ) && 
                (
                    this.CustomFields == input.CustomFields ||
                    this.CustomFields != null &&
                    input.CustomFields != null &&
                    this.CustomFields.SequenceEqual(input.CustomFields)
                ) && 
                (
                    this.Tags == input.Tags ||
                    this.Tags != null &&
                    input.Tags != null &&
                    this.Tags.SequenceEqual(input.Tags)
                ) && 
                (
                    this.ReadOnly == input.ReadOnly ||
                    (this.ReadOnly != null &&
                    this.ReadOnly.Equals(input.ReadOnly))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.InteractionCount != null)
                {
                    hashCode = (hashCode * 59) + this.InteractionCount.GetHashCode();
                }
                if (this.OwnerId != null)
                {
                    hashCode = (hashCode * 59) + this.OwnerId.GetHashCode();
                }
                if (this.Image != null)
                {
                    hashCode = (hashCode * 59) + this.Image.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.VatNumber != null)
                {
                    hashCode = (hashCode * 59) + this.VatNumber.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Currency.GetHashCode();
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
                if (this.Fax != null)
                {
                    hashCode = (hashCode * 59) + this.Fax.GetHashCode();
                }
                if (this.AnnualRevenue != null)
                {
                    hashCode = (hashCode * 59) + this.AnnualRevenue.GetHashCode();
                }
                if (this.NumberOfEmployees != null)
                {
                    hashCode = (hashCode * 59) + this.NumberOfEmployees.GetHashCode();
                }
                if (this.Industry != null)
                {
                    hashCode = (hashCode * 59) + this.Industry.GetHashCode();
                }
                if (this.Ownership != null)
                {
                    hashCode = (hashCode * 59) + this.Ownership.GetHashCode();
                }
                if (this.SalesTaxNumber != null)
                {
                    hashCode = (hashCode * 59) + this.SalesTaxNumber.GetHashCode();
                }
                if (this.PayeeNumber != null)
                {
                    hashCode = (hashCode * 59) + this.PayeeNumber.GetHashCode();
                }
                if (this.AbnOrTfn != null)
                {
                    hashCode = (hashCode * 59) + this.AbnOrTfn.GetHashCode();
                }
                if (this.AbnBranch != null)
                {
                    hashCode = (hashCode * 59) + this.AbnBranch.GetHashCode();
                }
                if (this.Acn != null)
                {
                    hashCode = (hashCode * 59) + this.Acn.GetHashCode();
                }
                if (this.ParentId != null)
                {
                    hashCode = (hashCode * 59) + this.ParentId.GetHashCode();
                }
                if (this.BankAccounts != null)
                {
                    hashCode = (hashCode * 59) + this.BankAccounts.GetHashCode();
                }
                if (this.Websites != null)
                {
                    hashCode = (hashCode * 59) + this.Websites.GetHashCode();
                }
                if (this.Addresses != null)
                {
                    hashCode = (hashCode * 59) + this.Addresses.GetHashCode();
                }
                if (this.SocialLinks != null)
                {
                    hashCode = (hashCode * 59) + this.SocialLinks.GetHashCode();
                }
                if (this.PhoneNumbers != null)
                {
                    hashCode = (hashCode * 59) + this.PhoneNumbers.GetHashCode();
                }
                if (this.Emails != null)
                {
                    hashCode = (hashCode * 59) + this.Emails.GetHashCode();
                }
                if (this.CustomFields != null)
                {
                    hashCode = (hashCode * 59) + this.CustomFields.GetHashCode();
                }
                if (this.Tags != null)
                {
                    hashCode = (hashCode * 59) + this.Tags.GetHashCode();
                }
                if (this.ReadOnly != null)
                {
                    hashCode = (hashCode * 59) + this.ReadOnly.GetHashCode();
                }
                if (this.LastActivityAt != null)
                {
                    hashCode = (hashCode * 59) + this.LastActivityAt.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Deleted.GetHashCode();
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
            // Name (string) minLength
            if (this.Name != null && this.Name.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 1.", new [] { "Name" });
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
