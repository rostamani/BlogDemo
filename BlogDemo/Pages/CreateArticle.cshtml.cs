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
    public class CreateArticleModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly ICategoryApplication _categoryApplication;

        public CreateArticle CreateArticle { get; set; }
        public SelectList Categories { get; set; }

        public CreateArticleModel(IArticleApplication articleApplication, ICategoryApplication categoryApplication)
        {
            _articleApplication = articleApplication;
            _categoryApplication = categoryApplication;
        }

        public void OnGet()
        {
            Categories=new SelectList(_categoryApplication.Search(""),"Id","Name");
        }

        public IActionResult OnPost(CreateArticle createArticle,IFormFile imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    createArticle.Picture = Guid.NewGuid().ToString() + Path.GetExtension(imageUpload.FileName);
                    string directoryToSaveImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Pictures", createArticle.Picture);
                    using (var stream = new FileStream(directoryToSaveImage, FileMode.Create))
                    {
                        imageUpload.CopyTo(stream);
                    }
                }
                else
                {
                    createArticle.Picture = "Default.jpg";
                }
                _articleApplication.Create(createArticle);
                return RedirectToPage("./Index");
            }

            return Page();

        }
    }
}
