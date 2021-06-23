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

namespace WebApi_SP.Services
{
    public class ProductoService
    {
        public Int32 AgregarProducto(Producto producto)
        {

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int resultado = 0;

            if (Conn.State != System.Data.ConnectionState.Open)
                Conn.Open();

            SqlCommand cmd = new SqlCommand("SP_CREATE_PRODUCTO", Conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // Add parameter that will be passed to stored procedure
            cmd.Parameters.Add(new SqlParameter("NOMBRE", producto.NOMBRE));
            cmd.Parameters.Add(new SqlParameter("DESCRIPCION", producto.DESCRIPCION));
            cmd.Parameters.Add(new SqlParameter("PRECIO", producto.PRECIO));


            resultado = Convert.ToInt32(cmd.ExecuteScalar());

            if (resultado > 0)
            {
                return resultado;
            }
            else
            {
                return 0;
                        
            }
            
        }

        public List<Producto> ObtenerProducto()
        {

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            List<Producto> _listaProducto = new List<Producto>();

            if (Conn.State != System.Data.ConnectionState.Open)
                Conn.Open();


            SqlCommand cmd = new SqlCommand("SP_READ_PRODUCTO", Conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Producto prod = new Producto();
                prod.ID_PRODUCTO = Convert.ToInt32(reader["ID_PRODUCTO"]);
                prod.NOMBRE = reader["NOMBRE"].ToString();
                prod.DESCRIPCION = reader["DESCRIPCION"].ToString();
                prod.PRECIO = Convert.ToInt32(reader["PRECIO"]);

                _listaProducto.Add(prod);

            }

            return _listaProducto;

        }


    }
}