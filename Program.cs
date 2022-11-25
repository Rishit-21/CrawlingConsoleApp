using CrawlingConsoleApp.Models;
using HtmlAgilityPack;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlingConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            StartCrwlerAsync();
            Console.ReadLine();

        }
        public static async Task StartCrwlerAsync()
        {
            var Url = "https://ineichen.com/auctions/past/";
           // var Url = "https://food-site-redux.netlify.app/#/burgers/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(Url);

            var htmlDocument = new HtmlDocument();
            //htmlDocument.Load(Url);
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                        .Where(node => node.GetAttributeValue("Class", "")
                        .Equals("auction-item"))
                        .ToList();

            foreach (var div in divs)
            {
                var divsTitle = div?.SelectSingleNode($"div[@class='auction-item__title']//h2")?.InnerText.ToString().Trim() ?? string.Empty;

                var dateDesc = div?.SelectSingleNode($".//div[@class='auction-date-location__item'][1]").InnerText.Trim().ToString() ?? string.Empty;

                var description = dateDesc + " " + div?.SelectSingleNode($".//div[@class='auction-date-location__item'][2]").InnerText.Trim().ToString() ?? string.Empty;

                var divsImgUrl = "https://ineichen.com" + div?.SelectNodes($"a//img")?.FirstOrDefault().ChildAttributes("src")?.FirstOrDefault().Value.ToString() ?? string.Empty;

                var link = "https://ineichen.com" + div?.SelectNodes($"a")?.FirstOrDefault().ChildAttributes("href")?.FirstOrDefault().Value.ToString() ?? string.Empty;

                var lotCounts = Regex.Match(div.SelectSingleNode($"div[@class='auction-item__btns'][1]//a").InnerText, @"\d+").ToString().ToString() ?? string.Empty;

                var startDate = Regex.Match(dateDesc, @"\d+").ToString();
                var startMonth = startDate != null ? Regex.Match(dateDesc, @"\d+\s?(\w+)").Groups[1].ToString() : "";
                var startyear = startDate != null ? Regex.Match(dateDesc, @"\d{4}").ToString() : "";
                var StartTime = startDate != null ? Regex.Match(dateDesc, @"\d+\s?\w+?,?\s?(\d+.?:?\d+\s\(?\w+\)?)").Groups[1].ToString() : "";

                var EndDate = startDate != null ? Regex.Match(dateDesc, @"-\s?(\d+)").Groups[1].Value : "";
                var EndMonth = startDate != null ? Regex.Match(dateDesc, @"-\s\d+\s?(\w+)").Groups[1].ToString() : "";
                var EndYear = startDate != null ? Regex.Match(dateDesc, @"-\s?\d+\s\w+\s(\d{4})").Groups[1].Value : "";
                var EndTime = startDate != null ? Regex.Match(dateDesc, @"-\s?\d+\s?\w+?,?\s?(\d+.?:?\d+\s\(?\w+\)?)").Groups[1].ToString() : "";

                Auctions auctions = new Auctions()
                {
                    Title = divsTitle.ToString(),
                    Description = description.ToString(),
                    ImageUrl = divsImgUrl.ToString(),
                    Link = link.ToString(),
                    LotCount = lotCounts,

                    StartDate = startDate.ToString(),
                    StartMonth = startMonth.ToString(),
                    StartTime = StartTime.ToString(),
                    StartYear = startyear.ToString(),

                    EndDate = EndDate.ToString(),
                    EndMonth = EndMonth.ToString(),
                    EndTime = EndTime.ToString(),
                    EndYear = EndYear.ToString()
                };

                CrawlingInfoContext context = new CrawlingInfoContext();
                context.Auctions.Add(auctions);
                context.SaveChanges();
                Console.WriteLine(1);
            }
        }
    }
}
