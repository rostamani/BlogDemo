using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Application.Contracts.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogDemo.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly ICategoryApplication _categoryApplication;

        public EditModel(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [BindProperty]
        public EditCategory EditCategory { get; set; }

        public void OnGet(int id)
        {
            EditCategory = _categoryApplication.GetDetails(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _categoryApplication.Edit(EditCategory);
                return RedirectToPage("Index");
            }

            return RedirectToPage("Edit",new {id=EditCategory.Id});

        }
    }
}
