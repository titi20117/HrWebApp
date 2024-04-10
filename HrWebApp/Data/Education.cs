using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class Education
{
    public int EducationId { get; set; }

    public string EducationName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
