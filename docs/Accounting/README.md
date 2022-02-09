# Apideck.Accounting - the C# library for the Accounting API

Welcome to the Accounting API.

You can use this API to access all Accounting API endpoints.

## Base URL

The base URL for all API requests is `https://unify.apideck.com`

## GraphQL

Use the [GraphQL playground](https://developers.apideck.com/graphql/playground) to test out the GraphQL API.

## Headers

Custom headers that are expected as part of the request. Note that [RFC7230](https://tools.ietf.org/html/rfc7230) states header names are case insensitive.

| Name                  | Type    | Required | Description                                                                                                                                                    |
| - -- -- -- -- -- -- -- -- -- -- | - -- -- -- | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| x-apideck-consumer-id | String  | Yes      | The id of the customer stored inside Apideck Vault. This can be a user id, account id, device id or whatever entity that can have integration within your app. |
| x-apideck-service-id  | String  | No       | Describe the service you want to call (e.g., pipedrive). Only needed when a customer has activated multiple integrations for the same Unified API.             |
| x-apideck-raw         | Boolean | No       | Include raw response. Mostly used for debugging purposes.                                                                                                      |
| x-apideck-app-id      | String  | Yes      | The application id of your Unify application. Available at https://app.apideck.com/unify/api-keys.                                                             |
| Authorization         | String  | Yes      | Bearer API KEY                                                                                                                                                 |

## Authorization

You can interact with the API through the authorization methods below.

<!- - ReDoc-Inject: <security-definitions> - ->

## Pagination

All API resources have support for bulk retrieval via list APIs. For example, you can list [ledger accounts](#tag/Ledger Accounts), [tax rates](#tag/Tax Rates) and [companies](#tag/Companies). Apideck uses cursor-based pagination via the optional `cursor` and `limit` parameters.

To fetch the first page of results, call the list API without a `cursor` parameter. Afterwards you can fetch subsequent pages by providing a cursor parameter. You will find the next cursor in the response body in `meta.cursors.next`. If `meta.cursors.next` is `null` you're at the end of the list.

In the REST API you can also use the `links` from the response for added convenience. Simply call the URL in `links.next` to get the next page of results.

### Query Parameters

| Name   | Type   | Required | Description                                                                                                        |
| - -- -- - | - -- -- - | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| cursor | String | No       | Cursor to start from. You can find cursors for next & previous pages in the meta.cursors property of the response. |
| limit  | Number | No       | Number of results to return. Minimum 1, Maximum 200, Default 20                                                    |

### Response Body

| Name                  | Type   | Description                                                        |
| - -- -- -- -- -- -- -- -- -- -- | - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| meta.cursors.previous | String | Cursor to navigate to the previous page of results through the API |
| meta.cursors.current  | String | Cursor to navigate to the current page of results through the API  |
| meta.cursors.next     | String | Cursor to navigate to the next page of results through the API     |
| meta.items_on_page    | Number | Number of items returned in the data property of the response      |
| links.previous        | String | Link to navigate to the previous page of results through the API   |
| links.current         | String | Link to navigate to the current page of results through the API    |
| links.next            | String | Link to navigate to the next page of results through the API       |

⚠️ `meta.cursors.previous`/`links.previous` is not available for all connectors.

## SDKs and API Clients

Upcoming. [Request the SDK of your choice](https://integrations.apideck.com/request).

## Debugging

Because of the nature of the abstraction we do in Apideck Unify we still provide the option to the receive raw requests and responses being handled underlying. By including the raw flag `?raw=true` in your requests you can still receive the full request. Please note that this increases the response size and can introduce extra latency.

## Errors

The API returns standard HTTP response codes to indicate success or failure of the API requests. For errors, we also return a customized error message inside the JSON response. You can see the returned HTTP status codes below.

| Code | Title                | Description                                                                                                                                                                                              |
| - -- - | - -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| 200  | OK                   | The request message has been successfully processed, and it has produced a response. The response message varies, depending on the request method and the requested data.                                |
| 201  | Created              | The request has been fulfilled and has resulted in one or more new resources being created.                                                                                                              |
| 204  | No Content           | The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.                                                                          |
| 400  | Bad Request          | The receiving server cannot understand the request because of malformed syntax. Do not repeat the request without first modifying it; check the request for errors, fix them and then retry the request. |
| 401  | Unauthorized         | The request has not been applied because it lacks valid authentication credentials for the target resource.                                                                                              |
| 402  | Payment Required     | Subscription data is incomplete or out of date. You'll need to provide payment details to continue.                                                                                                      |
| 403  | Forbidden            | You do not have the appropriate user rights to access the request. Do not repeat the request.                                                                                                            |
| 404  | Not Found            | The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.                                                                           |
| 409  | Conflict             | The request could not be completed due to a conflict with the current state of the target resource.                                                                                                      |
| 422  | Unprocessable Entity | The server understands the content type of the request entity, and the syntax of the request entity is correct but was unable to process the contained instructions.                                     |
| 5xx  | Server Errors        | Something went wrong with the Unify API. These errors are logged on our side. You can contact our team to resolve the issue.                                                                             |

### Handling errors

The Unify API and SDKs can produce errors for many reasons, such as a failed requests due to misconfigured integrations, invalid parameters, authentication errors, and network unavailability.

### Error Types

#### RequestValidationError

Request is not valid for the current endpoint. The response body will include details on the validation error. Check the spelling and types of your attributes, and ensure you are not passing data that is outside of the specification.

#### UnsupportedFiltersError

Filters in the request are valid, but not supported by the connector. Remove the unsupported filter(s) to get a successful response.

#### UnsupportedSortFieldError

Sort field (`sort[by]`) in the request is valid, but not supported by the connector. Replace or remove the sort field to get a successful response.

#### InvalidCursorError

Pagination cursor in the request is not valid for the current connector. Make sure to use a cursor returned from the API, for the same connector.

#### ConnectorExecutionError

A Unified API request made via one of our downstream connectors returned an unexpected error. The `status_code` returned is proxied through to error response along with their original response via the error detail.

#### ConnectorProcessingError

A Unified API request made via one of our downstream connectors returned a status code that was less than 400, along with a description of why the request could not be processed. Often this is due to the shape of request data being valid, but unable to be processed due to internal business logic - for example: an invalid relationship or `ID` present in your request.

#### UnauthorizedError

We were unable to authorize the request as made. This can happen for a number of reasons, from missing header params to passing an incorrect authorization token. Verify your Api Key is being set correctly in the authorization header. ie: `Authorization: 'Bearer sk_live_***'`

#### ConnectorCredentialsError

A request using a given connector has not been authorized. Ensure the connector you are trying to use has been configured correctly and been authorized for use.

#### ConnectorDisabledError

A request has been made to a connector that has since been disabled. This may be temporary - You can contact our team to resolve the issue.

#### RequestLimitError

You have reached the number of requests included in your Free Tier Subscription. You will no be able to make further requests until this limit resets at the end of the month, or talk to us about upgrading your subscription to continue immediately.

#### EntityNotFoundError

You've made a request for a resource or route that does not exist. Verify your path parameters or any identifiers used to fetch this resource.

#### OAuthCredentialsNotFoundError

When adding a connector integration that implements OAuth, both a `client_id` and `client_secret` must be provided before any authorizations can be performed. Verify the integration has been configured properly before continuing.

#### IntegrationNotFoundError

The requested connector integration could not be found associated to your `application_id`. Verify your `application_id` is correct, and that this connector has been added and configured for your application.

#### ConnectionNotFoundError

A valid connection could not be found associated to your `application_id`. Something _may_ have interrupted the authorization flow. You may need to start the connector authorization process again.

#### ConnectorNotFoundError

A request was made for an unknown connector. Verify your `service_id` is spelled correctly, and that this connector is enabled for your provided `unified_api`.

#### OAuthRedirectUriError

A request was made either in a connector authorization flow, or attempting to revoke connector access without a valid `redirect_uri`. This is the url the user should be returned to on completion of process.

#### OAuthInvalidStateError

The state param is required and is used to ensure the outgoing authorization state has not been altered before the user is redirected back. It also contains required params needed to identify the connector being used. If this has been altered, the authorization will not succeed.

#### OAuthCodeExchangeError

When attempting to exchange the authorization code for an `access_token` during an OAuth flow, an error occurred. This may be temporary. You can reattempt authorization or contact our team to resolve the issue.

#### MappingError

There was an error attempting to retrieve the mapping for a given attribute. We've been notified and are working to fix this issue.

#### ConnectorMappingNotFoundError

It seems the implementation for this connector is incomplete. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### ConnectorResponseMappingNotFoundError

We were unable to retrieve the response mapping for this connector. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### ConnectorOperationMappingNotFoundError

Connector mapping has not been implemented for the requested operation. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### ConnectorWorkflowMappingError

The composite api calls required for this operation have not been mapped entirely. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

#### PaginationNotSupportedError

Pagination is not yet supported for this connector, try removing limit and/or cursor from the query. It's possible this connector is in `beta` or still under development. We've been notified and are working to fix this issue.

## API Design

### API Styles and data formats

#### REST API

The API is organized around [REST](https://restfulapi.net/), providing simple and predictable URIs to access and modify objects. Requests support standard HTTP methods like GET, PUT, POST, and DELETE and standard status codes. JSON is returned by all API responses, including errors. In all API requests, you must set the content-type HTTP header to application/json. All API requests must be made over HTTPS. Calls made over HTTP will fail.

##### Available HTTP methods

The Apideck API uses HTTP verbs to understand if you want to read (GET), delete (DELETE) or create (POST) an object. When your web application cannot do a POST or DELETE, we provide the ability to set the method through the query parameter \\_method.

```
POST /messages
GET /messages
GET /messages/{messageId}
PATCH /messages/{messageId}
DELETE /messages/{messageId}
```

Response bodies are always UTF-8 encoded JSON objects, unless explicitly documented otherwise. For some endpoints and use cases we divert from REST to provide a better developer experience.

### Schema

All API requests and response bodies adhere to a common JSON format representing individual items, collections of items, links to related items and additional meta data.

### Meta

Meta data can be represented as a top level member named “meta”. Any information may be provided in the meta data. It’s most common use is to return the total number of records when requesting a collection of resources.

### Idempotence (upcoming)

To prevent the creation of duplicate resources, every POST method (such as one that creates a consumer record) must specify a unique value for the X-Unique-Transaction-ID header name. Uniquely identifying each unique POST request ensures that the API processes a given request once and only once.

Uniquely identifying new resource-creation POSTs is especially important when the outcome of a response is ambiguous because of a transient service interruption, such as a server-side timeout or network disruption. If a service interruption occurs, then the client application can safely retry the uniquely identified request without creating duplicate operations. (API endpoints that guarantee that every uniquely identified request is processed only once no matter how many times that uniquely identifiable request is made are described as idempotent.)

### Request IDs

Each API request has an associated request identifier. You can find this value in the response headers, under Request-Id. You can also find request identifiers in the URLs of individual request logs in your Dashboard. If you need to contact us about a specific request, providing the request identifier will ensure the fastest possible resolution.

### Fixed field types

#### Dates

The dates returned by the API are all represented in UTC (ISO8601 format).

This example `2019-11-14T00:55:31.820Z` is defined by the ISO 8601 standard. The T in the middle separates the year-month-day portion from the hour-minute-second portion. The Z on the end means UTC, that is, an offset-from-UTC of zero hours-minutes-seconds. The Z is pronounced \"Zulu\" per military/aviation tradition.

The ISO 8601 standard is more modern. The formats are wisely designed to be easy to parse by machine as well as easy to read by humans across cultures.

#### Prices and Currencies

All prices returned by the API are represented as integer amounts in a currency’s smallest unit. For example, $5 USD would be returned as 500 (i.e, 500 cents).

For zero-decimal currencies, amounts will still be provided as an integer but without the need to divide by 100. For example, an amount of ¥5 (JPY) would be returned as 5.

All currency codes conform to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).

## Support

If you have problems or need help with your case, you can always reach out to our Support.


This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 8.11.0
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen
    For more information, please visit [https://developers.apideck.com](https://developers.apideck.com)

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 12.0.3 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Apideck.Accounting.Api;
using Apideck.Accounting.Client;
using Apideck.Accounting.Model;
```
<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Apideck.Accounting.Api;
using Apideck.Accounting.Client;
using Apideck.Accounting.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://unify.apideck.com";
            // Configure API key authorization: apiKey
            config.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CompanyInfoApi(config);
            var xApideckConsumerId = "xApideckConsumerId_example";  // string | ID of the consumer which you want to get or push data from
            var xApideckAppId = "xApideckAppId_example";  // string | The ID of your Unify application
            var raw = true;  // bool? | Include raw response. Mostly used for debugging purposes (optional)  (default to true)
            var xApideckServiceId = "xApideckServiceId_example";  // string | Provide the service id you want to call (e.g., pipedrive). [See the full list in the connector section.](#section/Connectors) Only needed when a consumer has activated multiple integrations for a Unified API. (optional) 

            try
            {
                // Get company info
                GetCompanyInfoResponse result = apiInstance.CompanyInfoOne(xApideckConsumerId, xApideckAppId, raw, xApideckServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CompanyInfoApi.CompanyInfoOne: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://unify.apideck.com*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*CompanyInfoApi* | [**CompanyInfoOne**](docs/CompanyInfoApi.md#companyinfoone) | **GET** /accounting/company-info | Get company info
*CustomersApi* | [**CustomersAdd**](docs/CustomersApi.md#customersadd) | **POST** /accounting/customers | Create Customer
*CustomersApi* | [**CustomersAll**](docs/CustomersApi.md#customersall) | **GET** /accounting/customers | List Customers
*CustomersApi* | [**CustomersDelete**](docs/CustomersApi.md#customersdelete) | **DELETE** /accounting/customers/{id} | Delete Customer
*CustomersApi* | [**CustomersOne**](docs/CustomersApi.md#customersone) | **GET** /accounting/customers/{id} | Get Customer
*CustomersApi* | [**CustomersUpdate**](docs/CustomersApi.md#customersupdate) | **PATCH** /accounting/customers/{id} | Update Customer
*InvoiceItemsApi* | [**InvoiceItemsAdd**](docs/InvoiceItemsApi.md#invoiceitemsadd) | **POST** /accounting/invoice-items | Create Invoice Item
*InvoiceItemsApi* | [**InvoiceItemsAll**](docs/InvoiceItemsApi.md#invoiceitemsall) | **GET** /accounting/invoice-items | List Invoice Items
*InvoiceItemsApi* | [**InvoiceItemsDelete**](docs/InvoiceItemsApi.md#invoiceitemsdelete) | **DELETE** /accounting/invoice-items/{id} | Delete Invoice Item
*InvoiceItemsApi* | [**InvoiceItemsOne**](docs/InvoiceItemsApi.md#invoiceitemsone) | **GET** /accounting/invoice-items/{id} | Get Invoice Item
*InvoiceItemsApi* | [**InvoiceItemsUpdate**](docs/InvoiceItemsApi.md#invoiceitemsupdate) | **PATCH** /accounting/invoice-items/{id} | Update Invoice Item
*InvoicesApi* | [**InvoicesAdd**](docs/InvoicesApi.md#invoicesadd) | **POST** /accounting/invoices | Create Invoice
*InvoicesApi* | [**InvoicesAll**](docs/InvoicesApi.md#invoicesall) | **GET** /accounting/invoices | List Invoices
*InvoicesApi* | [**InvoicesDelete**](docs/InvoicesApi.md#invoicesdelete) | **DELETE** /accounting/invoices/{id} | Delete Invoice
*InvoicesApi* | [**InvoicesOne**](docs/InvoicesApi.md#invoicesone) | **GET** /accounting/invoices/{id} | Get Invoice
*InvoicesApi* | [**InvoicesUpdate**](docs/InvoicesApi.md#invoicesupdate) | **PATCH** /accounting/invoices/{id} | Update Invoice
*LedgerAccountsApi* | [**LedgerAccountsAdd**](docs/LedgerAccountsApi.md#ledgeraccountsadd) | **POST** /accounting/ledger-accounts | Create Ledger Account
*LedgerAccountsApi* | [**LedgerAccountsAll**](docs/LedgerAccountsApi.md#ledgeraccountsall) | **GET** /accounting/ledger-accounts | List Ledger Accounts
*LedgerAccountsApi* | [**LedgerAccountsDelete**](docs/LedgerAccountsApi.md#ledgeraccountsdelete) | **DELETE** /accounting/ledger-accounts/{id} | Delete Ledger Account
*LedgerAccountsApi* | [**LedgerAccountsOne**](docs/LedgerAccountsApi.md#ledgeraccountsone) | **GET** /accounting/ledger-accounts/{id} | Get Ledger Account
*LedgerAccountsApi* | [**LedgerAccountsUpdate**](docs/LedgerAccountsApi.md#ledgeraccountsupdate) | **PATCH** /accounting/ledger-accounts/{id} | Update Ledger Account
*PaymentsApi* | [**PaymentsAdd**](docs/PaymentsApi.md#paymentsadd) | **POST** /accounting/payments | Create Payment
*PaymentsApi* | [**PaymentsAll**](docs/PaymentsApi.md#paymentsall) | **GET** /accounting/payments | List Payments
*PaymentsApi* | [**PaymentsDelete**](docs/PaymentsApi.md#paymentsdelete) | **DELETE** /accounting/payments/{id} | Delete Payment
*PaymentsApi* | [**PaymentsOne**](docs/PaymentsApi.md#paymentsone) | **GET** /accounting/payments/{id} | Get Payment
*PaymentsApi* | [**PaymentsUpdate**](docs/PaymentsApi.md#paymentsupdate) | **PATCH** /accounting/payments/{id} | Update Payment
*TaxRatesApi* | [**TaxRatesAdd**](docs/TaxRatesApi.md#taxratesadd) | **POST** /accounting/tax-rates | Create Tax Rate
*TaxRatesApi* | [**TaxRatesAll**](docs/TaxRatesApi.md#taxratesall) | **GET** /accounting/tax-rates | List Tax Rates
*TaxRatesApi* | [**TaxRatesDelete**](docs/TaxRatesApi.md#taxratesdelete) | **DELETE** /accounting/tax-rates/{id} | Delete Tax Rate
*TaxRatesApi* | [**TaxRatesOne**](docs/TaxRatesApi.md#taxratesone) | **GET** /accounting/tax-rates/{id} | Get Tax Rate
*TaxRatesApi* | [**TaxRatesUpdate**](docs/TaxRatesApi.md#taxratesupdate) | **PATCH** /accounting/tax-rates/{id} | Update Tax Rate


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.AccountingCustomer](docs/AccountingCustomer.md)
 - [Model.AccountingEventType](docs/AccountingEventType.md)
 - [Model.Address](docs/Address.md)
 - [Model.BadRequestResponse](docs/BadRequestResponse.md)
 - [Model.BankAccount](docs/BankAccount.md)
 - [Model.Company](docs/Company.md)
 - [Model.CompanyInfo](docs/CompanyInfo.md)
 - [Model.Contact](docs/Contact.md)
 - [Model.CreateCustomerResponse](docs/CreateCustomerResponse.md)
 - [Model.CreateInvoiceItemResponse](docs/CreateInvoiceItemResponse.md)
 - [Model.CreateInvoiceResponse](docs/CreateInvoiceResponse.md)
 - [Model.CreateLedgerAccountResponse](docs/CreateLedgerAccountResponse.md)
 - [Model.CreatePaymentResponse](docs/CreatePaymentResponse.md)
 - [Model.CreateTaxRateResponse](docs/CreateTaxRateResponse.md)
 - [Model.Currency](docs/Currency.md)
 - [Model.CustomField](docs/CustomField.md)
 - [Model.DeleteCustomerResponse](docs/DeleteCustomerResponse.md)
 - [Model.DeleteInvoiceResponse](docs/DeleteInvoiceResponse.md)
 - [Model.DeleteLedgerAccountResponse](docs/DeleteLedgerAccountResponse.md)
 - [Model.DeletePaymentResponse](docs/DeletePaymentResponse.md)
 - [Model.DeleteTaxRateResponse](docs/DeleteTaxRateResponse.md)
 - [Model.Email](docs/Email.md)
 - [Model.GetCompanyInfoResponse](docs/GetCompanyInfoResponse.md)
 - [Model.GetCustomerResponse](docs/GetCustomerResponse.md)
 - [Model.GetCustomersResponse](docs/GetCustomersResponse.md)
 - [Model.GetInvoiceItemResponse](docs/GetInvoiceItemResponse.md)
 - [Model.GetInvoiceItemsResponse](docs/GetInvoiceItemsResponse.md)
 - [Model.GetInvoiceResponse](docs/GetInvoiceResponse.md)
 - [Model.GetInvoicesResponse](docs/GetInvoicesResponse.md)
 - [Model.GetLedgerAccountResponse](docs/GetLedgerAccountResponse.md)
 - [Model.GetLedgerAccountsResponse](docs/GetLedgerAccountsResponse.md)
 - [Model.GetPaymentResponse](docs/GetPaymentResponse.md)
 - [Model.GetPaymentsResponse](docs/GetPaymentsResponse.md)
 - [Model.GetTaxRateResponse](docs/GetTaxRateResponse.md)
 - [Model.GetTaxRatesResponse](docs/GetTaxRatesResponse.md)
 - [Model.Invoice](docs/Invoice.md)
 - [Model.InvoiceItem](docs/InvoiceItem.md)
 - [Model.InvoiceItemSalesDetails](docs/InvoiceItemSalesDetails.md)
 - [Model.InvoiceLineItem](docs/InvoiceLineItem.md)
 - [Model.InvoiceResponse](docs/InvoiceResponse.md)
 - [Model.LedgerAccount](docs/LedgerAccount.md)
 - [Model.LedgerAccountParentAccount](docs/LedgerAccountParentAccount.md)
 - [Model.LinkedCustomer](docs/LinkedCustomer.md)
 - [Model.LinkedInvoiceItem](docs/LinkedInvoiceItem.md)
 - [Model.LinkedLedgerAccount](docs/LinkedLedgerAccount.md)
 - [Model.LinkedTaxRate](docs/LinkedTaxRate.md)
 - [Model.Links](docs/Links.md)
 - [Model.Meta](docs/Meta.md)
 - [Model.MetaCursors](docs/MetaCursors.md)
 - [Model.NotFoundResponse](docs/NotFoundResponse.md)
 - [Model.NotImplementedResponse](docs/NotImplementedResponse.md)
 - [Model.Payment](docs/Payment.md)
 - [Model.PaymentRequiredResponse](docs/PaymentRequiredResponse.md)
 - [Model.PhoneNumber](docs/PhoneNumber.md)
 - [Model.Pipeline](docs/Pipeline.md)
 - [Model.PipelineStages](docs/PipelineStages.md)
 - [Model.SocialLink](docs/SocialLink.md)
 - [Model.TaxRate](docs/TaxRate.md)
 - [Model.UnauthorizedResponse](docs/UnauthorizedResponse.md)
 - [Model.UnexpectedErrorResponse](docs/UnexpectedErrorResponse.md)
 - [Model.UnifiedId](docs/UnifiedId.md)
 - [Model.UnprocessableResponse](docs/UnprocessableResponse.md)
 - [Model.UpdateCustomerResponse](docs/UpdateCustomerResponse.md)
 - [Model.UpdateInvoiceItemsResponse](docs/UpdateInvoiceItemsResponse.md)
 - [Model.UpdateInvoiceResponse](docs/UpdateInvoiceResponse.md)
 - [Model.UpdateLedgerAccountResponse](docs/UpdateLedgerAccountResponse.md)
 - [Model.UpdatePaymentResponse](docs/UpdatePaymentResponse.md)
 - [Model.UpdateTaxRateResponse](docs/UpdateTaxRateResponse.md)
 - [Model.WebhookEvent](docs/WebhookEvent.md)
 - [Model.WebhookEventAllOf](docs/WebhookEventAllOf.md)
 - [Model.WebhookEventAllOf1](docs/WebhookEventAllOf1.md)
 - [Model.Website](docs/Website.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="apiKey"></a>
### apiKey

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

