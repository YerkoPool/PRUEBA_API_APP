using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_SP.Models
{
    public class Pedido
    {
        public int ID_PEDIDO { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_ESTADO { get; set; }
        public int ID_ESTADO_PAGO { get; set; }
        public int VALOR_TOTAL { get; set; }
        public string COMENTARIO { get; set; }
        public List<Pedido_Producto> LISTA_PRODUCTO { get; set; }

    }


}
