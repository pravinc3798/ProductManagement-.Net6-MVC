using System;
using System.Collections.Generic;

namespace RepositoryLayer.Entity;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public int CategoryId { get; set; }

    public string? ProductImage { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual TblCategory Category { get; set; } = null!;
}
