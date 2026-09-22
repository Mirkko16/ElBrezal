namespace ElBrezal.Desktop.Forms.Tablas.Familias
{
    partial class FamiliasForm
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
            lblDescripcion = new Label();
            btnSalir = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            textBoxDescripcion = new TextBox();
            dataGridViewFamilias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFamilias).BeginInit();
            SuspendLayout();
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(70, 307);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 11;
            lblDescripcion.Text = "Descripción:";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(674, 335);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(574, 335);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(482, 298);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 32);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.CharacterCasing = CharacterCasing.Upper;
            textBoxDescripcion.Location = new Point(166, 299);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(310, 27);
            textBoxDescripcion.TabIndex = 7;
            // 
            // dataGridViewFamilias
            // 
            dataGridViewFamilias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFamilias.Location = new Point(77, 51);
            dataGridViewFamilias.Name = "dataGridViewFamilias";
            dataGridViewFamilias.RowHeadersWidth = 51;
            dataGridViewFamilias.Size = new Size(499, 219);
            dataGridViewFamilias.TabIndex = 6;
            // 
            // FamiliasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 381);
            Controls.Add(lblDescripcion);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(textBoxDescripcion);
            Controls.Add(dataGridViewFamilias);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FamiliasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FamiliasForm";
            Load += FamiliasForm_Load;
            KeyDown += FamiliasForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFamilias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDescripcion;
        private Button btnSalir;
        private Button btnEliminar;
        private Button btnAgregar;
        private TextBox textBoxDescripcion;
        private DataGridView dataGridViewFamilias;
    }
}