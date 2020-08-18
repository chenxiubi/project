using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.knowledge.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Policy = "Administrator")]
    public class EmployeeController : Controller
    {
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
