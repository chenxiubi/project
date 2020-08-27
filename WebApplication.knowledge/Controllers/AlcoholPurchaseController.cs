using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.knowledge.Controllers
{
    [Authorize(Policy = "AtLeast21")]
    [Route("[controller]/[action]")]
    public class AlcoholPurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
