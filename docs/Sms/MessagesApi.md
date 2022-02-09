# Apideck.Sms.Api.MessagesApi

All URIs are relative to *https://unify.apideck.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**MessagesAdd**](MessagesApi.md#messagesadd) | **POST** /sms/messages | Create Message
[**MessagesAll**](MessagesApi.md#messagesall) | **GET** /sms/messages | List Messages
[**MessagesDelete**](MessagesApi.md#messagesdelete) | **DELETE** /sms/messages/{id} | Delete Message
[**MessagesOne**](MessagesApi.md#messagesone) | **GET** /sms/messages/{id} | Get Message
[**MessagesUpdate**](MessagesApi.md#messagesupdate) | **PATCH** /sms/messages/{id} | Update Message


<a name="messagesadd"></a>
# **MessagesAdd**
> CreateMessageResponse MessagesAdd (string xApideckConsumerId, string xApideckAppId, Message message, bool? raw = null, string xApideckServiceId = null)

Create Message

Create Message

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Sms.Api;
using Apideck.Sms.Client;
using Apideck.Sms.Model;

namespace Example
{
    public class MessagesAddExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MessagesApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var message = new Message(); // Message | 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Create Message
                CreateMessageResponse result = apiInstance.MessagesAdd(xApideckConsumerId, xApideckAppId, message, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MessagesApi.MessagesAdd: " + e.Message );
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
 **message** | [**Message**](Message.md)|  | 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 

### Return type

[**CreateMessageResponse**](CreateMessageResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Messages |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="messagesall"></a>
# **MessagesAll**
> GetMessagesResponse MessagesAll (string xApideckConsumerId, string xApideckAppId, bool? raw = null, string xApideckServiceId = null, string cursor = null, int? limit = null)

List Messages

List Messages

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Sms.Api;
using Apideck.Sms.Client;
using Apideck.Sms.Model;

namespace Example
{
    public class MessagesAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MessagesApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var cursor = "cursor_example";  // string | Cursor to start from. You can find cursors for next/previous pages in the meta.cursors property of the response. (optional) 
            var limit = 20;  // int? | Number of records to return (optional)  (default to 20)

            try
            {
                // List Messages
                GetMessagesResponse result = apiInstance.MessagesAll(xApideckConsumerId, xApideckAppId, raw, xApideckServiceId, cursor, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MessagesApi.MessagesAll: " + e.Message );
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

[**GetMessagesResponse**](GetMessagesResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Messages |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="messagesdelete"></a>
# **MessagesDelete**
> DeleteMessageResponse MessagesDelete (string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = null, bool? raw = null)

Delete Message

Delete Message

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Sms.Api;
using Apideck.Sms.Client;
using Apideck.Sms.Model;

namespace Example
{
    public class MessagesDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MessagesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)

            try
            {
                // Delete Message
                DeleteMessageResponse result = apiInstance.MessagesDelete(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MessagesApi.MessagesDelete: " + e.Message );
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

[**DeleteMessageResponse**](DeleteMessageResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Messages |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="messagesone"></a>
# **MessagesOne**
> GetMessageResponse MessagesOne (string id, string xApideckConsumerId, string xApideckAppId, string xApideckServiceId = null, bool? raw = null)

Get Message

Get Message

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Sms.Api;
using Apideck.Sms.Client;
using Apideck.Sms.Model;

namespace Example
{
    public class MessagesOneExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MessagesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)

            try
            {
                // Get Message
                GetMessageResponse result = apiInstance.MessagesOne(id, xApideckConsumerId, xApideckAppId, xApideckServiceId, raw);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MessagesApi.MessagesOne: " + e.Message );
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

[**GetMessageResponse**](GetMessageResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Messages |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="messagesupdate"></a>
# **MessagesUpdate**
> UpdateMessageResponse MessagesUpdate (string id, string xApideckConsumerId, string xApideckAppId, Message message, string xApideckServiceId = null, bool? raw = null)

Update Message

Update Message

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Sms.Api;
using Apideck.Sms.Client;
using Apideck.Sms.Model;

namespace Example
{
    public class MessagesUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MessagesApi(config);
            var id = "id_example";  // string | ID of the record you are acting upon.
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var message = new Message(); // Message | 
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)

            try
            {
                // Update Message
                UpdateMessageResponse result = apiInstance.MessagesUpdate(id, xApideckConsumerId, xApideckAppId, message, xApideckServiceId, raw);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MessagesApi.MessagesUpdate: " + e.Message );
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
 **message** | [**Message**](Message.md)|  | 
 **xApideckServiceId** | **string**| Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. | [optional] 
 **raw** | **bool?**| Include raw response. Mostly used for debugging purposes | [optional] [default to true]

### Return type

[**UpdateMessageResponse**](UpdateMessageResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Messages |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **402** | Payment Required |  -  |
| **404** | The specified resource was not found |  -  |
| **422** | Unprocessable |  -  |
| **0** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

