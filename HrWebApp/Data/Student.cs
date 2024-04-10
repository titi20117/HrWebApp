using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;

    public string StudentPhoneNumber { get; set; } = null!;

    public int StudentWorkExperience { get; set; }

    public int? StudentNumberProjects { get; set; }

    public string? StudentUrlGithub { get; set; }

    public string? StudentAwardsHonors { get; set; }

    public int StudentStatusId { get; set; }

    public int? UserId { get; set; }

    public double EducationAverageScore { get; set; }

    public virtual ICollection<PersonalityTest> PersonalityTests { get; set; } = new List<PersonalityTest>();

    public virtual ICollection<StudentStatistic> StudentStatistics { get; set; } = new List<StudentStatistic>();

    public virtual StudentStatus StudentStatus { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
