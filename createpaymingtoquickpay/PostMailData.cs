using System;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace createpaymingtoquickpay
{
    public class PostMailData
    {
        public async Task PostDataToMailService(string url, string username, string email,string id, string prices)
        {
        
            var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://api.quickpay.net/payments");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7157/DynamicsEmailSender");
            //request.Headers.Add("Content-Type", "application/json");
            string json = "{\"id\": \"" + id + "\",\"username\": \"" + username + "\",\"email\": \"" + email + "\",\"url\": \"" + url + "\",\"price\": \"" + prices + "\"}";
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
