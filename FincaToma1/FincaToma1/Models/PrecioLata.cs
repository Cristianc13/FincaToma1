using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FincaToma1.Models
{
    public class PrecioLata
    {
        [Key]
        public int IDPL { get; set; }
        public int Temporada { get; set; }
        public double PrecioPL { get; set; }
    }
}
