using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IProductBL
    {
        public bool AddProduct(ProductModel formModel);
        public IEnumerable<ViewProductModel> ViewProduct();
    }
}
