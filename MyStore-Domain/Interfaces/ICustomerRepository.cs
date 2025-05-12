using MyStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Domain.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> Get();
        public Task<Customer> GetById(int id);
        public Task<Customer> Save(Customer entity);
        public Task<int> Update(Customer entity);
    }
}
