using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_SP.Models
{
    public class Provincia
    {
        int ID_PROVINCIA { get; set; }
        int ID_REGION { get; set; }
        string NOMBRE { get; set; }
        int NUMERO_COMUNAS { get; set; }
    }
}