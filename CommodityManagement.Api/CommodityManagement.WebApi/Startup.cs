using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommodityManagement.Repository;
using CommodityManagement.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace CommodityManagement.WebApi
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
            //数据库上下文注册
            var connection = Configuration.GetConnectionString("MySQL");
            services.AddDbContext<MyDbContext>(options =>
            options.UseMySql(connection, build => build.MigrationsAssembly("CommodityManagement.WebApi")));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //依赖注入
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICommodityService,CommodityService>();

#if DEBUG
            //Swagger的配置
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CommodityManagement.WebApi"
                });

                //应用程序基本路径。
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //注释路径。
                var serviceXmlPath = Path.Combine(basePath, "CommodityManagement.Service.xml");
                options.IncludeXmlComments(serviceXmlPath);
                var webapiXmlPath = Path.Combine(basePath, "CommodityManagement.WebApi.xml");
                options.IncludeXmlComments(webapiXmlPath);
            });
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommodityManagement.WebApi.xml");
            });
#endif
        }
    }
}
