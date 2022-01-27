using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Gateways
{
    public class ProductsGateway : IProductsGateway
    {
        private readonly DbConfiguration _dbConfig;

        public ProductsGateway(DbConfiguration dbConfig)
        {
            _dbConfig = dbConfig ?? throw new ArgumentNullException(nameof(dbConfig));
        }

        public async Task AddAsync(ShortProduct product)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert Products values(@name)", connection);                
                command.Parameters.Add(new SqlParameter("@name", product.Name));
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from Products where Id = @id", connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IList<ProductWithCount>> GetAll(int pharmacyId)
        {            
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select a.Id, a.Name, Sum(b.Count) from Batches as b " +
                    "inner join Storages as c on b.StorageId = c.Id " +
                    "inner join Products as a on b.ProductId = a.Id where c.PharmacyId = @pharmacyId group by a.Id, a.Name", connection);
                SqlParameter parameter = new SqlParameter("@pharmacyId", pharmacyId);
                command.Parameters.Add(parameter);
                var executionResult = await command.ExecuteReaderAsync();
                List<ProductWithCount> products = new List<ProductWithCount>();
                if (executionResult.HasRows)                
                    foreach (DbDataRecord row in executionResult)
                    {
                        products.Add(new ProductWithCount(row.GetInt32(0), row.GetString(1), row.GetInt32(2)));
                    }
                return products;
            }
        }

        public async Task<IList<ShortProduct>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Products", connection);
                var executionResult = await command.ExecuteReaderAsync();
                var products = new List<ShortProduct>();
                if (executionResult.HasRows)
                    foreach (DbDataRecord row in executionResult)
                    {
                        products.Add(new ShortProduct(row.GetInt32(0), row.GetString(1)));
                    }
                return products;
            }
        }        
    }
}
