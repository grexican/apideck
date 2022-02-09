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
    public interface IConsumersApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get all consumers
        /// </summary>
        /// <remarks>
        /// This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <returns>GetConsumersResponse</returns>
        GetConsumersResponse ConsumersAll(string xApideckAppId, string cursor = default(string), int? limit = default(int?));

        /// <summary>
        /// Get all consumers
        /// </summary>
        /// <remarks>
        /// This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <returns>ApiResponse of GetConsumersResponse</returns>
        ApiResponse<GetConsumersResponse> ConsumersAllWithHttpInfo(string xApideckAppId, string cursor = default(string), int? limit = default(int?));
        /// <summary>
        /// Get consumer
        /// </summary>
        /// <remarks>
        /// Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <returns>GetConsumerResponse</returns>
        GetConsumerResponse ConsumersOne(string xApideckAppId, string consumerId);

        /// <summary>
        /// Get consumer
        /// </summary>
        /// <remarks>
        /// Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <returns>ApiResponse of GetConsumerResponse</returns>
        ApiResponse<GetConsumerResponse> ConsumersOneWithHttpInfo(string xApideckAppId, string consumerId);
        /// <summary>
        /// Consumer request counts
        /// </summary>
        /// <remarks>
        /// Get consumer request counts within a given datetime range. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <returns>ConsumerRequestCountsInDateRangeResponse</returns>
        ConsumerRequestCountsInDateRangeResponse ConsumersRequestCounts(string xApideckAppId, string consumerId, string startDatetime, string endDatetime);

        /// <summary>
        /// Consumer request counts
        /// </summary>
        /// <remarks>
        /// Get consumer request counts within a given datetime range. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <returns>ApiResponse of ConsumerRequestCountsInDateRangeResponse</returns>
        ApiResponse<ConsumerRequestCountsInDateRangeResponse> ConsumersRequestCountsWithHttpInfo(string xApideckAppId, string consumerId, string startDatetime, string endDatetime);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IConsumersApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get all consumers
        /// </summary>
        /// <remarks>
        /// This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConsumersResponse</returns>
        System.Threading.Tasks.Task<GetConsumersResponse> ConsumersAllAsync(string xApideckAppId, string cursor = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all consumers
        /// </summary>
        /// <remarks>
        /// This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConsumersResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetConsumersResponse>> ConsumersAllWithHttpInfoAsync(string xApideckAppId, string cursor = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get consumer
        /// </summary>
        /// <remarks>
        /// Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConsumerResponse</returns>
        System.Threading.Tasks.Task<GetConsumerResponse> ConsumersOneAsync(string xApideckAppId, string consumerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get consumer
        /// </summary>
        /// <remarks>
        /// Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConsumerResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetConsumerResponse>> ConsumersOneWithHttpInfoAsync(string xApideckAppId, string consumerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Consumer request counts
        /// </summary>
        /// <remarks>
        /// Get consumer request counts within a given datetime range. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ConsumerRequestCountsInDateRangeResponse</returns>
        System.Threading.Tasks.Task<ConsumerRequestCountsInDateRangeResponse> ConsumersRequestCountsAsync(string xApideckAppId, string consumerId, string startDatetime, string endDatetime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Consumer request counts
        /// </summary>
        /// <remarks>
        /// Get consumer request counts within a given datetime range. 
        /// </remarks>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ConsumerRequestCountsInDateRangeResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ConsumerRequestCountsInDateRangeResponse>> ConsumersRequestCountsWithHttpInfoAsync(string xApideckAppId, string consumerId, string startDatetime, string endDatetime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IConsumersApi : IConsumersApiSync, IConsumersApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ConsumersApi : IConsumersApi
    {
        private Apideck.Vault.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConsumersApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConsumersApi(string basePath)
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
        /// Initializes a new instance of the <see cref="ConsumersApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ConsumersApi(Apideck.Vault.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ConsumersApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ConsumersApi(Apideck.Vault.Client.ISynchronousClient client, Apideck.Vault.Client.IAsynchronousClient asyncClient, Apideck.Vault.Client.IReadableConfiguration configuration)
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
        /// Get all consumers This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <returns>GetConsumersResponse</returns>
        public GetConsumersResponse ConsumersAll(string xApideckAppId, string cursor = default(string), int? limit = default(int?))
        {
            Apideck.Vault.Client.ApiResponse<GetConsumersResponse> localVarResponse = ConsumersAllWithHttpInfo(xApideckAppId, cursor, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all consumers This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <returns>ApiResponse of GetConsumersResponse</returns>
        public Apideck.Vault.Client.ApiResponse<GetConsumersResponse> ConsumersAllWithHttpInfo(string xApideckAppId, string cursor = default(string), int? limit = default(int?))
        {
            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConsumersApi->ConsumersAll");
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

            if (cursor != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "cursor", cursor));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<GetConsumersResponse>("/vault/consumers", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConsumersAll", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all consumers This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConsumersResponse</returns>
        public async System.Threading.Tasks.Task<GetConsumersResponse> ConsumersAllAsync(string xApideckAppId, string cursor = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<GetConsumersResponse> localVarResponse = await ConsumersAllWithHttpInfoAsync(xApideckAppId, cursor, limit, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all consumers This endpoint includes all application consumers, along with an aggregated count of requests made. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="cursor">Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional)</param>
        /// <param name="limit">Number of records to return (optional, default to 20)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConsumersResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<GetConsumersResponse>> ConsumersAllWithHttpInfoAsync(string xApideckAppId, string cursor = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConsumersApi->ConsumersAll");
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

            if (cursor != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "cursor", cursor));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetConsumersResponse>("/vault/consumers", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConsumersAll", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get consumer Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <returns>GetConsumerResponse</returns>
        public GetConsumerResponse ConsumersOne(string xApideckAppId, string consumerId)
        {
            Apideck.Vault.Client.ApiResponse<GetConsumerResponse> localVarResponse = ConsumersOneWithHttpInfo(xApideckAppId, consumerId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get consumer Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <returns>ApiResponse of GetConsumerResponse</returns>
        public Apideck.Vault.Client.ApiResponse<GetConsumerResponse> ConsumersOneWithHttpInfo(string xApideckAppId, string consumerId)
        {
            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConsumersApi->ConsumersOne");
            }

            // verify the required parameter 'consumerId' is set
            if (consumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'consumerId' when calling ConsumersApi->ConsumersOne");
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

            localVarRequestOptions.PathParameters.Add("consumer_id", Apideck.Vault.Client.ClientUtils.ParameterToString(consumerId)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<GetConsumerResponse>("/vault/consumers/{consumer_id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConsumersOne", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get consumer Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetConsumerResponse</returns>
        public async System.Threading.Tasks.Task<GetConsumerResponse> ConsumersOneAsync(string xApideckAppId, string consumerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<GetConsumerResponse> localVarResponse = await ConsumersOneWithHttpInfoAsync(xApideckAppId, consumerId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get consumer Consumer detail including their aggregated counts with the connections they have authorized. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetConsumerResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<GetConsumerResponse>> ConsumersOneWithHttpInfoAsync(string xApideckAppId, string consumerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConsumersApi->ConsumersOne");
            }

            // verify the required parameter 'consumerId' is set
            if (consumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'consumerId' when calling ConsumersApi->ConsumersOne");
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

            localVarRequestOptions.PathParameters.Add("consumer_id", Apideck.Vault.Client.ClientUtils.ParameterToString(consumerId)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetConsumerResponse>("/vault/consumers/{consumer_id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConsumersOne", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Consumer request counts Get consumer request counts within a given datetime range. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <returns>ConsumerRequestCountsInDateRangeResponse</returns>
        public ConsumerRequestCountsInDateRangeResponse ConsumersRequestCounts(string xApideckAppId, string consumerId, string startDatetime, string endDatetime)
        {
            Apideck.Vault.Client.ApiResponse<ConsumerRequestCountsInDateRangeResponse> localVarResponse = ConsumersRequestCountsWithHttpInfo(xApideckAppId, consumerId, startDatetime, endDatetime);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Consumer request counts Get consumer request counts within a given datetime range. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <returns>ApiResponse of ConsumerRequestCountsInDateRangeResponse</returns>
        public Apideck.Vault.Client.ApiResponse<ConsumerRequestCountsInDateRangeResponse> ConsumersRequestCountsWithHttpInfo(string xApideckAppId, string consumerId, string startDatetime, string endDatetime)
        {
            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConsumersApi->ConsumersRequestCounts");
            }

            // verify the required parameter 'consumerId' is set
            if (consumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'consumerId' when calling ConsumersApi->ConsumersRequestCounts");
            }

            // verify the required parameter 'startDatetime' is set
            if (startDatetime == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'startDatetime' when calling ConsumersApi->ConsumersRequestCounts");
            }

            // verify the required parameter 'endDatetime' is set
            if (endDatetime == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'endDatetime' when calling ConsumersApi->ConsumersRequestCounts");
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

            localVarRequestOptions.PathParameters.Add("consumer_id", Apideck.Vault.Client.ClientUtils.ParameterToString(consumerId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "start_datetime", startDatetime));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "end_datetime", endDatetime));
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ConsumerRequestCountsInDateRangeResponse>("/vault/consumers/{consumer_id}/stats", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConsumersRequestCounts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Consumer request counts Get consumer request counts within a given datetime range. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ConsumerRequestCountsInDateRangeResponse</returns>
        public async System.Threading.Tasks.Task<ConsumerRequestCountsInDateRangeResponse> ConsumersRequestCountsAsync(string xApideckAppId, string consumerId, string startDatetime, string endDatetime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Apideck.Vault.Client.ApiResponse<ConsumerRequestCountsInDateRangeResponse> localVarResponse = await ConsumersRequestCountsWithHttpInfoAsync(xApideckAppId, consumerId, startDatetime, endDatetime, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Consumer request counts Get consumer request counts within a given datetime range. 
        /// </summary>
        /// <exception cref="Apideck.Vault.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xApideckAppId">The ID of your Unify application</param>
        /// <param name="consumerId">ID of the consumer to return</param>
        /// <param name="startDatetime">Scopes results to requests that happened after datetime</param>
        /// <param name="endDatetime">Scopes results to requests that happened before datetime</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ConsumerRequestCountsInDateRangeResponse)</returns>
        public async System.Threading.Tasks.Task<Apideck.Vault.Client.ApiResponse<ConsumerRequestCountsInDateRangeResponse>> ConsumersRequestCountsWithHttpInfoAsync(string xApideckAppId, string consumerId, string startDatetime, string endDatetime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xApideckAppId' is set
            if (xApideckAppId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'xApideckAppId' when calling ConsumersApi->ConsumersRequestCounts");
            }

            // verify the required parameter 'consumerId' is set
            if (consumerId == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'consumerId' when calling ConsumersApi->ConsumersRequestCounts");
            }

            // verify the required parameter 'startDatetime' is set
            if (startDatetime == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'startDatetime' when calling ConsumersApi->ConsumersRequestCounts");
            }

            // verify the required parameter 'endDatetime' is set
            if (endDatetime == null)
            {
                throw new Apideck.Vault.Client.ApiException(400, "Missing required parameter 'endDatetime' when calling ConsumersApi->ConsumersRequestCounts");
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

            localVarRequestOptions.PathParameters.Add("consumer_id", Apideck.Vault.Client.ClientUtils.ParameterToString(consumerId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "start_datetime", startDatetime));
            localVarRequestOptions.QueryParameters.Add(Apideck.Vault.Client.ClientUtils.ParameterToMultiMap("", "end_datetime", endDatetime));
            localVarRequestOptions.HeaderParameters.Add("x-apideck-app-id", Apideck.Vault.Client.ClientUtils.ParameterToString(xApideckAppId)); // header parameter

            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ConsumerRequestCountsInDateRangeResponse>("/vault/consumers/{consumer_id}/stats", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConsumersRequestCounts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
