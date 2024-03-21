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
        [HttpPost]
        public IActionResult CreateCompany()
        {
            return View();
        }

        public IActionResult UpdateCompany()
        {
            return View();
        }

        public IActionResult Job()
        {
            return View();
        }
        [HttpPost]
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
