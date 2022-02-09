# Apideck.Accounting.Model.InvoiceLineItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] [readonly] 
**RowId** | **string** |  | [optional] 
**Code** | **string** | User defined item code | [optional] 
**LineNumber** | **int?** |  | [optional] 
**Description** | **string** |  | [optional] 
**Type** | **string** |  | [optional] 
**TaxAmount** | **decimal?** |  | [optional] 
**TotalAmount** | **decimal?** |  | [optional] 
**Quantity** | **decimal?** |  | [optional] 
**UnitPrice** | **decimal?** |  | [optional] 
**UnitOfMeasure** | **string** | Description of the unit type the item is sold as, ie: kg, hour. | [optional] 
**DiscountPercentage** | **decimal?** |  | [optional] 
**Item** | [**LinkedInvoiceItem**](LinkedInvoiceItem.md) |  | [optional] 
**TaxRate** | [**LinkedTaxRate**](LinkedTaxRate.md) |  | [optional] 
**LedgerAccount** | [**LinkedLedgerAccount**](LinkedLedgerAccount.md) |  | [optional] 
**RowVersion** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

