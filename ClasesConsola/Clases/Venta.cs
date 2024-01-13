using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola.Clases
{
    public class Venta
    {
        private int id;
        private string comentarios;
        private int idUsuario;

        public Venta(int id, string comentarios, int idUsuario)
        {
            this.id = id;
            this.comentarios = comentarios;
            this.idUsuario = idUsuario;
        }

        public int Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
