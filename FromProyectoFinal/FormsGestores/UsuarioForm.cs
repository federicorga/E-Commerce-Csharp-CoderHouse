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
        private int idUsuario;

        public Usuario UsuarioCreado { get; private set; }
        public bool ModoEdicion { get; set; } = false;
        public UsuarioForm()
        {

            InitializeComponent();

        }

        public UsuarioForm (int idUsuario) 
        {
           
            this.idUsuario = idUsuario;

            InitializeComponent();
         
        }
    
        private void agregarUsuarioForm_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                btnAgregarUsuario.Enabled = false;
            }
            else
            {
                btnModificar.Enabled = false;
            }

            if (this.idUsuario != 0)
            {

                Usuario usuarioEncontrado = GestorUsuarioData.GetUsuarioPorId(this.idUsuario);

                this.txtNombre.Text = usuarioEncontrado.Name;
                this.txtApellido.Text = usuarioEncontrado.Apellido;
                this.txtContraseña.Text = usuarioEncontrado.Password;
                this.txtMail.Text = usuarioEncontrado.Email;
                this.txtNombreUsuario.Text = usuarioEncontrado.NameUser;

            }


        }


        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string nombreUsuario = this.txtNombreUsuario.Text;
                string contraseña = this.txtContraseña.Text;
                string email = this.txtMail.Text;

                if (nombre != string.Empty && apellido != string.Empty && nombreUsuario != string.Empty && contraseña != string.Empty && email != string.Empty)
                {

                    Usuario usuario = new Usuario(nombre, apellido, nombreUsuario, contraseña, email);

                    this.UsuarioCreado = usuario;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Campos vacios, vuelva a intenralo");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {

        
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string nombreUsuario = this.txtNombreUsuario.Text;
                string contraseña = this.txtContraseña.Text;
                string email = this.txtMail.Text;

                if (nombre != "" && apellido != "" && nombreUsuario != "" && contraseña != "" && email != "")
                {
                    int id = idUsuario;


                    Usuario usuario = new Usuario(nombre, apellido, nombreUsuario, contraseña, email);

                    if (GestorUsuarioData.UpdateUsuario(id, usuario))
                    {

                        MessageBox.Show("Usuario agregado de forma exitosa!");

                        this.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Campos vacios, vuelva a intenralo");
                }

            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            

        }
    }
}
