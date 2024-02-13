namespace FormEntityFramework.Forms.ABMProductosVendidos
{
    partial class ViewABMProductosVendidos
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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            txtId = new TextBox();
            btnBuscarId = new Button();
            btnList = new Button();
            dgvDatos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(16, 311);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(111, 50);
            btnAgregar.TabIndex = 27;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(16, 388);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(111, 50);
            btnModificar.TabIndex = 26;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(16, 233);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(111, 50);
            btnEliminar.TabIndex = 25;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(152, 158);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 24;
            // 
            // btnBuscarId
            // 
            btnBuscarId.Location = new Point(16, 133);
            btnBuscarId.Name = "btnBuscarId";
            btnBuscarId.Size = new Size(111, 77);
            btnBuscarId.TabIndex = 23;
            btnBuscarId.Text = "Buscar por ID";
            btnBuscarId.UseVisualStyleBackColor = true;
            btnBuscarId.Click += btnBuscarId_Click;
            // 
            // btnList
            // 
            btnList.Location = new Point(16, 24);
            btnList.Name = "btnList";
            btnList.Size = new Size(111, 60);
            btnList.TabIndex = 22;
            btnList.Text = "Cargar Lista";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(304, 12);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 29;
            dgvDatos.Size = new Size(592, 426);
            dgvDatos.TabIndex = 21;
            dgvDatos.SelectionChanged += dgvDatos_SelectionChanged;
            // 
            // ViewABMProductosVendidos
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
            Name = "ViewABMProductosVendidos";
            Text = "ViewABMProductosVendidos";
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private TextBox txtId;
        private Button btnBuscarId;
        private Button btnList;
        private DataGridView dgvDatos;
    }
}