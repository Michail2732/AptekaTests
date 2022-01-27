using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Gateways
{
    public interface IProductsGateway
    {
        Task AddAsync(ShortProduct product);
        Task DeleteAsync(int id);        
        Task<IList<ProductWithCount>> GetAll(int pharmacyId);
        Task<IList<ShortProduct>> GetAllAsync();
    }
}
