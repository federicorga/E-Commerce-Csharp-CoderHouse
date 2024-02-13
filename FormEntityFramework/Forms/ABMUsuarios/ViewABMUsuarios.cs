
using Entidades.Models;
using Entidades.Service;
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
    public partial class ViewABMUsuarios : Form
    {
        public Usuario usuarioSeleccionado { get; private set; }
        public ViewABMUsuarios()
        {
            InitializeComponent();
        }

        private void ActualizarDGV<T>(List<T> list)
        {
            this.dgvDatos.DataSource = null;

            this.dgvDatos.DataSource = list;

            //Recibe un objeto Lista
            //limpia el data grid view y carga los datos pasados por parametro
        }

        private int ObtenerId()
        {
            string stringId = this.txtId.Text;
            if (!string.IsNullOrEmpty(stringId))
            {
                int id = Convert.ToInt32(stringId);
                return id;
            }

            return -1;

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
                        MessageBox.Show($"Usuario con id: {id} inexistente", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Complete el campo Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtId.Focus();
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

                        var usuarios = UsuarioService.ObtenerListaDeUsuarios();

                        ActualizarDGV(usuarios);

                        MessageBox.Show("Usuario Eliminado");
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo eliminar el usuario con id: {id}", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No ingreso ningun Id", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ViewUsuarioGestor viewUsuarioEditor = new ViewUsuarioGestor();

                viewUsuarioEditor.ShowDialog();

                Usuario usuario = viewUsuarioEditor.usuarioCreado;

                if (UsuarioService.AgregarUsuario(usuario))
                {

                    var usuarios = UsuarioService.ObtenerListaDeUsuarios();

                    ActualizarDGV(usuarios);
                    MessageBox.Show("Se agrego un nuevo usuario!");
                }
                else
                {
                    MessageBox.Show("el usuario no fue creado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario usuario = this.usuarioSeleccionado;

            if (this.usuarioSeleccionado is not null)
            {

                ViewUsuarioGestor viewUsuarioEditor = new ViewUsuarioGestor(usuario);
                viewUsuarioEditor.ModoEdicion = true;
                viewUsuarioEditor.ShowDialog();

                Usuario usuarioModificado = viewUsuarioEditor.usuarioCreado;
                if (UsuarioService.ActualizarUsuarioPorId(usuarioModificado, this.usuarioSeleccionado.Id))
                {

                    var usuarios = UsuarioService.ObtenerListaDeUsuarios();

                    ActualizarDGV(usuarios);

                    MessageBox.Show("El usuario se modifico correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No selecciono ningun elemento de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            //Me permite almacenera en usuarioSeleccionado lo que yo estoy seleccionando en la dgList 
            var seleccion = this.dgvDatos.SelectedRows;

            if (seleccion.Count > 0)
            {
                var dato = seleccion[0].DataBoundItem;
                this.usuarioSeleccionado = dato as Usuario; //Casteo cambio dato(tipo objeto) a tipo usuario
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
