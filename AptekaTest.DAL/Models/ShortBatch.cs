using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.DAL.Models
{
    public class ShortBatch
    {
        public int Id { get; }
        public int ProductId { get; }
        public int StorageId { get; }
        public uint Count { get; }

        public ShortBatch(int id, int productId, int storageId, uint count)
        {
            Id = id;
            ProductId = productId;
            StorageId = storageId;
            Count = count;
        }
    }
}
