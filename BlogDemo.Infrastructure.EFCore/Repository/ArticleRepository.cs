using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogDemo.Application.Contracts.Article;
using BlogDemo.Domain.ArticleAgg;

namespace BlogDemo.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogContext _db;

        public ArticleRepository(BlogContext db)
        {
            _db = db;
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _db.Articles.Where(a => a.IsRemoved==false).Select(a => new ArticleViewModel
            {
                ArticleId = a.ArticleId,
                Picture = a.Picture,
                PictureAlt = a.PictureAlt,
                ShortDescription = a.ShortDescription,
                Title = a.Title,
                Body = a.Body
            }).ToList();
        }

        public ArticleViewModel ShowArticle(int id)
        {
            return _db.Articles.Select(a => new ArticleViewModel()
            {
                ArticleId = a.ArticleId,
                Picture = a.Picture,
                PictureAlt = a.PictureAlt,
                ShortDescription = a.ShortDescription,
                Title = a.Title,
                Body = a.Body
            }).FirstOrDefault(a => a.ArticleId == id);
        }

        public void Create(Article article)
        {
            _db.Articles.Add(article);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public Article Get(int id)
        {
            return _db.Articles.FirstOrDefault(a => a.ArticleId == id);
        }
    }
}
