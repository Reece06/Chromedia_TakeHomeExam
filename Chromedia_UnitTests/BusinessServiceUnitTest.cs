using Chromedia_TakeHomeExam.Interface;
using Chromedia_TakeHomeExam.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chromedia_UnitTests
{
    [TestClass]
    public class BusinessServiceUnitTest
    {
        private IBusinessService _businessService;

        [TestInitialize]
        public void Initialize()
        {
            _businessService = new BusinesService(new Cache(new MemoryCache(new MemoryCacheOptions())), new DataService(new HttpClient()));
        }


        [TestMethod]
        public async Task GetAllArticles()
        {
            await _businessService.FetchAllArticles();
            var list = _businessService.GetArticleList();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }


        [TestMethod]
        public async Task GetAllArticlesWithLimit()
        {
            await _businessService.FetchAllArticles();
            var limited = _businessService.GetTopArticlesByLimit(2);

            Assert.IsNotNull(limited);
            Assert.IsTrue(limited.Count == 2);
        }
    }
}
