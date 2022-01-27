using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Models
{
    public class ProductWithCount
    {
        public int Id { get; }
        public string Name { get; }
        public int Count { get; }

        public ProductWithCount(int id, string name, int count)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Count = count;
        }
    }
}
