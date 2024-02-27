using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.Service;
using System.Collections.Generic;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using System.Runtime.CompilerServices;
using WebApiSistemaGestion.CustomExceptions;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
       readonly private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService) {
            this.usuarioService = usuarioService;
        }


        [HttpGet("listaDeUsuarios")]
        public List<UsuarioDTO> ObtenerListaDeUsuarios()
        {
            try
            {
                var listaDeUsuarios= this.usuarioService.ObtenerListaDeUsuarios();
                return listaDeUsuarios;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{nombreDeUsuario}")]
        public ActionResult<UsuarioDTO> ObtenerUsuarioPorNombre(string nombreDeUsuario)
        {
            try
            {
                if (nombreDeUsuario is not null && nombreDeUsuario != string.Empty)
                {
                    var usuarioObtenido = this.usuarioService.ObtenerUsuarioPorNombre(nombreDeUsuario);

                    if (usuarioObtenido is not null)
                    {
                        return Ok(usuarioObtenido);
                    }
                }

                return NotFound(new { mensaje = $"el Usuario con nombre {nombreDeUsuario} no fue encontrado", Status = "404" });

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

        [HttpGet("{usuario}/{password}")]
        public ActionResult<UsuarioDTO> ObtenerUsuarioPorUserPass(string usuario, string password)
        {
            try
            {
                if (usuario is not null && usuario != string.Empty)
                {
                    var usuarioObtenido = this.usuarioService.ObtenerUsuarioPorUserPass(usuario, password);

                    if (usuarioObtenido is not null)
                    {
                        return Ok(usuarioObtenido);
                    }
                }

                return NotFound(new { mensaje = $"El usuario no se pudo logear", Status = "404" });
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

        //[HttpGet("ObtenerUsuarioPorID/{id}")]
        //public ActionResult<UsuarioDTO> ObtenerUsuarioPorID(int id)
        //{
        //    try
        //    {

        //        if (id < 0) { 

        //            return BadRequest(new { mensaje = $"el id es menor a 0 id= {id}", Status = "400" });
        //        }
        //        var usuarioObtenido = this.usuarioService.ObtenerUsuarioPorID(id);

        //        if (usuarioObtenido is not null)
        //        {
        //            return usuarioObtenido;
        //        }

        //        return NotFound(new { mensaje = $"el Usuario con id {id} no fue encontrado", Status = "404" });
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
        public IActionResult AgregarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (this.usuarioService.AgregarUsuario(usuarioDTO))
                {

                    return this.Ok(new { message = usuarioDTO, status = "200", respuesta = "Usuario agregado correctamente" });
                }
                else
                {
                    return this.Conflict(new { message = "No pudo agregar Usuario a la BD", status = "400" });
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
        public IActionResult ActualizarUsuarioPorId([FromBody] UsuarioDTO usuarioDTO, [FromQuery] int idUsuario)
        {
            try
            {

                if (this.usuarioService.ActualizarUsuarioPorId(usuarioDTO, idUsuario))
                {
                    return this.Ok(new { message = $"Usuario con ID: {idUsuario} fue modificado", status = "200" });
                }
                else
                {
                    return this.BadRequest(new { messge = $"El Usuario con ID: {idUsuario} no pudo ser modificado", status = "400" });
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

        //[HttpDelete("EliminarUsuario")]

        //public IActionResult EliminarUsuario([FromQuery] int idUsuario)
        //{
        //    try {
        //        if (this.usuarioService.EliminarUsuario(idUsuario))
        //        {
        //            return this.Ok(new { message = $"El usuario con ID: {idUsuario} fue eliminado.", status = "200" });
        //        }
        //        else {
        //            return this.BadRequest(new { message = $"El usuario con ID: {idUsuario} no pudo ser eliminado", status = "400" });
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
