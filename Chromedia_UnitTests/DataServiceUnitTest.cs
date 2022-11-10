using Chromedia_TakeHomeExam.Interface;
using Chromedia_TakeHomeExam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chromedia_UnitTests
{
    [TestClass]
    public class DataServiceUnitTest
    {

        private IDataService dataService;

        [TestInitialize]
        public void Initialize()
        {
            var client = new HttpClient();
            dataService = new DataService(client);
        }

        [TestMethod]
        public async Task GetArticlePage1()
        {
           
            var result = await dataService.GetArticleByPage(1);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public async Task GetArticlePage2()
        {
            var result = await dataService.GetArticleByPage(2);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public async Task GetArticlePage3()
        {
            var result = await dataService.GetArticleByPage(3);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public async Task GetArticlePage4()
        {
            var result = await dataService.GetArticleByPage(4);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }


        [TestMethod]
        public async Task GetArticlePage5()
        {
            var result = await dataService.GetArticleByPage(5);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public async Task GetArticlePage_NoArticle()
        {
            var result = await dataService.GetArticleByPage(6);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Data.Count == 0);
        }


    }
}
