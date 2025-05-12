using MyStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Domain.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> Get();
        public Task<Order> GetById(int id);
        public Task<Order> Save(Order entity);
        public Task<int> Update(Order entity);
    }
}
