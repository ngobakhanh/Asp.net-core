using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference_Article;

namespace EnotsCompany.Models
{
    public class ArticleModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string ImageArticle { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string StatusArticle { get; set; }

        public Article[] articles { get; set; }
        public ServiceReference_Article.Article arclById { get; set; }
    }
}
