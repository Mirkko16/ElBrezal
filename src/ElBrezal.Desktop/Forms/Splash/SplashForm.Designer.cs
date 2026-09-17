namespace ElBrezal.Desktop.Forms.Splash
{
    partial class SplashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            lblEstado = new Label();
            lblVersion = new Label();
            splashTimer = new System.Windows.Forms.Timer(components);
            progressBarCarga = new ProgressBar();
            lblPorcentaje = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(12, 273);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(133, 20);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Iniciando sistema...";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(511, 274);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(91, 20);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "Versión 2.0.0";
            // 
            // splashTimer
            // 
            splashTimer.Interval = 3500;
            // 
            // progressBarCarga
            // 
            progressBarCarga.Location = new Point(12, 244);
            progressBarCarga.Name = "progressBarCarga";
            progressBarCarga.Size = new Size(575, 26);
            progressBarCarga.TabIndex = 4;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new Point(437, 274);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(29, 20);
            lblPorcentaje.TabIndex = 5;
            lblPorcentaje.Text = "0%";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(575, 227);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // SplashForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(614, 302);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(lblPorcentaje);
            Controls.Add(progressBarCarga);
            Controls.Add(lblVersion);
            Controls.Add(lblEstado);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SplashForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashForm";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblEstado;
        private Label lblVersion;
        private System.Windows.Forms.Timer splashTimer;
        private ProgressBar progressBarCarga;
        private Label lblPorcentaje;
        private PictureBox pictureBox1;
    }
}