using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendVisitaNET.Models
{
    [Table("Regional", Schema = "NIV")]
    public class Regional
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
