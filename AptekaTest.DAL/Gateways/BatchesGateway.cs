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
    public class BatchesGateway: IBatchesGateway
    {
        private readonly DbConfiguration _dbConfig;

        public BatchesGateway(DbConfiguration dbConfig)
        {
            _dbConfig = dbConfig ?? throw new ArgumentNullException(nameof(dbConfig));
        }

        public async Task AddAsync(ShortBatch batch)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert Batches values(@productId, @storageId, @count)", connection);                
                command.Parameters.Add(new SqlParameter("@productId", batch.ProductId));
                command.Parameters.Add(new SqlParameter("@storageId", batch.StorageId));
                command.Parameters.Add(new SqlParameter("@count", (int)batch.Count));
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from Batches where Id = @id", connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IList<ShortBatch>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Batches", connection);                                
                var executionResult = await command.ExecuteReaderAsync();
                List<ShortBatch> batches = new List<ShortBatch>();
                if (executionResult.HasRows)
                    foreach (DbDataRecord row in executionResult)
                    {
                        batches.Add(new ShortBatch(row.GetInt32(0), row.GetInt32(1), row.GetInt32(2), (uint)row.GetInt32(3)));
                    }
                return batches;
            }
        }
    }
}
