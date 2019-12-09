using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FincaToma1.Models
{
    public class Ubicacion
    {
        [Key]
        public int IDU { get; set; }
        public string NombreU { get; set; }
    }
}
