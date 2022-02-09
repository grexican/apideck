# Apideck.Accounting.Model.InvoiceItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] [readonly] 
**Name** | **string** |  | [optional] 
**Description** | **string** |  | [optional] 
**Code** | **string** | User defined item code | [optional] 
**Sold** | **bool?** | Item will be available on sales transactions | [optional] 
**Purchased** | **bool?** | Item is available for purchase transactions | [optional] 
**Tracked** | **bool?** | Item is inventoried | [optional] 
**Type** | **string** |  | [optional] 
**SalesDetails** | [**InvoiceItemSalesDetails**](InvoiceItemSalesDetails.md) |  | [optional] 
**PurchaseDetails** | [**InvoiceItemSalesDetails**](InvoiceItemSalesDetails.md) |  | [optional] 
**Quantity** | **decimal?** |  | [optional] 
**UnitPrice** | **decimal?** |  | [optional] 
**AssetAccount** | [**LinkedLedgerAccount**](LinkedLedgerAccount.md) |  | [optional] 
**IncomeAccount** | [**LinkedLedgerAccount**](LinkedLedgerAccount.md) |  | [optional] 
**ExpenseAccount** | [**LinkedLedgerAccount**](LinkedLedgerAccount.md) |  | [optional] 
**Active** | **bool?** |  | [optional] 
**RowVersion** | **string** |  | [optional] 
**UpdatedBy** | **string** |  | [optional] [readonly] 
**CreatedBy** | **string** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**CreatedAt** | **DateTime** |  | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

