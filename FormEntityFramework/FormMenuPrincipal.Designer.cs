namespace FormEntityFramework
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAccesoUsuario = new Button();
            label1 = new Label();
            btnAccesoProducto = new Button();
            btnAccesoProductoVendido = new Button();
            btnAccesoVenta = new Button();
            SuspendLayout();
            // 
            // btnAccesoUsuario
            // 
            btnAccesoUsuario.Location = new Point(118, 218);
            btnAccesoUsuario.Name = "btnAccesoUsuario";
            btnAccesoUsuario.Size = new Size(94, 53);
            btnAccesoUsuario.TabIndex = 0;
            btnAccesoUsuario.Text = "Usuarios";
            btnAccesoUsuario.UseVisualStyleBackColor = true;
            btnAccesoUsuario.Click += btnAccesoUsuario_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(312, 113);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 1;
            label1.Text = "MENU PRINCIPAL";
            // 
            // btnAccesoProducto
            // 
            btnAccesoProducto.Location = new Point(261, 218);
            btnAccesoProducto.Name = "btnAccesoProducto";
            btnAccesoProducto.Size = new Size(94, 53);
            btnAccesoProducto.TabIndex = 2;
            btnAccesoProducto.Text = "Productos";
            btnAccesoProducto.UseVisualStyleBackColor = true;
            btnAccesoProducto.Click += btnAccesoProducto_Click;
            // 
            // btnAccesoProductoVendido
            // 
            btnAccesoProductoVendido.Location = new Point(399, 218);
            btnAccesoProductoVendido.Name = "btnAccesoProductoVendido";
            btnAccesoProductoVendido.Size = new Size(94, 53);
            btnAccesoProductoVendido.TabIndex = 3;
            btnAccesoProductoVendido.Text = "Productos Vendidos";
            btnAccesoProductoVendido.UseVisualStyleBackColor = true;
            btnAccesoProductoVendido.Click += btnAccesoProductoVendido_Click;
            // 
            // btnAccesoVenta
            // 
            btnAccesoVenta.Location = new Point(534, 218);
            btnAccesoVenta.Name = "btnAccesoVenta";
            btnAccesoVenta.Size = new Size(94, 53);
            btnAccesoVenta.TabIndex = 4;
            btnAccesoVenta.Text = "Ventas";
            btnAccesoVenta.UseVisualStyleBackColor = true;
            btnAccesoVenta.Click += btnAccesoVenta_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAccesoVenta);
            Controls.Add(btnAccesoProductoVendido);
            Controls.Add(btnAccesoProducto);
            Controls.Add(label1);
            Controls.Add(btnAccesoUsuario);
            Name = "FormMenuPrincipal";
            Text = "Menu Principal";
            Load += FormMenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccesoUsuario;
        private Label label1;
        private Button btnAccesoProducto;
        private Button btnAccesoProductoVendido;
        private Button btnAccesoVenta;
    }
}
