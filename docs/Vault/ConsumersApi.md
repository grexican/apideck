# Apideck.Vault.Api.ConsumersApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ConsumersAll**](ConsumersApi.md#consumersall) | **GET** /vault/consumers | Get all consumers
[**ConsumersOne**](ConsumersApi.md#consumersone) | **GET** /vault/consumers/{consumer_id} | Get consumer
[**ConsumersRequestCounts**](ConsumersApi.md#consumersrequestcounts) | **GET** /vault/consumers/{consumer_id}/stats | Consumer request counts


<a name="consumersall"></a>
# **ConsumersAll**
> GetConsumersResponse ConsumersAll (string xApideckAppId, string cursor = null, int? limit = null)

Get all consumers

This endpoint includes all application consumers, along with an aggregated count of requests made. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConsumersAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConsumersApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)

            try
            {
                // Get all consumers
                GetConsumersResponse result = apiInstance.ConsumersAll(xApideckAppId, cursor, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConsumersApi.ConsumersAll: " + e.Message );
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

[**GetConsumersResponse**](GetConsumersResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Consumers |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="consumersone"></a>
# **ConsumersOne**
> GetConsumerResponse ConsumersOne (string xApideckAppId, string consumerId)

Get consumer

Consumer detail including their aggregated counts with the connections they have authorized. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConsumersOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConsumersApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var consumerId = test_user_id;  // string | ID of the consumer to return

            try
            {
                // Get consumer
                GetConsumerResponse result = apiInstance.ConsumersOne(xApideckAppId, consumerId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConsumersApi.ConsumersOne: " + e.Message );
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
 **consumerId** | **string**| ID of the consumer to return | 

### Return type

[**GetConsumerResponse**](GetConsumerResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Consumer |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="consumersrequestcounts"></a>
# **ConsumersRequestCounts**
> ConsumerRequestCountsInDateRangeResponse ConsumersRequestCounts (string xApideckAppId, string consumerId, string startDatetime, string endDatetime)

Consumer request counts

Get consumer request counts within a given datetime range. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class ConsumersRequestCountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConsumersApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var consumerId = test_user_id;  // string | ID of the consumer to return
            var startDatetime = 2021-05-01T12:00:00.000Z;  // string | Scopes results to requests that happened after datetime
            var endDatetime = 2021-05-30T12:00:00.000Z;  // string | Scopes results to requests that happened before datetime

            try
            {
                // Consumer request counts
                ConsumerRequestCountsInDateRangeResponse result = apiInstance.ConsumersRequestCounts(xApideckAppId, consumerId, startDatetime, endDatetime);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConsumersApi.ConsumersRequestCounts: " + e.Message );
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
 **consumerId** | **string**| ID of the consumer to return | 
 **startDatetime** | **string**| Scopes results to requests that happened after datetime | 
 **endDatetime** | **string**| Scopes results to requests that happened before datetime | 

### Return type

[**ConsumerRequestCountsInDateRangeResponse**](ConsumerRequestCountsInDateRangeResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Consumers Request Counts within Date Range |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

