using Entidades.Models;
using Entidades.Service;
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
    public partial class ViewABMProductos : Form
    {

        public ViewABMProductos()
        {
            InitializeComponent();
        }

        public Producto ProductoSeleccionado { get; private set; }

        private void ViewABMProductos_Load(object sender, EventArgs e)
        {

        }

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

            var productos = ProductoService.ObtenerListaDeProductos();

            ActualizarDGV(productos);

        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {



            try
            {
                string stringId = this.txtId.Text;

                if (stringId != string.Empty)
                {
                    int id = Convert.ToInt32(stringId);


                    var productoBuscado = ProductoService.ObtenerProductoPorID(id);

                    if (productoBuscado != null)
                    {
                        List<Producto> producto = new List<Producto>() { productoBuscado };

                        this.ActualizarDGV(producto);
                    }
                    else
                    {
                        MessageBox.Show($"Producto con id: {id} inexistente", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (ProductoService.EliminarProducto(id))
                    {
                        var productos = ProductoService.ObtenerListaDeProductos();

                        ActualizarDGV(productos);
                        MessageBox.Show("Producto Eliminado");
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo eliminar el Producto con id: {id}", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ViewProductoGestor ViewProductoGestor = new ViewProductoGestor();

                ViewProductoGestor.ShowDialog();

                Producto producto = ViewProductoGestor.productoCreado;

                if (ProductoService.AgregarProducto(producto))
                {
                    var productos = ProductoService.ObtenerListaDeProductos();

                    ActualizarDGV(productos);
                    MessageBox.Show("Se agrego un nuevo Producto!");
                }
                else
                {
                    MessageBox.Show("el Producto no fue creado");
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
                Producto producto = this.ProductoSeleccionado;

                if (this.ProductoSeleccionado is not null)
                {

                    ViewProductoGestor viewProductoEditor = new ViewProductoGestor(producto);
                    viewProductoEditor.ModoEdicion = true;
                    viewProductoEditor.ShowDialog();

                    Producto productoModificado = viewProductoEditor.productoCreado;
                    if (ProductoService.ActualizarProductoPorId(productoModificado, this.ProductoSeleccionado.Id))
                    {
                        var listproductos = ProductoService.ObtenerListaDeProductos();

                        ActualizarDGV(listproductos);

                        MessageBox.Show("El producto se modifico correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.ProductoSeleccionado = dato as Producto;
            }
        }

     

   
    }
}
