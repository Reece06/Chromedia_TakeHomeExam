using System;
using System.Collections.Generic;
using System.Text;

namespace Chromedia_TakeHomeExam.Models
{
    public class ArticleList
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public IList<Article> Data { get; set; }
    }
}
