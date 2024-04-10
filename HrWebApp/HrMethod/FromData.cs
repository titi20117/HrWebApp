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
    }
}
