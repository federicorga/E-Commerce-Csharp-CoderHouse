
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEntityFramework.Forms
{
    public partial class ViewUsuarioGestor : Form
    {
        public Usuario usuarioCreado { get; private set; }
        public bool ModoEdicion { get; set; } = false;
        public ViewUsuarioGestor()
        {
            InitializeComponent();


        }

        public ViewUsuarioGestor(Usuario usuario) : this()
        {


            this.txtNombre.Text = usuario.Nombre;
            this.txtApellido.Text = usuario.Apellido;
            this.txtNombreUsuario.Text = usuario.NombreUsuario;
            this.txtPassword.Text = usuario.Contraseña;
            this.txtEmail.Text = usuario.Mail;

        }

        private void ViewUsuarioEditor_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                this.btnAgregar.Enabled = false;

            }
            else
            {

                this.btnModificar.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string nombreUsuario = txtNombreUsuario.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;

                if (nombre != string.Empty && apellido != string.Empty && nombreUsuario != string.Empty && password != string.Empty && email != string.Empty)
                {

                    Usuario usuario = new Usuario() { Nombre = nombre, Apellido = apellido, NombreUsuario = nombreUsuario, Contraseña = password, Mail = email };


                    this.usuarioCreado = usuario;



                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falta completar campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void btnModificar_Click(object sender, EventArgs e)
        {


            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string nombreUsuario = txtNombreUsuario.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;

                if (nombre != string.Empty && apellido != string.Empty && nombreUsuario != string.Empty && password != string.Empty && email != string.Empty)
                {

                    Usuario usuario = new Usuario() { Nombre = nombre, Apellido = apellido, NombreUsuario = nombreUsuario, Contraseña = password, Mail = email };


                    this.usuarioCreado = usuario;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falta completar campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
