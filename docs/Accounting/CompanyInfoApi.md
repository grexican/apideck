# Apideck.Accounting.Api.CompanyInfoApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CompanyInfoOne**](CompanyInfoApi.md#companyinfoone) | **GET** /accounting/company-info | Get company info


<a name="companyinfoone"></a>
# **CompanyInfoOne**
> GetCompanyInfoResponse CompanyInfoOne (string xApideckConsumerId, string xApideckAppId, bool? raw = null, string xApideckServiceId = null)

Get company info

Get company info

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Accounting.Api;
using Apideck.Accounting.Client;
using Apideck.Accounting.Model;

namespace Example
{
    public class CompanyInfoOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new CompanyInfoApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Get company info
                GetCompanyInfoResponse result = apiInstance.CompanyInfoOne(xApideckConsumerId, xApideckAppId, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CompanyInfoApi.CompanyInfoOne: " + e.Message );
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
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 

### Return type

[**GetCompanyInfoResponse**](GetCompanyInfoResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | CompanyInfo |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

