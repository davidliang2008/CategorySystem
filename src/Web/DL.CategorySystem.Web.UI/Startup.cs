using DL.CategorySystem.Framework.Mvc;
using DL.CategorySystem.Persistence.EFCore;
using DL.CategorySystem.Web.UI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.CategorySystem.Web.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string dbConnectionString = this.Configuration.GetConnectionString("AppDbConnection");
            string assemblyName = typeof(AppDbContext).Namespace;

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(dbConnectionString, optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(assemblyName)), ServiceLifetime.Singleton);

            services.AddSingleton<ICachedRouteDataProvider<int>, CategoryCachedRouteDataProvider>();

            services.AddMediatRService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ICachedRouteDataProvider<int> cachedRouteDataProvider, IMemoryCache memoryCache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.Routes.Add(new CachedRoute<int>(
                        controller: "category",
                        action: "index",
                        dataProvider: cachedRouteDataProvider,
                        cache: memoryCache,
                        target: routes.DefaultHandler)
                {
                    CacheTimeoutInSeconds = 900
                });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
