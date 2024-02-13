namespace FormEntityFramework.Forms.ABMProductosVendidos
{
    partial class ViewProductoVendidoGestor
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
            txtIdProducto = new TextBox();
            btnCancelar = new Button();
            txtStock = new TextBox();
            btnAgregar = new Button();
            label2 = new Label();
            btnModificar = new Button();
            label1 = new Label();
            label4 = new Label();
            txtIdVenta = new TextBox();
            SuspendLayout();
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(62, 178);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.Size = new Size(199, 27);
            txtIdProducto.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(249, 389);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(62, 116);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(199, 27);
            txtStock.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(17, 389);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 155);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 43;
            label2.Text = "Id Producto";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(133, 389);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 93);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 41;
            label1.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 220);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 48;
            label4.Text = "Id Venta";
            // 
            // txtIdVenta
            // 
            txtIdVenta.Location = new Point(62, 243);
            txtIdVenta.Name = "txtIdVenta";
            txtIdVenta.Size = new Size(199, 27);
            txtIdVenta.TabIndex = 3;
            // 
            // ViewProductoVendidoGestor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 451);
            Controls.Add(txtIdVenta);
            Controls.Add(label4);
            Controls.Add(txtIdProducto);
            Controls.Add(btnCancelar);
            Controls.Add(txtStock);
            Controls.Add(btnAgregar);
            Controls.Add(label2);
            Controls.Add(btnModificar);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ViewProductoVendidoGestor";
            Text = "Gestor Producto Vendido";
            Load += ViewProductoVendidoGestor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdProducto;
        private Button btnCancelar;
        private TextBox txtStock;
        private Button btnAgregar;
        private Label label2;
        private Button btnModificar;
        private Label label1;
        private Label label4;
        private TextBox txtIdVenta;
    }
}