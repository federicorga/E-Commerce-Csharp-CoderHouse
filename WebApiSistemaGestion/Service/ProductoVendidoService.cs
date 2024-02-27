using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.Service;
using System.Linq.Expressions;
using WebApiSistemaGestion.CustomExceptions;

namespace WebApiSistemaGestion.Service
{
    public class ProductoVendidoService
    {

        private DataBaseContext context;
        public ProductoVendidoService(DataBaseContext dataBaseContext)
        {

            this.context = dataBaseContext;
        }

        public  List<ProductoVendidoDTO> ObtenerListaDeProductosVendidos()
        {
            try
            {
                var productosVendidosDTO = this.context.ProductoVendidos.Select(pv => ProductoVendidoMapper.MapearProductoVendidoAProductoVendidoDTO(pv)).ToList();
                return productosVendidosDTO;
            }
            catch(Exception ex)
            {
                throw new Exception($"No se pudo obtener la lista de productos vendidos. Detalle: {ex.Message}");
            }
            


        }

        public List<ProductoVendidoDTO> ObtenerProductosVendidosPorIdDeUsuario(int idUsuario) 
        {

            try
            {
                var listaDeProductos = this.context.Productos.Where(p => p.IdUsuario == idUsuario).ToList(); 

                if (listaDeProductos is not null)
                {
                    var listaProductosVendidosTotal = this.context.ProductoVendidos.Select(pv => pv).ToList(); 

                    if (listaProductosVendidosTotal is not null)
                    {

                        List<ProductoVendidoDTO> listaProductosVendidosDTO = new List<ProductoVendidoDTO>();

                        foreach (var productoVendido in listaProductosVendidosTotal)
                        {
                            foreach (var producto in listaDeProductos)
                            {
                                if (producto.Id == productoVendido.IdProducto)
                                {
                                    var productoVendidoDTO = ProductoVendidoMapper.MapearProductoVendidoAProductoVendidoDTO(productoVendido);
                                    listaProductosVendidosDTO.Add(productoVendidoDTO);
                                }
                            }
                        }
                        if (listaProductosVendidosDTO is not null)
                        {
                            return listaProductosVendidosDTO;
                        }else
                        {
                            throw new CustomHttpException("No se encontraron productos vendidos asociados a este usuario.",404);
                        }
                    }else
                    {
                        throw new CustomHttpException("No se encontraran productos vendiodos en la base de datos",404);
                    }
                }else
                {
                    throw new CustomHttpException("No se encontraron productos asociados a ese Usuario",404);
                }

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo obtener el producto vendido. Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public ProductoVendidoDTO? ObtenerProductoVendidoPorID(int id)
        {
            try
            {
                var productoVendidoBuscado = this.context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

                if (productoVendidoBuscado is not null)
                {
                    var productoVendidoDTO = ProductoVendidoMapper.MapearProductoVendidoAProductoVendidoDTO(productoVendidoBuscado);
                    return productoVendidoDTO;
                }

                //return null;
                throw new CustomHttpException($"Producto con id:{id} no encontrado",404);

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo obtener el producto vendido. Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public  bool AgregarProductoVendido(ProductoVendidoDTO productovendidoDTO)
        {
          
            try
            {
               
                if (productovendidoDTO is not null)
                {
                    var producto = ProductoVendidoMapper.MapearProductoVendidoDTOAProductoVendido(productovendidoDTO);
                    this.context.ProductoVendidos.Add(producto);
                    this.context.SaveChanges();
                    return true;      
                }
             
                //return false;
                throw new CustomHttpException("Formato de producto vendido invalido.",400);
                
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo agregar el producto vendido. Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public  bool EliminarProductoVendido(int id)
        {
            try
            {
                ProductoVendido? productoVendido = this.context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

                if (productoVendido is not null)
                {
                    this.context.ProductoVendidos.Remove(productoVendido);
                    this.context.SaveChanges();
                    return true;
                }
           
                //return false;

                throw new CustomHttpException($"id: {id} no encontrado.",404);

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo eliminar el producto vendido. Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public  bool ActualizarProductoVendidoPorId(ProductoVendidoDTO productovendidoDTO, int id)
        {
            try
            {
                ProductoVendido? productoVendidoBuscado = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

                if (productoVendidoBuscado is not null)
                {

                    productoVendidoBuscado = ProductoVendidoMapper.MapearProductoVendidoDTOAProductoVendido(productovendidoDTO);
                    if (productoVendidoBuscado is not null) { 
                    this.context.ProductoVendidos.Update(productoVendidoBuscado);
                    this.context.SaveChanges();

                    return true;
                    }
                    else
                    {
                      //return false;

                        throw new CustomHttpException("Formato de producto vendido invalido.",400);
                    }
                }
            
                //return false;

                throw new CustomHttpException($"Producto vendido con id: {id} no encontrado.",404);
                      
                
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo actualizar el producto vendido. Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}



