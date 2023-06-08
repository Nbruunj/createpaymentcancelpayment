using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text;
using System.Text.Json;

namespace createpaymingtoquickpay
{
    public class QuickpayLink
    {
        public async Task GetQuickpayLink(string apikey, string id, string prices, string username, string email)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://api.quickpay.net/payments/{id}/link");
            var passwordbytes = Encoding.UTF8.GetBytes($":{apikey}");
            string passwordencoding = Convert.ToBase64String(passwordbytes);
            request.Headers.Add("Accept-Version", "v10");
            Console.WriteLine(prices);
            request.Headers.Add("Authorization", $"Basic {passwordencoding}");
            string json = "{\"amount\": \"" + prices + "\"}";
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObj = JsonSerializer.Deserialize<JsonElement>(responseJson);
            var url = responseObj.GetProperty("url").GetString();
            Console.WriteLine(url);
            PostMailData postMailData = new PostMailData();
            postMailData.PostDataToMailService(url, username,email, id, prices);
            


        }
    }
}
