namespace ElBrezal.Desktop.Forms.Clientes
{
    partial class BuscarClientesForm
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
            lblBuscarCliente = new Label();
            textBoxBuscar = new TextBox();
            dataGridViewClientes = new DataGridView();
            dataGridViewTextBoxColumnCuenta = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnNombre = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnCUIT = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnLocalidad = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            SuspendLayout();
            // 
            // lblBuscarCliente
            // 
            lblBuscarCliente.AutoSize = true;
            lblBuscarCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscarCliente.Location = new Point(25, 27);
            lblBuscarCliente.Name = "lblBuscarCliente";
            lblBuscarCliente.Size = new Size(47, 15);
            lblBuscarCliente.TabIndex = 0;
            lblBuscarCliente.Text = "Buscar:";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.CharacterCasing = CharacterCasing.Upper;
            textBoxBuscar.Location = new Point(78, 19);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(393, 23);
            textBoxBuscar.TabIndex = 1;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            textBoxBuscar.KeyDown += textBoxBuscar_KeyDown;
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnCuenta, dataGridViewTextBoxColumnNombre, dataGridViewTextBoxColumnCUIT, dataGridViewTextBoxColumnLocalidad });
            dataGridViewClientes.Location = new Point(25, 66);
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.Size = new Size(446, 264);
            dataGridViewClientes.TabIndex = 2;
            dataGridViewClientes.CellDoubleClick += dataGridViewClientes_CellDoubleClick;
            dataGridViewClientes.KeyDown += dataGridViewClientes_KeyDown;
            // 
            // dataGridViewTextBoxColumnCuenta
            // 
            dataGridViewTextBoxColumnCuenta.HeaderText = "Cuenta";
            dataGridViewTextBoxColumnCuenta.Name = "dataGridViewTextBoxColumnCuenta";
            dataGridViewTextBoxColumnCuenta.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnNombre
            // 
            dataGridViewTextBoxColumnNombre.HeaderText = "Nombre";
            dataGridViewTextBoxColumnNombre.Name = "dataGridViewTextBoxColumnNombre";
            dataGridViewTextBoxColumnNombre.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnCUIT
            // 
            dataGridViewTextBoxColumnCUIT.HeaderText = "CUIT";
            dataGridViewTextBoxColumnCUIT.Name = "dataGridViewTextBoxColumnCUIT";
            dataGridViewTextBoxColumnCUIT.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnLocalidad
            // 
            dataGridViewTextBoxColumnLocalidad.HeaderText = "Localidad";
            dataGridViewTextBoxColumnLocalidad.Name = "dataGridViewTextBoxColumnLocalidad";
            dataGridViewTextBoxColumnLocalidad.ReadOnly = true;
            // 
            // BuscarClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 379);
            Controls.Add(dataGridViewClientes);
            Controls.Add(textBoxBuscar);
            Controls.Add(lblBuscarCliente);
            Name = "BuscarClientesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuscarClientesForm";
            Load += BuscarClientesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscarCliente;
        private TextBox textBoxBuscar;
        private DataGridView dataGridViewClientes;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnCuenta;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnNombre;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnCUIT;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnLocalidad;
    }
}