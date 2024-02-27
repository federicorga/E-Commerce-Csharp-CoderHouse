using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.DTOs;
using System.Threading.Tasks.Dataflow;
using WebApiSistemaGestion.CustomExceptions;

namespace WebApiSistemaGestion.Service
{
    public class VentaService
    {
     
        private DataBaseContext context;
        private ProductoService productoService;
        private ProductoVendidoService productoVendidoService;
        private UsuarioService usuarioService;
      
        public VentaService(DataBaseContext dataBaseContext)
        {

            this.context = dataBaseContext;
            this.productoService = new ProductoService(dataBaseContext);
            this.productoVendidoService= new ProductoVendidoService(dataBaseContext);
            this.usuarioService= new UsuarioService(dataBaseContext);
      

        }

        public List<VentaDTO> ObtenerListaDeVentas()
        {
            try
            {
                var listaVentas = this.context.Ventas.Select(venta => VentaMapper.MapearVentaAVentaDTO(venta)).ToList();
                return listaVentas;

            }catch (Exception ex)
            {
                throw new Exception($"No se pudo obtener la lista de Ventas. Detalle: {ex.Message}");
            }
           
        }


        public VentaDTO? ObtenerVentaPorIdUsuario(int idUsuario)
        {
            try
            {
                Venta? ventaBuscada = this.context.Ventas.Where(v => v.IdUsuario == idUsuario).FirstOrDefault();
                if (ventaBuscada is not null)
                {
                    var ventaDTO = VentaMapper.MapearVentaAVentaDTO(ventaBuscada);
                    return ventaDTO;

                }

                //return null;
                throw new CustomHttpException($"Venta con id de usuario: {idUsuario} no encontrada",404);

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo obtener la venta . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  VentaDTO? ObtenerVentaPorID(int id)
        {
            try
            {
                Venta? ventaBuscada = this.context.Ventas.Where(u => u.Id == id).FirstOrDefault();

                if (ventaBuscada is not null)
                {
                    var ventaDTO = VentaMapper.MapearVentaAVentaDTO(ventaBuscada);
                    return ventaDTO;
                }

                //return null;
                throw new CustomHttpException($"Venta con id: {id} no encontrada",404);

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo obtener la venta . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }   

        public  bool AgregarVenta(VentaDTO ventaDTO)
        {

          
            try
            {
                if (ventaDTO is not null)
                {
                    Usuario? idUsuarioEncontrado = this.context.Usuarios.Where(u => u.Id == ventaDTO.IdUsuario).FirstOrDefault();


                    if (idUsuarioEncontrado is not null)
                    {
                        var venta = VentaMapper.MapearVentaDTOAVenta(ventaDTO);
                        this.context.Ventas.Add(venta);
                        this.context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //return false;
                        throw new CustomHttpException($"Usuario con id: {ventaDTO.IdUsuario} no encontrado.",404);
                    }
                }
              
                //return false;
                throw new CustomHttpException("Formato de venta invalida.",400);
                
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo agregar la venta . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public  bool EliminarVenta(int id)
        {
            try
            {
                Venta? venta = this.context.Ventas.Include(v => v.ProductoVendidos).Where(v => v.Id == id).FirstOrDefault();

                if (venta is not null)
                {
                    this.context.Ventas.Remove(venta);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {

                    //return false;

                    throw new CustomHttpException($"venta con id: {id} no encontrado.",404);
                }
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo eliminar la venta . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool ActualizarVentaPorId(VentaDTO ventaDTO, int id)
        {
            try
            {
                if (ventaDTO is not null)
                {
                    Usuario? idUsuarioEncontrado = this.context.Usuarios.Where(u => u.Id == ventaDTO.IdUsuario).FirstOrDefault();

                    if (idUsuarioEncontrado is not null)
                    {
                        Venta? ventaBuscada = this.context.Ventas.Where(v => v.Id == id).FirstOrDefault();

                        if (ventaBuscada is not null)
                        {
                            var venta = VentaMapper.MapearVentaDTOAVenta(ventaDTO);
                            this.context.Ventas.Update(venta);
                            this.context.SaveChanges();
                            return true;
                        }
                        else
                        {
                            //return false;
                            throw new CustomHttpException($"la venta con id : {id} no fue encontrada.",404);
                        }
                    }
                    else
                    {
                        throw new CustomHttpException($"Usuario con id: {ventaDTO.IdUsuario} no encontrado.",404);
                    }  
                }
                
                //return false;
                throw new CustomHttpException("Formato de venta invalido.",400);                

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo actualizar la venta . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        
        public bool FinalizarVenta(int idUsuario, List<ProductoDTO> listaProductoDTO)
        {
            try
            {

                if (this.usuarioService.ObtenerUsuarioPorID(idUsuario) is not null)
                {

                    var nuevaVenta = new Venta();

                    var nombreDeProducto = listaProductoDTO.Select(p => p.Descripciones).ToList();

                    nuevaVenta.Comentarios = string.Join("-", nombreDeProducto);
                    nuevaVenta.IdUsuario = idUsuario;



                    this.context.Ventas.Add(nuevaVenta);
                    this.context.SaveChanges();


                    this.ActualizarStockProductoYAgregrarProductoVendido(listaProductoDTO, nuevaVenta.Id);

                    return true;
                }

                return false;
                throw new CustomHttpException($"Usuario con {idUsuario}, no existe", 404);

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo finalizar la venta . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public bool ActualizarStockProductoYAgregrarProductoVendido(List<ProductoDTO> listaProductosDTO, int idVenta)
        {

            try
            {
                List<ProductoDTO> nuevaListaProductoDTO = new List<ProductoDTO>();

                foreach (var productoDTO in listaProductosDTO)
                {
                    var productoObtenidoDTODeBD = this.productoService.ObtenerProductoPorID(productoDTO.Id);

                    if (productoObtenidoDTODeBD.Stock <= 0)
                    {
                        continue;
                    }

                    if (productoObtenidoDTODeBD.Stock < productoDTO.Stock)
                    {
                        productoDTO.Stock = productoObtenidoDTODeBD.Stock;

                        nuevaListaProductoDTO.Add(productoDTO);

                        productoObtenidoDTODeBD.Stock = 0;
                        this.productoService.ActualizarStockDeProducto(productoObtenidoDTODeBD);

                        continue;
                    }

                    productoObtenidoDTODeBD.Stock -= productoDTO.Stock;

                    this.productoService.ActualizarStockDeProducto(productoObtenidoDTODeBD);

                    nuevaListaProductoDTO.Add(productoDTO);
                }

                if (nuevaListaProductoDTO is not null)
                {


                    if (MarcarComoProductoVendido(nuevaListaProductoDTO, idVenta))
                    {
                        return true;
                    }
                }

                return false;

            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se pudo actualizar el stock del producto y agregar producto vendido relacionado con la venta finalizada. Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public bool MarcarComoProductoVendido(List<ProductoDTO> listaProductosDTO, int idVenta) 
        {
            try
            {
                var productoVendidoDTO = new ProductoVendidoDTO();


                listaProductosDTO.ForEach(productoDTO =>
                {
                    productoVendidoDTO.IdProducto = productoDTO.Id;
                    productoVendidoDTO.Stock = productoDTO.Stock;
                    productoVendidoDTO.IdVenta = idVenta;
                    this.productoVendidoService.AgregarProductoVendido(productoVendidoDTO);

                });

                return true;
            }
            catch (CustomHttpException ex)
            {
                throw new CustomHttpException($"No se Marcar como ProductoVendido . Detalle: {ex.Message}", ex.HttpStatusCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




    }
}

