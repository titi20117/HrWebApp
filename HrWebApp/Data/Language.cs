using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
