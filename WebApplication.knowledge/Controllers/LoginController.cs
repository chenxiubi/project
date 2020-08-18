using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.knowledge.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,"张三"),
                new Claim(ClaimTypes.NameIdentifier,"身份证号"),
                new Claim(ClaimTypes.Role,"AdminUser"),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var identityPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("AdminUser", identityPrincipal,new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddDays(1)
            });
            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Index2()
        {
            //
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,"李四"),
                new Claim("Administrator","Administrator"),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var identityPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, identityPrincipal, new AuthenticationProperties());
            return RedirectToAction("Index", "Employee");
        }
    }
}
