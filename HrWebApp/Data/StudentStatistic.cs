using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class StudentStatistic
{
    public int StatisticId { get; set; }

    public int StudentId { get; set; }

    public double EducationScore { get; set; }

    public double ProfilScore { get; set; }

    public double PersonalityTestScore { get; set; }

    public double IndividualAchievementsScore { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
