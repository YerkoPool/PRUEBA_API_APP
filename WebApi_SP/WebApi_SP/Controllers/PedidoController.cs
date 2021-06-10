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
    public class PedidoController : ApiController
    {
        [HttpGet]
        // GET: api/Cliente
        public async Task<IHttpActionResult> Get()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_READ_PEDIDO", con))
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

        [HttpGet]
        // GET: api/Cliente
        public async Task<IHttpActionResult> Get(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_READ_PEDIDO_X_ID", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID_PEDIDO", id));

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
        // POST: api/Pedido
        public async Task<IHttpActionResult> Post(Pedido pedido)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_CREATE_PEDIDO_X_PRODUCTO", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter("ID_CLIENTE", pedido.ID_CLIENTE));
                    cmd.Parameters.Add(new SqlParameter("COMENTARIO", pedido.COMENTARIO));

                    DataTable dt = new DataTable();
                    //Add Columns
                    dt.Columns.Add("ID_PEDIDO_PRODUCTO");
                    dt.Columns.Add("ID_PRODUCTO");
                    dt.Columns.Add("ID_PEDIDO");
                    dt.Columns.Add("CANTIDAD");

                    //Add rows

                    foreach (Pedido_Producto pedidos in pedido.LISTA_PRODUCTO)
                    {
                        dt.Rows.Add("0", pedidos.ID_PRODUCTO,"0", pedidos.CANTIDAD);
                    }

                    SqlParameter tvparam = cmd.Parameters.AddWithValue("@LISTA", dt);
                    tvparam.SqlDbType = SqlDbType.Structured;
                    tvparam.TypeName = "dbo.PEDIDO_X_PRODUCTO";

                    cmd.ExecuteNonQuery();

                }

                con.Close();
            }

            return Ok(200);
        }

    }
}
