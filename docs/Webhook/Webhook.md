# Apideck.Webhook.Model.Webhook

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] [readonly] 
**Description** | **string** |  | [optional] 
**UnifiedApi** | **UnifiedApiId** |  | 
**Status** | **Status** |  | 
**DeliveryUrl** | **string** | The delivery url of the webhook endpoint. | 
**ExecuteBaseUrl** | **string** | The Unify Base URL events from connectors will be sent to after service id is appended. | [readonly] 
**Events** | [**List&lt;WebhookEventType&gt;**](WebhookEventType.md) | The list of subscribed events for this webhook. [&#x60;*&#x60;] indicates that all events are enabled. | 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**CreatedAt** | **DateTime** |  | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

