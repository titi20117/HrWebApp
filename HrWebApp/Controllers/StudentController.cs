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
            return View();
        }

        public IActionResult ManageAccount()
        {
            return RedirectToAction("Account", "Student");
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
