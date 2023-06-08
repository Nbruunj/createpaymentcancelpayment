using createpaymingtoquickpay.model;
using RestSharp;
using System.Text;
using System.Text.Json;

namespace createpaymingtoquickpay
{
    public class CreateQuickpayPayment
    {
        public async Task CreatePayment(string apikey,string orderid, string kundeurl, string price, string username, string email)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.quickpay.net/payments");
            var passwordbytes = Encoding.UTF8.GetBytes($":{apikey}");
            string passwordencoding = Convert.ToBase64String(passwordbytes);
            request.Headers.Add("Accept-Version", "v10");
            request.Headers.Add("Authorization", $"Basic {passwordencoding}");
            var orderidquick = orderid.Substring(0, 20);
            string json = "{\"currency\": \"dkk\",\"order_id\": \"" + orderidquick + "\",\"shopsystem_name\": \"" + kundeurl + "\",\"shipping[tracking_number]\": \"" + orderid + "\",\"shipping[tracking_url]\": \"" + apikey + "\"}";
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);     
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObj = JsonSerializer.Deserialize<Quickpay.Root>(responseJson);
            var ids = responseObj.id;
            string id = ids.ToString();
            var prices = price+00;
            

            Console.WriteLine($"Payment ID: {ids}");
            QuickpayLink quickpayLink = new QuickpayLink();
            quickpayLink.GetQuickpayLink(apikey, id, prices, username, email);




        }
    }
}
