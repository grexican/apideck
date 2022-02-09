# Apideck.Crm.Api.NotesApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**NotesAdd**](NotesApi.md#notesadd) | **POST** /crm/notes | Create note
[**NotesAll**](NotesApi.md#notesall) | **GET** /crm/notes | List notes
[**NotesDelete**](NotesApi.md#notesdelete) | **DELETE** /crm/notes/{id} | Delete note
[**NotesOne**](NotesApi.md#notesone) | **GET** /crm/notes/{id} | Get note
[**NotesUpdate**](NotesApi.md#notesupdate) | **PATCH** /crm/notes/{id} | Update note


<a name="notesadd"></a>
# **NotesAdd**
> CreateNoteResponse NotesAdd (string xApideckConsumerId, string xApideckAppId, Note note, bool? raw = null, string xApideckServiceId = null)

Create note

Create note

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class NotesAddExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NotesApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var note = new Note(); // Note | 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Create note
                CreateNoteResponse result = apiInstance.NotesAdd(xApideckConsumerId, xApideckAppId, note, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NotesApi.NotesAdd: " + e.Message );
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
 **note** | [**Note**](Note.md)|  | 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 

### Return type

[**CreateNoteResponse**](CreateNoteResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Note created |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="notesall"></a>
# **NotesAll**
> GetNotesResponse NotesAll (string xApideckConsumerId, string xApideckAppId, bool? raw = null, string xApideckServiceId = null, string cursor = null, int? limit = null)

List notes

List notes

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class NotesAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NotesApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)

            try
            {
                // List notes
                GetNotesResponse result = apiInstance.NotesAll(xApideckConsumerId, xApideckAppId, raw, xApideckServiceId, cursor, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NotesApi.NotesAll: " + e.Message );
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

### Return type

[**GetNotesResponse**](GetNotesResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Notes |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="notesdelete"></a>
# **NotesDelete**
> DeleteNoteResponse NotesDelete (string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = null, bool? raw = null)

Delete note

Delete note

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class NotesDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NotesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)

            try
            {
                // Delete note
                DeleteNoteResponse result = apiInstance.NotesDelete(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NotesApi.NotesDelete: " + e.Message );
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
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]

### Return type

[**DeleteNoteResponse**](DeleteNoteResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Note deleted |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="notesone"></a>
# **NotesOne**
> GetNoteResponse NotesOne (string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = null, bool? raw = null)

Get note

Get note

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class NotesOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NotesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)

            try
            {
                // Get note
                GetNoteResponse result = apiInstance.NotesOne(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NotesApi.NotesOne: " + e.Message );
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
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]

### Return type

[**GetNoteResponse**](GetNoteResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Note |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="notesupdate"></a>
# **NotesUpdate**
> UpdateNoteResponse NotesUpdate (string id, string xApideckConsumerId, string xApideckAppId, Note note, string xApideckServiceId = null, bool? raw = null)

Update note

Update note

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Crm.Api;
using Apideck.Crm.Client;
using Apideck.Crm.Model;

namespace Example
{
    public class NotesUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new NotesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var note = new Note(); // Note | 
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)

            try
            {
                // Update note
                UpdateNoteResponse result = apiInstance.NotesUpdate(id, xApideckConsumerId, xApideckAppId, note, xApideckServiceId, raw);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NotesApi.NotesUpdate: " + e.Message );
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
 **note** | [**Note**](Note.md)|  | 
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]

### Return type

[**UpdateNoteResponse**](UpdateNoteResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Note updated |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

