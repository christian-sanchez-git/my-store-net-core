using MyStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Application.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> CreateCustomer(Customer customer);
        Task<int> ModifyCustomerInfo(Customer customer);
    }
}
