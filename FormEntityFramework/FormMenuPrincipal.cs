using FormEntityFramework.Forms;
using FormEntityFramework.Forms.ABMProductos;
using FormEntityFramework.Forms.ABMProductosVendidos;
using FormEntityFramework.Forms.ABMVentas;

namespace FormEntityFramework
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
                  
        }

        private void btnAccesoUsuario_Click(object sender, EventArgs e)
        {
            ViewABMUsuarios ViewABMUsuarios = new ViewABMUsuarios();

            ViewABMUsuarios.ShowDialog();
        }

        private void btnAccesoProducto_Click(object sender, EventArgs e)
        {

            ViewABMProductos viewABMProductos = new ViewABMProductos();

            viewABMProductos.ShowDialog();

        }

        private void btnAccesoProductoVendido_Click(object sender, EventArgs e)
        {

           ViewABMProductosVendidos viewABMProductosVendidos = new ViewABMProductosVendidos ();
            viewABMProductosVendidos.ShowDialog();

        }

        private void btnAccesoVenta_Click(object sender, EventArgs e)
        {
            ViewABMVentas viewABMVentas = new ViewABMVentas();
            viewABMVentas.ShowDialog();

        }

     
    }
}
