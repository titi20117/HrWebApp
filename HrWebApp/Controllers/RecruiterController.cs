using HrWebApp.Data;
using HrWebApp.HrMethod;
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
            vm.Jobs = new List<GetJobModel>();
            using (var resource = new HrProjectContext())
            {
                var items = resource.Companies.ToList();
                bool temp = false;
                if (items.Count != 0)
                {
                    int userId = FromData.GetUserId(User.Identity.Name);
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
                              join c in resource.Companies on j.CompanyId equals c.CompanyId
                              join contrat in resource.Contracts on j.ContractId equals contrat.ContractId
                              where c.CompanyId == GetCompanyId(GetCompanyNameByUserMail(User.Identity.Name))
                              select new
                              {
                                  CompanyName = c.CompanyName,
                                  JobTitle = j.Title,
                                  JobContract = contrat.ContractTitle,
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
                foreach (var item in jobList)
                {
                    GetJobModel jm = new GetJobModel();
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
                company.UserId = FromData.GetUserId(vm.UserMail);

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
                               where element.UserId == FromData.GetUserId(userMail)
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

        private int GetCompanyId(string name)
        {
            int companyId = 0;
            using (var resource = new HrProjectContext())
            {
                var company = (from c in resource.Companies
                               select new
                               {
                                   Id = c.CompanyId,
                                   Name = c.CompanyName
                               }).FirstOrDefault(c => c.Name == name);
                companyId = company.Id;
            }
            return companyId;
        }

        [HttpPost]
        public IActionResult CreateJob(JobModel vm)
        {
            vm.Vacancies = new List<Vacancy>();
            using (var resource = new HrProjectContext())
            {
                Vacancy vacancy = new Vacancy();
                vacancy.CompanyId = GetCompanyId(vm.CompanyId);
                vacancy.Title = vm.Title;
                vacancy.Responsibilities = vm.Responsibilities;
                vacancy.StudyLevelId = vm.StudyLevelId;
                vacancy.WorkingExperience = vm.WorkingExperience;
                vacancy.WorkingHours = vm.WorkingHours;
                vacancy.ContractId = vm.ContractId;
                vacancy.Salary = vm.Salary;
                vacancy.VacancyDescription = vm.Description;
                vacancy.PublicationDate = vm.PublicationDate;
                resource.Vacancies.Add(vacancy);
                resource.SaveChanges();

                resource.Vacancies.Attach(vacancy);
                foreach (var item in vm.IdSkills)
                {
                    Skill skill = new Skill { SkillId = item };
                    resource.Skills.Attach(skill);
                    vacancy.Skills.Add(skill);
                }
                resource.SaveChanges();
            }
            return RedirectToAction("Account", "Recruiter");
        }

        public IActionResult Statistics()
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
