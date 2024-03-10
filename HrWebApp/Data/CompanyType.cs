using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class CompanyType
{
    public int CompanyTypeId { get; set; }

    public string? CompanyTypeName { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
