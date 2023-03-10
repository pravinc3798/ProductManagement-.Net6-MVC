using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class ViewProductModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CategoryId { get; set; }
        public string ProductImage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }
    }
}
