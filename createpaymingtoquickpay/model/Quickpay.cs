using Newtonsoft.Json;

namespace createpaymingtoquickpay.model
{
    public class Quickpay
    {
        public class Metadata
        {
            public object type { get; set; }
            public object origin { get; set; }
            public object brand { get; set; }
            public object bin { get; set; }
            public object corporate { get; set; }
            public object last4 { get; set; }
            public object exp_month { get; set; }
            public object exp_year { get; set; }
            public object country { get; set; }
            public object is_3d_secure { get; set; }

            [JsonProperty("3d_secure_type")]
            public object _3d_secure_type { get; set; }
            public object issued_to { get; set; }
            public object hash { get; set; }
            public object moto { get; set; }
            public object number { get; set; }
            public object customer_ip { get; set; }
            public object customer_country { get; set; }
            public bool fraud_suspected { get; set; }
            public List<object> fraud_remarks { get; set; }
            public bool fraud_reported { get; set; }
            public object fraud_report_description { get; set; }
            public object fraud_reported_at { get; set; }
            public object nin_number { get; set; }
            public object nin_country_code { get; set; }
            public object nin_gender { get; set; }
            public object shopsystem_name { get; set; }
            public object shopsystem_version { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public object ulid { get; set; }
            public int merchant_id { get; set; }
            public string order_id { get; set; }
            public bool accepted { get; set; }
            public string type { get; set; }
            public object text_on_statement { get; set; }
            public object branding_id { get; set; }
            public Variables variables { get; set; }
            public string currency { get; set; }
            public string state { get; set; }
            public Metadata metadata { get; set; }
            public object link { get; set; }
            public object shipping_address { get; set; }
            public object invoice_address { get; set; }
            public List<object> basket { get; set; }
            public Shipping shipping { get; set; }
            public List<object> operations { get; set; }
            public bool test_mode { get; set; }
            public object acquirer { get; set; }
            public object facilitator { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public object retented_at { get; set; }
            public int balance { get; set; }
            public object fee { get; set; }
            public object deadline_at { get; set; }
        }
        public class Link
        {
            public string url { get; set; }
            public int agreement_id { get; set; }
            public string language { get; set; }
            public int amount { get; set; }
            public object continue_url { get; set; }
            public object cancel_url { get; set; }
            public object callback_url { get; set; }
            public object payment_methods { get; set; }
            public bool auto_fee { get; set; }
            public object auto_capture { get; set; }
            public object auto_capture_at { get; set; }
            public object branding_id { get; set; }
            public object google_analytics_client_id { get; set; }
            public object google_analytics_tracking_id { get; set; }
            public string version { get; set; }
            public object acquirer { get; set; }
            public object deadline { get; set; }
            public bool framed { get; set; }
            public BrandingConfig branding_config { get; set; }
            public object invoice_address_selection { get; set; }
            public object shipping_address_selection { get; set; }
            public object fee_vat { get; set; }
            public bool moto { get; set; }
            public object customer_email { get; set; }
        }
        public class Shipping
        {
            public object method { get; set; }
            public string company { get; set; }
            public object amount { get; set; }
            public object vat_rate { get; set; }
            public string tracking_number { get; set; }
            public string tracking_url { get; set; }
        }
        public class BrandingConfig
        {
        }
        public class Variables
        {
        }
    }
}
