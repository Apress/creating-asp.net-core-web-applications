using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VideoStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO;
using VideoStore.CustomMiddleware;

namespace VideoStore
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
            _ = services.AddDbContextPool<VideoDbContext>(dbContextOptns =>
            {
                _ = dbContextOptns.UseSqlServer(
                    Configuration.GetConnectionString("VideoConn"));
            });

            _ = services.AddScoped<IVideoData, SQLData>();
            //_ = services.AddSingleton<IVideoData, TestData>(); // TODO: Change to scoped
            _ = services.AddRazorPages().AddSessionStateTempDataProvider();
            _ = services.AddSession();

            //_ = services.AddHsts(opts =>
            //{
            //    opts.Preload = true;
            //    opts.IncludeSubDomains = true;
            //    opts.MaxAge = TimeSpan.FromDays(60);
            //    opts.ExcludedHosts.Add("www.somesite.com");
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();                
            }
            else
            {
                _ = app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }

            _ = app.UseMyCustomMiddleware();

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();
            //_ = app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "StaticFiles")), RequestPath = "/StaticFiles"
            //});
                        
            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseSession();

            _ = app.UseEndpoints(endpoints =>
              {
                  _ = endpoints.MapRazorPages();
              });

            
        }
    }
}
