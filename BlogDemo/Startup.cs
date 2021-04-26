using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Application;
using BlogDemo.Application.Contracts.Article;
using BlogDemo.Application.Contracts.Category;
using BlogDemo.Domain.ArticleAgg;
using BlogDemo.Domain.CategoryAgg;
using BlogDemo.Infrastructure.EFCore;
using BlogDemo.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<ICategoryApplication, CategoryApplication>();

            services.AddDbContext<BlogContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("BlogDemoConnectionString"));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
