using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
