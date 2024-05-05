using HrWebApp.Controllers;
using HrWebApp.Data;

namespace HrWebApp.HrMethod
{
    public static class FromData
    {
        public static int GetUserId(string? userMail)
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

        public static string GetUserCategory(string? userMail)
        {
            string userCategory = "";
            using (var resource = new HrProjectContext())
            {
                int userCategoryId = (int)(from element in resource.Users
                          where element.UserEmail == userMail
                          select element.UserCategoryId).Single();
                userCategory = ProfilesController.getCategoryUser(userCategoryId);
            }
            return userCategory;
        }

        public static int GetStudentId(string? userMail)
        {
            int studentId = 0;
            using (var resource = new HrProjectContext())
            {
                studentId = (from element in resource.Students
                          where element.UserId == GetUserId(userMail)
                          select element.StudentId).Single();
            }
            return studentId;
        }
        public static int GetMyUserId(int id)
        {
            int myUserId = 0;
            using (var resource = new HrProjectContext())
            {
                myUserId = (int)(from element in resource.Students
                             where element.StudentId == id
                             select element.UserId).Single();
            }
            return myUserId;
        }
    }
}
