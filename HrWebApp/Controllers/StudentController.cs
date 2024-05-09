using HrWebApp.Data;
using HrWebApp.HrMethod;
using HrWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    [Authorize(Policy = "MustBelongToStudentProfile")]
    public class StudentController : Controller
    {
        [Route("/Student/Account")]
        public IActionResult Account()
        {
            StudentModel vm = new StudentModel();

            using (var resource = new HrProjectContext())
            {
                var students = resource.Students.ToList();
                bool temp = false;
                int userId = FromData.GetUserId(User.Identity.Name);
                if (students.Count != 0)
                {
                    foreach (var item in students)
                    {
                        if (item.UserId == userId)
                        {
                            temp = true;
                        }
                    }
                }
                else
                {
                    return RedirectToAction("FormTestPersonality", "Student");
                }

                if (!temp)
                {
                    return RedirectToAction("FormTestPersonality", "Student");
                }

                var studentPageList = (from s in resource.Students
                                       join st in resource.StudentStatuses on s.StudentStatusId equals st.StudentStatusId
                                       select new
                                       {
                                           UserId = s.UserId,
                                           FirstName = s.StudentFirstName,
                                           LastName = s.StudentLastName,
                                           PhoneNumber = s.StudentPhoneNumber,
                                           ExperienceYears = s.StudentWorkExperience,
                                           GithubProfile = s.StudentUrlGithub,
                                           Awards = s.StudentAwardsHonors,
                                           Skills = s.Skills,
                                           Languages = s.Languages,
                                           Educations = s.Educations,
                                           Vacancies = s.Vacancies
                                       }).FirstOrDefault(s => s.UserId == userId);
                vm.FirstName = studentPageList.FirstName;
                vm.LastName = studentPageList.LastName;
                vm.PhoneNumber = studentPageList.PhoneNumber;
                vm.WorkExperience = studentPageList.ExperienceYears;
                vm.GitHubProfile = studentPageList.GithubProfile;
                vm.AwardsAndHonors = studentPageList.Awards;
                vm.Skills = new List<Skill>();
                vm.Educations = new List<Education>();
                vm.Languages = new List<Language>();
                vm.Vacancies = new List<GetJobModel>();

                var jobList = from j in studentPageList.Vacancies
                              join c in resource.Companies on j.CompanyId equals c.CompanyId
                              join t in resource.Contracts on j.ContractId equals t.ContractId
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
                    vm.Vacancies.Add(vm1);
                }

                foreach (var item in studentPageList.Skills)
                {
                    vm.Skills.Add(item);
                }
                foreach (var item in studentPageList.Languages)
                {
                    vm.Languages.Add(item);
                }

                foreach (var item in studentPageList.Educations)
                {
                    vm.Educations.Add(item);
                }
            }
            return View(vm);
        }

        public IActionResult FormStudent()
        {
            var vm = new StudentModel();
            vm.Educations = new List<Education>();
            vm.Skills = new List<Skill>();
            vm.Status = new List<StudentStatus>();
            vm.Languages = new List<Language>();

            using (var resource = new HrProjectContext())
            {
                var skills = resource.Skills.ToList();
                var status = resource.StudentStatuses.ToList();
                var educations = resource.Educations.ToList();
                var languages = resource.Languages.ToList();

                foreach (var item in skills)
                {
                    vm.Skills.Add(item);
                }

                foreach (var item in status)
                {
                    vm.Status.Add(item);
                }

                foreach (var item in educations)
                {
                    vm.Educations.Add(item);
                }

                foreach (var item in languages)
                {
                    vm.Languages.Add(item);
                }
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult ManageAccount(StudentModel vm)
        {
            using (var resource = new HrProjectContext())
            {
                Student student = new Student();
                student.StudentFirstName = vm.FirstName;
                student.StudentLastName = vm.LastName;
                student.UserId = FromData.GetUserId(vm.UserMail);
                student.StudentPhoneNumber = vm.PhoneNumber;
                student.StudentWorkExperience = vm.WorkExperience;
                student.StudentNumberProjects = vm.NumberOfProjects;
                student.StudentUrlGithub = vm.GitHubProfile;
                student.StudentAwardsHonors = vm.AwardsAndHonors;
                student.EducationAverageScore = vm.EducationAverageScore;
                student.StudentStatusId = vm.StatutId;

                resource.Students.Add(student);
                resource.SaveChanges();

                resource.Students.Attach(student);

                foreach (var item in vm.SkillsId)
                {
                    Skill skill = new Skill { SkillId = item };
                    resource.Skills.Attach(skill);
                    student.Skills.Add(skill);
                }

                foreach (var item in vm.EducationsId)
                {
                    Education education = new Education { EducationId = item };
                    resource.Educations.Attach(education);
                    student.Educations.Add(education);
                }

                foreach (var item in vm.LanguagesId)
                {
                    Language language = new Language { LanguageId = item };
                    resource.Languages.Attach(language);
                    student.Languages.Add(language);
                }

                resource.SaveChanges();
            }
            return RedirectToAction("Account", "Student");
        }

        public IActionResult FormTestPersonality()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidTest(PersonalityTestModel vm)
        {
            using (var resource = new HrProjectContext())
            {
                PersonalityTest test = new PersonalityTest();
                test.PersonalityTestQuestion1 = vm.Question1;
                test.PersonalityTestQuestion2 = vm.Question2;
                test.PersonalityTestQuestion3 = vm.Question3;
                test.PersonalityTestQuestion4 = vm.Question4;
                test.PersonalityTestQuestion5 = vm.Question5;
                test.PersonalityTestQuestion6 = vm.Question6;
                test.PersonalityTestQuestion7 = vm.Question7;
                test.PersonalityTestQuestion8 = vm.Question8;
                test.PersonalityTestQuestion9 = vm.Question9;
                test.PersonalityTestQuestion10 = vm.Question10;
                test.PersonalityTestQuestion11 = vm.Question11;
                test.PersonalityTestQuestion12 = vm.Question12;
                test.PersonalityTestQuestion13 = vm.Question13;
                test.PersonalityTestQuestion14 = vm.Question14;
                test.PersonalityTestQuestion15 = vm.Question15;
                test.PersonalityTestQuestion16 = vm.Question16;
                test.PersonalityTestQuestion17 = vm.Question17;
                test.PersonalityTestQuestion18 = vm.Question18;
                test.PersonalityTestQuestion19 = vm.Question19;
                test.PersonalityTestQuestion20 = vm.Question20;
                test.PersonalityTestQuestion21 = vm.Question21;
                test.UserId = FromData.GetUserId(User.Identity.Name);

                resource.PersonalityTests.Add(test);
                resource.SaveChanges();
            }
            return RedirectToAction("FormStudent", "Student");
        }

        public IActionResult UpdateAccount()
        {
            return RedirectToAction("Account", "Student");
        }
        public IActionResult DeleteAccount()
        {
            return View();
        }
    }
}
