using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Application.Contracts.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogDemo.Pages.Category
{
    public class IndexModel : PageModel
    {
        public List<CategoryViewModel> Categories { get; set; }

        private readonly ICategoryApplication _categoryApplication;

        public IndexModel(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public void OnGet(string name)
        {
            Categories = _categoryApplication.Search(name);
        }
    }
}
