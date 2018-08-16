using System;
using System.Collections.Generic;
using PrestacionMedicaMvc.Models;

namespace PrestacionMedicaMvc.Models.PrestacionMedicaViewControllers
{
    public class CrearEmpleadoVM
    {
        public int IDEmpleado{get;set;}
        public int Status{get;set;}
        public string Nombre{get;set;}  
        public string Apellido{get;set;}
        public string Empresa{get;set;}
        public string NombrePlanilla{get;set;}
        public string DUI{get;set;}

        public IEnumerable<String> TiposCuentasBancarias{get;}

        public IEnumerable<Banco> ListaBancos{get;set;}

        public IEnumerable<String> OpcionesStatus{get;set;}
    }
}