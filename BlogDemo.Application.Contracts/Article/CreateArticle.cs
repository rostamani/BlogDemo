using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Application.Contracts.Article
{
    public class CreateArticle
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string Body { get; set; }
        public string PictureTitle { get; set; }
    }
}
