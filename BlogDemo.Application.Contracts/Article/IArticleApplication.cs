using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        void Remove(int id);
        void Restore(int id);
        List<ArticleViewModel> GetArticles();
        ArticleViewModel ShowArticle(int id);
        EditArticle GetDetails(int id);
    }
}
