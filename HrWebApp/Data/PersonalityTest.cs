using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class PersonalityTest
{
    public int PersonalityTestId { get; set; }

    public int UserId { get; set; }

    public int? PersonalityTestQuestion1 { get; set; }

    public int? PersonalityTestQuestion2 { get; set; }

    public int? PersonalityTestQuestion3 { get; set; }

    public int? PersonalityTestQuestion4 { get; set; }

    public int? PersonalityTestQuestion5 { get; set; }

    public int? PersonalityTestQuestion6 { get; set; }

    public int? PersonalityTestQuestion7 { get; set; }

    public int? PersonalityTestQuestion8 { get; set; }

    public int? PersonalityTestQuestion9 { get; set; }

    public int? PersonalityTestQuestion10 { get; set; }

    public int? PersonalityTestQuestion11 { get; set; }

    public int? PersonalityTestQuestion12 { get; set; }

    public int? PersonalityTestQuestion13 { get; set; }

    public int? PersonalityTestQuestion14 { get; set; }

    public int? PersonalityTestQuestion15 { get; set; }

    public int? PersonalityTestQuestion16 { get; set; }

    public int? PersonalityTestQuestion17 { get; set; }

    public int? PersonalityTestQuestion18 { get; set; }

    public int? PersonalityTestQuestion19 { get; set; }

    public int? PersonalityTestQuestion20 { get; set; }

    public int? PersonalityTestQuestion21 { get; set; }

    public virtual User User { get; set; } = null!;
}
