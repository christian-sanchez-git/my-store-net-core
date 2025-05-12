using MyStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Application.Services
{
    public interface IOrderService
    {
        Order GetOrder();
        Order CreateOrder(Customer customer, Order order);
        Order CancelOrder(Order order);
    }
}
