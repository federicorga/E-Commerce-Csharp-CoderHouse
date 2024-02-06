namespace FromProyectoFinal
{
    partial class MenuVentaForm
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
            btnEliminar = new Button();
            c = new Button();
            btnAgregar = new Button();
            txtId = new TextBox();
            btnBuscarId = new Button();
            btnCargarDatos = new Button();
            dgLista = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgLista).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(26, 324);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // c
            // 
            c.Location = new Point(26, 262);
            c.Name = "c";
            c.Size = new Size(94, 29);
            c.TabIndex = 12;
            c.Text = "Editar";
            c.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(26, 195);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 130);
            txtId.Name = "txtId";
            txtId.Size = new Size(97, 27);
            txtId.TabIndex = 10;
            // 
            // btnBuscarId
            // 
            btnBuscarId.Location = new Point(26, 121);
            btnBuscarId.Name = "btnBuscarId";
            btnBuscarId.Size = new Size(108, 45);
            btnBuscarId.TabIndex = 9;
            btnBuscarId.Text = "Buscar por ID";
            btnBuscarId.UseVisualStyleBackColor = true;
            btnBuscarId.Click += btnBuscarId_Click;
            // 
            // btnCargarDatos
            // 
            btnCargarDatos.Location = new Point(26, 56);
            btnCargarDatos.Name = "btnCargarDatos";
            btnCargarDatos.Size = new Size(94, 29);
            btnCargarDatos.TabIndex = 8;
            btnCargarDatos.Text = "Cargar";
            btnCargarDatos.UseVisualStyleBackColor = true;
            btnCargarDatos.Click += btnCargarDatos_Click;
            // 
            // dgLista
            // 
            dgLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgLista.Location = new Point(258, 12);
            dgLista.Name = "dgLista";
            dgLista.RowHeadersWidth = 51;
            dgLista.RowTemplate.Height = 29;
            dgLista.Size = new Size(516, 426);
            dgLista.TabIndex = 7;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(143, 409);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 14;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // MenuVentaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(c);
            Controls.Add(btnAgregar);
            Controls.Add(txtId);
            Controls.Add(btnBuscarId);
            Controls.Add(btnCargarDatos);
            Controls.Add(dgLista);
            Name = "MenuVentaForm";
            Text = "Menu Ventas";
            ((System.ComponentModel.ISupportInitialize)dgLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button c;
        private Button btnAgregar;
        private TextBox txtId;
        private Button btnBuscarId;
        private Button btnCargarDatos;
        private DataGridView dgLista;
        private Button btnVolver;
    }
}