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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalidadesForm));
            cmbProvincias = new ComboBox();
            lblZona = new Label();
            textBoxZona = new TextBox();
            textBoxCodigoPostal = new TextBox();
            lblCodPostal = new Label();
            textBoxLocalidad = new TextBox();
            lblLocalidad = new Label();
            lblProvincia = new Label();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            bindingSourceLocalidades = new BindingSource(components);
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            btnUltimo = new Button();
            lblPosicion = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidades).BeginInit();
            SuspendLayout();
            // 
            // cmbProvincias
            // 
            cmbProvincias.FormattingEnabled = true;
            cmbProvincias.Location = new Point(121, 159);
            cmbProvincias.Margin = new Padding(3, 4, 3, 4);
            cmbProvincias.Name = "cmbProvincias";
            cmbProvincias.Size = new Size(195, 28);
            cmbProvincias.TabIndex = 0;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(38, 74);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(50, 20);
            lblZona.TabIndex = 1;
            lblZona.Text = "Zona: ";
            // 
            // textBoxZona
            // 
            textBoxZona.Location = new Point(121, 71);
            textBoxZona.Margin = new Padding(3, 4, 3, 4);
            textBoxZona.Name = "textBoxZona";
            textBoxZona.ReadOnly = true;
            textBoxZona.Size = new Size(114, 27);
            textBoxZona.TabIndex = 2;
            // 
            // textBoxCodigoPostal
            // 
            textBoxCodigoPostal.Location = new Point(487, 70);
            textBoxCodigoPostal.Margin = new Padding(3, 4, 3, 4);
            textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            textBoxCodigoPostal.Size = new Size(114, 27);
            textBoxCodigoPostal.TabIndex = 4;
            // 
            // lblCodPostal
            // 
            lblCodPostal.AutoSize = true;
            lblCodPostal.Location = new Point(381, 74);
            lblCodPostal.Name = "lblCodPostal";
            lblCodPostal.Size = new Size(85, 20);
            lblCodPostal.TabIndex = 3;
            lblCodPostal.Text = "Cód. Postal:";
            // 
            // textBoxLocalidad
            // 
            textBoxLocalidad.CharacterCasing = CharacterCasing.Upper;
            textBoxLocalidad.Location = new Point(121, 114);
            textBoxLocalidad.Margin = new Padding(3, 4, 3, 4);
            textBoxLocalidad.Name = "textBoxLocalidad";
            textBoxLocalidad.Size = new Size(195, 27);
            textBoxLocalidad.TabIndex = 6;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(38, 117);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(77, 20);
            lblLocalidad.TabIndex = 5;
            lblLocalidad.Text = "Localidad:";
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(38, 167);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(69, 20);
            lblProvincia.TabIndex = 7;
            lblProvincia.Text = "Provincia";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(407, 237);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(86, 31);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(500, 237);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(86, 31);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(592, 237);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(685, 237);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 31);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // bindingSourceLocalidades
            // 
            bindingSourceLocalidades.PositionChanged += bindingSourceLocalidades_PositionChanged;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackgroundImage = (Image)resources.GetObject("btnSiguiente.BackgroundImage");
            btnSiguiente.BackgroundImageLayout = ImageLayout.Center;
            btnSiguiente.Location = new Point(254, 237);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(36, 31);
            btnSiguiente.TabIndex = 15;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackgroundImage = (Image)resources.GetObject("btnAnterior.BackgroundImage");
            btnAnterior.BackgroundImageLayout = ImageLayout.Center;
            btnAnterior.Location = new Point(71, 237);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(36, 31);
            btnAnterior.TabIndex = 16;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.BackgroundImage = (Image)resources.GetObject("btnPrimero.BackgroundImage");
            btnPrimero.BackgroundImageLayout = ImageLayout.Center;
            btnPrimero.Location = new Point(23, 237);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(36, 31);
            btnPrimero.TabIndex = 17;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnUltimo
            // 
            btnUltimo.BackgroundImage = (Image)resources.GetObject("btnUltimo.BackgroundImage");
            btnUltimo.BackgroundImageLayout = ImageLayout.Center;
            btnUltimo.Location = new Point(296, 237);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(36, 31);
            btnUltimo.TabIndex = 18;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Location = new Point(150, 244);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(15, 20);
            lblPosicion.TabIndex = 19;
            lblPosicion.Text = "-";
            // 
            // LocalidadesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 296);
            Controls.Add(lblPosicion);
            Controls.Add(btnUltimo);
            Controls.Add(btnPrimero);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblProvincia);
            Controls.Add(textBoxLocalidad);
            Controls.Add(lblLocalidad);
            Controls.Add(textBoxCodigoPostal);
            Controls.Add(lblCodPostal);
            Controls.Add(textBoxZona);
            Controls.Add(lblZona);
            Controls.Add(cmbProvincias);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "LocalidadesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LocalidadesForm";
            Load += LocalidadesForm_Load;
            KeyDown += LocalidadesForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProvincias;
        private Label lblZona;
        private TextBox textBoxZona;
        private TextBox textBoxCodigoPostal;
        private Label lblCodPostal;
        private TextBox textBoxLocalidad;
        private Label lblLocalidad;
        private Label lblProvincia;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
        private BindingSource bindingSourceLocalidades;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Button btnUltimo;
        private Label lblPosicion;
    }
}