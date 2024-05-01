using System;
using System.Collections.Generic;

namespace POC_Test_KTMM.Models;

public partial class ProductUser
{
    public int ProductUserId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public int? Quantity { get; set; }

    public string? Image { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
