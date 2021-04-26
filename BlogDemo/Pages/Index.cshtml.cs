using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Application.Contracts.Article;
using BlogDemo.Application.Contracts.Category;
using BlogDemo.Domain.ArticleAgg;

namespace BlogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public List<ArticleViewModel> Articles { get; set; }

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }


        public void OnGet()
        {
            Articles = _articleApplication.GetArticles();
        }
    }
}
