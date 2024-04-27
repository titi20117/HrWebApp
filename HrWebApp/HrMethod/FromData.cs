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
    }
}
