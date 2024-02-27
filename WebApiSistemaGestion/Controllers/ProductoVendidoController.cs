using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.Models;
using WebApiSistemaGestion.Service;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.CustomExceptions;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductoVendidoController : Controller
    {

        private readonly ProductoVendidoService productoVendidoService;

        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.productoVendidoService = productoVendidoService;
        }


        [HttpGet ("listaDeProductosVendidos")]

        public List<ProductoVendidoDTO> ObtenerListaDeProductosVendidos()
        {
            try
            {
                var listaProductosVendidos = this.productoVendidoService.ObtenerListaDeProductosVendidos();
                return listaProductosVendidos;

            }
           
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet ("{idUsuario}")]

        public IActionResult ObtenerProductosVendidosPorIdDeUsuario(int idUsuario)
        {
            try
            {
                var productosVendidos = this.productoVendidoService.ObtenerProductosVendidosPorIdDeUsuario(idUsuario);

                if (productosVendidos is not null && productosVendidos.Count != 0)
                {
                    return Ok(productosVendidos);
                }
                else
                {
                    return NotFound(new { Message = "No se encontraron productos vendidos asociados a este Usuario", Status = "404" });
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
