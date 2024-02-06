using AplicacionConsola.Clases.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola.Database
{
    public class GestorVentaData
    {
        private static string stringConnection;


        static GestorVentaData()
        {
            stringConnection = "Server=localhost;Database=coderhouse;Trusted_Connection=true;";

           
        }


        public static List<Venta> GetListaVenta()
        {
            List<Venta> listaVentas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM Venta";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["Id"]);
                    string comentarios = reader.GetString(1);
                    int idUsuario = reader.GetInt32(2);

                    Venta venta = new Venta(id, comentarios, idUsuario);

                    listaVentas.Add(venta);

                }
                return listaVentas;
            }


            
            throw new Exception($"Error, no se pudo obtener la lista de Ventas");
        }

        public static Venta GetVentaPorId(int idVenta)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM Venta Where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idVenta);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string comentarios = reader.GetString(1);
                    int idUsuario = reader.GetInt32(2);

                    Venta venta = new Venta(id, comentarios, idUsuario);


                    return venta;

                }

                throw new Exception($"id: {idVenta} no encontrado, Venta no encontrada");

            }


        }

        public static bool AddVenta(Venta venta)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO Venta (Comentarios,IdUsuario) values (@comentarios,@idUsuario);";


                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@comentario", venta.Comentarios);
                command.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);
     

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }

            throw new Exception($"Venta no agregada a la lista");


        }


        public static bool UpdateVenta(int idVenta, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "UPDATE Venta SET Comentarios=@comentario,IdUsuario=@idUsuario where id = @id;";
          

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idVenta);
                command.Parameters.AddWithValue("@comentario", venta.Comentarios);
                command.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);
                connection.Open();
                return command.ExecuteNonQuery() > 0;


            }

            throw new Exception($"id: {idVenta} no encontrado, Venta no actualizada");
        }


        public static bool DeleteVenta(int idVenta)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Venta Where id = @id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idVenta);

                connection.Open();

                return command.ExecuteNonQuery() > 0;


            }

            throw new Exception($" id: {idVenta} no encontrado, Venta no eliminada");
        }


    }
}

