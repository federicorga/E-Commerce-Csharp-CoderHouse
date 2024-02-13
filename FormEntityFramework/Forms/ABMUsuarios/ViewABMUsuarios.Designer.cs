namespace FormEntityFramework.Forms
{
    partial class ViewABMUsuarios
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
            dgvDatos = new DataGridView();
            btnList = new Button();
            btnBuscarId = new Button();
            txtId = new TextBox();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(309, 12);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 29;
            dgvDatos.Size = new Size(592, 426);
            dgvDatos.TabIndex = 0;
            dgvDatos.SelectionChanged += dgvDatos_SelectionChanged;
            // 
            // btnList
            // 
            btnList.Location = new Point(21, 24);
            btnList.Name = "btnList";
            btnList.Size = new Size(111, 60);
            btnList.TabIndex = 1;
            btnList.Text = "Cargar Lista";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // btnBuscarId
            // 
            btnBuscarId.Location = new Point(21, 133);
            btnBuscarId.Name = "btnBuscarId";
            btnBuscarId.Size = new Size(111, 77);
            btnBuscarId.TabIndex = 2;
            btnBuscarId.Text = "Buscar por ID";
            btnBuscarId.UseVisualStyleBackColor = true;
            btnBuscarId.Click += btnBuscarId_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(157, 158);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 3;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(21, 233);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(111, 50);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(21, 388);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(111, 50);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(21, 311);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(111, 50);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // ViewABMUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 450);
            Controls.Add(btnAgregar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(txtId);
            Controls.Add(btnBuscarId);
            Controls.Add(btnList);
            Controls.Add(dgvDatos);
            Name = "ViewABMUsuarios";
            Text = "ABM-Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDatos;
        private Button btnList;
        private Button btnBuscarId;
        private TextBox txtId;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
    }
}