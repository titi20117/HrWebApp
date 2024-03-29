using HrWebApp.Data;
using HrWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrWebApp.Controllers
{
    [Authorize(Policy = "RecruiterOnly")]
    public class RecruiterController : Controller
    {
        [Route("Recruiter/Company")]
        public IActionResult Account()
        {
            CompanyRecruiterModel vm = new CompanyRecruiterModel();
            using (var resource = new HrProjectContext())
            {
                var items = resource.Companies.ToList();
                bool temp = false;
                if (items.Count() != 0)
                {
                    int userId = GetUserId(User.Identity.Name);
                    foreach (var item in items)
                    {
                        if (item.UserId == userId)
                        {
                            temp = true;
                        }
                    }
                }
                else
                {
                    return RedirectToAction("FormCompany", "Recruiter");
                }

                if (!temp)
                {
                    return RedirectToAction("FormCompany", "Recruiter");
                }

                var jobList = from j in resource.Vacancies
                              where j.Company.User.UserEmail == User.Identity.Name
                              select new
                              {
                                  CompanyName = j.Company.CompanyName,
                                  JobTitle = j.Title,
                                  JobContract = j.Contract,
                                  JobLocation = j.Company.CompanyLocation,
                                  PublicationTime = j.PublicationDate
                              };

                var myCompany = (from c in resource.Companies
                                 join t in resource.CompanyTypes on c.CompanyTypeId equals t.CompanyTypeId
                                 join s in resource.CompanySectors on c.CompanySectorId equals s.CompanySectorId
                                 join u in resource.Users on c.UserId equals u.UserId
                                 select new
                                 {
                                     Name = c.CompanyName,
                                     Url = c.CompanyUrl,
                                     Type = t.CompanyTypeName,
                                     Sector = s.CompanySectorName,
                                     Location = c.CompanyLocation,
                                     Description = c.CompanyDescription,
                                     NbrEmplyee = c.CompanyNumberOfEmployees,
                                     UserName = u.UserEmail
                                 }).FirstOrDefault(c => c.UserName == User.Identity.Name);

                vm.Name = myCompany.Name;
                vm.Url = myCompany.Url;
                vm.Type = myCompany.Type;
                vm.Sector = myCompany.Sector;
                vm.Location = myCompany.Location;
                vm.Description = myCompany.Description;
                vm.JobCount = jobList.Count();

            }
            return View(vm);
        }

        [Route("/Recruiter/Create-Account")]
        public IActionResult FormCompany()
        {
            var vm = new CompanyModel();
            using (var resource = new HrProjectContext())
            {
                vm.CompanySectors = new List<CompanySector>();
                vm.CompanyTypes = new List<CompanyType>();

                var companySectors = resource.CompanySectors.ToList();
                var companyTypes = resource.CompanyTypes.ToList();

                foreach (var item in companyTypes)
                {
                    vm.CompanyTypes.Add(item);
                }
                foreach (var item in companySectors)
                {
                    vm.CompanySectors.Add(item);
                }
            }
            return View(vm);
        }
        private int GetUserId(string userMail)
        {
            int userId = 0;
            using (var resource = new HrProjectContext())
            {
                userId = (from element in resource.Users
                          where element.UserEmail == userMail
                          select element.UserId).Single();
            }
            return userId;
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyModel vm)
        {
            using (var resource = new HrProjectContext())
            {
                Company company = new Company();
                company.CompanyNumberOfEmployees = vm.CompanyNumberOfEmployees;
                company.CompanyLocation = vm.CompanyLocation;
                company.CompanyDateOfCreation = vm.CompanyDateOfCreation;
                company.CompanyDescription = vm.CompanyDescription;
                company.CompanyUrl = vm.CompanyUrl;
                company.CompanySectorId = vm.CompanySectorId;
                company.CompanyTypeId = vm.CompanyTypeId;
                company.CompanyName = vm.CompanyName;
                company.CompanyRecruiterFirstName = vm.CompanyRecruiterFirstName;
                company.CompanyRecruiterLastName = vm.CompanyRecruiterLastName;
                company.CompanyPhone = vm.CompanyPhone;
                company.UserId = GetUserId(vm.UserMail);

                resource.Companies.Add(company);
                resource.SaveChanges();
            }
            return RedirectToAction("Account", "Recruiter");
        }

        public IActionResult UpdateCompany()
        {
            return View();
        }

        private string GetCompanyNameByUserMail(string userMail)
        {
            string companyName = "";
            using (var resource = new HrProjectContext())
            {
                companyName = (from element in resource.Companies
                               where element.UserId == GetUserId(userMail)
                               select element.CompanyName).Single();
            }
            return companyName;
        }

        public IActionResult FormJob()
        {
            var vm = new JobModel();
            using (var resource = new HrProjectContext())
            {
                string recruiterMail = User.Identity.Name;
                vm.Skills = new List<Skill>();
                vm.Contracts = new List<Contract>();
                vm.StudyLevels = new List<Education>();

                vm.CompanyId = GetCompanyNameByUserMail(recruiterMail);

                foreach (var item in resource.Skills.ToList())
                {
                    vm.Skills.Add(item);
                }
                foreach (var item in resource.Contracts.ToList())
                {
                    vm.Contracts.Add(item);
                }
                foreach (var item in resource.Educations.ToList())
                {
                    vm.StudyLevels.Add(item);
                }
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult CreateJob(JobModel vm)
        {
            vm.Vacancies = new List<Vacancy>();
            using (var resource = new HrProjectContext())
            {

            }
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
