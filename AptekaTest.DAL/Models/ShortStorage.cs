using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Models
{
    public class ShortStorage
    {
        public int Id { get; }
        public int PharmacyId { get; }
        public string Name { get; }

        public ShortStorage(int id, int pharmacyId, string name)
        {
            Id = id;
            PharmacyId = pharmacyId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
