using System;
using System.Collections.Generic;

namespace POC_Test_KTMM.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductUser> ProductUsers { get; set; } = new List<ProductUser>();

    public virtual ICollection<SecurityQuestion> SecurityQuestions { get; set; } = new List<SecurityQuestion>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
