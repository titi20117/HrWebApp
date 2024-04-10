using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class UserCategory
{
    public int UserCategoryId { get; set; }

    public string? UserCategoryName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
