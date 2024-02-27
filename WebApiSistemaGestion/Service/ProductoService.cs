using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApiSistemaGestion.CustomExceptions;

namespace WebApiSistemaGestion.Service
{
    public class ProductoService
    {

        private DataBaseContext context;

        public ProductoService(DataBaseContext dataBaseContext)
        {

            this.context = dataBaseContext;

        }

        public  List<ProductoDTO> ObtenerListaDeProductos()
        {
            try
            {
                var productosDTO = this.context.Productos.Select(producto => ProductoMapper.MapearProductoAProductoDTO(producto)).ToList();

                return productosDTO;
            }catch(Exception ex)
            {
                throw new Exception($"No se pudo obtener la lista de productos. Detalle: {ex.Message}");
            }

        }


        public List<ProductoDTO>? ObtenerProductosPorIdDeUsuario(int idUsuario)
        {
            try
            {
                var usuario = this.context.Usuarios.Any(u => u.Id == idUsuario);
                var listaProductosDTO = this.context.Productos.Where(p => p.IdUsuario == idUsuario).Select(p => ProductoMapper.MapearProductoAProductoDTO(p)).ToList();

                if (usuario)
                {
                    if(listaProductosDTO.Count != 0)
                    {
                        return listaProductosDTO;
                    }

                    //return null;

                    throw new CustomHttpException($"El usuario con id: {idUsuario}, no posee productos asociados a el.",404);
                }

                throw new CustomHttpException($"Usuario con id : {idUsuario} no encontrado",404);

               
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo obtener producto asociados a este usuario. Detalle: {ex.Message}", ex.HttpStatusCode); 
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
        }

        public  ProductoDTO? ObtenerProductoPorID(int id)
        {

            try
            {
                Producto? productoBuscado = this.context.Productos.Where(u => u.Id == id).FirstOrDefault();

                if (productoBuscado is not null)
                {
                    var productoDTO = ProductoMapper.MapearProductoAProductoDTO(productoBuscado);
                    return productoDTO;
                }


                //return null;

                throw new CustomHttpException($"Producto con id: {id} no encontrado",404);
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo obtener el producto . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public  bool AgregarProducto(ProductoDTO productoDto)
        {

            try
            {
                var producto = ProductoMapper.MapearProductoDTOAProducto(productoDto);
                if (producto is not null)
                {
                    Usuario? idUsuarioEncontrado = this.context.Usuarios.Where(u => u.Id == producto.IdUsuario).FirstOrDefault();

                    if (idUsuarioEncontrado is not null)
                    {
                        this.context.Productos.Add(producto);
                        this.context.SaveChanges();
                        return true;
                    }
                   
                        throw new CustomHttpException($"Usuario con id: {producto.IdUsuario} no encontrado.",404);
                    
                }

                //return false;
                throw new CustomHttpException("El producto pasado no es valido.",400);

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo agregar el producto . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    
        public  bool EliminarProducto(int id)
        {
            try
            {
                Producto? producto = this.context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                if (producto is not null)
                {
                    this.context.Productos.Remove(producto);
                    this.context.SaveChanges();
                    return true;
                }
              
                //return false;
                throw new CustomHttpException($"producto con id: {id} no encontrado.",404);
                
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo eliminar el producto . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public  bool ActualizarProductoPorId(ProductoDTO productoDTO)
        {
            try
            {

                var productoBuscado = this.context.Productos.Where(p => p.Id == productoDTO.Id).FirstOrDefault();

                var usuarioBuscado= this.context.Usuarios.Where(u=>u.Id== productoDTO.IdUsuario).FirstOrDefault();

                if(usuarioBuscado is null) throw new CustomHttpException($"Usuario con id: {productoDTO.IdUsuario} no encontrado.", 404);


                if (productoBuscado is not null)
                {

                    var producto = ProductoMapper.MapearProductoDTOAProducto(productoDTO, productoBuscado);

                    this.context.Productos.Update(producto);
                    this.context.SaveChanges();

                    return true;
                }

                //return false;
                throw new CustomHttpException($"Producto con id: {productoDTO.Id} no encontrado.", 404);

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo actualizar el producto . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        public bool ActualizarStockDeProducto(ProductoDTO productoDTO)
        {
            try
            {

              var  productoBuscado = this.context.Productos.Where(p => p.Id == productoDTO.Id).FirstOrDefault();


                if (productoBuscado is not null)
                {
                    productoBuscado.Stock=productoDTO.Stock;
                    this.context.Productos.Update(productoBuscado);
                    this.context.SaveChanges();

                    return true;
                }

                //return false;

                throw new CustomHttpException($"El producto con id: {productoDTO.Id} no encontrado.",404);
                

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo actualizar el stock del producto . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}



