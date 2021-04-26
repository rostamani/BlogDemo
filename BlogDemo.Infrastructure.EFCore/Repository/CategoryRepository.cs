using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogDemo.Application.Contracts.Category;
using BlogDemo.Domain.CategoryAgg;

namespace BlogDemo.Infrastructure.EFCore.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly BlogContext _db;

        public CategoryRepository(BlogContext db)
        {
            _db = db;
        }

        public void Create(Category category)
        {
            _db.Categories.Add(category);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return _db.Categories.Any(c => c.Name == name);
        }

        public Category Get(int id)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public List<CategoryViewModel> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
