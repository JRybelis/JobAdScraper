using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Timers;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using ScrapySharp.Extensions;
using ScrapySharp.Network;


namespace JobAdScraper
{
    class Program
    {
        private static System.Timers.Timer _Timer;
        static async Task Main(string[] args)
        {
            //var scrapingInterval = new System.Timers.Timer();
            //scrapingInterval.Elapsed += new ElapsedEventHandler(WebScrape()
            //)
            SetTimer();
        }
        private static void SetTimer()
        {
            _Timer = new System.Timers.Timer(3000);
            _Timer.Elapsed += new ElapsedEventHandler(WebScrape);
            _Timer.AutoReset = true;
            _Timer.Enabled = true;
        }
        //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    Console.WriteLine(e.SignalTime);

        //}
        public static void WebScrape(object source, ElapsedEventArgs e)
        {
            //ScrapingBrowser browser = new ScrapingBrowser();
            List<string> jobsList = new List<string>();

            var scraper = new HtmlWeb();
            for (int i = 0; i <= 300; i += 20)
            {
                //WebPage homepPage =
                //    browser.NavigateToPage(new Uri($"https://www.cvonline.lt/lt/search?limit=20&offset=" + i + "&categories%5B0%5D=INFORMATION_TECHNOLOGY&towns%5B0%5D=540&isHourlySalary=false&isRemoteWork=true"));
                //var html = homepPage.Html;
                //var nodes = html.CssSelect(".vacancy-item__content a .vacancy-item__title");
                //var nodes = html.CssSelect(".vacancy-item__title");

                var page = scraper.Load($"https://www.cvonline.lt/lt/search?limit=20&offset=" + i + "&categories%5B0%5D=INFORMATION_TECHNOLOGY&towns%5B0%5D=540&isHourlySalary=false&isRemoteWork=true");
                var nodes = page.DocumentNode.CssSelect(".vacancy-item__title");
                var jobTitles = nodes.Where(n => n.InnerText.Contains(".NET")).OrderBy(n => n.InnerText).Select(n => n.InnerText).ToList();

                foreach (var currentJobTitle in jobTitles)
                {
                    jobsList.Add(currentJobTitle);
                }
            }
            //return jobsList;
            Console.WriteLine(jobsList);
        }
    }
}
