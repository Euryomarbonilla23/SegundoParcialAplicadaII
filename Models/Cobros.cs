﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcialAplicadaII.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }
        public double BalanceCobro { get; set; }
        public int ClienteId { get; set; }
        public int Totales { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Cliente { get; set; }

        [ForeignKey("CobroId")]
        public virtual List<CobrosDetalles> Cobrosdetalles { get; set; }

        public Cobros()
        {
            Fecha = DateTime.Now;
            Cobrosdetalles = new List<CobrosDetalles>();
        }
    }
}
