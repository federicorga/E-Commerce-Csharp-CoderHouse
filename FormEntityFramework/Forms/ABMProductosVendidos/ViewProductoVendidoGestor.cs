using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Models;

namespace FormEntityFramework.Forms.ABMProductosVendidos
{
    public partial class ViewProductoVendidoGestor : Form
    {
        public ViewProductoVendidoGestor()
        {
            InitializeComponent();
        }
        private void ViewProductoVendidoGestor_Load(object sender, EventArgs e)
        {

            if (ModoEdicion)
            {
                this.btnAgregar.Enabled = false;

            }
            else
            {

                this.btnModificar.Enabled = false;
            }
        }

        public ProductoVendido productoVendidoCreado { get; private set; }
        public bool ModoEdicion { get; set; } = false;


        public ViewProductoVendidoGestor(ProductoVendido productoVendido) : this()
        {


            this.txtStock.Text = Convert.ToString(productoVendido.Stock);
            this.txtIdProducto.Text = Convert.ToString(productoVendido.IdProducto);
            this.txtIdVenta.Text = Convert.ToString(productoVendido.IdVenta);

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {


                if (txtStock.Text != string.Empty && txtIdProducto.Text != string.Empty && txtIdVenta.Text != string.Empty)
                {
                    int stock = Convert.ToInt32(txtStock.Text);
                    int idProducto = Convert.ToInt32(txtIdProducto.Text);
                    int idVenta = Convert.ToInt32(txtIdVenta.Text);

                    ProductoVendido productoVendido = new ProductoVendido() { Stock = stock, IdProducto = idProducto, IdVenta = idVenta };


                    this.productoVendidoCreado = productoVendido;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falta completar campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void btnModificar_Click(object sender, EventArgs e)
        {


            try
            {

                if (txtStock.Text != string.Empty && txtIdProducto.Text != string.Empty && txtIdVenta.Text != string.Empty)
                {
                    int stock = Convert.ToInt32(txtStock.Text);
                    int idProducto = Convert.ToInt32(txtIdProducto.Text);
                    int idVenta = Convert.ToInt32(txtIdVenta.Text);

                    ProductoVendido productoVendido = new ProductoVendido() { Stock = stock, IdProducto = idProducto, IdVenta = idVenta };


                    this.productoVendidoCreado = productoVendido;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falta completar campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
