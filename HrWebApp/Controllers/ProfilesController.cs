using HrWebApp.Data;
using HrWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class ProfilesController : Controller
    {
        [Route("/Create/Account")]
        public IActionResult UserAccount()
        {
            var context = new HrProjectContext();
            var vm = new UserAccountModel();
            using (context)
            {
                var userCategories = context.UserCategories.ToList();
                vm.UserCategoryList = new List<UserCategoryModel>();
                foreach (var item in userCategories)
                {
                    var userCategory = new UserCategoryModel();
                    userCategory.Id = item.UserCategoryId;
                    userCategory.Name = item.UserCategoryName;

                    vm.UserCategoryList.Add(userCategory);
                }
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult CreateAccount(UserAccountModel user)
        {
            var vm = new UserAccountModel();
            using (var ressource = new HrProjectContext())
            {
                var userAccount = new User();
                userAccount.UserEmail = user.UserEmail;
                userAccount.UserPassword = user.UserPassword;
                userAccount.UserConfirmationPassword = user.UserConfirmationPassword;
                userAccount.UserCategoryId = user.UserCategoryId;
                ressource.Users.Add(userAccount);
                ressource.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        
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
