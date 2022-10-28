using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrenExplorer.Data;
using PrenExplorer.Models;
using PrenExplorer.Services;
using PrenExplorer.UoW;

namespace PrenExplorer
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
            services.AddDbContext<NewGenContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<NPUser, IdentityRole>(
               opts =>
               {
                   opts.Password.RequireDigit = false;
                   opts.Password.RequiredLength = 5;
                   opts.Password.RequireNonAlphanumeric = false;
                   opts.Password.RequireUppercase = false;
               }).AddEntityFrameworkStores<NewGenContext>()
                 .AddTokenProvider<DataProtectorTokenProvider<NPUser>>(TokenOptions.DefaultProvider);

            //services.AddIdentityCore<CustomerUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<TenantDataContext>()
            //    .AddTokenProvider<DataProtectorTokenProvider<CustomerUser>>(TokenOptions.DefaultProvider);

            //services.AddIdentityCore<NPUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<NewGenContext>()
            //    .AddTokenProvider

            services.AddTransient<UnitOfWork>();
            services.AddTransient<AccountService>();
            services.AddTransient<ProjectService>();
            services.AddTransient<LevelService>();
            services.AddTransient<UserProjectService>();
            services.AddControllersWithViews();
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }

        
    }
}