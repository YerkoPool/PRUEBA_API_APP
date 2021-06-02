using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class UbicacionController : ApiController
    {
        [HttpPost]
        // POST: api/Cliente
        public async Task<IHttpActionResult> Post(Ubicacion ubicacion)
        {
            int ESTADO = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_CREATE_UBICACION", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter("ID_CLIENTE", ubicacion.ID_CLIENTE ));
                    cmd.Parameters.Add(new SqlParameter("ID_COMUNA", ubicacion.ID_COMUNA));
                    cmd.Parameters.Add(new SqlParameter("CALLE", ubicacion.CALLE));
                    cmd.Parameters.Add(new SqlParameter("NUMERO", ubicacion.NUMERO));
                    cmd.Parameters.Add(new SqlParameter("ID_TIPO_VIVIENDA", ubicacion.ID_TIPO_VIVIENDA));
                    cmd.Parameters.Add(new SqlParameter("NRO_DEPTO", ubicacion.NRO_DEPTO));
                    cmd.Parameters.Add(new SqlParameter("CX", ubicacion.CX));
                    cmd.Parameters.Add(new SqlParameter("CY", ubicacion.CY));

                    ESTADO = cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            return Ok(200);
        }
    }
}
