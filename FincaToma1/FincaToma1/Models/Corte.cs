using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FincaToma1.Models
{
    public class Corte
    {
        [Key]
        public int IDC { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCorte { get; set; }
        public double LatasCortadas { get; set; }
        public double SubTotal { get; set; }

        [ForeignKey("IDE")]
        public int IDE { get; set; }
        [ForeignKey("IDE")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("IDU")]
        public int IDU { get; set; }
        [ForeignKey("IDU")]
        public virtual Ubicacion Ubicacion { get; set; }

        [ForeignKey("IDPL")]
        public int IDPL { get; set; }
        [ForeignKey("IDPL")]
        public virtual PrecioLata PrecioLata { get; set; }
    }
}
