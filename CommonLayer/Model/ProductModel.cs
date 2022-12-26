using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;

namespace CommonLayer.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ProductImage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
