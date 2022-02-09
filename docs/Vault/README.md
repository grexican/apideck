# Apideck.Vault - the C# library for the Vault API

Welcome to the Vault API 👋

When you're looking to connect to an API, the first step is authentication.

Vault helps you handle OAuth flows, store API keys, and refresh access tokens from users (called consumers in Apideck).

## Base URL

The base URL for all API requests is `https://unify.apideck.com`

## Get Started

To use the Apideck APIs, you need to sign up for free at [https://app.apideck.com/signup](). Follow the steps below to get started.

- [Create a free account.](https://app.apideck.com/signup)
- Go to the [Dashboard](https://app.apideck.com/unify/unified-apis/dashboard).
- Get your API key and the application ID.
- Select and configure the integrations you want to make available to your users. Through the Unify dashboard, you can configure which connectors you want to support as integrations.
- Retrieve the client_id and client_secret for the integration you want to activate (Only needed for OAuth integrations).
- Soon, you can skip the previous step and use the Apideck sandbox credentials to get you started instead (upcoming)
- Register the redirect URI for the example app (https://unify.apideck.com/vault/callback) in the list of redirect URIs under your app's settings
- Use the [publishing guides](/app-listing-requirements) to get your integration listed across app marketplaces.

### Hosted Vault

Hosted Vault (vault.apideck.com) is a no-code solution, so you don't need to build your own UI to handle the integration settings and authentication.

![Hosted Vault - Integrations portal](https://github.com/apideck-samples/integration-settings/raw/master/public/img/vault.png)

Behind the scenes, Hosted Vault implements the Vault API endpoints and handles the following features for your customers:

- Add a connection
- Handle the OAuth flow
- Configure connection settings per integration
- Manage connections
- Discover and propose integration options
- Search for integrations (upcoming)
- Give integration suggestions based on provided metadata (email or website) when creating the session (upcoming)

To use Hosted Vault, you will need to first [__create a session__](https://developers.apideck.com/apis/vault/reference#operation/sessionsCreate). This can be achieved by making a POST request to the Vault API to create a valid session for a user, hereafter referred to as the consumer ID.

Example using curl:

```
curl -X POST https://unify.apideck.com/vault/sessions
    -H \"Content-Type: application/json\"
    -H \"Authorization: Bearer <your-api-key>\"
    -H \"X-APIDECK-CONSUMER-ID: <consumer-id>\"
    -H \"X-APIDECK-APP-ID: <application-id>\"
    -d '{\"consumer_metadata\": { \"account_name\" : \"Sample\", \"user_name\": \"Sand Box\", \"email\": \"sand@box.com\", \"image\": \"https://unavatar.now.sh/jake\" }, \"theme\": { \"vault_name\": \"Intercom\", \"primary_color\": \"#286efa\", \"sidepanel_background_color\": \"#286efa\",\"sidepanel_text_color\": \"#FFFFFF\", \"favicon\": \"https://res.cloudinary.com/apideck/icons/intercom\" }}'
```

### Vault API

_Beware, this is strategy takes more time to implement in comparison to Hosted Vault._

If you are building your integration settings UI manually, you can call the Vault API directly.

The Vault API is for those who want to completely white label the in-app integrations overview and authentication experience. All the available endpoints are listed below.

Through the API, your customers authenticate directly in your app, where Vault will still take care of redirecting to the auth provider and back to your app.

If you're already storing access tokens, we will help you migrate through our Vault Migration API (upcoming).

## Domain model

At its core, a domain model creates a web of interconnected entities.

Our domain model contains five main entity types: Consumer (user, account, team, machine), Application, Connector, Integration, and Connection.

## Connection state

The connection state is computed based on the connection flow below.

![](https://developers.apideck.com/api-references/vault/connection-flow.png)

## Unify and Proxy integration

The only thing you need to use the Unify APIs and Proxy is the consumer id; thereafter, Vault will do the look-up in the background to handle the token injection before performing the API call(s).

## Headers

Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.

| Name                  | Type    | Required | Description                                                                                                                                                    |
| - -- -- -- -- -- -- -- -- -- -- | - -- -- -- | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| x-apideck-app-id      | String  | Yes      | The id of your Unify application. Available at https://app.apideck.com/api-keys.                                                                               |
| x-apideck-consumer-id | String  | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app. |
| x-apideck-raw         | Boolean | No       | Include raw response. Mostly used for debugging purposes.                                                                                                      |

## Sandbox (upcoming)

The sandbox is pre-loaded with data similar to a real-life integrations setup. You can use the preconfigured OAauth configured connectors for testing purposes and can skip this step by using the Apideck sandbox credentials to get you started.

## Guides

- [How to build an integrations UI with Vault](https://github.com/apideck-samples/integration-settings)
- How to configure the OAuth credentials for integration providers (COMING SOON)

## FAQ

**What purpose does Vault serve? Can I just handle the authentication and access token myself?**
You can store everything yourself, but that defeats the purpose of using Apideck Unify. Handling tokens for multiple providers can quickly become very complex.

### Is my data secure?

Vault employs data minimization, therefore only requesting the minimum amount of scopes needed to perform an API request.

### How do I migrate existing data?

Using our migration API, you can migrate the access tokens and accounts to Apideck Vault. (COMING SOON)

### Can I use Vault in combination with existing integrations?

Yes, you can. The flexibility of Unify allows you to quickly the use cases you need while keeping a gradual migration path based on your timeline and requirements.

### How does Vault work for Apideck Ecosystem customers?

Once logged in, pick your ecosystem; on the left-hand side of the screen, you'll have the option to create an application underneath the Unify section.

### How to integrate Apideck Vault

This section covers everything you need to know to authenticate your customers through Vault.
Vault provides **three auth strategies** to use API tokens from your customers:

- Vault API
- Hosted Vault
- Apideck Ecosystem _(COMING SOON)_

You can also opt to bypass Vault and still take care of authentication flows yourself. Make sure to put the right safeguards in place to protect your customers' tokens and other sensitive data.

### What auth types does Vault support?

What auth strategies does Vault handle? We currently support three flows so your customers can activate an integration.

#### API keys

For Services supporting the API key strategy, you can use Hosted Vault will need to provide an in-app form where users can configure their API keys provided by the integration service.

#### OAuth 2.0

##### Authorization Code Grant Type Flow

Vault handles the complete Authorization Code Grant Type Flow for you. This flow only supports browser-based (passive) authentication because most identity providers don't allow entering a username and password to be entered into applications that they don't own.

Certain connectors require an OAuth redirect authentication flow, where the end-user is redirected to the provider's website or mobile app to authenticate.

This is being handled by the `/authorize` endpoint.

#### Basic auth

Basic authentication is a simple authentication scheme built into the HTTP protocol. The required fields to complete basic auth are handled by Hosted Vault or by updating the connection through the Vault API below.


This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 8.11.0
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen
    For more information, please visit [https://developers.apideck.com](https://developers.apideck.com)

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 12.0.3 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;
```
<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ConnectionsApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var unifiedApi = crm;  // string | Unified API
            var connection = new Connection(); // Connection | Fields that need to be persisted on the resource

            try
            {
                // Create connection
                CreateConnectionResponse result = apiInstance.ConnectionsAdd(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, connection);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsAdd: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://unify.apideck.com*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ConnectionsApi* | [**ConnectionsAdd**](docs/ConnectionsApi.md#connectionsadd) | **POST** /vault/connections/{unified_api}/{service_id} | Create connection
*ConnectionsApi* | [**ConnectionsAll**](docs/ConnectionsApi.md#connectionsall) | **GET** /vault/connections | Get all connections
*ConnectionsApi* | [**ConnectionsAuthorize**](docs/ConnectionsApi.md#connectionsauthorize) | **GET** /vault/authorize/{service_id}/{application_id} | Authorize
*ConnectionsApi* | [**ConnectionsCallback**](docs/ConnectionsApi.md#connectionscallback) | **GET** /vault/callback | Callback
*ConnectionsApi* | [**ConnectionsDelete**](docs/ConnectionsApi.md#connectionsdelete) | **DELETE** /vault/connections/{unified_api}/{service_id} | Deletes a connection
*ConnectionsApi* | [**ConnectionsGetSettings**](docs/ConnectionsApi.md#connectionsgetsettings) | **GET** /vault/connections/{unified_api}/{service_id}/{resource}/config | Get resource settings
*ConnectionsApi* | [**ConnectionsOne**](docs/ConnectionsApi.md#connectionsone) | **GET** /vault/connections/{unified_api}/{service_id} | Get connection
*ConnectionsApi* | [**ConnectionsRevoke**](docs/ConnectionsApi.md#connectionsrevoke) | **GET** /vault/revoke/{service_id}/{application_id} | Revoke
*ConnectionsApi* | [**ConnectionsUpdate**](docs/ConnectionsApi.md#connectionsupdate) | **PATCH** /vault/connections/{unified_api}/{service_id} | Update connection
*ConnectionsApi* | [**ConnectionsUpdateSettings**](docs/ConnectionsApi.md#connectionsupdatesettings) | **PATCH** /vault/connections/{unified_api}/{service_id}/{resource}/config | Update settings
*ConsumersApi* | [**ConsumersAll**](docs/ConsumersApi.md#consumersall) | **GET** /vault/consumers | Get all consumers
*ConsumersApi* | [**ConsumersOne**](docs/ConsumersApi.md#consumersone) | **GET** /vault/consumers/{consumer_id} | Get consumer
*ConsumersApi* | [**ConsumersRequestCounts**](docs/ConsumersApi.md#consumersrequestcounts) | **GET** /vault/consumers/{consumer_id}/stats | Consumer request counts
*LogsApi* | [**LogsAll**](docs/LogsApi.md#logsall) | **GET** /vault/logs | Get all consumer request logs
*SessionsApi* | [**SessionsCreate**](docs/SessionsApi.md#sessionscreate) | **POST** /vault/sessions | Create Session


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.AuthType](docs/AuthType.md)
 - [Model.BadRequestResponse](docs/BadRequestResponse.md)
 - [Model.Connection](docs/Connection.md)
 - [Model.ConnectionConfiguration](docs/ConnectionConfiguration.md)
 - [Model.ConnectionDefaults](docs/ConnectionDefaults.md)
 - [Model.ConnectionEvent](docs/ConnectionEvent.md)
 - [Model.ConnectionMetadata](docs/ConnectionMetadata.md)
 - [Model.ConnectionState](docs/ConnectionState.md)
 - [Model.Consumer](docs/Consumer.md)
 - [Model.ConsumerConnection](docs/ConsumerConnection.md)
 - [Model.ConsumerMetadata](docs/ConsumerMetadata.md)
 - [Model.ConsumerRequestCountsInDateRangeResponse](docs/ConsumerRequestCountsInDateRangeResponse.md)
 - [Model.ConsumerRequestCountsInDateRangeResponseData](docs/ConsumerRequestCountsInDateRangeResponseData.md)
 - [Model.ConsumerWebhook](docs/ConsumerWebhook.md)
 - [Model.CreateConnectionResponse](docs/CreateConnectionResponse.md)
 - [Model.CreateSessionResponse](docs/CreateSessionResponse.md)
 - [Model.CreateSessionResponseData](docs/CreateSessionResponseData.md)
 - [Model.FormField](docs/FormField.md)
 - [Model.FormFieldOption](docs/FormFieldOption.md)
 - [Model.FormFieldOptionGroup](docs/FormFieldOptionGroup.md)
 - [Model.GetConnectionResponse](docs/GetConnectionResponse.md)
 - [Model.GetConnectionsResponse](docs/GetConnectionsResponse.md)
 - [Model.GetConsumerResponse](docs/GetConsumerResponse.md)
 - [Model.GetConsumersResponse](docs/GetConsumersResponse.md)
 - [Model.GetConsumersResponseData](docs/GetConsumersResponseData.md)
 - [Model.GetLogsResponse](docs/GetLogsResponse.md)
 - [Model.Links](docs/Links.md)
 - [Model.Log](docs/Log.md)
 - [Model.LogOperation](docs/LogOperation.md)
 - [Model.LogService](docs/LogService.md)
 - [Model.LogsFilter](docs/LogsFilter.md)
 - [Model.Meta](docs/Meta.md)
 - [Model.MetaCursors](docs/MetaCursors.md)
 - [Model.NotFoundResponse](docs/NotFoundResponse.md)
 - [Model.NotImplementedResponse](docs/NotImplementedResponse.md)
 - [Model.PaymentRequiredResponse](docs/PaymentRequiredResponse.md)
 - [Model.RequestCountAllocation](docs/RequestCountAllocation.md)
 - [Model.Session](docs/Session.md)
 - [Model.SessionSettings](docs/SessionSettings.md)
 - [Model.SessionTheme](docs/SessionTheme.md)
 - [Model.SimpleFormFieldOption](docs/SimpleFormFieldOption.md)
 - [Model.UnauthorizedResponse](docs/UnauthorizedResponse.md)
 - [Model.UnexpectedErrorResponse](docs/UnexpectedErrorResponse.md)
 - [Model.UnifiedApiId](docs/UnifiedApiId.md)
 - [Model.UnprocessableResponse](docs/UnprocessableResponse.md)
 - [Model.UpdateConnectionResponse](docs/UpdateConnectionResponse.md)
 - [Model.VaultEventType](docs/VaultEventType.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="apiKey"></a>
### apiKey

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

<a name="applicationId"></a>
### applicationId

- **Type**: API key
- **API key parameter name**: x-apideck-app-id
- **Location**: HTTP header

