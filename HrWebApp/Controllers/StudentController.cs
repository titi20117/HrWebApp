using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class StudentController : Controller
    {
        [Route("/Student/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateStudentPage()
        {
            return View();
        }
        public IActionResult UpdateStudentPage()
        {
            return View();
        }
    }
}
