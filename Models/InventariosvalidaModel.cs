using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaInventarios.Models
{
    public class InventariosvalidaModel
    {
        public int idinventario { get; set; }
        public int idMaterial { get; set; }
        [Required (ErrorMessage = "SE NECESITA UNA CANTIDAD")]
        public int cantidad { get; set; }
        public int idTipoEstado { get; set; }
    }
}