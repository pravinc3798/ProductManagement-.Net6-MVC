using BusinessLayer.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class ProductBL : IProductBL
    {
        private readonly IProductRL productRL;
        private readonly DbProductManagementContext dbContext;

        public ProductBL(IProductRL productRL, DbProductManagementContext dbContext)
        {
            this.productRL = productRL;
            this.dbContext = dbContext;
        }

        public bool AddProduct(ProductModel formModel)
        {
            try
            {
                var check = dbContext.TblProducts.FirstOrDefault(t => t.ProductCode == formModel.ProductCode);


                if (check == null || formModel.ProductImage.Length > (1024*1024*5))
                {
                    string cloudPath = "";

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", formModel.ProductImage.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        formModel.ProductImage.CopyTo(stream);
                    }

                    Account account = new("dfhribck9", "773724862418468", "C9C6v_j8H522pFoUA91z1WWjb_8");
                    Cloudinary cloudinary = new(account);
                    ImageUploadParams parameters = new()
                    {
                        File = new FileDescription(path),
                        PublicId = formModel.ProductCode
                    };

                    ImageUploadResult uploadDetails = cloudinary.Upload(parameters);
                    cloudPath = uploadDetails.Url.ToString();

                    TblProduct product = new()
                    {
                        ProductId = formModel.ProductId,
                        ProductCode = formModel.ProductCode.Trim(),
                        ProductName = formModel.ProductName.Trim(),
                        ProductDescription = formModel.ProductDescription.Trim(),
                        ExpiryDate = formModel.ExpiryDate,
                        CategoryId = formModel.CategoryId,
                        ProductImage = cloudPath,
                        IsActive = formModel.IsActive,
                        CreationDate = formModel.CreationDate
                    };

                    return productRL.AddProduct(product);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ViewProductModel> ViewProduct()
        {
            try
            {
                return productRL.ViewProduct();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
