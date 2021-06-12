using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using LoL1Shot.Data;
using LoL1Shot.Infrastructure;
using net10.Utils;

namespace Projekt.NET
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
        { //filtry
            //services.AddRazorPages().AddMvcOptions(options =>
            //{
            //    options.Filters.Add(new CustomPageFilter(Configuration));
            //});
            services.AddAuthentication("CookieAuthentication")
            .AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.HttpOnly = true;
                config.Cookie.SecurePolicy = CookieSecurePolicy.None;
                config.Cookie.Name = "UserLoginCookie";
                config.LoginPath = "/Login/UserLogin";
                config.Cookie.SameSite = SameSiteMode.Strict;
            });
            // dodajemy strony ktore wymagaja autoryzacji (profil uzytkownika)

            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizePage("/Login/DummyLoginPage");
                options.Conventions.AuthorizePage("/CRUD_Combo/Add");
                options.Conventions.AuthorizePage("/CRUD_Combo/Update");
                options.Conventions.AuthorizePage("/CRUD_Combo/Delete");
            });

            services.Add(new ServiceDescriptor(typeof(IComboDB), new ComboSqlDB(Configuration)));
            services.Add(new ServiceDescriptor(typeof(IActionDB), new ActionApiDB(Configuration)));
            //korzystanie z bazy XML => new ComboXmlDB(Configuration)
            //korzystanie z bazy SQL => new ComboSqlDB(Configuration)

            services.AddRazorPages();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("OneShotDB"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //TODO fix middleware
            //app.UseImageMiddleware();
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

            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
