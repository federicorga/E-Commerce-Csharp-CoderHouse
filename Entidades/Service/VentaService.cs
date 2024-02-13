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
    public class VentaService
    {

        public static List<Venta> ObtenerListaDeVentas()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                var venta = context.Ventas.ToList();

                return venta;
            }

        }

        public static Venta ObtenerVentaPorID(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {


                Venta? ventaBuscada = context.Ventas.Where(u => u.Id == id).FirstOrDefault();

                if (ventaBuscada is not null)
                {

                    return ventaBuscada;
                }


                return null;



            }
        }

        public static bool AgregarVenta(Venta venta)
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                try
                {
                    if (venta is not null)
                    {
                        Usuario? idUsuarioEncontrado = context.Usuarios.Where(u => u.Id == venta.IdUsuario).FirstOrDefault();


                        if (idUsuarioEncontrado is not null)
                        {

                            context.Ventas.Add(venta);
                            context.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception($"Usuario con id: {venta.IdUsuario} no encontrado, no se puede agregar esta venta");
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

        public static bool EliminarVenta(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                Venta? venta = context.Ventas.Include(v => v.ProductoVendidos).Where(v => v.Id == id).FirstOrDefault();

                if (venta is not null)
                {
                    context.Ventas.Remove(venta);
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

        public static bool ActualizarVentaPorId(Venta venta, int id)
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    Venta? ventaBuscada = context.Ventas.Where(v => v.Id == id).FirstOrDefault();

                    if (venta is not null)
                    {

                       Usuario? idUsuarioEncontrado = context.Usuarios.Where(u => u.Id == venta.IdUsuario).FirstOrDefault();


                        if (idUsuarioEncontrado is not null)
                        {
                            ventaBuscada.Comentarios = venta.Comentarios;
                            ventaBuscada.IdUsuario = venta.IdUsuario;

                            context.Ventas.Update(ventaBuscada);
                            context.SaveChanges();

                            return true;
                        }else
                        {

                            throw new Exception($"Usuario con id: {venta.IdUsuario} no encontrado, no se puedo cambiar de usuario la venta");
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

