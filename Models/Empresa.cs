using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PrestacionMedicaMvc.Models
{
    public class Empresa
    {
        #region Atributos no mapeables por EF
        
        [NotMapped]
        public IEnumerable<Banco> ListaBancos{get;set;}
        
        #endregion


        #region Main Class definition for EF Code First
        [Key]
        public int ID{get;set;}

        [Display(Name="Nombre")]
        public string NombreEmpresa {get;set;}

        [Display(Name="Razón Social")]
        public string RazonSocial {get;set;}

        [Display(Name="No. Patronal")]
        public string NumPatronal {get;set;}

        public string NIT {get;set;}

        [Display(Name="Teléfono")]
        public string Telefono {get;set;}

        [Display(Name="Dirección")]
        public string Direccion {get;set;}

        [Display(Name="Municipio")]
        public string Municipio {get;set;}

        [Display(Name="Depto.")]
        public string Departamento {get;set;}

        [Display(Name="No. IVA")]
        public string NumIva {get;set;}

        public int IDBanco{get;set;}
        
        [Display(Name="No. Cta. Bancaria")]
        public string NumCuentaBancaria {get;set;}

        [Display(Name="Nómina Empleados")]
        public ICollection<Empleado> Empleados {get;set;}
        #endregion

    }
}