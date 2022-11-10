using Chromedia_TakeHomeExam.Interface;
using Chromedia_TakeHomeExam.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net.Http;

namespace Chromedia_TakeHomeExam
{
    public class Program
    {

        private static readonly ICache _cache = new Cache(new MemoryCache(new MemoryCacheOptions()));
        private static readonly IDataService _dataService = new DataService(new HttpClient());
        private static readonly IBusinessService _businessService = new BusinesService(_cache, _dataService);

        public static void Main(string[] args)
        {
            Console.WriteLine("Fetch the latest articles");
            string cont = "y";

            Console.WriteLine("\nLoading Article Lists ( Please Wait!! )...");
            var fetchTask = _businessService.FetchAllArticles();
            var taskComplete = true;
            if (!fetchTask.Wait(TimeSpan.FromMinutes(1)))
            {
                Console.WriteLine("Error encountered fetching the list of Articles");
                taskComplete = false;
            }
            Console.WriteLine("Article Lists Loaded!\n");

            while (cont == "y" || cont == "Y" && taskComplete)
            {
                Console.WriteLine("Please enter a number for your top article list : ");
                string input = Console.ReadLine().Trim();

                if (!int.TryParse(input, out int num))
                {
                    Console.WriteLine("Please input a valid number!!!");
                    continue;
                }

                Console.WriteLine($"\nTop {num} articles available\n");
                var articles = _businessService.GetTopArticlesByLimit(num);
                foreach(var article in articles)
                {
                    Console.WriteLine(article);
                }

                Console.WriteLine("\nDo you wish to try your list again? (Y/N) : ");
                cont = Console.ReadLine();
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
