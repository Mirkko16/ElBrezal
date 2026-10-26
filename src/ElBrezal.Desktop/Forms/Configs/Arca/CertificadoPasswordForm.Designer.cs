namespace ElBrezal.Desktop.Forms.Configs.Arca
{
    partial class CertificadoPasswordForm
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
            lblPassword = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            textBoxPassword = new TextBox();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 49);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(131, 15);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Contraseña Certificado:";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(66, 124);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(216, 124);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(149, 41);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(192, 23);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // CertificadoPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 223);
            Controls.Add(textBoxPassword);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblPassword);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CertificadoPasswordForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CertificadoPasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox textBoxPassword;
    }
}