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
using System.Web;
using System.Windows.Forms;


namespace FormEntityFramework.Forms
{
    public partial class ViewUsuarioGestor : Form
    {
        public ViewUsuarioGestor()
        {
            InitializeComponent();
        }

        public void ActualizarDGV<T>(List<T> list)
        {
            this.dgvDatos.DataSource = null;

            this.dgvDatos.DataSource = list;

            //Recibe un objeto Lista
            //limpia el data grid view y carga los datos pasados por parametro
        }

        private void btnList_Click(object sender, EventArgs e)
        {

            var usuarios = UsuarioService.ObtenerListaDeUsuarios();

            ActualizarDGV(usuarios);

        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {



            try
            {
                string stringId = this.txtId.Text;

                if (stringId != string.Empty)
                {
                    int id = Convert.ToInt32(stringId);


                    Usuario usuarioBuscado = UsuarioService.ObtenerUsuarioPorID(id);

                    if (usuarioBuscado != null)
                    {
                        List<Usuario> usuario = new List<Usuario>() { usuarioBuscado };

                        this.ActualizarDGV(usuario);
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado");
                    }

                }
                else
                {
                    MessageBox.Show("No se encuentra un valor valido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string stringId = this.txtId.Text;

                if (stringId != string.Empty)
                {
                    int id = Convert.ToInt32(stringId);

                    if (UsuarioService.EliminarUsuario(id))
                    {
                        MessageBox.Show("Usuario Eliminado");
                    }
                    else
                    {
                        MessageBox.Show("Usuario no Eliminado");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {





        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ViewUsuarioEditor viewUsuarioEditor = new ViewUsuarioEditor();

            viewUsuarioEditor.ShowDialog();


        }
    }
}
