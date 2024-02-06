using AplicacionConsola.Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola.Database
{
    public static class GestorUsuarioData
    {
        private static string stringConnection;

        static GestorUsuarioData()
        {
            stringConnection = "Server=localhost;Database=coderhouse;Trusted_Connection=true;";
        }




        public static List<Usuario> GetListaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM Usuario";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["Id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string contraseña = reader.GetString(4);
                    string email = reader.GetString(5);

                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, contraseña, email);

                    listaUsuarios.Add(usuario);

                }
                return listaUsuarios;
            }


            
            throw new Exception($"Error, no se pudo obtener la lista de usuarios");
        }

        public static Usuario GetUsuarioPorId(int idUsuario)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "SELECT * FROM Usuario Where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idUsuario);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader(); //ejecucion solo lectura aca se recuperan todos los datos en base a la sentencia query

                if (reader.Read()) // el read va a ir fila por fila obtengo un unico dato en este caso sabien si existe o no alguna fila
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string contraseña = reader.GetString(4);
                    string email = reader.GetString(5);

                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, contraseña, email);


                    return usuario;

                }

                throw new Exception($"id: {idUsuario} no encontrado, Usuario no encontrado");

            }


        }

        public static bool AddUsuario(Usuario usuario)
        {

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) values (@nombre,@apellido,@nombreUsuario,@password,@email);";


                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@nombre", usuario.Name);
                command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@nombreUsuario",usuario.NameUser);
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.Parameters.AddWithValue("@email", usuario.Email);


                connection.Open();
                return command.ExecuteNonQuery() > 0; //si es mayor a 0 es verdadero si es 0 es false primero se ejecuta la sentencia de ejeucion de datos.

                throw new Exception($"{usuario.Name} no agregado a la lista");

            }


        }


        public static bool UpdateUsuario(int idUsuario, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                string query = "UPDATE Usuario SET Nombre = @nombre,Apellido = @apellido,NombreUsuario = @nombreUsuario,Contraseña= @password,Mail=@email WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", idUsuario);
                command.Parameters.AddWithValue("@nombre", usuario.Name);
                command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@nombreUsuario", usuario.NameUser);
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.Parameters.AddWithValue("@email", usuario.Email);
                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }

            throw new Exception($"id: {idUsuario} no encontrado, Usuario no actualizado");
        }


        public static bool DeleteUsuario(int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Usuario Where id = @id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;


            }

            throw new Exception($" id: {idUsuario} no encontrado, Usuario no eliminado");
        }


    }
}

