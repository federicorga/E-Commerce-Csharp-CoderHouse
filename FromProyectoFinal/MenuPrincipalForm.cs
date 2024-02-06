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
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();
        }

        private void btnMUsuario_Click(object sender, EventArgs e)
        {
            MenuUsuarioForm menuUsuarioForm = new MenuUsuarioForm();

            menuUsuarioForm.Show();
        }

        private void btnMProducto_Click(object sender, EventArgs e)
        {
            MenuProductoForm menuProductoForm = new MenuProductoForm();
            menuProductoForm.Show();
        }

        private void btnMProductoVendido_Click(object sender, EventArgs e)
        {
            MenuProductoVendidoForm menuProductoVendidoForm = new MenuProductoVendidoForm();
            menuProductoVendidoForm.Show();
        }

        private void btnMVenta_Click(object sender, EventArgs e)
        {
            MenuVentaForm menuVentaForm = new MenuVentaForm();

            menuVentaForm.Show();
        }
    }
}
