using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using VocabularyNetCore.Models.Approximating�lasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace VocabularyNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {

           
           
            services.AddDbContext<VocabularyContext>(config =>
            {
                config.UseInMemoryDatabase("Vocabulary");
            });

            


            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<VocabularyContext>()
               .AddDefaultTokenProviders();


            //services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", config => 
            //{
            //    config.Cookie.Name = "Grandmas.Cookie";
            //    config.LoginPath = "/Home/Authenticate";
            //});
            // ��������� ������������ � �������������
            services.AddControllersWithViews()
              // ������������� � asp.net.core 3
              .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


       

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            
            // ������� �������� � ��������� ����������� �� ������
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            

            app.UseRouting();

            // ��� ��� ������?
            app.UseAuthentication();
            //�� ������?
            app.UseAuthorization();

          

            // ��������� ��������� ������
            app.UseStaticFiles();

            // ����������� ���������
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute("default", "{Controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
