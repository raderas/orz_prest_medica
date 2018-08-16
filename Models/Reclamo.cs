using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using PrestacionMedicaMvc.Public;

namespace PrestacionMedicaMvc.Models
{
    public class Reclamo
    {
        [Key]
        public int ID{get;set;}
        
        public int Año{get;set;}

        public int CorrelativoAño{get;set;}
        
        public Expediente Paciente{get;set;}

        public string Diagnostico{get;set;}

        public int Fuente {get;set;}

        public DateTime FechaNomina {get;set;}

        public ICollection<Factura> Facturas {get;set;}

        public Planilla Planilla{get;set;}
    }

}