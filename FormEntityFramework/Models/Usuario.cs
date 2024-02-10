using System;
using System.Collections.Generic;

namespace FormEntityFramework.Models
{
    public partial class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Mail { get; set; } = null!;

                public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Ventas> Venta { get; set; }


        public Usuario()
        {
            Productos = new HashSet<Producto>();
            Venta = new HashSet<Ventas>();
        }


      


        

    }
}
