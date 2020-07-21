using Microsoft.AspNetCore.Mvc;

namespace WebApplication.knowledge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IMyDependency _myDependency;

        public AdminController(IMyDependency myDependency)
        {
            this._myDependency = myDependency;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public JsonResult Get()
        {
            string name = _myDependency.WriteMessage("ABC").Result;
            return Json(name);
        }
    }
}