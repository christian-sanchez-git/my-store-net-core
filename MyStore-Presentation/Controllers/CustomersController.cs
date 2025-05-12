using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyStore_Application.Services;
using MyStore_Domain.Dtos;
using MyStore_Domain.Entities;

namespace MyStore_Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController(ICustomerService CustomerService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetPersonas()
        {
            var lista = await CustomerService.GetCustomers();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomer customer)
        {
            Customer entity = new Customer(customer.Cedula, customer.Nombre);
            return await CustomerService.CreateCustomer(entity);

            // Se llama al metodo GET GetPersona para entregar respuesta al usuario:
            /*return CreatedAtAction(nameof(GetPersona),
                new { personaId = personaDB.Id },
                personaDB
            );*/
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult<Customer>> PutCustomer([FromRoute] int customerId, [FromBody] ModifyCustomer customer)
        {
            Customer entity = new Customer();
            entity.Id = customerId;
            entity.Cedula = customer.Cedula;
            entity.Nombre = customer.Nombre;
            entity.Activo = customer.Activo;

            int rowsAffected = await CustomerService.ModifyCustomerInfo(entity);

            if (rowsAffected == 0)
            {
                //logger.LogInformation(" PutPersona : NotFound personaId: " + personaId.ToString());
                return NotFound("No se encontró ningun Customer con el Id ingresado.");
            }
            return Ok();
        }
    }


}