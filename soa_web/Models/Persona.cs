using System;
using System.Collections.Generic;

namespace soa_web.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Activos = new HashSet<Activo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Discriminator { get; set; } = null!;
        public int? IdEmpleado { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Activo> Activos { get; set; }
    }
}
