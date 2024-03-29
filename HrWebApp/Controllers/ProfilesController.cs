using HrWebApp.Data;
using HrWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public static string getCategoryUser(int? id)
        {
            string category = "";
            using (var context = new HrProjectContext())
            {
                category = (from cat in context.UserCategories
                            where cat.UserCategoryId == id
                            select cat.UserCategoryName).Single();
            }
            return category;
        }
        [HttpPost]
        public async Task<IActionResult> CreateConnectionAsync(LoginModel loginVm)
        {
            if (!ModelState.IsValid) return RedirectToAction("SignIn", "Profiles");
            using (var resource = new HrProjectContext())
            {
                var usersList = resource.Users.ToList();
                foreach (var item in usersList)
                {
                    //verify the credential
                    if (loginVm.Mail == item.UserEmail && loginVm.Password == item.UserPassword)
                    {
                        //Creating the security context
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, item.UserEmail),
                            new Claim(ClaimTypes.Email, item.UserEmail),
                            new Claim("UserCategory", getCategoryUser(item.UserCategoryId))
                        };
                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                        return RedirectToAction("Account", getCategoryUser(item.UserCategoryId));

                    }
                }
            }
            return RedirectToAction("SignIn", "Profiles");
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

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}
