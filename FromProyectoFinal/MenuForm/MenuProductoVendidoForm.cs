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
    public partial class MenuProductoVendidoForm : Form
    {
        public MenuProductoVendidoForm()
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

                var productosVendidos = GestorProductoVendidosData.GetListaProductoVendido();

                ActualizarDgv(productosVendidos);
                MessageBox.Show($"Lista cargada correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {
            string idstring = this.txtId.Text;

            int id = int.Parse(idstring);

            var productoVendidoObtenido = GestorProductoVendidosData.GetProductoVendidoPorId(id);

            List<ProductoVendido> productoVendido = new List<ProductoVendido> { productoVendidoObtenido };

            ActualizarDgv(productoVendido);
        }
    }
}
