using System;
using System.Collections.Generic;

namespace HrWebApp.Data;

public partial class PersonalityTest
{
    public int PersonalityTestId { get; set; }

    public int UserId { get; set; }

    public string PersonalityTestQuestion1 { get; set; } = null!;

    public string PersonalityTestQuestion2 { get; set; } = null!;

    public string PersonalityTestQuestion3 { get; set; } = null!;

    public string PersonalityTestQuestion4 { get; set; } = null!;

    public string PersonalityTestQuestion5 { get; set; } = null!;

    public string PersonalityTestQuestion6 { get; set; } = null!;

    public string PersonalityTestQuestion7 { get; set; } = null!;

    public string PersonalityTestQuestion8 { get; set; } = null!;

    public string PersonalityTestQuestion9 { get; set; } = null!;

    public string PersonalityTestQuestion10 { get; set; } = null!;

    public string PersonalityTestQuestion11 { get; set; } = null!;

    public string PersonalityTestQuestion12 { get; set; } = null!;

    public string PersonalityTestQuestion13 { get; set; } = null!;

    public string PersonalityTestQuestion14 { get; set; } = null!;

    public string PersonalityTestQuestion15 { get; set; } = null!;

    public string PersonalityTestQuestion16 { get; set; } = null!;

    public string PersonalityTestQuestion17 { get; set; } = null!;

    public string PersonalityTestQuestion18 { get; set; } = null!;

    public string PersonalityTestQuestion19 { get; set; } = null!;

    public string PersonalityTestQuestion20 { get; set; } = null!;

    public string PersonalityTestQuestion21 { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
