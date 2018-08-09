using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventarios.Models
{
    public class TipoMaterialvalidaModel
    {
        public int idTipo { get; set; }
        [Required (ErrorMessage ="Debe ingresar un nombre")]
        public string nombre { get; set; }
    }
}