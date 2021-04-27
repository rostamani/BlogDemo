using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Application.Contracts.Category;
using BlogDemo.Domain.CategoryAgg;

namespace BlogDemo.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public EditCategory GetDetails(int id)
        {
            return _categoryRepository.GetDeatils(id);
        }

        public void Create(CreateCategory command)
        {
            if (!_categoryRepository.Exists(command.Name))
            {
                var category = new Category(command.Name);
                _categoryRepository.Create(category);
                _categoryRepository.SaveChanges();
            }
        }

        public void Edit(EditCategory command)
        {
            var category = _categoryRepository.Get(command.Id);
            if (category!=null)
            {
                category.Edit(command.Name);
                _categoryRepository.SaveChanges();
            }
        }

        public List<CategoryViewModel> Search(string name)
        {
            return _categoryRepository.Search(name);
        }
    }
}
