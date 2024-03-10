using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
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

        public IActionResult ShowCompany()
        {
            return View();
        }
    }
}
