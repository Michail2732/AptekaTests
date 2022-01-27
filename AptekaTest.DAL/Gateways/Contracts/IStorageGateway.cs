using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Gateways
{
    public interface IStorageGateway
    {
        Task<IList<ShortStorage>> GetAllAsync();
        Task AddAsync(ShortStorage product);
        Task DeleteAsync(int id);        
    }
}
