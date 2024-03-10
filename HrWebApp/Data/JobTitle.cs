using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class JobTitle
{
    public int JobTitleId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
