using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class Contract
{
    public int ContractId { get; set; }

    public string ContractTitle { get; set; } = null!;

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
