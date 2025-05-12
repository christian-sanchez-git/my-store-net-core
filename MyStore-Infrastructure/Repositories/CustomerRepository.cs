using Microsoft.EntityFrameworkCore;
using MyStore_Domain.Entities;
using MyStore_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyStore_Infrastructure.Repositories
{
    public class CustomerRepository(TuyaDBContext context) : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> Get()
        {
            var lista = await context.Customers.AsNoTracking().ToListAsync();
            return lista;
        }

        public async Task<Customer> GetById(int id)
        {
            var item = await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async Task<Customer> Save(Customer entity)
        {
            await context.Set<Customer>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Update(Customer entity)
        {
            var rowsAffected = await context.Customers.Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(elemento =>
                        elemento.SetProperty(x => x.Cedula, entity.Cedula)
                                .SetProperty(x => x.Nombre, entity.Nombre)
                                .SetProperty(x => x.Activo, entity.Activo)
                    );
            return rowsAffected;
        }
    }
}
