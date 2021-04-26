using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Application.Contracts.Article;
using BlogDemo.Domain.ArticleAgg;


namespace BlogDemo.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public void Create(CreateArticle command)
        {
            var article=new Article(command.Title,command.Picture,command.PictureAlt,command.ShortDescription,command.Body
            ,command.CategoryId);
            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.ArticleId);
            if (article!=null)
            {
                article.Edit(command.Title,command.Picture,command.PictureAlt,command.ShortDescription,command.Body,command.CategoryId);
                _articleRepository.SaveChanges();
            }
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetArticles();
        }

        public ArticleViewModel ShowArticle(int id)
        {
            return _articleRepository.ShowArticle(id);
        }
    }
}
