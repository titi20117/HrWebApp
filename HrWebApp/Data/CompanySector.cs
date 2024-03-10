using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class CompanySector
{
    public int CompanySectorId { get; set; }

    public string? CompanySectorName { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
