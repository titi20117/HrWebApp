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
            int id = 0;
            string userCategory = "";
            using (var resource = new HrProjectContext())
            {
                var el = (from u in resource.Users
                          join cat in resource.UserCategories on u.UserCategoryId equals cat.UserCategoryId
                          select new
                          {
                              Id = u.UserId,
                              Name = u.UserEmail,
                              UserCategoryName = cat.UserCategoryName
                          }).FirstOrDefault(u => u.Name == User.Identity.Name);
                id = el.Id;
                userCategory = el.UserCategoryName;
            }
            if (userCategory.ToLower() == "recruiter")
            {
                return RedirectToAction("Account", "Recruiter");
            }
            return View();
        }
        public IActionResult Recruiter()
        {
            return View();
        }

        public IActionResult Companies()
        {
            GetCompanyModel vm = new GetCompanyModel();
            using (var resource = new HrProjectContext())
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
            var vm = new GetJobModel();
            vm.Jobs = new List<GetJobModel>();
            using (var resource = new HrProjectContext())
            {
                var jobList = from j in resource.Vacancies
                              join c in resource.Companies on j.CompanyId equals c.CompanyId
                              join t in  resource.Contracts on j.ContractId equals t.ContractId
                               select new
                               {
                                   CompanyName = c.CompanyName,
                                   JobTitle = j.Title,
                                   JobContract = t.ContractTitle,
                                   JobLocation = c.CompanyLocation,
                                   DatePublication = j.PublicationDate
                               };
                foreach (var job in jobList)
                {
                    var vm1 = new GetJobModel();
                    vm1.CompanyName = job.CompanyName;
                    vm1.JobTitle = job.JobTitle;
                    vm1.JobContract = job.JobContract;
                    vm1.JobLocation = job.JobLocation;
                    vm1.PublicationTime = job.DatePublication;
                    vm.Jobs.Add(vm1);
                }
            }
            return View(vm);
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