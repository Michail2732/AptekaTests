using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Gateways
{
    public interface IBatchesGateway
    {
        Task<IList<ShortBatch>> GetAllAsync();
        Task AddAsync(ShortBatch product);
        Task DeleteAsync(int id);        
    }
}
