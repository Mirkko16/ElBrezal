namespace ElBrezal.Desktop.Forms.Articulos.ActualizacionCostos
{
    partial class ActualizacionCostosForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBoxTitulo = new GroupBox();
            labelTitulo = new Label();
            lblFamilia = new Label();
            lblProveedor = new Label();
            lblMarca = new Label();
            groupBoxTipoAumento = new GroupBox();
            textBoxAumento = new TextBox();
            lblAumento = new Label();
            radioButtonImporte = new RadioButton();
            radioButtonPorcentaje = new RadioButton();
            dataGridViewProductos = new DataGridView();
            DataGridViewCheckBoxColumnSeleccionar = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumnCodigo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnProducto = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnMarca = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnProveedor = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxFamilia = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnPrecioContado = new DataGridViewTextBoxColumn();
            comboBoxFamilia = new ComboBox();
            comboBoxProveedor = new ComboBox();
            comboBoxMarca = new ComboBox();
            lblProdEncontrados = new Label();
            lblResultado = new Label();
            btnBuscarProductos = new Button();
            btnAplicarActualizacion = new Button();
            btnSalir = new Button();
            bindingSourceMarca = new BindingSource(components);
            bindingSourceProveedor = new BindingSource(components);
            bindingSourcefamilia = new BindingSource(components);
            bindingSourceProductos = new BindingSource(components);
            groupBoxTitulo.SuspendLayout();
            groupBoxTipoAumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceMarca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcefamilia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProductos).BeginInit();
            SuspendLayout();
            // 
            // groupBoxTitulo
            // 
            groupBoxTitulo.Controls.Add(labelTitulo);
            groupBoxTitulo.Location = new Point(173, 5);
            groupBoxTitulo.Name = "groupBoxTitulo";
            groupBoxTitulo.Size = new Size(455, 62);
            groupBoxTitulo.TabIndex = 0;
            groupBoxTitulo.TabStop = false;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(85, 31);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(277, 14);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = " ACTUALIZACIÓN GLOBAL DE COSTOS   ";
            // 
            // lblFamilia
            // 
            lblFamilia.AutoSize = true;
            lblFamilia.Location = new Point(36, 90);
            lblFamilia.Name = "lblFamilia";
            lblFamilia.Size = new Size(48, 15);
            lblFamilia.TabIndex = 1;
            lblFamilia.Text = "Familia:";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(36, 165);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 2;
            lblProveedor.Text = "Proveedor:";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(36, 126);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 3;
            lblMarca.Text = "Marca:";
            // 
            // groupBoxTipoAumento
            // 
            groupBoxTipoAumento.Controls.Add(textBoxAumento);
            groupBoxTipoAumento.Controls.Add(lblAumento);
            groupBoxTipoAumento.Controls.Add(radioButtonImporte);
            groupBoxTipoAumento.Controls.Add(radioButtonPorcentaje);
            groupBoxTipoAumento.Location = new Point(400, 73);
            groupBoxTipoAumento.Name = "groupBoxTipoAumento";
            groupBoxTipoAumento.Size = new Size(388, 75);
            groupBoxTipoAumento.TabIndex = 4;
            groupBoxTipoAumento.TabStop = false;
            groupBoxTipoAumento.Text = "Tipo de Aumento";
            // 
            // textBoxAumento
            // 
            textBoxAumento.Location = new Point(250, 18);
            textBoxAumento.Name = "textBoxAumento";
            textBoxAumento.Size = new Size(100, 23);
            textBoxAumento.TabIndex = 3;
            // 
            // lblAumento
            // 
            lblAumento.AutoSize = true;
            lblAumento.Location = new Point(182, 26);
            lblAumento.Name = "lblAumento";
            lblAumento.Size = new Size(60, 15);
            lblAumento.TabIndex = 2;
            lblAumento.Text = "Aumento:";
            // 
            // radioButtonImporte
            // 
            radioButtonImporte.AutoSize = true;
            radioButtonImporte.Location = new Point(40, 50);
            radioButtonImporte.Name = "radioButtonImporte";
            radioButtonImporte.Size = new Size(84, 19);
            radioButtonImporte.TabIndex = 1;
            radioButtonImporte.TabStop = true;
            radioButtonImporte.Text = "Importe ($)";
            radioButtonImporte.UseVisualStyleBackColor = true;
            // 
            // radioButtonPorcentaje
            // 
            radioButtonPorcentaje.AutoSize = true;
            radioButtonPorcentaje.Location = new Point(40, 22);
            radioButtonPorcentaje.Name = "radioButtonPorcentaje";
            radioButtonPorcentaje.Size = new Size(102, 19);
            radioButtonPorcentaje.TabIndex = 0;
            radioButtonPorcentaje.TabStop = true;
            radioButtonPorcentaje.Text = "Porcentaje (%)";
            radioButtonPorcentaje.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.AllowUserToAddRows = false;
            dataGridViewProductos.AllowUserToDeleteRows = false;
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Columns.AddRange(new DataGridViewColumn[] { DataGridViewCheckBoxColumnSeleccionar, DataGridViewTextBoxColumnCodigo, DataGridViewTextBoxColumnProducto, DataGridViewTextBoxColumnMarca, DataGridViewTextBoxColumnProveedor, DataGridViewTextBoxFamilia, DataGridViewTextBoxColumnPrecioContado });
            dataGridViewProductos.Location = new Point(36, 216);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.ReadOnly = true;
            dataGridViewProductos.Size = new Size(744, 327);
            dataGridViewProductos.TabIndex = 5;
            // 
            // DataGridViewCheckBoxColumnSeleccionar
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.NullValue = false;
            DataGridViewCheckBoxColumnSeleccionar.DefaultCellStyle = dataGridViewCellStyle2;
            DataGridViewCheckBoxColumnSeleccionar.HeaderText = "Seleccionar";
            DataGridViewCheckBoxColumnSeleccionar.Name = "DataGridViewCheckBoxColumnSeleccionar";
            DataGridViewCheckBoxColumnSeleccionar.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnCodigo
            // 
            DataGridViewTextBoxColumnCodigo.HeaderText = "Codigo";
            DataGridViewTextBoxColumnCodigo.Name = "DataGridViewTextBoxColumnCodigo";
            DataGridViewTextBoxColumnCodigo.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnProducto
            // 
            DataGridViewTextBoxColumnProducto.HeaderText = "Producto";
            DataGridViewTextBoxColumnProducto.Name = "DataGridViewTextBoxColumnProducto";
            DataGridViewTextBoxColumnProducto.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnMarca
            // 
            DataGridViewTextBoxColumnMarca.HeaderText = "Marca";
            DataGridViewTextBoxColumnMarca.Name = "DataGridViewTextBoxColumnMarca";
            DataGridViewTextBoxColumnMarca.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnProveedor
            // 
            DataGridViewTextBoxColumnProveedor.HeaderText = "Proveedor";
            DataGridViewTextBoxColumnProveedor.Name = "DataGridViewTextBoxColumnProveedor";
            DataGridViewTextBoxColumnProveedor.ReadOnly = true;
            // 
            // DataGridViewTextBoxFamilia
            // 
            DataGridViewTextBoxFamilia.HeaderText = "Familia";
            DataGridViewTextBoxFamilia.Name = "DataGridViewTextBoxFamilia";
            DataGridViewTextBoxFamilia.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnPrecioContado
            // 
            DataGridViewTextBoxColumnPrecioContado.HeaderText = "Precio";
            DataGridViewTextBoxColumnPrecioContado.Name = "DataGridViewTextBoxColumnPrecioContado";
            DataGridViewTextBoxColumnPrecioContado.ReadOnly = true;
            DataGridViewTextBoxColumnPrecioContado.Resizable = DataGridViewTriState.False;
            // 
            // comboBoxFamilia
            // 
            comboBoxFamilia.FormattingEnabled = true;
            comboBoxFamilia.Location = new Point(106, 82);
            comboBoxFamilia.Name = "comboBoxFamilia";
            comboBoxFamilia.Size = new Size(176, 23);
            comboBoxFamilia.TabIndex = 6;
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(106, 157);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(176, 23);
            comboBoxProveedor.TabIndex = 7;
            // 
            // comboBoxMarca
            // 
            comboBoxMarca.FormattingEnabled = true;
            comboBoxMarca.Location = new Point(106, 123);
            comboBoxMarca.Name = "comboBoxMarca";
            comboBoxMarca.Size = new Size(176, 23);
            comboBoxMarca.TabIndex = 8;
            // 
            // lblProdEncontrados
            // 
            lblProdEncontrados.AutoSize = true;
            lblProdEncontrados.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProdEncontrados.Location = new Point(526, 199);
            lblProdEncontrados.Name = "lblProdEncontrados";
            lblProdEncontrados.Size = new Size(167, 14);
            lblProdEncontrados.TabIndex = 9;
            lblProdEncontrados.Text = " Productos encontrados:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(699, 199);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(19, 14);
            lblResultado.TabIndex = 10;
            lblResultado.Text = "--";
            // 
            // btnBuscarProductos
            // 
            btnBuscarProductos.Location = new Point(400, 155);
            btnBuscarProductos.Name = "btnBuscarProductos";
            btnBuscarProductos.Size = new Size(112, 24);
            btnBuscarProductos.TabIndex = 11;
            btnBuscarProductos.Text = "Buscar Productos";
            btnBuscarProductos.UseVisualStyleBackColor = true;
            btnBuscarProductos.Click += btnBuscarProductos_Click;
            // 
            // btnAplicarActualizacion
            // 
            btnAplicarActualizacion.Location = new Point(582, 154);
            btnAplicarActualizacion.Name = "btnAplicarActualizacion";
            btnAplicarActualizacion.Size = new Size(112, 24);
            btnAplicarActualizacion.TabIndex = 12;
            btnAplicarActualizacion.Text = "Aplicar Actualizacion";
            btnAplicarActualizacion.UseVisualStyleBackColor = true;
            btnAplicarActualizacion.Click += btnAplicarActualizacion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(676, 549);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(112, 24);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // ActualizacionCostosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 579);
            Controls.Add(btnSalir);
            Controls.Add(btnAplicarActualizacion);
            Controls.Add(btnBuscarProductos);
            Controls.Add(lblResultado);
            Controls.Add(lblProdEncontrados);
            Controls.Add(comboBoxMarca);
            Controls.Add(comboBoxProveedor);
            Controls.Add(comboBoxFamilia);
            Controls.Add(dataGridViewProductos);
            Controls.Add(groupBoxTipoAumento);
            Controls.Add(lblMarca);
            Controls.Add(lblProveedor);
            Controls.Add(lblFamilia);
            Controls.Add(groupBoxTitulo);
            KeyPreview = true;
            Name = "ActualizacionCostosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ActualizacionCostosForm";
            Load += ActualizacionCostosForm_Load;
            KeyDown += ActualizacionCostosForm_KeyDown;
            groupBoxTitulo.ResumeLayout(false);
            groupBoxTitulo.PerformLayout();
            groupBoxTipoAumento.ResumeLayout(false);
            groupBoxTipoAumento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceMarca).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcefamilia).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxTitulo;
        private Label labelTitulo;
        private Label lblFamilia;
        private Label lblProveedor;
        private Label lblMarca;
        private GroupBox groupBoxTipoAumento;
        private TextBox textBoxAumento;
        private Label lblAumento;
        private RadioButton radioButtonImporte;
        private RadioButton radioButtonPorcentaje;
        private DataGridView dataGridViewProductos;
        private ComboBox comboBoxFamilia;
        private ComboBox comboBoxProveedor;
        private ComboBox comboBoxMarca;
        private Label lblProdEncontrados;
        private Label lblResultado;
        private Button btnBuscarProductos;
        private Button btnAplicarActualizacion;
        private Button btnSalir;
        private BindingSource bindingSourceMarca;
        private BindingSource bindingSourceProveedor;
        private BindingSource bindingSourcefamilia;
        private BindingSource bindingSourceProductos;
        private DataGridViewCheckBoxColumn DataGridViewCheckBoxColumnSeleccionar;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnCodigo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnProducto;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnMarca;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnProveedor;
        private DataGridViewTextBoxColumn DataGridViewTextBoxFamilia;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnPrecioContado;
    }
}