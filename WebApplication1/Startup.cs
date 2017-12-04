using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }      
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json");

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeting, Greeting>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();

            services.AddEntityFrameworkMySql();
            services.AddDbContext<RestaurantDbContext>(options =>
            {
                options.UseMySql("Server=localhost;Port=3306;Database=test;Uid=root;Pwd=root;");
                
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeting greeting)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseMvc(ConfigureRoute);
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
