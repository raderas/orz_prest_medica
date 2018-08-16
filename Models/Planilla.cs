using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PrestacionMedicaMvc.Models
{
    public class Planilla
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String IDPlanilla{get;set;}
        
        public DateTime FechaInicial {get;set;}

        public DateTime FechaFinal {get;set;}

        public string Descripcion {get;set;}

        public bool PlanillaAbierta{get;set;}

        public Empresa Empresa{get;set;}

        public ICollection<Reclamo> Reclamos{get;set;}
    }
}