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
            SuspendLayout();
            // 
            // btnAccesoUsuario
            // 
            btnAccesoUsuario.Location = new Point(75, 215);
            btnAccesoUsuario.Name = "btnAccesoUsuario";
            btnAccesoUsuario.Size = new Size(94, 29);
            btnAccesoUsuario.TabIndex = 0;
            btnAccesoUsuario.Text = "Usuario";
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
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnAccesoUsuario);
            Name = "FormMenuPrincipal";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccesoUsuario;
        private Label label1;
    }
}
