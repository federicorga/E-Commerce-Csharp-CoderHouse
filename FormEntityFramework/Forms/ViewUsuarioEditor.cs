using FormEntityFramework.Models;
using FormEntityFramework.Service;
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
    public partial class ViewUsuarioEditor : Form
    {
        public ViewUsuarioEditor()
        {
            InitializeComponent();
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


                    UsuarioService.AgregarUsuario(usuario);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falta completar campos");
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



    }
}
