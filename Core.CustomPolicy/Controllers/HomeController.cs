using Core.CustomPolicy.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.CustomPolicy.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 自定义策略
        /// 属性(Authorize) => PolicyProvider(策略方法) => (注册策略处理类) => RequirementHandler => 获取角色数据，判断是否能进入该页面。
        /// </summary>
        /// <returns></returns>
        [PermissionAuthorize("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            var returnUrl = HttpContext.Request.Query["ReturnUrl"];
            returnUrl = "/Home/Privacy";
            string roleType = "";
            if (username == "admin")
            {
                roleType = "Administrator";
            }
            else if (username == "custom")
            {
                roleType = "Custom";
            }
            if ((username == "admin" && password == "admin") || (username == "custom" && password == "custom"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,username),
                    new Claim("Role",roleType),
                    new Claim(ClaimTypes.Role,roleType)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties());

                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return Redirect("/Home/Index");
            }
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return Redirect("/Home/Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult NotPermission()
        {
            return View();
        }
    }
}
