using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Application.Contracts.Article;
using BlogDemo.Application.Contracts.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogDemo.Pages
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly ICategoryApplication _categoryApplication;


        [BindProperty]
        public EditArticle EditArticle { get; set; }
        public SelectList Categories { get; set; }

        public EditModel(IArticleApplication articleApplication, ICategoryApplication categoryApplication)
        {
            _articleApplication = articleApplication;
            _categoryApplication = categoryApplication;
        }


        public void OnGet(int id)
        {
            EditArticle = _articleApplication.GetDetails(id);
            Categories = new SelectList(_categoryApplication.Search(""), "Id", "Name");
        }

        public IActionResult OnPost(IFormFile imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    if (EditArticle.Picture == null)
                    {
                        EditArticle.Picture = Guid.NewGuid().ToString() + Path.GetExtension(imageUpload.FileName);
                    }
                    string directoryToSaveImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Pictures", EditArticle.Picture);
                    using (var stream = new FileStream(directoryToSaveImage, FileMode.Create))
                    {
                        imageUpload.CopyTo(stream);
                    }
                }
                _articleApplication.Edit(EditArticle);
                return RedirectToPage("Index");
            }

            else
            {
                return RedirectToPage("Edit",new{id=EditArticle.ArticleId});
            }
        }
    }
}
