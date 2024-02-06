using AplicacionConsola.Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola.Database
{
    public class GestorProductoVendidosData
    {
        private static string stringConnection;


        static GestorProductoVendidosData()
        {
            stringConnection = "Server=localhost;Database=coderhouse;Trusted_Connection=true;";
        }


        public static List<ProductoVendido> GetListaProductoVendido()
        {
            List <ProductoVendido> listaProductosVendidos = new List<ProductoVendido> ();

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM ProductoVendido";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["Id"]);
                    int stock = reader.GetInt32(1);
                    int idProducto = reader.GetInt32(2);
                    int idVenta = reader.GetInt32(3);

                    ProductoVendido productoVendido = new ProductoVendido(id, stock, idProducto, idVenta);

                    listaProductosVendidos.Add(productoVendido);

                }
            }


            return listaProductosVendidos;
        }

        public static ProductoVendido GetProductoVendidoPorId(int idProductoVendido)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM ProductoVendido Where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idProductoVendido);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    int stock = reader.GetInt32(1);
                    int idProducto = reader.GetInt32(2);
                    int idVenta = reader.GetInt32(3);


                    ProductoVendido productoVendido = new ProductoVendido(id, stock, idProducto, idVenta);


                    return productoVendido;

                }

                throw new Exception($"id: {idProductoVendido} no encontrado, Producto vendido no encontrado");

            }


        }

        public static bool AddProductoVendido(ProductoVendido productoVendido)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) values (@stock,@idProducto,@idVenta);";


                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@idVenta", productoVendido.IdVenta);
        

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }

            throw new Exception($" Producto no agregado a la Venta");


        }


        public static bool UpdateProductoVendido(int idProductoVendido, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "UPDATE ProductoVendido SET Stock=@stock, IdProducto=@idProducto, IdVenta=@idVenta where id = @id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idProductoVendido);
                command.Parameters.AddWithValue("@stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@idVenta", productoVendido.IdVenta);
                connection.Open();
                return command.ExecuteNonQuery() > 0;


            }

            throw new Exception($"id: {idProductoVendido} no encontrado, ProductoVendido no actualizado");
        }


        public static bool DeleteProductoVendido(int idProductoVendido)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM ProductoVendido Where id = @id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idProductoVendido);

                connection.Open();

                return command.ExecuteNonQuery() > 0;


            }

            throw new Exception($" id: {idProductoVendido} no encontrado, Producto no eliminado de la Venta");
        }
    }
}
