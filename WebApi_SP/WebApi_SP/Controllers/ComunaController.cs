﻿using System;
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

namespace WebApi_SP.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComunaController : ApiController
    {
        [HttpGet]
        // GET: api/Cliente
        public async Task<IHttpActionResult> Get(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDConexion"].ToString()))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SP_READ_COMUNA", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID_PROVINCIA", id));

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
    }
}
