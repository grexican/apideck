# Apideck.Proxy.Api.ExecuteApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteProxy**](ExecuteApi.md#deleteproxy) | **DELETE** /proxy | DELETE
[**GetProxy**](ExecuteApi.md#getproxy) | **GET** /proxy | GET
[**PatchProxy**](ExecuteApi.md#patchproxy) | **PATCH** /proxy | PATCH
[**PostProxy**](ExecuteApi.md#postproxy) | **POST** /proxy | POST
[**PutProxy**](ExecuteApi.md#putproxy) | **PUT** /proxy | PUT


<a name="deleteproxy"></a>
# **DeleteProxy**
> Object DeleteProxy (string xApideckConsumerId, string xApideckAppId, string xApideckServiceId, string xApideckDownstreamUrl, string xApideckDownstreamAuthorization = null)

DELETE

Proxies a downstream DELETE request to a service and injects the necessary credentials into a request stored in Vault. This allows you to have an additional security layer and logging without needing to rely on Unify for normalization. **Note**: Vault will proxy all data to the downstream URL and method/verb in the headers. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Proxy.Api;
using Apideck.Proxy.Client;
using Apideck.Proxy.Model;

namespace Example
{
    public class DeleteProxyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

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
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ExecuteApi.DeleteProxy: " + e.Message );
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
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | 
 **xApideckDownstreamUrl** | **string**| Downstream URL | 
 **xApideckDownstreamAuthorization** | **string**| Downstream authorization header. This will skip the Vault token injection. | [optional] 

### Return type

**Object**

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **401** | Unauthorized |  -  |
| **0** | Proxy error |  * x-apideck-downstream-error -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getproxy"></a>
# **GetProxy**
> Object GetProxy (string xApideckConsumerId, string xApideckAppId, string xApideckServiceId, string xApideckDownstreamUrl, string xApideckDownstreamAuthorization = null)

GET

Proxies a downstream GET request to a service and injects the necessary credentials into a request stored in Vault. This allows you to have an additional security layer and logging without needing to rely on Unify for normalization. **Note**: Vault will proxy all data to the downstream URL and method/verb in the headers. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Proxy.Api;
using Apideck.Proxy.Client;
using Apideck.Proxy.Model;

namespace Example
{
    public class GetProxyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ExecuteApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = close;  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API.
            var xApideckDownstreamUrl = https://api.close.com/api/v1/lead;  // string | Downstream URL
            var xApideckDownstreamAuthorization = Bearer XXXXXXXXXXXXXXXXX;  // string | Downstream authorization header. This will skip the Vault token injection. (optional) 

            try
            {
                // GET
                Object result = apiInstance.GetProxy(xApideckConsumerId, xApideckAppId, xApideckServiceId, xApideckDownstreamUrl, xApideckDownstreamAuthorization);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ExecuteApi.GetProxy: " + e.Message );
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
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | 
 **xApideckDownstreamUrl** | **string**| Downstream URL | 
 **xApideckDownstreamAuthorization** | **string**| Downstream authorization header. This will skip the Vault token injection. | [optional] 

### Return type

**Object**

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **401** | Unauthorized |  -  |
| **0** | Proxy error |  * x-apideck-downstream-error -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="patchproxy"></a>
# **PatchProxy**
> Object PatchProxy (string xApideckConsumerId, string xApideckAppId, string xApideckServiceId, string xApideckDownstreamUrl, string xApideckDownstreamAuthorization = null, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = null)

PATCH

Proxies a downstream PATCH request to a service and injects the necessary credentials into a request stored in Vault. This allows you to have an additional security layer and logging without needing to rely on Unify for normalization. **Note**: Vault will proxy all data to the downstream URL and method/verb in the headers. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Proxy.Api;
using Apideck.Proxy.Client;
using Apideck.Proxy.Model;

namespace Example
{
    public class PatchProxyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ExecuteApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = close;  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API.
            var xApideckDownstreamUrl = https://api.close.com/api/v1/lead;  // string | Downstream URL
            var xApideckDownstreamAuthorization = Bearer XXXXXXXXXXXXXXXXX;  // string | Downstream authorization header. This will skip the Vault token injection. (optional) 
            var UNKNOWN_BASE_TYPE = new UNKNOWN_BASE_TYPE(); // UNKNOWN_BASE_TYPE | Depending on the verb/method of the request this will contain the request body you want to POST/PATCH/PUT. (optional) 

            try
            {
                // PATCH
                Object result = apiInstance.PatchProxy(xApideckConsumerId, xApideckAppId, xApideckServiceId, xApideckDownstreamUrl, xApideckDownstreamAuthorization, UNKNOWN_BASE_TYPE);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ExecuteApi.PatchProxy: " + e.Message );
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
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | 
 **xApideckDownstreamUrl** | **string**| Downstream URL | 
 **xApideckDownstreamAuthorization** | **string**| Downstream authorization header. This will skip the Vault token injection. | [optional] 
 **UNKNOWN_BASE_TYPE** | [**UNKNOWN_BASE_TYPE**](UNKNOWN_BASE_TYPE.md)| Depending on the verb/method of the request this will contain the request body you want to POST/PATCH/PUT. | [optional] 

### Return type

**Object**

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **401** | Unauthorized |  -  |
| **0** | Proxy error |  * x-apideck-downstream-error -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postproxy"></a>
# **PostProxy**
> Object PostProxy (string xApideckConsumerId, string xApideckAppId, string xApideckServiceId, string xApideckDownstreamUrl, string xApideckDownstreamAuthorization = null, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = null)

POST

Proxies a downstream POST request to a service and injects the necessary credentials into a request stored in Vault. This allows you to have an additional security layer and logging without needing to rely on Unify for normalization. **Note**: Vault will proxy all data to the downstream URL and method/verb in the headers. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Proxy.Api;
using Apideck.Proxy.Client;
using Apideck.Proxy.Model;

namespace Example
{
    public class PostProxyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ExecuteApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = close;  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API.
            var xApideckDownstreamUrl = https://api.close.com/api/v1/lead;  // string | Downstream URL
            var xApideckDownstreamAuthorization = Bearer XXXXXXXXXXXXXXXXX;  // string | Downstream authorization header. This will skip the Vault token injection. (optional) 
            var UNKNOWN_BASE_TYPE = new UNKNOWN_BASE_TYPE(); // UNKNOWN_BASE_TYPE | Depending on the verb/method of the request this will contain the request body you want to POST/PATCH/PUT. (optional) 

            try
            {
                // POST
                Object result = apiInstance.PostProxy(xApideckConsumerId, xApideckAppId, xApideckServiceId, xApideckDownstreamUrl, xApideckDownstreamAuthorization, UNKNOWN_BASE_TYPE);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ExecuteApi.PostProxy: " + e.Message );
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
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | 
 **xApideckDownstreamUrl** | **string**| Downstream URL | 
 **xApideckDownstreamAuthorization** | **string**| Downstream authorization header. This will skip the Vault token injection. | [optional] 
 **UNKNOWN_BASE_TYPE** | [**UNKNOWN_BASE_TYPE**](UNKNOWN_BASE_TYPE.md)| Depending on the verb/method of the request this will contain the request body you want to POST/PATCH/PUT. | [optional] 

### Return type

**Object**

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **401** | Unauthorized |  -  |
| **0** | Proxy error |  * x-apideck-downstream-error -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putproxy"></a>
# **PutProxy**
> Object PutProxy (string xApideckConsumerId, string xApideckAppId, string xApideckServiceId, string xApideckDownstreamUrl, string xApideckDownstreamAuthorization = null, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = null)

PUT

Proxies a downstream PUT request to a service and injects the necessary credentials into a request stored in Vault. This allows you to have an additional security layer and logging without needing to rely on Unify for normalization. **Note**: Vault will proxy all data to the downstream URL and method/verb in the headers. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Proxy.Api;
using Apideck.Proxy.Client;
using Apideck.Proxy.Model;

namespace Example
{
    public class PutProxyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ExecuteApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = close;  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API.
            var xApideckDownstreamUrl = https://api.close.com/api/v1/lead;  // string | Downstream URL
            var xApideckDownstreamAuthorization = Bearer XXXXXXXXXXXXXXXXX;  // string | Downstream authorization header. This will skip the Vault token injection. (optional) 
            var UNKNOWN_BASE_TYPE = new UNKNOWN_BASE_TYPE(); // UNKNOWN_BASE_TYPE | Depending on the verb/method of the request this will contain the request body you want to POST/PATCH/PUT. (optional) 

            try
            {
                // PUT
                Object result = apiInstance.PutProxy(xApideckConsumerId, xApideckAppId, xApideckServiceId, xApideckDownstreamUrl, xApideckDownstreamAuthorization, UNKNOWN_BASE_TYPE);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ExecuteApi.PutProxy: " + e.Message );
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
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | 
 **xApideckDownstreamUrl** | **string**| Downstream URL | 
 **xApideckDownstreamAuthorization** | **string**| Downstream authorization header. This will skip the Vault token injection. | [optional] 
 **UNKNOWN_BASE_TYPE** | [**UNKNOWN_BASE_TYPE**](UNKNOWN_BASE_TYPE.md)| Depending on the verb/method of the request this will contain the request body you want to POST/PATCH/PUT. | [optional] 

### Return type

**Object**

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **401** | Unauthorized |  -  |
| **0** | Proxy error |  * x-apideck-downstream-error -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

