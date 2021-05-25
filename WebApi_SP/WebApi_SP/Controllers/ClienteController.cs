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
    public class ClienteController : ApiController
    {
        [HttpGet]
        // GET: api/Cliente
        public async Task<IHttpActionResult> Get()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_READ_CLIENTE", con))
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
        // POST: api/Cliente
        public async Task<IHttpActionResult> Post(Cliente cliente)
        {
            int ESTADO = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_CREATE_CLIENTE", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter("IDENTIFICADOR", cliente.IDENTIFICADOR));
                    cmd.Parameters.Add(new SqlParameter("NOMBRE", cliente.NOMBRE));
                    cmd.Parameters.Add(new SqlParameter("APELLIDO", cliente.APELLIDO));
                    cmd.Parameters.Add(new SqlParameter("TELEFONO", cliente.TELEFONO));
                    ESTADO = cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            return Ok(200);
        }


        [HttpPut]
        // PUT: api/Cliente/1
        public async Task<IHttpActionResult> Put(int id, Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_UPDATE_CLIENTE", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter("ID_CLIENTE", cliente.ID_CLIENTE));
                    cmd.Parameters.Add(new SqlParameter("IDENTIFICADOR", cliente.IDENTIFICADOR));
                    cmd.Parameters.Add(new SqlParameter("NOMBRE", cliente.NOMBRE));
                    cmd.Parameters.Add(new SqlParameter("APELLIDO", cliente.APELLIDO));
                    cmd.Parameters.Add(new SqlParameter("TELEFONO", cliente.TELEFONO));
                    cmd.ExecuteReader();
                }

                con.Close();
            }

            return Ok(200);
        }


        [HttpDelete]
        // DELETE: api/Cliente/1
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_DELETE_CLIENTE", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter("ID_CLIENTE", id));
                    cmd.ExecuteReader();
                }

                con.Close();
            }

            return Ok(200);
        }
    }
}
