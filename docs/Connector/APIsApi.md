# Apideck.Connector.Api.APIsApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApisAll**](APIsApi.md#apisall) | **GET** /connector/apis | List APIs
[**ApisOne**](APIsApi.md#apisone) | **GET** /connector/apis/{id} | Get API


<a name="apisall"></a>
# **ApisAll**
> GetApisResponse ApisAll (string xApideckAppId, string cursor = null, int? limit = null, ApisFilter filter = null)

List APIs

List APIs

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Connector.Api;
using Apideck.Connector.Client;
using Apideck.Connector.Model;

namespace Example
{
    public class ApisAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new APIsApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)
            var filter = new ApisFilter(); // ApisFilter | Apply filters (optional) 

            try
            {
                // List APIs
                GetApisResponse result = apiInstance.ApisAll(xApideckAppId, cursor, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling APIsApi.ApisAll: " + e.Message );
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
 **filter** | [**ApisFilter**](ApisFilter.md)| Apply filters | [optional] 

### Return type

[**GetApisResponse**](GetApisResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Apis |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apisone"></a>
# **ApisOne**
> GetApiResponse ApisOne (string xApideckAppId, string id)

Get API

Get API

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Connector.Api;
using Apideck.Connector.Client;
using Apideck.Connector.Model;

namespace Example
{
    public class ApisOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new APIsApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var id = "id_example";  // string | ID of the record you are acting upon.

            try
            {
                // Get API
                GetApiResponse result = apiInstance.ApisOne(xApideckAppId, id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling APIsApi.ApisOne: " + e.Message );
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
 **id** | **string**| ID of the record you are acting upon. | 

### Return type

[**GetApiResponse**](GetApiResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Apis |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

