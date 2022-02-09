# Apideck.Connector.Model.Connector

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | ID of the connector. | [optional] [readonly] 
**Name** | **string** | Name of the connector. | [optional] 
**Description** | **string** |  | [optional] 
**IconUrl** | **string** | Link to a small square icon for the connector. | [optional] 
**LogoUrl** | **string** | Link to the full logo for the connector. | [optional] 
**WebsiteUrl** | **string** | Link to the connector&#39;s website. | [optional] 
**AuthType** | **string** | Type of authorization used by the connector | [optional] [readonly] 
**Status** | **ConnectorStatus** |  | [optional] 
**Settings** | [**List&lt;ConnectorSetting&gt;**](ConnectorSetting.md) |  | [optional] 
**ServiceId** | **string** | Service provider identifier | [optional] 
**UnifiedApis** | [**List&lt;ConnectorUnifiedApis&gt;**](ConnectorUnifiedApis.md) | List of Unified APIs that feature this connector. | [optional] 
**SupportedResources** | [**List&lt;ConnectorSupportedResources&gt;**](ConnectorSupportedResources.md) | List of resources that are supported on the connector. | [optional] 
**ConfigurableResources** | **List&lt;string&gt;** | List of resources that have settings that can be configured. | [optional] 
**SupportedEvents** | [**List&lt;ConnectorSupportedEvents&gt;**](ConnectorSupportedEvents.md) | List of events that are supported on the connector. Events are delivered via Webhooks. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

