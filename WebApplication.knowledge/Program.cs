using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebApplication.knowledge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            //HttpContext.SignInAsync("AdminUser", identityPrincipal);
            //identity.AddClaim(new Claim(ClaimTypes.Role, "AdminUser"));

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
