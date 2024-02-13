using Entidades.Database;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Service
{

    // es la capa intermedia entre DataBase y la interface (la vista form), es la capa que interactua entre meido.
    public static class UsuarioService
    {

        public static List<Usuario> ObtenerListaDeUsuarios()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                var usuario = context.Usuarios.ToList();
                return usuario;
            }

        }

        public static Usuario ObtenerUsuarioPorID(int id)
        {
            using(DataBaseContext context = new DataBaseContext()) { 
            

                // Usuario => Usuario.Id == id (Funcion anonima)
                //Luego del Where es un Func (Usuario (usuario) => bool (usuario.Id ==id))
                //.ToList() transforma IQueryable<Usuario> en List
                //.FirstOrDefault() transforma List<usuario> en Usuario (objeto). Si este metodo no encuentra un usuario devuelve un null
    
                Usuario? usuarioBuscado = context.Usuarios.Where(u=>u.Id==id).FirstOrDefault();
                
                if (usuarioBuscado is not null){

                    return usuarioBuscado;
                }


                return null;
                

                
            }
        }

        public static bool AgregarUsuario(Usuario usuario)
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                try
                {
                    if (usuario is not null)
                    {
                        context.Usuarios.Add(usuario);
                        context.SaveChanges(); //con este metodo agregamos a la base de datos si no lo usamos no tiene impacto en la base de datos.
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }catch(Exception ex)  
                {
                    throw new Exception("El usuario no pudo ser agregado a la BD", ex);
                }
            }
              
        }

        public static bool EliminarUsuario(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                Usuario? usuario = context.Usuarios.Include(u=>u.Venta).ThenInclude(v => v.ProductoVendidos).Include(u=>u.Productos).ThenInclude(p => p.ProductoVendidos).Where(u => u.Id == id).FirstOrDefault();

                if (usuario is not null)
                {
                    context.Usuarios.Remove(usuario);
                    context.SaveChanges();
                    return true;
                }
                else {
                  
                    return false;

                    throw new Exception($"id: {id} no encontrado.");
                }
            }
            
        }

        public static bool ActualizarUsuarioPorId(Usuario usuario,int id)
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

                    if (usuario is not null)
                    {

                        usuarioBuscado.Nombre = usuario.Nombre;
                        usuarioBuscado.NombreUsuario = usuario.NombreUsuario;
                        usuarioBuscado.Apellido = usuario.Apellido;
                        usuarioBuscado.Mail = usuario.Mail;
                        usuarioBuscado.Contraseña = usuario.Contraseña;
                        //la contraseña no se modifica aqui

                        context.Usuarios.Update(usuarioBuscado);
                        context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

    }
}
