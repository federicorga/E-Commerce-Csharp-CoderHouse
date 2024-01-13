using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola.Clases
{
    public class Usuario
    {
        private int id;
        private string name;
        private string apellido;
        private string nameUser;
        private int password;
        private string email;

        public Usuario(int id, string name, string apellido, string nameUser, int password, string email)
        {
            this.id = id;
            this.name = name;
            this.apellido = apellido;
            this.nameUser = nameUser;
            this.password = password;
            this.email = email;

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NameUser { get => nameUser; set => nameUser = value; }
        public int Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }


    }
}

