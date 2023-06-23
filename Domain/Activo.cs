using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Activos")]
    public class Activo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
