using Microsoft.AspNetCore.Mvc;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {


        public NombreController() {

        }

        [HttpGet] 
        public string ObtenerNombre() 
        {
            return "Federico Garea";
        }

       
    }
}
