using System;
using System.Collections.Generic;

namespace soa_web.Models
{
    public partial class ActivosEmpleado
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaLiberacion { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
