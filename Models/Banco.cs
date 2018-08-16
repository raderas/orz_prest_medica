using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PrestacionMedicaMvc.Models
{
  
    public class Banco
    {
        public enum TipoCuenta
        {
            CORRIENTE,AHORRO
        }

        [NotMapped]
        public Dictionary<Banco.TipoCuenta,string> TiposCuentas;

        #region Main Class Definition
        public int ID{get;set;}

        [Required]
        [StringLength(30)]
        [Display(Name="Banco")]
        public String NombreBanco {get; set;}

        [Display(Name="Código Cta. Ahorro")]
        public int CodigoCuentaAhorro {get;set;}

        [Display(Name="Código Cta. Cte.")]
        public int CodigoCuentaCorriente {get;set;}

        [Display(Name="Formato Archivo Pago")]
        public string FormatoArchivo {get;set;}

        [Display(Name="Ultimo Corr. Usado")]
        public int Correlativo {get; set;}
        #endregion
    }
}