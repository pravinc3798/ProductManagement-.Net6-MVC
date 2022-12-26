using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IProductRL
    {
        public bool AddProduct(TblProduct model);
        public IEnumerable<ViewProductModel> ViewProduct();
    }
}
