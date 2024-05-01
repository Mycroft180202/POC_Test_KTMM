using System;
using System.Collections.Generic;

namespace POC_Test_KTMM_MayAoMariaDB.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Productuser> Productusers { get; set; } = new List<Productuser>();

    public virtual ICollection<Securityquestion> Securityquestions { get; set; } = new List<Securityquestion>();

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
