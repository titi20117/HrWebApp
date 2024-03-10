using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class RecruiterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
