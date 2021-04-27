using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Application.Contracts.Article;

namespace BlogDemo.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        Article Get(int id);
        List<ArticleViewModel> GetArticles();
        ArticleViewModel ShowArticle(int id);
        EditArticle GetDetails(int id);
        void Create(Article article);
        void SaveChanges();
        void Remove(int id);
        void Restore(int id);
    }
}
