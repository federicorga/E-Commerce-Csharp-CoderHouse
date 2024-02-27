using WebApiSistemaGestion.Service;
using WebApiSistemaGestion.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.CustomExceptions;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductoController : Controller
    {

        private readonly ProductoService productoService; 
        public ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }


        [HttpGet("listaDeProductos")]
        public List<ProductoDTO> ObtenerListaDeProductos()
        {
            try
            {
                var listaDeProductos = this.productoService.ObtenerListaDeProductos();

                return listaDeProductos;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
          
        }

        [HttpGet("{idUsuario}")]

        public IActionResult ObtenerProductosPorIdDeUsuario( int idUsuario)
        {
            try
            {
                var listaDeProductosDeUnUsuario = this.productoService.ObtenerProductosPorIdDeUsuario(idUsuario);

                if (listaDeProductosDeUnUsuario is not null && listaDeProductosDeUnUsuario.Count != 0)

                {
                    return Ok(listaDeProductosDeUnUsuario);
                }
                else
                {
                    return NotFound(new { Message = "No se encontro una lista de productos relacionados a este usuario", status = "404" });
                }
            }
            catch(CustomHttpException ex)
            {
                return StatusCode(ex.HttpStatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpGet("ObtenerProductoPorID")]

        //public IActionResult ObtenerProductoPorID([FromQuery]int id)
        //{
        //    try
        //    {
        //        var productoObtenido = this.productoService.ObtenerProductoPorID(id);

        //        if (productoObtenido is not null)
        //        {
        //            return Ok(productoObtenido);
        //        }
        //        else
        //        {
        //            return NotFound(new { Message = $"Producto con id: {id} no encontrado", status = "404" });
        //        }
        //    }
        //    catch (CustomHttpException ex)
        //    {
        //        return StatusCode(ex.HttpStatusCode, new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        [HttpPost]
        public IActionResult AgregarProducto([FromBody] ProductoDTO productoDTO)
        {
            try
            {

                if (this.productoService.AgregarProducto(productoDTO))
                {

                    return this.Ok(new { message = productoDTO, status = "200", respuesta = "Producto agregado correctamente" });
                }
                else
                {
                    return this.Conflict(new { message = "No se pudo agregar el producto", status = "400" });
                }
            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.HttpStatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]

        public IActionResult ActualizarProductoPorId([FromBody] ProductoDTO productoDTO)
        {
            try
            {

                if (this.productoService.ActualizarProductoPorId(productoDTO))
                {
                    return this.Ok(new { message = $"Producto con ID: {productoDTO.Id} Modificado", status = "200" });
                }
                else
                {
                    return this.BadRequest(new { messge = $"El producto con ID: {productoDTO.Id} no pudo ser modificado", status = "400" });
                }
            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.HttpStatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{idProducto}")]

        public IActionResult EliminarProducto(int idProducto)
        {
            try
            {

                if (this.productoService.EliminarProducto(idProducto))
                {
                    return this.Ok(new { message = $"Producto con ID: {idProducto} fue eliminado con exito", status = "200" });
                }
                else
                {
                    return this.BadRequest(new { message = $"El producto con ID: {idProducto} no pudo ser eliminado", status = "400" });
                }
            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.HttpStatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
