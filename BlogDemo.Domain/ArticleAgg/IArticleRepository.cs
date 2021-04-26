using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        Article Get(int id);
        void Create(Article article);
        void SaveChanges();
    }
}
