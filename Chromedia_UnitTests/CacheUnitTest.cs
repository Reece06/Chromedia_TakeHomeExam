using Chromedia_TakeHomeExam.Interface;
using Chromedia_TakeHomeExam.Models;
using Chromedia_TakeHomeExam.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chromedia_UnitTests
{
    [TestClass]
    public class CacheUnitTest
    {

        private ICache cache;

        [TestInitialize]
        public void Initialize()
        {
            var meme = new MemoryCache(new MemoryCacheOptions());
            cache = new Cache(meme);
        }

        [TestMethod]
        public void GetAndSetCache()
        {
            string key = "testKey";
            object testObject = new { test = "tests", testI = 1};
            cache.SetCache(testObject, key);

            var item = cache.GetFromCache<object>(key);


            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void NoValueFetchCache()
        {
            string key = "testKey";
            var item = cache.GetFromCache<object>(key);

            Assert.IsNull(item);
        }

        [TestMethod]
        public void GetAndSetArticleCache()
        {
            string key = "testKey";
            var testObject = new Article{ Author = "test", Num_Comments= 123};
            cache.SetCache<Article>(testObject, key);

            var item = cache.GetFromCache<Article>(key);

            Assert.IsNotNull(item);
            Assert.AreEqual("test", item.Author);
            Assert.AreEqual(123, item.Num_Comments);
            Assert.IsNull(item.Story_ID);
        }

        [TestMethod]
        public void GetAndSetArticleListCache()
        {
            string key = "testKey";
            var testObject = new ArticleList { Page = 2, Total_Pages = 2, Data = new List<Article>()};
            cache.SetCache<ArticleList>(testObject, key);

            var item = cache.GetFromCache<ArticleList>(key);

            Assert.IsNotNull(item);
            Assert.AreEqual(2, item.Page);
            Assert.AreEqual(2, item.Total_Pages);
            Assert.IsTrue(item.Data.Count == 0);
        }
    }
}
