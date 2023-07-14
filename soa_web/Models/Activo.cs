using System;
using System.Collections.Generic;

namespace soa_web.Models
{
    public partial class Activo
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Date { get; set; }
        public int IdEmpleado { get; set; }

        public virtual Persona IdEmpleadoNavigation { get; set; } = null!;
    }
}
