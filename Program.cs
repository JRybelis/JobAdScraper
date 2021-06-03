using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using JobAdScraper.Models;
using Microsoft.VisualBasic;
using ScrapySharp.Extensions;
using ScrapySharp.Network;


namespace JobAdScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var httpClient = new HttpClient();
            //var httpResponsePost = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            //var httpResponseUser = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            //if (httpResponsePost.IsSuccessStatusCode)
            //{
            //    var contentString = await httpResponsePost.Content.ReadAsStringAsync();
            //    var posts = JsonConvert.DeserializeObject<List<Post>>(contentString);

            //    var filteredPosts = posts.Where(post => post.Id <= 50);

            //    foreach (var post in filteredPosts)
            //    {
            //        Console.WriteLine($"Post: id {post.Id}, name {post.Title}.");
            //    }

            //    Console.WriteLine();
            //    posts.ForEach(post => Console.WriteLine($"Post: id {post.Id}, name {post.Title}."));
            //}

            //if (httpResponseUser.IsSuccessStatusCode)
            //{
            //    var contentString = await httpResponseUser.Content.ReadAsStringAsync();
            //    var users = JsonConvert.DeserializeObject<List<User>>(contentString);

            //    var filteredUsers = users.Where(user => user.Id <= 50);

            //    foreach (var user in filteredUsers)
            //    {
            //        Console.WriteLine($"User: id {user.Id}, name {user.Username}.");
            //    }

            //    Console.WriteLine();
            //    users.ForEach(user => Console.WriteLine($"User: id {user.Id}, name {user.Username}, e-mail {user.Email}."));
            //    Console.WriteLine();
            //    var SamanthaUser = users.Where(user => user.Username == "Samantha").Select(user => user.Username).FirstOrDefault();
            //    Console.WriteLine(SamanthaUser);
            //}

            Console.WriteLine();
            //var scrapingInterval = new System.Timers.Timer();
            //scrapingInterval.Elapsed += new ElapsedEventHandler(WebScrape()
            //)
          WebScrape();

        }
        public static void WebScrape()
        {
            ScrapingBrowser browser = new ScrapingBrowser();
            for (int i = 0; i <= 300; i+=20)
            {
                WebPage homepPage =
                    browser.NavigateToPage(new Uri($"https://www.cvonline.lt/lt/search?limit=20&offset=" + i + "&categories%5B0%5D=INFORMATION_TECHNOLOGY&towns%5B0%5D=540&isHourlySalary=false&isRemoteWork=true"));

                var html = homepPage.Html;
                //var nodes = html.CssSelect(".vacancy-item__content a .vacancy-item__title");
                var nodes = html.CssSelect(".vacancy-item__title");
                var jobTitles = nodes.Where(n => n.InnerText.Contains(".NET")).Select(n => n.InnerText);
            }

                
        }
    }
}
