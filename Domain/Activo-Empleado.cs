using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table ("Activos_Empleados")]
    public class Activo_Empleado 
    {
        [ForeignKey ("Empleado")] 
        public int IdEmpleado { get; set; }
        [ForeignKey("Activo")]
       
        public int Id { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha_Asignacion { get; set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha_Liberacion { get; set;}

        [Required]
        [DataType(DataType.Date)]   
        public DateTime Fecha_Entrega { get;set;}
  


    }
}
