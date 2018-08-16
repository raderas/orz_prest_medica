using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace PrestacionMedicaMvc.Models
{


    public class Empleado
    {
        #region Atributos no mapeables por EF
        [NotMapped]
        public IEnumerable<Banco> ListaBancos { get; set; }

        [NotMapped]
        public Dictionary<Empleado.StatusEmpleado, String> OpcionesStatusEmpleado;

        [NotMapped]
        public IEnumerable<Empresa> ListaEmpresas {get;set;}

        public enum StatusEmpleado
        {
            PERMANENTE, INTERINO, EVENTUAL, TERMINADO
        }
        #endregion


        #region Class Definition for EF Code First
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID de Empleado")]
        public int IDempleado { get; set; }

        [Display(Name = "Status")]
        public String Status { get; set; }

        [Display(Name = "Nombres")]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        public string Apellido { get; set; }
        public Empresa Empresa { get; set; }

        [Display(Name = "Nombre en planilla")]
        public string NombrePlanilla { get; set; }

        [Display(Name = "No. DUI")]
        public string DUI { get; set; }

        [Display(Name = "Banco")]
        public Banco BancoCuenta { get; set; }

        [Display(Name = "Número de Cuenta")]
        public string NumeroCuenta { get; set; }

        [Display(Name = "Tipo de Cuenta")]
        public string TipoCuenta { get; set; }

        [Display(Name = "Departamento")]
        public string CentroDeCosto { get; set; }

        public ICollection<Expediente> Expedientes { get; set; }
        #endregion
    }
}