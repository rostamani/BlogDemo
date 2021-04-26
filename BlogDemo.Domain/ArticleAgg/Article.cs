using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Domain.CategoryAgg;

namespace BlogDemo.Domain.ArticleAgg
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }

        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public Article(string title,string picture,string pictureAlt,string shortDescription,string body,int categoryId)
        {
            Title = title;
            Body = body;
            Picture = picture;
            PictureAlt = pictureAlt;
            ShortDescription = shortDescription;
            CategoryId = categoryId;
            CreationDate = DateTime.Now;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }

        public void Edit(string title, string picture, string pictureAlt, string shortDescription, string body,int categoryId)
        {
            Title = title;
            Body = body;
            Picture = picture;
            PictureAlt = pictureAlt;
            ShortDescription = shortDescription;
            CategoryId = categoryId;
        }

    }
}
