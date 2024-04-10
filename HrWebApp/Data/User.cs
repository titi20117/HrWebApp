using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class User
{
    public int UserId { get; set; }

    public string? UserEmail { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserConfirmationPassword { get; set; } = null!;

    public int? UserCategoryId { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual UserCategory? UserCategory { get; set; }
}
