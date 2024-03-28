using HrWebApp.Data;
using HrWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HrWebApp.Controllers
{
    [Authorize("RecruiterAndStudentOnly")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Recruiter()
        {
            return View();
        }

        public IActionResult Companies()
        {
            GetCompanyModel vm = new GetCompanyModel();
            var resource = new HrProjectContext();
            using (resource)
            {
                vm.Companies = new List<GetCompanyModel>();
                var list = from c in resource.Companies
                           join t in resource.CompanyTypes on c.CompanyTypeId equals t.CompanyTypeId
                           select new
                           {
                               Name = c.CompanyName,
                               Type = t.CompanyTypeName,
                               NbrEmplyee = c.CompanyNumberOfEmployees,
                               Description = c.CompanyDescription
                           };

                foreach (var item in list)
                {
                    GetCompanyModel vm1 = new GetCompanyModel();
                    vm1.Name = item.Name;
                    vm1.Type = item.Type;
                    vm1.EmployeesCount = item.NbrEmplyee;
                    vm1.Description = item.Description;

                    vm.Companies.Add(vm1);
                }
            }
            return View(vm);
        }
        public IActionResult Jobs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}