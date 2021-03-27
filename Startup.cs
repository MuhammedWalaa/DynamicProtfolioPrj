using DynamicProtfolioPrj.Domain;
using DynamicProtfolioPrj.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DynamicProtfolioPrj
{
    public class Startup
    {
        #region Services
        private IConfiguration _configuration { get; }
        private readonly IWebHostEnvironment _environment;
        #endregion

        #region Constructor
        public Startup(IWebHostEnvironment environment)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.Development.json", optional: true)
            .AddEnvironmentVariables().Build();
            _environment = environment;
        }
        #endregion
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            #region DbContext
            services.AddDbContext<DynamicProtfolioContext>(options =>
            {
                options.UseSqlServer("Server=SQL5103.site4now.net;Database=DB_A71A2E_MohammedWalaa;User Id=DB_A71A2E_MohammedWalaa_admin;Password=01118034187aA");
            });

            #endregion

            services.RegisterServices();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
