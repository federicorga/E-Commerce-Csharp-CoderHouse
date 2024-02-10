using FormEntityFramework.Forms;

namespace FormEntityFramework
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAccesoUsuario_Click(object sender, EventArgs e)
        {
            ViewUsuarioGestor viewUsuarioGestor = new ViewUsuarioGestor();

            viewUsuarioGestor.ShowDialog();
        }
    }
}
