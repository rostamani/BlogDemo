using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Application.Contracts.Article;
using BlogDemo.Domain.ArticleAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogDemo.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public ArticleViewModel Article { get; set; }


        public DetailsModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }
        public void OnGet(int id)
        {
            Article = _articleApplication.ShowArticle(id);
        }
    }
}
