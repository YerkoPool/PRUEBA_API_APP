using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_SP.Models
{
    public class Pedido_Producto
    {
        public int ID_PEDIDO_PRODUCTO { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_PEDIDO { get; set; }
        public int CANTIDAD { get; set; }
    }
}