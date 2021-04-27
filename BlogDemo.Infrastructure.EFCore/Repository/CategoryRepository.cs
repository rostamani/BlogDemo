using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogDemo.Application.Contracts.Category;
using BlogDemo.Domain.CategoryAgg;
using BlogDemo.Helpers.Convertors;

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
            var query = _db.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationDate.ToPersianDate()
            });
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            return query.OrderBy(c => c.Name).ThenBy(c => c.Id).ToList();
        }

        public EditCategory GetDeatils(int id)
        {
            return _db.Categories.Select(c => new EditCategory()
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefault(c => c.Id == id);
        }
    }
}
