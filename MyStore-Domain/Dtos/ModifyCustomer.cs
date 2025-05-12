using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Domain.Dtos
{
    public class ModifyCustomer
    {
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Cedula { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}
