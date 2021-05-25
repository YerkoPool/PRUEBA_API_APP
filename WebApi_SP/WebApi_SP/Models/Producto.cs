using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_SP.Models
{
    public class Producto
    {
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int PRECIO { get; set; }
    }
}