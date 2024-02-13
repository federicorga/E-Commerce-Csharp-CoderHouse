using Entidades.Database;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Service
{
    public class ProductoVendidoService
    {
        public static List<ProductoVendido> ObtenerListaDeProductosVendidos()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                var productoVendidos = context.ProductoVendidos.ToList();
                return productoVendidos;
            }

        }

        public static ProductoVendido ObtenerProductoVendidoPorID(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {

                ProductoVendido? productoVendidoBuscado = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

                if (productoVendidoBuscado is not null)
                {

                    return productoVendidoBuscado;
                }


                return null;


            }
        }

        public static bool AgregarProductoVendido(ProductoVendido productovendido)
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                try
                {
                    if (productovendido is not null)
                    {
                             
                        context.ProductoVendidos.Add(productovendido);
                        context.SaveChanges();
                        return true;
                       
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

        public static bool EliminarProductoVendido(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                ProductoVendido? productoVendido = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

                if (productoVendido is not null)
                {
                    context.ProductoVendidos.Remove(productoVendido);
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

        public static bool ActualizarProductoVendidoPorId(ProductoVendido productovendido, int id)
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ProductoVendido? productoVendidoBuscado = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

                    if (productovendido is not null)
                    {

                        if (productoVendidoBuscado is not null)
                        {

                            productoVendidoBuscado.Stock = productovendido.Stock;
                            productoVendidoBuscado.IdProducto = productovendido.IdProducto;
                            productoVendidoBuscado.IdVenta = productovendido.IdVenta;

                            context.ProductoVendidos.Update(productoVendidoBuscado);
                            context.SaveChanges();

                            return true;
                        }


                        else
                        {
                            throw new Exception($"Producto vendido con id: {productovendido.Id} no encontrado, no se puedo cambiar el producto vendido");
                        }
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



