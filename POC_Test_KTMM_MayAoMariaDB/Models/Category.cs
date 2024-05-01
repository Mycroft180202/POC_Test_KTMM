using System;
using System.Collections.Generic;

namespace POC_Test_KTMM_MayAoMariaDB.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
