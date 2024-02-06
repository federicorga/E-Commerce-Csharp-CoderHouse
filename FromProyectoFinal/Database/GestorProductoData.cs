using AplicacionConsola.Clases.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola.Database
{
    public class GestorProductoData
    {
        private static string stringConnection;

     
        static GestorProductoData()
        {
            stringConnection = "Server=localhost;Database=coderhouse;Trusted_Connection=true;";
        }


        public static List<Producto> GetListaProducto()
        {
            List<Producto> listaProductos= new List<Producto>();
         
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM Producto";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

               

                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string descripcion = reader.GetString(1);
                    double costo = Convert.ToDouble(reader.GetDecimal(2));
                    double precioVenta=Convert.ToDouble(reader.GetDecimal(3));
                    int stock=reader.GetInt32(4);
                    int idUsuario=reader.GetInt32(5);

                    Producto producto = new Producto(id, descripcion,costo, precioVenta, stock, idUsuario);

                    listaProductos.Add(producto);

                }
            }


            return listaProductos ;
        }

        public static Producto GetProductoPorId(int idProducto)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM Producto Where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idProducto);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) 
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string descripcion = reader.GetString(1);
                    double costo = Convert.ToDouble(reader.GetDecimal(2));
                    double precioVenta = Convert.ToDouble(reader.GetDecimal(3));
                    int stock = reader.GetInt32(4);
                    int idUsuario = reader.GetInt32(5);

                    Producto producto = new Producto(id, descripcion, costo, precioVenta, stock, idUsuario);


                    return producto;

                }

                throw new Exception($"id: {idProducto} no encontrado, Producto no encontrado");

            }


        }

        public static bool AddProducto(Producto producto)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) values (@descripcion,@costo,@precioVenta,@stock,@idUsuario);";


                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@costo", producto.Costo);
                command.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);



                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }

            throw new Exception($"{producto.Descripcion} no agregado a la lista");


        }


        public static bool UpdateProducto(int idProducto, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "UPDATE Producto SET Descripciones@descripcion, Costo=@costo, PrecioVenta=@precioVenta, Stock=@stock, IdUsuario=@idUsuario  where id = @id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idProducto);
                command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@costo", producto.Costo);
                command.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                connection.Open();
                return command.ExecuteNonQuery() > 0;


            }

            throw new Exception($"id: {idProducto} no encontrado, Producto no actualizado");
        }


        public static bool DeleteProducto(int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Producto Where id = @id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idProducto);

                connection.Open();

                return command.ExecuteNonQuery() > 0;


            }

            throw new Exception($" id: {idProducto} no encontrado, Producto no eliminado");
        }


    }
}

