using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string CodAlmacen { get; set; }
        public int CustomerId { get; set; }
        public Decimal ValorTotal { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Order() { }
        public Order(string CodAlmacen, string DescArticulo, Decimal ValorTotal, string Estado)
        {
            this.Id = 0;
            DateTime fecha = DateTime.Now;
            this.FechaHora = fecha;
            this.CodAlmacen = CodAlmacen;
            this.ValorTotal = ValorTotal;
            this.Estado = Estado;
            this.Activo = true;
            this.FechaRegistro = fecha;
            this.FechaActualizacion = fecha;
        }
    }
}