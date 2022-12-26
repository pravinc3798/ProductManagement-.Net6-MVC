using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Entity;

public partial class TblProduct
{
    public int ProductId { get; set; }
    [DisplayName("Product Code")]
    [StringLength(25)]
    public string ProductCode { get; set; } = null!;
    [DisplayName("Name")]
    [StringLength(250)]
    public string ProductName { get; set; } = null!;
    [DisplayName("Description")]
    [StringLength(4000)]
    public string ProductDescription { get; set; } = null!;
    [DisplayName("Expiry Date")]
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }
    [DisplayName("Category")]
    public int CategoryId { get; set; }
    [DisplayName("Image")]
    public string? ProductImage { get; set; }
    [DisplayName("Status")]
    public bool? IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual TblCategory Category { get; set; } = null!;
}
