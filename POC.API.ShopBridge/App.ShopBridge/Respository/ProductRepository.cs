using App.ShopBridge.Models;
using App.ShopBridge.Utility;
using System.Data.SqlClient;

namespace App.ShopBridge.Respository
{
    public class ProductRepository
    {
        public string connectionString;
        private readonly ISqlDBConnection sqlDBConnection;

        public ProductRepository()
        {
            this.sqlDBConnection = new SqlDBConnection() ;
        }
        public async Task<IList<ProductModel>> Get()
        {
            var list = new List<ProductModel>();
            try
            {
                using (var conn = sqlDBConnection.GetConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "";
                        var sdr = await cmd.ExecuteReaderAsync();
                        while (sdr.Read())
                        {
                            list.Add(new ProductModel()
                            {
                                Id = (int)sdr["Id"],
                                Name = sdr["Name"].ToString(),
                                Description = sdr["Description"].ToString(),
                                Price = (double)sdr["Price"],
                                IsActive = (bool)sdr["IsActive"],
                                CreatedDateTime = (DateTime)sdr["CreatedDateTime"],
                                ModifiedDateTime = (DateTime)sdr["ModifiedDateTime"]
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                //skip
            }
            return list;
        }

        public async Task<ProductModel> Get(int id)
        {
            ProductModel productModel = null;
            try
            {
                using (var conn = sqlDBConnection.GetConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "";
                        var sdr = await cmd.ExecuteReaderAsync();
                        while (sdr.Read())
                        {
                            productModel = new ProductModel()
                            {
                                Id = (int)sdr["Id"],
                                Name = sdr["Name"].ToString(),
                                Description = sdr["Description"].ToString(),
                                Price = (double)sdr["Price"],
                                IsActive = (bool)sdr["IsActive"],
                                CreatedDateTime = (DateTime)sdr["CreatedDateTime"],
                                ModifiedDateTime = (DateTime)sdr["ModifiedDateTime"]
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                //skip
            }
            return productModel;
        }

        public async Task<string> Post(ProductModel productModel)
        {
            var result = "failed";
            try
            {
                using (var conn = sqlDBConnection.GetConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = $"INSERT INTO Product" +
                            $" (Name, Description, Price, IsActive, CreatedDateTime, ModifiedDateTime)" +
                            $" Values('{productModel.Name}', '{productModel.Description}', '{productModel.IsActive}', '{productModel.CreatedDateTime}', '{productModel.ModifiedDateTime}')";
                        var sdr = await cmd.ExecuteNonQueryAsync();
                        if (sdr > 0)
                        {
                            result = "success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //skip
            }
            return result;
        }

        public async Task<string> Put(int id, ProductModel productModel)
        {
            var result = "failed";
            try
            {
                using (var conn = sqlDBConnection.GetConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = $"UPDATE Product SET Name='{productModel.Name}' WHERE id={productModel.Id}";
                        var sdr = await cmd.ExecuteNonQueryAsync();
                        if (sdr > 0)
                        {
                            result = "success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //skip
            }
            return result;
        }

        public async Task<string> Delete(int id)
        {
            var result = "failed";
            try
            {
                using (var conn = sqlDBConnection.GetConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = $"DELETE FROM Product where id={id}";
                        var sdr = await cmd.ExecuteNonQueryAsync();
                        if (sdr > 0)
                        {
                            result = "success";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //skip
            }
            return result;
        }

    }
}
