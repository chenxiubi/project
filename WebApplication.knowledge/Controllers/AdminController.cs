using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.knowledge.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "AdminUser")]
    public class AdminController : Controller
    {
        //private readonly IMyDependency _myDependency;

        public AdminController()
        {
            //this._myDependency = myDependency;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}