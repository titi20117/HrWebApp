using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class Skill
{
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public virtual ICollection<VacanciesSkill> VacanciesSkills { get; set; } = new List<VacanciesSkill>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
