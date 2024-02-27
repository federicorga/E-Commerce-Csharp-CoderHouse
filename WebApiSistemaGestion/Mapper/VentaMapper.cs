using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Mapper
{
    public class VentaMapper
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public static Venta MapearVentaDTOAVenta(VentaDTO ventaDTO)
        {

            Venta venta = new Venta();

            venta.Id = ventaDTO.Id;
            venta.Comentarios = ventaDTO.Comentarios;
            venta.IdUsuario= ventaDTO.IdUsuario;
  
            return venta;
        }

        public static VentaDTO MapearVentaAVentaDTO(Venta venta)
        {

            VentaDTO ventaDTO = new VentaDTO();

            ventaDTO.Id = venta.Id;
            ventaDTO.Comentarios= venta.Comentarios;
            ventaDTO.IdUsuario = venta.IdUsuario;

            return ventaDTO;
        }
    }
}
