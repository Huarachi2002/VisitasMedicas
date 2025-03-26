using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppDB.Models
{
    [Table("EmpleadoEspecialidad", Schema = "ERP")]
    public class EmpleadoEspecialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long IdEmpleado { get; set; }
        [JsonIgnore]
        public virtual Empleado? Empleado { get; set; }
        [Required]
        public long IdEspecialidad { get; set; }
        public virtual Especialidad? Especialidad { get; set; }
    }
}
