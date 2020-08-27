using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApplication.knowledge
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("AdminUser").AddCookie("AdminUser");
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("Administrator"));
            });
            //services.AddSingleton<IAuthorizationHandler, MyHandler1>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Home/NotPermission");
                options.LoginPath = new PathString("/Login/Index2");
                options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AtLeast21", policy =>
                    policy.Requirements.Add(new MinimumAgeRequirement(21)));
            });
            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
            services.AddControllers();
            //services.AddControllersWithViews();
            services.AddMvc();
            //services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>();
            //services.AddScoped<IMyDependency, MyDependency>();

            //services.AddTransient(ctx =>
            //new AdminController(new MyDependency()));

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Admin}/{action=Index}");
            });
        }
    }
}
