using Entidades.Models;
using Entidades.Service;
using FormEntityFramework.Forms.ABMProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEntityFramework.Forms.ABMVentas
{
    public partial class ViewABMVentas : Form
    {
        public ViewABMVentas()
        {
            InitializeComponent();
        }


        public Venta ventaSeleccionada { get; private set; }


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

            var venta = VentaService.ObtenerListaDeVentas();

            ActualizarDGV(venta);

        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {



            try
            {
                string stringId = this.txtId.Text;

                if (stringId != string.Empty)
                {
                    int id = Convert.ToInt32(stringId);


                    var ventaBuscada = VentaService.ObtenerVentaPorID(id);

                    if (ventaBuscada != null)
                    {
                        List<Venta> venta = new List<Venta>() { ventaBuscada };

                        this.ActualizarDGV(venta);
                    }
                    else
                    {
                        MessageBox.Show($"Venta con id: {id} inexistente", "Venta no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (VentaService.EliminarVenta(id))
                    {
                        var venta = VentaService.ObtenerListaDeVentas();

                        ActualizarDGV(venta);
                        MessageBox.Show("Venta Eliminado");
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo eliminar la Venta con id: {id}", "Venta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ViewVentaGestor ViewVentaGestor = new ViewVentaGestor();

                ViewVentaGestor.ShowDialog();

                Venta venta = ViewVentaGestor.ventaCreada;

                if (VentaService.AgregarVenta(venta))
                {
                    var listaventa = VentaService.ObtenerListaDeVentas();

                    ActualizarDGV(listaventa);
                    MessageBox.Show("Se agrego un nueva Venta!");
                }
                else
                {
                    MessageBox.Show("la venta no fue creado");
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
                Venta venta = this.ventaSeleccionada;

                if (this.ventaSeleccionada is not null)
                {
                    ViewVentaGestor viewVentaGestor = new ViewVentaGestor(venta);

                    viewVentaGestor.ModoEdicion = true;
                    viewVentaGestor.ShowDialog();

                    Venta ventaModificada = viewVentaGestor.ventaCreada;
                    if (VentaService.ActualizarVentaPorId(ventaModificada, this.ventaSeleccionada.Id))
                    {
                        var listaventa = VentaService.ObtenerListaDeVentas();

                        ActualizarDGV(listaventa);
                        MessageBox.Show("La venta se modifico correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.ventaSeleccionada = dato as Venta;
            }
        }

       
    }
}
