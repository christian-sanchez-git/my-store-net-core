using Microsoft.EntityFrameworkCore;
using MyStore_Domain.Entities;
using MyStore_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Infrastructure.Repositories
{
    public partial class OrderRepository(TuyaDBContext context) : IOrderRepository
    {
        public async Task<IEnumerable<Order>> Get()
        {
            var lista = await context.Orders.AsNoTracking().ToListAsync();
            return lista;
        }

        public async Task<Order> GetById(int id)
        {
            var item = await context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async Task<Order> Save(Order entity)
        {
            await context.Set<Order>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Update(Order entity)
        {
            var rowsAffected = await context.Orders.Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(elemento =>
                        elemento.SetProperty(x => x.Estado, entity.Estado)
                    );
            return rowsAffected;
        }
    }
}
