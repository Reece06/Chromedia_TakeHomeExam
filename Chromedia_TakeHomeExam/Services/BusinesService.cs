using Chromedia_TakeHomeExam.Interface;
using Chromedia_TakeHomeExam.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chromedia_TakeHomeExam.Services
{
    public class BusinesService : IBusinessService
    {
        private readonly ICache _cache;
        private readonly IDataService _dataService;
        private List<Article> AllArticles = new List<Article>();
        private string key = "page";


        public BusinesService(ICache cache, IDataService dataService)
        {
            _cache = cache;
            _dataService = dataService;
        }

        public async Task FetchAllArticles()
        {
            var pageCounter = 1;
            ArticleList fetched;

            do
            {
                //get from cache
                fetched = _cache.GetFromCache<ArticleList>(key + pageCounter);

                if (fetched == null)
                {
                    //then get from service
                    fetched = await _dataService.GetArticleByPage(pageCounter);
                    _cache.SetCache<ArticleList>(fetched, key + pageCounter);
                }

                AllArticles.AddRange(fetched.Data);
                pageCounter++;
            } while (pageCounter <= fetched.Total_Pages);

        }

        public IList<Article> GetArticleList()
        {
            return AllArticles;
        }

        public IList<string> GetTopArticlesByLimit(int limit)
        {
            return AllArticles.Where(x =>
                    //Remove all items with empty title ANNNDD story title
                    !string.IsNullOrEmpty(x.Title) || !string.IsNullOrEmpty(x.Story_Title))
                    //Get the title OR StoryTitle AANND comments only
                    .Select(x =>
                    {
                        return new
                        {
                            title = x.Title ?? x.Story_Title,
                            comments = x.Num_Comments
                        };
                    }) 
                    //Sort by Number of Comments then by Title
                    .OrderByDescending(x => x.comments)
                    .ThenBy(x => x.title)
                    //Take the limit
                    .Take(limit)
                    //get the titles
                    .Select(x => x.title)
                    .ToList();
        }
    }
}
