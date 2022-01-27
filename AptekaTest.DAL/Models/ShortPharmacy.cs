using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Models
{
    public class ShortPharmacy
    {
        public int Id { get; }
        public string Name { get; }
        public string Adress { get; }
        public string Phone { get; }

        public ShortPharmacy(int id, string name, string adress, string number)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Adress = adress ?? throw new ArgumentNullException(nameof(adress));
            Phone = number ?? throw new ArgumentNullException(nameof(number));
        }
    }
}
