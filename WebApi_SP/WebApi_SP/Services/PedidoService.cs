using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi_SP.Models;

namespace WebApi_SP.Services
{
    public class PedidoService
    {
        public List<Pedido.PedidoGet> ObtenerPedido()
        {

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            List<Pedido.PedidoGet> _listaPedido = new List<Pedido.PedidoGet>();

            if (Conn.State != System.Data.ConnectionState.Open)
                Conn.Open();


            SqlCommand cmd = new SqlCommand("SP_READ_PEDIDO", Conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pedido.PedidoGet ped = new Pedido.PedidoGet();
                ped.ID_PEDIDO = Convert.ToInt32(reader["ID_PEDIDO"]);
                ped.ID_CLIENTE = Convert.ToInt32(reader["ID_CLIENTE"]);
                ped.IDENTIFICADOR = reader["IDENTIFICADOR"].ToString();
                ped.CLIENTE_NOMBRE = reader["CLIENTE_NOMBRE"].ToString();
                ped.ESTADO_PEDIDO = reader["ESTADO_PEDIDO"].ToString();
                ped.VALOR_TOTAL = Convert.ToInt32(reader["VALOR_TOTAL"]);
                ped.COMUNA = reader["COMUNA"].ToString();
                ped.CALLE = reader["CALLE"].ToString();
                ped.NRO_DOMICILIO = reader["NRO_DOMICILIO"].ToString();
                ped.NRO_DEPTO = reader["NRO_DEPTO"].ToString();
                ped.COMENTARIO = reader["COMENTARIO"].ToString();

                _listaPedido.Add(ped);

            }

            return _listaPedido;

        }

        public List<Pedido.PedidoGet> ObtenerPedidoId(int id)
        {

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            List<Pedido.PedidoGet> _listaPedido = new List<Pedido.PedidoGet>();

            if (Conn.State != System.Data.ConnectionState.Open)
                Conn.Open();


            SqlCommand cmd = new SqlCommand("SP_READ_PEDIDO_X_ID", Conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("ID_PEDIDO", id));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pedido.PedidoGet ped = new Pedido.PedidoGet();
                ped.ID_PEDIDO = Convert.ToInt32(reader["ID_PEDIDO"]);
                ped.ID_CLIENTE = Convert.ToInt32(reader["ID_CLIENTE"]);
                ped.IDENTIFICADOR = reader["IDENTIFICADOR"].ToString();
                ped.CLIENTE_NOMBRE = reader["CLIENTE_NOMBRE"].ToString();
                ped.ESTADO_PEDIDO = reader["ESTADO_PEDIDO"].ToString();
                ped.VALOR_TOTAL = Convert.ToInt32(reader["VALOR_TOTAL"]);
                ped.COMUNA = reader["COMUNA"].ToString();
                ped.CALLE = reader["CALLE"].ToString();
                ped.NRO_DOMICILIO = reader["NRO_DOMICILIO"].ToString();
                ped.NRO_DEPTO = reader["NRO_DEPTO"].ToString();
                ped.COMENTARIO = reader["COMENTARIO"].ToString();

                _listaPedido.Add(ped);

            }

            return _listaPedido;

        }
    }
}