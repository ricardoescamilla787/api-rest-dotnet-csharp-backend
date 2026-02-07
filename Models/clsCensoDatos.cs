using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiRESTCenso.Models
{
    public class clsCensoDatos
    {
        // Estructura de los datos
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string rol { get; set; }
    }
}