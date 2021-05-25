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
        int ID_PEDIDO { get; set; }
        int ID_CLIENTE { get; set; }
        int ESTADO { get; set; }
        int CANTIDAD_ITEM { get; set; }
        int VALOR_TOTAL { get; set; }
        int COMENTARIO { get; set; }
    }
}
