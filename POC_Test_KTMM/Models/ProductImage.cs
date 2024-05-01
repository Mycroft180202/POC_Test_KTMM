using System;
using System.Collections.Generic;

namespace POC_Test_KTMM.Models;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public int? ProductId { get; set; }

    public string? ImageDescription { get; set; }

    public string? Image { get; set; }

    public virtual Product? Product { get; set; }
}
