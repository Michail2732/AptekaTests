using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Gateways
{
    public interface IPharmaciesGateway
    {
        Task<IList<ShortPharmacy>> GetAllAsync();
        Task AddAsync(ShortPharmacy product);
        Task DeleteAsync(int id);        
    }
}
