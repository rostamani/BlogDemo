using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);
        void Edit(EditArticle command);
    }
}
