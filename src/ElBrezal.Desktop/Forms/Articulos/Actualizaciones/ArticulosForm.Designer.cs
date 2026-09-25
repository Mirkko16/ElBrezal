namespace ElBrezal.Desktop.Forms.Articulos.Actualizaciones
{
    partial class ArticulosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticulosForm));
            gpDatosArticulo = new GroupBox();
            btnNuevaMarca = new Button();
            btnNuevaUnidad = new Button();
            btnNuevoProveedor = new Button();
            btnNuevaFamilia = new Button();
            comboBoxMarca = new ComboBox();
            comboBoxUnidad = new ComboBox();
            comboBoxProveedor = new ComboBox();
            comboBoxFamilia = new ComboBox();
            textBoxStock = new TextBox();
            textBoxFechaModificacion = new TextBox();
            textBoxFechaAlta = new TextBox();
            textBoxDescripcion = new TextBox();
            textBoxCodigo = new TextBox();
            lblProveedor = new Label();
            lblDescripcion = new Label();
            lblFechaAlta = new Label();
            lblFamilia = new Label();
            lblMarca = new Label();
            lblStock = new Label();
            lblfechaModificacion = new Label();
            lblUnidad = new Label();
            lblCodigo = new Label();
            lblContado = new Label();
            lblReventa = new Label();
            lblCtaCte = new Label();
            lblRentabilidad = new Label();
            lblPrecioSIVA = new Label();
            lblPreciocIVA = new Label();
            lblCategoria = new Label();
            gpPrecios = new GroupBox();
            comboBoxAlicuota = new ComboBox();
            textBoxCostoArt = new TextBox();
            textBoxCategoria = new TextBox();
            lblPRecioIVA = new Label();
            lblPrecioCtaCte = new Label();
            textBoxReventaSIVA = new TextBox();
            lblPrecioReventa = new Label();
            textBoxCtaCteSIVA = new TextBox();
            textBoxContadoSIVA = new TextBox();
            textBoxrentaReventa = new TextBox();
            textBoxRentaCtaCte = new TextBox();
            textBoxRentaContado = new TextBox();
            label13 = new Label();
            lblCosto = new Label();
            lblPosicion = new Label();
            btnUltimo = new Button();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnSalir = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            bindingSourceArticulos = new BindingSource(components);
            bindingSourceProveedor = new BindingSource(components);
            bindingSourceAlicuota = new BindingSource(components);
            bindingSourceFamilia = new BindingSource(components);
            bindingSourceMarca = new BindingSource(components);
            bindingSourceUnidad = new BindingSource(components);
            textBoxStockMinimo = new TextBox();
            label1 = new Label();
            gpDatosArticulo.SuspendLayout();
            gpPrecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceAlicuota).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFamilia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceMarca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceUnidad).BeginInit();
            SuspendLayout();
            // 
            // gpDatosArticulo
            // 
            gpDatosArticulo.Controls.Add(textBoxStockMinimo);
            gpDatosArticulo.Controls.Add(label1);
            gpDatosArticulo.Controls.Add(btnNuevaMarca);
            gpDatosArticulo.Controls.Add(btnNuevaUnidad);
            gpDatosArticulo.Controls.Add(btnNuevoProveedor);
            gpDatosArticulo.Controls.Add(btnNuevaFamilia);
            gpDatosArticulo.Controls.Add(comboBoxMarca);
            gpDatosArticulo.Controls.Add(comboBoxUnidad);
            gpDatosArticulo.Controls.Add(comboBoxProveedor);
            gpDatosArticulo.Controls.Add(comboBoxFamilia);
            gpDatosArticulo.Controls.Add(textBoxStock);
            gpDatosArticulo.Controls.Add(textBoxFechaModificacion);
            gpDatosArticulo.Controls.Add(textBoxFechaAlta);
            gpDatosArticulo.Controls.Add(textBoxDescripcion);
            gpDatosArticulo.Controls.Add(textBoxCodigo);
            gpDatosArticulo.Controls.Add(lblProveedor);
            gpDatosArticulo.Controls.Add(lblDescripcion);
            gpDatosArticulo.Controls.Add(lblFechaAlta);
            gpDatosArticulo.Controls.Add(lblFamilia);
            gpDatosArticulo.Controls.Add(lblMarca);
            gpDatosArticulo.Controls.Add(lblStock);
            gpDatosArticulo.Controls.Add(lblfechaModificacion);
            gpDatosArticulo.Controls.Add(lblUnidad);
            gpDatosArticulo.Controls.Add(lblCodigo);
            gpDatosArticulo.Location = new Point(17, 23);
            gpDatosArticulo.Margin = new Padding(3, 2, 3, 2);
            gpDatosArticulo.Name = "gpDatosArticulo";
            gpDatosArticulo.Padding = new Padding(3, 2, 3, 2);
            gpDatosArticulo.Size = new Size(802, 183);
            gpDatosArticulo.TabIndex = 13;
            gpDatosArticulo.TabStop = false;
            gpDatosArticulo.Text = "Datos Articulo";
            // 
            // btnNuevaMarca
            // 
            btnNuevaMarca.Location = new Point(338, 83);
            btnNuevaMarca.Name = "btnNuevaMarca";
            btnNuevaMarca.Size = new Size(25, 23);
            btnNuevaMarca.TabIndex = 5;
            btnNuevaMarca.Text = "...";
            btnNuevaMarca.UseVisualStyleBackColor = true;
            btnNuevaMarca.Click += btnNuevaMarca_Click;
            // 
            // btnNuevaUnidad
            // 
            btnNuevaUnidad.Location = new Point(338, 113);
            btnNuevaUnidad.Name = "btnNuevaUnidad";
            btnNuevaUnidad.Size = new Size(25, 23);
            btnNuevaUnidad.TabIndex = 7;
            btnNuevaUnidad.Text = "...";
            btnNuevaUnidad.UseVisualStyleBackColor = true;
            btnNuevaUnidad.Click += btnNuevaUnidad_Click;
            // 
            // btnNuevoProveedor
            // 
            btnNuevoProveedor.Location = new Point(338, 142);
            btnNuevoProveedor.Name = "btnNuevoProveedor";
            btnNuevoProveedor.Size = new Size(25, 23);
            btnNuevoProveedor.TabIndex = 9;
            btnNuevoProveedor.Text = "...";
            btnNuevoProveedor.UseVisualStyleBackColor = true;
            btnNuevoProveedor.Click += btnNuevoProveedor_Click;
            // 
            // btnNuevaFamilia
            // 
            btnNuevaFamilia.Location = new Point(338, 54);
            btnNuevaFamilia.Name = "btnNuevaFamilia";
            btnNuevaFamilia.Size = new Size(25, 23);
            btnNuevaFamilia.TabIndex = 3;
            btnNuevaFamilia.Text = "...";
            btnNuevaFamilia.UseVisualStyleBackColor = true;
            btnNuevaFamilia.Click += btnNuevaFamilia_Click;
            // 
            // comboBoxMarca
            // 
            comboBoxMarca.FormattingEnabled = true;
            comboBoxMarca.Location = new Point(101, 83);
            comboBoxMarca.Name = "comboBoxMarca";
            comboBoxMarca.Size = new Size(231, 23);
            comboBoxMarca.TabIndex = 4;
            // 
            // comboBoxUnidad
            // 
            comboBoxUnidad.FormattingEnabled = true;
            comboBoxUnidad.Location = new Point(101, 112);
            comboBoxUnidad.Name = "comboBoxUnidad";
            comboBoxUnidad.Size = new Size(231, 23);
            comboBoxUnidad.TabIndex = 6;
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(101, 142);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(231, 23);
            comboBoxProveedor.TabIndex = 8;
            // 
            // comboBoxFamilia
            // 
            comboBoxFamilia.FormattingEnabled = true;
            comboBoxFamilia.Location = new Point(101, 55);
            comboBoxFamilia.Name = "comboBoxFamilia";
            comboBoxFamilia.Size = new Size(231, 23);
            comboBoxFamilia.TabIndex = 2;
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(611, 121);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(100, 23);
            textBoxStock.TabIndex = 10;
            textBoxStock.KeyPress += textBoxStock_KeyPress;
            // 
            // textBoxFechaModificacion
            // 
            textBoxFechaModificacion.Location = new Point(611, 88);
            textBoxFechaModificacion.Name = "textBoxFechaModificacion";
            textBoxFechaModificacion.ReadOnly = true;
            textBoxFechaModificacion.Size = new Size(100, 23);
            textBoxFechaModificacion.TabIndex = 41;
            // 
            // textBoxFechaAlta
            // 
            textBoxFechaAlta.Location = new Point(611, 52);
            textBoxFechaAlta.Name = "textBoxFechaAlta";
            textBoxFechaAlta.ReadOnly = true;
            textBoxFechaAlta.Size = new Size(100, 23);
            textBoxFechaAlta.TabIndex = 40;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.CharacterCasing = CharacterCasing.Upper;
            textBoxDescripcion.Location = new Point(234, 18);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(477, 23);
            textBoxDescripcion.TabIndex = 1;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(55, 18);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.ReadOnly = true;
            textBoxCodigo.Size = new Size(69, 23);
            textBoxCodigo.TabIndex = 38;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(10, 150);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 37;
            lblProveedor.Text = "Proveedor:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(156, 26);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 23;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(477, 63);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(65, 15);
            lblFechaAlta.TabIndex = 36;
            lblFechaAlta.Text = "Fecha Alta:";
            // 
            // lblFamilia
            // 
            lblFamilia.AutoSize = true;
            lblFamilia.Location = new Point(10, 63);
            lblFamilia.Name = "lblFamilia";
            lblFamilia.Size = new Size(48, 15);
            lblFamilia.TabIndex = 22;
            lblFamilia.Text = "Familia:";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(10, 91);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 21;
            lblMarca.Text = "Marca:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(477, 129);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 20;
            lblStock.Text = "Stock:";
            // 
            // lblfechaModificacion
            // 
            lblfechaModificacion.AutoSize = true;
            lblfechaModificacion.Location = new Point(477, 97);
            lblfechaModificacion.Name = "lblfechaModificacion";
            lblfechaModificacion.Size = new Size(114, 15);
            lblfechaModificacion.TabIndex = 34;
            lblfechaModificacion.Text = "Fecha Modificación:";
            // 
            // lblUnidad
            // 
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new Point(10, 121);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(48, 15);
            lblUnidad.TabIndex = 18;
            lblUnidad.Text = "Unidad:";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(5, 26);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(49, 15);
            lblCodigo.TabIndex = 17;
            lblCodigo.Text = "Código:";
            // 
            // lblContado
            // 
            lblContado.AutoSize = true;
            lblContado.Location = new Point(13, 82);
            lblContado.Name = "lblContado";
            lblContado.Size = new Size(56, 15);
            lblContado.TabIndex = 31;
            lblContado.Text = "Contado:";
            // 
            // lblReventa
            // 
            lblReventa.AutoSize = true;
            lblReventa.Location = new Point(13, 111);
            lblReventa.Name = "lblReventa";
            lblReventa.Size = new Size(52, 15);
            lblReventa.TabIndex = 30;
            lblReventa.Text = "Reventa:";
            // 
            // lblCtaCte
            // 
            lblCtaCte.AutoSize = true;
            lblCtaCte.Location = new Point(13, 140);
            lblCtaCte.Name = "lblCtaCte";
            lblCtaCte.Size = new Size(100, 15);
            lblCtaCte.TabIndex = 27;
            lblCtaCte.Text = "Cuenta Corriente:";
            // 
            // lblRentabilidad
            // 
            lblRentabilidad.AutoSize = true;
            lblRentabilidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRentabilidad.Location = new Point(271, 56);
            lblRentabilidad.Name = "lblRentabilidad";
            lblRentabilidad.Size = new Size(76, 15);
            lblRentabilidad.TabIndex = 26;
            lblRentabilidad.Text = "Rentabilidad";
            // 
            // lblPrecioSIVA
            // 
            lblPrecioSIVA.AutoSize = true;
            lblPrecioSIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecioSIVA.Location = new Point(456, 56);
            lblPrecioSIVA.Name = "lblPrecioSIVA";
            lblPrecioSIVA.Size = new Size(74, 15);
            lblPrecioSIVA.TabIndex = 25;
            lblPrecioSIVA.Text = "Precio s/IVA";
            // 
            // lblPreciocIVA
            // 
            lblPreciocIVA.AutoSize = true;
            lblPreciocIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreciocIVA.Location = new Point(613, 56);
            lblPreciocIVA.Name = "lblPreciocIVA";
            lblPreciocIVA.Size = new Size(75, 15);
            lblPreciocIVA.TabIndex = 24;
            lblPreciocIVA.Text = "Precio c/IVA";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(13, 181);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 19;
            lblCategoria.Text = "Categoría:";
            // 
            // gpPrecios
            // 
            gpPrecios.Controls.Add(comboBoxAlicuota);
            gpPrecios.Controls.Add(textBoxCostoArt);
            gpPrecios.Controls.Add(textBoxCategoria);
            gpPrecios.Controls.Add(lblPRecioIVA);
            gpPrecios.Controls.Add(lblPrecioCtaCte);
            gpPrecios.Controls.Add(textBoxReventaSIVA);
            gpPrecios.Controls.Add(lblPrecioReventa);
            gpPrecios.Controls.Add(textBoxCtaCteSIVA);
            gpPrecios.Controls.Add(textBoxContadoSIVA);
            gpPrecios.Controls.Add(textBoxrentaReventa);
            gpPrecios.Controls.Add(textBoxRentaCtaCte);
            gpPrecios.Controls.Add(textBoxRentaContado);
            gpPrecios.Controls.Add(lblContado);
            gpPrecios.Controls.Add(lblReventa);
            gpPrecios.Controls.Add(lblCategoria);
            gpPrecios.Controls.Add(label13);
            gpPrecios.Controls.Add(lblCtaCte);
            gpPrecios.Controls.Add(lblRentabilidad);
            gpPrecios.Controls.Add(lblPrecioSIVA);
            gpPrecios.Controls.Add(lblCosto);
            gpPrecios.Controls.Add(lblPreciocIVA);
            gpPrecios.Location = new Point(17, 211);
            gpPrecios.Name = "gpPrecios";
            gpPrecios.Size = new Size(802, 213);
            gpPrecios.TabIndex = 15;
            gpPrecios.TabStop = false;
            gpPrecios.Text = "Precios";
            // 
            // comboBoxAlicuota
            // 
            comboBoxAlicuota.FormattingEnabled = true;
            comboBoxAlicuota.Location = new Point(385, 20);
            comboBoxAlicuota.Name = "comboBoxAlicuota";
            comboBoxAlicuota.Size = new Size(157, 23);
            comboBoxAlicuota.TabIndex = 12;
            comboBoxAlicuota.SelectedIndexChanged += comboBoxAlicuota_SelectedIndexChanged;
            // 
            // textBoxCostoArt
            // 
            textBoxCostoArt.Location = new Point(80, 20);
            textBoxCostoArt.Name = "textBoxCostoArt";
            textBoxCostoArt.Size = new Size(100, 23);
            textBoxCostoArt.TabIndex = 11;
            textBoxCostoArt.KeyPress += textBoxCostoArt_KeyPress;
            textBoxCostoArt.Leave += textBoxCostoArt_Leave;
            // 
            // textBoxCategoria
            // 
            textBoxCategoria.Location = new Point(80, 173);
            textBoxCategoria.Name = "textBoxCategoria";
            textBoxCategoria.ReadOnly = true;
            textBoxCategoria.Size = new Size(100, 23);
            textBoxCategoria.TabIndex = 57;
            // 
            // lblPRecioIVA
            // 
            lblPRecioIVA.AutoSize = true;
            lblPRecioIVA.Location = new Point(613, 77);
            lblPRecioIVA.Name = "lblPRecioIVA";
            lblPRecioIVA.Size = new Size(34, 15);
            lblPRecioIVA.TabIndex = 53;
            lblPRecioIVA.Text = "$0.00";
            // 
            // lblPrecioCtaCte
            // 
            lblPrecioCtaCte.AutoSize = true;
            lblPrecioCtaCte.Location = new Point(613, 135);
            lblPrecioCtaCte.Name = "lblPrecioCtaCte";
            lblPrecioCtaCte.Size = new Size(34, 15);
            lblPrecioCtaCte.TabIndex = 51;
            lblPrecioCtaCte.Text = "$0.00";
            // 
            // textBoxReventaSIVA
            // 
            textBoxReventaSIVA.Location = new Point(442, 103);
            textBoxReventaSIVA.Name = "textBoxReventaSIVA";
            textBoxReventaSIVA.Size = new Size(100, 23);
            textBoxReventaSIVA.TabIndex = 16;
            textBoxReventaSIVA.KeyPress += textBoxReventaSIVA_KeyPress;
            textBoxReventaSIVA.Leave += textBoxReventaSIVA_Leave;
            // 
            // lblPrecioReventa
            // 
            lblPrecioReventa.AutoSize = true;
            lblPrecioReventa.Location = new Point(613, 106);
            lblPrecioReventa.Name = "lblPrecioReventa";
            lblPrecioReventa.Size = new Size(34, 15);
            lblPrecioReventa.TabIndex = 52;
            lblPrecioReventa.Text = "$0.00";
            // 
            // textBoxCtaCteSIVA
            // 
            textBoxCtaCteSIVA.Location = new Point(442, 132);
            textBoxCtaCteSIVA.Name = "textBoxCtaCteSIVA";
            textBoxCtaCteSIVA.Size = new Size(100, 23);
            textBoxCtaCteSIVA.TabIndex = 18;
            textBoxCtaCteSIVA.KeyPress += textBoxCtaCteSIVA_KeyPress;
            textBoxCtaCteSIVA.Leave += textBoxCtaCteSIVA_Leave;
            // 
            // textBoxContadoSIVA
            // 
            textBoxContadoSIVA.Location = new Point(442, 74);
            textBoxContadoSIVA.Name = "textBoxContadoSIVA";
            textBoxContadoSIVA.Size = new Size(100, 23);
            textBoxContadoSIVA.TabIndex = 14;
            textBoxContadoSIVA.KeyPress += textBoxContadoSIVA_KeyPress;
            textBoxContadoSIVA.Leave += textBoxContadoSIVA_Leave;
            // 
            // textBoxrentaReventa
            // 
            textBoxrentaReventa.Location = new Point(263, 103);
            textBoxrentaReventa.Name = "textBoxrentaReventa";
            textBoxrentaReventa.Size = new Size(100, 23);
            textBoxrentaReventa.TabIndex = 15;
            textBoxrentaReventa.KeyPress += textBoxrentaReventa_KeyPress;
            textBoxrentaReventa.Leave += textBoxrentaReventa_Leave;
            // 
            // textBoxRentaCtaCte
            // 
            textBoxRentaCtaCte.Location = new Point(263, 132);
            textBoxRentaCtaCte.Name = "textBoxRentaCtaCte";
            textBoxRentaCtaCte.Size = new Size(100, 23);
            textBoxRentaCtaCte.TabIndex = 17;
            textBoxRentaCtaCte.KeyPress += textBoxRentaCtaCte_KeyPress;
            textBoxRentaCtaCte.Leave += textBoxRentaCtaCte_Leave;
            // 
            // textBoxRentaContado
            // 
            textBoxRentaContado.Location = new Point(263, 74);
            textBoxRentaContado.Name = "textBoxRentaContado";
            textBoxRentaContado.Size = new Size(100, 23);
            textBoxRentaContado.TabIndex = 13;
            textBoxRentaContado.KeyPress += textBoxRentaContado_KeyPress;
            textBoxRentaContado.Leave += textBoxRentaContado_Leave;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(305, 28);
            label13.Name = "label13";
            label13.Size = new Size(74, 15);
            label13.TabIndex = 37;
            label13.Text = "Alicuota IVA:";
            // 
            // lblCosto
            // 
            lblCosto.AutoSize = true;
            lblCosto.Location = new Point(13, 28);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(41, 15);
            lblCosto.TabIndex = 35;
            lblCosto.Text = "Costo:";
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Location = new Point(136, 443);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(12, 15);
            lblPosicion.TabIndex = 34;
            lblPosicion.Text = "-";
            // 
            // btnUltimo
            // 
            btnUltimo.BackgroundImage = (Image)resources.GetObject("btnUltimo.BackgroundImage");
            btnUltimo.BackgroundImageLayout = ImageLayout.Stretch;
            btnUltimo.Location = new Point(264, 438);
            btnUltimo.Margin = new Padding(3, 2, 3, 2);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(32, 23);
            btnUltimo.TabIndex = 33;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.BackgroundImage = (Image)resources.GetObject("btnPrimero.BackgroundImage");
            btnPrimero.BackgroundImageLayout = ImageLayout.Stretch;
            btnPrimero.Location = new Point(25, 438);
            btnPrimero.Margin = new Padding(3, 2, 3, 2);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(32, 23);
            btnPrimero.TabIndex = 32;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackgroundImage = (Image)resources.GetObject("btnAnterior.BackgroundImage");
            btnAnterior.BackgroundImageLayout = ImageLayout.Stretch;
            btnAnterior.Location = new Point(67, 438);
            btnAnterior.Margin = new Padding(3, 2, 3, 2);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(32, 23);
            btnAnterior.TabIndex = 31;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackgroundImage = (Image)resources.GetObject("btnSiguiente.BackgroundImage");
            btnSiguiente.BackgroundImageLayout = ImageLayout.Stretch;
            btnSiguiente.Location = new Point(227, 438);
            btnSiguiente.Margin = new Padding(3, 2, 3, 2);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(32, 23);
            btnSiguiente.TabIndex = 30;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(710, 440);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(82, 22);
            btnSalir.TabIndex = 29;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(623, 440);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 28;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(535, 440);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(82, 22);
            btnModificar.TabIndex = 27;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(448, 440);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(82, 22);
            btnNuevo.TabIndex = 26;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // bindingSourceArticulos
            // 
            bindingSourceArticulos.PositionChanged += bindingSourceArticulos_PositionChanged;
            // 
            // textBoxStockMinimo
            // 
            textBoxStockMinimo.Location = new Point(611, 150);
            textBoxStockMinimo.Name = "textBoxStockMinimo";
            textBoxStockMinimo.Size = new Size(100, 23);
            textBoxStockMinimo.TabIndex = 42;
            textBoxStockMinimo.KeyPress += textBoxStockMinimo_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(477, 158);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 43;
            label1.Text = "Stock Minimo:";
            // 
            // ArticulosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 486);
            Controls.Add(lblPosicion);
            Controls.Add(btnUltimo);
            Controls.Add(btnPrimero);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(gpPrecios);
            Controls.Add(gpDatosArticulo);
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ArticulosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ArticulosForm";
            Load += ArticulosForm_Load;
            KeyDown += ArticulosForm_KeyDown;
            gpDatosArticulo.ResumeLayout(false);
            gpDatosArticulo.PerformLayout();
            gpPrecios.ResumeLayout(false);
            gpPrecios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceAlicuota).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFamilia).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceMarca).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceUnidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gpDatosArticulo;
        private Label lblContado;
        private Label lblReventa;
        private Label lblCtaCte;
        private Label lblRentabilidad;
        private Label lblPrecioSIVA;
        private Label lblPreciocIVA;
        private Label lblDescripcion;
        private Label lblFamilia;
        private Label lblMarca;
        private Label lblStock;
        private Label lblCategoria;
        private Label lblUnidad;
        private Label lblCodigo;
        private Label lblFechaAlta;
        private Label lblfechaModificacion;
        private GroupBox gpPrecios;
        private Label label13;
        private Label lblCosto;
        private Label lblProveedor;
        private TextBox textBoxDescripcion;
        private TextBox textBoxCodigo;
        private Label lblPosicion;
        private Button btnUltimo;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnSalir;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private ComboBox comboBoxMarca;
        private ComboBox comboBoxUnidad;
        private ComboBox comboBoxProveedor;
        private ComboBox comboBoxFamilia;
        private TextBox textBoxStock;
        private TextBox textBoxFechaModificacion;
        private TextBox textBoxFechaAlta;
        private Button btnNuevaMarca;
        private Button btnNuevaUnidad;
        private Button btnNuevoProveedor;
        private Button btnNuevaFamilia;
        private TextBox textBoxCategoria;
        private Label lblPRecioIVA;
        private Label lblPrecioCtaCte;
        private TextBox textBoxReventaSIVA;
        private Label lblPrecioReventa;
        private TextBox textBoxCtaCteSIVA;
        private TextBox textBoxContadoSIVA;
        private TextBox textBoxrentaReventa;
        private TextBox textBoxRentaCtaCte;
        private TextBox textBoxRentaContado;
        private TextBox textBoxCostoArt;
        private ComboBox comboBoxAlicuota;
        private BindingSource bindingSourceArticulos;
        private BindingSource bindingSourceProveedor;
        private BindingSource bindingSourceAlicuota;
        private BindingSource bindingSourceFamilia;
        private BindingSource bindingSourceMarca;
        private BindingSource bindingSourceUnidad;
        private TextBox textBoxStockMinimo;
        private Label label1;
    }
}