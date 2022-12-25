using System;
using System.Collections.Generic;

namespace RepositoryLayer.Entity;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();
}
