using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JobAdScraper.Models;


namespace JobAdScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (httpResponse.IsSuccessStatusCode)
            {
                var contentString = await httpResponse.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<Post>>(contentString);
            }
        }
    }
}
