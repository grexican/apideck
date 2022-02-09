/*
 * File storage API
 *
 * Welcome to the file-storage.  You can use this API to access all file-storage endpoints.  ## Base URL  The base URL for all API requests is `https://unify.apideck.com`  ## GraphQL  Use the [GraphQL playground](https://developers.apideck.com/graphql/playground) to test out the GraphQL API.  ## Headers  Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.  | Name                  | Type    | Required | Description                                                                                                                                                    | | - -- -- -- -- -- -- -- -- -- -- | - -- -- -- | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | x-apideck-consumer-id | String  | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app. | | x-apideck-service-id  | String  | No       | Describe the service you want to call (e.g., pipedrive). Only needed when a customer has activated multiple integrations for the same Unified API.             | | x-apideck-raw         | Boolean | No       | Include raw response. Mostly used for debugging purposes.                                                                                                      | | x-apideck-app-id      | String  | Yes      | The application id of your Unify application. Available at https://app.apideck.com/unify/api-keys.                                                             | | Authorization         | String  | Yes      | Bearer API KEY                                                                                                                                                 |  ## Authorization  You can interact with the API through the authorization methods below.  <!- - ReDoc-Inject: <security-definitions> - ->  ## Pagination  All API resources have support for bulk retrieval via list APIs.  Apideck uses cursor-based pagination via the optional `cursor` and `limit` parameters.  To fetch the first page of results, call the list API without a `cursor` parameter. Afterwards you can fetch subsequent pages by providing a cursor parameter. You will find the next cursor in the response body in `meta.cursors.next`. If `meta.cursors.next` is `null` you're at the end of the list.  In the REST API you can also use the `links` from the response for added convenience. Simply call the URL in `links.next` to get the next page of results.  ### Query Parameters  | Name   | Type   | Required | Description                                                                                                        | | - -- -- - | - -- -- - | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | cursor | String | No       | Cursor to start from. You can find cursors for next & previous pages in the meta.cursors property of the response. | | limit  | Number | No       | Number of results to return. Minimum 1, Maximum 200, Default 20                                                    |  ### Response Body  | Name                  | Type   | Description                                                        | | - -- -- -- -- -- -- -- -- -- -- | - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | meta.cursors.previous | String | Cursor to navigate to the previous page of results through the API | | meta.cursors.current  | String | Cursor to navigate to the current page of results through the API  | | meta.cursors.next     | String | Cursor to navigate to the next page of results through the API     | | meta.items_on_page    | Number | Number of items returned in the data property of the response      | | links.previous        | String | Link to navigate to the previous page of results through the API   | | links.current         | String | Link to navigate to the current page of results through the API    | | links.next            | String | Link to navigate to the next page of results through the API       |  ⚠️ `meta.cursors.previous`/`links.previous` is not available for all connectors.  ## SDKs and API Clients  Upcoming. [Request the SDK of your choice](https://integrations.apideck.com/request).  ## Debugging  Because of the nature of the abstraction we do in Apideck Unify we still provide the option to the receive raw requests and responses being handled underlying. By including the raw flag `?raw=true` in your requests you can still receive the full request. Please note that this increases the response size and can introduce extra latency.  ## Errors  The API returns standard HTTP response codes to indicate success or failure of the API requests. For errors, we also return a customized error message inside the JSON response. You can see the returned HTTP status codes below.  | Code | Title                | Description                                                                                                                                                                                              | | - -- - | - -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | 200  | OK                   | The request message has been successfully processed, and it has produced a response. The response message varies, depending on the request method and the requested data.                                | | 201  | Created              | The request has been fulfilled and has resulted in one or more new resources being created.                                                                                                              | | 204  | No Content           | The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.                                                                          | | 400  | Bad Request          | The receiving server cannot understand the request because of malformed syntax. Do not repeat the request without first modifying it; check the request for errors, fix them and then retry the request. | | 401  | Unauthorized         | The request has not been applied because it lacks valid authentication credentials for the target resource.                                                                                              | | 402  | Payment Required     | Subscription data is incomplete or out of date. You'll need to provide payment details to continue.                                                                                                      | | 403  | Forbidden            | You do not have the appropriate user rights to access the request. Do not repeat the request.                                                                                                            | | 404  | Not Found            | The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.                                                                           | | 409  | Conflict             | The request could not be completed due to a conflict with the current state of the target resource.                                                                                                      | | 422  | Unprocessable Entity | The server understands the content type of the request entity, and the syntax of the request entity is correct but was unable to process the contained instructions.                                     | | 5xx  | Server Errors        | Something went wrong with the Unify API. These errors are logged on our side. You can contact our team to resolve the issue.                                                                             |  ### Handling errors  The Unify API and SDKs can produce errors for many reasons, such as a failed requests due to misconfigured integrations, invalid parameters, authentication errors, and network unavailability.  ### Error Types  #### RequestValidationError  Request is not valid for the current endpoint. The response body will include details on the validation error. Check the spelling and types of your attributes, and ensure you are not passing data that is outside of the specification.  #### UnsupportedFiltersError  Filters in the request are valid, but not supported by the connector. Remove the unsupported filter(s) to get a successful response.  #### UnsupportedSortFieldError  Sort field (`sort[by]`) in the request is valid, but not supported by the connector. Replace or remove the sort field to get a successful response.  #### InvalidCursorError  Pagination cursor in the request is not valid for the current connector. Make sure to use a cursor returned from the API, for the same connector.  #### ConnectorExecutionError  A Unified API request made via one of our downstream connectors returned an unexpected error. The `status_code` returned is proxied through to error response along with their original response via the error detail.  #### ConnectorProcessingError  A Unified API request made via one of our downstream connectors returned a status code that was less than 400, along with a description of why the request could not be processed. Often this is due to the shape of request data being valid, but unable to be processed due to internal business logic - for example: an invalid relationship or `ID` present in your request.  #### UnauthorizedError  We were unable to authorize the request as made. This can happen for a number of reasons, from missing header params to passing an incorrect authorization token. Verify your Api Key is being set correctly in the authorization header. ie: `Authorization: 'Bearer sk_live_***'`  #### ConnectorCredentialsError  A request using a given connector has not been authorized. Ensure the connector you are trying to use has been configured correctly and been authorized for use.  #### ConnectorDisabledError  A request has been made to a connector that has since been disabled. This may be temporary - You can contact our team to resolve the issue.  #### RequestLimitError  You have reached the number of requests included in your Free Tier Subscription. You will no be able to make further requests until this limit resets at the end of the month, or talk to us about upgrading your subscription to continue immediately.  #### EntityNotFoundError  You've made a request for a resource or route that does not exist. Verify your path parameters or any identifiers used to fetch this resource.  #### OAuthCredentialsNotFoundError  When adding a connector integration that implements OAuth, both a `client_id` and `client_secret` must be provided before any authorizations can be performed. Verify the integration has been configured properly before continuing.  #### IntegrationNotFoundError  The requested connector integration could not be found associated to your `application_id`. Verify your `application_id` is correct, and that this connector has been added and configured for your application.  #### ConnectionNotFoundError  A valid connection could not be found associated to your `application_id`. Something _may_ have interrupted the authorization flow. You may need to start the connector authorization process again.  #### ConnectorNotFoundError  A request was made for an unknown connector. Verify your `service_id` is spelled correctly, and that this connector is enabled for your provided `unified_api`.  #### OAuthRedirectUriError  A request was made either in a connector authorization flow, or attempting to revoke connector access without a valid `redirect_uri`. This is the url the user should be returned to on completion of process.  #### OAuthInvalidStateError  The state param is required and is used to ensure the outgoing authorization state has not been altered before the user is redirected back. It also contains required params needed to identify the connector being used. If this has been altered, the authorization will not succeed.  #### OAuthCodeExchangeError  When attempting to exchange the authorization code for an `access_token` during an OAuth flow, an error occurred. This may be temporary. You can reattempt authorization or contact our team to resolve the issue.  #### MappingError  There was an error attempting to retrieve the mapping for a given attribute. We've been notified and are working to fix this issue.  #### ConnectorMappingNotFoundError  It seems the implementation for this connector is incomplete. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorResponseMappingNotFoundError  We were unable to retrieve the response mapping for this connector. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorOperationMappingNotFoundError  Connector mapping has not been implemented for the requested operation. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### ConnectorWorkflowMappingError  The composite api calls required for this operation have not been mapped entirely. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  #### PaginationNotSupportedError  Pagination is not yet supported for this connector, try removing limit and/or cursor from the query. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.  ## API Design  ### API Styles and data formats  #### REST API  The API is organized around [REST](https://restfulapi.net/), providing simple and predictable URIs to access and modify objects. Requests support standard HTTP methods like GET, PUT, POST, and DELETE and standard status codes. JSON is returned by all API responses, including errors. In all API requests, you must set the content-type HTTP header to application/json. All API requests must be made over HTTPS. Calls made over HTTP will fail.  ##### Available HTTP methods  The Apideck API uses HTTP verbs to understand if you want to read (GET), delete (DELETE) or create (POST) an object. When your web application cannot do a POST or DELETE, we provide the ability to set the method through the query parameter \\_method.  ``` POST /messages GET /messages GET /messages/{messageId} PATCH /messages/{messageId} DELETE /messages/{messageId} ```  Response bodies are always UTF-8 encoded JSON objects, unless explicitly documented otherwise. For some endpoints and use cases we divert from REST to provide a better developer experience.  ### Schema  All API requests and response bodies adhere to a common JSON format representing individual items, collections of items, links to related items and additional meta data.  ### Meta  Meta data can be represented as a top level member named “meta”. Any information may be provided in the meta data. It’s most common use is to return the total number of records when requesting a collection of resources.  ### Idempotence (upcoming)  To prevent the creation of duplicate resources, every POST method (such as one that creates a consumer record) must specify a unique value for the X-Unique-Transaction-ID header name. Uniquely identifying each unique POST request ensures that the API processes a given request once and only once.  Uniquely identifying new resource-creation POSTs is especially important when the outcome of a response is ambiguous because of a transient service interruption, such as a server-side timeout or network disruption. If a service interruption occurs, then the client application can safely retry the uniquely identified request without creating duplicate operations. (API endpoints that guarantee that every uniquely identified request is processed only once no matter how many times that uniquely identifiable request is made are described as idempotent.)  ### Request IDs  Each API request has an associated request identifier. You can find this value in the response headers, under Request-Id. You can also find request identifiers in the URLs of individual request logs in your Dashboard. If you need to contact us about a specific request, providing the request identifier will ensure the fastest possible resolution.  ### Fixed field types  #### Dates  The dates returned by the API are all represented in UTC (ISO8601 format).  This example `2019-11-14T00:55:31.820Z` is defined by the ISO 8601 standard. The T in the middle separates the year-month-day portion from the hour-minute-second portion. The Z on the end means UTC, that is, an offset-from-UTC of zero hours-minutes-seconds. The Z is pronounced \"Zulu\" per military/aviation tradition.  The ISO 8601 standard is more modern. The formats are wisely designed to be easy to parse by machine as well as easy to read by humans across cultures.  #### Prices and Currencies  All prices returned by the API are represented as integer amounts in a currency’s smallest unit. For example, $5 USD would be returned as 500 (i.e, 500 cents).  For zero-decimal currencies, amounts will still be provided as an integer but without the need to divide by 100. For example, an amount of ¥5 (JPY) would be returned as 5.  All currency codes conform to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).  ## Support  If you have problems or need help with your case, you can always reach out to our Support. 
 *
 * The version of the OpenAPI document: 8.11.0
 * Contact: hello@apideck.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Apideck.FileStorage.Client;
using Apideck.FileStorage.Model;

namespace Apideck.FileStorage.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFoldersApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create Folder
        /// </summary>
        /// <remarks>
        /// Create Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <returns>CreateFolderResponse</returns>
        CreateFolderResponse FoldersAdd(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string));

        /// <summary>
        /// Create Folder
        /// </summary>
        /// <remarks>
        /// Create Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <returns>ApiResponse of CreateFolderResponse</returns>
        ApiResponse<CreateFolderResponse> FoldersAddWithHttpInfo(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string));
        /// <summary>
        /// Copy Folder
        /// </summary>
        /// <remarks>
        /// Copy Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>UpdateFolderResponse</returns>
        UpdateFolderResponse FoldersCopy(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?));

        /// <summary>
        /// Copy Folder
        /// </summary>
        /// <remarks>
        /// Copy Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of UpdateFolderResponse</returns>
        ApiResponse<UpdateFolderResponse> FoldersCopyWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?));
        /// <summary>
        /// Delete Folder
        /// </summary>
        /// <remarks>
        /// Delete Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>DeleteFolderResponse</returns>
        DeleteFolderResponse FoldersDelete(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?));

        /// <summary>
        /// Delete Folder
        /// </summary>
        /// <remarks>
        /// Delete Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of DeleteFolderResponse</returns>
        ApiResponse<DeleteFolderResponse> FoldersDeleteWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?));
        /// <summary>
        /// Get Folder
        /// </summary>
        /// <remarks>
        /// Get Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>GetFolderResponse</returns>
        GetFolderResponse FoldersOne(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?));

        /// <summary>
        /// Get Folder
        /// </summary>
        /// <remarks>
        /// Get Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of GetFolderResponse</returns>
        ApiResponse<GetFolderResponse> FoldersOneWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?));
        /// <summary>
        /// Rename or move Folder
        /// </summary>
        /// <remarks>
        /// Rename or move Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>UpdateFolderResponse</returns>
        UpdateFolderResponse FoldersUpdate(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?));

        /// <summary>
        /// Rename or move Folder
        /// </summary>
        /// <remarks>
        /// Rename or move Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of UpdateFolderResponse</returns>
        ApiResponse<UpdateFolderResponse> FoldersUpdateWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFoldersApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create Folder
        /// </summary>
        /// <remarks>
        /// Create Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CreateFolderResponse</returns>
        System.Threading.Tasks.Task<CreateFolderResponse> FoldersAddAsync(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create Folder
        /// </summary>
        /// <remarks>
        /// Create Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CreateFolderResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CreateFolderResponse>> FoldersAddWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Copy Folder
        /// </summary>
        /// <remarks>
        /// Copy Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateFolderResponse</returns>
        System.Threading.Tasks.Task<UpdateFolderResponse> FoldersCopyAsync(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Copy Folder
        /// </summary>
        /// <remarks>
        /// Copy Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateFolderResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UpdateFolderResponse>> FoldersCopyWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete Folder
        /// </summary>
        /// <remarks>
        /// Delete Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeleteFolderResponse</returns>
        System.Threading.Tasks.Task<DeleteFolderResponse> FoldersDeleteAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Folder
        /// </summary>
        /// <remarks>
        /// Delete Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeleteFolderResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeleteFolderResponse>> FoldersDeleteWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Folder
        /// </summary>
        /// <remarks>
        /// Get Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetFolderResponse</returns>
        System.Threading.Tasks.Task<GetFolderResponse> FoldersOneAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Folder
        /// </summary>
        /// <remarks>
        /// Get Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetFolderResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetFolderResponse>> FoldersOneWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Rename or move Folder
        /// </summary>
        /// <remarks>
        /// Rename or move Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateFolderResponse</returns>
        System.Threading.Tasks.Task<UpdateFolderResponse> FoldersUpdateAsync(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Rename or move Folder
        /// </summary>
        /// <remarks>
        /// Rename or move Folder
        /// </remarks>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateFolderResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UpdateFolderResponse>> FoldersUpdateWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFoldersApi : IFoldersApiSync, IFoldersApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class FoldersApi : IFoldersApi
    {
        private Apideck.FileStorage.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FoldersApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FoldersApi(string basePath)
        {
            this.Configuration = Apideck.FileStorage.Client.Configuration.MergeConfigurations(
                Apideck.FileStorage.Client.GlobalConfiguration.Instance,
                new Apideck.FileStorage.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Apideck.FileStorage.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Apideck.FileStorage.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Apideck.FileStorage.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldersApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public FoldersApi(Apideck.FileStorage.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Apideck.FileStorage.Client.Configuration.MergeConfigurations(
                Apideck.FileStorage.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Apideck.FileStorage.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Apideck.FileStorage.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Apideck.FileStorage.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldersApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public FoldersApi(Apideck.FileStorage.Client.ISynchronousClient client, Apideck.FileStorage.Client.IAsynchronousClient asyncClient, Apideck.FileStorage.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Apideck.FileStorage.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Apideck.FileStorage.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Apideck.FileStorage.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Apideck.FileStorage.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Apideck.FileStorage.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Create Folder Create Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <returns>CreateFolderResponse</returns>
        public CreateFolderResponse FoldersAdd(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string))
        {
            Apideck.FileStorage.Client.ApiResponse<CreateFolderResponse> localVarResponse = FoldersAddWithHttpInfo(xApideckConsumerId, xApideckAppId, createFolderRequest, raw, xApideckServiceId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create Folder Create Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <returns>ApiResponse of CreateFolderResponse</returns>
        public Apideck.FileStorage.Client.ApiResponse<CreateFolderResponse> FoldersAddWithHttpInfo(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersAdd");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersAdd");
            }

            // verify the required parameter 'createFolderRequest' is set
            if (createFolderRequest == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'createFolderRequest' when calling FoldersApi->FoldersAdd");
            }

            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }
            localVarRequestOptions.Data = createFolderRequest;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<CreateFolderResponse>("/file-storage/folders", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersAdd", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create Folder Create Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CreateFolderResponse</returns>
        public async System.Threading.Tasks.Task<CreateFolderResponse> FoldersAddAsync(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.FileStorage.Client.ApiResponse<CreateFolderResponse> localVarResponse = await FoldersAddWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, createFolderRequest, raw, xApideckServiceId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create Folder Create Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="createFolderRequest"></param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CreateFolderResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.FileStorage.Client.ApiResponse<CreateFolderResponse>> FoldersAddWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, CreateFolderRequest createFolderRequest, bool? raw = default(bool?), string xApideckServiceId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersAdd");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersAdd");
            }

            // verify the required parameter 'createFolderRequest' is set
            if (createFolderRequest == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'createFolderRequest' when calling FoldersApi->FoldersAdd");
            }


            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }
            localVarRequestOptions.Data = createFolderRequest;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<CreateFolderResponse>("/file-storage/folders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersAdd", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Copy Folder Copy Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>UpdateFolderResponse</returns>
        public UpdateFolderResponse FoldersCopy(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse> localVarResponse = FoldersCopyWithHttpInfo(id, xApideckConsumerId, xApideckAppId, copyFolderRequest, xApideckServiceId, raw);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Copy Folder Copy Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of UpdateFolderResponse</returns>
        public Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse> FoldersCopyWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersCopy");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersCopy");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersCopy");
            }

            // verify the required parameter 'copyFolderRequest' is set
            if (copyFolderRequest == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'copyFolderRequest' when calling FoldersApi->FoldersCopy");
            }

            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }
            localVarRequestOptions.Data = copyFolderRequest;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<UpdateFolderResponse>("/file-storage/folders/{id}/copy", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersCopy", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Copy Folder Copy Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateFolderResponse</returns>
        public async System.Threading.Tasks.Task<UpdateFolderResponse> FoldersCopyAsync(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse> localVarResponse = await FoldersCopyWithHttpInfoAsync(id, xApideckConsumerId, xApideckAppId, copyFolderRequest, xApideckServiceId, raw, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Copy Folder Copy Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="copyFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateFolderResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse>> FoldersCopyWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, CopyFolderRequest copyFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersCopy");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersCopy");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersCopy");
            }

            // verify the required parameter 'copyFolderRequest' is set
            if (copyFolderRequest == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'copyFolderRequest' when calling FoldersApi->FoldersCopy");
            }


            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }
            localVarRequestOptions.Data = copyFolderRequest;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<UpdateFolderResponse>("/file-storage/folders/{id}/copy", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersCopy", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Folder Delete Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>DeleteFolderResponse</returns>
        public DeleteFolderResponse FoldersDelete(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            Apideck.FileStorage.Client.ApiResponse<DeleteFolderResponse> localVarResponse = FoldersDeleteWithHttpInfo(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete Folder Delete Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of DeleteFolderResponse</returns>
        public Apideck.FileStorage.Client.ApiResponse<DeleteFolderResponse> FoldersDeleteWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersDelete");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersDelete");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersDelete");
            }

            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeleteFolderResponse>("/file-storage/folders/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Folder Delete Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeleteFolderResponse</returns>
        public async System.Threading.Tasks.Task<DeleteFolderResponse> FoldersDeleteAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.FileStorage.Client.ApiResponse<DeleteFolderResponse> localVarResponse = await FoldersDeleteWithHttpInfoAsync(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete Folder Delete Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeleteFolderResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.FileStorage.Client.ApiResponse<DeleteFolderResponse>> FoldersDeleteWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersDelete");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersDelete");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersDelete");
            }


            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeleteFolderResponse>("/file-storage/folders/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Folder Get Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>GetFolderResponse</returns>
        public GetFolderResponse FoldersOne(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            Apideck.FileStorage.Client.ApiResponse<GetFolderResponse> localVarResponse = FoldersOneWithHttpInfo(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Folder Get Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of GetFolderResponse</returns>
        public Apideck.FileStorage.Client.ApiResponse<GetFolderResponse> FoldersOneWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersOne");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersOne");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersOne");
            }

            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<GetFolderResponse>("/file-storage/folders/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersOne", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Folder Get Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetFolderResponse</returns>
        public async System.Threading.Tasks.Task<GetFolderResponse> FoldersOneAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.FileStorage.Client.ApiResponse<GetFolderResponse> localVarResponse = await FoldersOneWithHttpInfoAsync(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Folder Get Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetFolderResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.FileStorage.Client.ApiResponse<GetFolderResponse>> FoldersOneWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersOne");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersOne");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersOne");
            }


            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetFolderResponse>("/file-storage/folders/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersOne", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Rename or move Folder Rename or move Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>UpdateFolderResponse</returns>
        public UpdateFolderResponse FoldersUpdate(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse> localVarResponse = FoldersUpdateWithHttpInfo(id, xApideckConsumerId, xApideckAppId, updateFolderRequest, xApideckServiceId, raw);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Rename or move Folder Rename or move Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <returns>ApiResponse of UpdateFolderResponse</returns>
        public Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse> FoldersUpdateWithHttpInfo(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersUpdate");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersUpdate");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersUpdate");
            }

            // verify the required parameter 'updateFolderRequest' is set
            if (updateFolderRequest == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'updateFolderRequest' when calling FoldersApi->FoldersUpdate");
            }

            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }
            localVarRequestOptions.Data = updateFolderRequest;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Patch<UpdateFolderResponse>("/file-storage/folders/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersUpdate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Rename or move Folder Rename or move Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateFolderResponse</returns>
        public async System.Threading.Tasks.Task<UpdateFolderResponse> FoldersUpdateAsync(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse> localVarResponse = await FoldersUpdateWithHttpInfoAsync(id, xApideckConsumerId, xApideckAppId, updateFolderRequest, xApideckServiceId, raw, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Rename or move Folder Rename or move Folder
        /// </summary>
        /// <exception cref="Apideck.FileStorage.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the record you are acting upon.</param>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="updateFolderRequest"></param>
        /// <param name="xApideckServiceId">Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional)</param>
        /// <param name="raw">Include raw response. Mostly used for debugging purposes (optional, default to true)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateFolderResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.FileStorage.Client.ApiResponse<UpdateFolderResponse>> FoldersUpdateWithHttpInfoAsync(string id, string xApideckConsumerId, string xApideckAppId, UpdateFolderRequest updateFolderRequest, string xApideckServiceId = default(string), bool? raw = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'id' when calling FoldersApi->FoldersUpdate");
            }

            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling FoldersApi->FoldersUpdate");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling FoldersApi->FoldersUpdate");
            }

            // verify the required parameter 'updateFolderRequest' is set
            if (updateFolderRequest == null)
            {
                throw new Apideck.FileStorage.Client.ApiException(400, "Missing required parameter 'updateFolderRequest' when calling FoldersApi->FoldersUpdate");
            }


            Apideck.FileStorage.Client.RequestOptions localVarRequestOptions = new Apideck.FileStorage.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.FileStorage.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.FileStorage.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (raw != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.FileStorage.Client.ClientUtils.ParameterToMultiMap("", "raw", raw));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            if (xApideckServiceId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-apideck-service-id", Apideck.FileStorage.Client.ClientUtils.ParameterToString(xApideckServiceId)); // header parameter
            }
            localVarRequestOptions.Data = updateFolderRequest;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PatchAsync<UpdateFolderResponse>("/file-storage/folders/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FoldersUpdate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
