namespace FormEntityFramework.Forms.ABMProductos
{
    partial class ViewProductoGestor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtIdUsuario = new TextBox();
            label5 = new Label();
            txtStock = new TextBox();
            txtPrecioVenta = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtCosto = new TextBox();
            btnCancelar = new Button();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            label2 = new Label();
            btnModificar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new Point(45, 309);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.Size = new Size(199, 27);
            txtIdUsuario.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 286);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 39;
            label5.Text = "ID Usuario";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(45, 248);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(199, 27);
            txtStock.TabIndex = 4;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(45, 186);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(199, 27);
            txtPrecioVenta.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 225);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 36;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 163);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 35;
            label4.Text = "Precio de Venta";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(45, 121);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(199, 27);
            txtCosto.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(249, 392);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(45, 59);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(199, 27);
            txtDescripcion.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(17, 392);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 98);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 30;
            label2.Text = "Costo";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(133, 392);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 36);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 28;
            label1.Text = "Descripcion";
            // 
            // ViewProductoGestor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 450);
            Controls.Add(txtIdUsuario);
            Controls.Add(label5);
            Controls.Add(txtStock);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtCosto);
            Controls.Add(btnCancelar);
            Controls.Add(txtDescripcion);
            Controls.Add(btnAgregar);
            Controls.Add(label2);
            Controls.Add(btnModificar);
            Controls.Add(label1);
            Name = "ViewProductoGestor";
            Text = "Producto Gestor";
            Load += ViewProductoGestor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdUsuario;
        private Label label5;
        private TextBox txtStock;
        private TextBox txtPrecioVenta;
        private Label label3;
        private Label label4;
        private TextBox txtCosto;
        private Button btnCancelar;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Label label2;
        private Button btnModificar;
        private Label label1;
    }
}