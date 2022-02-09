# Apideck.Accounting.Model.TaxRate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] 
**Name** | **string** |  | [optional] 
**Code** | **string** |  | [optional] 
**Description** | **string** |  | [optional] 
**EffectiveTaxRate** | **decimal?** |  | [optional] 
**TotalTaxRate** | **decimal?** | Not compounded sum of the components of a tax rate | [optional] 
**TaxPayableAccountId** | **string** | Unique identifier for the account for tax collected. | [optional] 
**TaxRemittedAccountId** | **string** | Unique identifier for the account for tax remitted. | [optional] 
**Components** | **List&lt;Object&gt;** |  | [optional] 
**Type** | **string** | Tax type used to indicate the source of tax collected or paid | [optional] 
**OriginalTaxRateId** | **string** | ID of the original tax rate from which the new tax rate is derived. Helps to understand the relationship between corresponding tax rate entities. | [optional] 
**Status** | **string** |  | [optional] 
**RowVersion** | **string** |  | [optional] 
**UpdatedBy** | **string** |  | [optional] [readonly] 
**CreatedBy** | **string** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**CreatedAt** | **DateTime** |  | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

