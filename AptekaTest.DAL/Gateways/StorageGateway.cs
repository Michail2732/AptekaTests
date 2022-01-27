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
    public class StorageGateway : IStorageGateway
    {
        private readonly DbConfiguration _dbConfig;

        public StorageGateway(DbConfiguration dbConfig)
        {
            _dbConfig = dbConfig ?? throw new ArgumentNullException(nameof(dbConfig));
        }

        public async  Task AddAsync(ShortStorage storage)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert Storages values(@pharmacyId, @name)", connection);                
                command.Parameters.Add(new SqlParameter("@pharmacyId", storage.PharmacyId));
                command.Parameters.Add(new SqlParameter("@name", storage.Name));                
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from Storages where Id = @id", connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IList<ShortStorage>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Storages", connection);
                var executionResult = await command.ExecuteReaderAsync();
                var products = new List<ShortStorage>();
                if (executionResult.HasRows)
                    foreach (DbDataRecord row in executionResult)
                    {
                        products.Add(new ShortStorage(row.GetInt32(0), row.GetInt32(1), row.GetString(2)));
                    }
                return products;
            }
        }
    }
}
