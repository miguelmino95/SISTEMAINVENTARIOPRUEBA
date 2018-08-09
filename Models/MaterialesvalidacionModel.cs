using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventarios.Models
{
    public class MaterialesvalidacionModel
    {
        
        public int idMaterial { get; set; }
        public int idTipo { get; set; }
        [Required(ErrorMessage = "Debe ingresar un CÓDIGO")]
        public string CodMaterial { get; set; }
        [Required(ErrorMessage = "Debe ingresar una DESCRIPCIÓN")]
        public string Descripcion { get; set; }
    }
}