# Apideck.Connector.Api.ConnectorsApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ConnectorsAll**](ConnectorsApi.md#connectorsall) | **GET** /connector/connectors | List Connectors
[**ConnectorsOne**](ConnectorsApi.md#connectorsone) | **GET** /connector/connectors/{id} | Get Connector


<a name="connectorsall"></a>
# **ConnectorsAll**
> GetConnectorsResponse ConnectorsAll (string xApideckAppId, string cursor = null, int? limit = null, ConnectorsFilter filter = null)

List Connectors

List Connectors

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Connector.Api;
using Apideck.Connector.Client;
using Apideck.Connector.Model;

namespace Example
{
    public class ConnectorsAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectorsApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)
            var filter = new ConnectorsFilter(); // ConnectorsFilter | Apply filters (optional) 

            try
            {
                // List Connectors
                GetConnectorsResponse result = apiInstance.ConnectorsAll(xApideckAppId, cursor, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectorsApi.ConnectorsAll: " + e.Message );
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
 **filter** | [**ConnectorsFilter**](ConnectorsFilter.md)| Apply filters | [optional] 

### Return type

[**GetConnectorsResponse**](GetConnectorsResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connectors |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="connectorsone"></a>
# **ConnectorsOne**
> GetConnectorResponse ConnectorsOne (string xApideckAppId, string id)

Get Connector

Get Connector

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Connector.Api;
using Apideck.Connector.Client;
using Apideck.Connector.Model;

namespace Example
{
    public class ConnectorsOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConnectorsApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var id = "id_example";  // string | ID of the record you are acting upon.

            try
            {
                // Get Connector
                GetConnectorResponse result = apiInstance.ConnectorsOne(xApideckAppId, id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConnectorsApi.ConnectorsOne: " + e.Message );
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

[**GetConnectorResponse**](GetConnectorResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Connectors |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

