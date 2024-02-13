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

namespace FormEntityFramework.Forms.ABMVentas
{
    public partial class ViewVentaGestor : Form
    {
        public ViewVentaGestor()
        {
            InitializeComponent();
        }
        public Venta ventaCreada { get; private set; }
        public bool ModoEdicion { get; set; } = false;


        public ViewVentaGestor(Venta venta) : this()
        {


            this.txtComentario.Text = venta.Comentarios;
            this.txtIdUsuario.Text = Convert.ToString(venta.IdUsuario);

        }

        private void ViewVentaGestor_Load(object sender, EventArgs e)
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


                if (txtComentario.Text != string.Empty && txtIdUsuario.Text != string.Empty)
                {
                    string comentario = this.txtComentario.Text;
           
                    int idUsuario = Convert.ToInt32(txtIdUsuario.Text);

                    Venta venta = new Venta() { Comentarios = comentario, IdUsuario = idUsuario };


                    this.ventaCreada = venta;

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
                if (txtComentario.Text != string.Empty && txtIdUsuario.Text != string.Empty)
                {
                    string comentario = this.txtComentario.Text;

                    int idUsuario = Convert.ToInt32(txtIdUsuario.Text);

                    Venta venta = new Venta() { Comentarios = comentario, IdUsuario = idUsuario };


                    this.ventaCreada = venta;

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
