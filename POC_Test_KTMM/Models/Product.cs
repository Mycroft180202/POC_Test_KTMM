using System;
using System.Collections.Generic;

namespace POC_Test_KTMM.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public int? StockQuantity { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductUser> ProductUsers { get; set; } = new List<ProductUser>();
}
