using AplicacionConsola.Clases.Models;
using AplicacionConsola.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FromProyectoFinal
{
    public partial class UsuarioForm : Form
    {

        public UsuarioForm()
        {

            InitializeComponent();

        }
        public Usuario UsuarioCreado { get; private set; }

        public Usuario UsuarioModificado { get; private set; }
        private void agregarUsuarioForm_Load(object sender, EventArgs e)
        {

        }



        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(this.txtNombre.Text,
                this.txtApellido.Text,
                this.txtNombreUsuario.Text,
                this.txtContraseña.Text,
                this.txtMail.Text);

            this.UsuarioCreado = usuario;

            this.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(this.txtNombre.Text,
                        this.txtApellido.Text,
                        this.txtNombreUsuario.Text,
                        this.txtContraseña.Text,
                        this.txtMail.Text);

            this.UsuarioModificado = usuario;

            this.Close();

        }
    }
}
