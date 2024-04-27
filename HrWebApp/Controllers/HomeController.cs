using HrWebApp.Data;
using HrWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HrWebApp.Controllers
{
    [Authorize(Policy = "MustBelongToStudentProfile")]
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
            if (userCategory.ToLower() == "student")
            {
                return RedirectToAction("Account", "Student");
            }
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
                               Id = c.CompanyId,
                               Name = c.CompanyName,
                               Type = t.CompanyTypeName,
                               NbrEmplyee = c.CompanyNumberOfEmployees,
                               Description = c.CompanyDescription
                           };

                foreach (var item in list)
                {
                    GetCompanyModel vm1 = new GetCompanyModel();
                    vm1.Id = item.Id;
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
                                   JobId = j.VacancyId,
                                   CompanyName = c.CompanyName,
                                   JobTitle = j.Title,
                                   JobContract = t.ContractTitle,
                                   JobLocation = c.CompanyLocation,
                                   DatePublication = j.PublicationDate
                               };
                foreach (var job in jobList)
                {
                    var vm1 = new GetJobModel();
                    vm1.JobId = job.JobId;
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

        public IActionResult JobPage(int id)
        {
            var vm = new GetJobModel();
            using (var resource = new HrProjectContext())
            {
                var job = (from j in resource.Vacancies
                           join c in resource.Companies on j.CompanyId equals c.CompanyId
                           join t in resource.Contracts on j.ContractId equals t.ContractId
                           join e in resource.Educations on j.StudyLevelId equals e.EducationId
                           select new
                           {
                               Id = j.VacancyId,
                               CompanyId = c.CompanyId,
                               CompanyName = c.CompanyName,
                               CompanyNbrEmployees = c.CompanyNumberOfEmployees,
                               JobTitle = j.Title,
                               JobContract = t.ContractTitle,
                               JobLocation = c.CompanyLocation,
                               PublicationTime = j.PublicationDate,
                               Responsibilities = j.Responsibilities,
                               StudyLevel = e.EducationName,
                               WorkingExperience = j.WorkingExperience,
                               WorkingHours = j.WorkingHours,
                               Salary = j.Salary,
                               Description = j.VacancyDescription,
                               Skills = j.Skills
                           }).FirstOrDefault(u => u.Id == id);

                vm.JobId = job.Id;
                vm.CompanyId = job.CompanyId;
                vm.CompanyName = job.CompanyName;
                vm.CompanyNbrEmployees = job.CompanyNbrEmployees;
                vm.JobTitle = job.JobTitle;
                vm.JobContract = job.JobContract;
                vm.JobLocation = job.JobLocation;
                vm.PublicationTime = job.PublicationTime;
                vm.Responsibilities = new List<string>();
                vm.Responsibilities = splitText(job.Responsibilities);
                vm.StudyLevel = job.StudyLevel;
                vm.WorkingExperience = job.WorkingExperience;
                vm.WorkingHours = job.WorkingHours;
                vm.Salary = job.Salary;
                vm.Description = job.Description;
                vm.Skills = new List<Skill>();

                foreach (var skill in job.Skills)
                {
                    vm.Skills.Add(skill);
                }
            }
            return View(vm);
        }

        private List<string> splitText(string txt)
        {
            List<string> txts = new List<string>();
            if (txt.Contains(';'))
            {
                string[] txtlist = txt.Split(";");
                foreach (var item in txtlist)
                {
                    txts.Add(item);
                }
                return txts;
            }
            if (txt.Contains('.'))
            {
                string[] txtlist = txt.Split(".");
                foreach (var item in txtlist)
                {
                    txts.Add(item);
                }
                return txts;
            }
            txts.Add(txt);
            return txts;
        }
        
        public IActionResult CompanyPage(int id)
        {
            var vm = new GetCompanyModel();
            vm.Jobs = new List<GetJobModel>();
            using (var resource = new HrProjectContext())
            {
                var company = (from c in resource.Companies
                               join s in resource.CompanySectors on c.CompanySectorId equals s.CompanySectorId
                               join t in resource.CompanyTypes on c.CompanyTypeId equals t.CompanyTypeId
                               select new
                               {
                                   Id = c.CompanyId,
                                   CompanyName = c.CompanyName,
                                   CompanySector = s.CompanySectorName,
                                   CompanyType = t.CompanyTypeName,
                                   CompanyPhone = c.CompanyPhone,
                                   CompanyNumberOfEmployees = c.CompanyNumberOfEmployees,
                                   CompanyLocation = c.CompanyLocation,
                                   CompanyDateOfCreation = c.CompanyDateOfCreation,
                                   CompanyDescription = c.CompanyDescription,
                                   CompanyUrl = c.CompanyUrl
                               }).FirstOrDefault(u => u.Id == id);

                var jobList = from j in resource.Vacancies
                              join c in resource.Companies on j.CompanyId equals c.CompanyId
                              join contrat in resource.Contracts on j.ContractId equals contrat.ContractId
                              where c.CompanyId == id
                              select new
                              {
                                  JobId = j.VacancyId,
                                  CompanyName = c.CompanyName,
                                  JobTitle = j.Title,
                                  JobContract = contrat.ContractTitle,
                                  JobLocation = j.Company.CompanyLocation,
                                  PublicationTime = j.PublicationDate
                              };
                vm.Id = company.Id;
                vm.Name = company.CompanyName;
                vm.CompanySector = company.CompanySector;
                vm.Type = company.CompanyType;
                vm.CompanyPhone = company.CompanyPhone;
                vm.EmployeesCount = company.CompanyNumberOfEmployees;
                vm.CompanyLocation = company.CompanyLocation;
                vm.CompanyDateOfCreation = company.CompanyDateOfCreation;
                vm.Description = company.CompanyDescription;
                vm.CompanyUrl = company.CompanyUrl;

                foreach (var item in jobList)
                {
                    GetJobModel jm = new GetJobModel();
                    jm.JobId = item.JobId;
                    jm.CompanyName = item.CompanyName;
                    jm.JobTitle = item.JobTitle;
                    jm.JobContract = item.JobContract;
                    jm.JobLocation = item.JobLocation;
                    jm.PublicationTime = item.PublicationTime;
                    vm.Jobs.Add(jm);
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