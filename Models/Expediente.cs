using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PrestacionMedicaMvc.Models
{
    public class Expediente
    {
        public enum Parentescos{
            ASEGURADO,HIJO,ESPOSA
        }


        #region Main Class Definition
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="No. Carnet")]
        public string NumCarnet {get;set;}

        public string Nombre{get;set;}

        public bool Beneficiario {get;set;}

        public Empleado Empleado{get;set;}
        
        public Parentescos Parentesco {get;set;}

        [Display(Name="Fecha de nacimiento")]
        public DateTime FechaNacimiento {get;set;}

        [Display(Name="Tipo deducible")]
        public string TipoDeducible {get;set;}

        public bool Activo{get;set;}
        #endregion
    }
}