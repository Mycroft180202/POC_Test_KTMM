using System;
using System.Collections.Generic;

namespace POC_Test_KTMM_MayAoMariaDB.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public int? StockQuantity { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Productimage> Productimages { get; set; } = new List<Productimage>();

    public virtual ICollection<Productuser> Productusers { get; set; } = new List<Productuser>();
}
