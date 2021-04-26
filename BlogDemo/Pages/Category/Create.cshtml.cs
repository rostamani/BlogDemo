using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Application.Contracts.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogDemo.Pages.Category
{
    public class CreateModel : PageModel
    {
        public CreateCategory CreateCategory { get; set; }
        private readonly ICategoryApplication _categoryApplication;

        public CreateModel(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }
        public void OnGet()
        {

        }

        public void OnPost(CreateCategory createCategory)
        {
            if (ModelState.IsValid)
            {
                _categoryApplication.Create(createCategory);
            }

            else
            {
                
            }
        }
    }
}
