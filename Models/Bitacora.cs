using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wSoftware1.Models
{
    [Table("bitacora")]
    public class Bitacora
    {
        [Key]
        public long id { get; set; }
        public DateTime fecha { get; set; }
        public string contenido { get; set; }
        public string usuario { get; set; }
    }
}
