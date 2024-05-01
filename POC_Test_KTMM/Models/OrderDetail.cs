using System;
using System.Collections.Generic;

namespace POC_Test_KTMM.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Subtotal { get; set; }

    public bool? Status { get; set; }

    public int UserId { get; set; }

    public string Address { get; set; } = null!;

    public int? Phone { get; set; }

    public virtual User User { get; set; } = null!;
}
