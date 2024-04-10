using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class Company
{
    public int CompanyId { get; set; }

    public int CompanyNumberOfEmployees { get; set; }

    public string CompanyLocation { get; set; } = null!;

    public int CompanyDateOfCreation { get; set; }

    public string CompanyDescription { get; set; } = null!;

    public string CompanyUrl { get; set; } = null!;

    public int? CompanySectorId { get; set; }

    public int? CompanyTypeId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyRecruiterFirstName { get; set; } = null!;

    public string CompanyRecruiterLastName { get; set; } = null!;

    public string CompanyPhone { get; set; } = null!;

    public int UserId { get; set; }

    public virtual CompanySector? CompanySector { get; set; }

    public virtual CompanyType? CompanyType { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
