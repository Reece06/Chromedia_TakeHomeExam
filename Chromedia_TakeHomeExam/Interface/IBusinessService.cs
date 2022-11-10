using Chromedia_TakeHomeExam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chromedia_TakeHomeExam.Interface
{
    public interface IBusinessService
    {
        Task FetchAllArticles();

        IList<Article> GetArticleList();
        IList<string> GetTopArticlesByLimit(int limit);
    }
}
