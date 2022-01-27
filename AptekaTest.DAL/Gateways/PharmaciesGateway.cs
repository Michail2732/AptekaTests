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
    public class PharmaciesGateway : IPharmaciesGateway
    {
        private readonly DbConfiguration _dbConfig;

        public PharmaciesGateway(DbConfiguration dbConfig)
        {
            _dbConfig = dbConfig ?? throw new ArgumentNullException(nameof(dbConfig));
        }

        public async Task AddAsync(ShortPharmacy pharmacy)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert Pharmacies values(@name, @adress, @number)", connection);                
                command.Parameters.Add(new SqlParameter("@name", pharmacy.Name));
                command.Parameters.Add(new SqlParameter("@adress", pharmacy.Adress));
                command.Parameters.Add(new SqlParameter("@number", pharmacy.Phone));
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from Pharmacies where Id = @id", connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IList<ShortPharmacy>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Pharmacies", connection);
                var executionResult = await command.ExecuteReaderAsync();
                var farmacies = new List<ShortPharmacy>();
                if (executionResult.HasRows)
                    foreach (DbDataRecord row in executionResult)
                    {
                        farmacies.Add(new ShortPharmacy(row.GetInt32(0), row.GetString(1), row.GetString(2), row.GetString(3)));
                    }
                return farmacies;
            }
        }
    }
}
