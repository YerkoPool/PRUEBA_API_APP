using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_SP.Models
{
    public class Comuna
    {
        int ID_COMUNA { get; set; }
        int ID_PROVINCIA { get; set; }
        string NOMBRE { get; set; }
    }
}