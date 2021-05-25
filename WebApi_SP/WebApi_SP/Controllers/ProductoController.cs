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

namespace WebApi_SP.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductoController : ApiController
    {
     
        [HttpGet]
        // GET: api/Producto
        public async Task<IHttpActionResult> Get()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_READ_PRODUCTO", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }

                con.Close();
            }

            if ((dt == null) || (dt.Rows.Count == 0))
            {
                return NotFound();
            }

            return Ok(dt);

            //string JSONresult;
            //JSONresult = JsonConvert.SerializeObject(dt);

            //return Ok(JSONresult);
        }


        [HttpPost]
        // POST: api/Producto
        public async Task<IHttpActionResult> Post(Producto producto)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_CREATE_PRODUCTO", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter("NOMBRE", producto.NOMBRE));
                    cmd.Parameters.Add(new SqlParameter("DESCRIPCION", producto.DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("PRECIO", producto.PRECIO));
                    cmd.ExecuteReader();
                }

                con.Close();
            }

            return Ok(200);
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
