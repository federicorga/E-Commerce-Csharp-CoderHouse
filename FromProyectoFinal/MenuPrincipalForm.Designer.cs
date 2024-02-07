namespace FromProyectoFinal
{
    partial class MenuPrincipalForm
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
            btnMUsuario = new Button();
            btnMProducto = new Button();
            btnMProductoVendido = new Button();
            btnMVenta = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnMUsuario
            // 
            btnMUsuario.Location = new Point(46, 180);
            btnMUsuario.Name = "btnMUsuario";
            btnMUsuario.Size = new Size(94, 51);
            btnMUsuario.TabIndex = 0;
            btnMUsuario.Text = "Usuarios";
            btnMUsuario.UseVisualStyleBackColor = true;
            btnMUsuario.Click += btnMUsuario_Click;
            // 
            // btnMProducto
            // 
            btnMProducto.Location = new Point(189, 180);
            btnMProducto.Name = "btnMProducto";
            btnMProducto.Size = new Size(94, 51);
            btnMProducto.TabIndex = 1;
            btnMProducto.Text = "Productos";
            btnMProducto.UseVisualStyleBackColor = true;
            btnMProducto.Click += btnMProducto_Click;
            // 
            // btnMProductoVendido
            // 
            btnMProductoVendido.Location = new Point(317, 180);
            btnMProductoVendido.Name = "btnMProductoVendido";
            btnMProductoVendido.Size = new Size(95, 51);
            btnMProductoVendido.TabIndex = 2;
            btnMProductoVendido.Text = "Productos Vendidos";
            btnMProductoVendido.UseVisualStyleBackColor = true;
            btnMProductoVendido.Click += btnMProductoVendido_Click;
            // 
            // btnMVenta
            // 
            btnMVenta.Location = new Point(465, 180);
            btnMVenta.Name = "btnMVenta";
            btnMVenta.Size = new Size(94, 51);
            btnMVenta.TabIndex = 3;
            btnMVenta.Text = "Ventas";
            btnMVenta.UseVisualStyleBackColor = true;
            btnMVenta.Click += btnMVenta_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 100);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 4;
            label1.Text = "MENU PRINCIPAL";
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 383);
            Controls.Add(label1);
            Controls.Add(btnMVenta);
            Controls.Add(btnMProductoVendido);
            Controls.Add(btnMProducto);
            Controls.Add(btnMUsuario);
            Name = "MenuPrincipalForm";
            Text = "MenuPrincipalForm";
            Load += MenuPrincipalForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMUsuario;
        private Button btnMProducto;
        private Button btnMProductoVendido;
        private Button btnMVenta;
        private Label label1;
    }
}