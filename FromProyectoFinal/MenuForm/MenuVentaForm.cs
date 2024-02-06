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
    public partial class MenuVentaForm : Form
    {
        public MenuVentaForm()
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

                var ventas = GestorVentaData.GetListaVenta();

                ActualizarDgv(ventas);
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

            var ventaobtenida = GestorVentaData.GetVentaPorId(id);

            List<Venta> venta = new List<Venta> { ventaobtenida };

            ActualizarDgv(venta);
        }
    }
}
