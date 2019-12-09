using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FincaToma1.Models
{
    public class Empleado
    {
        [Key]
        public int IDE { get; set; }
        public string NombreE { get; set; }
        public string ApellidoE { get; set; }
        public string TelefonoE { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaE { get; set; }
    }
}
