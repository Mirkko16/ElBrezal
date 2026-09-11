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
            pbSplashForm = new PictureBox();
            lblSplash = new Label();
            lblInfoSplash = new Label();
            lblVersion = new Label();
            splashTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbSplashForm).BeginInit();
            SuspendLayout();
            // 
            // pbSplashForm
            // 
            pbSplashForm.Location = new Point(74, 125);
            pbSplashForm.Name = "pbSplashForm";
            pbSplashForm.Size = new Size(125, 62);
            pbSplashForm.TabIndex = 0;
            pbSplashForm.TabStop = false;
            // 
            // lblSplash
            // 
            lblSplash.AutoSize = true;
            lblSplash.Location = new Point(53, 15);
            lblSplash.Name = "lblSplash";
            lblSplash.Size = new Size(176, 20);
            lblSplash.TabIndex = 1;
            lblSplash.Text = "Módulo Gestión de Stock";
            // 
            // lblInfoSplash
            // 
            lblInfoSplash.AutoSize = true;
            lblInfoSplash.Location = new Point(33, 256);
            lblInfoSplash.Name = "lblInfoSplash";
            lblInfoSplash.Size = new Size(161, 20);
            lblInfoSplash.TabIndex = 2;
            lblInfoSplash.Text = "Chequeando Registro...";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(464, 261);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(91, 20);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "Versión 2.0.0";
            // 
            // splashTimer
            // 
            splashTimer.Interval = 1500;
            // 
            // SplashForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 302);
            ControlBox = false;
            Controls.Add(lblVersion);
            Controls.Add(lblInfoSplash);
            Controls.Add(lblSplash);
            Controls.Add(pbSplashForm);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SplashForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "SplashForm";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pbSplashForm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSplashForm;
        private Label lblSplash;
        private Label lblInfoSplash;
        private Label lblVersion;
        private System.Windows.Forms.Timer splashTimer;
    }
}