# Apideck.Proxy - the C# library for the Proxy API

Welcome to the Proxy API.

You can use this API to access all Proxy API endpoints.

## Base URL

The base URL for all API requests is `https://unify.apideck.com`

## Headers

Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.

| Name                               | Type   | Required | Description |
| - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | - -- -- - | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| Authorization                      | String | Yes      | Bearer API KEY |
| x-apideck-app-id                   | String | Yes      | The application id of your Unify application. Available at https://app.apideck.com/unify/api-keys. |
| x-apideck-consumer-id              | String | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app.                       |
| x-apideck-downstream-url           | String | Yes      | Downstream URL to forward the request too |
| x-apideck-downstream-authorization | String | No       | Downstream authorization header. This will skip the Vault token injection. |
| x-apideck-downstream-method        | String | No       | Downstream method. If not provided the upstream method will be inherited, depending on the verb/method of the request this will contain the request body you want to POST/PATCH/PUT. |
| x-apideck-service-id               | String | No       | Describe the service you want to call (e.g., pipedrive). Only needed when a customer has activated multiple integrations for the same Unified API.                                   |

## Authorization

You can interact with the API through the authorization methods below.

### apiKey

To use API you have to sign up and get your own API key. Unify API accounts have sandbox mode and live mode API keys. To change modes just use the appropriate key to get a live or test object. You can find your API keys on the unify settings of your Apideck app. Your Apideck application_id can also be found on the same page.

Authenticate your API requests by including your test or live secret API key in the request header.

- Bearer authorization header: Authorization: Bearer <your-apideck-api-key>
- Application id header: x-apideck-app-id: <your-apideck-app-id>
  You should use the public keys on the SDKs and the secret keys to authenticate API requests.

**Do not share or include your secret API keys on client side code.** Your API keys carry significant privileges. Please ensure to keep them 100% secure and be sure to not share your secret API keys in areas that are publicly accessible like GitHub.

Learn how to set the Authorization header inside Postman https://learning.postman.com/docs/postman/sending-api-requests/authorization/#api-key

Go to Unify to grab your API KEY https://app.apideck.com/unify/api-keys

| Security Scheme Type      | HTTP   |
| - -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- - |
| HTTP Authorization Scheme | bearer |

### applicationId

The ID of your Unify application

| Security Scheme Type  | API Key          |
| - -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- - |
| Header parameter name | x-apideck-app-id |

## Static IP

Some of the APIs you want to use can require a static IP. Apideck's static IP feature allows you to the Proxy API with a fixed IP avoiding the need for you to set up your own infrastructure. This feature is currently available to all Apideck customers.
To use this feature, the API Vendor will need to whitelist the associated static IP addresses.
The provided static IP addresses are fixed to their specified region and shared by all customers who use this feature.

- EU Central 1: **18.197.244.247**
- Other: upcoming

  More info about our data security can be found at [https://compliance.apideck.com/](https://compliance.apideck.com/)

## Limitations

### Timeout

The request timeout is set at 30 seconds.

### Response Size

The Proxy API has no response size limit. For responses larger than 2MB, the Proxy API will redirect to a temporary URL. In this case the usual Apideck response headers will be returned in the redirect response. Most HTTP clients will handle this redirect automatically.

```
GET /proxy
< 301 Moved Permanently
< x-apideck-request-id: {{requestId}}
< Location: {{temporaryUrl}}

GET {{temporaryUrl}}
< {{responseBody}}
```

## SDKs and API Clients

Upcoming. [Request the SDK of your choice](https://integrations.apideck.com/request).

## Errors

The API returns standard HTTP response codes to indicate success or failure of the API requests. For errors, we also return a customized error message inside the JSON response. You can see the returned HTTP status codes below.

| Code | Title                | Description |
| - -- - | - -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| 200  | OK                   | The request message has been successfully processed, and it has produced a response. The response message varies, depending on the request method and the requested data.                                |
| 201  | Created              | The request has been fulfilled and has resulted in one or more new resources being created. |
| 204  | No Content           | The server has successfully fulfilled the request and that there is no additional content to send in the response payload body. |
| 400  | Bad Request          | The receiving server cannot understand the request because of malformed syntax. Do not repeat the request without first modifying it; check the request for errors, fix them and then retry the request. |
| 401  | Unauthorized         | The request has not been applied because it lacks valid authentication credentials for the target resource. |
| 402  | Payment Required     | Subscription data is incomplete or out of date. You'll need to provide payment details to continue. |
| 403  | Forbidden            | You do not have the appropriate user rights to access the request. Do not repeat the request. |
| 404  | Not Found            | The origin server did not find a current representation for the target resource or is not willing to disclose that one exists. |
| 409  | Conflict             | The request could not be completed due to a conflict with the current state of the target resource. |
| 422  | Unprocessable Entity | The server understands the content type of the request entity, and the syntax of the request entity is correct but was unable to process the contained instructions.                                     |
| 5xx  | Server Errors        | Something went wrong with the Unify API. These errors are logged on our side. You can contact our team to resolve the issue. |

### Handling errors

The Unify API and SDKs can produce errors for many reasons, such as a failed requests due to misconfigured integrations, invalid parameters, authentication errors, and network unavailability.

### Error Types

#### RequestBodyValidationError

Request body is not valid for the current endpoint. Check the spelling and types of your attributes, and ensure you are not passing data that is outside of the specification.

#### RequestParametersValidationError

Request parameters are not valid for the current endpoint. Check the spelling and types of your parameters, and ensure you are not passing parameters that are outside of the specification.

#### RequestHeadersValidationError

Request headers are not valid for the current endpoint. Check the spelling and types of your headers, and ensure you are not passing headers that are outside of the specification.

#### UnsupportedFiltersError

Filters in the request are valid, but not supported by the connector. Remove the unsupported filter(s) to get a successful response.

#### InvalidCursorError

Pagination cursor in the request is not valid for the current connector. Make sure to use a cursor returned from the API, for the same connector.

#### ConnectorExecutionError

A Unified API request made via one of our downstream connectors returned an unexpected error. The `status_code` returned is proxied through to error response along with their original response via the error detail.

#### UnauthorizedError

We were unable to authorize the request as made. This can happen for a number of reasons, from missing header params to passing an incorrect authorization token. Verify your Api Key is being set correctly in the authorization header. ie: `Authorization: 'Bearer sk_live_***'`

#### ConnectorCredentialsError

A request using a given connector has not been authorized. Ensure the connector you are trying to use has been configured correctly and been authorized for use.

#### ConnectorDisabledError

A request has been made to a connector that has since been disabled. This may be temporary - You can contact our team to resolve the issue.

#### RequestLimitError

You have reached the number of requests included in your Free Tier Subscription. You will no be able to make further requests until this limit resets at the end of the month, or talk to us about upgrading your subscription to continue immediately.

#### EntityNotFoundError

You've made a request for a resource or route that does not exist. Verify your path parameters or any identifiers used to fetch this resource.

#### OAuthCredentialsNotFoundError

When adding a connector integration that implements OAuth, both a `client_id` and `client_secret` must be provided before any authorizations can be performed. Verify the integration has been configured properly before continuing.

#### IntegrationNotFoundError

The requested connector integration could not be found associated to your `application_id`. Verify your `application_id` is correct, and that this connector has been added and configured for your application.

#### ConnectionNotFoundError

A valid connection could not be found associated to your `application_id`. Something _may_ have interrupted the authorization flow. You may need to start the connector authorization process again.

#### ConnectorNotFoundError

A request was made for an unknown connector. Verify your `service_id` is spelled correctly, and that this connector is enabled for your provided `unified_api`.

#### OAuthRedirectUriError

A request was made either in a connector authorization flow, or attempting to revoke connector access without a valid `redirect_uri`. This is the url the user should be returned to on completion of process.

#### OAuthInvalidStateError

The state param is required and is used to ensure the outgoing authorization state has not been altered before the user is redirected back. It also contains required params needed to identify the connector being used. If this has been altered, the authorization will not succeed.

#### OAuthCodeExchangeError

When attempting to exchange the authorization code for an `access_token` during an OAuth flow, an error occurred. This may be temporary. You can reattempt authorization or contact our team to resolve the issue.

#### MappingError

There was an error attempting to retrieve the mapping for a given attribute. We've been notified and are working to fix this issue.

#### ConnectorMappingNotFoundError

It seems the implementation for this connector is incomplete. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### ConnectorResponseMappingNotFoundError

We were unable to retrieve the response mapping for this connector. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### ConnectorOperationMappingNotFoundError

Connector mapping has not been implemented for the requested operation. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### ConnectorWorkflowMappingError

The composite api calls required for this operation have not been mapped entirely. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### PaginationNotSupportedError

Pagination is not yet supported for this connector, try removing limit and/or cursor from the query. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

## API Design

### API Styles and data formats

#### REST API

The API is organized around [REST](https://restfulapi.net/), providing simple and predictable URIs to access and modify objects. Requests support standard HTTP methods like GET, PUT, POST, and DELETE and standard status codes. JSON is returned by all API responses, including errors. In all API requests, you must set the content-type HTTP header to application/json. All API requests must be made over HTTPS. Calls made over HTTP will fail.

### Request IDs

Each API request has an associated request identifier. You can find this value in the response headers, under Request-Id. You can also find request identifiers in the URLs of individual request logs in your Dashboard. If you need to contact us about a specific request, providing the request identifier will ensure the fastest possible resolution.

## Support

If you have problems or need help with your case, you can always reach out to our Support.


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
using Apideck.Proxy.Api;
using Apideck.Proxy.Client;
using Apideck.Proxy.Model;
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
using Apideck.Proxy.Api;
using Apideck.Proxy.Client;
using Apideck.Proxy.Model;

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

            var apiInstance = new ExecuteApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = close;  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API.
            var xApideckDownstreamUrl = https://api.close.com/api/v1/lead;  // string | Downstream URL
            var xApideckDownstreamAuthorization = Bearer XXXXXXXXXXXXXXXXX;  // string | Downstream authorization header. This will skip the Vault token injection. (optional) 

            try
            {
                // DELETE
                Object result = apiInstance.DeleteProxy(xApideckConsumerId, xApideckAppId, xApideckServiceId, xApideckDownstreamUrl, xApideckDownstreamAuthorization);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ExecuteApi.DeleteProxy: " + e.Message );
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
*ExecuteApi* | [**DeleteProxy**](docs/ExecuteApi.md#deleteproxy) | **DELETE** /proxy | DELETE
*ExecuteApi* | [**GetProxy**](docs/ExecuteApi.md#getproxy) | **GET** /proxy | GET
*ExecuteApi* | [**PatchProxy**](docs/ExecuteApi.md#patchproxy) | **PATCH** /proxy | PATCH
*ExecuteApi* | [**PostProxy**](docs/ExecuteApi.md#postproxy) | **POST** /proxy | POST
*ExecuteApi* | [**PutProxy**](docs/ExecuteApi.md#putproxy) | **PUT** /proxy | PUT


<a name="documentation-for-models"></a>
## Documentation for Models



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

