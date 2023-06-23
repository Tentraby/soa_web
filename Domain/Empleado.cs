using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Empleado : Persona
    {
        [Required]
        public int NumEmpleado { get; set; }
        public virtual ICollection<Activo> Activos { get; set; }


    }
}
