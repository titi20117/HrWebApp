using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class StudentStatus
{
    public int StudentStatusId { get; set; }

    public string? StudentStatusName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
