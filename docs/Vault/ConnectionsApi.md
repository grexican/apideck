# Apideck.Vault.Api.ConnectionsApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ConnectionsAdd**](ConnectionsApi.md#connectionsadd) | **POST** /vault/connections/{unified_api}/{service_id} | Create connection
[**ConnectionsAll**](ConnectionsApi.md#connectionsall) | **GET** /vault/connections | Get all connections
[**ConnectionsAuthorize**](ConnectionsApi.md#connectionsauthorize) | **GET** /vault/authorize/{service_id}/{application_id} | Authorize
[**ConnectionsCallback**](ConnectionsApi.md#connectionscallback) | **GET** /vault/callback | Callback
[**ConnectionsDelete**](ConnectionsApi.md#connectionsdelete) | **DELETE** /vault/connections/{unified_api}/{service_id} | Deletes a connection
[**ConnectionsGetSettings**](ConnectionsApi.md#connectionsgetsettings) | **GET** /vault/connections/{unified_api}/{service_id}/{resource}/config | Get resource settings
[**ConnectionsOne**](ConnectionsApi.md#connectionsone) | **GET** /vault/connections/{unified_api}/{service_id} | Get connection
[**ConnectionsRevoke**](ConnectionsApi.md#connectionsrevoke) | **GET** /vault/revoke/{service_id}/{application_id} | Revoke
[**ConnectionsUpdate**](ConnectionsApi.md#connectionsupdate) | **PATCH** /vault/connections/{unified_api}/{service_id} | Update connection
[**ConnectionsUpdateSettings**](ConnectionsApi.md#connectionsupdatesettings) | **PATCH** /vault/connections/{unified_api}/{service_id}/{resource}/config | Update settings


<a name="connectionsadd"></a>
# **ConnectionsAdd**
> CreateConnectionResponse ConnectionsAdd (string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection)

Create connection

Create an authorized connection 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsAddExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

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
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsAdd: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **serviceId** | **string**| Service ID of the resource to return | 
 **unifiedApi** | **string**| Unified API | 
 **connection** | [**Connection**](Connection.md)| Fields that need to be persisted on the resource | 

### Return type

[**CreateConnectionResponse**](CreateConnectionResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connection created |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsall"></a>
# **ConnectionsAll**
> GetConnectionsResponse ConnectionsAll (string xApideckConsumerId, string xApideckAppId, string api = null, bool? configured = null)

Get all connections

This endpoint includes all the configured integrations and contains the required assets to build an integrations page where your users can install integrations. OAuth2 supported integrations will contain authorize and revoke links to handle the authentication flows. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectionsApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var api = crm;  // string | Scope results to Unified API (optional) 
            var configured = true;  // bool? | Scopes results to connections that have been configured or not (optional) 

            try
            {
                // Get all connections
                GetConnectionsResponse result = apiInstance.ConnectionsAll(xApideckConsumerId, xApideckAppId, api, configured);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsAll: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **api** | **string**| Scope results to Unified API | [optional] 
 **configured** | **bool?**| Scopes results to connections that have been configured or not | [optional] 

### Return type

[**GetConnectionsResponse**](GetConnectionsResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connections |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsauthorize"></a>
# **ConnectionsAuthorize**
> UnexpectedErrorResponse ConnectionsAuthorize (string serviceId, string applicationId, string state, string redirectUri, List<string> scope = null)

Authorize

__In most cases the authorize link is provided in the ``/connections`` endpoint. Normally you don't need to manually generate these links.__  Use this endpoint to authenticate a user with a connector. It will return a 302 redirect to the downstream connector endpoints.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete Authorization Code Grant Type Flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsAuthorizeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            var apiInstance = new ConnectionsApi(config);
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var applicationId = "applicationId_example";  // string | Application ID of the resource to return
            var state = eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjb25zdW1lcl9pZCI6InRlc3RfdXNlcl9pZCIsInVuaWZpZWRfYXBpIjoiZGVmYXVsdCIsInNlcnZpY2VfaWQiOiJ0ZWFtbGVhZGVyIiwiYXBwbGljYXRpb25faWQiOiIxMTExIiwiaWF0IjoxNjIyMTI2Nzg3fQ.97_pn1UAXc7mctXBdr15czUNO1jjdQ9sJUOIE_Myzbk;  // string | An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.
            var redirectUri = http://example.com/integrations;  // string | URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.
            var scope = new List<string>(); // List<string> | One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector's documentation for the available scopes. (optional) 

            try
            {
                // Authorize
                UnexpectedErrorResponse result = apiInstance.ConnectionsAuthorize(serviceId, applicationId, state, redirectUri, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsAuthorize: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serviceId** | **string**| Service ID of the resource to return | 
 **applicationId** | **string**| Application ID of the resource to return | 
 **state** | **string**| An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks. | 
 **redirectUri** | **string**| URL to redirect back to after authorization. When left empty the default configured redirect uri will be used. | 
 **scope** | [**List&lt;string&gt;**](string.md)| One or more OAuth scopes to request from the connector. OAuth scopes control the set of resources and operations that are allowed after authorization. Refer to the connector&#39;s documentation for the available scopes. | [optional] 

### Return type

[**UnexpectedErrorResponse**](UnexpectedErrorResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **301** | redirect |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionscallback"></a>
# **ConnectionsCallback**
> UnexpectedErrorResponse ConnectionsCallback (string state, string code)

Callback

This endpoint gets called after the triggering the authorize flow.  Callback links need a state and code parameter to verify the validity of the request. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsCallbackExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            var apiInstance = new ConnectionsApi(config);
            var state = eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjb25zdW1lcl9pZCI6InRlc3RfdXNlcl9pZCIsInVuaWZpZWRfYXBpIjoiZGVmYXVsdCIsInNlcnZpY2VfaWQiOiJ0ZWFtbGVhZGVyIiwiYXBwbGljYXRpb25faWQiOiIxMTExIiwiaWF0IjoxNjIyMTI2Nzg3fQ.97_pn1UAXc7mctXBdr15czUNO1jjdQ9sJUOIE_Myzbk;  // string | An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.
            var code = g0ZGZmNjVmOWI;  // string | An authorization code from the connector which Apideck Vault will later exchange for an access token.

            try
            {
                // Callback
                UnexpectedErrorResponse result = apiInstance.ConnectionsCallback(state, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsCallback: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **state** | **string**| An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks. | 
 **code** | **string**| An authorization code from the connector which Apideck Vault will later exchange for an access token. | 

### Return type

[**UnexpectedErrorResponse**](UnexpectedErrorResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **301** | callback |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsdelete"></a>
# **ConnectionsDelete**
> void ConnectionsDelete (string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi)

Deletes a connection

Deletes a connection

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectionsApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var unifiedApi = crm;  // string | Unified API

            try
            {
                // Deletes a connection
                apiInstance.ConnectionsDelete(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsDelete: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **serviceId** | **string**| Service ID of the resource to return | 
 **unifiedApi** | **string**| Unified API | 

### Return type

void (empty response body)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Resource deleted |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsgetsettings"></a>
# **ConnectionsGetSettings**
> GetConnectionResponse ConnectionsGetSettings (string xApideckConsumerId, string xApideckAppId, string unifiedApi, string serviceId, string resource)

Get resource settings

This endpoint returns custom settings and their defaults required by connection for a given resource. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsGetSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectionsApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var unifiedApi = crm;  // string | Unified API
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var resource = leads;  // string | Resource Name

            try
            {
                // Get resource settings
                GetConnectionResponse result = apiInstance.ConnectionsGetSettings(xApideckConsumerId, xApideckAppId, unifiedApi, serviceId, resource);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsGetSettings: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **unifiedApi** | **string**| Unified API | 
 **serviceId** | **string**| Service ID of the resource to return | 
 **resource** | **string**| Resource Name | 

### Return type

[**GetConnectionResponse**](GetConnectionResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connection |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsone"></a>
# **ConnectionsOne**
> GetConnectionResponse ConnectionsOne (string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi)

Get connection

Get a connection

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectionsApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var unifiedApi = crm;  // string | Unified API

            try
            {
                // Get connection
                GetConnectionResponse result = apiInstance.ConnectionsOne(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsOne: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **serviceId** | **string**| Service ID of the resource to return | 
 **unifiedApi** | **string**| Unified API | 

### Return type

[**GetConnectionResponse**](GetConnectionResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connection |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsrevoke"></a>
# **ConnectionsRevoke**
> UnexpectedErrorResponse ConnectionsRevoke (string serviceId, string applicationId, string state, string redirectUri)

Revoke

__In most cases the authorize link is provided in the ``/connections`` endpoint. Normally you don't need to manually generate these links.__  Use this endpoint to revoke an existing OAuth connector.  Auth links will have a state parameter included to verify the validity of the request. This is the url your users will use to activate OAuth supported integration providers.  Vault handles the complete revoke flow for you and will redirect you to the dynamic redirect uri you have appended to the url in case this is missing the default redirect uri you have configured for your Unify application. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsRevokeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            var apiInstance = new ConnectionsApi(config);
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var applicationId = "applicationId_example";  // string | Application ID of the resource to return
            var state = eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjb25zdW1lcl9pZCI6InRlc3RfdXNlcl9pZCIsInVuaWZpZWRfYXBpIjoiZGVmYXVsdCIsInNlcnZpY2VfaWQiOiJ0ZWFtbGVhZGVyIiwiYXBwbGljYXRpb25faWQiOiIxMTExIiwiaWF0IjoxNjIyMTI2Nzg3fQ.97_pn1UAXc7mctXBdr15czUNO1jjdQ9sJUOIE_Myzbk;  // string | An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks.
            var redirectUri = http://example.com/integrations;  // string | URL to redirect back to after authorization. When left empty the default configured redirect uri will be used.

            try
            {
                // Revoke
                UnexpectedErrorResponse result = apiInstance.ConnectionsRevoke(serviceId, applicationId, state, redirectUri);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsRevoke: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serviceId** | **string**| Service ID of the resource to return | 
 **applicationId** | **string**| Application ID of the resource to return | 
 **state** | **string**| An opaque value the applications adds to the initial request that the authorization server includes when redirecting the back to the application. This value must be used by the application to prevent CSRF attacks. | 
 **redirectUri** | **string**| URL to redirect back to after authorization. When left empty the default configured redirect uri will be used. | 

### Return type

[**UnexpectedErrorResponse**](UnexpectedErrorResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **301** | redirect |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsupdate"></a>
# **ConnectionsUpdate**
> UpdateConnectionResponse ConnectionsUpdate (string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, Connection connection)

Update connection

Update a connection

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectionsApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var unifiedApi = crm;  // string | Unified API
            var connection = new Connection(); // Connection | Fields that need to be updated on the resource

            try
            {
                // Update connection
                UpdateConnectionResponse result = apiInstance.ConnectionsUpdate(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, connection);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsUpdate: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **serviceId** | **string**| Service ID of the resource to return | 
 **unifiedApi** | **string**| Unified API | 
 **connection** | [**Connection**](Connection.md)| Fields that need to be updated on the resource | 

### Return type

[**UpdateConnectionResponse**](UpdateConnectionResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connection updated |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectionsupdatesettings"></a>
# **ConnectionsUpdateSettings**
> UpdateConnectionResponse ConnectionsUpdateSettings (string xApideckConsumerId, string xApideckAppId, string serviceId, string unifiedApi, string resource, Connection connection)

Update settings

Update default values for a connection's resource settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConnectionsUpdateSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectionsApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var serviceId = pipedrive;  // string | Service ID of the resource to return
            var unifiedApi = crm;  // string | Unified API
            var resource = leads;  // string | Resource Name
            var connection = new Connection(); // Connection | Fields that need to be updated on the resource

            try
            {
                // Update settings
                UpdateConnectionResponse result = apiInstance.ConnectionsUpdateSettings(xApideckConsumerId, xApideckAppId, serviceId, unifiedApi, resource, connection);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectionsApi.ConnectionsUpdateSettings: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **serviceId** | **string**| Service ID of the resource to return | 
 **unifiedApi** | **string**| Unified API | 
 **resource** | **string**| Resource Name | 
 **connection** | [**Connection**](Connection.md)| Fields that need to be updated on the resource | 

### Return type

[**UpdateConnectionResponse**](UpdateConnectionResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connection updated |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

