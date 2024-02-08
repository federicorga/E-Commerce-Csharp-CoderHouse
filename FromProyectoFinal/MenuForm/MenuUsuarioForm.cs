using AplicacionConsola.Clases.Models;
using AplicacionConsola.Database;

namespace FromProyectoFinal
{
    public partial class btnEdit : Form
    {

        public int idUsuario { get; private set; }
        public btnEdit()
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
                    MessageBox.Show($"El Usuario con id: {id} fue eliminado!");
                }
                else
                {
                    MessageBox.Show($"Usuario con id: {id} no encontrado!");
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

                if (this.txtId.Text != "")
                {

                    string idstring = this.txtId.Text;

                    idUsuario = int.Parse(idstring);

                    if (GestorUsuarioData.GetUsuarioPorId(idUsuario) is not null)
                    {
                       

                        UsuarioForm modificarUsuarioForm = new UsuarioForm(idUsuario);

                        modificarUsuarioForm.ModoEdicion = true;

                        modificarUsuarioForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un id Valido");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }


        }

      
    }
}


