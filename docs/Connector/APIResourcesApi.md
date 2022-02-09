# Apideck.Connector.Api.APIResourcesApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiResourceCoverageOne**](APIResourcesApi.md#apiresourcecoverageone) | **GET** /connector/apis/{id}/resources/{resource_id}/coverage | Get API Resource Coverage
[**ApiResourcesOne**](APIResourcesApi.md#apiresourcesone) | **GET** /connector/apis/{id}/resources/{resource_id} | Get API Resource


<a name="apiresourcecoverageone"></a>
# **ApiResourceCoverageOne**
> GetApiResourceCoverageResponse ApiResourceCoverageOne (string xApideckAppId, string id, string resourceId)

Get API Resource Coverage

Get API Resource Coverage

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Connector.Api;
using Apideck.Connector.Client;
using Apideck.Connector.Model;

namespace Example
{
    public class ApiResourceCoverageOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new APIResourcesApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var id = "id_example";  // string | ID of the record you are acting upon.
            var resourceId = "resourceId_example";  // string | ID of the resource you are acting upon.

            try
            {
                // Get API Resource Coverage
                GetApiResourceCoverageResponse result = apiInstance.ApiResourceCoverageOne(xApideckAppId, id, resourceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling APIResourcesApi.ApiResourceCoverageOne: " + e.Message );
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
 **resourceId** | **string**| ID of the resource you are acting upon. | 

### Return type

[**GetApiResourceCoverageResponse**](GetApiResourceCoverageResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ApiResources |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiresourcesone"></a>
# **ApiResourcesOne**
> GetApiResourceResponse ApiResourcesOne (string xApideckAppId, string id, string resourceId)

Get API Resource

Get API Resource

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Connector.Api;
using Apideck.Connector.Client;
using Apideck.Connector.Model;

namespace Example
{
    public class ApiResourcesOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new APIResourcesApi(config);
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var id = "id_example";  // string | ID of the record you are acting upon.
            var resourceId = "resourceId_example";  // string | ID of the resource you are acting upon.

            try
            {
                // Get API Resource
                GetApiResourceResponse result = apiInstance.ApiResourcesOne(xApideckAppId, id, resourceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling APIResourcesApi.ApiResourcesOne: " + e.Message );
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
 **resourceId** | **string**| ID of the resource you are acting upon. | 

### Return type

[**GetApiResourceResponse**](GetApiResourceResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ApiResources |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

