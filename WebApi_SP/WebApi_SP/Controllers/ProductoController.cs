using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi_SP.Models;
using WebApi_SP.Services;

namespace WebApi_SP.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductoController : ApiController
    {

        [HttpGet]
        // GET: api/Producto
        public IHttpActionResult Get()
        {

            ProductoService ps = new ProductoService();
            List<Producto> producto = ps.ObtenerProducto();

            return Ok(producto);

        }


        [HttpPost]
        // POST: api/Producto
        public IHttpActionResult Post(Producto producto)
        {
            
            ProductoService ps = new ProductoService();

            Int32 MENSAJE = 0;
            Int32 ESTADO = 0;
            Boolean SUCCESS = false;


            //*************************************************************************
            // VALIDACION DE DATOS
            //*************************************************************************
            if ((producto.NOMBRE != null) && (producto.DESCRIPCION != null) && (producto.PRECIO != 0))
            {
                MENSAJE = ps.AgregarProducto(producto);          
            }
            else
            {
                MENSAJE = -1;            
            }

            //*************************************************************************
            // VALIDO QUE EL MENSAJE SEA MAYOR A CERO CUANDO FUE UNA INSERCION EXITOSA
            //*************************************************************************
            if (MENSAJE > 0)
            {
                ESTADO = (int)HttpStatusCode.OK;
                SUCCESS = true;
            }
            else
            {
                ESTADO = (int)HttpStatusCode.BadRequest;
                SUCCESS = false;
            }



            return Json(new
            {
                Success = SUCCESS,
                StatusCode = ESTADO,
                Message = MENSAJE
            });
        }


        [HttpPut]
        // PUT: api/Producto/1
        public async Task<IHttpActionResult> Put(int id, Producto producto)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_UPDATE_PRODUCTO", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter("ID_PRODUCTO", id));
                    cmd.Parameters.Add(new SqlParameter("NOMBRE", producto.NOMBRE));
                    cmd.Parameters.Add(new SqlParameter("DESCRIPCION", producto.DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("PRECIO", producto.PRECIO));
                    cmd.ExecuteReader();
                }

                con.Close();
            }

            return Ok(200);
        }
    }
}
