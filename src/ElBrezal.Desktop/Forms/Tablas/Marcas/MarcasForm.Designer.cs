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
            dataGridViewMarcas.Location = new Point(70, 65);
            dataGridViewMarcas.Name = "dataGridViewMarcas";
            dataGridViewMarcas.RowHeadersWidth = 51;
            dataGridViewMarcas.Size = new Size(442, 278);
            dataGridViewMarcas.TabIndex = 0;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.CharacterCasing = CharacterCasing.Upper;
            textBoxDescripcion.Location = new Point(122, 365);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(310, 27);
            textBoxDescripcion.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(438, 364);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(532, 409);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(649, 409);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(26, 372);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 5;
            lblDescripcion.Text = "Descripción:";
            // 
            // MarcasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDescripcion);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(textBoxDescripcion);
            Controls.Add(dataGridViewMarcas);
            KeyPreview = true;
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