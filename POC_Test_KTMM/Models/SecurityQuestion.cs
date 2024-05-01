using System;
using System.Collections.Generic;

namespace POC_Test_KTMM.Models;

public partial class SecurityQuestion
{
    public int QuestionId { get; set; }

    public string? Question { get; set; }

    public int? UserId { get; set; }

    public string? Answer { get; set; }

    public virtual User? User { get; set; }
}
