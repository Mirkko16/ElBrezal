namespace ElBrezal.Desktop.Forms.Tablas.Localidades
{
    partial class BuscarLocalidadesForm
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
            dataGridViewLocalidades = new DataGridView();
            dataGridViewTextBoxColumnId = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnCodigoPostal = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnNombre = new DataGridViewTextBoxColumn();
            textBoxBuscar = new TextBox();
            lblBuscarCliente = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLocalidades).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewLocalidades
            // 
            dataGridViewLocalidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLocalidades.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnId, dataGridViewTextBoxColumnCodigoPostal, dataGridViewTextBoxColumnNombre });
            dataGridViewLocalidades.Location = new Point(26, 63);
            dataGridViewLocalidades.Name = "dataGridViewLocalidades";
            dataGridViewLocalidades.Size = new Size(446, 264);
            dataGridViewLocalidades.TabIndex = 5;
            dataGridViewLocalidades.CellDoubleClick += dataGridViewLocalidades_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumnId
            // 
            dataGridViewTextBoxColumnId.HeaderText = "Id";
            dataGridViewTextBoxColumnId.Name = "dataGridViewTextBoxColumnId";
            dataGridViewTextBoxColumnId.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnCodigoPostal
            // 
            dataGridViewTextBoxColumnCodigoPostal.HeaderText = "Codigo Postal";
            dataGridViewTextBoxColumnCodigoPostal.Name = "dataGridViewTextBoxColumnCodigoPostal";
            dataGridViewTextBoxColumnCodigoPostal.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnNombre
            // 
            dataGridViewTextBoxColumnNombre.HeaderText = "Nombre";
            dataGridViewTextBoxColumnNombre.Name = "dataGridViewTextBoxColumnNombre";
            dataGridViewTextBoxColumnNombre.ReadOnly = true;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.CharacterCasing = CharacterCasing.Upper;
            textBoxBuscar.Location = new Point(79, 16);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(393, 23);
            textBoxBuscar.TabIndex = 4;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // lblBuscarCliente
            // 
            lblBuscarCliente.AutoSize = true;
            lblBuscarCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscarCliente.Location = new Point(26, 24);
            lblBuscarCliente.Name = "lblBuscarCliente";
            lblBuscarCliente.Size = new Size(47, 15);
            lblBuscarCliente.TabIndex = 3;
            lblBuscarCliente.Text = "Buscar:";
            // 
            // BuscarLocalidadesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 354);
            Controls.Add(dataGridViewLocalidades);
            Controls.Add(textBoxBuscar);
            Controls.Add(lblBuscarCliente);
            Name = "BuscarLocalidadesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuscarLocalidadesForm";
            Load += BuscarLocalidadesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewLocalidades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewLocalidades;
        private TextBox textBoxBuscar;
        private Label lblBuscarCliente;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnCodigoPostal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnNombre;
    }
}