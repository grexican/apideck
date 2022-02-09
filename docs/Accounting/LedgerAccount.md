# Apideck.Accounting.Model.LedgerAccount

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] [readonly] 
**DisplayId** | **string** |  | [optional] 
**NominalCode** | **string** |  | [optional] 
**Classification** | **string** |  | [optional] 
**Type** | **string** |  | [optional] 
**SubType** | **string** |  | [optional] 
**Name** | **string** |  | [optional] 
**FullyQualifiedName** | **string** |  | [optional] 
**Description** | **string** |  | [optional] 
**OpeningBalance** | **decimal?** |  | [optional] 
**CurrentBalance** | **decimal?** |  | [optional] 
**Currency** | **Currency** |  | [optional] 
**TaxType** | **string** |  | [optional] 
**TaxRate** | [**LinkedTaxRate**](LinkedTaxRate.md) |  | [optional] 
**Level** | **decimal?** |  | [optional] 
**Active** | **bool?** |  | [optional] 
**Status** | **string** |  | [optional] 
**Header** | **bool?** |  | [optional] 
**BankAccount** | [**BankAccount**](BankAccount.md) |  | [optional] 
**ParentAccount** | [**LedgerAccountParentAccount**](LedgerAccountParentAccount.md) |  | [optional] 
**SubAccount** | **bool?** |  | [optional] 
**SubAccounts** | **List&lt;Object&gt;** |  | [optional] [readonly] 
**LastReconciliationDate** | **DateTime?** | Reconciliation Date means the last calendar day of each Reconciliation Period. | [optional] 
**RowVersion** | **string** |  | [optional] 
**UpdatedBy** | **string** |  | [optional] [readonly] 
**CreatedBy** | **string** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**CreatedAt** | **DateTime** |  | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

