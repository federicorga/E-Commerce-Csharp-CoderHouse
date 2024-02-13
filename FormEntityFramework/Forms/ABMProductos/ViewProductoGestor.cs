using Entidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEntityFramework.Forms.ABMProductos
{
    public partial class ViewProductoGestor : Form
    {
        public ViewProductoGestor()
        {
            InitializeComponent();
        }

        public Producto productoCreado { get; private set; }
        public bool ModoEdicion { get; set; } = false;


        public ViewProductoGestor(Producto producto) : this()
        {


            this.txtDescripcion.Text = producto.Descripciones;
            this.txtCosto.Text = producto.Costo.ToString();
            this.txtPrecioVenta.Text = producto.PrecioVenta.ToString();
            this.txtStock.Text = producto.Stock.ToString();
            this.txtIdUsuario.Text = producto.IdUsuario.ToString();

        }

        private void ViewProductoGestor_Load(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {


                if (txtDescripcion.Text != string.Empty && txtCosto.Text != string.Empty && txtPrecioVenta.Text != string.Empty && txtStock.Text != string.Empty && txtIdUsuario.Text != string.Empty)
                {
                    string descripcion = txtDescripcion.Text;
                    decimal costo = Convert.ToDecimal(txtCosto.Text);
                    decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    int stock = Convert.ToInt32(txtStock.Text);
                    int idUsuario = Convert.ToInt32(txtIdUsuario.Text);

                    Producto producto = new Producto() { Descripciones = descripcion, Costo = costo, PrecioVenta = precioVenta, Stock = stock, IdUsuario = idUsuario };


                    this.productoCreado = producto;

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
                if (txtDescripcion.Text != string.Empty && txtCosto.Text != string.Empty && txtPrecioVenta.Text != string.Empty && txtStock.Text != string.Empty && txtIdUsuario.Text != string.Empty)
                {
                    string descripcion = txtDescripcion.Text;
                    decimal costo = Convert.ToDecimal(txtCosto.Text);
                    decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    int stock = Convert.ToInt32(txtStock.Text);
                    int idUsuario = Convert.ToInt32(txtIdUsuario.Text);

                    Producto producto = new Producto() { Descripciones = descripcion, Costo = costo, PrecioVenta = precioVenta, Stock = stock, IdUsuario = idUsuario };


                    this.productoCreado = producto;

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
