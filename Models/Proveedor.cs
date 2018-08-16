using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestacionMedicaMvc.Models
{
    public class Proveedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CodigoProveedor{get;set;}

        public string Nombre{get;set;}

        public int TipoProveedor{get;set;}

    }
}