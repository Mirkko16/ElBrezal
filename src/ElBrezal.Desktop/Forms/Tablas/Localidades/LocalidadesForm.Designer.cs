namespace ElBrezal.Desktop.Forms.Tablas.Localidades
{
    partial class LocalidadesForm
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
            cmbProvincias = new ComboBox();
            lblZona = new Label();
            textBoxZona = new TextBox();
            textBoxCodPostal = new TextBox();
            lblCodPostal = new Label();
            textBoxLocalidad = new TextBox();
            lblLocalidad = new Label();
            lblProvincia = new Label();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // cmbProvincias
            // 
            cmbProvincias.FormattingEnabled = true;
            cmbProvincias.Location = new Point(126, 223);
            cmbProvincias.Name = "cmbProvincias";
            cmbProvincias.Size = new Size(121, 23);
            cmbProvincias.TabIndex = 0;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(21, 111);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(40, 15);
            lblZona.TabIndex = 1;
            lblZona.Text = "Zona: ";
            // 
            // textBoxZona
            // 
            textBoxZona.Location = new Point(58, 103);
            textBoxZona.Name = "textBoxZona";
            textBoxZona.Size = new Size(100, 23);
            textBoxZona.TabIndex = 2;
            // 
            // textBoxCodPostal
            // 
            textBoxCodPostal.Location = new Point(358, 103);
            textBoxCodPostal.Name = "textBoxCodPostal";
            textBoxCodPostal.Size = new Size(100, 23);
            textBoxCodPostal.TabIndex = 4;
            // 
            // lblCodPostal
            // 
            lblCodPostal.AutoSize = true;
            lblCodPostal.Location = new Point(282, 111);
            lblCodPostal.Name = "lblCodPostal";
            lblCodPostal.Size = new Size(70, 15);
            lblCodPostal.TabIndex = 3;
            lblCodPostal.Text = "Cód. Postal:";
            // 
            // textBoxLocalidad
            // 
            textBoxLocalidad.Location = new Point(85, 154);
            textBoxLocalidad.Name = "textBoxLocalidad";
            textBoxLocalidad.Size = new Size(100, 23);
            textBoxLocalidad.TabIndex = 6;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(21, 162);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(61, 15);
            lblLocalidad.TabIndex = 5;
            lblLocalidad.Text = "Localidad:";
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(21, 231);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(56, 15);
            lblProvincia.TabIndex = 7;
            lblProvincia.Text = "Provincia";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(337, 252);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(418, 252);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(499, 252);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(580, 252);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // LocalidadesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 321);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblProvincia);
            Controls.Add(textBoxLocalidad);
            Controls.Add(lblLocalidad);
            Controls.Add(textBoxCodPostal);
            Controls.Add(lblCodPostal);
            Controls.Add(textBoxZona);
            Controls.Add(lblZona);
            Controls.Add(cmbProvincias);
            Name = "LocalidadesForm";
            Text = "LocalidadesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProvincias;
        private Label lblZona;
        private TextBox textBoxZona;
        private TextBox textBoxCodPostal;
        private Label lblCodPostal;
        private TextBox textBoxLocalidad;
        private Label lblLocalidad;
        private Label lblProvincia;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
    }
}