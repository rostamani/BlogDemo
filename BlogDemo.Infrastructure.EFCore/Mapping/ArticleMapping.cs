using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDemo.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(b => b.ArticleId);
            builder.Property(a => a.Title).HasMaxLength(250).IsRequired();
            builder.Property(a => a.ShortDescription).HasMaxLength(500).IsRequired();

            builder.Property(a => a.Body).IsRequired();
            
            builder.HasOne(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
        }
    }
}
