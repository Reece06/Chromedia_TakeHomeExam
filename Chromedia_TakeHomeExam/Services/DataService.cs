using Chromedia_TakeHomeExam.Interface;
using Chromedia_TakeHomeExam.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chromedia_TakeHomeExam.Services
{
    public class DataService : IDataService
    {

        protected HttpClient _client;

        public DataService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ArticleList> GetArticleByPage(int num)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://jsonmock.hackerrank.com/api/articles?page={num}");
            var response = await _client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            try
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ArticleList>(stringContent);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
