using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Data.Common;
using System.Reflection.PortableExecutable;

namespace RepositoryLayer.Service
{
    public class ProductRL : IProductRL
    {
        private readonly DbProductManagementContext dbContext;

        public ProductRL(DbProductManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddProduct(TblProduct model)
        {
            try
            {
                int result = dbContext.Database.ExecuteSqlRaw("EXECUTE spAddProduct {0},{1},{2},{3},{4},{5},{6},{7}",
                    model.ProductCode, model.ProductName, model.ProductDescription, model.ExpiryDate, model.CategoryId, model.ProductImage, model.IsActive, DateTime.Now.Date);

                return result > 0;
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
                List<ViewProductModel> products = new List<ViewProductModel>();

                var cmd = dbContext.Database.GetDbConnection().CreateCommand();
                using (cmd)
                {
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.CommandText = "spViewProducts";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    DbDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            products.Add(new ViewProductModel()
                            {
                                ProductId = reader.GetInt32(0),
                                ProductCode = reader.GetString(1),
                                ProductName = reader.GetString(2),
                                ProductDescription = reader.GetString(3),
                                ExpiryDate = reader.GetDateTime(4),
                                CategoryId = reader.GetInt32(5),
                                ProductImage = reader.GetString(6),
                                IsActive = reader.GetBoolean(7),
                                CreationDate = reader.GetDateTime(8),
                                Category = reader.GetString(9),
                            });
                        }
                        return products;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
