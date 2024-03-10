using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class VacanciesSkill
{
    public int VacancyId { get; set; }

    public int SkillId { get; set; }

    public virtual Skill Skill { get; set; } = null!;

    public virtual Vacancy SkillNavigation { get; set; } = null!;
}
