﻿using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class Vacancy
{
    public int VacancyId { get; set; }

    public int CompanyId { get; set; }

    public string Title { get; set; } = null!;

    public string Responsibilities { get; set; } = null!;

    public int StudyLevelId { get; set; }

    public int WorkingExperience { get; set; }

    public int WorkingHours { get; set; }

    public int ContractId { get; set; }

    public decimal Salary { get; set; }

    public string VacancyDescription { get; set; } = null!;

    public DateTime PublicationDate { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Contract Contract { get; set; } = null!;

    public virtual Education StudyLevel { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<StudentStatistic> Statistics { get; set; } = new List<StudentStatistic>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
