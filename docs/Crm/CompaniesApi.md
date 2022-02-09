# Apideck.Crm.Api.CompaniesApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CompaniesAdd**](CompaniesApi.md#companiesadd) | **POST** /crm/companies | Create company
[**CompaniesAll**](CompaniesApi.md#companiesall) | **GET** /crm/companies | List companies
[**CompaniesDelete**](CompaniesApi.md#companiesdelete) | **DELETE** /crm/companies/{id} | Delete company
[**CompaniesOne**](CompaniesApi.md#companiesone) | **GET** /crm/companies/{id} | Get company
[**CompaniesUpdate**](CompaniesApi.md#companiesupdate) | **PATCH** /crm/companies/{id} | Update company


<a name="companiesadd"></a>
# **CompaniesAdd**
> CreateCompanyResponse CompaniesAdd (string xApideckConsumerId, string xApideckAppId, Company company, bool? raw = null, string xApideckServiceId = null)

Create company

Create company

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class CompaniesAddExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new CompaniesApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var company = new Company(); // Company | 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Create company
                CreateCompanyResponse result = apiInstance.CompaniesAdd(xApideckConsumerId, xApideckAppId, company, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CompaniesApi.CompaniesAdd: " + e.Message );
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
 **company** | [**Company**](Company.md)|  | 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 

### Return type

[**CreateCompanyResponse**](CreateCompanyResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Company created |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="companiesall"></a>
# **CompaniesAll**
> GetCompaniesResponse CompaniesAll (string xApideckConsumerId, string xApideckAppId, bool? raw = null, string xApideckServiceId = null, string cursor = null, int? limit = null, CompaniesFilter filter = null, CompaniesSort sort = null)

List companies

List companies

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class CompaniesAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new CompaniesApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)
            var filter = new CompaniesFilter(); // CompaniesFilter | Apply filters (beta) (optional) 
            var sort = new CompaniesSort(); // CompaniesSort | Apply sorting (beta) (optional) 

            try
            {
                // List companies
                GetCompaniesResponse result = apiInstance.CompaniesAll(xApideckConsumerId, xApideckAppId, raw, xApideckServiceId, cursor, limit, filter, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CompaniesApi.CompaniesAll: " + e.Message );
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
 **cursor** | **string**| Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. | [optional] 
 **limit** | **int?**| Number of records to return | [optional] [default to 20]
 **filter** | [**CompaniesFilter**](CompaniesFilter.md)| Apply filters (beta) | [optional] 
 **sort** | [**CompaniesSort**](CompaniesSort.md)| Apply sorting (beta) | [optional] 

### Return type

[**GetCompaniesResponse**](GetCompaniesResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Companies |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="companiesdelete"></a>
# **CompaniesDelete**
> DeleteCompanyResponse CompaniesDelete (string id, string xApideckConsumerId, string xApideckAppId, bool? raw = null, string xApideckServiceId = null)

Delete company

Delete company

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class CompaniesDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new CompaniesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Delete company
                DeleteCompanyResponse result = apiInstance.CompaniesDelete(id, xApideckConsumerId, xApideckAppId, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CompaniesApi.CompaniesDelete: " + e.Message );
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
 **id** | **string**| ID of the record you are acting upon. | 
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 

### Return type

[**DeleteCompanyResponse**](DeleteCompanyResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Company deleted |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="companiesone"></a>
# **CompaniesOne**
> GetCompanyResponse CompaniesOne (string id, string xApideckConsumerId, string xApideckAppId, bool? raw = null, string xApideckServiceId = null)

Get company

Get company

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class CompaniesOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new CompaniesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Get company
                GetCompanyResponse result = apiInstance.CompaniesOne(id, xApideckConsumerId, xApideckAppId, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CompaniesApi.CompaniesOne: " + e.Message );
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
 **id** | **string**| ID of the record you are acting upon. | 
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 

### Return type

[**GetCompanyResponse**](GetCompanyResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Company |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="companiesupdate"></a>
# **CompaniesUpdate**
> UpdateCompanyResponse CompaniesUpdate (string id, string xApideckConsumerId, string xApideckAppId, Company company, bool? raw = null, string xApideckServiceId = null)

Update company

Update company

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class CompaniesUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new CompaniesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var company = new Company(); // Company | 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Update company
                UpdateCompanyResponse result = apiInstance.CompaniesUpdate(id, xApideckConsumerId, xApideckAppId, company, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CompaniesApi.CompaniesUpdate: " + e.Message );
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
 **id** | **string**| ID of the record you are acting upon. | 
 **xApideckConsumerId** | **string**| ID of the consumer which you want to get or push data from | 
 **xApideckAppId** | **string**| The ID of your Unify application | 
 **company** | [**Company**](Company.md)|  | 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 

### Return type

[**UpdateCompanyResponse**](UpdateCompanyResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Company updated |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

