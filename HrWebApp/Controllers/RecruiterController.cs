using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    [Authorize(Policy = "RecruiterOnly")]
    public class RecruiterController : Controller
    {
        [Route("/Recruiter/Account")]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Company()
        {
            return View();
        }

        public IActionResult CreateCompany()
        {
            return View();
        }

        public IActionResult UpdateCompany()
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

        public IActionResult DeleteJob()
        {
            return View();
        }
    }
}
