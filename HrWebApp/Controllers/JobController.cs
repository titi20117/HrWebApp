using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateJob()
        {
            return View();
        }

        public IActionResult UpdateJob()
        {
            return View();
        }

        public IActionResult ShowJob()
        {
            return View();
        }
    }
}
