/*
 * Lead API
 *
 * Welcome to the Lead API.  You can use this API to access all Lead API endpoints.  ## Base URL  The base URL for all API requests is `https://unify.apideck.com`  ## GraphQL  Use the [GraphQL playground](https://developers.apideck.com/graphql/playground) to test out the GraphQL API.  ## Headers  Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.  | Name                  | Type    | Required | Description                                                                                                                                                    | | - -- -- -- -- -- -- -- -- -- -- | - -- -- -- | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | x-apideck-consumer-id | String  | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app. | | x-apideck-service-id  | String  | No       | Describe the service you want to call (e.g., pipedrive). Only needed when a customer has activated multiple integrations for the same Unified API.             | | x-apideck-raw         | Boolean | No       | Include raw response. Mostly used for debugging purposes.                                                                                                      | | x-apideck-app-id      | String  | Yes      | The application id of your Unify application. Available at https://app.apideck.com/unify/api-keys.                                                             | | Authorization         | String  | Yes      | Bearer API KEY                                                                                                                                                 |  ## Authorization  You can interact with the API through the authorization methods below.  <!- - ReDoc-Inject: <security-definitions> - ->  ## Pagination  All API resources have support for bulk retrieval via list APIs.  Apideck uses cursor-based pagination via the optional `cursor` and `limit` parameters.  To fetch the first page of results, call the list API without a `cursor` parameter. Afterwards you can fetch subsequent pages by providing a cursor parameter. You will find the next cursor in the response body in `meta.cursors.next`. If `meta.cursors.next` is `null` you're at the end of the list.  In the REST API you can also use the `links` from the response for added convenience. Simply call the URL in `links.next` to get the next page of results.  ### Query Parameters  | Name   | Type   | Required | Description                                                                                                        | | - -- -- - | - -- -- - | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | cursor | String | No       | Cursor to start from. You can find cursors for next & previous pages in the meta.cursors property of the response. | | limit  | Number | No       | Number of results to return. Minimum 1, Maximum 200, Default 20                                                    |  ### Response Body  | Name                  | Type   | Description                                                        | | - -- -- -- -- -- -- -- -- -- -- | - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | meta.cursors.previous | String | Cursor to navigate to the previous page of results through the API | | meta.cursors.current  | String | Cursor to navigate to the current page of results through the API  | | meta.cursors.next     | String | Cursor to navigate to the next page of results through the API     | | meta.items_on_page    | Number | Number of items returned in the data property of the response      | | links.previous        | String | Link to navigate to the previous page of results through the API   | | links.current         | String | Link to navigate to the current page of results through the API    | | links.next            | String | Link to navigate to the next page of results through the API       |  ⚠️ `meta.cursors.previous`/`links.previous` is not available for all connectors.  ## SDKs and API Clients  Upcoming. [Request the SDK of your choice](https://integrations.apideck.com/request).  ## Debugging  Because of the nature of the abstraction we do in Apideck Unify we still provide the option to the receive raw requests and responses being handled underlying. By including the raw flag `?raw=true` in your requests you can still receive the full request. Please note that this increases the response size and can introduce extra latency.  ## Errors  The API returns standard HTTP response codes to indicate success or failure of the API requests. For errors, we also return a customized error message inside the JSON response. You can see the returned HTTP status codes below.  | Code | Title                | Description                                                                                                                                                                                              | | - -- - | - -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | 200  | OK                   | The request message has been successfully processed, and it has produced a response. The response message varies, depending on the request method and the requested data.                                | | 201  | Created              | The request has been fulfilled and has resulted in one or more new resources being created.                                                                                                              | | 204  | No Content           | The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.                                                                          | | 400  | Bad Request          | The receiving server cannot understand the request because of malformed syntax. Do not repeat the request without first modifying it; check the request for errors, fix them and then retry the request. | | 401  | Unauthorized         | The request has not been applied because it lacks valid authentication credentials for the target resource.                                                                                              | | 402  | Payment Required     | Subscription data is incomplete or out of date. You'll need to provide payment details to continue.                                                                                                      | | 403  | Forbidden            | You do not have the appropriate user rights to access the request. Do not repeat the request.                                                                                                            | | 404  | Not Found            | The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.                                                                           | | 409  | Conflict             | The request could not be completed due to a conflict with the current state of the target resource.                                                                                                      | | 422  | Unprocessable Entity | The server understands the content type of the request entity, and the syntax of the request entity is correct but was unable to process the contained instructions.                                     | | 5xx  | Server Errors        | Something went wrong with the Unify API. These errors are logged on our side. You can contact our team to resolve the issue.                                                                             |  ### Handling errors  The Unify API and SDKs can produce errors for many reasons, such as a failed requests due to misconfigured integrations, invalid parameters, authentication errors, and network unavailability.  ### Error Types  #### RequestValidationError  Request is not valid for the current endpoint. The response body will include details on the validation error. Check the spelling and types of your attributes, and ensure you are not passing data that is outside of the specification.  #### UnsupportedFiltersError  Filters in the request are valid, but not supported by the connector. Remove the unsupported filter(s) to get a successful response.  #### UnsupportedSortFieldError  Sort field (`sort[by]`) in the request is valid, but not supported by the connector. Replace or remove the sort field to get a successful response.  #### InvalidCursorError  Pagination cursor in the request is not valid for the current connector. Make sure to use a cursor returned from the API, for the same connector.  #### ConnectorExecutionError  A Unified API request made via one of our downstream connectors returned an unexpected error. The `status_code` returned is proxied through to error response along with their original response via the error detail.  #### ConnectorProcessingError  A Unified API request made via one of our downstream connectors returned a status code that was less than 400, along with a description of why the request could not be processed. Often this is due to the shape of request data being valid, but unable to be processed due to internal business logic - for example: an invalid relationship or `ID` present in your request.  #### UnauthorizedError  We were unable to authorize the request as made. This can happen for a number of reasons, from missing header params to passing an incorrect authorization token. Verify your Api Key is being set correctly in the authorization header. ie: `Authorization: 'Bearer sk_live_***'`  #### ConnectorCredentialsError  A request using a given connector has not been authorized. Ensure the connector you are trying to use has been configured correctly and been authorized for use.  #### ConnectorDisabledError  A request has been made to a connector that has since been disabled. This may be temporary - You can contact our team to resolve the issue.  #### RequestLimitError  You have reached the number of requests included in your Free Tier Subscription. You will no be able to make further requests until this limit resets at the end of the month, or talk to us about upgrading your subscription to continue immediately.  #### EntityNotFoundError  You've made a request for a resource or route that does not exist. Verify your path parameters or any identifiers used to fetch this resource.  #### OAuthCredentialsNotFoundError  When adding a connector integration that implements OAuth, both a `client_id` and `client_secret` must be provided before any authorizations can be performed. Verify the integration has been configured properly before continuing.  #### IntegrationNotFoundError  The requested connector integration could not be found associated to your `application_id`. Verify your `application_id` is correct, and that this connector has been added and configured for your application.  #### ConnectionNotFoundError  A valid connection could not be found associated to your `application_id`. Something _may_ have interrupted the authorization flow. You may need to start the connector authorization process again.  #### ConnectorNotFoundError  A request was made for an unknown connector. Verify your `service_id` is spelled correctly, and that this connector is enabled for your provided `unified_api`.  #### OAuthRedirectUriError  A request was made either in a connector authorization flow, or attempting to revoke connector access without a valid `redirect_uri`. This is the url the user should be returned to on completion of process.  #### OAuthInvalidStateError  The state param is required and is used to ensure the outgoing authorization state has not been altered before the user is redirected back. It also contains required params needed to identify the connector being used. If this has been altered, the authorization will not succeed.  #### OAuthCodeExchangeError  When attempting to exchange the authorization code for an `access_token` during an OAuth flow, an error occurred. This may be temporary. You can reattempt authorization or contact our team to resolve the issue.  #### MappingError  There was an error attempting to retrieve the mapping for a given attribute. We've been notified and are working to fix this issue.  #### ConnectorMappingNotFoundError  It seems the implementation for this connector is incomplete. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorResponseMappingNotFoundError  We were unable to retrieve the response mapping for this connector. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorOperationMappingNotFoundError  Connector mapping has not been implemented for the requested operation. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorWorkflowMappingError  The composite api calls required for this operation have not been mapped entirely. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### PaginationNotSupportedError  Pagination is not yet supported for this connector, try removing limit and/or cursor from the query. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  ## API Design  ### API Styles and data formats  #### REST API  The API is organized around [REST](https://restfulapi.net/), providing simple and predictable URIs to access and modify objects. Requests support standard HTTP methods like GET, PUT, POST, and DELETE and standard status codes. JSON is returned by all API responses, including errors. In all API requests, you must set the content-type HTTP header to application/json. All API requests must be made over HTTPS. Calls made over HTTP will fail.  ##### Available HTTP methods  The Apideck API uses HTTP verbs to understand if you want to read (GET), delete (DELETE) or create (POST) an object. When your web application cannot do a POST or DELETE, we provide the ability to set the method through the query parameter \\_method.  ``` POST /messages GET /messages GET /messages/{messageId} PATCH /messages/{messageId} DELETE /messages/{messageId} ```  Response bodies are always UTF-8 encoded JSON objects, unless explicitly documented otherwise. For some endpoints and use cases we divert from REST to provide a better developer experience.  ### Schema  All API requests and response bodies adhere to a common JSON format representing individual items, collections of items, links to related items and additional meta data.  ### Meta  Meta data can be represented as a top level member named “meta”. Any information may be provided in the meta data. It’s most common use is to return the total number of records when requesting a collection of resources.  ### Idempotence (upcoming)  To prevent the creation of duplicate resources, every POST method (such as one that creates a consumer record) must specify a unique value for the X-Unique-Transaction-ID header name. Uniquely identifying each unique POST request ensures that the API processes a given request once and only once.  Uniquely identifying new resource-creation POSTs is especially important when the outcome of a response is ambiguous because of a transient service interruption, such as a server-side timeout or network disruption. If a service interruption occurs, then the client application can safely retry the uniquely identified request without creating duplicate operations. (API endpoints that guarantee that every uniquely identified request is processed only once no matter how many times that uniquely identifiable request is made are described as idempotent.)  ### Request IDs  Each API request has an associated request identifier. You can find this value in the response headers, under Request-Id. You can also find request identifiers in the URLs of individual request logs in your Dashboard. If you need to contact us about a specific request, providing the request identifier will ensure the fastest possible resolution.  ### Fixed field types  #### Dates  The dates returned by the API are all represented in UTC (ISO8601 format).  This example `2019-11-14T00:55:31.820Z` is defined by the ISO 8601 standard. The T in the middle separates the year-month-day portion from the hour-minute-second portion. The Z on the end means UTC, that is, an offset-from-UTC of zero hours-minutes-seconds. The Z is pronounced \"Zulu\" per military/aviation tradition.  The ISO 8601 standard is more modern. The formats are wisely designed to be easy to parse by machine as well as easy to read by humans across cultures.  #### Prices and Currencies  All prices returned by the API are represented as integer amounts in a currency’s smallest unit. For example, $5 USD would be returned as 500 (i.e, 500 cents).  For zero-decimal currencies, amounts will still be provided as an integer but without the need to divide by 100. For example, an amount of ¥5 (JPY) would be returned as 5.  All currency codes conform to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).  ## Support  If you have problems or need help with your case, you can always reach out to our Support. 
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
using OpenAPIDateConverter = Apideck.Leads.Client.OpenAPIDateConverter;

namespace Apideck.Leads.Model
{
    /// <summary>
    /// Indicates the associated currency for an amount of money. Values correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).
    /// </summary>
    /// <value>Indicates the associated currency for an amount of money. Values correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Currency
    {
        /// <summary>
        /// Enum UNKNOWNCURRENCY for value: UNKNOWN_CURRENCY
        /// </summary>
        [EnumMember(Value = "UNKNOWN_CURRENCY")]
        UNKNOWNCURRENCY = 1,

        /// <summary>
        /// Enum AED for value: AED
        /// </summary>
        [EnumMember(Value = "AED")]
        AED = 2,

        /// <summary>
        /// Enum AFN for value: AFN
        /// </summary>
        [EnumMember(Value = "AFN")]
        AFN = 3,

        /// <summary>
        /// Enum ALL for value: ALL
        /// </summary>
        [EnumMember(Value = "ALL")]
        ALL = 4,

        /// <summary>
        /// Enum AMD for value: AMD
        /// </summary>
        [EnumMember(Value = "AMD")]
        AMD = 5,

        /// <summary>
        /// Enum ANG for value: ANG
        /// </summary>
        [EnumMember(Value = "ANG")]
        ANG = 6,

        /// <summary>
        /// Enum AOA for value: AOA
        /// </summary>
        [EnumMember(Value = "AOA")]
        AOA = 7,

        /// <summary>
        /// Enum ARS for value: ARS
        /// </summary>
        [EnumMember(Value = "ARS")]
        ARS = 8,

        /// <summary>
        /// Enum AUD for value: AUD
        /// </summary>
        [EnumMember(Value = "AUD")]
        AUD = 9,

        /// <summary>
        /// Enum AWG for value: AWG
        /// </summary>
        [EnumMember(Value = "AWG")]
        AWG = 10,

        /// <summary>
        /// Enum AZN for value: AZN
        /// </summary>
        [EnumMember(Value = "AZN")]
        AZN = 11,

        /// <summary>
        /// Enum BAM for value: BAM
        /// </summary>
        [EnumMember(Value = "BAM")]
        BAM = 12,

        /// <summary>
        /// Enum BBD for value: BBD
        /// </summary>
        [EnumMember(Value = "BBD")]
        BBD = 13,

        /// <summary>
        /// Enum BDT for value: BDT
        /// </summary>
        [EnumMember(Value = "BDT")]
        BDT = 14,

        /// <summary>
        /// Enum BGN for value: BGN
        /// </summary>
        [EnumMember(Value = "BGN")]
        BGN = 15,

        /// <summary>
        /// Enum BHD for value: BHD
        /// </summary>
        [EnumMember(Value = "BHD")]
        BHD = 16,

        /// <summary>
        /// Enum BIF for value: BIF
        /// </summary>
        [EnumMember(Value = "BIF")]
        BIF = 17,

        /// <summary>
        /// Enum BMD for value: BMD
        /// </summary>
        [EnumMember(Value = "BMD")]
        BMD = 18,

        /// <summary>
        /// Enum BND for value: BND
        /// </summary>
        [EnumMember(Value = "BND")]
        BND = 19,

        /// <summary>
        /// Enum BOB for value: BOB
        /// </summary>
        [EnumMember(Value = "BOB")]
        BOB = 20,

        /// <summary>
        /// Enum BOV for value: BOV
        /// </summary>
        [EnumMember(Value = "BOV")]
        BOV = 21,

        /// <summary>
        /// Enum BRL for value: BRL
        /// </summary>
        [EnumMember(Value = "BRL")]
        BRL = 22,

        /// <summary>
        /// Enum BSD for value: BSD
        /// </summary>
        [EnumMember(Value = "BSD")]
        BSD = 23,

        /// <summary>
        /// Enum BTN for value: BTN
        /// </summary>
        [EnumMember(Value = "BTN")]
        BTN = 24,

        /// <summary>
        /// Enum BWP for value: BWP
        /// </summary>
        [EnumMember(Value = "BWP")]
        BWP = 25,

        /// <summary>
        /// Enum BYR for value: BYR
        /// </summary>
        [EnumMember(Value = "BYR")]
        BYR = 26,

        /// <summary>
        /// Enum BZD for value: BZD
        /// </summary>
        [EnumMember(Value = "BZD")]
        BZD = 27,

        /// <summary>
        /// Enum CAD for value: CAD
        /// </summary>
        [EnumMember(Value = "CAD")]
        CAD = 28,

        /// <summary>
        /// Enum CDF for value: CDF
        /// </summary>
        [EnumMember(Value = "CDF")]
        CDF = 29,

        /// <summary>
        /// Enum CHE for value: CHE
        /// </summary>
        [EnumMember(Value = "CHE")]
        CHE = 30,

        /// <summary>
        /// Enum CHF for value: CHF
        /// </summary>
        [EnumMember(Value = "CHF")]
        CHF = 31,

        /// <summary>
        /// Enum CHW for value: CHW
        /// </summary>
        [EnumMember(Value = "CHW")]
        CHW = 32,

        /// <summary>
        /// Enum CLF for value: CLF
        /// </summary>
        [EnumMember(Value = "CLF")]
        CLF = 33,

        /// <summary>
        /// Enum CLP for value: CLP
        /// </summary>
        [EnumMember(Value = "CLP")]
        CLP = 34,

        /// <summary>
        /// Enum CNY for value: CNY
        /// </summary>
        [EnumMember(Value = "CNY")]
        CNY = 35,

        /// <summary>
        /// Enum COP for value: COP
        /// </summary>
        [EnumMember(Value = "COP")]
        COP = 36,

        /// <summary>
        /// Enum COU for value: COU
        /// </summary>
        [EnumMember(Value = "COU")]
        COU = 37,

        /// <summary>
        /// Enum CRC for value: CRC
        /// </summary>
        [EnumMember(Value = "CRC")]
        CRC = 38,

        /// <summary>
        /// Enum CUC for value: CUC
        /// </summary>
        [EnumMember(Value = "CUC")]
        CUC = 39,

        /// <summary>
        /// Enum CUP for value: CUP
        /// </summary>
        [EnumMember(Value = "CUP")]
        CUP = 40,

        /// <summary>
        /// Enum CVE for value: CVE
        /// </summary>
        [EnumMember(Value = "CVE")]
        CVE = 41,

        /// <summary>
        /// Enum CZK for value: CZK
        /// </summary>
        [EnumMember(Value = "CZK")]
        CZK = 42,

        /// <summary>
        /// Enum DJF for value: DJF
        /// </summary>
        [EnumMember(Value = "DJF")]
        DJF = 43,

        /// <summary>
        /// Enum DKK for value: DKK
        /// </summary>
        [EnumMember(Value = "DKK")]
        DKK = 44,

        /// <summary>
        /// Enum DOP for value: DOP
        /// </summary>
        [EnumMember(Value = "DOP")]
        DOP = 45,

        /// <summary>
        /// Enum DZD for value: DZD
        /// </summary>
        [EnumMember(Value = "DZD")]
        DZD = 46,

        /// <summary>
        /// Enum EGP for value: EGP
        /// </summary>
        [EnumMember(Value = "EGP")]
        EGP = 47,

        /// <summary>
        /// Enum ERN for value: ERN
        /// </summary>
        [EnumMember(Value = "ERN")]
        ERN = 48,

        /// <summary>
        /// Enum ETB for value: ETB
        /// </summary>
        [EnumMember(Value = "ETB")]
        ETB = 49,

        /// <summary>
        /// Enum EUR for value: EUR
        /// </summary>
        [EnumMember(Value = "EUR")]
        EUR = 50,

        /// <summary>
        /// Enum FJD for value: FJD
        /// </summary>
        [EnumMember(Value = "FJD")]
        FJD = 51,

        /// <summary>
        /// Enum FKP for value: FKP
        /// </summary>
        [EnumMember(Value = "FKP")]
        FKP = 52,

        /// <summary>
        /// Enum GBP for value: GBP
        /// </summary>
        [EnumMember(Value = "GBP")]
        GBP = 53,

        /// <summary>
        /// Enum GEL for value: GEL
        /// </summary>
        [EnumMember(Value = "GEL")]
        GEL = 54,

        /// <summary>
        /// Enum GHS for value: GHS
        /// </summary>
        [EnumMember(Value = "GHS")]
        GHS = 55,

        /// <summary>
        /// Enum GIP for value: GIP
        /// </summary>
        [EnumMember(Value = "GIP")]
        GIP = 56,

        /// <summary>
        /// Enum GMD for value: GMD
        /// </summary>
        [EnumMember(Value = "GMD")]
        GMD = 57,

        /// <summary>
        /// Enum GNF for value: GNF
        /// </summary>
        [EnumMember(Value = "GNF")]
        GNF = 58,

        /// <summary>
        /// Enum GTQ for value: GTQ
        /// </summary>
        [EnumMember(Value = "GTQ")]
        GTQ = 59,

        /// <summary>
        /// Enum GYD for value: GYD
        /// </summary>
        [EnumMember(Value = "GYD")]
        GYD = 60,

        /// <summary>
        /// Enum HKD for value: HKD
        /// </summary>
        [EnumMember(Value = "HKD")]
        HKD = 61,

        /// <summary>
        /// Enum HNL for value: HNL
        /// </summary>
        [EnumMember(Value = "HNL")]
        HNL = 62,

        /// <summary>
        /// Enum HRK for value: HRK
        /// </summary>
        [EnumMember(Value = "HRK")]
        HRK = 63,

        /// <summary>
        /// Enum HTG for value: HTG
        /// </summary>
        [EnumMember(Value = "HTG")]
        HTG = 64,

        /// <summary>
        /// Enum HUF for value: HUF
        /// </summary>
        [EnumMember(Value = "HUF")]
        HUF = 65,

        /// <summary>
        /// Enum IDR for value: IDR
        /// </summary>
        [EnumMember(Value = "IDR")]
        IDR = 66,

        /// <summary>
        /// Enum ILS for value: ILS
        /// </summary>
        [EnumMember(Value = "ILS")]
        ILS = 67,

        /// <summary>
        /// Enum INR for value: INR
        /// </summary>
        [EnumMember(Value = "INR")]
        INR = 68,

        /// <summary>
        /// Enum IQD for value: IQD
        /// </summary>
        [EnumMember(Value = "IQD")]
        IQD = 69,

        /// <summary>
        /// Enum IRR for value: IRR
        /// </summary>
        [EnumMember(Value = "IRR")]
        IRR = 70,

        /// <summary>
        /// Enum ISK for value: ISK
        /// </summary>
        [EnumMember(Value = "ISK")]
        ISK = 71,

        /// <summary>
        /// Enum JMD for value: JMD
        /// </summary>
        [EnumMember(Value = "JMD")]
        JMD = 72,

        /// <summary>
        /// Enum JOD for value: JOD
        /// </summary>
        [EnumMember(Value = "JOD")]
        JOD = 73,

        /// <summary>
        /// Enum JPY for value: JPY
        /// </summary>
        [EnumMember(Value = "JPY")]
        JPY = 74,

        /// <summary>
        /// Enum KES for value: KES
        /// </summary>
        [EnumMember(Value = "KES")]
        KES = 75,

        /// <summary>
        /// Enum KGS for value: KGS
        /// </summary>
        [EnumMember(Value = "KGS")]
        KGS = 76,

        /// <summary>
        /// Enum KHR for value: KHR
        /// </summary>
        [EnumMember(Value = "KHR")]
        KHR = 77,

        /// <summary>
        /// Enum KMF for value: KMF
        /// </summary>
        [EnumMember(Value = "KMF")]
        KMF = 78,

        /// <summary>
        /// Enum KPW for value: KPW
        /// </summary>
        [EnumMember(Value = "KPW")]
        KPW = 79,

        /// <summary>
        /// Enum KRW for value: KRW
        /// </summary>
        [EnumMember(Value = "KRW")]
        KRW = 80,

        /// <summary>
        /// Enum KWD for value: KWD
        /// </summary>
        [EnumMember(Value = "KWD")]
        KWD = 81,

        /// <summary>
        /// Enum KYD for value: KYD
        /// </summary>
        [EnumMember(Value = "KYD")]
        KYD = 82,

        /// <summary>
        /// Enum KZT for value: KZT
        /// </summary>
        [EnumMember(Value = "KZT")]
        KZT = 83,

        /// <summary>
        /// Enum LAK for value: LAK
        /// </summary>
        [EnumMember(Value = "LAK")]
        LAK = 84,

        /// <summary>
        /// Enum LBP for value: LBP
        /// </summary>
        [EnumMember(Value = "LBP")]
        LBP = 85,

        /// <summary>
        /// Enum LKR for value: LKR
        /// </summary>
        [EnumMember(Value = "LKR")]
        LKR = 86,

        /// <summary>
        /// Enum LRD for value: LRD
        /// </summary>
        [EnumMember(Value = "LRD")]
        LRD = 87,

        /// <summary>
        /// Enum LSL for value: LSL
        /// </summary>
        [EnumMember(Value = "LSL")]
        LSL = 88,

        /// <summary>
        /// Enum LTL for value: LTL
        /// </summary>
        [EnumMember(Value = "LTL")]
        LTL = 89,

        /// <summary>
        /// Enum LVL for value: LVL
        /// </summary>
        [EnumMember(Value = "LVL")]
        LVL = 90,

        /// <summary>
        /// Enum LYD for value: LYD
        /// </summary>
        [EnumMember(Value = "LYD")]
        LYD = 91,

        /// <summary>
        /// Enum MAD for value: MAD
        /// </summary>
        [EnumMember(Value = "MAD")]
        MAD = 92,

        /// <summary>
        /// Enum MDL for value: MDL
        /// </summary>
        [EnumMember(Value = "MDL")]
        MDL = 93,

        /// <summary>
        /// Enum MGA for value: MGA
        /// </summary>
        [EnumMember(Value = "MGA")]
        MGA = 94,

        /// <summary>
        /// Enum MKD for value: MKD
        /// </summary>
        [EnumMember(Value = "MKD")]
        MKD = 95,

        /// <summary>
        /// Enum MMK for value: MMK
        /// </summary>
        [EnumMember(Value = "MMK")]
        MMK = 96,

        /// <summary>
        /// Enum MNT for value: MNT
        /// </summary>
        [EnumMember(Value = "MNT")]
        MNT = 97,

        /// <summary>
        /// Enum MOP for value: MOP
        /// </summary>
        [EnumMember(Value = "MOP")]
        MOP = 98,

        /// <summary>
        /// Enum MRO for value: MRO
        /// </summary>
        [EnumMember(Value = "MRO")]
        MRO = 99,

        /// <summary>
        /// Enum MUR for value: MUR
        /// </summary>
        [EnumMember(Value = "MUR")]
        MUR = 100,

        /// <summary>
        /// Enum MVR for value: MVR
        /// </summary>
        [EnumMember(Value = "MVR")]
        MVR = 101,

        /// <summary>
        /// Enum MWK for value: MWK
        /// </summary>
        [EnumMember(Value = "MWK")]
        MWK = 102,

        /// <summary>
        /// Enum MXN for value: MXN
        /// </summary>
        [EnumMember(Value = "MXN")]
        MXN = 103,

        /// <summary>
        /// Enum MXV for value: MXV
        /// </summary>
        [EnumMember(Value = "MXV")]
        MXV = 104,

        /// <summary>
        /// Enum MYR for value: MYR
        /// </summary>
        [EnumMember(Value = "MYR")]
        MYR = 105,

        /// <summary>
        /// Enum MZN for value: MZN
        /// </summary>
        [EnumMember(Value = "MZN")]
        MZN = 106,

        /// <summary>
        /// Enum NAD for value: NAD
        /// </summary>
        [EnumMember(Value = "NAD")]
        NAD = 107,

        /// <summary>
        /// Enum NGN for value: NGN
        /// </summary>
        [EnumMember(Value = "NGN")]
        NGN = 108,

        /// <summary>
        /// Enum NIO for value: NIO
        /// </summary>
        [EnumMember(Value = "NIO")]
        NIO = 109,

        /// <summary>
        /// Enum NOK for value: NOK
        /// </summary>
        [EnumMember(Value = "NOK")]
        NOK = 110,

        /// <summary>
        /// Enum NPR for value: NPR
        /// </summary>
        [EnumMember(Value = "NPR")]
        NPR = 111,

        /// <summary>
        /// Enum NZD for value: NZD
        /// </summary>
        [EnumMember(Value = "NZD")]
        NZD = 112,

        /// <summary>
        /// Enum OMR for value: OMR
        /// </summary>
        [EnumMember(Value = "OMR")]
        OMR = 113,

        /// <summary>
        /// Enum PAB for value: PAB
        /// </summary>
        [EnumMember(Value = "PAB")]
        PAB = 114,

        /// <summary>
        /// Enum PEN for value: PEN
        /// </summary>
        [EnumMember(Value = "PEN")]
        PEN = 115,

        /// <summary>
        /// Enum PGK for value: PGK
        /// </summary>
        [EnumMember(Value = "PGK")]
        PGK = 116,

        /// <summary>
        /// Enum PHP for value: PHP
        /// </summary>
        [EnumMember(Value = "PHP")]
        PHP = 117,

        /// <summary>
        /// Enum PKR for value: PKR
        /// </summary>
        [EnumMember(Value = "PKR")]
        PKR = 118,

        /// <summary>
        /// Enum PLN for value: PLN
        /// </summary>
        [EnumMember(Value = "PLN")]
        PLN = 119,

        /// <summary>
        /// Enum PYG for value: PYG
        /// </summary>
        [EnumMember(Value = "PYG")]
        PYG = 120,

        /// <summary>
        /// Enum QAR for value: QAR
        /// </summary>
        [EnumMember(Value = "QAR")]
        QAR = 121,

        /// <summary>
        /// Enum RON for value: RON
        /// </summary>
        [EnumMember(Value = "RON")]
        RON = 122,

        /// <summary>
        /// Enum RSD for value: RSD
        /// </summary>
        [EnumMember(Value = "RSD")]
        RSD = 123,

        /// <summary>
        /// Enum RUB for value: RUB
        /// </summary>
        [EnumMember(Value = "RUB")]
        RUB = 124,

        /// <summary>
        /// Enum RWF for value: RWF
        /// </summary>
        [EnumMember(Value = "RWF")]
        RWF = 125,

        /// <summary>
        /// Enum SAR for value: SAR
        /// </summary>
        [EnumMember(Value = "SAR")]
        SAR = 126,

        /// <summary>
        /// Enum SBD for value: SBD
        /// </summary>
        [EnumMember(Value = "SBD")]
        SBD = 127,

        /// <summary>
        /// Enum SCR for value: SCR
        /// </summary>
        [EnumMember(Value = "SCR")]
        SCR = 128,

        /// <summary>
        /// Enum SDG for value: SDG
        /// </summary>
        [EnumMember(Value = "SDG")]
        SDG = 129,

        /// <summary>
        /// Enum SEK for value: SEK
        /// </summary>
        [EnumMember(Value = "SEK")]
        SEK = 130,

        /// <summary>
        /// Enum SGD for value: SGD
        /// </summary>
        [EnumMember(Value = "SGD")]
        SGD = 131,

        /// <summary>
        /// Enum SHP for value: SHP
        /// </summary>
        [EnumMember(Value = "SHP")]
        SHP = 132,

        /// <summary>
        /// Enum SLL for value: SLL
        /// </summary>
        [EnumMember(Value = "SLL")]
        SLL = 133,

        /// <summary>
        /// Enum SOS for value: SOS
        /// </summary>
        [EnumMember(Value = "SOS")]
        SOS = 134,

        /// <summary>
        /// Enum SRD for value: SRD
        /// </summary>
        [EnumMember(Value = "SRD")]
        SRD = 135,

        /// <summary>
        /// Enum SSP for value: SSP
        /// </summary>
        [EnumMember(Value = "SSP")]
        SSP = 136,

        /// <summary>
        /// Enum STD for value: STD
        /// </summary>
        [EnumMember(Value = "STD")]
        STD = 137,

        /// <summary>
        /// Enum SVC for value: SVC
        /// </summary>
        [EnumMember(Value = "SVC")]
        SVC = 138,

        /// <summary>
        /// Enum SYP for value: SYP
        /// </summary>
        [EnumMember(Value = "SYP")]
        SYP = 139,

        /// <summary>
        /// Enum SZL for value: SZL
        /// </summary>
        [EnumMember(Value = "SZL")]
        SZL = 140,

        /// <summary>
        /// Enum THB for value: THB
        /// </summary>
        [EnumMember(Value = "THB")]
        THB = 141,

        /// <summary>
        /// Enum TJS for value: TJS
        /// </summary>
        [EnumMember(Value = "TJS")]
        TJS = 142,

        /// <summary>
        /// Enum TMT for value: TMT
        /// </summary>
        [EnumMember(Value = "TMT")]
        TMT = 143,

        /// <summary>
        /// Enum TND for value: TND
        /// </summary>
        [EnumMember(Value = "TND")]
        TND = 144,

        /// <summary>
        /// Enum TOP for value: TOP
        /// </summary>
        [EnumMember(Value = "TOP")]
        TOP = 145,

        /// <summary>
        /// Enum TRC for value: TRC
        /// </summary>
        [EnumMember(Value = "TRC")]
        TRC = 146,

        /// <summary>
        /// Enum TRY for value: TRY
        /// </summary>
        [EnumMember(Value = "TRY")]
        TRY = 147,

        /// <summary>
        /// Enum TTD for value: TTD
        /// </summary>
        [EnumMember(Value = "TTD")]
        TTD = 148,

        /// <summary>
        /// Enum TWD for value: TWD
        /// </summary>
        [EnumMember(Value = "TWD")]
        TWD = 149,

        /// <summary>
        /// Enum TZS for value: TZS
        /// </summary>
        [EnumMember(Value = "TZS")]
        TZS = 150,

        /// <summary>
        /// Enum UAH for value: UAH
        /// </summary>
        [EnumMember(Value = "UAH")]
        UAH = 151,

        /// <summary>
        /// Enum UGX for value: UGX
        /// </summary>
        [EnumMember(Value = "UGX")]
        UGX = 152,

        /// <summary>
        /// Enum USD for value: USD
        /// </summary>
        [EnumMember(Value = "USD")]
        USD = 153,

        /// <summary>
        /// Enum USN for value: USN
        /// </summary>
        [EnumMember(Value = "USN")]
        USN = 154,

        /// <summary>
        /// Enum USS for value: USS
        /// </summary>
        [EnumMember(Value = "USS")]
        USS = 155,

        /// <summary>
        /// Enum UYI for value: UYI
        /// </summary>
        [EnumMember(Value = "UYI")]
        UYI = 156,

        /// <summary>
        /// Enum UYU for value: UYU
        /// </summary>
        [EnumMember(Value = "UYU")]
        UYU = 157,

        /// <summary>
        /// Enum UZS for value: UZS
        /// </summary>
        [EnumMember(Value = "UZS")]
        UZS = 158,

        /// <summary>
        /// Enum VEF for value: VEF
        /// </summary>
        [EnumMember(Value = "VEF")]
        VEF = 159,

        /// <summary>
        /// Enum VND for value: VND
        /// </summary>
        [EnumMember(Value = "VND")]
        VND = 160,

        /// <summary>
        /// Enum VUV for value: VUV
        /// </summary>
        [EnumMember(Value = "VUV")]
        VUV = 161,

        /// <summary>
        /// Enum WST for value: WST
        /// </summary>
        [EnumMember(Value = "WST")]
        WST = 162,

        /// <summary>
        /// Enum XAF for value: XAF
        /// </summary>
        [EnumMember(Value = "XAF")]
        XAF = 163,

        /// <summary>
        /// Enum XAG for value: XAG
        /// </summary>
        [EnumMember(Value = "XAG")]
        XAG = 164,

        /// <summary>
        /// Enum XAU for value: XAU
        /// </summary>
        [EnumMember(Value = "XAU")]
        XAU = 165,

        /// <summary>
        /// Enum XBA for value: XBA
        /// </summary>
        [EnumMember(Value = "XBA")]
        XBA = 166,

        /// <summary>
        /// Enum XBB for value: XBB
        /// </summary>
        [EnumMember(Value = "XBB")]
        XBB = 167,

        /// <summary>
        /// Enum XBC for value: XBC
        /// </summary>
        [EnumMember(Value = "XBC")]
        XBC = 168,

        /// <summary>
        /// Enum XBD for value: XBD
        /// </summary>
        [EnumMember(Value = "XBD")]
        XBD = 169,

        /// <summary>
        /// Enum XCD for value: XCD
        /// </summary>
        [EnumMember(Value = "XCD")]
        XCD = 170,

        /// <summary>
        /// Enum XDR for value: XDR
        /// </summary>
        [EnumMember(Value = "XDR")]
        XDR = 171,

        /// <summary>
        /// Enum XOF for value: XOF
        /// </summary>
        [EnumMember(Value = "XOF")]
        XOF = 172,

        /// <summary>
        /// Enum XPD for value: XPD
        /// </summary>
        [EnumMember(Value = "XPD")]
        XPD = 173,

        /// <summary>
        /// Enum XPF for value: XPF
        /// </summary>
        [EnumMember(Value = "XPF")]
        XPF = 174,

        /// <summary>
        /// Enum XPT for value: XPT
        /// </summary>
        [EnumMember(Value = "XPT")]
        XPT = 175,

        /// <summary>
        /// Enum XTS for value: XTS
        /// </summary>
        [EnumMember(Value = "XTS")]
        XTS = 176,

        /// <summary>
        /// Enum XXX for value: XXX
        /// </summary>
        [EnumMember(Value = "XXX")]
        XXX = 177,

        /// <summary>
        /// Enum YER for value: YER
        /// </summary>
        [EnumMember(Value = "YER")]
        YER = 178,

        /// <summary>
        /// Enum ZAR for value: ZAR
        /// </summary>
        [EnumMember(Value = "ZAR")]
        ZAR = 179,

        /// <summary>
        /// Enum ZMK for value: ZMK
        /// </summary>
        [EnumMember(Value = "ZMK")]
        ZMK = 180,

        /// <summary>
        /// Enum ZMW for value: ZMW
        /// </summary>
        [EnumMember(Value = "ZMW")]
        ZMW = 181,

        /// <summary>
        /// Enum BTC for value: BTC
        /// </summary>
        [EnumMember(Value = "BTC")]
        BTC = 182

    }

}