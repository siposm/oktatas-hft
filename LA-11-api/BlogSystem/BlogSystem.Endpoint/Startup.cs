using BlogSystem.Data;
using BlogSystem.Logic;
using BlogSystem.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // enable controllers

            // IoC
            services.AddTransient<IBlogLogic, BlogLogic>();
            services.AddTransient<ICommentLogic, CommentLogic>();

            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<DbContext, BlogContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // localhost:0123/ALMA --> ALMA kontrollerhez fordul
            });
        }
    }
}
