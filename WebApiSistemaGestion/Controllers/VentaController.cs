using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.CustomExceptions;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        readonly private VentaService ventaService;

        public VentaController(VentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet("listaDeVentas")]

        public List<VentaDTO> ObtenerListaDeVentas()
        {
            try
            {
              
                var listaDeVentas = this.ventaService.ObtenerListaDeVentas();
                return listaDeVentas;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{idUsuario}")]
        public IActionResult ObtenerVentaPorIdUsuario(int idUsuario)
        {
            try
            {
                var venta = this.ventaService.ObtenerVentaPorIdUsuario(idUsuario);

                if(venta is not null)
                {
                    return Ok(venta);
                }

                return NotFound(new { Message=$"no se pudo obtener Venta con id de usuario: {idUsuario}", Status="404" });

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

        //[HttpPut("AgregarVenta")]
        //public IActionResult AgregarVenta([FromBody] VentaDTO ventaDTO)
        //{
        //    try
        //    {
        //        if (this.ventaService.AgregarVenta(ventaDTO))
        //        {
        //            return Ok(new { Message = "Venta Agregada de forma exitosa", Status = "200"});
        //        }
        //        else
        //        {
        //            return Conflict(new { Message = "No se pudo agregar la venta", Status = "409" });
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

        public IActionResult FinalizarVenta([FromQuery]int idUsuario, [FromBody]List<ProductoDTO> listaProductoDTO)
        {
            try
            {
                if (this.ventaService.FinalizarVenta(idUsuario, listaProductoDTO))
                {
                    return Ok("Venta finalizada con exito, se desconto stock de productos");
                }

                return Conflict(new { Message = "No se pudo finalizar la venta", status = "409" });
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


        //[HttpDelete("EliminarVenta")]

        //public IActionResult EliminarVenta([FromQuery]int id)
        //{
        //    try {
        //        if (this.ventaService.EliminarVenta(id))
        //        {
        //            return Ok("La venta fue eliminada de forma correcta");
        //        }
        //        else
        //        {
        //            return BadRequest($"La venta con el id: {id} no pudo ser eliminado");
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
    } 
}
