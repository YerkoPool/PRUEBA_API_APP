using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_SP.Models
{
    public class Cliente
    {
        public int ID_CLIENTE { get; set; }
        public string IDENTIFICADOR { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string TELEFONO { get; set; }
    }
}