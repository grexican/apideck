# Apideck.Webhook.Api.WebhooksApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**EventLogsAll**](WebhooksApi.md#eventlogsall) | **GET** /webhook/logs | List event logs
[**WebhooksAdd**](WebhooksApi.md#webhooksadd) | **POST** /webhook/webhooks | Create webhook
[**WebhooksAll**](WebhooksApi.md#webhooksall) | **GET** /webhook/webhooks | List webhooks
[**WebhooksDelete**](WebhooksApi.md#webhooksdelete) | **DELETE** /webhook/webhooks/{id} | Delete webhook
[**WebhooksExecute**](WebhooksApi.md#webhooksexecute) | **POST** /webhook/webhooks/{id}/execute/{serviceId} | Execute a webhook
[**WebhooksOne**](WebhooksApi.md#webhooksone) | **GET** /webhook/webhooks/{id} | Get webhook
[**WebhooksUpdate**](WebhooksApi.md#webhooksupdate) | **PATCH** /webhook/webhooks/{id} | Update webhook


<a name="eventlogsall"></a>
# **EventLogsAll**
> GetWebhookEventLogsResponse EventLogsAll (string xApideckAppId, string cursor = null, int? limit = null, WebhookEventLogsFilter filter = null)

List event logs

List event logs

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Webhook.Api;
using Apideck.Webhook.Client;
using Apideck.Webhook.Model;

namespace Example
{
    public class EventLogsAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new WebhooksApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)
            var filter = new WebhookEventLogsFilter(); // WebhookEventLogsFilter | Filter results (optional) 

            try
            {
                // List event logs
                GetWebhookEventLogsResponse result = apiInstance.EventLogsAll(xApideckAppId, cursor, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.EventLogsAll: " + e.Message );
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
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **cursor** | **string**| Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. | [optional] 
 **limit** | **int?**| Number of records to return | [optional] [default to 20]
 **filter** | [**WebhookEventLogsFilter**](WebhookEventLogsFilter.md)| Filter results | [optional] 

### Return type

[**GetWebhookEventLogsResponse**](GetWebhookEventLogsResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | EventLogs |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="webhooksadd"></a>
# **WebhooksAdd**
> CreateWebhookResponse WebhooksAdd (string xApideckAppId, CreateWebhookRequest createWebhookRequest)

Create webhook

Create webhook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Webhook.Api;
using Apideck.Webhook.Client;
using Apideck.Webhook.Model;

namespace Example
{
    public class WebhooksAddExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new WebhooksApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var createWebhookRequest = new CreateWebhookRequest(); // CreateWebhookRequest | 

            try
            {
                // Create webhook
                CreateWebhookResponse result = apiInstance.WebhooksAdd(xApideckAppId, createWebhookRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.WebhooksAdd: " + e.Message );
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
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **createWebhookRequest** | [**CreateWebhookRequest**](CreateWebhookRequest.md)|  | 

### Return type

[**CreateWebhookResponse**](CreateWebhookResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Webhooks |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="webhooksall"></a>
# **WebhooksAll**
> GetWebhooksResponse WebhooksAll (string xApideckAppId, string cursor = null, int? limit = null)

List webhooks

List webhooks

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Webhook.Api;
using Apideck.Webhook.Client;
using Apideck.Webhook.Model;

namespace Example
{
    public class WebhooksAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new WebhooksApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)

            try
            {
                // List webhooks
                GetWebhooksResponse result = apiInstance.WebhooksAll(xApideckAppId, cursor, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.WebhooksAll: " + e.Message );
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
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **cursor** | **string**| Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. | [optional] 
 **limit** | **int?**| Number of records to return | [optional] [default to 20]

### Return type

[**GetWebhooksResponse**](GetWebhooksResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Webhooks |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="webhooksdelete"></a>
# **WebhooksDelete**
> DeleteWebhookResponse WebhooksDelete (string id, string xApideckAppId)

Delete webhook

Delete webhook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Webhook.Api;
using Apideck.Webhook.Client;
using Apideck.Webhook.Model;

namespace Example
{
    public class WebhooksDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new WebhooksApi(config);
            var id = "id_example";  // string | JWT Webhook token that represents the unifiedApi and applicationId associated to the event source.
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application

            try
            {
                // Delete webhook
                DeleteWebhookResponse result = apiInstance.WebhooksDelete(id, xApideckAppId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.WebhooksDelete: " + e.Message );
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
 **id** | **string**| JWT Webhook token that represents the unifiedApi and applicationId associated to the event source. | 
 **xApideckAppId** | **string**| The ID of your Unify application | 

### Return type

[**DeleteWebhookResponse**](DeleteWebhookResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Webhooks |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="webhooksexecute"></a>
# **WebhooksExecute**
> ExecuteWebhookResponse WebhooksExecute (string id, string serviceId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE)

Execute a webhook

Execute a webhook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Webhook.Api;
using Apideck.Webhook.Client;
using Apideck.Webhook.Model;

namespace Example
{
    public class WebhooksExecuteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new WebhooksApi(config);
            var id = "id_example";  // string | JWT Webhook token that represents the unifiedApi and applicationId associated to the event source.
            var serviceId = "serviceId_example";  // string | Service provider ID.
            var UNKNOWN_BASE_TYPE = new UNKNOWN_BASE_TYPE(); // UNKNOWN_BASE_TYPE | 

            try
            {
                // Execute a webhook
                ExecuteWebhookResponse result = apiInstance.WebhooksExecute(id, serviceId, UNKNOWN_BASE_TYPE);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.WebhooksExecute: " + e.Message );
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
 **id** | **string**| JWT Webhook token that represents the unifiedApi and applicationId associated to the event source. | 
 **serviceId** | **string**| Service provider ID. | 
 **UNKNOWN_BASE_TYPE** | [**UNKNOWN_BASE_TYPE**](UNKNOWN_BASE_TYPE.md)|  | 

### Return type

[**ExecuteWebhookResponse**](ExecuteWebhookResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Execute Webhook |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="webhooksone"></a>
# **WebhooksOne**
> GetWebhookResponse WebhooksOne (string id, string xApideckAppId)

Get webhook

Get webhook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Webhook.Api;
using Apideck.Webhook.Client;
using Apideck.Webhook.Model;

namespace Example
{
    public class WebhooksOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new WebhooksApi(config);
            var id = "id_example";  // string | JWT Webhook token that represents the unifiedApi and applicationId associated to the event source.
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application

            try
            {
                // Get webhook
                GetWebhookResponse result = apiInstance.WebhooksOne(id, xApideckAppId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.WebhooksOne: " + e.Message );
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
 **id** | **string**| JWT Webhook token that represents the unifiedApi and applicationId associated to the event source. | 
 **xApideckAppId** | **string**| The ID of your Unify application | 

### Return type

[**GetWebhookResponse**](GetWebhookResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Webhooks |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="webhooksupdate"></a>
# **WebhooksUpdate**
> UpdateWebhookResponse WebhooksUpdate (string id, string xApideckAppId, UpdateWebhookRequest updateWebhookRequest)

Update webhook

Update webhook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Webhook.Api;
using Apideck.Webhook.Client;
using Apideck.Webhook.Model;

namespace Example
{
    public class WebhooksUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new WebhooksApi(config);
            var id = "id_example";  // string | JWT Webhook token that represents the unifiedApi and applicationId associated to the event source.
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var updateWebhookRequest = new UpdateWebhookRequest(); // UpdateWebhookRequest | 

            try
            {
                // Update webhook
                UpdateWebhookResponse result = apiInstance.WebhooksUpdate(id, xApideckAppId, updateWebhookRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.WebhooksUpdate: " + e.Message );
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
 **id** | **string**| JWT Webhook token that represents the unifiedApi and applicationId associated to the event source. | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **updateWebhookRequest** | [**UpdateWebhookRequest**](UpdateWebhookRequest.md)|  | 

### Return type

[**UpdateWebhookResponse**](UpdateWebhookResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Webhooks |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

