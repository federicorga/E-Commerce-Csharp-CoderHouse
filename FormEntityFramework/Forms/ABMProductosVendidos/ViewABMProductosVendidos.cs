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
using Entidades.Service;
using FormEntityFramework.Forms.ABMVentas;

namespace FormEntityFramework.Forms.ABMProductosVendidos
{
    public partial class ViewABMProductosVendidos : Form
    {
        public ViewABMProductosVendidos()
        {
            InitializeComponent();
        }

        public ProductoVendido ProductoVendidoSeleccionado { get; private set; }


        private void ActualizarDGV<T>(List<T> list)
        {
            this.dgvDatos.DataSource = null;

            this.dgvDatos.DataSource = list;

        }

        private int ObtenerId()
        {
            string stringId = this.txtId.Text;
            if (!string.IsNullOrEmpty(stringId))
            {
                int id = Convert.ToInt32(stringId);
                return id;
            }

            return -1;

        }

        private void btnList_Click(object sender, EventArgs e)
        {

            var productoVendido = ProductoVendidoService.ObtenerListaDeProductosVendidos();

            ActualizarDGV(productoVendido);

        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {

            try
            {
                string stringId = this.txtId.Text;

                if (stringId != string.Empty)
                {
                    int id = Convert.ToInt32(stringId);


                    var productoVendidoBuscado = ProductoVendidoService.ObtenerProductoVendidoPorID(id);

                    if (productoVendidoBuscado != null)
                    {
                        List<ProductoVendido> productoVendido = new List<ProductoVendido>() { productoVendidoBuscado };

                        this.ActualizarDGV(productoVendido);
                    }
                    else
                    {
                        MessageBox.Show($"Producto Vendido con id: {id} inexistente", "Producto vendido no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Complete el campo Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtId.Focus();
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
                string stringId = this.txtId.Text;

                if (stringId != string.Empty)
                {
                    int id = Convert.ToInt32(stringId);

                    if (ProductoVendidoService.EliminarProductoVendido(id))
                    {
                        var productoVendido = ProductoVendidoService.ObtenerListaDeProductosVendidos();

                        ActualizarDGV(productoVendido);
                        MessageBox.Show("Producto vendido Eliminado");
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo eliminar el producto vendido con id: {id}", "Producto vendido no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No ingreso ningun Id", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

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
                ViewProductoVendidoGestor viewProductoVendidoGestor = new ViewProductoVendidoGestor();

                viewProductoVendidoGestor.ShowDialog();

                ProductoVendido productoVendido = viewProductoVendidoGestor.productoVendidoCreado;    

                if (ProductoVendidoService.AgregarProductoVendido(productoVendido))
                {
                    var listaproductoVendido = ProductoVendidoService.ObtenerListaDeProductosVendidos();

                    ActualizarDGV(listaproductoVendido);
                    MessageBox.Show("Se agrego un nuevo producto vendido!");
                }
                else
                {
                    MessageBox.Show("El producto vendido no fue creado");
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
                ProductoVendido productoVendido = this.ProductoVendidoSeleccionado;

                if (this.ProductoVendidoSeleccionado is not null)
                {
                    ViewProductoVendidoGestor viewProductoVendidoGestor = new ViewProductoVendidoGestor(ProductoVendidoSeleccionado);

                    viewProductoVendidoGestor.ModoEdicion = true;
                    viewProductoVendidoGestor.ShowDialog();

                    ProductoVendido productoVendidoModificado = viewProductoVendidoGestor.productoVendidoCreado;

                    if (ProductoVendidoService.ActualizarProductoVendidoPorId(productoVendidoModificado, this.ProductoVendidoSeleccionado.Id))
                    {
                        var listproductoVendido = ProductoVendidoService.ObtenerListaDeProductosVendidos();

                        ActualizarDGV(listproductoVendido);

                        MessageBox.Show("El producto vendido se modifico correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No selecciono ningun elemento de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }



        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {

            var seleccion = this.dgvDatos.SelectedRows;

            if (seleccion.Count > 0)
            {
                var dato = seleccion[0].DataBoundItem;
                this.ProductoVendidoSeleccionado = dato as ProductoVendido;
            }
        }


    }
}
