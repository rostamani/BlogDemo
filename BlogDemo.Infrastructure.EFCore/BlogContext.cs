using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Domain.ArticleAgg;
using BlogDemo.Domain.CategoryAgg;
using BlogDemo.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Infrastructure.EFCore
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
