using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insecap.Models.ViewModels
{
    public class ListAlumnoViewModel
    {
        public int id_alumno { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string genero { get; set; }
        public string curso { get; set; }
    }
}