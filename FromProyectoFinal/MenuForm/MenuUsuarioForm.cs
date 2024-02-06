using AplicacionConsola.Clases.Models;
using AplicacionConsola.Database;

namespace FromProyectoFinal
{
    public partial class MenuUsuarioForm : Form
    {
        public MenuUsuarioForm()
        {
            InitializeComponent();
        }

        private void ActualizarDgv(object objeto)
        {
            this.dgLista.DataSource = null;
            this.dgLista.DataSource = objeto;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void btnCargarDatos_Click(object sender, EventArgs e)
        {

            try
            {

                var usuarios = GestorUsuarioData.GetListaUsuarios();

                ActualizarDgv(usuarios);
                MessageBox.Show($"Lista cargada correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {
            try
            {
                string idstring = this.txtId.Text;

                int id = int.Parse(idstring);

                var usuario = GestorUsuarioData.GetUsuarioPorId(id);

                List<Usuario> user = new List<Usuario> { usuario };

                ActualizarDgv(user);
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
                UsuarioForm agregarUsuarioForm = new UsuarioForm();


                agregarUsuarioForm.ShowDialog();

                if (agregarUsuarioForm.UsuarioCreado != null)
                {
                    Usuario usuario = agregarUsuarioForm.UsuarioCreado;

                    if (GestorUsuarioData.AddUsuario(usuario))
                    {
                        MessageBox.Show("Se agrego un usuario al a Base de datos");
                    }
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
                string idstring = this.txtId.Text;

                int id = int.Parse(idstring);

                bool resultado = GestorUsuarioData.DeleteUsuario(id);

                if (resultado)
                {
                    MessageBox.Show($"El Usuario con id:{id} fue eliminado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                string idstring = this.txtId.Text;

                int id = int.Parse(idstring);


                UsuarioForm modificarUsuarioForm = new UsuarioForm();

                modificarUsuarioForm.ShowDialog();


                if (modificarUsuarioForm.UsuarioModificado != null)
                {

                    Usuario usuarioEdit = modificarUsuarioForm.UsuarioModificado;


                    if (GestorUsuarioData.UpdateUsuario(id, usuarioEdit))
                    {
                        MessageBox.Show("Se Modifico el usuario en  la Base de datos");
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo Modificar el Usuario");
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }
        

    }
}


