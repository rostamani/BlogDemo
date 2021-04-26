using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Domain.ArticleAgg;

namespace BlogDemo.Domain.CategoryAgg
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public List<Article> Articles { get; set; }

        public Category(string name)
        {
            Name = name;
            Articles=new List<Article>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}
