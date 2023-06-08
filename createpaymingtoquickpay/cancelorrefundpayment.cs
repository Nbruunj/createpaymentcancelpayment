using System.Diagnostics;
using System.Text;
using System.Text.Json;
using createpaymingtoquickpay.model;

namespace createpaymingtoquickpay
{
    public class cancelorrefundpayment
    {
        public async Task cancelorrefundkursist(string orderid, string apikey)
        
        {
            var orderidquick = orderid.Substring(0, 20);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.quickpay.net/payments?order_id={orderidquick}");
            var passwordbytes = Encoding.UTF8.GetBytes($":{apikey}");
            string passwordencoding = Convert.ToBase64String(passwordbytes);
            request.Headers.Add("Accept-Version", "v10");
            request.Headers.Add("Authorization", $"Basic {passwordencoding}");
            
            var response = await client.SendAsync(request);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObj = JsonSerializer.Deserialize<List<Quickpay.Root>>(responseJson);
            var quickpayroot = responseObj.First();
            var qucikpaylink = quickpayroot.link.ToString();
            JsonDocument doc = JsonDocument.Parse(qucikpaylink);
            var price = doc.RootElement.GetProperty("amount").GetInt64();
            var ids = quickpayroot.id;
            string id = ids.ToString();
            var state = quickpayroot.state;
            Console.WriteLine(state);

            if(state == "processed")//virker
            {
                
                var request2 = new HttpRequestMessage(HttpMethod.Post, $"https://api.quickpay.net/payments/{id}/refund");
                request2.Headers.Add("Accept-Version", "v10");
                request2.Headers.Add("Authorization", $"Basic {passwordencoding}");
                string amountjson = "{\"amount\": \"" + price + "\"}";
                var content2 = new StringContent(amountjson, null, "application/json");
                request2.Content = content2;
                var response2 = await client.SendAsync(request2);
                Console.WriteLine(await response2.Content.ReadAsStringAsync());
                Console.WriteLine("processed");
            }
            else if(state == "new")//virker 
            {
                var request3 = new HttpRequestMessage(HttpMethod.Post, $"https://api.quickpay.net/payments/{id}/cancel");
                request3.Headers.Add("Accept-Version", "v10");
                request3.Headers.Add("Authorization", $"Basic {passwordencoding}");
                var response3 = await client.SendAsync(request3);
                Console.WriteLine(await response3.Content.ReadAsStringAsync());
                Console.WriteLine("new");
            }
            else if (state == "initial")//virker 
            {
                var request4 = new HttpRequestMessage(HttpMethod.Delete, $"https://api.quickpay.net/payments/{id}/link");
                request4.Headers.Add("Accept-Version", "v10");
                request4.Headers.Add("Authorization", $"Basic {passwordencoding}");
                var response4 = await client.SendAsync(request4);
                Console.WriteLine(await response4.Content.ReadAsStringAsync());
                Console.WriteLine("initial");
            }

        }
    }
}
