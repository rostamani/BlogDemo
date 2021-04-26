using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Application.Contracts.Category;

namespace BlogDemo.Domain.CategoryAgg
{
    public interface ICategoryRepository
    {
        bool Exists(string name);
        Category Get(int id);
        void Create(Category category);
        void SaveChanges();
        List<CategoryViewModel> Search(string name);
    }
}
