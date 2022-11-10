using Chromedia_TakeHomeExam.Models;
using System.Threading.Tasks;

namespace Chromedia_TakeHomeExam.Interface
{
    public interface IDataService
    {
        Task<ArticleList> GetArticleByPage(int num);
    }
}
