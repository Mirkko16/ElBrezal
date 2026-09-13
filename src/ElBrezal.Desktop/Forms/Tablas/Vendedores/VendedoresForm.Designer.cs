namespace ElBrezal.Desktop.Forms.Tablas.Vendedores
{
    partial class VendedoresForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendedoresForm));
            lblPosicion = new Label();
            btnUltimo = new Button();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnSalir = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            lblLocalidad = new Label();
            textBoxDireccionVendedor = new TextBox();
            lblDireccionVendedor = new Label();
            textBoxNombreVendedor = new TextBox();
            lblNombreVendedor = new Label();
            textBoxIdVendedor = new TextBox();
            lblIdVendedor = new Label();
            cmbLocalidadesVendedor = new ComboBox();
            textBoxTelVendedor = new TextBox();
            lblTelefonoVendedor = new Label();
            textBoxEmailVendedor = new TextBox();
            lblEmailVendedor = new Label();
            bindingSourceLocalidadesVendedor = new BindingSource(components);
            bindingSourceVendedores = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidadesVendedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceVendedores).BeginInit();
            SuspendLayout();
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Location = new Point(100, 246);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(15, 20);
            lblPosicion.TabIndex = 36;
            lblPosicion.Text = "-";
            // 
            // btnUltimo
            // 
            btnUltimo.BackgroundImage = (Image)resources.GetObject("btnUltimo.BackgroundImage");
            btnUltimo.BackgroundImageLayout = ImageLayout.Center;
            btnUltimo.Location = new Point(207, 241);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(29, 31);
            btnUltimo.TabIndex = 35;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.BackgroundImage = (Image)resources.GetObject("btnPrimero.BackgroundImage");
            btnPrimero.BackgroundImageLayout = ImageLayout.Center;
            btnPrimero.Location = new Point(12, 241);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(31, 31);
            btnPrimero.TabIndex = 34;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackgroundImage = (Image)resources.GetObject("btnAnterior.BackgroundImage");
            btnAnterior.BackgroundImageLayout = ImageLayout.Center;
            btnAnterior.Location = new Point(49, 241);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(33, 31);
            btnAnterior.TabIndex = 33;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackgroundImage = (Image)resources.GetObject("btnSiguiente.BackgroundImage");
            btnSiguiente.BackgroundImageLayout = ImageLayout.Center;
            btnSiguiente.Location = new Point(156, 241);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(32, 31);
            btnSiguiente.TabIndex = 32;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(719, 234);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 31);
            btnSalir.TabIndex = 31;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(626, 234);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 30;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(534, 234);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(86, 31);
            btnModificar.TabIndex = 29;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(441, 234);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(86, 31);
            btnNuevo.TabIndex = 28;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(72, 164);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(74, 20);
            lblLocalidad.TabIndex = 27;
            lblLocalidad.Text = "Localidad";
            // 
            // textBoxDireccionVendedor
            // 
            textBoxDireccionVendedor.CharacterCasing = CharacterCasing.Upper;
            textBoxDireccionVendedor.Location = new Point(155, 111);
            textBoxDireccionVendedor.Margin = new Padding(3, 4, 3, 4);
            textBoxDireccionVendedor.Name = "textBoxDireccionVendedor";
            textBoxDireccionVendedor.Size = new Size(229, 27);
            textBoxDireccionVendedor.TabIndex = 26;
            // 
            // lblDireccionVendedor
            // 
            lblDireccionVendedor.AutoSize = true;
            lblDireccionVendedor.Location = new Point(72, 114);
            lblDireccionVendedor.Name = "lblDireccionVendedor";
            lblDireccionVendedor.Size = new Size(75, 20);
            lblDireccionVendedor.TabIndex = 25;
            lblDireccionVendedor.Text = "Direccion:";
            // 
            // textBoxNombreVendedor
            // 
            textBoxNombreVendedor.CharacterCasing = CharacterCasing.Upper;
            textBoxNombreVendedor.Location = new Point(555, 64);
            textBoxNombreVendedor.Margin = new Padding(3, 4, 3, 4);
            textBoxNombreVendedor.Name = "textBoxNombreVendedor";
            textBoxNombreVendedor.Size = new Size(248, 27);
            textBoxNombreVendedor.TabIndex = 24;
            // 
            // lblNombreVendedor
            // 
            lblNombreVendedor.AutoSize = true;
            lblNombreVendedor.Location = new Point(472, 71);
            lblNombreVendedor.Name = "lblNombreVendedor";
            lblNombreVendedor.Size = new Size(67, 20);
            lblNombreVendedor.TabIndex = 23;
            lblNombreVendedor.Text = "Nombre:";
            // 
            // textBoxIdVendedor
            // 
            textBoxIdVendedor.Location = new Point(155, 68);
            textBoxIdVendedor.Margin = new Padding(3, 4, 3, 4);
            textBoxIdVendedor.Name = "textBoxIdVendedor";
            textBoxIdVendedor.ReadOnly = true;
            textBoxIdVendedor.Size = new Size(114, 27);
            textBoxIdVendedor.TabIndex = 22;
            // 
            // lblIdVendedor
            // 
            lblIdVendedor.AutoSize = true;
            lblIdVendedor.Location = new Point(72, 71);
            lblIdVendedor.Name = "lblIdVendedor";
            lblIdVendedor.Size = new Size(29, 20);
            lblIdVendedor.TabIndex = 21;
            lblIdVendedor.Text = "Id: ";
            // 
            // cmbLocalidadesVendedor
            // 
            cmbLocalidadesVendedor.FormattingEnabled = true;
            cmbLocalidadesVendedor.Location = new Point(155, 156);
            cmbLocalidadesVendedor.Margin = new Padding(3, 4, 3, 4);
            cmbLocalidadesVendedor.Name = "cmbLocalidadesVendedor";
            cmbLocalidadesVendedor.Size = new Size(229, 28);
            cmbLocalidadesVendedor.TabIndex = 20;
            // 
            // textBoxTelVendedor
            // 
            textBoxTelVendedor.CharacterCasing = CharacterCasing.Upper;
            textBoxTelVendedor.Location = new Point(555, 111);
            textBoxTelVendedor.Margin = new Padding(3, 4, 3, 4);
            textBoxTelVendedor.Name = "textBoxTelVendedor";
            textBoxTelVendedor.Size = new Size(248, 27);
            textBoxTelVendedor.TabIndex = 38;
            // 
            // lblTelefonoVendedor
            // 
            lblTelefonoVendedor.AutoSize = true;
            lblTelefonoVendedor.Location = new Point(472, 114);
            lblTelefonoVendedor.Name = "lblTelefonoVendedor";
            lblTelefonoVendedor.Size = new Size(70, 20);
            lblTelefonoVendedor.TabIndex = 37;
            lblTelefonoVendedor.Text = "Teléfono:";
            // 
            // textBoxEmailVendedor
            // 
            textBoxEmailVendedor.Location = new Point(555, 161);
            textBoxEmailVendedor.Margin = new Padding(3, 4, 3, 4);
            textBoxEmailVendedor.Name = "textBoxEmailVendedor";
            textBoxEmailVendedor.Size = new Size(248, 27);
            textBoxEmailVendedor.TabIndex = 40;
            // 
            // lblEmailVendedor
            // 
            lblEmailVendedor.AutoSize = true;
            lblEmailVendedor.Location = new Point(472, 164);
            lblEmailVendedor.Name = "lblEmailVendedor";
            lblEmailVendedor.Size = new Size(49, 20);
            lblEmailVendedor.TabIndex = 39;
            lblEmailVendedor.Text = "Email:";
            // 
            // bindingSourceVendedores
            // 
            bindingSourceVendedores.PositionChanged += bindingSourceVendedores_PositionChanged;
            // 
            // VendedoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 282);
            Controls.Add(textBoxEmailVendedor);
            Controls.Add(lblEmailVendedor);
            Controls.Add(textBoxTelVendedor);
            Controls.Add(lblTelefonoVendedor);
            Controls.Add(lblPosicion);
            Controls.Add(btnUltimo);
            Controls.Add(btnPrimero);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblLocalidad);
            Controls.Add(textBoxDireccionVendedor);
            Controls.Add(lblDireccionVendedor);
            Controls.Add(textBoxNombreVendedor);
            Controls.Add(lblNombreVendedor);
            Controls.Add(textBoxIdVendedor);
            Controls.Add(lblIdVendedor);
            Controls.Add(cmbLocalidadesVendedor);
            KeyPreview = true;
            Name = "VendedoresForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VendedoresForm";
            Load += VendedoresForm_Load;
            KeyDown += VendedoresForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidadesVendedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceVendedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPosicion;
        private Button btnUltimo;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnSalir;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private Label lblLocalidad;
        private TextBox textBoxDireccionVendedor;
        private Label lblDireccionVendedor;
        private TextBox textBoxNombreVendedor;
        private Label lblNombreVendedor;
        private TextBox textBoxIdVendedor;
        private Label lblIdVendedor;
        private ComboBox cmbLocalidadesVendedor;
        private TextBox textBoxTelVendedor;
        private Label lblTelefonoVendedor;
        private TextBox textBoxEmailVendedor;
        private Label lblEmailVendedor;
        private BindingSource bindingSourceLocalidadesVendedor;
        private BindingSource bindingSourceVendedores;
    }
}