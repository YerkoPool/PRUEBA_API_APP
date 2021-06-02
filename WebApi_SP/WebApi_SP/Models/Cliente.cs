﻿using System;
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
        public int ID_COMUNA { get; set; }
        public string CALLE { get; set; }
        public string NUMERO { get; set; }
        public int ID_TIPO_VIVIENDA { get; set; }
        public string NRO_DEPTO { get; set; }
        public string CX { get; set; }
        public string CY { get; set; }
    }
}