using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class ProfilesController : Controller
    {
        [Route("/sign-in")]
        public IActionResult SignIn()
        {
            return View();
        }
        [Route("/student/sign-up")]
        public IActionResult SignUpStudent()
        {
            return View();
        }

        public IActionResult CreateNewStudent()
        {
            return RedirectToAction("Index", "Home");
        }

        [Route("/recruiter/sign-up")]
        public IActionResult SignUpRecruiter()
        {
            return View();
        }

        public IActionResult CreateNewRecruiter()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult NewStudent()
        {
            return View();
        }

        public IActionResult NewRecruiter()
        {
            return View();
        }

        public IActionResult Login()
        {

            return RedirectToAction("Student");
            //return View();
        }
    }
}
