using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestacionMedicaMvc.Models
{
    public class Factura
    {
        [Key, Column(Order=0)]
        public Reclamo Reclamo{get;set;}

        [Key, Column(Order=1),DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NumeroFactura{get;set;}

        public DateTime FechaFactura{get;set;}

        public decimal Valor{get;set;}

        public decimal GastoPresentado{get;set;}

        public decimal GastoNoCubierto{get;set;}

        public decimal Deducible{get;set;}

        public decimal Coaseguro{get;set;}

        public Proveedor Proveedor{get;set;}
    }
}