using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FincaToma1.Models
{
    public class Pago
    {
        [Key]
        public int IDP { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaP { get; set; }
        public double SubTotal { get; set; }

        [ForeignKey("IDE")]
        public int IDE { get; set; }
        [ForeignKey("IDE")]
        public virtual Empleado Empleado { get; set; }
    }
}
