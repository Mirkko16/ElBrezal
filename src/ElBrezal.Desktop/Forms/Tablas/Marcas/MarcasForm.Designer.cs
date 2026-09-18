namespace ElBrezal.Desktop.Forms.Tablas.Marcas
{
    partial class MarcasForm
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
            dataGridViewMarcas = new DataGridView();
            textBoxDescripcion = new TextBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            lblDescripcion = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarcas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMarcas
            // 
            dataGridViewMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarcas.Location = new Point(61, 49);
            dataGridViewMarcas.Margin = new Padding(3, 2, 3, 2);
            dataGridViewMarcas.Name = "dataGridViewMarcas";
            dataGridViewMarcas.RowHeadersWidth = 51;
            dataGridViewMarcas.Size = new Size(387, 208);
            dataGridViewMarcas.TabIndex = 0;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.CharacterCasing = CharacterCasing.Upper;
            textBoxDescripcion.Location = new Point(107, 274);
            textBoxDescripcion.Margin = new Padding(3, 2, 3, 2);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(272, 23);
            textBoxDescripcion.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(383, 273);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(82, 24);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(466, 307);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(568, 307);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(82, 22);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(23, 279);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 5;
            lblDescripcion.Text = "Descripción:";
            // 
            // MarcasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lblDescripcion);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(textBoxDescripcion);
            Controls.Add(dataGridViewMarcas);
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MarcasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarcasForm";
            Load += MarcasForm_Load;
            KeyDown += MarcasForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarcas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewMarcas;
        private TextBox textBoxDescripcion;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnSalir;
        private Label lblDescripcion;
    }
}