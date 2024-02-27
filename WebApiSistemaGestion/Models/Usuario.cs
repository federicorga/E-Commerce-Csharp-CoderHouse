using System;
using System.Collections.Generic;

namespace WebApiSistemaGestion.Models
{
    public partial class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Mail { get; set; } = null!;

        //con el metodo Include de Entity en el Where pido que me traiga estas listas que proviene de la base de datos relacioanada al Usuario. Me trae Productos y Venta relacionados a ese Usuario para por ejemplo eliminar el usuario y los productos y las ventas relacionadas.
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }

        public Usuario()
        {
            Productos = new HashSet<Producto>();
            Venta = new HashSet<Venta>();
        }


      


        

    }
}
