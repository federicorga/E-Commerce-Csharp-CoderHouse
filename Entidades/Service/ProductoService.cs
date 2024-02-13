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
    public static class ProductoService
    {

        public static List<Producto> ObtenerListaDeProductos()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                var producto = context.Productos.ToList();
                return producto;
            }

        }

        public static Producto ObtenerProductoPorID(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {

                Producto? productoBuscado = context.Productos.Where(u => u.Id == id).FirstOrDefault();

                if (productoBuscado is not null)
                {

                    return productoBuscado;
                }


                return null;


            }
        }

        public static bool AgregarProducto(Producto producto)
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                try
                {
                    if (producto is not null)
                    {
                    Usuario? idUsuarioEncontrado = context.Usuarios.Where(u =>u.Id == producto.IdUsuario).FirstOrDefault();

                    if (idUsuarioEncontrado is not null)
                    {
                        context.Productos.Add(producto);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Usuario con id: {producto.IdUsuario} no encontrado, no se puede agregar este producto");
                    }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        public static bool EliminarProducto(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
            Producto? producto = context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                if (producto is not null)
                {
                    context.Productos.Remove(producto);
                    context.SaveChanges();
                    return true;
                }
                else
                {

                    return false;

                    throw new Exception($"id: {id} no encontrado.");
                }
            }

        }

        public static bool ActualizarProductoPorId(Producto producto, int id)
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();

                    if (producto is not null)
                    {

                    Usuario? idUsuarioEncontrado = context.Usuarios.Where(u => u.Id == producto.IdUsuario).FirstOrDefault();

                    if (idUsuarioEncontrado is not null)
                    {
                        productoBuscado.Descripciones = producto.Descripciones;
                        productoBuscado.Costo = producto.Costo;
                        productoBuscado.PrecioVenta = producto.PrecioVenta;
                        productoBuscado.Stock = producto.Stock;
                        productoBuscado.IdUsuario = producto.IdUsuario;

                        context.Productos.Update(productoBuscado);
                        context.SaveChanges();

                        return true;
                    }
                    else {

                        throw new Exception($"Usuario con id: {producto.IdUsuario} no encontrado, no se puedo cambiar de usuario el producto"); }
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



