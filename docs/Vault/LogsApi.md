# Apideck.Vault.Api.LogsApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**LogsAll**](LogsApi.md#logsall) | **GET** /vault/logs | Get all consumer request logs


<a name="logsall"></a>
# **LogsAll**
> GetLogsResponse LogsAll (string xApideckAppId, string xApideckConsumerId, LogsFilter filter = null, string cursor = null, int? limit = null)

Get all consumer request logs

This endpoint includes all consumer request logs. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Vault.Api;
using Apideck.Vault.Client;
using Apideck.Vault.Model;

namespace Example
{
    public class LogsAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new LogsApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var filter = new LogsFilter(); // LogsFilter | Filter results (optional) 
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)

            try
            {
                // Get all consumer request logs
                GetLogsResponse result = apiInstance.LogsAll(xApideckAppId, xApideckConsumerId, filter, cursor, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogsApi.LogsAll: " + e.Message );
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
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **filter** | [**LogsFilter**](LogsFilter.md)| Filter results | [optional] 
 **cursor** | **string**| Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. | [optional] 
 **limit** | **int?**| Number of records to return | [optional] [default to 20]

### Return type

[**GetLogsResponse**](GetLogsResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Logs |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

