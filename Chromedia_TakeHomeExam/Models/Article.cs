using System;
using System.Collections.Generic;
using System.Text;

namespace Chromedia_TakeHomeExam.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string Author { get; set; }
        public int? Num_Comments { get; set; }
        public int? Story_ID { get; set; }
        public string Story_Title { get; set; }
        public string Story_URL { get; set; }
        public int? ParentId { get; set; }
        public string Created_At { get; set; }
    }
}
