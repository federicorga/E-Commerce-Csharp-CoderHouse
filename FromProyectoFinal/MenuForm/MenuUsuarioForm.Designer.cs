namespace FromProyectoFinal
{
    partial class btnEdit
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
            btnVolver = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            txtId = new TextBox();
            btnBuscarId = new Button();
            btnCargarDatos = new Button();
            dgLista = new DataGridView();
            btnEditar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgLista).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(143, 409);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 22;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(26, 324);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(26, 195);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 19;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 130);
            txtId.Name = "txtId";
            txtId.Size = new Size(97, 27);
            txtId.TabIndex = 18;
            // 
            // btnBuscarId
            // 
            btnBuscarId.Location = new Point(26, 121);
            btnBuscarId.Name = "btnBuscarId";
            btnBuscarId.Size = new Size(108, 45);
            btnBuscarId.TabIndex = 17;
            btnBuscarId.Text = "Buscar por ID";
            btnBuscarId.UseVisualStyleBackColor = true;
            btnBuscarId.Click += btnBuscarId_Click;
            // 
            // btnCargarDatos
            // 
            btnCargarDatos.Location = new Point(26, 56);
            btnCargarDatos.Name = "btnCargarDatos";
            btnCargarDatos.Size = new Size(94, 29);
            btnCargarDatos.TabIndex = 16;
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
            dgLista.TabIndex = 15;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(26, 246);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 23;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEditar);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(txtId);
            Controls.Add(btnBuscarId);
            Controls.Add(btnCargarDatos);
            Controls.Add(dgLista);
            Name = "btnEdit";
            Text = "Menu Usuario";
            ((System.ComponentModel.ISupportInitialize)dgLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Button btnEliminar;
        private Button btnAgregar;
        private TextBox txtId;
        private Button btnBuscarId;
        private Button btnCargarDatos;
        private DataGridView dgLista;
        private Button btnEditar;
    }
}
