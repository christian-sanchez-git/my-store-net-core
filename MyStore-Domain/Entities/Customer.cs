using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Customer() { }
        public Customer(string Cedula, string Nombre)
        {
            this.Id = 0;
            this.Cedula = Cedula;
            this.Nombre = Nombre;
            this.Activo = true;
            DateTime fecha = DateTime.Now;
            this.FechaRegistro = fecha;
            this.FechaActualizacion = fecha;
        }
    }
}