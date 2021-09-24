using System;
using System.Collections.Generic;

namespace ppp
{
    #region Token

    public class PayPalPlusAccessTokenResponse
    {
        public PayPalPlusAccessTokenResponse()
        {
            success = true;
        }

        public string scope { get; set; }
        public string nonce { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string app_id { get; set; }
        public int expires_in { get; set; }

        public bool success { get; set; }
        public string method { get; set; }
        public string payloadRequest { get; set; }
        public string payloadResponse { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }

    #endregion

    #region Create Payment

    #region Request

    public class PayPalPlusPaymentRequest
    {
        public PayPalPlusPaymentRequest()
        {
            //experience_profile_id = "XP-R295-7GRS-N2QH-778W";
            intent = "sale";
        }

        public string intent { get; set; }
        //public string experience_profile_id { get; set; }
        public PayerPaymentRequest payer { get; set; }
        public List<TransactionPaymentRequest> transactions { get; set; }
        public PayeePaymentRequest payee { get; set; }
        public RedirectUrlsPaymentRequest redirect_urls { get; set; }
    }

    public class PayerPaymentRequest
    {
        public string payment_method { get; set; }
    }

    public class DetailsPaymentRequest
    {
        public string shipping { get; set; }
        public string subtotal { get; set; }
        public string tax { get; set; }
    }

    public class AmountPaymentRequest
    {
        public string currency { get; set; }
        public string total { get; set; }
        public DetailsPaymentRequest details { get; set; }
    }

    public class PayeePaymentRequest
    {
        public PayeePaymentRequest()
        {
            email = "contato@meucurso.com.br";
        }

        public string email { get; set; }
    }

    public class ItemPaymentRequest
    {
        public string name { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string sku { get; set; }
        public string currency { get; set; }
    }

    public class ShippingAddressPaymentRequest
    {
        public string recipient_name { get; set; }
        public string line1 { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string postal_code { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
    }

    public class ItemListPaymentRequest
    {
        public ItemListPaymentRequest()
        {
            items = new List<ItemPaymentRequest>();
            //shipping_address = new ShippingAddressPaymentRequest();
        }

        public List<ItemPaymentRequest> items { get; set; }
        //public ShippingAddressPaymentRequest shipping_address { get; set; }
    }

    public class TransactionPaymentRequest
    {
        public AmountPaymentRequest amount { get; set; }
        public PayeePaymentRequest payee { get; set; }
        public string description { get; set; }
        public ItemListPaymentRequest item_list { get; set; }
    }

    public class RedirectUrlsPaymentRequest
    {
        public string return_url { get; set; }
        public string cancel_url { get; set; }
    }

    public class RootPaymentRequest
    {
        public string intent { get; set; }
        public string experience_profile_id { get; set; }
        public Payer payer { get; set; }
        public List<TransactionPaymentRequest> transactions { get; set; }
        public RedirectUrlsPaymentRequest redirect_urls { get; set; }
    }

    public class Payer
    {
        public Payer()
        {
            address = new Address();
        }

        public string phone_prefix { get; set; }
        public string cpf_cnpj { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string number { get; set; }
        public string district { get; set; }
        public string complement { get; set; }
    }

    #endregion

    #region Response

    public class PayPalPlusPaymentResponse
    {
        public PayPalPlusPaymentResponse()
        {
            success = true;
        }

        public bool success { get; set; }
        public string method { get; set; }
        public string payloadRequest { get; set; }
        public string payloadResponse { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }

        public List<PayPalPlusPaymentItemsPaymentResponse> items { get; set; }


        public string id { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public string state { get; set; }
        public string intent { get; set; }
        public PayerPaymentResponse payer { get; set; }
        public List<TransactionPaymentResponse> transactions { get; set; }
        public List<LinkPaymentResponse> links { get; set; }
    }

    public class ShippingAddressPaymentResponse
    {
        public string recipient_name { get; set; }
        public string line1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }

    public class PayPalPlusPaymentItemsPaymentResponse
    {
        public PayPalPlusPaymentItemsPaymentResponse()
        {
            success = true;
        }

        public bool success { get; set; }
        public string method { get; set; }
        public string payloadRequest { get; set; }
        public string payloadResponse { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }

    }

    public class PayerInfoPaymentResponse
    {
        public ShippingAddressPaymentResponse shipping_address { get; set; }
    }

    public class PayerPaymentResponse
    {
        public string payment_method { get; set; }
        public PayerInfoPaymentResponse payer_info { get; set; }
    }

    public class DetailsPaymentResponse
    {
        public string subtotal { get; set; }
        public string tax { get; set; }
        public string shipping { get; set; }
    }

    public class AmountPaymentResponse
    {
        public string total { get; set; }
        public string currency { get; set; }
        public DetailsPaymentResponse details { get; set; }
    }

    public class ItemPaymentResponse
    {
        public string name { get; set; }
        public string sku { get; set; }
        public string price { get; set; }
        public string currency { get; set; }
        public string quantity { get; set; }
    }

    public class ItemListPaymentResponse
    {
        public List<ItemPaymentResponse> items { get; set; }
        public ShippingAddressPaymentResponse shipping_address { get; set; }
    }

    public class TransactionPaymentResponse
    {
        public AmountPaymentResponse amount { get; set; }
        public string description { get; set; }
        public ItemListPaymentResponse item_list { get; set; }
    }

    public class LinkPaymentResponse
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }

    public class RootPaymentResponse
    {
        public string id { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public string state { get; set; }
        public string intent { get; set; }
        public PayerPaymentResponse payer { get; set; }
        public List<TransactionPaymentResponse> transactions { get; set; }
        public List<LinkPaymentResponse> links { get; set; }
    }



    #endregion

    #endregion

    #region Execute Payment

    #region Request

    public class PayPalPlusExecutePaymentRequest
    {
        public string payer_id { get; set; }
    }

    #endregion

    #region Response

    public class PayPalPlusExecutePaymentResponse
    {
        public PayPalPlusExecutePaymentResponse()
        {
            success = true;
        }

        public bool success { get; set; }
        public string method { get; set; }
        public string payloadRequest { get; set; }
        public string payloadResponse { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }

    public class ShippingAddressExecutePaymentResponse
    {
        public string recipient_name { get; set; }
        public string line1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }

    public class PayerInfoExecutePaymentResponse
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string payer_id { get; set; }
        public ShippingAddressExecutePaymentResponse shipping_address { get; set; }
        public string country_code { get; set; }
    }

    public class PayerExecutePaymentResponse
    {
        public string payment_method { get; set; }
        public string status { get; set; }
        public PayerInfoExecutePaymentResponse payer_info { get; set; }
    }

    public class DetailsExecutePaymentResponse
    {
        public string subtotal { get; set; }
        public string tax { get; set; }
        public string shipping { get; set; }
        public string insurance { get; set; }
        public string handling_fee { get; set; }
        public string shipping_discount { get; set; }
    }

    public class AmountExecutePaymentResponse
    {
        public string total { get; set; }
        public string currency { get; set; }
        public DetailsExecutePaymentResponse details { get; set; }
    }

    public class PayeeExecutePaymentResponse
    {
        public string merchant_id { get; set; }
        public string email { get; set; }
    }

    public class ItemExecutePaymentResponse
    {
        public string name { get; set; }
        public string sku { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string currency { get; set; }
        public int quantity { get; set; }
    }

    public class ItemListExecutePaymentResponse
    {
        public List<ItemExecutePaymentResponse> items { get; set; }
        public ShippingAddressExecutePaymentResponse shipping_address { get; set; }
    }

    public class TransactionFeeExecutePaymentResponse
    {
        public string value { get; set; }
        public string currency { get; set; }
    }

    public class LinkExecutePaymentResponse
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }

    public class SaleExecutePaymentResponse
    {
        public string id { get; set; }
        public string state { get; set; }
        public AmountExecutePaymentResponse amount { get; set; }
        public string payment_mode { get; set; }
        public string protection_eligibility { get; set; }
        public string protection_eligibility_type { get; set; }
        public TransactionFeeExecutePaymentResponse transaction_fee { get; set; }
        public string parent_payment { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public List<LinkExecutePaymentResponse> links { get; set; }
    }

    public class RelatedResourceExecutePaymentResponse
    {
        public SaleExecutePaymentResponse sale { get; set; }
    }

    public class TransactionExecutePaymentResponse
    {
        public AmountExecutePaymentResponse amount { get; set; }
        public PayeeExecutePaymentResponse payee { get; set; }
        public string description { get; set; }
        public string custom { get; set; }
        public string invoice_number { get; set; }
        public ItemListExecutePaymentResponse item_list { get; set; }
        public List<RelatedResourceExecutePaymentResponse> related_resources { get; set; }
    }

    public class RootExecutePaymentResponse
    {
        public string id { get; set; }
        public string intent { get; set; }
        public string state { get; set; }
        public string cart { get; set; }
        public PayerExecutePaymentResponse payer { get; set; }
        public List<TransactionExecutePaymentResponse> transactions { get; set; }
        public DateTime create_time { get; set; }
        public List<LinkExecutePaymentResponse> links { get; set; }
    }

    #endregion

    #endregion
}