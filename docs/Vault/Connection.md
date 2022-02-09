# Apideck.Vault.Model.Connection

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] [readonly] 
**ServiceId** | **string** |  | [optional] [readonly] 
**Name** | **string** |  | [optional] [readonly] 
**TagLine** | **string** |  | [optional] [readonly] 
**UnifiedApi** | **string** |  | [optional] [readonly] 
**Website** | **string** |  | [optional] [readonly] 
**Icon** | **string** |  | [optional] [readonly] 
**Logo** | **string** |  | [optional] [readonly] 
**Settings** | **Object** | Connection settings. Values will persist to &#x60;form_fields&#x60; with corresponding id | [optional] 
**Metadata** | **Dictionary&lt;string, Object&gt;** | Attach your own consumer specific metadata | [optional] 
**AuthType** | **AuthType** |  | [optional] 
**Status** | **string** |  | [optional] [readonly] 
**FormFields** | [**List&lt;FormField&gt;**](FormField.md) |  | [optional] [readonly] 
**_Configuration** | [**List&lt;ConnectionConfiguration&gt;**](ConnectionConfiguration.md) |  | [optional] 
**ConfigurableResources** | **List&lt;string&gt;** |  | [optional] [readonly] 
**ResourceSchemaSupport** | **List&lt;string&gt;** |  | [optional] [readonly] 
**ResourceSettingsSupport** | **List&lt;string&gt;** |  | [optional] [readonly] 
**SettingsRequiredForAuthorization** | **List&lt;string&gt;** |  | [optional] [readonly] 
**AuthorizeUrl** | **string** |  | [optional] [readonly] 
**RevokeUrl** | **string** |  | [optional] [readonly] 
**Enabled** | **bool** |  | [optional] 
**CreatedAt** | **decimal** |  | [optional] [readonly] 
**UpdatedAt** | **decimal?** |  | [optional] [readonly] 
**State** | **ConnectionState** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

