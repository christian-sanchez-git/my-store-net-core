using MyStore_Domain.Entities;
using MyStore_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Application.Services
{
    public class CustomerService(ICustomerRepository CustomerRepo) : ICustomerService
    {
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await CustomerRepo.Get();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await CustomerRepo.Save(customer);
        }

        public async Task<int> ModifyCustomerInfo(Customer customer)
        {
            return await CustomerRepo.Update(customer);
        }
    }
}
