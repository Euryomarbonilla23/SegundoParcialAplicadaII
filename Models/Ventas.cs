using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcialAplicadaII.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Cliente { get; set; }
    }
}
