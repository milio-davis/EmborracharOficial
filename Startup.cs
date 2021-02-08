using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emb.Context;
using emb.Interfaces;
using emb.Models;
using emb.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace emb
{
    public class Startup
    {

        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection"),x => x.MigrationsAssembly("emb")));

            services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            services.AddTransient<IRepositorioCategoria, RepositorioCategoria>();
            services.AddTransient<IRepositorioProducto, RepositorioProducto>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRepositorioOrden, RepositorioOrden>();
            services.AddScoped(sp => Carrito.GetCarrito(sp));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddMemoryCache();
            services.AddSession();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseIdentity();

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "filtroCategoria",
                    template: "Producto/{action}/{categoria}",
                    defaults: new { Controller = "Producto", action = "Lista" });

            });

            var dbContext = serviceProvider.GetService<AppDbContext>();

            DbInitializer.Seed(app);



            //await CreateRoles(serviceProvider);
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Gerente"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                // ensure that the role does not exist
                if (!roleExist)
                {
                    //create the roles and seed them to the database: 
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // find the user with the admin email 
            var _user = await UserManager.FindByNameAsync("Admin");

            // check if the user exists
            if (_user == null)
            {
                //Here you could create the super admin who will maintain the web app
                var poweruser = new IdentityUser
                {
                    UserName = "Admin"
                };
                string adminPassword = "123321";

                var createPowerUser = await UserManager.CreateAsync(poweruser, adminPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }
    }
}
