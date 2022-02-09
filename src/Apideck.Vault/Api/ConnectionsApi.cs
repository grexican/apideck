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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Apideck.Vault.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IConnectionsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create connection
        /// </summary>
        /// <remarks>
        /// Create an authorized connection 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <returns>CreateConnectionResponse</returns>
        CreateConnectionResponse ConnectionsAdd(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection);

        /// <summary>
        /// Create connection
        /// </summary>
        /// <remarks>
        /// Create an authorized connection 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <returns>ApiResponse of CreateConnectionResponse</returns>
        ApiResponse<CreateConnectionResponse> ConnectionsAddWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection);
        /// <summary>
        /// Get all connections
        /// </summary>
        /// <remarks>
        /// This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <returns>GetConnectionsResponse</returns>
        GetConnectionsResponse ConnectionsAll(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?));

        /// <summary>
        /// Get all connections
        /// </summary>
        /// <remarks>
        /// This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <returns>ApiResponse of GetConnectionsResponse</returns>
        ApiResponse<GetConnectionsResponse> ConnectionsAllWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?));
        /// <summary>
        /// Authorize
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <returns>UnexpectedErrorResponse</returns>
        UnexpectedErrorResponse ConnectionsAuthorize(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>));

        /// <summary>
        /// Authorize
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <returns>ApiResponse of UnexpectedErrorResponse</returns>
        ApiResponse<UnexpectedErrorResponse> ConnectionsAuthorizeWithHttpInfo(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>));
        /// <summary>
        /// Callback
        /// </summary>
        /// <remarks>
        /// This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <returns>UnexpectedErrorResponse</returns>
        UnexpectedErrorResponse ConnectionsCallback(string state, string code);

        /// <summary>
        /// Callback
        /// </summary>
        /// <remarks>
        /// This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <returns>ApiResponse of UnexpectedErrorResponse</returns>
        ApiResponse<UnexpectedErrorResponse> ConnectionsCallbackWithHttpInfo(string state, string code);
        /// <summary>
        /// Deletes a connection
        /// </summary>
        /// <remarks>
        /// Deletes a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns></returns>
        void ConnectionsDelete(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi);

        /// <summary>
        /// Deletes a connection
        /// </summary>
        /// <remarks>
        /// Deletes a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ConnectionsDeleteWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi);
        /// <summary>
        /// Get resource settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <returns>GetConnectionResponse</returns>
        GetConnectionResponse ConnectionsGetSettings(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource);

        /// <summary>
        /// Get resource settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <returns>ApiResponse of GetConnectionResponse</returns>
        ApiResponse<GetConnectionResponse> ConnectionsGetSettingsWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource);
        /// <summary>
        /// Get connection
        /// </summary>
        /// <remarks>
        /// Get a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns>GetConnectionResponse</returns>
        GetConnectionResponse ConnectionsOne(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi);

        /// <summary>
        /// Get connection
        /// </summary>
        /// <remarks>
        /// Get a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns>ApiResponse of GetConnectionResponse</returns>
        ApiResponse<GetConnectionResponse> ConnectionsOneWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi);
        /// <summary>
        /// Revoke
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <returns>UnexpectedErrorResponse</returns>
        UnexpectedErrorResponse ConnectionsRevoke(string serviceId, string applicationId, string state, string redirectUri);

        /// <summary>
        /// Revoke
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <returns>ApiResponse of UnexpectedErrorResponse</returns>
        ApiResponse<UnexpectedErrorResponse> ConnectionsRevokeWithHttpInfo(string serviceId, string applicationId, string state, string redirectUri);
        /// <summary>
        /// Update connection
        /// </summary>
        /// <remarks>
        /// Update a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>UpdateConnectionResponse</returns>
        UpdateConnectionResponse ConnectionsUpdate(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection);

        /// <summary>
        /// Update connection
        /// </summary>
        /// <remarks>
        /// Update a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>ApiResponse of UpdateConnectionResponse</returns>
        ApiResponse<UpdateConnectionResponse> ConnectionsUpdateWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection);
        /// <summary>
        /// Update settings
        /// </summary>
        /// <remarks>
        /// Update default values for a connection&#39;s resource settings
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>UpdateConnectionResponse</returns>
        UpdateConnectionResponse ConnectionsUpdateSettings(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection);

        /// <summary>
        /// Update settings
        /// </summary>
        /// <remarks>
        /// Update default values for a connection&#39;s resource settings
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>ApiResponse of UpdateConnectionResponse</returns>
        ApiResponse<UpdateConnectionResponse> ConnectionsUpdateSettingsWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IConnectionsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create connection
        /// </summary>
        /// <remarks>
        /// Create an authorized connection 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CreateConnectionResponse</returns>
        System.Threading.Tasks.Task<CreateConnectionResponse> ConnectionsAddAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create connection
        /// </summary>
        /// <remarks>
        /// Create an authorized connection 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CreateConnectionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CreateConnectionResponse>> ConnectionsAddWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get all connections
        /// </summary>
        /// <remarks>
        /// This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConnectionsResponse</returns>
        System.Threading.Tasks.Task<GetConnectionsResponse> ConnectionsAllAsync(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all connections
        /// </summary>
        /// <remarks>
        /// This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConnectionsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetConnectionsResponse>> ConnectionsAllWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Authorize
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UnexpectedErrorResponse</returns>
        System.Threading.Tasks.Task<UnexpectedErrorResponse> ConnectionsAuthorizeAsync(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Authorize
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UnexpectedErrorResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UnexpectedErrorResponse>> ConnectionsAuthorizeWithHttpInfoAsync(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Callback
        /// </summary>
        /// <remarks>
        /// This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UnexpectedErrorResponse</returns>
        System.Threading.Tasks.Task<UnexpectedErrorResponse> ConnectionsCallbackAsync(string state, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Callback
        /// </summary>
        /// <remarks>
        /// This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UnexpectedErrorResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UnexpectedErrorResponse>> ConnectionsCallbackWithHttpInfoAsync(string state, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Deletes a connection
        /// </summary>
        /// <remarks>
        /// Deletes a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ConnectionsDeleteAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Deletes a connection
        /// </summary>
        /// <remarks>
        /// Deletes a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ConnectionsDeleteWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get resource settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConnectionResponse</returns>
        System.Threading.Tasks.Task<GetConnectionResponse> ConnectionsGetSettingsAsync(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get resource settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConnectionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetConnectionResponse>> ConnectionsGetSettingsWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get connection
        /// </summary>
        /// <remarks>
        /// Get a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConnectionResponse</returns>
        System.Threading.Tasks.Task<GetConnectionResponse> ConnectionsOneAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get connection
        /// </summary>
        /// <remarks>
        /// Get a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConnectionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetConnectionResponse>> ConnectionsOneWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Revoke
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UnexpectedErrorResponse</returns>
        System.Threading.Tasks.Task<UnexpectedErrorResponse> ConnectionsRevokeAsync(string serviceId, string applicationId, string state, string redirectUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Revoke
        /// </summary>
        /// <remarks>
        /// __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UnexpectedErrorResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UnexpectedErrorResponse>> ConnectionsRevokeWithHttpInfoAsync(string serviceId, string applicationId, string state, string redirectUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update connection
        /// </summary>
        /// <remarks>
        /// Update a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateConnectionResponse</returns>
        System.Threading.Tasks.Task<UpdateConnectionResponse> ConnectionsUpdateAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update connection
        /// </summary>
        /// <remarks>
        /// Update a connection
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateConnectionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UpdateConnectionResponse>> ConnectionsUpdateWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update settings
        /// </summary>
        /// <remarks>
        /// Update default values for a connection&#39;s resource settings
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateConnectionResponse</returns>
        System.Threading.Tasks.Task<UpdateConnectionResponse> ConnectionsUpdateSettingsAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update settings
        /// </summary>
        /// <remarks>
        /// Update default values for a connection&#39;s resource settings
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateConnectionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UpdateConnectionResponse>> ConnectionsUpdateSettingsWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IConnectionsApi : IConnectionsApiSync, IConnectionsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ConnectionsApi : IConnectionsApi
    {
        private Apideck.Vault.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConnectionsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConnectionsApi(string basePath)
        {
            this.Configuration = Apideck.Vault.Client.Configuration.MergeConfigurations(
                Apideck.Vault.Client.GlobalConfiguration.Instance,
                new Apideck.Vault.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Apideck.Vault.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Apideck.Vault.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Apideck.Vault.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ConnectionsApi(Apideck.Vault.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Apideck.Vault.Client.Configuration.MergeConfigurations(
                Apideck.Vault.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Apideck.Vault.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Apideck.Vault.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Apideck.Vault.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ConnectionsApi(Apideck.Vault.Client.ISynchronousClient client, Apideck.Vault.Client.IAsynchronousClient asyncClient, Apideck.Vault.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Apideck.Vault.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Apideck.Vault.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Apideck.Vault.Client.ISynchronousClient Client { get; set; }

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
        public Apideck.Vault.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Apideck.Vault.Client.ExceptionFactory ExceptionFactory
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
        /// Create connection Create an authorized connection 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <returns>CreateConnectionResponse</returns>
        public CreateConnectionResponse ConnectionsAdd(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection)
        {
            Apideck.Vault.Client.ApiResponse<CreateConnectionResponse> localVarResponse = ConnectionsAddWithHttpInfo(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, connection);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create connection Create an authorized connection 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <returns>ApiResponse of CreateConnectionResponse</returns>
        public Apideck.Vault.Client.ApiResponse<CreateConnectionResponse> ConnectionsAddWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection)
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'connection' is set
            if (connection == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'connection' when calling ConnectionsApi->ConnectionsAdd");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            localVarRequestOptions.Data = connection;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<CreateConnectionResponse>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsAdd", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create connection Create an authorized connection 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CreateConnectionResponse</returns>
        public async System.Threading.Tasks.Task<CreateConnectionResponse> ConnectionsAddAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<CreateConnectionResponse> localVarResponse = await ConnectionsAddWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, connection, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create connection Create an authorized connection 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be persisted on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CreateConnectionResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<CreateConnectionResponse>> ConnectionsAddWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsAdd");
            }

            // verify the required parameter 'connection' is set
            if (connection == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'connection' when calling ConnectionsApi->ConnectionsAdd");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            localVarRequestOptions.Data = connection;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<CreateConnectionResponse>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsAdd", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all connections This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <returns>GetConnectionsResponse</returns>
        public GetConnectionsResponse ConnectionsAll(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?))
        {
            Apideck.Vault.Client.ApiResponse<GetConnectionsResponse> localVarResponse = ConnectionsAllWithHttpInfo(xApideckConsumerId, xApideckAppId, api, configured);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all connections This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <returns>ApiResponse of GetConnectionsResponse</returns>
        public Apideck.Vault.Client.ApiResponse<GetConnectionsResponse> ConnectionsAllWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsAll");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsAll");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (api != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "api", api));
            }
            if (configured != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "configured", configured));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<GetConnectionsResponse>("/vault/connections", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsAll", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all connections This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConnectionsResponse</returns>
        public async System.Threading.Tasks.Task<GetConnectionsResponse> ConnectionsAllAsync(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<GetConnectionsResponse> localVarResponse = await ConnectionsAllWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, api, configured, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all connections This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="api">Scope results to Unified API (optional)</param>
        /// <param name="configured">Scopes results to connections that have been configured or not (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConnectionsResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<GetConnectionsResponse>> ConnectionsAllWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string api = default(string), bool? configured = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsAll");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsAll");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (api != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "api", api));
            }
            if (configured != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "configured", configured));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetConnectionsResponse>("/vault/connections", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsAll", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Authorize __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <returns>UnexpectedErrorResponse</returns>
        public UnexpectedErrorResponse ConnectionsAuthorize(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>))
        {
            Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> localVarResponse = ConnectionsAuthorizeWithHttpInfo(serviceId, applicationId, state, redirectUri, scope);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Authorize __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <returns>ApiResponse of UnexpectedErrorResponse</returns>
        public Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> ConnectionsAuthorizeWithHttpInfo(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>))
        {
            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsAuthorize");
            }

            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'applicationId' when calling ConnectionsApi->ConnectionsAuthorize");
            }

            // verify the required parameter 'state' is set
            if (state == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'state' when calling ConnectionsApi->ConnectionsAuthorize");
            }

            // verify the required parameter 'redirectUri' is set
            if (redirectUri == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'redirectUri' when calling ConnectionsApi->ConnectionsAuthorize");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("application_id", Apideck.Vault.Client.ClientUtils.ParameterToString(applicationId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "redirect_uri", redirectUri));
            if (scope != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("ssv", "scope", scope));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<UnexpectedErrorResponse>("/vault/authorize/{service_id}/{application_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsAuthorize", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Authorize __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UnexpectedErrorResponse</returns>
        public async System.Threading.Tasks.Task<UnexpectedErrorResponse> ConnectionsAuthorizeAsync(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> localVarResponse = await ConnectionsAuthorizeWithHttpInfoAsync(serviceId, applicationId, state, redirectUri, scope, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Authorize __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="scope">One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UnexpectedErrorResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse>> ConnectionsAuthorizeWithHttpInfoAsync(string serviceId, string applicationId, string state, string redirectUri, List<string> scope = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsAuthorize");
            }

            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'applicationId' when calling ConnectionsApi->ConnectionsAuthorize");
            }

            // verify the required parameter 'state' is set
            if (state == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'state' when calling ConnectionsApi->ConnectionsAuthorize");
            }

            // verify the required parameter 'redirectUri' is set
            if (redirectUri == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'redirectUri' when calling ConnectionsApi->ConnectionsAuthorize");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("application_id", Apideck.Vault.Client.ClientUtils.ParameterToString(applicationId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "redirect_uri", redirectUri));
            if (scope != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("ssv", "scope", scope));
            }


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<UnexpectedErrorResponse>("/vault/authorize/{service_id}/{application_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsAuthorize", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Callback This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <returns>UnexpectedErrorResponse</returns>
        public UnexpectedErrorResponse ConnectionsCallback(string state, string code)
        {
            Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> localVarResponse = ConnectionsCallbackWithHttpInfo(state, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Callback This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <returns>ApiResponse of UnexpectedErrorResponse</returns>
        public Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> ConnectionsCallbackWithHttpInfo(string state, string code)
        {
            // verify the required parameter 'state' is set
            if (state == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'state' when calling ConnectionsApi->ConnectionsCallback");
            }

            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'code' when calling ConnectionsApi->ConnectionsCallback");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "code", code));


            // make the HTTP request
            var localVarResponse = this.Client.Get<UnexpectedErrorResponse>("/vault/callback", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsCallback", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Callback This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UnexpectedErrorResponse</returns>
        public async System.Threading.Tasks.Task<UnexpectedErrorResponse> ConnectionsCallbackAsync(string state, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> localVarResponse = await ConnectionsCallbackWithHttpInfoAsync(state, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Callback This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="code">An authorization code from the connector which Apideck Vault will later exchange for an access token.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UnexpectedErrorResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse>> ConnectionsCallbackWithHttpInfoAsync(string state, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'state' is set
            if (state == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'state' when calling ConnectionsApi->ConnectionsCallback");
            }

            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'code' when calling ConnectionsApi->ConnectionsCallback");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "code", code));


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<UnexpectedErrorResponse>("/vault/callback", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsCallback", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Deletes a connection Deletes a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns></returns>
        public void ConnectionsDelete(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi)
        {
            ConnectionsDeleteWithHttpInfo(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi);
        }

        /// <summary>
        /// Deletes a connection Deletes a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Apideck.Vault.Client.ApiResponse<Object> ConnectionsDeleteWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi)
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsDelete");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsDelete");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsDelete");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsDelete");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Deletes a connection Deletes a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ConnectionsDeleteAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ConnectionsDeleteWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a connection Deletes a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<Object>> ConnectionsDeleteWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsDelete");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsDelete");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsDelete");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsDelete");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get resource settings This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <returns>GetConnectionResponse</returns>
        public GetConnectionResponse ConnectionsGetSettings(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource)
        {
            Apideck.Vault.Client.ApiResponse<GetConnectionResponse> localVarResponse = ConnectionsGetSettingsWithHttpInfo(xApideckConsumerId, xApideckAppId, unifiedApi, serviceId, resource);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get resource settings This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <returns>ApiResponse of GetConnectionResponse</returns>
        public Apideck.Vault.Client.ApiResponse<GetConnectionResponse> ConnectionsGetSettingsWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource)
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'resource' is set
            if (resource == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'resource' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("resource", Apideck.Vault.Client.ClientUtils.ParameterToString(resource)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<GetConnectionResponse>("/vault/connections/{unified_api}/{service_id}/{resource}/config", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsGetSettings", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get resource settings This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConnectionResponse</returns>
        public async System.Threading.Tasks.Task<GetConnectionResponse> ConnectionsGetSettingsAsync(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<GetConnectionResponse> localVarResponse = await ConnectionsGetSettingsWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, unifiedApi, serviceId, resource, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get resource settings This endpoint returns custom settings and their defaults required by connection for a given resource. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConnectionResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<GetConnectionResponse>> ConnectionsGetSettingsWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsGetSettings");
            }

            // verify the required parameter 'resource' is set
            if (resource == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'resource' when calling ConnectionsApi->ConnectionsGetSettings");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("resource", Apideck.Vault.Client.ClientUtils.ParameterToString(resource)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetConnectionResponse>("/vault/connections/{unified_api}/{service_id}/{resource}/config", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsGetSettings", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get connection Get a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns>GetConnectionResponse</returns>
        public GetConnectionResponse ConnectionsOne(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi)
        {
            Apideck.Vault.Client.ApiResponse<GetConnectionResponse> localVarResponse = ConnectionsOneWithHttpInfo(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get connection Get a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <returns>ApiResponse of GetConnectionResponse</returns>
        public Apideck.Vault.Client.ApiResponse<GetConnectionResponse> ConnectionsOneWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi)
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsOne");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsOne");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsOne");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsOne");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<GetConnectionResponse>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsOne", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get connection Get a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConnectionResponse</returns>
        public async System.Threading.Tasks.Task<GetConnectionResponse> ConnectionsOneAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<GetConnectionResponse> localVarResponse = await ConnectionsOneWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get connection Get a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConnectionResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<GetConnectionResponse>> ConnectionsOneWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsOne");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsOne");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsOne");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsOne");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetConnectionResponse>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsOne", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Revoke __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <returns>UnexpectedErrorResponse</returns>
        public UnexpectedErrorResponse ConnectionsRevoke(string serviceId, string applicationId, string state, string redirectUri)
        {
            Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> localVarResponse = ConnectionsRevokeWithHttpInfo(serviceId, applicationId, state, redirectUri);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Revoke __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <returns>ApiResponse of UnexpectedErrorResponse</returns>
        public Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> ConnectionsRevokeWithHttpInfo(string serviceId, string applicationId, string state, string redirectUri)
        {
            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsRevoke");
            }

            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'applicationId' when calling ConnectionsApi->ConnectionsRevoke");
            }

            // verify the required parameter 'state' is set
            if (state == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'state' when calling ConnectionsApi->ConnectionsRevoke");
            }

            // verify the required parameter 'redirectUri' is set
            if (redirectUri == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'redirectUri' when calling ConnectionsApi->ConnectionsRevoke");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("application_id", Apideck.Vault.Client.ClientUtils.ParameterToString(applicationId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "redirect_uri", redirectUri));


            // make the HTTP request
            var localVarResponse = this.Client.Get<UnexpectedErrorResponse>("/vault/revoke/{service_id}/{application_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsRevoke", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Revoke __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UnexpectedErrorResponse</returns>
        public async System.Threading.Tasks.Task<UnexpectedErrorResponse> ConnectionsRevokeAsync(string serviceId, string applicationId, string state, string redirectUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse> localVarResponse = await ConnectionsRevokeWithHttpInfoAsync(serviceId, applicationId, state, redirectUri, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Revoke __In most cases the authorize link is provided in the &#x60;&#x60;/connections&#x60;&#x60; endpoint. Normally you don&#39;t need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="applicationId">Application ID of the resource to return</param>
        /// <param name="state">An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.</param>
        /// <param name="redirectUri">URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UnexpectedErrorResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<UnexpectedErrorResponse>> ConnectionsRevokeWithHttpInfoAsync(string serviceId, string applicationId, string state, string redirectUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsRevoke");
            }

            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'applicationId' when calling ConnectionsApi->ConnectionsRevoke");
            }

            // verify the required parameter 'state' is set
            if (state == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'state' when calling ConnectionsApi->ConnectionsRevoke");
            }

            // verify the required parameter 'redirectUri' is set
            if (redirectUri == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'redirectUri' when calling ConnectionsApi->ConnectionsRevoke");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("application_id", Apideck.Vault.Client.ClientUtils.ParameterToString(applicationId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "redirect_uri", redirectUri));


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<UnexpectedErrorResponse>("/vault/revoke/{service_id}/{application_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsRevoke", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update connection Update a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>UpdateConnectionResponse</returns>
        public UpdateConnectionResponse ConnectionsUpdate(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection)
        {
            Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse> localVarResponse = ConnectionsUpdateWithHttpInfo(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, connection);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update connection Update a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>ApiResponse of UpdateConnectionResponse</returns>
        public Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse> ConnectionsUpdateWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection)
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'connection' is set
            if (connection == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'connection' when calling ConnectionsApi->ConnectionsUpdate");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            localVarRequestOptions.Data = connection;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Patch<UpdateConnectionResponse>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsUpdate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update connection Update a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateConnectionResponse</returns>
        public async System.Threading.Tasks.Task<UpdateConnectionResponse> ConnectionsUpdateAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse> localVarResponse = await ConnectionsUpdateWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, connection, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update connection Update a connection
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateConnectionResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse>> ConnectionsUpdateWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsUpdate");
            }

            // verify the required parameter 'connection' is set
            if (connection == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'connection' when calling ConnectionsApi->ConnectionsUpdate");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            localVarRequestOptions.Data = connection;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PatchAsync<UpdateConnectionResponse>("/vault/connections/{unified_api}/{service_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsUpdate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update settings Update default values for a connection&#39;s resource settings
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>UpdateConnectionResponse</returns>
        public UpdateConnectionResponse ConnectionsUpdateSettings(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection)
        {
            Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse> localVarResponse = ConnectionsUpdateSettingsWithHttpInfo(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, resource, connection);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update settings Update default values for a connection&#39;s resource settings
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <returns>ApiResponse of UpdateConnectionResponse</returns>
        public Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse> ConnectionsUpdateSettingsWithHttpInfo(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection)
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'resource' is set
            if (resource == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'resource' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'connection' is set
            if (connection == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'connection' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.PathParameters.Add("resource", Apideck.Vault.Client.ClientUtils.ParameterToString(resource)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            localVarRequestOptions.Data = connection;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Patch<UpdateConnectionResponse>("/vault/connections/{unified_api}/{service_id}/{resource}/config", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsUpdateSettings", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update settings Update default values for a connection&#39;s resource settings
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpdateConnectionResponse</returns>
        public async System.Threading.Tasks.Task<UpdateConnectionResponse> ConnectionsUpdateSettingsAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse> localVarResponse = await ConnectionsUpdateSettingsWithHttpInfoAsync(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, resource, connection, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update settings Update default values for a connection&#39;s resource settings
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckConsumerId">ID of the consumer which you want to get or push data from</param>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="serviceId">Service ID of the resource to return</param>
        /// <param name="unifiedApi">Unified API</param>
        /// <param name="resource">Resource Name</param>
        /// <param name="connection">Fields that need to be updated on the resource</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpdateConnectionResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<UpdateConnectionResponse>> ConnectionsUpdateSettingsWithHttpInfoAsync(string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckConsumerId' is set
            if (xApideckConsumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckConsumerId' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'serviceId' is set
            if (serviceId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'serviceId' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'unifiedApi' is set
            if (unifiedApi == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'unifiedApi' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'resource' is set
            if (resource == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'resource' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }

            // verify the required parameter 'connection' is set
            if (connection == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'connection' when calling ConnectionsApi->ConnectionsUpdateSettings");
            }


            Apideck.Vault.Client.RequestOptions localVarRequestOptions = new Apideck.Vault.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Apideck.Vault.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Apideck.Vault.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("service_id", Apideck.Vault.Client.ClientUtils.ParameterToString(serviceId)); // path parameter
            localVarRequestOptions.PathParameters.Add("unified_api", Apideck.Vault.Client.ClientUtils.ParameterToString(unifiedApi)); // path parameter
            localVarRequestOptions.PathParameters.Add("resource", Apideck.Vault.Client.ClientUtils.ParameterToString(resource)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-consumer-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckConsumerId)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter
            localVarRequestOptions.Data = connection;

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PatchAsync<UpdateConnectionResponse>("/vault/connections/{unified_api}/{service_id}/{resource}/config", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConnectionsUpdateSettings", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
