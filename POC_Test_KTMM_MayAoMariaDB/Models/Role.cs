using System;
using System.Collections.Generic;

namespace POC_Test_KTMM_MayAoMariaDB.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
