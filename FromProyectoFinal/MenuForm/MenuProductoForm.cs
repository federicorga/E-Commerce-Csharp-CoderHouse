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
    public partial class MenuProductoForm : Form
    {

       
        public MenuProductoForm()
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

                var producto = GestorProductoData.GetListaProducto();

                ActualizarDgv(producto);
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

            var productoObtenido = GestorProductoData.GetProductoPorId(id);

            List<Producto> producto= new List<Producto> { productoObtenido };

            ActualizarDgv(producto);
        }
    }

}
