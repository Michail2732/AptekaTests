using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Extensions
{
    public static class DalModelsExtensions
    {
        public static string ToFormatString(this ShortProduct product)
        {
            return $"{product.Id}\t\t{product.Name}";
        }

        public static string ToFormatString(this ShortPharmacy pharmacy)
        {
            return $"{pharmacy.Id}\t\t{pharmacy.Name}\t\t{pharmacy.Adress}\t\t{pharmacy.Phone}";
        }

        public static string ToFormatString(this ShortStorage storage)
        {
            return $"{storage.Id}\t\t{storage.PharmacyId}\t\t{storage.Name}";
        }

        public static string ToFormatString(this ShortBatch batch)
        {
            return $"{batch.Id}\t\t{batch.ProductId}\t\t{batch.StorageId}\t\t{batch.Count}";
        }

        public static string ToFormatString(this ProductWithCount product)
        {
            return $"{product.Id}\t\t{product.Name}\t\t{product.Count}";
        }        

    }
}
