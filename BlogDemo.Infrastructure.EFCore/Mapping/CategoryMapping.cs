using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDemo.Infrastructure.EFCore.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(250).IsRequired();
           
            builder.HasMany(c => c.Articles).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);
        }
    }
}
