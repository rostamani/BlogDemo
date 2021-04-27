using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDemo.Application.Contracts.Article
{
    public class ArticleViewModel
    {

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public bool IsRemoved { get; set; }
    }
}
