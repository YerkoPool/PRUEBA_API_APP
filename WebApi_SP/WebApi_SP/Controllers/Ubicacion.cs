using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_SP.Controllers
{
    public class Ubicacion
    {
        int ID_UBICACION { get; set; }
        int ID_CLIENTE { get; set; }
        int ID_COMUNA { get; set; }
        string CALLE { get; set; }
        string NUMERO { get; set; }
        int ID_TIPO_VIVIENDA { get; set; }
        string NRO_DEPTO { get; set; }
        string CX { get; set; }
        string CY { get; set; }

    }
}